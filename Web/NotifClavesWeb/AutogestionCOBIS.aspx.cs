using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDCCommon.Entities;
using NDCBL;

namespace NotifClavesWeb
{
    public partial class AutogestionCOBIS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            BloqueoBusiness bloqueoBus = new BloqueoBusiness();
            bool bloqueoCobis = bloqueoBus.IsBloqueoActivo(BloqueoEntity.TipoBLoqueo.AutogestionCobis);

            lblBloqueoCobis.Visible = bloqueoCobis;
            btnCambioClave.Enabled = !bloqueoCobis;
            btnDesbloqueoCOBIS.Enabled = !bloqueoCobis;
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClavesAplicativos.aspx");

        }
        protected void btnDesbloqueoCOBIS_Click(object sender, EventArgs e)
        {
            Response.Redirect("DesbloqueoUsuarioCOBIS.aspx");
        }
        protected void btnCambioClave_Click(object sender, EventArgs e)
        {
            //bool notificado = ValidarAutogestion();

            //lbMensaje.Visible = false;
            //if (!notificado)
            //{
            //    lbMensaje.Text = "Se debe notificar el alta de usuario antes de cambiar la contraseña";
            //    lbMensaje.Visible = true;
            //    return;
            //}

            Response.Redirect("CambioContrasenia.aspx");
        }

        private bool ValidarAutogestion()
        {
            bool ok = false;
            string usuario = Session["Usuario"].ToString();
            string dominio = Session["Dominio"].ToString();

            NDCBL.AplicacionNotificacionClaveBusiness appBL = new NDCBL.AplicacionNotificacionClaveBusiness();
            AplicacionNotificacionClaveEntity app = appBL.GetAppCobis();

            NDCBL.TicketNotificacionClaveBusiness ticketBL = new NDCBL.TicketNotificacionClaveBusiness();

            try
            {
                NDCCommon.Collections.TicketNotificacionClaveEntityCollection notificaciones = ticketBL.GetAllActiveByUser(dominio, usuario, app.Codigo);

                ok = (notificaciones.Count > 0 && notificaciones[0].FechaAceptacionTyC.HasValue);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("CerrarSesion.aspx");
        }
    }
}