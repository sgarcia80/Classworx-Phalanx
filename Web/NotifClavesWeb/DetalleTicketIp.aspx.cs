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
using System.DirectoryServices;
using PhalanxNAL;
using System.Text;
using System.Threading;

namespace NotifClavesWeb
{
    public partial class DetalleTicketIp : System.Web.UI.Page
    {
        private string UsuarioActualizarAD = "";
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
                /// si es alta de red y es la primera vez que se ve, hay que actualizar la descripcion del usuario AD y sacar 
                /// la leyenda que se puso cuando llegó el ticket
                AuditTicketNotificacionBusiness AudTBL = new AuditTicketNotificacionBusiness();

                AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();

                AplicacionNotificacionClaveEntity appRed = ancb.GetAppRed();

                if (appRed != null && ticket.Aplicacion.Codigo == appRed.Codigo && !AudTBL.Visualizado(ticket))
                {
                    UsuarioActualizarAD = ticket.Usuario;

                    if (ConfigurationManager.AppSettings["DebugChgAD"] != null && ConfigurationManager.AppSettings["DebugChgAD"].ToString() == "1")
                    {
                        ActualizarDescripcionUsuarioRed();
                    }
                    else
                    {

                        Thread oThread = new Thread(new ThreadStart(ActualizarDescripcionUsuarioRed));


                        // Start the thread
                        oThread.Start();
                        // Spin for a while waiting for the started thread to become
                        // alive:
                        while (!oThread.IsAlive) ;
                    }

                }

                if (!IsPostBack)
                    AudTBL.LogVisualizacion(ticket);

                Session["id"] = null;
            }
            else
                Response.Redirect(FormsAuthentication.LoginUrl);
        }

        private void ActualizarDescripcionUsuarioRed()
        {
            if (!ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(UsuarioActualizarAD))
            {
                return;
                StringBuilder sb = new StringBuilder();

                sb.Append("<body><script type='text/javascript'>alert('Error al agregar la descripción'); </script></body>");

                HttpContext.Current.Response.Write(sb.ToString());

                HttpContext.Current.Response.Flush();
            }
        }
        private void MostrarDatosTicket(TicketNotificacionClaveEntity ticket)
        {
            tbFecha.Text = ticket.Fecha.ToString();
            tbApp.Text = ticket.Aplicacion.Nombre;

            if (ticket.NumeroSolicitud.HasValue)
            {
                tbNroSolicitud.Text = ticket.NumeroSolicitud.GetValueOrDefault().ToString();
            }

            tbUsuario.Text = ticket.UsuarioAplicacion;

            //if (ticket.EsPasswordDominio)
            if (ticket.Aplicacion.EsAplicacionRed)
            {
                trUsaContraRed.Visible = true;

                trMail.Visible = true;
                txtEmail.Text = ticket.EmailExterno;
            }

            trContra.Visible = true;
            tbContra.Text = TicketNotificacionClaveBusiness.DesencriptarPassword(ticket.PasswordUsuarioAplicacion);

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}