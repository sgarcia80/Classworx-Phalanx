using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCDAL.Factories;
using NDCBL;
using NDCCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FTicketControl : PhalanxAdmin.FModalBase
    {
        private TicketNotificacionClaveEntity _Ticket = null;

        public FTicketControl(int IdTicket)
        {
            InitializeComponent();
            this.Title = "Control de Ticket";
                
            TicketNotificacionClaveBusiness BTNC = new TicketNotificacionClaveBusiness();
            // buscar el ticket
            try
            {
                _Ticket = BTNC.Load(IdTicket);
            }
            catch (Common.CwxException cwxEx)
            {
                MessageBox.Show(cwxEx.FullMessage);
                this.Close();
                return;
            }

            txtUsuarioRed.Text = _Ticket.Usuario;
            txtDominio.Text = _Ticket.DominioUsuario;
            txtAplicativo.Text = _Ticket.Aplicacion.Nombre;
            txtFecha.Text = _Ticket.Fecha.ToString("dd/MM/yyyy HH:mm");
            txtNroDoc.Text = _Ticket.Documento;
            txtNroTicket.Text = _Ticket.NumeroSolicitud.HasValue ? _Ticket.NumeroSolicitud.GetValueOrDefault().ToString() : string.Empty;
            txtTipoDoc.Text = _Ticket.TipoDocumentoDesc;
            txtUsuario.Text = _Ticket.UsuarioAplicacion;
            txtLegajo.Text = _Ticket.Legajo; //TicketNotificacionClaveBusiness.DesencriptarPassword(_Ticket.PasswordUsuarioAplicacion);
            
            //if (_Ticket.FechaProcesado != null)
            //    txtFechaProceso.Text = _Ticket.FechaProcesado.Value.ToString("dd/MM/yyyy HH:mm");

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TicketNotificacionClaveBusiness BTNC = new TicketNotificacionClaveBusiness();
            try
            {
                BTNC.SetNombreUsuarioAplicacion(_Ticket.Id, txtUsuario.Text);
                
                MessageBox.Show("El nombre de usuario se guardó correctamente");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("No se pudo guardar el nombre de usuario");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void txtFechaProceso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

