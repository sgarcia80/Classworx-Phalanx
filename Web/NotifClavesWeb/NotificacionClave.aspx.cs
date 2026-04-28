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
using NDCCommon.Collections;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using Classworx.Common.Trace;

namespace NotifClavesWeb
{
    public partial class NotificacionClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WinDomainBusiness dominioLoginBL = new WinDomainBusiness();
                dominioLoginBL.FilConfigured = true;
                WinDomainEntityCollection dominios = dominioLoginBL.GetAll();

                ddlDominio.DataSource = dominios;
                ddlDominio.DataBind();
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = tbLegajo.Text.Trim();
            lblMensajeNotif.Text = "";

            string valor = ddlDominio.SelectedItem.Value;
            int id = 0;
            string path = string.Empty;

            int.TryParse(valor, out id);

            WinDomainBusiness dominioLoginBL = new WinDomainBusiness();
            WinDomainEntityCollection dominios = dominioLoginBL.GetById(id);

            if (dominios.Count > 0)
            {
                path = dominios[0].LDAPPath;
            }

            TraceHelper.Information("Se valida el usuario {0}", usuario);
            string legajo = PhalanxNAL.ActiveDirectoryHelper.BuscarEmployeeID(usuario, path);

            //bool esExterno = nombreUser.ToUpper().Contains("EXTERNO");
            bool esExterno = string.IsNullOrEmpty(legajo);

            TraceHelper.Information("El usuario es {0}", (esExterno ? "Externo" : "Interno"));
            AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();
            AplicacionNotificacionClaveEntity aplicacion = ancb.GetAppRed();

            TraceHelper.Information("Se consulta si existe un ticket de blanqueo");
            TicketNotificacionBlanqueoBusiness tncb = new TicketNotificacionBlanqueoBusiness();
            TicketNotificacionBlanqueoEntityCollection tickets = tncb.GetAll(TicketNotificacionBlanqueoEntity.TipoNotificacionBlanqueoRed, null, null, aplicacion, usuario, string.Empty, string.Empty, true, string.Empty);

            if (tickets == null || tickets.Count == 0)
            {
                TraceHelper.Information("No existe ticket de blanqueo");
                lblMensajeNotif.Text = "No existe ticket de Blanqueo para este Usuario";

                return;
            }

            string url = string.Empty;

            Session["externo"] = (esExterno) ? "S" : "N";

            if (esExterno)
            {
                TraceHelper.Information("Se valida si existen las preguntas secretas");

                QuestionAnswerBusiness qab = new QuestionAnswerBusiness();
                qab.FilUser = usuario;

                QuestionAnswerEntityCollection qaEC = new QuestionAnswerEntityCollection();
                qaEC = qab.GetAll();

                if (qaEC == null || qaEC.Count == 0)
                {
                    lblMensajeNotif.Text = "El usuario externo no tiene cargadas las preguntas.";
                    return;
                }

                url = "ValidaRespuestas.aspx";
            }
            else //INTERNO
            {
                TraceHelper.Information("Se debe utilizar Identificacion Positiva");
                Session["seed"] = TimeSpan.FromTicks(DateTime.Now.Ticks).Seconds; ;

                url = "IdentificacionPositiva.aspx?";
            }

            if (!string.IsNullOrEmpty(url))
            {
                TraceHelper.Information("Se redirecciona a {0}", url);
                Session["Dominio"] = "MACRO";
                Session["Usuario"] = usuario;
                Session["ticketId"] = tickets[0].Id;

                Response.Redirect(url);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.LoginUrl);
        }

    }
}