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
using NDCCommon.Collections;

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

                Session["sortdirection"] = SortDirection.Descending;
                Session["sortcolumn"] = "Fecha";
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

        protected void gvTickets_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["sortdirection"] = e.SortDirection;
            Session["sortcolumn"] = e.SortExpression;
        }
    }
}