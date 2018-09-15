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
    public partial class FEquiposCom : PhalanxAdmin.FBaseAdmin
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Equipos de Comunicación");
            }
        }

        protected CommunicationDeviceTypeEntityCollection _tipo_cm;
        protected CommunicationDeviceEntityCollection _entitiesCD;
        protected string _filNombre = "";
        protected CommunicationDeviceTypeEntity _filTipoCD;

        public FEquiposCom()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter(); 
        }
        public override string Id
        {
            get
            {
                return "EqCom";
            }
        }

        private void FEquiposCom_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccAdmEqComRW(this.Usuario);
            lnkModify.Enabled = UsrBL.AccAdmEqComRW(this.Usuario);
            lnkDelete.Enabled = UsrBL.AccAdmEqComRW(this.Usuario);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;

            CargaComboTiposEC();
            
            //ExecEntitiesRefresh();
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

            if (cbTipoEC.SelectedIndex > 0)
                _filTipoCD = (CommunicationDeviceTypeEntity) cbTipoEC.SelectedItem;
            else
                _filTipoCD = null;
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
            CommunicationDeviceBusiness CDBL = new CommunicationDeviceBusiness();
            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
                CDBL.FilNombre = txtFilNombre.Text.Trim();

            CDBL.FilTipoCD = _filTipoCD;

            _entitiesCD = CDBL.GetAll();
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
            lviArr = new ListViewItem[_entitiesCD.Count];
            
            int i = 0;
            
            foreach (CommunicationDeviceEntity CommunicationDeviceEnt in _entitiesCD)
            {
                string desc = string.Empty;

                if (CommunicationDeviceEnt.Description.Length > 25)
                    desc = CommunicationDeviceEnt.Description.Substring(0, 25) + "...";
                else
                    desc = CommunicationDeviceEnt.Description;
                
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(CommunicationDeviceEnt.Type.Name);
                lviArr[i].SubItems.Add(CommunicationDeviceEnt.IP);
                lviArr[i].SubItems.Add(desc);
                lviArr[i].Text = CommunicationDeviceEnt.Name;
                lviArr[i].ImageIndex = CommunicationDeviceEnt.Active ? 0 : 1;
                lviArr[i].Tag = CommunicationDeviceEnt;
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

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMEquiposCom fEditarEC = new FABMEquiposCom((CommunicationDeviceEntity)lvLista.SelectedItems[0].Tag, false);

            fEditarEC.Title = "Modificación de Equipo de Comunicación";

            if (fEditarEC.ShowDialog() == DialogResult.OK)
            {
                ExecEntitiesRefresh();
            }
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMEquiposCom fViewEC = new FABMEquiposCom((CommunicationDeviceEntity)lvLista.SelectedItems[0].Tag, true);
            fViewEC.Title = "Visualización de Equipo de Comunicación";
            fViewEC.ShowDialog();
        }
        
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMEquiposCom fAltaEC = new FABMEquiposCom(new CommunicationDeviceEntity(), false);

            fAltaEC.Title = "Nuevo Equipo de Comunicación";

            if (fAltaEC.ShowDialog() == DialogResult.OK)
                ExecEntitiesRefresh();
        }

        private void CargaComboTiposEC()
        {
            CommunicationDeviceTypeBusiness CDTypeBL = new CommunicationDeviceTypeBusiness();
            _tipo_cm = CDTypeBL.FillFilter();

            cbTipoEC.DataSource = _tipo_cm;
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
    }
}

