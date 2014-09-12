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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // grabo DB
            _entity.Notificable = cbNotificable.Checked;

            AplicacionNotificacionClaveBusiness ancBusiness = new AplicacionNotificacionClaveBusiness();

            try
            {
                ancBusiness.Update(_entity);

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
    }
}

