using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMAplicativos : PhalanxAdmin.FModalBase
    {
        ApplicationEntity _entity = new ApplicationEntity();
        bool _readOnly = false;
        private bool _estadoOriginal = true;

        public FABMAplicativos()
        {
            InitializeComponent();
        }
        public FABMAplicativos(ApplicationEntity ApplicationE, bool ReadOnly)
            : this()
        {
            _entity = ApplicationE;
            _readOnly = ReadOnly;
            lvLista.ListViewItemSorter = new cwxSorter();
        }

        private void FABMAplicativos_Load(object sender, EventArgs e)
        {

            this.Title = "Aplicativos";
            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;
            }

            if (_entity.Id == 0)
            {
                // si es uno nuevo
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            }
            else
            {
                txtAppName.Text = _entity.Name;
                txtDesc.Text = _entity.Desc;
                txtAppField1.Text = _entity.Field1Desc;
                txtAppField2.Text = _entity.Field2Desc;
                txtAppField3.Text = _entity.Field3Desc;
                _estadoOriginal = _entity.Active;
                cBoxActivo.Checked = _entity.Active;
                cBoxDesactivaPwdCierre.Checked = _entity.Desactiva_PWD_Cierre;
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtAppName.ReadOnly = true;
                    txtDesc.ReadOnly = true;
                    txtAppField1.ReadOnly = true;
                    txtAppField2.ReadOnly = true;
                    txtAppField3.ReadOnly = true;

                }
                else
                {
                }
                DBRefreshEntites();
            }
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
            if (txtAppName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar un Nombre");
                return;
            }

            // grabo DB
            _entity.Name = txtAppName.Text.Trim();
            _entity.Desc = txtDesc.Text;
            _entity.Field1Desc = txtAppField1.Text;
            _entity.Field2Desc = txtAppField2.Text;
            _entity.Field3Desc = txtAppField3.Text;
            _entity.Active = cBoxActivo.Checked;
            _entity.Desactiva_PWD_Cierre = cBoxDesactivaPwdCierre.Checked;

            ApplicationBusiness AppBL = new ApplicationBusiness();
            if (AppBL.Exists(_entity.Name, _entity.Id))
            {
                MessageBox.Show("La aplicación ya existe");
                return;

            }
            bool GrabaDB = true;
            if (_entity.Id > 0 && _entity.Active != _estadoOriginal)
            {
                ApplicationUserBusiness AppUBL = new ApplicationUserBusiness();
                ApplicationUserEntityCollection DBUEC = AppUBL.GetAppUsers(_entity);
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

                int Id = AppBL.Save(_entity);
                if (Id > 0)
                {
                    _entity.Id = Id;
                }
                else
                {
                    MessageBox.Show("Hubo un error al grabar el Aplicativo", "Aplicativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Aplicativos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    == DialogResult.No)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

        }

        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;

        }

        ApplicationUserEntityCollection _entities;

        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            ApplicationUserBusiness UsrBL = new ApplicationUserBusiness();
            UsrBL.SetOrderByFolio();
            UsrBL.GetGruposAsignados = true;
            UsrBL.FilUsuariosActivos = true;
            UsrBL.FilApplication = _entity;
            _entities = UsrBL.GetAll();
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
            foreach (ApplicationUserEntity UsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(UsrEnt.Key);
                lviArr[i].SubItems.Add(UsrEnt.Username);
                lviArr[i].SubItems.Add(UsrEnt.Critical ? "Si" : "No");
                lviArr[i].Text = "";
                lviArr[i].ImageIndex = UsrEnt.ActiveUser ? 0 : 1;
                lviArr[i].Tag = UsrEnt;
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

