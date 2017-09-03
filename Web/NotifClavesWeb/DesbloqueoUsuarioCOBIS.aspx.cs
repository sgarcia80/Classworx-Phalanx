using Classworx.Common.Trace;
using NDCBL;
using NDCCommon.Entities;
using PhalanxBL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace NotifClavesWeb
{
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

                COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisClient serviceProxy = new COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisClient();

                serviceProxy.ClientCredentials.UserName.UserName = usuarioLlamada;
                serviceProxy.ClientCredentials.UserName.Password = "a";

                //UsernameToken token = new UsernameToken(usuarioLlamada, "a", PasswordOption.SendNone);
                //serviceProxy.SetClientCredential(token);
                //serviceProxy.SetPolicy("ClientPolicy");
                //serviceProxy.ClientCredentials.UserName.UserName = usuarioLlamada;
                //serviceProxy.ClientCredentials.UserName.Password = "a";

                COBISDesbloqueo.RequestConnection requestConnection = new COBISDesbloqueo.RequestConnection();
                requestConnection.applicationID = idAplicacion;
                requestConnection.password = string.Empty;
                requestConnection.sessionID = string.Empty;
                requestConnection.user = string.Empty;
                COBISDesbloqueo.BloqueoDesbloqueFil loginFiltro = new COBISDesbloqueo.BloqueoDesbloqueFil();
                loginFiltro.i_c_estado = estado;
                loginFiltro.i_c_login = Session["Usuario"].ToString().ToLower();
                loginFiltro.i_m_quien_llama = quienLlama;
                bool ErrorExec = true;
                string error = string.Empty;
                try
                {
                    TicketAutogestionCobisEntity ticket = TicketAutogestionCobisEntity.CreateDesbloqueo();
                    ticket.Usuario = loginFiltro.i_c_login;
                    ticket.Fecha = DateTime.Now;
                    ticket.RespuestaCodigo = 0;
                    ticket.RespuestaMensaje = string.Empty;

                    lblUsrName.Text = loginFiltro.i_c_login;
                    COBISDesbloqueo.ExecuteRet resultado = serviceProxy.execute(requestConnection, loginFiltro);

                    if (resultado != null &&
                        resultado.funcionarioRet != null &&
                        resultado.funcionarioRet.o_error == 0)
                    {
                        trTitRespuesta.Visible = true;
                        trRespuesta.Visible = true;
                        lblResp2.Text = "ha sido desbloqueado en forma satisfactoria!";
                        ErrorExec = false;

                        ticket.RespuestaCodigo = resultado.funcionarioRet.o_error;
                    }
                    else
                    {
                        trTitRespuesta.Visible = true;
                        trRespuesta.Visible = true;
                        lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
                    }

                    if (resultado != null &&
                        resultado.funcionarioRet != null &&
                        !string.IsNullOrEmpty(resultado.funcionarioRet.o_mensaje))
                    {
                        if (!string.IsNullOrEmpty(error))
                            error = error + "<BR/>";
                        error += string.Format("o_mensaje: {0}", resultado.funcionarioRet.o_mensaje);

                        ticket.RespuestaCodigo = resultado.funcionarioRet.o_error;
                        ticket.RespuestaMensaje = resultado.funcionarioRet.o_mensaje;
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        error = "Error devuelto por el servicio:<BR/>" + error;
                    }

                    TicketAutogestionCobisBusiness ticketBL = new TicketAutogestionCobisBusiness();
                    ticketBL.Save(ticket);
                }
                //catch (Microsoft.Web.Services3.Security.SecurityFault ee)
                //{
                //    error = "Security Error:<BR/>" + ee.Actor;
                //}
                //catch (System.Web.Services.Protocols.SoapHeaderException ee)
                //{
                //    error = "Soap Error:<BR/>" + ee.ToString();
                //    //txtRespuesta.Text += ee.Message;
                //}
                catch (Exception ex)
                {
                    error = "Internal Error:<BR/>" + ex.ToString();
                    //txtRespuesta.Text += ex.Message;
                }

                lblError.Text = string.Empty;
                if (ErrorExec)
                {
                    trTitRespuesta.Visible = true;
                    trRespuesta.Visible = true;
                    lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
                }

                bool showCobis = false;
                if (ConfigurationManager.AppSettings["RespuestaCobis"] != null &&
                    ConfigurationManager.AppSettings["RespuestaCobis"].ToString() == "1")
                {
                    showCobis = true;
                }

                if (!string.IsNullOrEmpty(error) && showCobis)
                {
                    lblError.Text = "<BR/><BR/>" + error;
                }
            }
            else
            {
                //txtRespuesta.Text = "Para solicitar el desbloqueo debe estar autenticado en el sistema";
            }
        }
        //protected void btnDesbloquear_Click(object sender, EventArgs e)
        //{
        //    if (Session["Dominio"] != null && Session["Usuario"] != null)
        //    {
        //        PhxConfigBusiness pcb = new PhxConfigBusiness();

        //        string usuarioLlamada = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.UsuarioLlamadaWSCOBIS).ShortTxtValue;
        //        string idAplicacion = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.IDAplicacionWSCOBIS).ShortTxtValue;
        //        string estado = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.EstadoWSCOBIS).ShortTxtValue;
        //        string quienLlama = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.QuienLlamaWSCOBIS).ShortTxtValue;

        //        COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisClient serviceProxy = new COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisClient();

        //        //UsernameToken token = new UsernameToken(usuarioLlamada, "a", PasswordOption.SendNone);
        //        //serviceProxy.SetClientCredential(token);
        //        //serviceProxy.SetPolicy("ClientPolicy");
        //        serviceProxy.ClientCredentials.UserName.UserName = usuarioLlamada;
        //        serviceProxy.ClientCredentials.UserName.Password = "a";

        //        COBISDesbloqueo.RequestConnection requestConnection = new COBISDesbloqueo.RequestConnection();
        //        requestConnection.applicationID = idAplicacion;
        //        requestConnection.password = string.Empty;
        //        requestConnection.sessionID = string.Empty;
        //        requestConnection.user = string.Empty;
        //        COBISDesbloqueo.BloqueoDesbloqueFil loginFiltro = new COBISDesbloqueo.BloqueoDesbloqueFil();
        //        loginFiltro.i_c_estado = estado;
        //        loginFiltro.i_c_login = Session["Usuario"].ToString().ToLower();
        //        loginFiltro.i_m_quien_llama = quienLlama;
        //        bool ErrorExec = true;
        //        string error = string.Empty;
        //        try
        //        {
        //            TicketAutogestionCobisEntity ticket = TicketAutogestionCobisEntity.CreateDesbloqueo();
        //            ticket.Usuario = loginFiltro.i_c_login;
        //            ticket.Fecha = DateTime.Now;
        //            ticket.RespuestaCodigo = 0;
        //            ticket.RespuestaMensaje = string.Empty;

        //            lblUsrName.Text = loginFiltro.i_c_login;
        //            COBISDesbloqueo.ExecuteRet resultado = serviceProxy.execute(requestConnection, loginFiltro);

        //            if (resultado != null &&
        //                resultado.funcionarioRet != null &&
        //                resultado.funcionarioRet.o_error == 0)
        //            {
        //                trTitRespuesta.Visible = true;
        //                trRespuesta.Visible = true;
        //                lblResp2.Text = "ha sido desbloqueado en forma satisfactoria!";
        //                ErrorExec = false;

        //                ticket.RespuestaCodigo = resultado.funcionarioRet.o_error;
        //            }
        //            else
        //            {
        //                trTitRespuesta.Visible = true;
        //                trRespuesta.Visible = true;
        //                lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
        //            }

        //            if (resultado != null &&
        //                resultado.funcionarioRet != null &&
        //                !string.IsNullOrEmpty(resultado.funcionarioRet.o_mensaje))
        //            {
        //                if (!string.IsNullOrEmpty(error))
        //                    error = error + "<BR/>";
        //                error += string.Format("o_mensaje: {0}", resultado.funcionarioRet.o_mensaje);

        //                ticket.RespuestaCodigo = resultado.funcionarioRet.o_error;
        //                ticket.RespuestaMensaje = resultado.funcionarioRet.o_mensaje;
        //            }

        //            if (!string.IsNullOrEmpty(error))
        //            {
        //                error = "Error devuelto por el servicio:<BR/>" + error;
        //            }

        //            TicketAutogestionCobisBusiness ticketBL = new TicketAutogestionCobisBusiness();
        //            ticketBL.Save(ticket);
        //        }
        //        //catch (Microsoft.Web.Services3.Security.SecurityFault ee)
        //        //{
        //        //    error = "Security Error:<BR/>" + ee.Actor;
        //        //}
        //        //catch (System.Web.Services.Protocols.SoapHeaderException ee)
        //        //{
        //        //    error = "Soap Error:<BR/>" + ee.ToString();
        //        //    //txtRespuesta.Text += ee.Message;
        //        //}
        //        catch (Exception ex)
        //        {
        //            error = "Internal Error:<BR/>" + ex.ToString();
        //            //txtRespuesta.Text += ex.Message;
        //        }

        //        lblError.Text = string.Empty;
        //        if (ErrorExec)
        //        {
        //            trTitRespuesta.Visible = true;
        //            trRespuesta.Visible = true;
        //            lblResp2.Text = "no se ha podido desbloquear. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
        //        }

        //        bool showCobis = false;
        //        if (ConfigurationManager.AppSettings["RespuestaCobis"] != null &&
        //            ConfigurationManager.AppSettings["RespuestaCobis"].ToString() == "1")
        //        {
        //            showCobis = true;
        //        }

        //        if (!string.IsNullOrEmpty(error) && showCobis)
        //        {
        //            lblError.Text = "<BR/><BR/>" + error;
        //        }
        //    }
        //    else
        //    {
        //        //txtRespuesta.Text = "Para solicitar el desbloqueo debe estar autenticado en el sistema";
        //    }
        //}

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AutogestionCOBIS.aspx");
        }
    }
}