using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FUsuarios : PhalanxAdmin.FBaseAdmin
    {
        protected PhxUserEntityCollection _entities;
        protected string _filNombre = "";
        protected Nullable<bool> _filActivo = null;

        public FUsuarios()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "Usuarios";
            }
        }

        private void FUsuarios_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccAdmUsuariosRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkModify.Enabled = UsrBL.AccAdmUsuariosRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkDelete.Enabled = UsrBL.AccAdmUsuariosRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            cbEstado.SelectedIndex = 0; // por defecto se selecciona Activos
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
            if (txtFilNombre.Text.Trim() != "")
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
            PhxUserBusiness PxhUsrBL = new PhxUserBusiness();
            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
            {
                PxhUsrBL.FilNombreGral = txtFilNombre.Text.Trim();
            }
            if (_filActivo != null)
            {
                PxhUsrBL.FilActive = _filActivo;
            }
            _entities = PxhUsrBL.GetAllWithGroupsAndRoles();
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
            foreach (PhxUserEntity PxhUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(PxhUsrEnt.Domain);
                lviArr[i].SubItems.Add(PxhUsrEnt.Fullname);
                lviArr[i].SubItems.Add(PxhUsrEnt.Email);
                lviArr[i].SubItems.Add((PxhUsrEnt.Active ? "Activo" : "Inactivo"));
                lviArr[i].Text = PxhUsrEnt.Username;
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
        {
            lvPermisos.Items.Clear();
            lvGrupos.Items.Clear();
            lvGruposSeguim.Items.Clear();
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
                // solo se dejan los activos

                for (int CantGrp = ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList.Count - 1; CantGrp >= 0; CantGrp--)
                {
                    if (((PhxUserGroupEntity)(((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList[CantGrp])).RqstGrp.Active == false)
                    {
                        ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList.RemoveAt(CantGrp);
                    }
                }
                ListViewItem[] lviArrGrp = new ListViewItem[((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList.Count];
                i = 0;

                foreach (PhxUserGroupEntity PhxUsrGrpE in ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersGroupsList)
                {
                    /// solo muestra los activos
                    lviArrGrp[i] = new ListViewItem();
                    lviArrGrp[i].ImageIndex = PhxUsrGrpE.RqstGrp.Active ? 0 : 1;
                    lviArrGrp[i].Text = PhxUsrGrpE.RqstGrp.RqstGrpName;
                    lviArrGrp[i].Tag = PhxUsrGrpE;
                    i++;
                }
                lvGrupos.Items.AddRange(lviArrGrp);


                for (int CantGrp = ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersFollowupGroupsList.Count - 1; CantGrp >= 0; CantGrp--)
                {
                    if (((FollowupRequestGroupUserEntity)(((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersFollowupGroupsList[CantGrp])).FollowupRqstGrp.Active == false)
                    {
                        ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersFollowupGroupsList.RemoveAt(CantGrp);
                    }
                }

                // cargo listview de grupos de seguimiento
                ListViewItem[] lviArrFollowGrp = new ListViewItem[((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersFollowupGroupsList.Count];
                i = 0;

                foreach (FollowupRequestGroupUserEntity PhxUsrGrpE in ((PhxUserEntity)lvLista.SelectedItems[0].Tag).PhxUsersFollowupGroupsList)
                {

                    /// solo muestra los activos
                    lviArrFollowGrp[i] = new ListViewItem();
                    lviArrFollowGrp[i].ImageIndex = PhxUsrGrpE.FollowupRqstGrp.Active ? 0 : 1;
                    lviArrFollowGrp[i].Text = PhxUsrGrpE.FollowupRqstGrp.Name;
                    lviArrFollowGrp[i].Tag = PhxUsrGrpE;
                    i++;

                }
                lvGruposSeguim.Items.AddRange(lviArrFollowGrp);
            }
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMUsuarios FABMUsr = new FABMUsuarios();
            FABMUsr.ShowDialog();
            if (FABMUsr.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                FABMUsuarios FABMUsr = new FABMUsuarios((PhxUserEntity)lvLista.SelectedItems[0].Tag, false);
                FABMUsr.ShowDialog();
                if (FABMUsr.DialogResult == DialogResult.OK)
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
                FABMUsuarios FABMUsr = new FABMUsuarios((PhxUserEntity)lvLista.SelectedItems[0].Tag, true);
                FABMUsr.ShowDialog();
            }
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                if (MessageBox.Show("Se va a borrar el usuario. Desea continuar?", "Eliminación de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    if (new PhxUserBusiness().InactivateUser((PhxUserEntity)lvLista.Items[0].Tag, System.Security.Principal.WindowsIdentity.GetCurrent().Name) > 0)
                    {
                        MessageBox.Show("Se eliminó el Usuario", "Eliminación de Usuarios");
                        this.CleanFilters();
                        this.ExecEntitiesRefresh();
                    }
                }
            }

        }

    }
}

