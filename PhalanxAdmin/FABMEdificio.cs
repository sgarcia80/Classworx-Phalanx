using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FABMEdificio : PhalanxAdmin.FModalBase
    {
        BuildingEntity _entity = new BuildingEntity();
        bool _readOnly = false;
        bool _delete = false;

        public FABMEdificio()
        {
            InitializeComponent();
        }
        public FABMEdificio(BuildingEntity BuildingE, bool ReadOnly, bool ToDelete)
            : this()
        {
            _entity = BuildingE;
            _readOnly = ReadOnly;
            _delete = ToDelete;
        }

        private void FABMEdificio_Load(object sender, EventArgs e)
        {
            this.Title = "Edificio";
            // si es visualización
            if (_delete)
            {
                lblDelBuilding.Visible = true;
            }
            if (_readOnly && !_delete)
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
                txtDireccion.Text = _entity.Address;
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtDireccion.ReadOnly = true;

                }
                else
                {
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // si es visualización o delete
            if (_readOnly)
            {
                if (!_delete)
                {
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    // hay que borrar
                    BuildingBusiness BldBL = new BuildingBusiness();
                    if (BldBL.Delete(_entity))
                    {
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al borrar el Edificio", "Edificios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                    return;

                }
            }
            // si es alta o moficiación
            if (txtDireccion.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar la dirección");
                return;
            }

            // grabo DB
            _entity.Address = txtDireccion.Text.Trim();

            BuildingBusiness BuildingBL = new BuildingBusiness();
            int Id = BuildingBL.Save(_entity);
            if (Id > 0)
            {
                _entity.Id = Id;
            }
            else
            {
                MessageBox.Show("Hubo un error al grabar el Edificio", "Edificios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Edificios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== DialogResult.No)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

        }

    }
}

