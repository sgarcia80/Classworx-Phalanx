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
    public partial class FABMMacroClave : PhalanxAdmin.FModalBase
    {
        MacroClaveEntity _entity = new MacroClaveEntity();
        private bool ReadOnly { get; set; }

        public FABMMacroClave()
        {
            _entity = new MacroClaveEntity();

            InitializeComponent();
        }

        public FABMMacroClave(MacroClaveEntity ancEntity, bool readOnly)
            : this()
        {
            this.ReadOnly = readOnly;

            _entity = ancEntity;
        }

        private void FABMMacroClave_Load(object sender, EventArgs e)
        {
            this.Title = "Claves de Usuarios";

            txtClave.Text = _entity.Clave;
            txtClaveEncriptada.Text = _entity.ClaveEncriptada;
            chkActivo.Checked = _entity.Activo;

            if (_entity.Id == 0)
            {
                chkActivo.Checked = true;
            }

            if (this.ReadOnly)
            {
                txtClave.ReadOnly = true;
                txtClaveEncriptada.ReadOnly = true;
                chkActivo.Enabled = false;

                btnCancelar.Visible= false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (this.ReadOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                MessageBox.Show("Debe introducir una Clave sin Encriptar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtClaveEncriptada.Text.Trim()))
            {
                MessageBox.Show("Debe introducir una Clave Encriptada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClaveEncriptada.Focus();
                return;
            }

            // grabo DB
            _entity.Clave = txtClave.Text.Trim();
            _entity.ClaveEncriptada = txtClaveEncriptada.Text.Trim();
            _entity.Activo = chkActivo.Checked;

            MacroClaveBusiness ancBusiness = new MacroClaveBusiness();

            try
            {
                ancBusiness.Save(_entity);

                MessageBox.Show("La operación se ha realizado correctamente", "Clave de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Hubo un error al guardar los datos", "Clave de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                DialogResult = DialogResult.None;
                
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Clave de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                DialogResult = DialogResult.None;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}

