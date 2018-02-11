using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FPerfiles : PhalanxAdmin.FBaseAdmin
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Perfiles");
            }
        }

        protected PhxRoleEntityCollection _entities;

        public FPerfiles()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "Perfiles";
            }
        }

        private void lvPermisos_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lvPermisos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        /*
        private void lvPermisos_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Clicks != 2 || lvPermisos.GetItemAt(e.X, e.Y) != null)
            {
                return;
            }
            int inc = 0;
            ListViewItem ItmSelec = null;
            while (ItmSelec == null && e.Y + inc < lvPermisos.Size.Height)
            {
                ItmSelec = lvPermisos.GetItemAt(e.X, e.Y + inc);
                inc++;
            }
            if (ItmSelec == null)
            {
                return;
            }
            bool ChkASetear = false;
            for (int i = 0; i < ItmSelec.Group.Items.Count; i++)
            {
                if (lvPermisos.Items[ItmSelec.Group.Items[i].Index].Checked == false)
                {
                    ChkASetear = true;
                    break;
                }
            }
            for (int i = 0; i < ItmSelec.Group.Items.Count; i++)
            {
                lvPermisos.Items[ItmSelec.Group.Items[i].Index].Checked = ChkASetear;
            }


        }
        */
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMPerfil FPerfiles = new FABMPerfil();
            FPerfiles.Title = "Perfil";
            FPerfiles.Usuario = this.Usuario;
            FPerfiles.ShowDialog();
            if (FPerfiles.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }

        }

        private void FPerfiles_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccAdmPerfilesRW(this.Usuario);
            lnkModify.Enabled = UsrBL.AccAdmPerfilesRW(this.Usuario);
            //lnkDelete.Enabled = UsrBL.AccParamSupervisoresRW(this.Usuario);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
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
            /*if (txtFilNombre.Text.Trim() != "")
            {
                _filNombre = txtFilNombre.Text.Trim();
            }
            else
            {
                _filNombre = "";
            }
            if (cbEstado.SelectedIndex < 2)
            {
                _filActivo = (cbEstado.SelectedIndex == 0);
            }
            else
            {
                _filActivo = null;
            }*/

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
            PhxRoleBusiness PxhUsrBL = new PhxRoleBusiness();
            // seteo filtros
            /*if (txtFilNombre.Text.Trim() != "")
            {
                PxhUsrBL.FilNombreGral = txtFilNombre.Text.Trim();
            }
            if (_filActivo != null)
            {
                PxhUsrBL.FilActive = _filActivo;
            }*/
            _entities = PxhUsrBL.GetAll();
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
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (PhxRoleEntity PxhUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = PxhUsrEnt.Name;
                lviArr[i].Tag = PxhUsrEnt;
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

        private void CleanFilters()
        {
            txtFilNombre.Text = "";
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
        private void lvLista_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            lvPermisos.Items.Clear();
            lvGrupos.Items.Clear();
            // a veces cuando cambia el índice entra 1 vez sin selección y después entra de nuevo con selección
            // así me aseguro que cargue cuando hay selección
            if (lvLista.SelectedItems.Count > 0 && lvLista.SelectedItems[0].Index > -1)
            {
                // cargo listview de permisos
                ListViewItem[] lviArr = new ListViewItem[((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxRolesUsersList.Count];
                int i = 0;

                foreach (PhxRoleUserEntity PhxRoleUsrE in ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxRolesUsersList)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].Text = PhxRoleUsrE.PhxRole.Name;
                    lviArr[i].Tag = PhxRoleUsrE;
                    i++;
                }
                lvPermisos.Items.AddRange(lviArr);


                // cargo listview de grupos
                ListViewItem[] lviArrGrp = new ListViewItem[((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList.Count];
                i = 0;

                foreach (PhxUserGroupEntity PhxUsrGrpE in ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList)
                {
                    lviArrGrp[i] = new ListViewItem();
                    lviArrGrp[i].Text = PhxUsrGrpE.RqstGrp.RqstGrpName;
                    lviArrGrp[i].Tag = PhxUsrGrpE;
                    i++;
                }
                lvGrupos.Items.AddRange(lviArrGrp);
            }*/
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                FABMPerfil FABMPerf = new FABMPerfil((PhxRoleEntity)lvLista.SelectedItems[0].Tag, false, false);
                FABMPerf.Usuario = this.Usuario;
                FABMPerf.ShowDialog();
                if (FABMPerf.DialogResult == DialogResult.OK)
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
                FABMPerfil FABMPerf = new FABMPerfil((PhxRoleEntity)lvLista.SelectedItems[0].Tag, true, false);
                FABMPerf.Usuario = this.Usuario;
                FABMPerf.ShowDialog();
            }

        }

    }
}

