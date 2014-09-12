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
    public partial class FABMPerfil : PhalanxAdmin.FModalBase
    {
        PhxRoleEntity _entity = new PhxRoleEntity();
        bool _readOnly = false;
        bool _delete = false;

        public FABMPerfil()
        {
            InitializeComponent();
            CargarGrupos();
            this.Title = "Perfil";
        }
        public FABMPerfil(PhxRoleEntity Role, bool ReadOnly, bool ToDelete)
        {
            _entity = Role;
            _readOnly = ReadOnly;
            _delete = ToDelete;
            InitializeComponent();
            CargarGrupos();
            this.Title = "Perfil";
            if (_entity.Id == 0)
            {
                // si es uno nuevo

            }
            else
            {
                txtNombre.Text = _entity.Name;
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtNombre.ReadOnly = true;
                    lvPermisos.Enabled = false;
                    lvPermisos.BackColor = Color.White;

                }
                else
                {
                }
            }

        }
        void CargarGrupos()
        {
            bool EsModif = (_entity.Id == 0 ? false : true);
            bool ChkPrivilegios = false;
            PhxPrivilegeRoleEntityCollection PrivRolEC = new PhxPrivilegeRoleEntityCollection();
            if (EsModif)
            {
                PrivRolEC = new PhxPrivilegeRoleBusiness().GetAll(_entity);
                if (PrivRolEC.Count > 0)
                {
                    ChkPrivilegios = true;
                }
            }
            lvPermisos.Items.Clear();
            lvPermisos.Groups.Clear();
            PhxPrivilegeGroupBusiness GrpBL = new PhxPrivilegeGroupBusiness();
            PhxPrivilegeGroupEntityCollection Grps = GrpBL.GetAll(true);

            foreach (PhxPrivilegeGroupEntity PriGrp in Grps)
            {
                ListViewGroup lvG = lvPermisos.Groups.Add(PriGrp.Key, PriGrp.Name);
                foreach (PhxPrivilegeEntity Priv in PriGrp.PhxPrivilegeList)
                {
                    ListViewItem LVi = new ListViewItem(lvG);
                    LVi.Text = Priv.Name;
                    LVi.Tag = Priv;
                    // ver si es modificacion del rol, verificar si existe o no el privilegio en el role
                    if (ChkPrivilegios)
                    {
                        if (PrivRolEC.FindPrivilegio(Priv.Key) != null)
                        {
                            LVi.Checked = true;
                        }
                    }
                    lvPermisos.Items.Add(LVi);
                }
            }
            lvPermisos.Refresh();
        }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // si es visualización o delete
            if (_readOnly)
            {
            }
            else
            {
                // si es alta o moficiación
                if (txtNombre.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Debe ingresar el nombre");
                    txtNombre.Focus();
                    return;
                }
                // crea la collection de privilegio a asignar
                PhxPrivilegeEntityCollection PrivEC = new PhxPrivilegeEntityCollection();
                for (int i = 0; i < lvPermisos.CheckedItems.Count; i++)
                {
                    PrivEC.Add((PhxPrivilegeEntity)lvPermisos.CheckedItems[i].Tag);
                }
                PhxRoleBusiness RolBL = new PhxRoleBusiness();
                _entity.Name = txtNombre.Text;
                int Id = RolBL.Save(_entity, PrivEC, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                if (Id == 0)
                {
                    MessageBox.Show("Hubo un error al grabar el Perfil", "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                this.DialogResult = DialogResult.OK;


            }
        }
    }
}

