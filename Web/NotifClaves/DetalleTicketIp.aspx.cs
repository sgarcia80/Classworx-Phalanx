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
            AuditTicketNotificacionBusiness AudTBL = new AuditTicketNotificacionBusiness();
            if (ticket.Aplicacion.Codigo == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower()
                && !AudTBL.Visualizado(ticket))
                ActualizarDescripcionUsuarioRed(ticket.Usuario);

            if (!IsPostBack)
                AudTBL.LogVisualizacion(ticket);

            Session["id"] = null;
        }
        else
            Response.Redirect(FormsAuthentication.LoginUrl);
    }

    private void ActualizarDescripcionUsuarioRed(string nombreUsuario)
    {
        DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(nombreUsuario);
        string strErr = "";
        if (usuario == null)
        {
            strErr = "usuario == null";
            return;
        }
        if (usuario.Properties["description"] != null)
        {
            string descripcion = usuario.Properties["description"].Value.ToString();

            if (descripcion.StartsWith(ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"]))
            {
                usuario.Properties["description"].Value = descripcion.Remove(0, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"].Length);
                strErr = "Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
                usuario.CommitChanges();
            }
            else
            {
                strErr = "NOT Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
            }
        }
        else
        {
            strErr = "(usuario.Properties[description] == null)";
        }
        if (strErr != null)
        {
            return;
            StringBuilder sb = new StringBuilder();

            sb.Append("<body><script type='text/javascript'>alert('" + strErr + "'); </script></body>");

            HttpContext.Current.Response.Write(sb.ToString());

            HttpContext.Current.Response.Flush();
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
        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}
