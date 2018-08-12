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
    public partial class FBaseReportesNormativos : PhalanxAdmin.FBaseReportes
    {
        public override string Id
        {
            get
            {
                return "FBaseReportesNormativos";
            }
        }

        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Normativos");
            }
        }

        public FBaseReportesNormativos()
        {
            InitializeComponent(); 
        }

        private void FBaseConfiguracion_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            linkConingencia.Enabled = UsrBL.AccRptPlanCtrlPwd(this.Usuario);
            lnkInventario.Enabled = UsrBL.AccRptInventPwd(this.Usuario);
            lnkABMUsr.Enabled = UsrBL.AccRptABMUsr(this.Usuario);
            lnkAsigPerf.Enabled = UsrBL.AccRptAsigPerf(this.Usuario);
            lnkLstUsuarios.Enabled = UsrBL.AccRptLstUsr(this.Usuario);
            lnkUsuariosPorPerfil.Enabled = UsrBL.AccRptUsrPorPerf(this.Usuario);

            linkLabel1.Enabled = UsrBL.AccRptUsrGrpSol(this.Usuario);
            linkLabel2.Enabled = UsrBL.AccRptUsrGrpSegSol(this.Usuario);
            lnkPwdRqstGrp.Enabled = UsrBL.AccRptPwdGrpSol(this.Usuario);
        }

        private void linkConingencia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FSolicitudes());

            //((FPrincipal)this.MdiParent).OpenForm(new FListadoContingencia());
        }

        private void linkInventario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptInventarioPwd());

        }

        private void lnkABMUsr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptABMUsuarios());

        }

        private void lnkAsigPerf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptPerfilesUsrs());

        }

        private void lnkLstUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptLstUsuarios());

        }

        private void lnkUsuariosPorPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptUsuariosPorPerfil());

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FUsuariosGrupos());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FUsuariosGruposSeguimiento());
        }

        private void lnkPwdRqstGrp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptClavesGrpSol());
        }
    }
}

