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
using System.Collections.Generic;
using NDCCommon.Collections;
using Classworx.Common.Trace;

namespace NotifClavesWeb
{
    public partial class SolicitudBlanqueoTarjeta : System.Web.UI.Page
    {
        string Usuario = string.Empty;
        string Dominio = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }


            if (Session["Usuario"] != null)
            {
                Usuario = Session["Usuario"].ToString();
            }
            if (Session["Dominio"] != null)
            {
                Dominio = Session["Dominio"].ToString();
            }

            tbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbUsuarioRed.Text = string.Format("{0}\\{1}", Dominio, Usuario);

            if (!IsPostBack)
            {
                CargarTarjetas(Usuario);

                if (gvTickets.Rows.Count == 0)
                {
                    lblInfo.Text = "No tiene Usuarios de Tarjetas de Crédito asociados. Debe solicitar los blanqueos mediante Remedy";
                    btnAceptar.Visible = false;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MacroUsuarioTarjetaBusiness tcbusiness = new MacroUsuarioTarjetaBusiness();

            List<TicketNotificacionTarjetaEntity> list = new List<TicketNotificacionTarjetaEntity>();
            TicketNotificacionTarjetaEntity solicitud = null;

            string dominio = string.Empty;
            int id = 0;

            if (Session["Dominio"] != null)
            {
                dominio = Session["Dominio"].ToString();
            }

            foreach (GridViewRow row in gvTickets.Rows)
            {
                MacroUsuarioTarjetaEntity usuariotc = row.DataItem as MacroUsuarioTarjetaEntity;
                CheckBox seleccion = row.FindControl("chkSeleccionar") as CheckBox;

                if (seleccion != null && seleccion.Checked)
                {
                    int.TryParse(gvTickets.DataKeys[row.DataItemIndex].Value.ToString(), out id);
                    usuariotc = tcbusiness.Load(id);

                    if (usuariotc != null)
                    {
                        solicitud = new TicketNotificacionTarjetaEntity();

                        solicitud.Aplicacion = usuariotc.Aplicacion;
                        solicitud.UsuarioAplicacion = usuariotc.UsuarioTC;

                        solicitud.UsuarioDominio = dominio;
                        solicitud.Usuario = usuariotc.UsuarioRed;

                        solicitud.Fecha = DateTime.Now;
                        solicitud.Solicitante = usuariotc.UsuarioRed;
                        solicitud.UsuarioCarga = tbUsuarioRed.Text;

                        list.Add(solicitud);
                    }
                }
            }

            if (list.Count == 0)
            {
                lblInfo.Text = "Debe seleccionar al menos un Usuario para blanquear";
                return;
            }

            try
            {
                TicketNotificacionTarjetaBusiness business = new TicketNotificacionTarjetaBusiness();
                business.Create(list);

                CargarTarjetas(list[0].Usuario);

                string mensaje = string.Empty;
                if (list.Count == 1)
                {
                    mensaje = string.Format("Se generaron correctamente {0} solicitud", list.Count);
                }
                else
                {
                    mensaje = string.Format("Se generaron correctamente {0} solicitudes", list.Count);
                }

                lblInfo.Text = mensaje;
                btnAceptar.Visible = false;
            }
            catch (Exception ex)
            {
                TraceHelper.Error(ex, "Error al generar las solicitudes");
                lblInfo.Text = "Hubo un error al generar las solicitudes. Comuníques con el Administrador";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClavesAplicativos.aspx");
        }

        public void CargarTarjetas(string usuario)
        {
            MacroUsuarioTarjetaBusiness business = new MacroUsuarioTarjetaBusiness();
            MacroUsuarioTarjetaEntityCollection list = business.GetAll(usuario);

            gvTickets.DataSource = list;
            gvTickets.DataBind();
        }
    }
}