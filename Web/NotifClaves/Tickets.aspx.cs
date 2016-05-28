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

            if (Session["TipoNotif"] != null)
            {
                tipo = Session["TipoNotif"].ToString();
                
                ddlTipoNotificacion.SelectedValue = tipo;
            }

        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClavesAplicativos.aspx");

    }

    protected void ddlTipoNotificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["TipoNotif"] = ddlTipoNotificacion.SelectedValue;
    }
}
