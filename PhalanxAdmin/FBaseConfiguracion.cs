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
        public override string Titulo
        {
            get
            {
                return  GetTitlePath(base.Titulo, "Configuración");
            }
        }

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
            lnkconfigMailsExpPwd.Enabled = UsrBL.AccParamConfigMails(this.Usuario);
            lnkEsquemas.Enabled = UsrBL.PermisoActivacionEsquema(this.Usuario);
            lnkATMs.Enabled = UsrBL.AccParamGrpSeguimATM(this.Usuario);
            lnkWSBPM.Enabled = UsrBL.AccParamConfigWSBPM(this.Usuario);
            lnkWSCOBIS.Enabled = UsrBL.AccParamConfigWSCOBIS(this.Usuario);
            lnkNDC.Enabled = UsrBL.AccParamConfigNDC(this.Usuario);
            
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

        private void lnkWSConectores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigWSConectores());
        }
    }
}

