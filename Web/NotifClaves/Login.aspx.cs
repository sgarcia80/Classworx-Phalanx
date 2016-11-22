using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using PhalanxBL;
using PhalanxCommon.Entities;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCBL;
using PhalanxCommon.Collections;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WinDomainBusiness dominioLoginBL = new WinDomainBusiness();
            dominioLoginBL.FilConfigured = true;
            WinDomainEntityCollection dominios = dominioLoginBL.GetAll();

            ddlDominio.DataSource = dominios;
            ddlDominio.DataBind();
        }
    }
    
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //string dominio = tbDominio.Text.Trim();
        string dominio = ddlDominio.SelectedItem.Text;
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

        AuditLoginBusiness auditLoginBusiness = new AuditLoginBusiness();

        string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario); 
        
        try
        {
            int id = 0;
            string valor = ddlDominio.SelectedItem.Value;
            string path = string.Empty;

            int.TryParse(valor, out id);

            WinDomainBusiness dominioLoginBL = new WinDomainBusiness();
            WinDomainEntityCollection dominios = dominioLoginBL.GetById(id);

            string provider = "LDAP";

            PhxConfigBusiness pcb = new PhxConfigBusiness();
            PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionLoginNDC);
            
            if (dominios.Count > 0)
            {
                provider = dominios[0].LDAPPath;
            }

            if (config.ShortTxtValue == "WINNT")
                provider = "WinNT";

            DirectoryEntry entry = new DirectoryEntry(provider + "://" + dominio, usuario, password);
            
            object nativeObject = entry.NativeObject;
            authentic = true;

            auditLoginBusiness.LogAccOK(null, nombreUsuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves);

            string nombreUser = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(usuario, path);
            bool esExterno = nombreUser.ToUpper().Contains("EXTERNO");
            
            Session["externo"] = (esExterno) ? "S" : "";
        }
        catch (DirectoryServicesCOMException cex)
        {
            if (cex.ExtendedError == -2146893044)
                auditLoginBusiness.LogUsrConInexistente(null, usuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves); 
        }
        catch (Exception ex)
        {
            
        }

        return authentic;
    }



    protected void btnAlta_Click(object sender, EventArgs e)
    {
        Response.Redirect("AltaTemprana.aspx");
    }
}
