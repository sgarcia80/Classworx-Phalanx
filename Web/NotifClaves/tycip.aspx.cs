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
using System.DirectoryServices;
using PhalanxNAL;
using NDCCommon.Entities;
using System.Text;

public partial class tycip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAceptar.Attributes.Add("onclick", "this.value = 'Aguarde...';  this.disabled = true; " + btnVolver.ClientID + ".disabled = true;  " + cbDesbloqueo.ClientID + ".disabled = true;  " + cbtyc.ClientID + ".disabled = true; " + ClientScript.GetPostBackEventReference(btnAceptar, null) + ";"); if (Session["id"] == null)
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

            string tipo = "ALTA";

            if (Session["tipoticket"] != null)
            {
                tipo = Session["tipoticket"].ToString().ToUpper();
            }

            if (tipo == "ALTA")
            {
                TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

                TicketNotificacionClaveEntity ticket = tncb.GetById(id);

                tncb.AceptarTyC(ticket);

                Response.Redirect("DetalleTicketIp.aspx?");
            }

            if (tipo == "BLANQUEO")
            {
                TicketNotificacionBlanqueoBusiness tncb = new TicketNotificacionBlanqueoBusiness();
                TicketNotificacionBlanqueoEntity ticket = tncb.GetById(id);

                tncb.AceptarTyC(ticket);

                Response.Redirect("DetalleTicket.aspx?id=" + id.ToString());
            }
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect("IdentificacionPositiva.aspx?id=" + Session["id"]);
        Response.Redirect("AltaTemprana.aspx");   
    }
}
