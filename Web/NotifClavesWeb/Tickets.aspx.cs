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

                int vigencia = GetVigencia();

                Session["TipoNotif"] = chkNotifAlta.SelectedValue;

                Session["FechaDesde"] = DateTime.Now.Date.AddDays(vigencia * -1);
                Session["FechaHasta"] = DateTime.Now.Date;

                Session["sortdirection"] = SortDirection.Descending;
                Session["sortcolumn"] = "Fecha";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Session["TipoNotif"] = chkNotifAlta.SelectedValue;
            gvTickets.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClavesAplicativos.aspx");

        }

        protected void ddlVigencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vigencia = GetVigencia();
            Session["FechaDesde"] = DateTime.Now.Date.AddDays(vigencia * -1);
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

        protected int GetVigencia()
        {
            int vigencia = 30;

            int.TryParse(ddlVigencia.SelectedValue, out vigencia);

            return vigencia;
        }
    }
}