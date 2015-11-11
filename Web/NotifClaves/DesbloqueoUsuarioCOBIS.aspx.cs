using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COBISDesbloqueo;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;
using WSE3.CustomAssertion.RemoveAddressingHeaders;
using System.Configuration;
using PhalanxBL;

public partial class DesbloqueoUsuarioCOBIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            trTitRespuesta.Visible = false;
            trRespuesta.Visible = false;
        }
    }
    protected void btnDesbloquear_Click(object sender, EventArgs e)
    {
        if (Session["Dominio"] != null && Session["Usuario"] != null)
        {
            PhxConfigBusiness pcb = new PhxConfigBusiness();

            string usuarioLlamada = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.UsuarioLlamadaWSCOBIS).ShortTxtValue;
            string idAplicacion = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.IDAplicacionWSCOBIS).ShortTxtValue;
            string estado = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.EstadoWSCOBIS).ShortTxtValue;
            string quienLlama = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.QuienLlamaWSCOBIS).ShortTxtValue;

            COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisServiceWse serviceProxy = new BloqueoDesbloqueoUsuariosCobisServiceWse();
            UsernameToken token = new UsernameToken(usuarioLlamada, "a", PasswordOption.SendNone);
            serviceProxy.SetClientCredential(token);
            serviceProxy.SetPolicy("ClientPolicy");
            COBISDesbloqueo.RequestConnection requestConnection = new COBISDesbloqueo.RequestConnection();
            requestConnection.applicationID = idAplicacion;
            requestConnection.password = string.Empty;
            requestConnection.sessionID = string.Empty;
            requestConnection.user = string.Empty;
            COBISDesbloqueo.BloqueoDesbloqueFil loginFiltro = new COBISDesbloqueo.BloqueoDesbloqueFil();
            loginFiltro.i_c_estado = estado;
            loginFiltro.i_c_login = Session["Usuario"].ToString();
            loginFiltro.i_m_quien_llama = quienLlama;
            bool ErrorExec = true;
            try
            {
                lblUsrName.Text = loginFiltro.i_c_login;
                COBISDesbloqueo.ExecuteRet resultado = serviceProxy.execute(requestConnection, loginFiltro);
                if (resultado.funcionarioRet.o_error == 0)
                {
                    //txtRespuesta.Text = "Se desbloqueó el usuario COBIS " + Session["Usuario"].ToString();
                    trTitRespuesta.Visible = true;
                    trRespuesta.Visible = true;
                    lblResp2.Text = "ha sido desbloqueado en forma satisfactoria!";
                    ErrorExec = false;
                }
                else
                {
                    trTitRespuesta.Visible = true;
                    trRespuesta.Visible = true;
                    lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
                    //txtRespuesta.Text = "Error: ";
                    //txtRespuesta.Text += resultado.funcionarioRet.o_error.ToString();
                    //txtRespuesta.Text += " - ";
                    //txtRespuesta.Text += resultado.funcionarioRet.o_mensaje;
                    //txtRespuesta.Text += Environment.NewLine + "restultado.funcionarioRet.o_error.ToString: ";
                    //txtRespuesta.Text += resultado.funcionarioRet.o_error.ToString();
                    //txtRespuesta.Text += Environment.NewLine + "restultado.funcionarioRet.o_mensaje: ";
                    //txtRespuesta.Text += resultado.funcionarioRet.o_mensaje;
                }
            }
            catch (Microsoft.Web.Services3.Security.SecurityFault ee)
            {
                string act = ee.Actor;

            }
            catch (System.Web.Services.Protocols.SoapHeaderException ee)
            {
                //txtRespuesta.Text += ee.Message;
            }

            catch (Exception ex)
            {
                //txtRespuesta.Text += ex.Message;
            }
            if (ErrorExec)
            {
                trTitRespuesta.Visible = true;
                trRespuesta.Visible = true;
                lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
            }
        }
        else
        {
            //txtRespuesta.Text = "Para solicitar el desbloqueo debe estar autenticado en el sistema";
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("AutogestionCOBIS.aspx");

    }
}