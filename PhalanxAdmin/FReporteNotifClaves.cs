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
using System.IO;
using System.Collections;
using NDCBL;
using NDCCommon.Entities;
using NDCCommon.Collections;
using Classworx.Common.Trace;

namespace PhalanxAdmin
{
    public partial class FReporteNotifClaves : PhalanxAdmin.FBaseReportesInternos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Notificaciones de Altas Pendientes (Red y Cobis)");
            }
        }

        protected IList _entities;

        AplicacionNotificacionClaveEntity aplicacion;
        DateTime? fechaDesde;
        DateTime? fechaHasta;

        public override string Id
        {
            get
            {
                return "FReporteNotifClaves";
            }
        }

        public FReporteNotifClaves()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

            CargaComboAplicaciones();

            cbAplicacion.SelectedIndex = 0;
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
        /// <summary>
        /// Setea las variables de filtros con los valores de los controles
        /// </summary>
        /// <example>
        /// private override void SetQueryFilters()
        /// {
        ///  _filNombre = txtFilFullname.Text;
        ///  _filEmpresa = txtFilEmpresa.Text;
        ///  _filEstado = ((EstadoClienteEntity)cbEstado.SelectedItem).Id;
        ///  _filCateg = ((CategoriaClienteEntity)cbCategoria.SelectedItem).Id;
        ///  _filLocalidad = ((LocalidadEntity)cbLocalidad.SelectedItem).Id;
        /// }
        /// </example>
        private void SetQueryFilters()
        {
            aplicacion = null;
            if (cbAplicacion.SelectedIndex > 0)
            {
                aplicacion = (AplicacionNotificacionClaveEntity)cbAplicacion.SelectedItem;
            }

            fechaDesde = dtpFechaDesde.Checked ? dtpFechaDesde.Value : (DateTime?)null;
            fechaHasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value : (DateTime?)null;
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
            IList list = new TicketNotificacionClaveBusiness().GetReporteNotif(fechaDesde, fechaHasta, aplicacion, string.Empty, string.Empty);
            TicketNotificacionClaveEntityCollection tnceC = new TicketNotificacionClaveEntityCollection();
            tnceC = (TicketNotificacionClaveEntityCollection)list;

            _entities = list;
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
            foreach (TicketNotificacionClaveEntity entidad in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /*lviArr[i].SubItems.Add(HistChgPwdEnt.User.);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.ServerName);
                lviArr[i].ImageIndex = HistChgPwdEnt.ActiveUser ? 0 : 1;*/


                lviArr[i].Text = entidad.NumeroSolicitud.ToString(); // HistChgPwdEnt.User.Username;
                //lviArr[i].SubItems.Add(entidad.TipoNotificacionDescr);
                lviArr[i].SubItems.Add("Alta de Usuario");
                lviArr[i].SubItems.Add(entidad.Aplicacion.Nombre);
                lviArr[i].SubItems.Add(entidad.UsuarioAplicacion);
                lviArr[i].SubItems.Add(entidad.Fecha.ToString("dd/MM/yyyy HH:mm"));
                lviArr[i].SubItems.Add(entidad.Reclamos.ToString());
                //if (entidad.FechaUltimoMail != null)
                //    lviArr[i].SubItems.Add(entidad.FechaUltimoMail.Value.ToString("dd/MM/yyyy HH:mm"));
                //else
                //    lviArr[i].SubItems.Add("");

                if (entidad.Reclamos == 0 || entidad.Mail == null)
                {
                    lviArr[i].SubItems.Add(string.Empty);
                }
                else
                {
                    lviArr[i].SubItems.Add(entidad.Mail.SendDate.Value.ToString("dd/MM/yyyy HH:mm"));
                }


                lviArr[i].Tag = entidad;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidateFilters())
            {
                try
                {
                    ExecEntitiesRefresh();
                }
                catch
                {
                    MessageBox.Show("Error al realizar la búsqueda", "Error");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            cbAplicacion.SelectedIndex = 0;

            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = true;

            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
        }

        private void lnkCancelar_Click(object sender, EventArgs e)
        {
            this.bwRefreshEntities.CancelAsync();
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            this.lblStatus.Text = "Cancelado";
            this.lvLista.Items.Clear();
            this.pnlFilters.Enabled = true;
            this.pnlList.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void FHistPwdChg_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";
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

        private bool ValidateFilters()
        {
            return true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFilters())
                {
                    DBRefreshEntites();

                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    saveFileDialog1.FileName = "Reclamos_Notificacion_Clave";
                    saveFileDialog1.Title = "Exportar a CSV";

                    StringBuilder sb = new StringBuilder();
                    string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    sb.Append("Nro" + Separator);
                    sb.Append("Tipo Notificacion" + Separator);
                    sb.Append("Aplicacion" + Separator);
                    sb.Append("Usuario" + Separator);
                    sb.Append("Fecha" + Separator);
                    sb.Append("Cant. Reclamos");

                    foreach (TicketNotificacionClaveEntity entidad in this._entities)
                    {
                        sb.AppendLine();
                        sb.Append(entidad.Id.ToString() + Separator);
                        //sb.Append(entidad.TipoNotificacionDescr + Separator);
                        sb.Append("Alta de Usuario" + Separator);
                        sb.Append(entidad.Aplicacion.Nombre + Separator);
                        sb.Append(entidad.UsuarioAplicacion + Separator);
                        sb.Append(entidad.Fecha.ToString("dd/MM/yyyy HH:mm") + Separator);
                        sb.Append(entidad.Reclamos.ToString() + Separator);
                    }

                    DialogResult dr = saveFileDialog1.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
                        sw.Write(sb.ToString());
                        sw.Close();

                        MessageBox.Show("La exportación ha sido completada", "Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargaComboAplicaciones()
        {
            AplicacionNotificacionClaveBusiness business = new AplicacionNotificacionClaveBusiness();

            AplicacionNotificacionClaveEntityCollection aplicaciones = new AplicacionNotificacionClaveEntityCollection();

            AplicacionNotificacionClaveEntity app = null;

            app = business.GetAppCobis();
            if (app != null)
            {
                aplicaciones.Add(app);
            }
            app = business.GetAppRed();
            if (app != null)
            {
                aplicaciones.Add(app);
            }

            aplicaciones.Insert(0, new AplicacionNotificacionClaveEntity { Id = 0, Nombre = "Todas" });

            cbAplicacion.DataSource = aplicaciones;
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;

            cantidad = lvLista.SelectedItems.Count;

            if (cantidad == 0)
            {
                MessageBox.Show("Debe seleccionar alguna notificación para reenviar");
                return;
            }

            string mensaje = string.Format("Se enviarán {0} avisos de notificación pendientes. ¿Desea continuar?", cantidad);

            DialogResult result = MessageBox.Show(mensaje, "Reenvio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                TicketNotificacionClaveEntityCollection collection = new TicketNotificacionClaveEntityCollection();
                TicketNotificacionClaveEntity entity = null;

                foreach (ListViewItem item in lvLista.SelectedItems)
                {
                    entity = item.Tag as TicketNotificacionClaveEntity;

                    if (entity != null)
                    {
                        collection.Add(entity);
                    }
                }

                TicketNotificacionClaveBusiness ticketBL = new TicketNotificacionClaveBusiness();

                try
                {
                    int cant = ticketBL.ReenviarEmailReclamo(collection);

                    if (cant == collection.Count)
                    {
                        MessageBox.Show("Se reenviaron los mails correctamente", "Reenvio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Se enviaron {0} de {1} reclamos", cant, collection.Count), "Reenvio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ExecEntitiesRefresh();
                }
                catch (Exception ex)
                {
                    mensaje = string.Format("Error al reenviar los mails. {0}{1}", System.Environment.NewLine, ex.Message);
                    MessageBox.Show(mensaje, "Reenvio", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLista.SelectedItems != null && lvLista.SelectedItems.Count > 0)
                {
                    if (string.IsNullOrEmpty(txtComentarios.Text))
                    {
                        MessageBox.Show("Debe ingresar un Motivo de anulación", "Advertencia");
                        txtComentarios.Focus();
                        return;
                    }

                    TicketNotificacionClaveEntity ticket = null;
                    List<TicketNotificacionClaveEntity> tickets = new List<TicketNotificacionClaveEntity>();
                    DateTime fechabaja = DateTime.Now;

                    foreach (ListViewItem item in lvLista.SelectedItems)
                    {
                        ticket = item.Tag as TicketNotificacionClaveEntity;

                        if (!ticket.FechaBaja.HasValue && !ticket.FechaAceptacionTyC.HasValue)
                        {
                            ticket.FechaBaja = fechabaja;
                            ticket.ComentariosBaja = txtComentarios.Text.Trim();
                            tickets.Add(ticket);
                        }
                    }

                    if (MessageBox.Show(string.Format("Se anularán {0} tickets de los {1} seleccionados.{2}¿Desea continuar?", tickets.Count, lvLista.SelectedItems.Count, System.Environment.NewLine), "Advertencia", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }

                    TicketNotificacionClaveEntityCollection list = new TicketNotificacionClaveEntityCollection();
                    list.Add(tickets);

                    TicketNotificacionClaveBusiness business = new TicketNotificacionClaveBusiness();
                    business.Save(list);

                    MessageBox.Show("Los tickets se anularon correctamente");
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al anular los tickets";
                TraceHelper.Error(ex, mensaje);

                MessageBox.Show(mensaje, "Error");
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLista.SelectedItems != null && lvLista.SelectedItems.Count > 0)
                {
                    string user = "";
                    TicketNotificacionClaveEntity ticket = null;
                    List<TicketNotificacionClaveEntity> tickets = new List<TicketNotificacionClaveEntity>();
                    DateTime fechabaja = DateTime.Now;

                    foreach (ListViewItem item in lvLista.SelectedItems)
                    {
                        ticket = item.Tag as TicketNotificacionClaveEntity;

                        if (!ticket.FechaBaja.HasValue && ticket.Aplicacion.EsAplicacionRed && !ticket.FechaAceptacionTyC.HasValue)
                        {
                            user = ticket.UsuarioAplicacion;

                            string nombreUser = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(user);

                            if (string.IsNullOrEmpty(nombreUser))
                            {
                                ticket.FechaBaja = fechabaja;
                                ticket.ComentariosBaja = "Usuario no encontrado en Dominio";
                                tickets.Add(ticket);
                            }
                        }
                    }

                    if (MessageBox.Show(string.Format("Se anularán {0} tickets de los {1} seleccionados.{2}¿Desea continuar?", tickets.Count, lvLista.SelectedItems.Count, System.Environment.NewLine), "Advertencia", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }

                    TicketNotificacionClaveEntityCollection list = new TicketNotificacionClaveEntityCollection();
                    list.Add(tickets);

                    TicketNotificacionClaveBusiness business = new TicketNotificacionClaveBusiness();
                    business.Save(list);

                    MessageBox.Show("Los tickets se anularon correctamente");
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Error al validar los usuarios en el Dominio";
                TraceHelper.Error(ex, mensaje);

                MessageBox.Show(mensaje, "Error");
            }
        }
    }
}

