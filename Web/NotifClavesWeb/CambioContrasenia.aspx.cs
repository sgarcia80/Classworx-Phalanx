using Classworx.Common.Trace;
using NDCBL;
using NDCCommon.Entities;
using PhalanxBL;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Xml;

namespace NotifClavesWeb
{
    public partial class CambioContrasenia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
            }

            trTitRespuesta.Visible = false;
            trRespuesta.Visible = false;

            LimpiarReglas();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = string.Empty;

            if (Session["Usuario"] != null)
                usuario = Session["Usuario"].ToString();

            string password = tbPassword.Text;
            string passwordconfirm = tbPasswordConfirm.Text;

            bool cambioOk = Validar(password, passwordconfirm);

            if (cambioOk)
            {
                CambiarClave();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AutogestionCOBIS.aspx");
        }

        private void CambiarClave()
        {
            PhxConfigBusiness pcb = new PhxConfigBusiness();

            string usuarioLlamada = string.Empty;
            string idAplicacion = string.Empty;
            string estado = string.Empty;
            string quienLlama = string.Empty;

            string loginASBlanqueoWSCOBIS = string.Empty;
            string claveASBlanqueoWSCOBIS = string.Empty;
            string rolASBlanqueoWSCOBIS = string.Empty;
            string oficinaASBlanqueoWSCOBIS = string.Empty;
            string servidorASBlanqueoWSCOBIS = string.Empty;

            bool ErrorExec = true;
            lblResp2.Text = string.Empty;
            string error = string.Empty;
            string cert = string.Empty;

            try
            {
                usuarioLlamada = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.UsuarioLlamadaWSCOBIS).ShortTxtValue;
                idAplicacion = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.IDAplicacionWSCOBIS).ShortTxtValue;
                estado = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.EstadoWSCOBIS).ShortTxtValue;
                quienLlama = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.QuienLlamaWSCOBIS).ShortTxtValue;

                loginASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.LoginASBlanqueoWSCOBIS).ShortTxtValue;
                claveASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.ClaveASBlanqueoWSCOBIS).ShortTxtValue;
                rolASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.RolASBlanqueoWSCOBIS).ShortTxtValue;
                oficinaASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.OficinaASBlanqueoWSCOBIS).ShortTxtValue;
                servidorASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.ServidorASBlanqueoWSCOBIS).ShortTxtValue;
            }
            catch (Exception ex)
            {
                error += string.Format("Error en la parametría de Cobis: {0}", ex.ToString());

                trRespuesta.Visible = true;
                lblError.Text = "<BR/><BR/>" + error;
                return;
            }

            ADCambioContrasenia.ADCambioContraseniaClient serviceProxy = new ADCambioContrasenia.ADCambioContraseniaClient();

            //UsernameToken token = new UsernameToken(usuarioLlamada, "p", PasswordOption.SendNone);
            ADCambioContrasenia.RequestConnection requestConnection = new ADCambioContrasenia.RequestConnection();
            ADCambioContrasenia.ADCambioContraseniaFil filtro = new ADCambioContrasenia.ADCambioContraseniaFil();

            //serviceProxy.SetClientCredential(token);
            //serviceProxy.SetPolicy("ClientPolicy");
            serviceProxy.ClientCredentials.UserName.UserName = usuarioLlamada;
            serviceProxy.ClientCredentials.UserName.Password = "a";

            requestConnection.applicationID = idAplicacion;
            requestConnection.password = string.Empty;
            requestConnection.sessionID = string.Empty;
            requestConnection.user = string.Empty;

            filtro.i_u_login_adminseg = loginASBlanqueoWSCOBIS;
            filtro.i_c_clave_adminseg = claveASBlanqueoWSCOBIS;
            filtro.i_rol_adminseg = rolASBlanqueoWSCOBIS;
            filtro.i_oficina_adminseg = oficinaASBlanqueoWSCOBIS;
            filtro.i_servidor_adminseg = servidorASBlanqueoWSCOBIS;
            filtro.i_c_clave = tbPassword.Text.ToLower();
            filtro.i_u_login = Session["Usuario"].ToString().ToLower();
            
            if (!string.IsNullOrEmpty(error))
            {
                trRespuesta.Visible = true;
                lblError.Text = "<BR/><BR/>" + error;
                return;
            }

            try
            {
                TicketAutogestionCobisEntity ticket = TicketAutogestionCobisEntity.CreateBlanqueo();
                ticket.Usuario = filtro.i_u_login;
                ticket.Fecha = DateTime.Now;
                ticket.RespuestaCodigo = 0;
                ticket.RespuestaMensaje = string.Empty;

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);

                //TraceHelper.Information("Configuracion:", loginASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_u_login_adminseg = {0}",loginASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_c_clave_adminseg = {0}", claveASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_rol_adminseg = {0}", rolASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_oficina_adminseg = {0}", oficinaASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_servidor_adminseg = {0}", servidorASBlanqueoWSCOBIS);
                //TraceHelper.Information("i_c_clave = {0}", tbPassword.Text.ToLower());
                //TraceHelper.Information("i_u_login = {0}", Session["Usuario"].ToString().ToLower());

                TraceHelper.Information("Parametros:", loginASBlanqueoWSCOBIS);
                TraceHelper.Information("Usuario = {0}", filtro.i_u_login);

                TraceHelper.Information("Se ejecuta el WS CambioContrasena de Cobis");

                error = "Ejecutando WS... ";

                ADCambioContrasenia.ADCambioContraseniaRes resultado = serviceProxy.execute(requestConnection, filtro);

                error = string.Empty;

                if (resultado.serviceError != null &&
                    resultado.serviceError.code.HasValue &&
                    resultado.serviceError.code == 0)
                {
                    trTitRespuesta.Visible = true;
                    trRespuesta.Visible = true;
                    lblResp2.Text = "Se ha cambiado la contraseña en forma satisfactoria";
                    ErrorExec = false;

                    ticket.RespuestaCodigo = resultado.serviceError.code.GetValueOrDefault();

                    TraceHelper.Error("Response de Cobis:");
                    TraceHelper.Error("Code = {0}", resultado.serviceError.code.GetValueOrDefault());
                }

                if (resultado != null &&
                    resultado.serviceError != null &&
                    resultado.serviceError.code.HasValue &&
                    resultado.serviceError.code != 0)
                {
                    error = string.Format("serviceError: {0}", resultado.serviceError.message);

                    ticket.RespuestaCodigo = resultado.serviceError.code.GetValueOrDefault();
                    ticket.RespuestaMensaje = resultado.serviceError.message;

                    TraceHelper.Error("Response de Cobis:");
                    TraceHelper.Error("Code = {0}", resultado.serviceError.code.GetValueOrDefault());
                    TraceHelper.Error("Message = {0}", resultado.serviceError.message);
                }

                if (ticket.RespuestaCodigo == 151125)
                {
                    lblregla_pwd_rep.ForeColor = System.Drawing.Color.Red;
                    MostrarError("La nueva contraseña no cumple con todas las reglas");
                    return;
                }

                TicketAutogestionCobisBusiness ticketBL = new TicketAutogestionCobisBusiness();
                ticketBL.Save(ticket);
            }
            //catch (Microsoft.Web.Services3.Security.SecurityFault ee)
            //{
            //    error += "Security Error:<BR/>" + ee.Actor;
            //}
            //catch (System.Web.Services.Protocols.SoapHeaderException ee)
            //{
            //    error += "Soap Error:<BR/>" + ee.ToString();
            //    //txtRespuesta.Text += ee.Message;
            //}
            catch (Exception ex)
            {
                error += "Internal Error:<BR/>" + ex.ToString();
                //txtRespuesta.Text += ex.Message;
            }

            lblError.Text = string.Empty;
            if (ErrorExec && string.IsNullOrEmpty(lblResp2.Text))
            {
                trTitRespuesta.Visible = true;
                trRespuesta.Visible = true;
                lblResp2.Text = "no se ha podido cambiar la contraseña. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
            }

            if (!string.IsNullOrEmpty(error))
            {
                trRespuesta.Visible = true;
                lblError.Text = "<BR/>" + error;
            }
        }

        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }

        private void LimpiarReglas()
        {
            lblregla_caracteres.ForeColor = Color.Black;
            lblregla_largo.ForeColor = Color.Black;
            lblregla_min_letras.ForeColor = Color.Black;
            lblregla_min_nro.ForeColor = Color.Black;
            lblregla_let_rep.ForeColor = Color.Black;
            lblregla_nro_rep.ForeColor = Color.Black;
            lblregla_pwd_rep.ForeColor = Color.Black;
        }

        private void MostrarError(string mensaje)
        {
            lbMensaje.Text = mensaje;
            lbMensaje.Visible = !string.IsNullOrEmpty(mensaje);

            trTitRespuesta.Visible = false;
            trRespuesta.Visible = false;
            lblResp2.Text = string.Empty;
        }

        private bool Validar(string password, string passwordconfirm)
        {
            bool ok = false;
            lbMensaje.Text = string.Empty;

            try
            {
                bool largoOk = true;

                //Si la clave contiene otros caracteres que no sean letras y numeros
                bool caracteresValidos = ValidarLetrasNumeros(password);
                if (!caracteresValidos)
                {
                    lblregla_caracteres.ForeColor = System.Drawing.Color.Red;
                }

                //Si la longitud no esta entre 8 y 12 digitos alfanumericos.
                if (password.Length < 8 || password.Length > 12)
                {
                    largoOk = false;
                    lblregla_largo.ForeColor = System.Drawing.Color.Red;
                }

                //Mínimo 4 letras.
                bool minletrasOk = ValidarCantidaLetras(password, 4);
                if (!minletrasOk)
                {
                    lblregla_min_letras.ForeColor = System.Drawing.Color.Red;
                }

                //Mínimo 2 números.
                bool minnroOk = ValidarCantidadNumeros(password, 2);
                if (!minnroOk)
                {
                    lblregla_min_nro.ForeColor = System.Drawing.Color.Red;
                }

                //No puede haber 2 letras iguales seguidas.
                bool letrasOk = ValidarLetrasRepetidas(password);
                if (!letrasOk)
                {
                    lblregla_let_rep.ForeColor = System.Drawing.Color.Red;
                }

                //No puede haber 3 números iguales seguidos.
                bool numerosOk = ValidarNumerosRepetidas(password);
                if (!numerosOk)
                {
                    lblregla_nro_rep.ForeColor = System.Drawing.Color.Red;
                }

                //No importa si las letras son mayúsculas o minúsculas porque COBIS no hace diferencia.

                //Si alguna de las reglas falla
                if (!largoOk || !minletrasOk || !minnroOk || !letrasOk || !numerosOk || !caracteresValidos)
                {
                    MostrarError("La nueva contraseña no cumple con todas las reglas");
                }
                else
                {
                    //Por ultimo, ambas claves deben ser iguales.
                    if (password != passwordconfirm)
                    {
                        MostrarError("Las Contraseñas deben ser iguales");
                    }
                    else
                    {
                        ok = true;
                    }
                }

            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al validar las contraseñas ({0})", ex.Message);

                MostrarError(mensaje);
            }

            return ok;
        }

        private bool ValidarCantidaLetras(string cadena, int cantidadminimma)
        {
            bool result = false;

            MatchCollection matches = null;
            matches = Regex.Matches(cadena, @"([a-zA-Z])");

            //Si se encontraron letras
            if (matches != null && matches.Count > 0)
            {
                //Se revisa la cantidad de letras encontradas
                result = (matches.Count >= cantidadminimma);
            }

            return result;
        }

        private bool ValidarCantidadNumeros(string cadena, int cantidadminimma)
        {
            bool result = false;

            MatchCollection matches = null;
            matches = Regex.Matches(cadena, @"(\d)");

            //Si se encontraron números
            if (matches != null && matches.Count > 0)
            {
                //Se revisa la cantidad de números encontrados
                result = (matches.Count >= cantidadminimma);
            }

            return result;
        }

        private bool ValidarLetrasRepetidas(string cadena)
        {
            bool result = false;

            Match match = null;
            match = Regex.Match(cadena, @"(\D)\1+?");

            result = !match.Success;

            return result;
        }

        private bool ValidarLetrasNumeros(string cadena)
        {
            bool result = false;

            Match match = null;
            match = Regex.Match(cadena, @"^[a-zA-Z0-9]+$");

            result = match.Success;

            return result;
        }

        private bool ValidarNumerosRepetidas(string cadena)
        {
            bool result = false;

            Match match = null;
            match = Regex.Match(cadena, @"(\d)\1\1+?");

            result = !match.Success;

            return result;
        }
    }
}