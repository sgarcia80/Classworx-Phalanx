using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxNAL;
//using System.DirectoryServices;

namespace PhalanxAdmin
{
    public partial class FABMUsuarios : PhalanxAdmin.FModalBase
    {
        System.Collections.Hashtable test = new System.Collections.Hashtable();

        PhxUserEntity _entity = new PhxUserEntity();
        bool _readOnly = false;
        public FABMUsuarios()
        {
            InitializeComponent();
        }
        public FABMUsuarios(PhxUserEntity User, bool ReadOnly)
            : this()
        {
            _entity = User;
            _readOnly = ReadOnly;
        }

        private void FABMUsuarios_Load(object sender, EventArgs e)
        {
            base.Title = "Usuario del Sistema";
            CargaComboRelacionesLaborales();
            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;
                // muestra panel de botón aceptar y dockea el panel
                pnlPermisosEdit.Visible = false;
                pnlGruposEdit.Visible = false;
                pnlGuposSegEdit.Visible = false;
            }
            else
            {
                CargarComboEdificios();
                CargarComboDominios();
                CargarComboSuperiores();
            }

            if (_entity.Id == 0)
            {
            }
            else
            {
                txtUserName.Text = _entity.Username;
                txtFullName.Text = _entity.Fullname;
                txtEmail.Text = _entity.Email;
                cbDominio.Text = _entity.Domain;
                chkActivo.Checked = _entity.Active;
                // Agregado MG
                txtLegajo.Text = _entity.FileNumber;
                txtFuncion.Text = _entity.Function;
                if ( _entity.RelationType != null )
                    cboRelacionLaboral.SelectedValue = _entity.RelationType;

                if ( _entity.PhxUserSuperior != null )
                    cbSuperior.SelectedItem = _entity.PhxUserSuperior;

                //entity.RelationType = (cboRelacionLaboral.SelectedIndex >= 0 ? cboRelacionLaboral.SelectedText.Substring(1, 1) : "");
                txtSector.Text = _entity.Branch;
                cboEdificio.Text = _entity.BuildingAdress;
                txtPiso.Text = _entity.BuildingFloor;
                txtInterno.Text = _entity.ExtensionNumber;

                // Agregado MG
                txtLegajo.ReadOnly = _readOnly;
                txtFuncion.ReadOnly = _readOnly;
                cboRelacionLaboral.Enabled = !_readOnly;
                txtSector.ReadOnly = _readOnly;
                cboEdificio.Enabled = !_readOnly;
                txtPiso.ReadOnly = _readOnly;
                txtInterno.ReadOnly = _readOnly;

                if (_readOnly)
                {
                    // hace readonly los campos
                    txtUserName.ReadOnly = true;
                    txtFullName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    TextBox txtDominio = new TextBox();
                    txtDominio.Text = cbDominio.Text;
                    txtDominio.Location = cbDominio.Location;
                    txtDominio.ReadOnly = true;
                    txtDominio.Width = cbDominio.Width;
                    txtDominio.Height = cbDominio.Height;
                    this.tpgDatosUsr.Controls.Add(txtDominio);
                    cbDominio.Visible = false;
                    chkActivo.Enabled = false;
                    // reemplaza combo superior por textbox
                    TextBox txtSuperior = new TextBox();
                    if (_entity.PhxUserSuperior != null)
                    {
                        txtSuperior.Text = _entity.PhxUserSuperior.ToString();
                    }
                    txtSuperior.Location = cbSuperior.Location;
                    txtSuperior.ReadOnly = true;
                    txtSuperior.Width = cbSuperior.Width;
                    txtSuperior.Height = cbSuperior.Height;
                    this.tpgDatosUsr.Controls.Add(txtSuperior);
                    cbSuperior.Visible = false;

					btnCargarDatos.Enabled = false;
                }
            }
            CargarPermisosDelUsuario();
            CargarPermisosDB();
            CargarGruposDelUsuario();
            CargarGruposSeguimDelUsuario();
            CargarGruposDB();
            CargarGruposSeguimDB();
        }
        private void CargarComboEdificios()
        {
            BuildingBusiness WinDomBL = new BuildingBusiness();
            cboEdificio.DataSource = WinDomBL.GetAll();
        }

        private void CargarComboDominios()
        {
            WinDomainBusiness WinDomBL = new WinDomainBusiness();
            cbDominio.DataSource = WinDomBL.GetAll();
        }
        private void CargarComboSuperiores()
        {
            PhxUserSuperiorBusiness SupBL = new PhxUserSuperiorBusiness();
            cbSuperior.DataSource = SupBL.ArmaCombo();
        }

        /// <summary>
        /// Carga el listview de Permisos disponibles para dar al usuario.
        /// Trae todos los permisos de ls BD y solo agrega al LV aquellos que no están
        /// el LV de permisos dados al usuario
        /// </summary>
        private void CargarPermisosDB()
        {
            // traigo todos los roles de la base
            PhxRoleBusiness PhxRoleB = new PhxRoleBusiness();
            PhxRoleEntityCollection DBRoles = PhxRoleB.GetAll();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (PhxRoleEntity RoleEDB in DBRoles)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvPermisosUsr.Items)
                {
                    if (((PhxRoleEntity)lviPermisosUsr.Tag).Id == RoleEDB.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviPermDB = new ListViewItem();
                    lviPermDB.Text = RoleEDB.Name;
                    lviPermDB.Tag = RoleEDB;
                    lvPermisosDB.Items.Add(lviPermDB);
                }
            }

        }

        /// <summary>
        /// Carga el listview de Grupos disponibles para dar al usuario.
        /// Trae todos los Grupos de ls BD y solo agrega al LV aquellos que no están
        /// el LV de Grupos dados al usuario
        /// </summary>
        private void CargarGruposDB()
        {
            // traigo todos los roles de la base
            RequestGroupBusiness RequestGroupB = new RequestGroupBusiness();
            RequestGroupB.FilActivos = true;
            RequestGroupEntityCollection DBRequestGroups = RequestGroupB.GetAll();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (RequestGroupEntity RequestGroupEDB in DBRequestGroups)
            {
                bool GrupoAsignado = false;
                foreach (ListViewItem lviGruposUsr in lvGruposUsr.Items)
                {
                    if (((RequestGroupEntity)lviGruposUsr.Tag).Id == RequestGroupEDB.Id)
                    {
                        GrupoAsignado = true;
                        break;
                    }
                }
                if (!GrupoAsignado)
                {
                    ListViewItem lviGrpDB = new ListViewItem();
                    lviGrpDB.ImageIndex = RequestGroupEDB.Active ? 0 : 1;
                    lviGrpDB.Text = RequestGroupEDB.RqstGrpName;
                    lviGrpDB.Tag = RequestGroupEDB;
                    lvGruposDB.Items.Add(lviGrpDB);
                }
            }

        }
        private void CargarGruposSeguimDB()
        {
            
            FollowupRequestGroupBusiness RequestGroupB = new FollowupRequestGroupBusiness();
            RequestGroupB.FilActivos = true;
            FollowupRequestGroupEntityCollection DBRequestGroups = RequestGroupB.GetAll();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (FollowupRequestGroupEntity RequestGroupEDB in DBRequestGroups)
            {
                bool GrupoAsignado = false;
                foreach (ListViewItem lviGruposUsr in lvGruposSeguimUsr.Items)
                {
                    if (((FollowupRequestGroupEntity)lviGruposUsr.Tag).Id == RequestGroupEDB.Id)
                    {
                        GrupoAsignado = true;
                        break;
                    }
                }
                if (!GrupoAsignado)
                {
                    ListViewItem lviGrpDB = new ListViewItem();
                    lviGrpDB.ImageIndex = RequestGroupEDB.Active ? 0 : 1;
                    lviGrpDB.Text = RequestGroupEDB.Name;
                    lviGrpDB.Tag = RequestGroupEDB;
                    lvGruposSeguimDB.Items.Add(lviGrpDB);
                }
            }

        }
        private void CargarPermisosDelUsuario()
        {
            lvPermisosUsr.Items.AddRange(GenerarLVItmsPermisos(_entity.PhxRolesUsersList));
        }

        /// <summary>
        /// Genera el array de listviewitems de permisos
        /// </summary>
        /// <param name="LstPermisos">IList de PhxRoleUserEntity de permisos</param>
        /// <returns>array ListViewItem[] para agregar al listview</returns>
        private ListViewItem[] GenerarLVItmsPermisos(System.Collections.IList LstPermisos)
        {
            ListViewItem[] lviArr = new ListViewItem[LstPermisos.Count];
            int i = 0;
            foreach (PhxRoleUserEntity PxhRoleUsrEnt in LstPermisos)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = PxhRoleUsrEnt.PhxRole.Name;
                lviArr[i].Tag = PxhRoleUsrEnt.PhxRole;
                i++;
            }
            return lviArr;
        }
        private void CargarGruposSeguimDelUsuario()
        {
            lvGruposSeguimUsr.Items.AddRange(GenerarLVItmsGruposSeguim(_entity.PhxUsersFollowupGroupsList));
        }

        private void CargarGruposDelUsuario()
        {
            lvGruposUsr.Items.AddRange(GenerarLVItmsGrupos(_entity.PhxUsersGroupsList));
        }
        /// <summary>
        /// Genera el array de listviewitems de grupos
        /// </summary>
        /// <param name="LstPermisos">IList de PhxUserGroupEntity de grupos</param>
        /// <returns>array ListViewItem[] para agregar al listview</returns>
        private ListViewItem[] GenerarLVItmsGrupos(System.Collections.IList LstPermisos)
        {
            ListViewItem[] lviArr = new ListViewItem[LstPermisos.Count];
            int i = 0;
            foreach (PhxUserGroupEntity PxhUsrGrpEnt in LstPermisos)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = PxhUsrGrpEnt.RqstGrp.Active ? 0 : 1;
                lviArr[i].Text = PxhUsrGrpEnt.RqstGrp.RqstGrpName;
                lviArr[i].Tag = PxhUsrGrpEnt.RqstGrp;
                i++;
            }
            return lviArr;
        }
        private ListViewItem[] GenerarLVItmsGruposSeguim(System.Collections.IList LstPermisos)
        {
            ListViewItem[] lviArr = new ListViewItem[LstPermisos.Count];
            int i = 0;
            foreach (FollowupRequestGroupUserEntity PxhUsrGrpEnt in LstPermisos)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = PxhUsrGrpEnt.FollowupRqstGrp.Active ? 0 : 1;
                lviArr[i].Text = PxhUsrGrpEnt.FollowupRqstGrp.Name;
                lviArr[i].Tag = PxhUsrGrpEnt.FollowupRqstGrp;
                i++;
            }
            return lviArr;
        }

        #region Manejo de asignacion de permisos
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            PasarPermisoDeDBaUsr();
        }

        private void PasarPermisoDeDBaUsr()
        {
            if (lvPermisosDB.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrRole = new ListViewItem();
                lviUsrRole.Tag = lvPermisosDB.SelectedItems[0].Tag;
                lviUsrRole.Text = lvPermisosDB.SelectedItems[0].Text;
                lvPermisosUsr.Items.Add(lviUsrRole);
                lvPermisosDB.Items.Remove(lvPermisosDB.SelectedItems[0]);
            }
        }

        private void btnDelRole_Click(object sender, EventArgs e)
        {
            PasarPermisoDeUsraDB();

        }

        private void PasarPermisoDeUsraDB()
        {
            if (lvPermisosUsr.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrRole = new ListViewItem();
                lviUsrRole.Tag = lvPermisosUsr.SelectedItems[0].Tag;
                lviUsrRole.Text = lvPermisosUsr.SelectedItems[0].Text;
                lvPermisosDB.Items.Add(lviUsrRole);
                lvPermisosUsr.Items.Remove(lvPermisosUsr.SelectedItems[0]);
            }
        }

        private void lvPermisosDB_DoubleClick(object sender, EventArgs e)
        {
            PasarPermisoDeDBaUsr();
        }

        private void lvPermisosUsr_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarPermisoDeUsraDB();
            }
        }

        private void btnAddAllRoles_Click(object sender, EventArgs e)
        {
            if (lvPermisosDB.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvPermisosDB.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvPermisosDB.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvPermisosUsr.Items.AddRange(lviArr);
            lvPermisosDB.Items.Clear();

        }

        private void btnDelAllRoles_Click(object sender, EventArgs e)
        {
            if (lvPermisosUsr.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvPermisosUsr.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvPermisosUsr.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvPermisosDB.Items.AddRange(lviArr);
            lvPermisosUsr.Items.Clear();

        }
        #endregion
        #region Manejo de Asignación de Grupos
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            PasarGrupoDeDBaUsr();
        }

        private void PasarGrupoDeDBaUsr()
        {
            if (lvGruposDB.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrGroup = new ListViewItem();
                lviUsrGroup.ImageIndex = lvGruposDB.SelectedItems[0].ImageIndex;
                lviUsrGroup.Tag = lvGruposDB.SelectedItems[0].Tag;
                lviUsrGroup.Text = lvGruposDB.SelectedItems[0].Text;
                lvGruposUsr.Items.Add(lviUsrGroup);
                lvGruposDB.Items.Remove(lvGruposDB.SelectedItems[0]);
            }
        }

        private void lvGruposDB_DoubleClick(object sender, EventArgs e)
        {
            PasarGrupoDeDBaUsr();

        }

        private void lvGruposUsr_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarGrupoDeUsraDB();
            }
        }

        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            PasarGrupoDeUsraDB();
        }

        private void PasarGrupoDeUsraDB()
        {
            if (lvGruposUsr.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrGroup = new ListViewItem();
                lviUsrGroup.ImageIndex = lvGruposUsr.SelectedItems[0].ImageIndex;
                lviUsrGroup.Tag = lvGruposUsr.SelectedItems[0].Tag;
                lviUsrGroup.Text = lvGruposUsr.SelectedItems[0].Text;
                lvGruposDB.Items.Add(lviUsrGroup);
                lvGruposUsr.Items.Remove(lvGruposUsr.SelectedItems[0]);
            }
        }

        private void btnAddAllGroups_Click(object sender, EventArgs e)
        {
            if (lvGruposDB.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvGruposDB.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvGruposDB.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = lviUsrRole.ImageIndex;
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvGruposUsr.Items.AddRange(lviArr);
            lvGruposDB.Items.Clear();

        }

        private void btnDelAllGroups_Click(object sender, EventArgs e)
        {
            if (lvGruposUsr.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvGruposUsr.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvGruposUsr.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = lviUsrRole.ImageIndex;
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvGruposDB.Items.AddRange(lviArr);
            lvGruposUsr.Items.Clear();

        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            // si es visualización sale
            if (_readOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre de usuario", "Usuarios del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre completo", "Usuarios del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return;
            }
            if (cbDominio.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el dominio", "Usuarios del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDominio.Focus();
                return;
            }
            // si es alta o moficiación
            // grabo al usuario
            _entity.Username = txtUserName.Text;
            _entity.Fullname = txtFullName.Text;
            _entity.Domain = cbDominio.Text;
            _entity.Email = txtEmail.Text;
            _entity.Active = chkActivo.Checked;

            _entity.FileNumber = txtLegajo.Text;
            _entity.Function = txtFuncion.Text;
            _entity.RelationType = ( cboRelacionLaboral.SelectedValue != null 
                ? cboRelacionLaboral.SelectedValue.ToString()
                : null );
            _entity.Branch = txtSector.Text;
            
            _entity.PhxUserSuperior = ( cbSuperior.SelectedIndex > 0
                ? (PhxUserSuperiorEntity)cbSuperior.SelectedItem
                : null );
            _entity.BuildingAdress = cboEdificio.Text;
            _entity.BuildingFloor = txtPiso.Text;
            _entity.ExtensionNumber = txtInterno.Text;

            PhxUserBusiness PhxUserBL = new PhxUserBusiness();
            _entity.Id = PhxUserBL.Save(_entity, System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            // grabo permisos
            PhxRoleEntityCollection UsrRoles = new PhxRoleEntityCollection();
            foreach (ListViewItem lviUsrRole in lvPermisosUsr.Items)
            {
                UsrRoles.Add((PhxRoleEntity)lviUsrRole.Tag);
            }
            PhxUserBL.SetRoles(_entity, UsrRoles, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            // grabo grupos
            RequestGroupEntityCollection UsrGroups = new RequestGroupEntityCollection();
            foreach (ListViewItem lviUsrGroup in lvGruposUsr.Items)
            {
                UsrGroups.Add((RequestGroupEntity)lviUsrGroup.Tag);
            }
            PhxUserBL.SetGrupos(_entity, UsrGroups);
            // grabo grupos seguimiento
            FollowupRequestGroupEntityCollection UsrGroupsSeguim = new FollowupRequestGroupEntityCollection();
            
            foreach (ListViewItem lviUsrGroup in lvGruposSeguimUsr.Items)
            {
                UsrGroupsSeguim.Add((FollowupRequestGroupEntity)lviUsrGroup.Tag);
            }
            PhxUserBL.SetGruposSeguim(_entity, UsrGroupsSeguim);
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Usuario del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.No)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /*
        private int GetRelacionLaboralItem(string key)
        {
            lock (cboRelacionLaboral.Items)
            {
                for ( int i =0;i<cboRelacionLaboral.Items.Count;i++)
                {
                    if ( 
                }
            }
        }
        */

        private void CargaComboRelacionesLaborales()
        {
            ArrayList items = new ArrayList();
            items.Add(new RelacionLaboralItem("I", "Interno"));
            items.Add(new RelacionLaboralItem("E", "Externo"));
            items.Add(new RelacionLaboralItem("P", "Proveedor"));

            cboRelacionLaboral.DisplayMember = "Value";
            cboRelacionLaboral.ValueMember = "Key";
            cboRelacionLaboral.DataSource = items;

            cboRelacionLaboral.SelectedIndex = -1;
        }

        class RelacionLaboralItem
        {
            string mKey = "";
            string mValue = "";
            public RelacionLaboralItem(string key, string value)
            {
                mKey = key;
                mValue = value;
            }
            public String Key
            {
                get { return mKey; }
            }
            public String Value
            {
                get { return mValue; }
            }
            public override string ToString()
            {
                return mValue;
            }

        }

        private void cboRelacionLaboral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                cboRelacionLaboral.SelectedIndex = -1;
            }

        }

        private void btnAddGroupSeguim_Click(object sender, EventArgs e)
        {
            PasarGrupoSeguimDeDBaUsr();

        }
        private void PasarGrupoSeguimDeDBaUsr()
        {
            if (lvGruposSeguimDB.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrGroup = new ListViewItem();
                lviUsrGroup.ImageIndex = lvGruposSeguimDB.SelectedItems[0].ImageIndex;
                lviUsrGroup.Tag = lvGruposSeguimDB.SelectedItems[0].Tag;
                lviUsrGroup.Text = lvGruposSeguimDB.SelectedItems[0].Text;
                lvGruposSeguimUsr.Items.Add(lviUsrGroup);
                lvGruposSeguimDB.Items.Remove(lvGruposSeguimDB.SelectedItems[0]);
            }
        }

        private void btnAddAllGroupsSeguim_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimDB.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvGruposSeguimDB.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvGruposSeguimDB.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = lviUsrRole.ImageIndex;
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvGruposSeguimUsr.Items.AddRange(lviArr);
            lvGruposSeguimDB.Items.Clear();

        }

        private void btnDelAllGroupsSeguim_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimUsr.Items.Count == 0)
            {
                return;
            }
            ListViewItem[] lviArr = new ListViewItem[lvGruposSeguimUsr.Items.Count];
            int i = 0;
            foreach (ListViewItem lviUsrRole in lvGruposSeguimUsr.Items)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].ImageIndex = lviUsrRole.ImageIndex;
                lviArr[i].Text = lviUsrRole.Text;
                lviArr[i].Tag = lviUsrRole.Tag;
                i++;
            }
            lvGruposSeguimDB.Items.AddRange(lviArr);
            lvGruposSeguimUsr.Items.Clear();

        }

        private void btnDelGroupSeguim_Click(object sender, EventArgs e)
        {
            PasarGrupoSeguimDeUsraDB();

        }
        private void PasarGrupoSeguimDeUsraDB()
        {
            if (lvGruposSeguimUsr.SelectedItems.Count == 1)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviUsrGroup = new ListViewItem();
                lviUsrGroup.ImageIndex = lvGruposSeguimUsr.SelectedItems[0].ImageIndex;
                lviUsrGroup.Tag = lvGruposSeguimUsr.SelectedItems[0].Tag;
                lviUsrGroup.Text = lvGruposSeguimUsr.SelectedItems[0].Text;
                lvGruposSeguimDB.Items.Add(lviUsrGroup);
                lvGruposSeguimUsr.Items.Remove(lvGruposSeguimUsr.SelectedItems[0]);
            }
        }

        private void lvGruposSeguimDB_DoubleClick(object sender, EventArgs e)
        {
            PasarGrupoSeguimDeDBaUsr();

        }

        private void lvGruposSeguimUsr_DoubleClick(object sender, EventArgs e)
        {
            PasarGrupoSeguimDeUsraDB();
        }

		private void btnCargarDatos_Click(object sender, EventArgs e)
		{
            textBox1.Text = "";
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Se debe ingresar un nombre de usuario", "Carga de datos del usuario desde AD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            string path;
            try
            {
                if ((cbDominio.SelectedItem as WinDomainEntity).LDAPPath == "")
                {
                    MessageBox.Show("Se debe configurar el Path de LDAP para el dominio", "Carga de datos del usuario desde AD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                path = (cbDominio.SelectedItem as WinDomainEntity).LDAPPath;
            }
            catch
            {
                MessageBox.Show("No está configurado el Path del LDAP para el dominio seleccionado");
                return;
            }
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("No está configurado el Path del LDAP para el dominio seleccionado");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            DomainUser usuario = ActiveDirectoryHelper.BuscarUsuarioADPorNombre(path, txtUserName.Text.Trim());
            this.Cursor = Cursors.Default;
            //if (!string.IsNullOrEmpty(usuario.Log))
            if (usuario.Exception)
            {
                textBox1.Text = usuario.Log;
                if (usuario.Found)
                {
                    //MessageBox.Show(usuario.Log, "Se encontró el usuario pero hubo un error.");
                    MessageBox.Show("Se encontró el usuario pero hubo un error.");
                }
                else
                {
                    MessageBox.Show(usuario.Log, "No se encontró el usuario");
                }
            }
            else
            {
                textBox1.Text = usuario.Log;
                if (usuario.Found)
                {
                    txtFullName.Text = usuario.Name + " " + usuario.Surname; // usuario.Properties["givenName"].Value.ToString() + " " + usuario.Properties["sn"].Value.ToString();
                    txtEmail.Text = usuario.email; // usuario.Properties["mail"].Value.ToString();
                    txtSector.Text = usuario.Office;
                    string edificio = usuario.Address; // usuario.Properties["streetAddress"].Value.ToString();

                    cboEdificio.Text = edificio;
                }
                else
                {
                    //MessageBox.Show(usuario.Log, "No se encontró el usuario");
                    MessageBox.Show("No se encontró el usuario");
                }

                //int edificioIndex = cboEdificio.FindStringExact(edificio);

                //if (edificioIndex > 0)
                //    cboEdificio.SelectedIndex = edificioIndex;
            }
		}

    }
}

