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
    public partial class FBaseConfiguracion : PhalanxAdmin.FBaseSistema
    {
        public FBaseConfiguracion()
        {
            InitializeComponent(); 
        }

        private void lnkconfigMailsExpPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigMailsExpPwd());

        }

        private void FBaseConfiguracion_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkconfigMailsExpPwd.Enabled = UsrBL.AccParamConfigMails(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkEsquemas.Enabled = UsrBL.PermisoActivacionEsquema(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkATMs.Enabled = UsrBL.AccParamGrpSeguimATM(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkWSBPM.Enabled = UsrBL.AccParamConfigWSBPM(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkWSCOBIS.Enabled = UsrBL.AccParamConfigWSCOBIS(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkNDC.Enabled = UsrBL.AccParamConfigNDC(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }

        private void lnkEsquemas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEsquemas());

        }

        private void lnkATMs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfATMs());
        }

        private void lnkWSBPM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigWSBPM());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigWSCOBIS());
        }

        private void lnkNDC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigNDC());
        }
    }
}

