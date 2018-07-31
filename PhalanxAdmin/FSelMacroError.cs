using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCCommon.Entities;
using NDCBL;
using NDCCommon.Collections;
using System.Collections;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FSelMacroError : PhalanxAdmin.FModalBase
    {
        public MacroErrorEntity Error { get; set; }
        private MacroErrorEntityCollection Errores { get; set; }

        public FSelMacroError()
        {
            InitializeComponent();
        }

        private void FSelMacroError_Load(object sender, EventArgs e)
        {
            base.Title = "Seleccionar Error de Macro";

            MacroErrorBusiness business = new MacroErrorBusiness();
            Errores = business.GetAll();

            Errores.Insert(0, new MacroErrorEntity { Id = 0, Descripcion = "Seleccionar una opción" });

            cbError.DataSource = Errores.ToList();
            //cbError.ValueMember = "Id";
            //cbError.DisplayMember = "Descripcion";

            this.Error = null;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;

            if (cbError.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un Error", "Error de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Error = this.Errores[cbError.SelectedIndex];

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}

