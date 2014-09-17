using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;
using NDCCommon.Entities;
using NDCBL;

namespace PhalanxAdmin
{
    public partial class FABMSubsidiaria : PhalanxAdmin.FModalBase
    {
        SubsidiariaEntity _entity = new SubsidiariaEntity();
        bool _readOnly = false;
        bool _delete = false;

        public FABMSubsidiaria()
        {
            InitializeComponent();
        }

        public FABMSubsidiaria(SubsidiariaEntity subsidiaria, bool ReadOnly, bool ToDelete)
            : this()
        {
            _entity = subsidiaria;
            _readOnly = ReadOnly;
            _delete = ToDelete;
        }

        private void FABMSubsidiaria_Load(object sender, EventArgs e)
        {
            this.Title = "Subsidiaria";
            // si es visualización
            if (_delete)
                lblDelSubsidiaria.Visible = true;
            
            if (_readOnly && !_delete)
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;

            if (_entity.Id != 0)
            {
                txtCodigo.Text = _entity.Codigo;
                txtNombre.Text = _entity.Nombre;
                txtEmail01.Text = _entity.Email01;
                txtEmail02.Text = _entity.Email02;
                
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtCodigo.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    txtEmail01.ReadOnly = true;
                    txtEmail02.ReadOnly = true;
                }
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            SubsidiariaBusiness subsidiariaBL = new SubsidiariaBusiness();

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
                    if (subsidiariaBL.Delete(_entity))
                        this.DialogResult = DialogResult.OK;
                    else
                    {
                        MessageBox.Show("Hubo un error al borrar", "Subsidiaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        this.DialogResult = DialogResult.None;
                    }
                    
                    return;
                }
            }
            // si es alta o moficiación
            if (txtCodigo.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el código");
                txtCodigo.Focus();
                return;
            }

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el nombre");
                txtNombre.Focus();
                return;
            }

            // grabo DB
            _entity.Codigo = txtCodigo.Text.Trim();
            _entity.Nombre = txtNombre.Text.Trim();
            _entity.Email01 = txtEmail01.Text.Trim();
            _entity.Email02 = txtEmail02.Text.Trim();

            try
            {
                subsidiariaBL.Save(_entity);
            }
            catch
            {
                MessageBox.Show("Hubo un error al grabar", "Subsidiaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Subsidiaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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

