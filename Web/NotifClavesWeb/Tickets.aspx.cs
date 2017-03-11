using System;
using System.Web.UI;

namespace NotifClavesWeb
{
    public partial class Tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                string tipo = string.Empty;

                Session["TipoNotif"] = chkNotifAlta.SelectedValue;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClavesAplicativos.aspx");

        }

        protected void ddlTipoNotificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkNotifAlta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["TipoNotif"] = chkNotifAlta.SelectedValue;
        }
    }
}