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
using NDCCommon.Entities;

public partial class DetalleTicketIp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = (int)Session["id"];

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetById(id);

            if (ticket.FechaAceptacionTyC == null)
            {
                Response.Redirect("tycip.aspx?id=" + id);

                return;
            }

            MostrarDatosTicket(ticket);

            if (!IsPostBack)
                new AuditTicketNotificacionBusiness().LogVisualizacion(ticket);

            Session["id"] = null;
        }
        else
            Response.Redirect(FormsAuthentication.LoginUrl);
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
        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}
