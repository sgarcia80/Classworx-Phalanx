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
    public partial class FTicketUsrExtDetail : PhalanxAdmin.FModalBase
    {
        private TicketNotificacionClaveEntity _Ticket = null;

        public FTicketUsrExtDetail(int IdTicket)
        {
            InitializeComponent();
            this.Title = "Ticket de alta de usuario de Red para recursos externos";
                TicketNotificacionClaveBusiness BTNC = new TicketNotificacionClaveBusiness();
            // buscar el ticket
            try
            {
                _Ticket = BTNC.LoadTktRed(IdTicket);
            }
            catch (Common.CwxException cwxEx)
            {
                MessageBox.Show(cwxEx.FullMessage);
                this.Close();
                return;
            }

            txtDominio.Text = _Ticket.DominioUsuario;
            txtFecha.Text = _Ticket.Fecha.ToString("dd/MM/yyyy HH:mm");
            txtNroDoc.Text = _Ticket.Documento;
            txtNroTicket.Text = _Ticket.NumeroSolicitud.ToString();
            txtTipoDoc.Text = _Ticket.TipoDocumentoDesc;
            txtUsuario.Text = _Ticket.UsuarioAplicacion;
            txtPwd.Text = TicketNotificacionClaveBusiness.DesencriptarPassword(_Ticket.PasswordUsuarioAplicacion);
            if (_Ticket.FechaProcesado == null)
            {
                btnProcesar.Enabled = true;
            }
            else
            {
                txtFechaProceso.Text = _Ticket.FechaProcesado.Value.ToString("dd/MM/yyyy HH:mm");
                btnProcesar.Enabled = false;
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //string DomUsr = this.Usuario;
            TicketNotificacionClaveBusiness BTNC = new TicketNotificacionClaveBusiness();
            try
            {
                VwDateEntity GetDate =  new GetDateBusiness().GetDate();
                BTNC.SetProcesoTicket(_Ticket.Id, GetDate.GetDate);
                MessageBox.Show("Se estableció el proceso del ticket");
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo establecer el proceso del ticket");
            }
        }
    }
}

