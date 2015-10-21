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

public partial class tyc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

    }
    
    protected void cbtyc_CheckedChanged(object sender, EventArgs e)
    {
        btnAceptar.Visible = cbtyc.Checked;
    }
    
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        int id;

        if (Request["id"] != null && int.TryParse(Request["id"], out id))
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            tncb.AceptarTyC(id);

            Response.Redirect("DetalleTicket.aspx?id=" + Request["id"]);
        }
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tickets.aspx");
    }
}
