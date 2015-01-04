using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxBL;
using System.Collections;

namespace PhalanxAdmin
{
    public partial class FECPwd : PhalanxAdmin.FBaseContrasenas
    {
        protected IList _entities;
        protected string _filNombre = "";
        private bool? _filUsuariosActivos;
        private bool? _filUsuariosCriticos;
        protected CommunicationDeviceTypeEntityCollection _tipo_ec;
        private CommunicationDeviceTypeEntity _filTipoEC;
        
        public override string Id
        {
            get
            {
                return "ECPwd";
            }
        }
        public FECPwd()
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
                bwRefreshEntities.CancelAsync();
            else
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
        private void SetQueryFilters()
        {
            _filNombre = txtFilNombre.Text.Trim();
            if (cboEstado.SelectedIndex == 0) _filUsuariosActivos = true;
            if (cboEstado.SelectedIndex == 1) _filUsuariosActivos = false;
            if (cboEstado.SelectedIndex == 2) _filUsuariosActivos = null;
            switch (cbCritico.SelectedIndex)
            {
                case 0:
                    _filUsuariosCriticos = null;
                    break;
                case 1:
                    _filUsuariosCriticos = true;
                    break;
                case 2:
                    _filUsuariosCriticos = false;
                    break;
                default:
                    break;
            }

            if (cbTipoEC.SelectedIndex > 0)
                _filTipoEC = (CommunicationDeviceTypeEntity)cbTipoEC.SelectedItem;
            else
                _filTipoEC = null;
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
            CommunicationDeviceUserBusiness CDUsrBL = new CommunicationDeviceUserBusiness();
            // seteo filtros
			string nombre = null;

            if (txtFilNombre.Text.Trim() != "")
                nombre = txtFilNombre.Text.Trim();
			
			_entities = CDUsrBL.GetAll(_filUsuariosCriticos, _filUsuariosActivos, _filTipoEC, nombre);
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
            foreach (object[] ECUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /// 

                lviArr[i].SubItems.Add(ECUsrEnt[0].ToString());
                lviArr[i].SubItems.Add(ECUsrEnt[7].ToString());
                lviArr[i].SubItems.Add(ECUsrEnt[5].ToString());
                lviArr[i].SubItems.Add(ECUsrEnt[1].ToString());
                lviArr[i].SubItems.Add(ECUsrEnt[6].ToString());
                lviArr[i].SubItems.Add((bool)ECUsrEnt[2] ? "Si" : "No");
                lviArr[i].SubItems.Add(ECUsrEnt[4].ToString());

                lviArr[i].Text = "";
                lviArr[i].ImageIndex = (bool)ECUsrEnt[3] ? 0 : 1;
                lviArr[i].Tag = ECUsrEnt[0].ToString();  //ECUsrEnt;
                
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
            cboEstado.SelectedIndex = 0;
            this.cbCritico.SelectedIndex = 0;
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

        private void FDBPwd_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccPwdEqComRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkModify.Enabled = UsrBL.AccPwdEqComRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnkDelete.Enabled = UsrBL.AccPwdEqComRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            this.cboEstado.SelectedIndex = 0;
            this.cbCritico.SelectedIndex = 0;
            CargaComboTiposEC();

            ExecEntitiesRefresh();

        }
        private void CargaComboTiposEC()
        {
            CommunicationDeviceTypeBusiness CDTypeBL = new CommunicationDeviceTypeBusiness();

            _tipo_ec = CDTypeBL.FillFilter();
            cbTipoEC.DataSource = this._tipo_ec;
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMECPwd FABMECPwd = new FABMECPwd(FABMECPwd.FormType.New);
            FABMECPwd.ShowDialog();

            if (FABMECPwd.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                //FABMECPwd FABMCommunicationDevice = new FABMECPwd((CommunicationDeviceUserEntity)lvLista.SelectedItems[0].Tag, false, FABMECPwd.FormType.Update);
                CommunicationDeviceUserEntity currUser = new CommunicationDeviceUserBusiness().Load(Convert.ToInt32(lvLista.SelectedItems[0].Tag.ToString()));
                FABMECPwd FABMCommunicationDevice = new FABMECPwd(currUser, false, FABMECPwd.FormType.Update);
                FABMCommunicationDevice.ShowDialog();

                if (FABMCommunicationDevice.DialogResult == DialogResult.OK)
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
                //FABMECPwd FABMECUsr = new FABMECPwd((CommunicationDeviceUserEntity)lvLista.SelectedItems[0].Tag, true, FABMECPwd.FormType.View);
                CommunicationDeviceUserEntity currUser = new CommunicationDeviceUserBusiness().Load(Convert.ToInt32(lvLista.SelectedItems[0].Tag.ToString()));
                FABMECPwd FABMECUsr = new FABMECPwd(currUser, true, FABMECPwd.FormType.View);
                FABMECUsr.ShowDialog();
            }
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

