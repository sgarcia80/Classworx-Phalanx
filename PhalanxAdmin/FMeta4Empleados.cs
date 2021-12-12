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
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using Classworx.Common.Trace;

namespace PhalanxAdmin
{
    public partial class FMeta4Empleados : PhalanxAdmin.FBaseReportesInternos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Empleados Meta4");
            }
        }

        protected Meta4LegajoEntityCollection _entities;

        protected string _filNombre = "";
        protected string _filUsuario = "";
        protected string _filApellido = "";
        protected string _filDocumento = "";

        public FMeta4Empleados()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "FMeta4Empleados";
            }
        }

        private void FEquiposWin_Load(object sender, EventArgs e)
        {
            //NDCBL.TicketNotificacionBlanqueoBusiness business = new TicketNotificacionBlanqueoBusiness();
            //lnkAdd.Enabled = UsrBL.AccAdmEqWinRW(this.Usuario);
            //lnkModify.Enabled = UsrBL.AccAdmEqWinRW(this.Usuario);
            //lnkDelete.Enabled = UsrBL.AccAdmEqWinRW(this.Usuario);

            this.lvLista.ListViewItemSorter = new cwxSorter();
            cwxSorter s = (cwxSorter)this.lvLista.ListViewItemSorter;

            this.lnkCancelar.Visible = false;
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
            Meta4LegajoBusiness business = new Meta4LegajoBusiness();

            _entities = business.Search(txtFilUsuario.Text, txtFilNombre.Text, txtFilApellido.Text, txtDocumento.Text, txtLegajo.Text);
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
            foreach (Meta4LegajoEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = string.IsNullOrEmpty(entity.UsuarioRed) ? string.Empty : entity.UsuarioRed;
                lviArr[i].SubItems.Add(entity.Id);
                lviArr[i].SubItems.Add(entity.Nombre);
                lviArr[i].SubItems.Add(entity.Apellido);
                lviArr[i].SubItems.Add(entity.TipoDocumento);
                lviArr[i].SubItems.Add(entity.Documento);
                lviArr[i].SubItems.Add(entity.FechaNacimiento.ToString("dd/MM/yyyy"));
                lviArr[i].SubItems.Add(entity.Calle);
                lviArr[i].SubItems.Add(entity.Numero);
                lviArr[i].SubItems.Add(entity.Piso);
                lviArr[i].SubItems.Add(entity.Departamento);
                lviArr[i].SubItems.Add(entity.EstadoCivil);
                lviArr[i].SubItems.Add(entity.EMail);

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
                TraceHelper.Error(e.Error,"Error en reporte Empleados Meta4.");
                //MessageBox.Show(e.Error.Message);
                this.lblStatus.Text = "Error";
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

        private void CleanFilters()
        {
            txtFilUsuario.Text = "";
            txtFilNombre.Text = "";
            txtFilApellido.Text = "";
            txtLegajo.Text = "";
            txtDocumento.Text = "";
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

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

