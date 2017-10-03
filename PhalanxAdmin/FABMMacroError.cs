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
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMMacroError : PhalanxAdmin.FModalBase
    {
        MacroErrorEntity _entity = new MacroErrorEntity();
        private bool ReadOnly { get; set; }

        public FABMMacroError()
        {
            _entity = new MacroErrorEntity();

            InitializeComponent();
        }

        public FABMMacroError(MacroErrorEntity ancEntity, bool readOnly)
            : this()
        {
            this.ReadOnly = ReadOnly;

            _entity = ancEntity;
        }

        private void FABMMacroError_Load(object sender, EventArgs e)
        {
            this.Title = "Error de Macro";

            txtDescripcion.Text = _entity.Descripcion;

            if (this.ReadOnly)
            {
                txtDescripcion.ReadOnly = true;

                btnAceptar.Visible = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe introducir una Descripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }

            // grabo DB
            _entity.Descripcion = txtDescripcion.Text.Trim();

            MacroErrorBusiness ancBusiness = new MacroErrorBusiness();

            try
            {
                ancBusiness.Save(_entity);

                MessageBox.Show("La operación se ha realizado correctamente", "Error de Macro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Hubo un error al guardar los datos", "Error de Macro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                DialogResult = DialogResult.None;
                
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Error de Macro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                DialogResult = DialogResult.None;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}

