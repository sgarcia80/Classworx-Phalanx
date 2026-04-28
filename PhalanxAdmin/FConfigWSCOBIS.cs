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

namespace PhalanxAdmin
{
    public partial class FConfigWSCOBIS : FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Webservice de Cobis");
            }
        }

        public FConfigWSCOBIS()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigWSCOBIS";
            }
        }

        private void FConfigMailsExpPwd_Load(object sender, EventArgs e)
        {
            CargarComboParams();
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            btnModif.Enabled = UsrBL.AccParamConfigWSCOBISRW(this.Usuario);

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void CargarComboParams()
        {
            cbParams.Items.Clear();
            PhxConfigBusiness ConfigBL = new PhxConfigBusiness();
            PhxConfigEntityCollection ConfEC = ConfigBL.GetWSCOBISParams();
            cbParams.DataSource = ConfEC;
        }

        private void cbParams_SelectedValueChanged(object sender, EventArgs e)
        {
            MostrarInfoConfig();
        }

        private void MostrarInfoConfig()
        {
            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
            txtDescrip.Text = ConfEnt.Description;
            txtValor.Text = ConfEnt.ShortTxtValue;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            txtValor.ReadOnly = false;
            txtValor.Focus();
            btnModif.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            cbParams.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MostrarInfoConfig();
            txtValor.ReadOnly = true;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // actualizar el selected item del combo con el nuevo valor y grabarlo
            
            ((PhxConfigEntity)cbParams.SelectedItem).ShortTxtValue = txtValor.Text;

            PhxConfigBusiness ConfBL = new PhxConfigBusiness();
            ConfBL.Save((PhxConfigEntity)cbParams.SelectedItem);

            txtValor.ReadOnly = true;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;
        }
    }
}