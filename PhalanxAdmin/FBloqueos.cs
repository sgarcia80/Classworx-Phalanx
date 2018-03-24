using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCBL;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FBloqueos : PhalanxAdmin.FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Bloqueos de Servicios");
            }
        }

        protected BloqueoEntityCollection _entities;

        protected BloqueoBusiness m_BloqueoBus;

        protected int _filServicio = 0;
        protected DateTime? _filFechaDesde = null;
        protected DateTime? _filFechaHasta = null;

        public FBloqueos()
        {
            InitializeComponent();
            m_BloqueoBus = new BloqueoBusiness();

            cwxSorter sorter = new cwxSorter();
            sorter.Column = colFechaInicio.Index;
            sorter.Order = SortOrder.Descending;
            lvLista.ListViewItemSorter = sorter;
        }

        private void FDominios_Load(object sender, EventArgs e)
        {
            BloqueoEntityCollection servicios = m_BloqueoBus.GetBloqueos();

            this.cbServicio.DataSource = servicios;
            this.cbServicio.ValueMember = "Codigo";
            this.cbServicio.DisplayMember = "Descripcion";

            this.cbBloqueo.DataSource = servicios;
            this.cbBloqueo.ValueMember = "Codigo";
            this.cbBloqueo.DisplayMember = "Descripcion";

            CleanFilters();
            this.cbServicio.SelectedValue = (int)BloqueoEntity.TipoBLoqueo.AutogestionCobis;
            this.cbBloqueo.SelectedValue = (int)BloqueoEntity.TipoBLoqueo.AutogestionCobis;

            bool enable = new PhxUserBusiness().AccParamConfigBloqueoSrvRW(this.Usuario);

            gbAdmin.Enabled = enable;

            this.pbDB.Visible = false;
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
        protected void ExecEntitiesRefresh()
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
            this.bwRefreshEntities.RunWorkerAsync();
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
        protected virtual void SetQueryFilters()
        {
            if (cbServicio.SelectedIndex > 0)
            {
                _filServicio = ((BloqueoEntity)cbServicio.SelectedItem).Id;
            }
            else
            {
                _filServicio = 0;
            }

            _filFechaDesde = dtpFechaDesde.Checked ? dtpFechaDesde.Value.Date : (DateTime?)null;
            _filFechaHasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value.Date : (DateTime?)null;
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
        protected virtual void LoadEntities()
        {
            _entities = m_BloqueoBus.GetAll(_filServicio, _filFechaDesde, _filFechaHasta);
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
            foreach (BloqueoEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Descripcion;

                lviArr[i].SubItems.Add(entity.Activo ? "Bloqueado" : "Habilitado");
                lviArr[i].SubItems.Add(entity.FechaInicio.ToString("dd/MM/yyyy HH:mm"));
                lviArr[i].SubItems.Add(entity.FechaFin.HasValue ? entity.FechaFin.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty);
                lviArr[i].SubItems.Add(entity.Usuario);

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
            cbServicio.SelectedValue = 0;

            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaDesde.Checked = false;

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

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            int servicio = (int)cbBloqueo.SelectedValue;

            if (servicio == 0)
            {
                MessageBox.Show("Debe seleccionar un Servicio a bloquear", "Bloqueo de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BloqueoEntityCollection list = m_BloqueoBus.GetBloqueoActivo(servicio);

            if (list.Count > 0)
            {
                MessageBox.Show("El Servicio ya se encuentra bloqueado", "Bloqueo de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BloqueoEntity entity = new BloqueoEntity();
            entity.Codigo = servicio;
            entity.FechaInicio = DateTime.Now;
            entity.Activo = true;
            entity.Usuario = this.Usuario;

            m_BloqueoBus.Save(entity);

            MessageBox.Show("El Servicio ha sido bloqueado correctamente", "Bloqueo de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            int servicio = (int)cbBloqueo.SelectedValue;

            if (servicio == 0)
            {
                MessageBox.Show("Debe seleccionar un Servicio a habilitar", "Habilitación de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            BloqueoEntityCollection list = m_BloqueoBus.GetBloqueoActivo(servicio);

            if (list.Count == 0)
            {
                MessageBox.Show("El Servicio ya se encuentra habilitado", "Habilitación de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BloqueoEntity entity = list[0];
            entity.FechaFin = DateTime.Now;
            entity.Activo = false;
            entity.Usuario = this.Usuario;

            m_BloqueoBus.Save(entity);

            MessageBox.Show("El Servicio ha sido habilitado correctamente", "Habilitación de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

