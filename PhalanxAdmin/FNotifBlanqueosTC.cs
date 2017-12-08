using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NDCBL;
using log4net;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FNotifBlanqueosTC : PhalanxAdmin.FBaseNotifClaves
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FNotifBlanqueos));

        protected TicketNotificacionTarjetaEntityCollection _entities;
        protected AplicacionNotificacionClaveEntityCollection _aplicaciones;
        protected WinDomainEntityCollection _dominios;
        protected DominioLoginEntityCollection _tiposNotificaciones;
        private AplicacionNotificacionClaveEntity _filAplicacion;

        protected string _filUsuarioApp = "";
        protected string _filUsuario = "";
        protected string _filDominio = "";

        public FNotifBlanqueosTC()
        {
            InitializeComponent();
        }

        public override string Id
        {
            get
            {
                return "FNotifBlanqueosTC";
            }
        }

        private void FEquiposWin_Load(object sender, EventArgs e)
        {
            //NDCBL.TicketNotificacionBlanqueoBusiness business = new TicketNotificacionBlanqueoBusiness();
            //lnkAdd.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnkModify.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnkDelete.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            this.lvLista.ListViewItemSorter = new cwxSorter();
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            CargaComboAplicaciones();
            CargaComboDominios();
            ExecEntitiesRefresh();
        }

        //protected virtual void InicializaFiltros
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
            if (cbAplicacion.SelectedIndex > 0)
            {
                _filAplicacion = (AplicacionNotificacionClaveEntity)cbAplicacion.SelectedItem;
            }
            else
            {
                _filAplicacion = null;
            }

            if (cbDominio.SelectedIndex > 0)
            {
                WinDomainEntity dominio = cbDominio.SelectedItem as WinDomainEntity;

                if (dominio.Id > 0)
                {
                    _filDominio = dominio.NtName;
                }
            }
            else
            {
                _filDominio = string.Empty;
            }
        }

        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            DBRefreshEntites();
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
            TicketNotificacionTarjetaBusiness business = new TicketNotificacionTarjetaBusiness();

            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;

            var estado = TicketNotificacionTarjetaEntity.EstadoTicket.Ninguno;

            if (chkPendiente.Checked)
            {
                estado = TicketNotificacionTarjetaEntity.EstadoTicket.Ingresado;
            }

            _entities = business.GetAll(fechaDesde, fechaHasta, _filAplicacion, txtFilUsuarioApp.Text, _filDominio, txtFilUsuario.Text, estado);
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

        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = null;
            lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (TicketNotificacionTarjetaEntity entity in this._entities)
            {
                string estado = "Pendiente";

                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Id.ToString();
                lviArr[i].SubItems.Add("Blanqueo");
                lviArr[i].SubItems.Add(entity.NumeroSolicitud.ToString());
                lviArr[i].SubItems.Add(entity.UsuarioDominio);
                lviArr[i].SubItems.Add(entity.Usuario);
                lviArr[i].SubItems.Add(entity.Aplicacion == null ? string.Empty : entity.Aplicacion.ToString());
                lviArr[i].SubItems.Add(entity.UsuarioAplicacion);
                lviArr[i].SubItems.Add(entity.Fecha.ToString("dd/MM/yyyy HH:mm"));
                lviArr[i].SubItems.Add(entity.Solicitante);
                lviArr[i].SubItems.Add(entity.Estado.ToString());
                lviArr[i].SubItems.Add(entity.FechaNotificado.HasValue ? entity.FechaNotificado.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty);

                //lviArr[i].ImageIndex = ;
                lviArr[i].Tag = entity;
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
            ExecEntitiesRefresh();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtFilUsuario.Text = "";
            txtFilUsuarioApp.Text = "";
            cbAplicacion.SelectedIndex = 0;
            cbDominio.SelectedIndex = 0;
            chkPendiente.Checked = false;
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

        private void CargaComboAplicaciones()
        {
            AplicacionNotificacionClaveBusiness business = new AplicacionNotificacionClaveBusiness();
            business.FilEsEmuladores = true;
            this._aplicaciones = business.GetAll();

            this._aplicaciones.Insert(0, new AplicacionNotificacionClaveEntity { Id = 0, Nombre = "Todas" });

            cbAplicacion.DataSource = this._aplicaciones;
        }

        private void CargaComboDominios()
        {
            WinDomainBusiness business = new WinDomainBusiness();
            this._dominios = business.FillFilter();

            //this._dominios.Insert(0, new DominioLoginEntity { Nombre = "Todos", DireccionAD = "Todos" });

            cbDominio.DataSource = this._dominios;
            cbDominio.DisplayMember = "NtName";
            cbDominio.ValueMember = "Id";
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Seleccionar(false);
        }

        private void lnkReenviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedItems == null || lvLista.SelectedItems.Count == 0)
            {
                return;
            }

            int sent = 0;
            int count = lvLista.SelectedItems.Count;

            List<TicketNotificacionTarjetaEntity> collection = new List<TicketNotificacionTarjetaEntity>();

            foreach (ListViewItem item in lvLista.SelectedItems)
            {
                TicketNotificacionTarjetaEntity ticket = item.Tag as TicketNotificacionTarjetaEntity;

                if (ticket != null)
                {
                    string debug = string.Empty;

                    if (ticket.Estado == TicketNotificacionTarjetaEntity.EstadoTicket.Procesado && !ticket.FechaNotificado.HasValue)
                    {
                        collection.Add(ticket);
                    }
                }
            }

            if (count != collection.Count)
            {
                MessageBox.Show("Solo se pueden reenviar los tickets que están en estado [Procesado] y no fueron notificados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TicketNotificacionTarjetaBusiness ticketBL = new TicketNotificacionTarjetaBusiness();

            sent = ticketBL.ReenviarEmailReclamo(collection);

            MessageBox.Show(string.Format("Se reenviaron {0} de {1} mails", sent, count), "Reenvio de Mails", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMNotifBlanqueoTC form = new FABMNotifBlanqueoTC(FABMNotifBlanqueoTC.FormType.New);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExecEntitiesRefresh();
            }

        }

        private void lvLista_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar(false);
        }

        private DialogResult Seleccionar(bool edit)
        {

            if (lvLista.SelectedItems == null || lvLista.SelectedItems.Count == 0)
            {
                return DialogResult.None;
            }

            TicketNotificacionTarjetaEntity ticket = lvLista.SelectedItems[0].Tag as TicketNotificacionTarjetaEntity;

            Form form = null;

            //TODO
            form = new FABMDetalleBlanqueoTC(ticket.Id, false, FABMDetalleBlanqueoTC.FormType.View);

            return form.ShowDialog();
        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
            {
                return;
            }

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

        private void lnkGenerar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string mensaje = string.Empty;

                if (string.IsNullOrEmpty(txtDestino.Text.Trim()))
                {
                    throw new Common.CwxException("Debe seleccionar una Carpeta Destino para los archivos");
                }
                DirectoryInfo folder = new DirectoryInfo(txtDestino.Text.Trim());
                //if (!File.Exists(txtDestino.Text.Trim()))
                if (!folder.Exists)
                {
                    throw new Common.CwxException("La Carpeta Destino tiene una ruta inválida");
                }

                AplicacionNotificacionClaveEntityCollection apps = new AplicacionNotificacionClaveEntityCollection();
                List<TicketNotificacionTarjetaEntity> list = new List<TicketNotificacionTarjetaEntity>();

                TicketNotificacionTarjetaEntity ticket = null;

                log.Info("Se buscan los aplicativos de las notificaciones seleccionadas");
                List<string> invalidas = new List<string>();

                foreach (ListViewItem item in lvLista.SelectedItems)
                {
                    ticket = item.Tag as TicketNotificacionTarjetaEntity;

                    log.InfoFormat("Ticket '{0}' seleccionado de la aplicacion '{1}'", ticket.Id, ticket.Aplicacion.Codigo);

                    if (!ticket.Aplicacion.EsEmuladores)
                    {
                        if (invalidas.FindAll(o => o.Equals(string.Format("{0} - {1}", ticket.Aplicacion.Codigo, ticket.Aplicacion.Nombre))).Count == 0)
                        {
                            invalidas.Add(string.Format("{0} - {1}", ticket.Aplicacion.Codigo, ticket.Aplicacion.Nombre));
                        }
                        continue;
                    }

                    list.Add(ticket);

                    if (apps.FindByCodigo(ticket.Aplicacion.Codigo) == null)
                    {
                        apps.Add(ticket.Aplicacion);
                    }
                }

                if (invalidas.Count > 0)
                {
                    mensaje = string.Format("Las siguientes aplicaciones no están habilitadas para Emuladores{0}{1}", System.Environment.NewLine, string.Join(System.Environment.NewLine, invalidas.ToArray()));
                    MessageBox.Show(mensaje, "Generación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TicketNotificacionTarjetaBusiness business = new TicketNotificacionTarjetaBusiness();
                log.Info("Se procesan las notificaciones seleccionadas para generar los archivos");

                List<MacroArchivoEntity> archivos = business.Generar(list, apps);

                log.Info("Se proceden a generar los archivos fisicos");

                foreach (MacroArchivoEntity archivo in archivos)
                {
                    string filename = string.Format("{0}/{1}", txtDestino.Text, archivo.Nombre);

                    using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
                    {
                        sw.Write(archivo.Contenido);
                        sw.Close();
                    }
                }

                mensaje = string.Format("Se generaron correctamente {0} archivos", archivos.Count);
                MessageBox.Show(mensaje, "Generación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ExecEntitiesRefresh();
            }
            catch (Common.CwxException ex)
            {
                MessageBox.Show(ex.Message, "Generación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error("Error en la ubicacion de destino", ex);
                MessageBox.Show("No tiene permisos en la Carpeta destino para generar los archivos", "Generación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                log.Error("Error al generar los archivos", ex);
                MessageBox.Show("Error al generar los archivos", "Generación de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkProcesadasOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string mensaje = string.Format("Se marcarán las Notificaciones seleccionadas como 'Procesadas'.{0}¿Desea continuar?", System.Environment.NewLine);
            DialogResult result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                List<TicketNotificacionTarjetaEntity> list = new List<TicketNotificacionTarjetaEntity>();

                TicketNotificacionTarjetaEntity ticket = null;

                foreach (ListViewItem item in lvLista.SelectedItems)
                {
                    ticket = item.Tag as TicketNotificacionTarjetaEntity;

                    if (ticket.Estado == TicketNotificacionTarjetaEntity.EstadoTicket.Generado)
                    {
                        ticket.FechaProcesado = DateTime.Now;
                        ticket.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Procesado;
                        list.Add(ticket);
                    }
                }

                TicketNotificacionTarjetaBusiness business = new TicketNotificacionTarjetaBusiness();
                business.Save(list);

                try
                {
                    business.EnviarEmail(list);
                }
                catch (Exception)
                {

                    throw;
                }

                mensaje = string.Format("Las Notificaciones se actualizaron correctamente");
                MessageBox.Show(mensaje, "Notificaciones Procesadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ExecEntitiesRefresh();
            }
            catch (Common.CwxException ex)
            {
                MessageBox.Show(ex.Message, "Notificaciones Procesadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                log.Error("Error al procesar las Notificaciones", ex);
                MessageBox.Show("Error al procesar las Notificaciones", "Notificaciones Procesadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkProcesadasError_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FSelMacroError form = new FSelMacroError();
                DialogResult result = form.ShowDialog();

                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                if (form.Error == null)
                {
                    return;
                }

                string mensaje = string.Format("Se actualizarán las Notificaciones seleccionadas a 'Error'.{0}¿Desea continuar?", System.Environment.NewLine);
                result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                List<TicketNotificacionTarjetaEntity> list = new List<TicketNotificacionTarjetaEntity>();

                TicketNotificacionTarjetaEntity ticket = null;

                foreach (ListViewItem item in lvLista.SelectedItems)
                {
                    ticket = item.Tag as TicketNotificacionTarjetaEntity;

                    if (ticket.Estado == TicketNotificacionTarjetaEntity.EstadoTicket.Generado ||
                        ticket.Estado == TicketNotificacionTarjetaEntity.EstadoTicket.Ingresado)
                    {
                        ticket.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Error;
                        ticket.Error = form.Error;
                        list.Add(ticket);
                    }
                }

                TicketNotificacionTarjetaBusiness business = new TicketNotificacionTarjetaBusiness();
                business.Save(list);

                mensaje = string.Format("Las Notificaciones con Error se actualizaron correctamente");
                MessageBox.Show(mensaje, "Notificaciones con Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ExecEntitiesRefresh();
            }
            catch (Common.CwxException ex)
            {
                MessageBox.Show(ex.Message, "Notificaciones con Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                log.Error("Error al actualizar las Notificaciones con Error", ex);
                MessageBox.Show("Error al actualizar las Notificaciones con Error", "Notificaciones con Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtDestino.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

