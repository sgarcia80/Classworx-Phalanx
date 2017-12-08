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
using log4net;

public partial class Principal : System.Web.UI.MasterPage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Login));

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LabelTitle.Text = (string)Session["CtrlTitle"];
            LabelUser.Text = (string)Session["CtrlUser"];
            PhxContingenciaBusiness phxContB = new PhxContingenciaBusiness();
            if (!phxContB.VerificaSiConexionUsadaEstaActiva())
            {
                Response.Redirect("OutOfService.aspx");
            }
        }
        catch
        {
            Response.Redirect("OutOfService.aspx");
        }

    }
    protected void loginstatus_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        log.InfoFormat("Se elimina la session");
        Session.Abandon();
        Session.Clear();

        log.InfoFormat("Se desloguea el usuario");
        FormsAuthentication.SignOut();

        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
        cookie1.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie1);

        log.InfoFormat("Se redirecciona al login");
        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}
