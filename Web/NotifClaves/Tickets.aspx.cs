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
                switch (tipo)
                {
                    case "A":
                        lblTitulo.Text = "Notificaciones de Alta de Usuario";
                        break;
                    case "B":
                        lblTitulo.Text = "Notificaciones de Blanqueo de Usuario de Aplicación";
                        break;
                }
            }

        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClavesAplicativos.aspx");

    }
}
