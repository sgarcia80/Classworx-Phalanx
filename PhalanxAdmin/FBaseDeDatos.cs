using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FBaseDeDatos : PhalanxAdmin.FBaseAdmin
    {
        protected DataBaseEntityCollection _entities;
        protected string _filNombre = "";
        protected bool? _filUsuariosActivos;
        protected DatabaseTypeEntityCollection _tipo_bd;
        private DatabaseTypeEntity _filTipoBD;
        public override string Id
        {
            get
            {
                return "BasesDeDatos";
            }
        }
        public FBaseDeDatos()
        {
            InitializeComponent();
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
            _filNombre = txtFilNombre.Text.Trim();
            if (cbTipoBD.SelectedIndex > 0)
            {
                _filTipoBD = (DatabaseTypeEntity)cbTipoBD.SelectedItem;
            }
            else
            {
                _filTipoBD = null;
            }

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
            DataBaseBusiness BataBaseBL = new DataBaseBusiness();
            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
            {
                BataBaseBL.FilNombre = txtFilNombre.Text.Trim();
            }

            BataBaseBL.FilTipoDB = _filTipoBD;
            BataBaseBL.FilUsuariosActivos = _filUsuariosActivos;
            _entities = BataBaseBL.GetAll();
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
            foreach (DataBaseEntity DBEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(DBEnt.Type.Name);
                //lviArr[i].SubItems.Add(DBEnt.ServerName);
                lviArr[i].SubItems.Add(DBEnt.PCName);
                lviArr[i].SubItems.Add(DBEnt.Desc);
                /*
                if (WinDomEnt.Categoria == null)
                {
                    lviArr[i].SubItems.Add("");
                }
                else
                {
                    lviArr[i].SubItems.Add(WinDomEnt.Categoria.Categoria);
                }
                if (WinDomEnt.Empresa == null)
                {
                    lviArr[i].SubItems.Add("");
                }
                else
                {
                    lviArr[i].SubItems.Add(WinDomEnt.Empresa.Nombre);
                }*/
                lviArr[i].Text = DBEnt.Name;
                lviArr[i].ImageIndex = DBEnt.Active ? 0 : 1;
                lviArr[i].Tag = DBEnt;
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
            txtFilNombre.Text = "";
            cbTipoBD.SelectedIndex = 0;
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
        private void CargaComboTiposBD()
        {
            DatabaseTypeBusiness DBTypeBL = new DatabaseTypeBusiness();
            //ProvinciaEntityCollection ProvEC
            this._tipo_bd = DBTypeBL.FillFilter();
            cbTipoBD.DataSource = this._tipo_bd;
        }

        private void FBaseDeDatos_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccAdmBDRW(this.Usuario);
            lnkModify.Enabled = UsrBL.AccAdmBDRW(this.Usuario);
            lnkDelete.Enabled = UsrBL.AccAdmBDRW(this.Usuario);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            CargaComboTiposBD();
            ExecEntitiesRefresh();

        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMBaseDeDatos FABMBaseDeDatos = new FABMBaseDeDatos();
            FABMBaseDeDatos.ShowDialog();
            if (FABMBaseDeDatos.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }

        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                FABMBaseDeDatos FABMDataBase = new FABMBaseDeDatos((DataBaseEntity)lvLista.SelectedItems[0].Tag, false);
                FABMDataBase.ShowDialog();
                if (FABMDataBase.DialogResult == DialogResult.OK)
                {
                    this.CleanFilters();
                    this.ExecEntitiesRefresh();
                }
            }

        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                FABMBaseDeDatos FABMDataBase = new FABMBaseDeDatos((DataBaseEntity)lvLista.SelectedItems[0].Tag, true);
                FABMDataBase.ShowDialog();
            }

        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}

