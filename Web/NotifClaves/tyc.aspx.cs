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
        int id = 0;

        string tipo = "ALTA";

        if (Request["id"] != null)
        { 
            int.TryParse(Request["id"], out id);
        }

        if (Session["tipoticket"] != null)
        {
            tipo = Session["tipoticket"].ToString().ToUpper();
        }

        if (id > 0 && tipo =="ALTA")
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            tncb.AceptarTyC(id);
        }

        if (id > 0 && tipo == "BLANQUEO")
        {
            TicketNotificacionBlanqueoBusiness tncb = new TicketNotificacionBlanqueoBusiness();

            tncb.AceptarTyC(id);
        }

        Response.Redirect("DetalleTicket.aspx?id=" + Request["id"] + "&tipo=" + tipo);
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tickets.aspx");
    }
}
