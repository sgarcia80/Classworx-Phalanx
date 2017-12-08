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
using PhalanxBL;
using PhalanxCommon.Entities;
using System.Threading;
using System.DirectoryServices;
using PhalanxCommon.Collections;
using log4net;

public partial class Login : System.Web.UI.Page
{
    protected string m_DomUser;
    private static readonly ILog log = LogManager.GetLogger(typeof(Login));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            catch (Exception)
            {
            }

            DomainsMgr domainBL = new DomainsMgr();
            domainBL.ReloadDBDomains();

            Domain.DataSource = domainBL.DominiosDB;
            Domain.DataValueField = "Id";
            Domain.DataTextField = "NtName";
            Domain.DataBind();

            string dominio = "MACRO";
            int value = 0;

            foreach (WinDomainEntity d in domainBL.DominiosDB)
            {
                if (d.NtName.ToUpper().Contains(dominio))
                {
                    value = d.Id;
                    break;
                }
            }
            Domain.SelectedValue = value.ToString();
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = string.Empty;

        string dominio = string.Empty;
        string usuario = string.Empty;
        string password = string.Empty;
        int id = 0;

        int.TryParse(Domain.SelectedValue, out id);

        WinDomainBusiness domainBL = new WinDomainBusiness();
        WinDomainEntityCollection userdomains = domainBL.GetById(id);

        dominio = userdomains[0].LDAPPath;
        usuario = string.Format(@"{0}\{1}", userdomains[0].NtName, UserName.Text.Trim());
        password = Password.Text.Trim();

        if (Autenticar(dominio, usuario, password))
        {
            log.InfoFormat("Se persisten las credenciales");

            FormsAuthentication.SetAuthCookie(usuario, false);

            Session["Usuario"] = usuario;
            Session["Dominio"] = dominio;

            FormsAuthenticationTicket ticket1 =
                 new FormsAuthenticationTicket(
                      1,                                   // version
                      usuario,   // get username  from the form
                      DateTime.Now,                        // issue time is now
                      DateTime.Now.AddMinutes(30),         // expires in 10 minutes
                      false,      // cookie is not persistent
                      "PHX"                              // role assignment is stored
                // in userData
                      );
            HttpCookie cookie1 = new HttpCookie(
              FormsAuthentication.FormsCookieName,
              FormsAuthentication.Encrypt(ticket1));
            Response.Cookies.Add(cookie1);

            log.InfoFormat("Se redirecciona a la página de inicio");

            string returnUrl1 = string.Empty;

            // the login is successful
            //if (Request.QueryString["ReturnUrl"] == null)
            //{
            returnUrl1 = "Default.aspx";
            //}
            ////login not unsuccessful 
            //else
            //{
            //    returnUrl1 = Request.QueryString["ReturnUrl"];
            //}

            Response.Redirect(returnUrl1);
        }
        else
        {
            log.InfoFormat("Se visualiza mensaje de autenticacion fallida");
            ErrorMessage.Text = "Usuario o Contraseña incorrecto";
        }
    }


    private bool Autenticar(string dominio, string usuario, string password)
    {
        bool authentic = false;

        AuditLoginBusiness auditLoginBusiness = new AuditLoginBusiness();

        try
        {
            string path = dominio;// provider + "://" + dominio;

            log.InfoFormat("Se autentica el usario '{0}' contra el dominio '{1}'", usuario, dominio);

            DirectoryEntry entry = new DirectoryEntry(path, usuario, password);

            object nativeObject = entry.NativeObject;
            authentic = true;

            log.InfoFormat("Usuario autenticado correctamente", usuario, dominio);
        }
        catch (DirectoryServicesCOMException cex)
        {
            log.Error("Error en autenticacion", cex);

            if (cex.ExtendedError == -2146893044)
            {
                auditLoginBusiness.LogUsrConInexistente(null, usuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.Phalanx);
            }
        }
        catch (Exception ex)
        {
            log.Error("Error desconcido en autenticacion", ex);
        }

        return authentic;
    }
}
