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

namespace PhalanxAdmin
{
    public partial class FNotifBlanqueos : PhalanxAdmin.FBaseNotifClaves
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FNotifBlanqueos));

        protected TicketNotificacionBlanqueoEntityCollection _entities;
        protected AplicacionNotificacionClaveEntityCollection _aplicaciones;
        protected DominioLoginEntityCollection _dominios;
        private AplicacionNotificacionClaveEntity _filAplicacion;
        protected string _filUsuarioApp = "";
        protected string _filUsuario = "";
        protected string _filDominio = "";

        public FNotifBlanqueos()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "NotifBlanqueo";
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
                _filDominio = ((DominioLoginEntity)cbDominio.SelectedItem).Nombre;
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
            TicketNotificacionBlanqueoBusiness business = new TicketNotificacionBlanqueoBusiness();

            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;

            _entities = business.GetAll(fechaDesde, fechaHasta, _filAplicacion, txtFilUsuarioApp.Text, _filDominio, txtFilUsuario.Text);
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
            foreach (TicketNotificacionBlanqueoEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Id.ToString();
                lviArr[i].SubItems.Add(entity.Aplicacion.ToString());
                lviArr[i].SubItems.Add(entity.UsuarioAplicacion);
                lviArr[i].SubItems.Add(entity.UsuarioDominio);
                lviArr[i].SubItems.Add(entity.Usuario);
                lviArr[i].SubItems.Add(entity.Fecha.ToString("dd/MM/yyyy HH:mm"));
                lviArr[i].SubItems.Add(entity.Solicitante);

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
            this._aplicaciones = business.GetAll();

            this._aplicaciones.Insert(0, new AplicacionNotificacionClaveEntity { Id = 0, Nombre = "Todas" });

            cbAplicacion.DataSource = this._aplicaciones;
        }

        private void CargaComboDominios()
        {
            DominioLoginBusiness business = new DominioLoginBusiness();
            this._dominios = business.GetAllParaCombo();

            this._dominios.Insert(0, new DominioLoginEntity { Nombre = "Todos", DireccionAD = "Todos" });

            cbDominio.DataSource = this._dominios;
            cbDominio.DisplayMember = "Nombre";
            cbDominio.ValueMember = "Nombre";
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = Seleccionar(true);

            if (result == DialogResult.OK)
            {
                ExecEntitiesRefresh();
            }
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

            TicketNotificacionBlanqueoEntity ticket = lvLista.SelectedItems[0].Tag as TicketNotificacionBlanqueoEntity;

            if (ticket != null)
            {
                string debug = string.Empty;
                bool envio = new TicketNotificacionBlanqueoBusiness().EnviarEmail(ticket, out debug);

                if (!envio && !string.IsNullOrEmpty(debug))
                {
                    log.Info(debug);
                }

                if (envio)
                {
                    MessageBox.Show("El mensaje fue reenviado con éxito");
                }
            }

        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMNotifBlanqueo form = new FABMNotifBlanqueo(0, false, FABMNotifBlanqueo.FormType.New);

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
            
            TicketNotificacionBlanqueoEntity ticket = lvLista.SelectedItems[0].Tag as TicketNotificacionBlanqueoEntity;

            FABMNotifBlanqueo form = new FABMNotifBlanqueo(ticket.Id, !edit, FABMNotifBlanqueo.FormType.View);

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

    }

}

