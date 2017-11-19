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
            //lnk.Enabled = UsrBL.AccParam(this.Usuario);
            lnkConfiguracion.Enabled = (UsrBL.AccParamConfigMails(this.Usuario)
                || UsrBL.PermisoActivacionEsquema(this.Usuario));
            lnkEdificios.Enabled = UsrBL.AccParamEdificios(this.Usuario);
            lnkSuperv.Enabled = UsrBL.AccParamSupervisores(this.Usuario);
            lnkDominios.Enabled = UsrBL.AccAdmDominiosWin(this.Usuario);
            lnkAplicativosBPM.Enabled = UsrBL.AccParamAplicativosBMP(this.Usuario);
            lnkSubsidiarias.Enabled = UsrBL.AccParamSubsidiarias(this.Usuario);
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

