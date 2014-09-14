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
using NDCBL;

public partial class tycip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect(FormsAuthentication.LoginUrl);

            return;
        }
    }

    protected void cbtyc_CheckedChanged(object sender, EventArgs e)
    {
        btnAceptar.Visible = cbtyc.Checked && cbDesbloqueo.Checked;
    }

    protected void cbDesbloqueo_CheckedChanged(object sender, EventArgs e)
    {
        btnAceptar.Visible = cbtyc.Checked && cbDesbloqueo.Checked;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = (int)Session["id"];

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            tncb.AceptarTyC(id);

            Response.Redirect("DetalleTicketIp.aspx?");
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("IdentificacionPositiva.aspx?id=" + Session["id"]);
    }
}
