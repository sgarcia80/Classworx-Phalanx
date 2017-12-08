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
using NDCCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMMacroUsuario : PhalanxAdmin.FModalBase
    {
        MacroUsuarioEntity _entity = new MacroUsuarioEntity();
        private bool ReadOnly { get; set; }

        public FABMMacroUsuario()
        {
            _entity = new MacroUsuarioEntity();

            InitializeComponent();
        }

        public FABMMacroUsuario(MacroUsuarioEntity ancEntity, bool readOnly)
            : this()
        {
            this.ReadOnly = readOnly;

            _entity = ancEntity;
        }

        private void FABMMacroUsuario_Load(object sender, EventArgs e)
        {
            this.Title = "Usuario Login de Macro";

            CargarMacros();
            CargarDominios();

            txtUsuarioRed.Text = _entity.UsuarioRed;
            txtUsuario.Text = _entity.UsuarioTC;
            chkPrincipal.Checked = _entity.Principal;
            chkActivo.Checked = _entity.Activo;

            if (_entity.Id > 0)
            {
                txtClave.Text = new phxCryptMgr.CCryptMgr().decryptAndClearBadChars(_entity.ClaveTC);
            }
            else
            {
                chkActivo.Checked = true;
            }

            if (_entity.Macro != null)
            {
                cbMacro.SelectedValue = _entity.Macro.Id;
            }
            if (_entity.Dominio != null)
            {
                cbDominio.SelectedValue = _entity.Dominio.Id;
            }

            if (this.ReadOnly)
            {
                txtClave.ReadOnly = true;
                txtUsuario.ReadOnly = true;
                txtUsuarioRed.ReadOnly = true;
                cbDominio.Enabled = false;
                cbMacro.Enabled = false;
                chkPrincipal.Enabled = false;
                chkActivo.Enabled = false;

                //cbVisualizar.Enabled = false;
                btnCancelar.Visible = false;
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

            if (cbDominio.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDominio.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsuarioRed.Text.Trim()))
            {
                MessageBox.Show("Debe introducir un Usuario de Red", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuarioRed.Focus();
                return;
            }
            if (cbMacro.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar una Macro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMacro.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                MessageBox.Show("Debe introducir un Usuario Login para la Macro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                MessageBox.Show("Debe introducir un Clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuarioRed.Focus();
                return;
            }

            // grabo DB
            _entity.UsuarioRed = txtUsuarioRed.Text.Trim();
            _entity.UsuarioTC = txtUsuario.Text.Trim();
            _entity.ClaveTC = new phxCryptMgr.CCryptMgr().encrypt(txtClave.Text.Trim());
            _entity.Principal = chkPrincipal.Checked;
            _entity.Activo = chkActivo.Checked;

            if (cbMacro.SelectedIndex == 0)
            {
                _entity.Macro = null;
            }
            else
            {
                MacroBusiness business = new MacroBusiness();
                MacroEntity macro = business.Load((int)cbMacro.SelectedValue);
                _entity.Macro = macro;
            }

            _entity.Dominio = null;
            if (cbDominio.SelectedIndex > 0)
            {
                WinDomainBusiness business = new WinDomainBusiness();
                WinDomainEntityCollection dominios = business.GetById((int)cbDominio.SelectedValue);
                if (dominios.Count > 0)
                {
                    _entity.Dominio = dominios[0];
                }
            }

            MacroUsuarioBusiness ancBusiness = new MacroUsuarioBusiness();

            try
            {
                MacroUsuarioEntityCollection list = ancBusiness.GetAll(_entity.Macro.Id, _entity.Principal, true);
                bool existe = false;

                if (list.Count > 0)
                {
                    if (list.Count == 1)
                    {
                        existe = (list[0].Id != _entity.Id);
                    }
                    else
                    {
                        existe = true;
                    }
                }

                if (existe)
                {
                    string mensaje = string.Empty;

                    if (_entity.Principal)
                    {
                        mensaje = string.Format("Ya existe un Usuario Principal para la Macro '{0}'", _entity.Macro.Name);
                    }
                    else
                    {
                        mensaje = string.Format("Ya existe un Usuario Secundario para la Macro '{0}'", _entity.Macro.Name);
                    }

                    MessageBox.Show(mensaje, "Usuario Login de Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ancBusiness.Save(_entity);

                MessageBox.Show("La operación se ha realizado correctamente", "Usuario Login de Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Hubo un error al guardar los datos", "Usuario Login de Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Aplicativo BPM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                DialogResult = DialogResult.None;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void cbVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVisualizar.Checked)
            {
                txtClave.PasswordChar = new char();
            }
            else
            {
                txtClave.PasswordChar = '*';
            }

            txtClave.Refresh();
        }

        private void CargarMacros()
        {
            MacroBusiness business = new MacroBusiness();
            var macros = business.GetAll();
            macros.Insert(0, new MacroEntity());

            cbMacro.DataSource = macros;
        }

        private void CargarDominios()
        {
            WinDomainBusiness business = new WinDomainBusiness();
            var list = business.GetAll();
            list.Insert(0, new WinDomainEntity());

            cbDominio.DataSource = list;
        }
    }
}

