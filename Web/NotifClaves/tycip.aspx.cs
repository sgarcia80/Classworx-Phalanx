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
        string strErr = "Inicio";
        //try
        //{
            if (Session["id"] != null)
            {
                strErr = "Session[id] != null: " + Session["id"].ToString();
                int id = (int)Session["id"];

                TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();
                strErr = "tncb.GetById(id)";
                TicketNotificacionClaveEntity ticket = tncb.GetById(id);

                strErr = "tncb.AceptarTyC(ticket);";
                tncb.AceptarTyC(ticket);

                strErr = "ConfigurationManager.AppSettings[CodigoAppAltaTemprana].Trim().ToLower())";
                //if (ticket.Aplicacion.Codigo == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower())
                //    ActualizarDescripcionUsuarioRed(ticket.Usuario);

                Response.Redirect("DetalleTicketIp.aspx?");
            }
        //}
        //catch (Exception ex)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<body><script type='text/javascript'>alert('" + strErr+ " | " + ex.Message + "'); </script></body>");

        //    HttpContext.Current.Response.Write(sb.ToString());

        //    HttpContext.Current.Response.Flush();
            
        //}
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("IdentificacionPositiva.aspx?id=" + Session["id"]);
    }

	private void ActualizarDescripcionUsuarioRed(string nombreUsuario)
	{
		DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(nombreUsuario);

		if (usuario == null)
			return;
        if (usuario.Properties["description"] != null)
        {
            string descripcion = usuario.Properties["description"].Value.ToString();

            if (descripcion.StartsWith(ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"]))
            {
                usuario.Properties["description"].Value = descripcion.Remove(0, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"].Length);

                usuario.CommitChanges();
            }
        }
	}
}
