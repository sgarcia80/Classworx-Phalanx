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

        Session["ticketId"] = ticket.Id;
        Session["seed"] = TimeSpan.FromTicks(DateTime.Now.Ticks).Seconds;

        Response.Redirect("IdentificacionPositiva.aspx?");
    }
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(FormsAuthentication.LoginUrl);
    }
}
