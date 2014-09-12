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

namespace PhalanxAdmin
{
    public partial class FSelectUser : PhalanxAdmin.FBaseSelect
    {
        public FSelectUser()
        {
            InitializeComponent();
        }
        UserTypeEntity _ambiente;

        private void FSelectUser_Load(object sender, EventArgs e)
        {
            cbAmbiente.DataSource = new UserTypeBusiness().GetAll();
        }
        protected override void LoadEntities()
        {
            this._entities = new VwInventarioBusiness().GetAll(txtFilNombre.Text, _ambiente);
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (VwInventarioEntity PwdEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = PwdEnt.Usuario;
                string strEstado = "Inactivo";
                if (PwdEnt.Activo)
                {
                    strEstado = "Activo";
                }
                lviArr[i].SubItems.Add(strEstado);
                lviArr[i].Tag = PwdEnt;
                i++;
            }
            return lviArr;
        }
        protected override void CleanFilters()
        {
            
            base.CleanFilters();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedItems.Count == 1)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

        }

        protected override void SetQueryFilters()
        {
            _ambiente = (UserTypeEntity)cbAmbiente.SelectedItem;
        }
    }
}

