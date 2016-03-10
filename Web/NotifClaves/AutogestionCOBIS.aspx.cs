using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AutogestionCOBIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClavesAplicativos.aspx");

    }
    protected void btnDesbloqueoCOBIS_Click(object sender, EventArgs e)
    {
        Response.Redirect("DesbloqueoUsuarioCOBIS.aspx");

    }
    protected void btnCambioClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambioContrasenia.aspx");
    }
}