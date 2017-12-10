using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxBL;
using PhalanxCommon.Entities;
using NDCCommon.Collections;
using NDCBL;
using NDCCommon.Entities;
using System.Configuration;
using PhalanxCommon;
using PhalanxDAL.Factories;

namespace PhalanxAdmin
{
    public partial class FTicketsAltaTempUsrExt : PhalanxAdmin.FBaseReportes
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Alta Temprana de Recursos Externos");
            }
        }

        protected AplicacionNotificacionClaveEntity _filApp = null;

        public override string Id
        {
            get
            {
                return "FTicketsAltaTempUsrExt";
            }
        }

        protected TicketNotificacionClaveEntityCollection _entities;
        
        public FTicketsAltaTempUsrExt()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter(); 
        }
        /* Proceso de acceso a DB
* 1 - ExecClientesRefresh
* 2 - se ejecuta la función asociada al evento DoWork del background worker
* 3 - DBRefreshEntites()
* 4 - LoadEntities: acá regenera la lista de entidades
* 5 - RefreshClientesLV: arma los listview items
* 6 - SetLVItems: agrega los LVItems al LV mediante callbacks
*/
        /// <summary>
        /// Pone el form en estado de búsqueda, setea los filtros de búsqueda y arranda el BackgroundWorker
        /// </summary>
        private void ExecEntitiesRefresh()
        {
            if (lvLista.Columns.Count == 0)
            {
                //throw new Exception("Se deben definir las columnas del ListView");
            }

            this.Cursor = Cursors.WaitCursor;
            this.lnkCancelar.Visible = true;
            this.pbDB.Visible = true;
            this.lblStatus.Text = "Buscando...";
            SetQueryFilters();
            this.pnlFilters.Enabled = false;
            this.pnlList.Enabled = false;
            if (bwRefreshEntities.IsBusy)
            {
                bwRefreshEntities.CancelAsync();
            }
            else
            {
                this.bwRefreshEntities.RunWorkerAsync();
            }
        }
        private void SetQueryFilters()
        {
               // _filApp = null;
            //_filNombre = txtFilNombre.Text.Trim();

        }

        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DBRefreshEntites();
        }
        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        /// <summary>
        /// Carga la lista de entidades a mostrar en el listview
        /// </summary>
        /// <example>
        /// protected override void LoadEntities()
        /// {
        ///     ClienteBusiness ClieBL = new ClienteBusiness();
        ///     this._entities = ClieBL.Load(_filNombre, _filEmpresa, _filEstado, _filCateg, _filLocalidad);
        /// }
        /// </example>
        private void LoadEntities()
        {
            //HistPasswordChangeBusiness HistPwdChgBL = new HistPasswordChangeBusiness();
            TicketNotificacionClaveBusiness TicketNotificacionClaveBL = new TicketNotificacionClaveBusiness();
            // seteo filtros
            //AplicacionNotificacionClaveEntity app = cbFilApp.SelectedItem as AplicacionNotificacionClaveEntity;
            string dominio = txtFilDominio.Text.Trim();

            if (dominio == string.Empty)
                dominio = null;

            string usuario = txtFilUsuario.Text.Trim();

            if (usuario == string.Empty)
                usuario = null;
            int? iFilTicket = null;
            if (txtFilTicket.Text != "")
                iFilTicket = Convert.ToInt32(txtFilTicket.Text);

            bool? filVencido = null;
            bool? filNotificado = null;

            if (chkVencido.Checked)
            {
                filVencido = true;
                filNotificado = false;
            }
            
            _entities = TicketNotificacionClaveBL.GetAllUsrExt(ObtenerFecha(txtFDesde.Text), ObtenerFecha(txtFHasta.Text), _filApp, dominio, usuario, iFilTicket, filVencido, filNotificado);
        }

        /// <summary>
        /// Llama a la función que genera el array de LV Items y si hay items llama a la que hace el llenado
        /// usando el delegado
        /// </summary>
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }
        delegate void SetItemsAddRangeCallback(ListViewItem[] lvitems);

        /// <summary>
        /// Llena el Listview con los items pasados en el array
        /// </summary>
        /// <param name="lviArr">Array de Listview Items para llenar el Listview</param>
        private void SetLVItems(ListViewItem[] lviArr)
        {
            if (this.lvLista.InvokeRequired)
            {
                SetItemsAddRangeCallback d = new SetItemsAddRangeCallback(SetLVItems);
                this.Invoke(d, new object[] { lviArr });
            }
            else
            {
                this.lvLista.Items.Clear();
                if (lviArr.Length > 0)
                {

                    this.lvLista.Items.AddRange(lviArr);
                }
            }
        }

        /// <summary>
        /// Genera los list view items para llenar el list view
        /// </summary>
        /// <returns>Devuelve el arrary de list view items para llenar el listview</returns>
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (TicketNotificacionClaveEntity ticket in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /*lviArr[i].SubItems.Add(HistChgPwdEnt.User.);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.ServerName);
                lviArr[i].ImageIndex = HistChgPwdEnt.ActiveUser ? 0 : 1;*/
                lviArr[i].Text = ticket.NumeroSolicitud.ToString();
                lviArr[i].SubItems.Add(ticket.Aplicacion.Nombre);
                lviArr[i].SubItems.Add(ticket.Usuario);
                lviArr[i].SubItems.Add(ticket.DominioUsuario);
                lviArr[i].SubItems.Add(ticket.Fecha.ToString("dd/MM/yyyy HH:m:ss")); // HistChgPwdEnt.User.Username;
                string strLegajo = "";
                if (ticket.Legajo != null)
                {
                    strLegajo = ticket.Legajo;
                }
                lviArr[i].SubItems.Add(strLegajo);
                lviArr[i].SubItems.Add(ticket.TipoDocumento);
                lviArr[i].SubItems.Add(ticket.Documento);
                lviArr[i].SubItems.Add(ticket.FechaAceptacionTyC == null ? string.Empty : ticket.FechaAceptacionTyC.Value.ToString("dd/MM/yyyy HH:m:ss"));
				lviArr[i].SubItems.Add(ticket.AltaTempranaTokenFecha != null ? "Sí" : "No");
                lviArr[i].SubItems.Add(ticket.FechaExpiracionToken == null ? string.Empty : ticket.FechaExpiracionToken.Value.ToString("dd/MM/yyyy HH:m:ss"));
                lviArr[i].Tag = ticket.Id;
                i++;
            }
            return lviArr;

        }

        private void bwRefreshEntities_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                this.lblStatus.Text = "Cancelado";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                this.lblStatus.Text = "Listo"; // e.Result.ToString();
                this.lnkCancelar.Visible = false;
                this.pbDB.Visible = false;
                this.pnlFilters.Enabled = true;
                this.pnlList.Enabled = true;
                if (this.lvLista.Items.Count > 0)
                {
                    this.lvLista.Items[0].Selected = true;
                    this.lvLista.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void FTicketsAltaTempUsrExt_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha de inicio (dd/mm/aaaa)";
            try
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                DateTime dTest;
                if (txtFDesde.Text.Trim() != "/  /")
                {
                    dTest = Convert.ToDateTime(txtFDesde.Text, dtfi);
                }
                if (txtFHasta.Text.Trim() != "/  /")
                {
                    strErrorMsg = "Verifique el formato de la fecha de fin (dd/mm/aaaa)";
                    dTest = Convert.ToDateTime(txtFHasta.Text, dtfi);
                }
                strErrorMsg = "Valor no válido para el nro. de ticket.";
                if (txtFilTicket.Text != "")
                {
                    int iTicket = Convert.ToInt32(txtFilTicket.Text);
                }
            
                strErrorMsg = "No exste la aplicación correspondiente a altas de Red";
                _filApp = new AplicacionNotificacionClaveBusiness().GetAppRed();
                if (_filApp == null)
                {
                    throw new CwxException(strErrorMsg);
                }

                //DateTime FDesde = Convert.ToDateTime(txtFDesde.Text,
                ExecEntitiesRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErrorMsg, "Error en filtros de búsqueda");
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtFDesde.Text = "";
            txtFHasta.Text = "";

        }

        private DateTime? ObtenerFecha(string fecha)
        {
            if (!string.IsNullOrEmpty(fecha) && fecha.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                   System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                
                return Convert.ToDateTime(fecha, dtfi);
            }

            return null;
        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
                return;

            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;

            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                else
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            ((ListView)sender).Sort();
        }

        private void lvLista_DoubleClick(object sender, EventArgs e)
        {
            VerTicket();
        }

        private void btnVerTicket_Click(object sender, EventArgs e)
        {
            VerTicket();
        }
        private void VerTicket()
        {
            if (lvLista.SelectedItems.Count < 1)
            {
                return;
            }
            try
            {
                int Idticket = (int)lvLista.SelectedItems[0].Tag;
                FTicketUsrExtDetail frmViewticket = new FTicketUsrExtDetail(Idticket);
                frmViewticket.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Hubo problemas al mostrar los detalles del ticket", "Visualización de ticket");
            }
        }

		private void btnReenviarMail_Click(object sender, EventArgs e)
		{
			if (lvLista.SelectedItems.Count < 1)
			{
				return;
			}
			try
			{
				int Idticket = (int)lvLista.SelectedItems[0].Tag;

				TicketNotificacionClaveBusiness bsolb = new TicketNotificacionClaveBusiness();

				TicketNotificacionClaveEntity ticket = bsolb.GetById(Idticket);

                FReenvioMail frmReenvioMail = new FReenvioMail(ticket.MailId.Value);
                frmReenvioMail.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Hubo problemas al reenviar el email", "Reenvio de email");
			}
		}

        private void btnRegenerarToken_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedItems.Count < 1)
            {
                return;
            }
            try
            {
                int Idticket = (int)lvLista.SelectedItems[0].Tag;

                TicketNotificacionClaveBusiness bsolb = new TicketNotificacionClaveBusiness();

                TicketNotificacionClaveEntity ticket = bsolb.GetById(Idticket);

                if (!string.IsNullOrEmpty(ticket.Token) && ticket.Expirado())
                {
                    string MsgOut = "";
                    if (bsolb.ReGenerateToken(ticket, out MsgOut))
                        MessageBox.Show("El token se regeneró con éxito", "Regeneración de token");
                    else
                        MessageBox.Show(MsgOut, "Regeneración de token");

                }
                else
                    MessageBox.Show("El ticket no esta expirado", "Regeneración de token");
            }
            catch
            {
                MessageBox.Show("Hubo problemas al regenerar el token", "Regeneración de token");
            }
        }
    }
}

