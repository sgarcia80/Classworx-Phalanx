using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClavesAplicativos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

    }
    protected void btnCOBIS_Click(object sender, EventArgs e)
    {
        Response.Redirect("AutogestionCOBIS.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnNotifClaves_Click(object sender, EventArgs e)
    {
        string tipo = "A";

        if (chkNotifAlta.Checked)
        {
            tipo = "A";
        }
        if (chkNotifBlanqueo.Checked)
        {
            tipo = "B";
        }

        Session["TipoNotif"] = tipo;
        Response.Redirect("Tickets.aspx");
    }
}