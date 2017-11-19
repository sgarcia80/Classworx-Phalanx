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
    public partial class FABMAplicativoBPM : PhalanxAdmin.FModalBase
    {
        AplicacionNotificacionClaveEntity _entity = new AplicacionNotificacionClaveEntity();
        
        public FABMAplicativoBPM()
        {
            InitializeComponent();
        }

        public FABMAplicativoBPM(AplicacionNotificacionClaveEntity ancEntity)
            : this()
        {
            _entity = ancEntity;
        }

        private void FABMAplicativoBPM_Load(object sender, EventArgs e)
        {
            this.Title = "Aplicativo BPM";

            txtCodigo.Text = _entity.Codigo;
            txtNombre.Text = _entity.Nombre;
            cbNotificable.Checked = _entity.Notificable;
            cbEmuladores.Checked = _entity.EsEmuladores;
            txtPrefijoUsuario.Text = _entity.PrefijoUsuarioTC;

            MacroBusiness business = new MacroBusiness();
            var macros = business.GetAll();
            macros.Insert(0, new MacroEntity());

            cbMacro.DataSource = macros;

            if (_entity.Macro != null)
            {
                cbMacro.SelectedValue = _entity.Macro.Id;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // grabo DB
            _entity.Notificable = cbNotificable.Checked;
            _entity.EsEmuladores = cbEmuladores.Checked;
            _entity.PrefijoUsuarioTC = txtPrefijoUsuario.Text;

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

            AplicacionNotificacionClaveBusiness ancBusiness = new AplicacionNotificacionClaveBusiness();

            try
            {
                ancBusiness.Update(_entity);

                MessageBox.Show("La operación se ha realizado correctamente", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Hubo un error al guardar los datos", "Aplicativo BPM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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

        private void cbEmuladores_CheckedChanged(object sender, EventArgs e)
        {
            cbMacro.Enabled = cbEmuladores.Checked;
            txtPrefijoUsuario.Enabled = cbEmuladores.Checked;

            if (!cbEmuladores.Checked)
            {
                cbMacro.SelectedIndex = 0;
                txtPrefijoUsuario.Text = string.Empty;
            }

        }
    }
}

