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

namespace NotifClavesWeb
{
    public partial class AltaTemprana : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSociedad.DataSource = new Meta4SociedadBusiness().GetAll();
                ddlSociedad.DataBind();
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();

            Meta4LegajoEntity legajo = m4lb.GetByLegajoAndSociedad(tbLegajo.Text.Trim().PadLeft(6, '0'), ddlSociedad.SelectedValue);

            if (legajo == null)
            {
                lbMensaje.Text = "Legajo no existente para la sociedad seleccionada. Verifique legajo y/o sociedad";

                return;
            }

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetAltaTempranaTicket(legajo.IdTipoDocumento, legajo.Documento);

            if (ticket == null)
            {
                lbMensaje.Text = "No existe ticket de Alta Temprana para este legajo";

                return;
            }

            Session["tipoticket"] = null;

            Session["Dominio"] = "MACRO";
            Session["Usuario"] = "";
            Session["externo"] = null;
            Session["ticketId"] = ticket.Id;
            Session["seed"] = TimeSpan.FromTicks(DateTime.Now.Ticks).Seconds;

            Response.Redirect("IdentificacionPositiva.aspx?");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.LoginUrl);
        }

        protected void btnAceptarToken_Click(object sender, EventArgs e)
        {
            string token = tbToken.Text.Trim();

            if (token == string.Empty)
            {
                lbMensajeToken.Text = "Debe ingresar el token";

                return;
            }

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetByToken(token);

            if (ticket == null)
            {
                lbMensajeToken.Text = "No existe ticket para el token ingresado";

                return;
            }
            else if (ticket.FechaAceptacionTyC != null)
            {
                lbMensajeToken.Text = "La clave ya fue notificada";

                return;
            }
            else if (ticket.Expirado())
            {
                lbMensajeToken.Text = "El token ha expirado, por favor, solicite uno nuevo";

                return;
            }

            ticket.AltaTempranaTokenFecha = DateTime.Now;
            ticket.AltaTempranaTokenTerminal = Request.UserHostAddress;
            ticket.AltaTempranaTokenUsuario = User != null && User.Identity != null ? User.Identity.Name : string.Empty;

            tncb.Save(ticket);

            Session["tipoticket"] = null;

            Session["id"] = ticket.Id;
            Session["Usuario"] = ticket.Usuario;
            Session["externo"] = "S";

            Response.Redirect("tycip.aspx");
        }
    }
}