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

public partial class Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbLogout.Visible = Page.User.Identity.IsAuthenticated;

        if ((Session["Dominio"] == null || Session["Usuario"] == null) && !string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            string[] usuario = Page.User.Identity.Name.Split(new char[] { '\\' });

            if (usuario.Length == 2)
            {
                Session["Dominio"] = usuario[0];
                Session["Usuario"] = usuario[1];
            }
        }

        if (Session["Dominio"] != null && Session["Usuario"] != null)
            LabelUser.Text = String.Format(@"{0}\{1}", Session["Dominio"], Session["Usuario"]);
    }
    
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
        Session["Dominio"] = null;

        FormsAuthentication.SignOut();

        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}
