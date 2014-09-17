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
    public partial class FBaseSistema : PhalanxAdmin.FBasePanel
    {
        public FBaseSistema()
        {
            InitializeComponent();
        }


        private void lnkConfiguracion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfiguracion());

        }

        private void FBaseSistema_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //lnk.Enabled = UsrBL.AccParam(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkConfiguracion.Enabled = (UsrBL.AccParamConfigMails(System.Security.Principal.WindowsIdentity.GetCurrent().Name)
                || UsrBL.PermisoActivacionEsquema(System.Security.Principal.WindowsIdentity.GetCurrent().Name));
            lnkEdificios.Enabled = UsrBL.AccParamEdificios(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkSuperv.Enabled = UsrBL.AccParamSupervisores(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkDominios.Enabled = UsrBL.AccAdmDominiosWin(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAplicativosBPM.Enabled = UsrBL.AccParamAplicativosBMP(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkSubsidiarias.Enabled = UsrBL.AccParamSubsidiarias(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }

        private void lnkEdificios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEdificios());

        }

        private void lnkSuperv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FSupervisores());

        }


        private void lnkDominios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FDominios());

        }

        private void lnkAplicativosBPM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FAplicativosBPM());
        }

        private void lnkSubsidiarias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FSubsidiarias());
        }
    }
}

