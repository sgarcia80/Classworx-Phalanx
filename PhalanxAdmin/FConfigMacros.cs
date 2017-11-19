using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NDCBL;
using NDCCommon.Collections;
using NDCCommon.Entities;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FConfigMacros : FConfiguracionTC
    {
        public MacroEntity Entidad { get; set; }

        public FConfigMacros()
        {
            InitializeComponent();
        }

        public override string Id
        {
            get
            {
                return "FConfigMacros";
            }
        }

        #region Events

        private void FConfigMailsExpPwd_Load(object sender, EventArgs e)
        {
            CargarMacros();
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            bool edit = UsrBL.AccParamConfigMacrosRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkDelete.Enabled = edit;
            lnkModify.Enabled = edit;
            lnkAdd.Enabled = edit;
        }

        private void cbParams_SelectedValueChanged(object sender, EventArgs e)
        {
            MacroEntity entity = ((MacroEntity)cbMacros.SelectedItem);

            if (entity == null)
            {
                Limpiar();
                return;
            }

            this.Entidad = entity;

            VolcarDatos();

            Editar(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MacroEntity entity = this.Entidad;

                entity.Name = txtName.Text;
                entity.Header = txtHeader.Text;
                entity.Body = txtBody.Text;
                entity.Footer = txtFooter.Text;

                MacroBusiness business = new MacroBusiness();

                var list = business.GetAll(entity.Name);
                if (list != null && list.Count > 0)
                {
                    if (list[0].Id != entity.Id)
                    {
                        MessageBox.Show("El Nombre de la Macro ya existe y no puede repetirse", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                business.Save(entity);

                Limpiar();

                CargarMacros();

                MessageBox.Show("La operación se ha realizado correctamente", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la Macro", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkAdd_Click(object sender, EventArgs e)
        {
            cbMacros.SelectedIndex = 0;

            this.Entidad = new MacroEntity();

            VolcarDatos();

            Editar(true);
        }

        private void lnkModify_Click(object sender, EventArgs e)
        {
            if (this.Entidad == null || (this.Entidad != null && this.Entidad.Id == 0))
            {
                MessageBox.Show("Debe seleccionar una Macro para modificar", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnSave.Enabled = true;

            Editar(true);
        }

        private void lnkDelete_Click(object sender, EventArgs e)
        {
            if (this.Entidad == null || (this.Entidad != null && this.Entidad.Id == 0))
            {
                MessageBox.Show("Debe seleccionar una Macro a eliminar", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
         
            string mensaje = string.Format("Se eliminará la Macro '{0}'{1}¿Desea continuar?", this.Entidad.Name, System.Environment.NewLine);

            if (MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    MacroEntity entity = this.Entidad;

                    MacroBusiness business = new MacroBusiness();

                    bool ok = business.Delete(entity);

                    if (ok)
                    {
                        Limpiar();

                        CargarMacros();

                        MessageBox.Show("La Macro ha sido eliminada correctamente", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Macro. Revise que no esté asociada", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la Macro. Revise que no esté asociada", "Macros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdminUsuario1_Click(object sender, EventArgs e)
        {
            AgregarTag(txtHeader, MacroBusiness.HeaderTags.Tag_Admin_Usuario_1);
        }

        private void btnAdminClave1_Click(object sender, EventArgs e)
        {
            AgregarTag(txtHeader, MacroBusiness.HeaderTags.Tag_Admin_Clave_1);
        }

        private void btnAdminUsuario2_Click(object sender, EventArgs e)
        {
            AgregarTag(txtHeader, MacroBusiness.HeaderTags.Tag_Admin_Usuario_2);
        }

        private void btnAdminClave2_Click(object sender, EventArgs e)
        {
            AgregarTag(txtHeader, MacroBusiness.HeaderTags.Tag_Admin_Clave_2);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AgregarTag(txtBody, MacroBusiness.BodyTags.Tag_Usuario);
        }

        private void btnClave_Click(object sender, EventArgs e)
        {
            AgregarTag(txtBody, MacroBusiness.BodyTags.Tag_Clave);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (this.Entidad.Id == 0 && btnSave.Enabled)
            {
                MessageBox.Show("Primero debe guardar la nueva Macro", "Generación de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Entidad.Id == 0 && !btnSave.Enabled)
            {
                MessageBox.Show("Debe seleccioanr una Macro", "Generación de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(txtHeader.Text))
            {
                sb.AppendLine(txtHeader.Text);
            }
            if (!string.IsNullOrEmpty(txtBody.Text))
            {
                sb.AppendLine(txtBody.Text);
            }
            if (!string.IsNullOrEmpty(txtFooter.Text))
            {
                sb.AppendLine(txtFooter.Text);
            }

            string archivo = string.Format("Macro_{0}_{1:yyyyMMdd_HHmm}.txt", txtName.Text.Replace(" ", "_"), DateTime.Now);

            saveFileDialog1.FileName = archivo;
            saveFileDialog1.Filter = "text files (*.txt)|*.txt";
            
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, new UTF8Encoding());
                sw.Write(sb.ToString());
                sw.Close();
                MessageBox.Show("El archivo se ha generado correctamente", "Generación de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Methods

        private void AgregarTag(TextBox textbox, string strTag)
        {
            if (textbox.SelectionStart >= 0)
            {
                int SelStart = textbox.SelectionStart;
                string strValor = textbox.Text.Substring(0, textbox.SelectionStart) + strTag
                    + textbox.Text.Substring(textbox.SelectionStart);
                textbox.Text = strValor;
                textbox.SelectionStart = SelStart + strTag.Length;
                textbox.SelectionLength = 0;
                textbox.Focus();
            }
        }

        private void CargarMacros()
        {
            MacroBusiness business = new MacroBusiness();
            MacroEntityCollection list = business.GetAll();

            list.Insert(0, new MacroEntity());

            cbMacros.DataSource = list;
        }

        private void VolcarDatos()
        {
            txtName.Text = this.Entidad.Name;
            txtHeader.Text = this.Entidad.Header;
            txtBody.Text = this.Entidad.Body;
            txtFooter.Text = this.Entidad.Footer;
        }

        private void Limpiar()
        {
            cbMacros.SelectedIndex = 0;

            this.Entidad = new MacroEntity();

            txtName.Text = string.Empty;
            txtHeader.Text = string.Empty;
            txtBody.Text = string.Empty;
            txtFooter.Text = string.Empty;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void Editar(bool enable)
        {
            btnAdminUsuario1.Enabled = enable;
            btnAdminUsuario2.Enabled = enable;
            btnAdminClave1.Enabled = enable;
            btnAdminClave2.Enabled = enable;

            btnUsuario.Enabled = enable;
            btnClave.Enabled = enable;

            txtName.ReadOnly = !enable;
            txtHeader.ReadOnly = !enable;
            txtBody.ReadOnly = !enable;
            txtFooter.ReadOnly = !enable;

            btnCancel.Enabled = enable;
            btnSave.Enabled = enable;
        }

        #endregion

        private void pnlXPGrps_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}