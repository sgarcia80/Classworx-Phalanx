using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class frmBaseConfigMailing : PhalanxAdmin.frmBaseMaxMdiChilds
    {
        public frmBaseConfigMailing()
        {
            InitializeComponent();
            #region Parte copy paste entre forms y cambia contenido
            //SetFormTitle = "Parametría de Mailing";
            #endregion

            //CwxUserBusiness UsrBL = new CwxUserBusiness();
            //lnkCuentaEnvioMail.Enabled = UsrBL.AccAdmMailsR(base.UserName)
            //    || UsrBL.AccAdmMailsRW(base.UserName);
            //lnkPlantillasMails.Enabled = UsrBL.AccAdmMailsR(base.UserName)
            //    || UsrBL.AccAdmMailsRW(base.UserName);

        }

        private void frmBaseConfigMailing_Load(object sender, EventArgs e)
        {

            

        }

        private void lnkCuentaEnvioMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //((FPrincipal)this.MdiParent).OpenForm<frmConfigCuentaEnvioMail>();
        }

        private void lnkPlantillasMails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //((FPrincipal)this.MdiParent).OpenForm<frmConfigPlantillasMails>();

        }
    }
}
