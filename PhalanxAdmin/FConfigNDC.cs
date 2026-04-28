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
    public partial class FConfigNDC : FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Notificación de Claves");
            }
        }

        public FConfigNDC()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigNDC";
            }
        }

        private void FConfigMailsExpPwd_Load(object sender, EventArgs e)
        {
            CargarComboParams();
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            btnModif.Enabled = UsrBL.AccParamConfigNDCRW(this.Usuario);

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void CargarComboParams()
        {
            cbParams.Items.Clear();
            PhxConfigBusiness ConfigBL = new PhxConfigBusiness();
            PhxConfigEntityCollection ConfEC = ConfigBL.GetNDCParams();
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

            cbValor.Visible = false;
            txtValor.Visible = true;

            PhxConfigBusiness conf = new PhxConfigBusiness();
            if (
                ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.DominiosLoginNDC)
                )
            {
                txtValor.Multiline = true;
                txtValor.Text = ConfEnt.LongTxtValue;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.AutenticacionLoginNDC))
            {
                cbValor.Visible = true;
                txtValor.Visible = false;

                cbValor.SelectedIndex = ConfEnt.ShortTxtValue == "AD" ? 0 : 1;
            }
            else
            {
                txtValor.Multiline = false;
                txtValor.Text = ConfEnt.ShortTxtValue;
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            txtValor.ReadOnly = false;
            txtValor.Focus();
            btnModif.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            cbParams.Enabled = false;
            cbValor.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MostrarInfoConfig();
            txtValor.ReadOnly = true;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;
            cbValor.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // actualizar el selected item del combo con el nuevo valor y grabarlo
            
            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
            if (ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.DominiosLoginNDC))
                ((PhxConfigEntity)cbParams.SelectedItem).LongTxtValue = txtValor.Text;
            else if (ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.AutenticacionLoginNDC))
                ((PhxConfigEntity)cbParams.SelectedItem).ShortTxtValue = cbValor.SelectedIndex == 0 ? "AD" : "WINNT";
            else
                ((PhxConfigEntity)cbParams.SelectedItem).ShortTxtValue = txtValor.Text;

            PhxConfigBusiness ConfBL = new PhxConfigBusiness();
            ConfBL.Save((PhxConfigEntity)cbParams.SelectedItem);

            txtValor.ReadOnly = true;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;
            cbValor.Enabled = false;
        }
    }
}