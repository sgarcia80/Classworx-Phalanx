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
    public partial class FABMBaseDeDatos : PhalanxAdmin.FModalBase
    {
        DataBaseEntity _entity = new DataBaseEntity();
        bool _readOnly = false;
        private bool _estadoOriginal = true;

        public FABMBaseDeDatos()
        {
            InitializeComponent();
        }
        public FABMBaseDeDatos(DataBaseEntity DataBase, bool ReadOnly)
            : this()
        {
            _entity = DataBase;
            _WinPC = _entity.WinPc;
            _UnixPC = _entity.UnixPc;
            if (_WinPC != null)
            {
                txtEquipo.Text = _WinPC.WinDomain.NtName + @"\" + _WinPC.Name;
            }
            else if (_UnixPC != null)
            {
                txtEquipo.Text = _UnixPC.ServerName;
            }
            _estadoOriginal = _entity.Active;
            _readOnly = ReadOnly;
            lvLista.ListViewItemSorter = new cwxSorter(); 
        }

        private void FABMBaseDeDatos_Load(object sender, EventArgs e)
        {
            base.Title = "Base de Datos";
            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;
                // deshabilita cambio de estado
                cBoxActivo.Enabled = false;

            }

            if (_entity.Id == 0)
            {
                CargarComboTipos();
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            }
            else
            {
                txtDBName.Text = _entity.Name;
                txtServerName.Text = _entity.ServerName;
                txtDesc.Text = _entity.Desc;
                txtServerPort.Text = _entity.Port.ToString();
                cBoxActivo.Checked = _entity.Active;
                /*txtIP1.Text = _entity.ServerIp1.ToString();
                txtIP2.Text = _entity.ServerIp2.ToString();
                txtIP3.Text = _entity.ServerIp3.ToString();
                txtIP4.Text = _entity.ServerIp4.ToString();*/
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtDBName.ReadOnly = true;
                    txtServerName.ReadOnly = true;
                    txtDesc.ReadOnly = true;
                    txtServerPort.ReadOnly = true;
                    /*txtIP1.ReadOnly = true;
                    txtIP2.ReadOnly = true;
                    txtIP3.ReadOnly = true;
                    txtIP4.ReadOnly = true;*/

                    TextBox txtDBType = new TextBox();
                    txtDBType.Text = _entity.Type.Name; // cbDBType.Text;
                    txtDBType.Location = cbDBType.Location;
                    txtDBType.ReadOnly = true;
                    txtDBType.Width = cbDBType.Width;
                    txtDBType.Height = cbDBType.Height;
                    this.Controls.Add(txtDBType);
                    cbDBType.Visible = false;

                }
                else
                {
                    CargarComboTipos();
                    cbDBType.SelectedItem = _entity.Type;
                }
                DBRefreshEntites();
            }





        }



        private void CargarComboTipos()
        {
            DatabaseTypeBusiness DBTypeBL = new DatabaseTypeBusiness();
            cbDBType.DataSource = DBTypeBL.GetAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.None;

            // si es visualización sale
            if (_readOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            // si es alta o moficiación
            if (txtDBName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar un Nombre");
                return;
            }

            // grabo DB
            _entity.Name = txtDBName.Text;
            //_entity.ServerName = txtServerName.Text;
            _entity.Desc = txtDesc.Text;
            _entity.Type = (DatabaseTypeEntity)cbDBType.SelectedItem;
            _entity.Active = cBoxActivo.Checked;
            if (_WinPC == null && _UnixPC == null)
            {
                MessageBox.Show("Debe seleccionar el equipo");
                return;
            }
            _entity.WinPc = _WinPC;
            _entity.UnixPc = _UnixPC;
            try
            {
                if (txtServerPort.Text.Trim() != "")
                {
                    int Puerto = Convert.ToInt32(txtServerPort.Text.Trim());
                    if (Puerto < 1 || Puerto > 65534)
                    {
                        throw new Exception();
                    }
                    _entity.Port = Puerto;
                }
                else
                {
                    _entity.Port = null;
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar un Puerto Válido");
                return;
            }
            /*
            // chequea IP
            try
            {
                // si hay algun valor de la IP ingresado
                if (txtIP1.Text.Trim() != "" || txtIP2.Text.Trim() != "" ||
                    txtIP3.Text.Trim() != "" || txtIP4.Text.Trim() != "")
                {
                    // se fija que todos estén ingresados
                    if (txtIP1.Text.Trim() == "" || txtIP2.Text.Trim() == "" ||
                    txtIP3.Text.Trim() == "" || txtIP4.Text.Trim() == "")
                    {
                        throw new Exception();
                    }
                    // chequea que todos sean nros entre 0 y 255
                    int IP1 = Convert.ToInt32(txtIP1.Text.Trim());
                    int IP2 = Convert.ToInt32(txtIP2.Text.Trim());
                    int IP3 = Convert.ToInt32(txtIP3.Text.Trim());
                    int IP4 = Convert.ToInt32(txtIP4.Text.Trim());
                    if (IP1 < 0 || IP1 > 255 || IP2 < 0 || IP2 > 255 ||
                        IP3 < 0 || IP3 > 255 || IP4 < 0 || IP4 > 255)
                    {
                        throw new Exception();
                    }
                    _entity.ServerIp1 = Convert.ToByte(IP1);
                    _entity.ServerIp2 = Convert.ToByte(IP2);
                    _entity.ServerIp3 = Convert.ToByte(IP3);
                    _entity.ServerIp4 = Convert.ToByte(IP4);
                }
                else
                {
                    // no ingreso IP
                    _entity.ServerIp1 = null;
                    _entity.ServerIp2 = null;
                    _entity.ServerIp3 = null;
                    _entity.ServerIp4 = null;

                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar un Puerto Válido");
                this.DialogResult = DialogResult.None;
                return;
            }
             * 
            */
            bool GrabaDB = true;
            if (_entity.Id > 0 && _entity.Active != _estadoOriginal)
            {
                DatabaseUserBusiness DBUBL = new DatabaseUserBusiness();
                DatabaseUserEntityCollection DBUEC = DBUBL.GetDBUsers(_entity);
                if (DBUEC.CountEstado(!cBoxActivo.Checked) > 0)
                {
                    GrabaDB = false;
                    // abre form
                    FEqPwd formActDesPwd = new FEqPwd(_entity, cBoxActivo.Checked);
                    if (formActDesPwd.ShowDialog() == DialogResult.OK)
                    {
                        GrabaDB = true;
                    }
                }
            }
            if (GrabaDB)
            {
                DataBaseBusiness DataBaseBL = new DataBaseBusiness();
                int Id = DataBaseBL.Save(_entity);
                if (Id > 0)
                {
                    _entity.Id = Id;
                    MessageBox.Show("Se grabó la información de la Base de Datos");

                }
                else
                {
                    MessageBox.Show("Hubo un error al grabar la Base de Datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    == DialogResult.No)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

        }
        private WinPCEntity _WinPC;
        private UnixEntity _UnixPC;
        private void btnSelEquipo_Click(object sender, EventArgs e)
        {
            FSelEquipo frmSel = new FSelEquipo();
            if (frmSel.ShowDialog() == DialogResult.OK)
            {
                // setea el equipo de la DB
                if (frmSel.WinPCSelected == null)
                {
                    _WinPC = null;
                }
                else
                {
                    _WinPC = frmSel.WinPCSelected;
                    txtEquipo.Text = _WinPC.WinDomain.NtName + @"\" + _WinPC.Name;
                }
                if (frmSel.UnixPCSelected == null)
                {
                    _UnixPC = null;
                }
                else
                {
                    _UnixPC = frmSel.UnixPCSelected;
                    txtEquipo.Text = _UnixPC.ServerName;
                }
            }
        }

        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;

        }

        DatabaseUserEntityCollection _entities;

        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            DatabaseUserBusiness DBUsrBL = new DatabaseUserBusiness();
            DBUsrBL.SetOrderByFolio();
            DBUsrBL.GetGruposAsignados = true;
            DBUsrBL.FilUsuariosActivos = true;
            DBUsrBL.FilDB = _entity;
            _entities = DBUsrBL.GetAll();
        }
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }

        private void SetLVItems(ListViewItem[] lviArr)
        {
            this.lvLista.Items.Clear();
            if (lviArr.Length > 0)
            {

                this.lvLista.Items.AddRange(lviArr);
            }
        }

        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (DatabaseUserEntity DBUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(DBUsrEnt.Key);
                lviArr[i].SubItems.Add(DBUsrEnt.Username);
                lviArr[i].SubItems.Add(DBUsrEnt.Critical ? "Si" : "No");
                lviArr[i].Text = "";
                lviArr[i].ImageIndex = DBUsrEnt.ActiveUser ? 0 : 1;
                lviArr[i].Tag = DBUsrEnt;
                i++;
            }
            return lviArr;

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
    
    }
}

