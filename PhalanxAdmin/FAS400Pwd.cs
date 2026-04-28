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
using System.Collections;

namespace PhalanxAdmin
{
    public partial class FAS400Pwd : PhalanxAdmin.FBaseContrasenas
    {
        public override string Titulo
        {
            get
            {
                return  GetTitlePath(base.Titulo, "AS400");
            }
        }

		protected IList _entities;
        protected string _filNombre = "";
        protected bool? _filUsuariosActivos;
        private bool? _filUsuariosCriticos;
        private bool? _filAlertaVisual;
        private bool? _filAlertaModif;
        private int _filTipoCuenta;

        public override string Id
        {
            get
            {
                return "AS400Pwd";
            }
        }
        public FAS400Pwd()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

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

            _filTipoCuenta = cbTipoCuenta.SelectedIndex > 0 ? ((UserSubTypeEntity)cbTipoCuenta.SelectedItem).Id : 0;

            //_filAlertaModif = cbAlertaModif.SelectedIndex == 0 ? (bool?)null : (cbAlertaModif.SelectedIndex == 1);
            //_filAlertaVisual = cbAlertaVisual.SelectedIndex == 0 ? (bool?)null : (cbAlertaVisual.SelectedIndex == 1);
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
			AS400UserBusiness AS400UsrBL = new AS400UserBusiness();

			string nombre = null;

			if (txtFilNombre.Text.Trim() != "")
				nombre = txtFilNombre.Text.Trim();

			_entities = AS400UsrBL.GetAll(_filUsuariosCriticos, _filUsuariosActivos, nombre, _filTipoCuenta);
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
			foreach (object[] AS400UsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
				lviArr[i].SubItems.Add(AS400UsrEnt[0].ToString());
				lviArr[i].SubItems.Add(AS400UsrEnt[5].ToString());
				lviArr[i].SubItems.Add(AS400UsrEnt[1].ToString());
				lviArr[i].SubItems.Add(AS400UsrEnt[6].ToString());
				lviArr[i].SubItems.Add((bool)AS400UsrEnt[2] ? "Si" : "No");
				lviArr[i].SubItems.Add(AS400UsrEnt[4].ToString());

                lviArr[i].SubItems.Add(AS400UsrEnt[7].ToString());
                //lviArr[i].SubItems.Add((bool)AS400UsrEnt[8] ? "Si" : "");
                //lviArr[i].SubItems.Add((bool)AS400UsrEnt[9] ? "Si" : "");

                lviArr[i].Text = "";
				lviArr[i].ImageIndex = (bool)AS400UsrEnt[3] ? 0 : 1;
                lviArr[i].Tag = AS400UsrEnt[0].ToString();
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

            //cbAlertaModif.SelectedIndex = 0;
            //cbAlertaVisual.SelectedIndex = 0;
            cbTipoCuenta.SelectedIndex = 0;
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
        private void FAS400Pwd_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccPwdAS400RW(this.Usuario);
            lnkModify.Enabled = UsrBL.AccPwdAS400RW(this.Usuario);
            lnkDelete.Enabled = UsrBL.AccPwdAS400RW(this.Usuario);

            CargaUserSubTypes();

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            this.cboEstado.SelectedIndex = 0;
            this.cbCritico.SelectedIndex = 0;

            //this.cbAlertaModif.SelectedIndex = 0;
            //this.cbAlertaVisual.SelectedIndex = 0;
            this.cbTipoCuenta.SelectedIndex = 0;

            //ExecEntitiesRefresh();
        }
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMAS400UsrPwd UsrPass = new FABMAS400UsrPwd(FABMAS400UsrPwd.FormType.New, this.Usuario);
            UsrPass.Title = "Nuevo Usuario y Contraseña";
            
            if (UsrPass.ShowDialog() == DialogResult.OK)
                ExecEntitiesRefresh();
        }
        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AS400UserEntity currUser = new AS400UserBusiness().Load(Convert.ToInt32(lvLista.SelectedItems[0].Tag.ToString()));
            FABMAS400UsrPwd UsrPass = new FABMAS400UsrPwd(currUser, FABMAS400UsrPwd.FormType.Update, this.Usuario);
            UsrPass.Title = "Modificación de Usuario y Contraseña";
            
            if (UsrPass.ShowDialog() == DialogResult.OK)
                ExecEntitiesRefresh();
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AS400UserEntity currUser = new AS400UserBusiness().Load(Convert.ToInt32(lvLista.SelectedItems[0].Tag.ToString()));
            if (!currUser.ActiveUser)
            {
                MessageBox.Show("El Usuario ya se encuentra desactivado (baja)");
            }
            else
            {
                FABMAS400UsrPwd UsrPass = new FABMAS400UsrPwd(currUser, FABMAS400UsrPwd.FormType.Delete, this.Usuario);
                UsrPass.Title = "Baja de Usuario y Contraseña";

                if (UsrPass.ShowDialog() == DialogResult.OK)
                    ExecEntitiesRefresh();
            }
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AS400UserEntity currUser = new AS400UserBusiness().Load(Convert.ToInt32(lvLista.SelectedItems[0].Tag.ToString()));
            FABMAS400UsrPwd UsrPass = new FABMAS400UsrPwd(currUser, FABMAS400UsrPwd.FormType.View, this.Usuario);
            UsrPass.Title = "Visualización de Usuario y Contraseña";
            
            UsrPass.ShowDialog();
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
                {
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            ((ListView)sender).Sort();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CargaUserSubTypes()
        {
            UserSubTypeBusiness UserSubTypeBL = new UserSubTypeBusiness();

            cbTipoCuenta.DisplayMember = "Desc";
            cbTipoCuenta.ValueMember = "Id";

            cbTipoCuenta.Items.Clear();
            cbTipoCuenta.DataSource = UserSubTypeBL.FillFilter();
        }
    }
}


