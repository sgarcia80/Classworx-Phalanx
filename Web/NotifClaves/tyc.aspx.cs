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
        int id;

        if (Request["id"] != null && int.TryParse(Request["id"], out id))
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

			TicketNotificacionClaveEntity ticket = tncb.GetById(id);

            tncb.AceptarTyC(ticket);

			if (ticket.Aplicacion.Codigo == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower())
				ActualizarDescripcionUsuarioRed(ticket.Usuario);

            Response.Redirect("DetalleTicket.aspx?id=" + Request["id"]);
        }
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tickets.aspx");
    }

	private void ActualizarDescripcionUsuarioRed(string nombreUsuario)
	{
		DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(nombreUsuario);

		if (usuario == null)
			return;

		string descripcion = usuario.Properties["description"].Value.ToString();

		if (descripcion.StartsWith(ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"]))
		{
			usuario.Properties["description"].Value = descripcion.Remove(0, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"].Length);

			usuario.CommitChanges();
		}
	}
}
