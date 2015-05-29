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

public partial class DesbloqueoUsuarioCOBIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnDesbloquear_Click(object sender, EventArgs e)
    {
        if (Session["Dominio"] != null && Session["Usuario"] != null)
        {

            COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisServiceWse serviceProxy = new BloqueoDesbloqueoUsuariosCobisServiceWse();
            UsernameToken token = new UsernameToken(ConfigurationManager.AppSettings["COBISWSSUser"], "a", PasswordOption.SendNone);
            serviceProxy.SetClientCredential(token);
            serviceProxy.SetPolicy("ClientPolicy");
            COBISDesbloqueo.RequestConnection requestConnection = new COBISDesbloqueo.RequestConnection();
            requestConnection.applicationID = ConfigurationManager.AppSettings["COBISAppID"];
            requestConnection.password = string.Empty;
            requestConnection.sessionID = string.Empty;
            requestConnection.user = string.Empty;
            COBISDesbloqueo.BloqueoDesbloqueFil loginFiltro = new COBISDesbloqueo.BloqueoDesbloqueFil();
            loginFiltro.i_c_estado = ConfigurationManager.AppSettings["COBISEstado"];
            loginFiltro.i_c_login = Session["Usuario"].ToString();
            loginFiltro.i_m_quien_llama = ConfigurationManager.AppSettings["COBISQuienLlama"];
            try
            {
                COBISDesbloqueo.ExecuteRet resultado = serviceProxy.execute(requestConnection, loginFiltro);
                if (resultado.funcionarioRet.o_error == 0)
                {
                    txtRespuesta.Text = "Se desbloqueó el usuario COBIS " + Session["Usuario"].ToString();
                }
                else
                {
                    txtRespuesta.Text = "Error: ";
                    txtRespuesta.Text += resultado.funcionarioRet.o_error.ToString();
                    txtRespuesta.Text += " - ";
                    txtRespuesta.Text += resultado.funcionarioRet.o_mensaje;
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
                txtRespuesta.Text += ee.Message;
            }

            catch (Exception ex)
            {
                txtRespuesta.Text += ex.Message;
            }
           
        }
        else
        {
            txtRespuesta.Text = "Para solicitar el desbloqueo debe estar autenticado en el sistema";
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("AutogestionCOBIS.aspx");

    }
}