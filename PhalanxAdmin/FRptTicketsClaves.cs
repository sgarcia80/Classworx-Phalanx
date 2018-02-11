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
using System.IO;

namespace PhalanxAdmin
{
    public partial class FRptTicketsClaves : PhalanxAdmin.FBaseReportes
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Listado de Tickets de Notificación de Claves");
            }
        }

        protected AplicacionNotificacionClaveEntity _filApp = null;

        public override string Id
        {
            get
            {
                return "FTRptTicketsClaves";
            }
        }

        protected TicketNotificacionClaveEntityCollection _entities;
        
        public FRptTicketsClaves()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter(); 

            PhxUserBusiness UsrBL = new PhxUserBusiness();
            btnVer.Visible = UsrBL.AccTickets(this.Usuario);
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
            if ((cbFilApp.SelectedItem as AplicacionNotificacionClaveEntity).Id > -1)
                _filApp = cbFilApp.SelectedItem as AplicacionNotificacionClaveEntity;
            else
                _filApp = null;
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
            
            _entities = TicketNotificacionClaveBL.GetAll(ObtenerFecha(txtFDesde.Text), ObtenerFecha(txtFHasta.Text), _filApp, dominio, usuario, null, null, null);
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
                if (ticket.Usuario.ToLower() != ticket.UsuarioAplicacion.ToLower())
                {
                    lviArr[i].ImageIndex = 0;
                }
                lviArr[i].Text = ticket.NumeroSolicitud.ToString();
                lviArr[i].SubItems.Add(ticket.Aplicacion.ToString());
                lviArr[i].SubItems.Add(ticket.UsuarioAplicacion);
                lviArr[i].SubItems.Add(ticket.DominioUsuario+@"\"+ticket.Usuario);
                lviArr[i].SubItems.Add(ticket.Fecha.ToString("dd/MM/yyyy HH:m:ss")); // HistChgPwdEnt.User.Username;
                string strLegajo = "";
                if (ticket.Legajo != null)
                {
                    strLegajo = ticket.Legajo;
                }
                lviArr[i].SubItems.Add(strLegajo);
                // lviArr[i].SubItems.Add(ticket.TipoDocumento); // se eliminó en versión 3.2
                lviArr[i].SubItems.Add(ticket.Documento);
                lviArr[i].SubItems.Add(ticket.FechaAceptacionTyC == null ? string.Empty : ticket.FechaAceptacionTyC.Value.ToString("dd/MM/yyyy HH:m:ss"));
                lviArr[i].SubItems.Add(ticket.Corregido ? "Sí" : "No");
                lviArr[i].Tag = ticket;
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

        private void FRptTicketsClaves_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";

            AplicacionNotificacionClaveBusiness ANCBL = new AplicacionNotificacionClaveBusiness();
            AplicacionNotificacionClaveEntityCollection apps = ANCBL.GetAll();

            AplicacionNotificacionClaveEntity todos = new AplicacionNotificacionClaveEntity();
            todos.Id = -1;
            todos.Nombre = "Todos";
            apps.Insert(0, todos);

            cbFilApp.DataSource = apps;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = "Tickets Notificacion Claves";
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                foreach (ColumnHeader ch in lvLista.Columns)
                {
                    sb.Append(ch.Text + Separator);
                }
                foreach (ListViewItem lvi in lvLista.Items)
                {
                    sb.AppendLine();
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        if (lvs.Text.Trim() == string.Empty)
                            sb.Append(" " + Separator);
                        else
                            sb.Append(lvs.Text + Separator);
                    }
                }
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.Write(sb.ToString());
                    sw.Close();
                MessageBox.Show("La exportación ha sido completada", "Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
                int Idticket = ((TicketNotificacionClaveEntity)lvLista.SelectedItems[0].Tag).Id;
                FTicketControl frmTicketControl = new FTicketControl(Idticket);
                frmTicketControl.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Hubo problemas al mostrar los detalles del ticket", "Control de ticket");
            }
        }

    }
}

