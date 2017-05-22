using PhalanxBL;
using PhalanxCommon.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotifClavesWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("externo");
            }
            catch (Exception)
            {
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //string dominio = tbDominio.Text.Trim();
            string dominio = ddlDominio.SelectedValue;
            string usuario = tbUsuario.Text.Trim();
            string password = tbPassword.Text;

            if (Autenticar(dominio, usuario, password))
            {
                string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

                FormsAuthentication.SetAuthCookie(nombreUsuario, false);
                Session["Usuario"] = usuario;
                Session["Dominio"] = dominio;

                //FormsAuthentication.RedirectFromLoginPage(nombreUsuario, false);
                Response.Redirect("ClavesAplicativos.aspx");
            }
            else
            {
                lbMensaje.Text = "Usuario o Contraseña incorrecto";
                lbMensaje.Visible = true;
            }
        }
        
        protected void btnNotificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotificacionClave.aspx");
        }

        private bool Autenticar(string dominio, string usuario, string password)
        {
            bool authentic = false;
            bool esExterno = false;

            AuditLoginBusiness auditLoginBusiness = new AuditLoginBusiness();

            string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

            try
            {
                string provider = "LDAP";

                PhxConfigBusiness pcb = new PhxConfigBusiness();

                PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionLoginNDC);

                if (config.ShortTxtValue == "WINNT")
                    provider = "WinNT";

                string path = provider + "://" + dominio;

                DirectoryEntry entry = new DirectoryEntry(path, usuario, password);

                object nativeObject = entry.NativeObject;
                authentic = true;

                string name = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(usuario, path);

                if (!string.IsNullOrEmpty(name))
                {
                    esExterno = name.ToUpper().Contains("EXTERNO");
                }

                auditLoginBusiness.LogAccOK(null, nombreUsuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves);
            }
            catch (DirectoryServicesCOMException cex)
            {
                if (cex.ExtendedError == -2146893044)
                    auditLoginBusiness.LogUsrConInexistente(null, usuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves);
            }
            catch (Exception ex)
            {

            }

            if (esExterno)
            {
               Session["externo"] = (esExterno) ? "S" : "N";
            }
            return authentic;
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTemprana.aspx");
        }
    }
}