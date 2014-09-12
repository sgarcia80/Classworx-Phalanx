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
    public partial class FABMSupervisor : PhalanxAdmin.FModalBase
    {
        PhxUserSuperiorEntity _entity = new PhxUserSuperiorEntity();
        bool _readOnly = false;
        bool _delete = false;

        public FABMSupervisor()
        {
            InitializeComponent();
        }
        public FABMSupervisor(PhxUserSuperiorEntity SupervE, bool ReadOnly, bool ToDelete)
            : this()
        {
            _entity = SupervE;
            _readOnly = ReadOnly;
            _delete = ToDelete;
        }

        private void FABMSupervisor_Load(object sender, EventArgs e)
        {
            this.Title = "Supervisor";
            // si es visualización
            if (_delete)
            {
                // verificar si puede ser borrado
                if (!(new PhxUserSuperiorBusiness().IsDeleteable(_entity)))
                {
                    lblDelSuperv.Text = "El supervisor no puede ser borrado, está asignado a usuarios";
                    _delete = false;
                }
                    lblDelSuperv.Visible = true;
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
                txtNombre.Text = _entity.Name;
                txtMail.Text = _entity.Mail;
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtNombre.ReadOnly = true;
                    txtMail.ReadOnly = true;

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
                    PhxUserSuperiorBusiness BldBL = new PhxUserSuperiorBusiness();
                    if (BldBL.Delete(_entity))
                    {
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al borrar el Supervisor", "Supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                    return;

                }
            }
            // si es alta o moficiación
            if (txtNombre.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre");
                txtNombre.Focus();
                return;
            }
            if (txtMail.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el e-mail");
                txtMail.Focus();
                return;
            }

            // grabo DB
            _entity.Name = txtNombre.Text.Trim();
            _entity.Mail = txtMail.Text.Trim();

            PhxUserSuperiorBusiness SupBL = new PhxUserSuperiorBusiness();
            int Id = SupBL.Save(_entity);
            if (Id > 0)
            {
                _entity.Id = Id;
            }
            else
            {
                MessageBox.Show("Hubo un error al grabar el Supervisor", "Supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Supervisor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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

