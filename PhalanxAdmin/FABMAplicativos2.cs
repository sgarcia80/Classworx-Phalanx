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
    public partial class FABMAplicativos2 : PhalanxAdmin.FModalBase
    {
        ApplicationEntity _entity = new ApplicationEntity();
        bool _readOnly = false;

        public FABMAplicativos2()
        {
            InitializeComponent();
        }
        public FABMAplicativos2(ApplicationEntity Application, bool ReadOnly)
            : this()
        {
            _entity = Application;
            _readOnly = ReadOnly;
        }

        private void FABMAplicativos_Load(object sender, EventArgs e)
        {
            base.Text = "Aplicativos";
            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;
            }

            if (_entity.Id == 0)
            {
                // si es uno nuevo

            }
            else
            {
                txtAppName.Text = _entity.Name;
                txtDesc.Text = _entity.Desc;
                txtAppField1.Text = _entity.Field1Desc;
                txtAppField2.Text = _entity.Field2Desc;
                txtAppField3.Text = _entity.Field3Desc;
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
            _entity.Name = txtAppName.Text;
            _entity.Desc = txtDesc.Text;
            _entity.Field1Desc = txtAppField1.Text;
            _entity.Field2Desc = txtAppField2.Text;
            _entity.Field3Desc = txtAppField3.Text;

            ApplicationBusiness AppBL = new ApplicationBusiness();
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
}

