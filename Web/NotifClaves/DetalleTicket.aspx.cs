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
using NDCCommon.Entities;
using NDCBL;

public partial class DetalleTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

        int id;

        if (Request["id"] != null && int.TryParse(Request["id"], out id))
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetById(id);

            if (ticket.Usuario.ToLower() != Session["Usuario"].ToString().ToLower() || ticket.DominioUsuario.ToLower() != Session["Dominio"].ToString().ToLower())
                return;

            if (ticket.FechaAceptacionTyC == null)
            {
                Response.Redirect("tyc.aspx?id=" + id);

                return;
            }

            if (!ticket.Aplicacion.Notificable)
            {
                Response.Redirect("nopermitido.aspx?id=" + id);

                return;
            }

            MostrarDatosTicket(ticket);

            if (!IsPostBack)
                new AuditTicketNotificacionBusiness().LogVisualizacion(ticket);
        }
    }

    private void MostrarDatosTicket(TicketNotificacionClaveEntity ticket)
    {
        tbFecha.Text = ticket.Fecha.ToString();
        tbApp.Text = ticket.Aplicacion.Nombre;
        tbNroSolicitud.Text = ticket.NumeroSolicitud.ToString();
        tbUsuario.Text = ticket.UsuarioAplicacion;

        if (ticket.EsPasswordDominio)
            trUsaContraRed.Visible = true;
        else
        {
            trContra.Visible = true;
            tbContra.Text = TicketNotificacionClaveBusiness.DesencriptarPassword(ticket.PasswordUsuarioAplicacion);
        }
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tickets.aspx");
    }
}
