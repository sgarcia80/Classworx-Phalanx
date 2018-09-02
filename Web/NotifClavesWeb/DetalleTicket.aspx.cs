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

namespace NotifClavesWeb
{
    public partial class DetalleTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            int id = 0;
            string tipo = "ALTA";

            if (Request["id"] != null)
            {
                int.TryParse(Request["id"], out id);
            }
            if (Request["tipo"] != null)
            {
                tipo = Request["tipo"].ToString().ToUpper();
            }

            string redirect = string.Empty;

            tbTipoSolicitud.Text = "Alta de Usuario";

            if (id > 0 && tipo == "ALTA")
            {
                redirect = ConsultarTicketNotificacionClave(id);
            }

            if (id > 0 && tipo == "BLANQUEO")
            {
                redirect = ConsultarTicketNotificacion(id, tipo);
            }

            Session["tipoticket"] = tipo;
            if (!string.IsNullOrEmpty(redirect))
            {
                Response.Redirect(redirect);
            }
        }

        private string ConsultarTicketNotificacionClave(int id)
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetById(id);

            if (ticket.Usuario.ToLower() != Session["Usuario"].ToString().ToLower()) // || ticket.DominioUsuario.ToLower() != Session["Dominio"].ToString().ToLower())
                return string.Empty;

            if (ticket.FechaAceptacionTyC == null)
            {
                return "tyc.aspx?id=" + id.ToString();
            }

            if (!ticket.Aplicacion.Notificable)
            {
                return "nopermitido.aspx?id=" + id.ToString();
            }

            MostrarDatosTicketNotificacionClave(ticket);

            if (!IsPostBack)
                new AuditTicketNotificacionBusiness().LogVisualizacion(ticket);

            return string.Empty;
        }

        private string ConsultarTicketNotificacion(int id, string tipo)
        {
            string redirect = string.Empty;

            TicketNotificacionBusiness business = new TicketNotificacionBusiness();
            TicketNotificacionEntity ticket = business.Load(id, tipo);

            if (ticket != null)
            {
                if (ticket.Subtipo == "TC")
                {
                    tbTipoSolicitud.Text = "Blanqueo de Usuario de Tarjeta de Crédito";

                    redirect = ConsultarTicketNotificacionTC(id);
                }
                else
                {
                    tbTipoSolicitud.Text = "Blanqueo de Usuario de Aplicación";

                    redirect = ConsultarTicketNotificacionBlanqueo(id);
                }
            }

            return redirect;
        }

        private string ConsultarTicketNotificacionBlanqueo(int id)
        {
            TicketNotificacionBlanqueoBusiness tncb = new TicketNotificacionBlanqueoBusiness();

            TicketNotificacionBlanqueoEntity ticket = tncb.GetById(id);

            if (ticket.Usuario.ToLower() != Session["Usuario"].ToString().ToLower()) // || ticket.UsuarioDominio.ToLower() != Session["Dominio"].ToString().ToLower())
                return string.Empty;

            if (!ticket.Aplicacion.Notificable)
            {
                return "nopermitido.aspx?id=" + id.ToString();
            }

            if (!ticket.FechaAceptacionTyC.HasValue)
            {
                tncb.AceptarTyC(ticket.Id);
            }

            MostrarDatosTicketNotificacionBlanqueo(ticket);

            return string.Empty;
        }

        private string ConsultarTicketNotificacionTC(int id)
        {
            TicketNotificacionTarjetaBusiness tncb = new TicketNotificacionTarjetaBusiness();

            TicketNotificacionTarjetaEntity ticket = tncb.Load(id);

            if (ticket.Usuario.ToLower() != Session["Usuario"].ToString().ToLower()) // || ticket.UsuarioDominio.ToLower() != Session["Dominio"].ToString().ToLower())
            {
                return string.Empty;
            }

            if (!ticket.Aplicacion.Notificable)
            {
                return "nopermitido.aspx?id=" + id.ToString();
            }

            if (!ticket.FechaNotificado.HasValue)
            {
                tncb.AceptarTyC(ticket.Id);
            }

            MostrarDatosTicketNotificacionTC(ticket);

            return string.Empty;
        }

        private void MostrarDatosTicketNotificacionClave(TicketNotificacionClaveEntity ticket)
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

        private void MostrarDatosTicketNotificacionBlanqueo(TicketNotificacionBlanqueoEntity ticket)
        {
            tbFecha.Text = ticket.Fecha.ToString();
            tbApp.Text = ticket.Aplicacion.Nombre;
            tbNroSolicitud.Text = ticket.Id.ToString();
            tbUsuario.Text = ticket.UsuarioAplicacion;

            if (ticket.Aplicacion.EsAplicacionRed)
            {
                tbTipoSolicitud.Text = "Blanqueo de Usuario de Red";
            }

            trContra.Visible = true;
            tbContra.Text = new TicketNotificacionBlanqueoBusiness().DesencriptarPassword(ticket.PasswordUsuarioAplicacion);
        }

        private void MostrarDatosTicketNotificacionTC(TicketNotificacionTarjetaEntity ticket)
        {
            tbFecha.Text = ticket.Fecha.ToString();
            tbApp.Text = ticket.Aplicacion.Nombre;
            tbNroSolicitud.Text = ticket.Id.ToString();
            tbUsuario.Text = ticket.UsuarioAplicacion;

            if (ticket.Aplicacion.EsAplicacionRed)
            {
                tbTipoSolicitud.Text = "Blanqueo de Usuario de Red";
            }

            trContra.Visible = true;

            if (ticket.Clave == null)
            {
                tbContra.Text = ticket.PasswordUsuarioAplicacion;
            }
            else
            {
                tbContra.Text = ticket.Clave.Clave;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            bool esNotif = (Session["externo"] != null);

            if (esNotif)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Tickets.aspx");
            }
        }
    }
}