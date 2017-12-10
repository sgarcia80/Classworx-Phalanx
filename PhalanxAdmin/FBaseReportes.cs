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
    public partial class FBaseReportes : PhalanxAdmin.FBasePanel
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Reportes");
            }
        }

        public FBaseReportes()
        {
            InitializeComponent();
        }
        private void linkListados_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptListadoDePwd());
        }

        private void linkSolicitudes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FSolicitudes());
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

        private void lnkLogPwdChg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FLogPwdChg());

        }

        private void lnkMailsAlert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMailsAlert());

        }

        private void lnkHistPwd_Click(object sender, EventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FHistPwdChg());

        }

        private void lnkLogueos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptLogueos());

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

        private void lnkABMPerf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptABMPerfiles());

        }

        private void lnkAsigPerm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptPermisosPerf());

        }

        private void lnkLstPerfiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptLstPerfiles());

        }

        private void FBaseReportes_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //lnk.Enabled = UsrBL.AccRpt(this.Usuario);
            linkListados.Enabled = UsrBL.AccRptLstPwd(this.Usuario);
            linkConingencia.Enabled = UsrBL.AccRptPlanCtrlPwd(this.Usuario);
            lnkInventario.Enabled = UsrBL.AccRptInventPwd(this.Usuario);
            lnkABMUsr.Enabled = UsrBL.AccRptABMUsr(this.Usuario);
            lnkAsigPerf.Enabled = UsrBL.AccRptAsigPerf(this.Usuario);
            lnkLstUsuarios.Enabled = UsrBL.AccRptLstUsr(this.Usuario);
            lnkUsuariosPorPerfil.Enabled = UsrBL.AccRptUsrPorPerf(this.Usuario);
            lnkABMPerf.Enabled = UsrBL.AccRptABMPerf(this.Usuario);
            lnkAsigPerm.Enabled = UsrBL.AccRptAsigPerm(this.Usuario);
            lnkLstPerfiles.Enabled = UsrBL.AccRptLstPerf(this.Usuario);
            lnkLstTickets.Enabled = UsrBL.AccRptLstTickets(this.Usuario);
            lnkAltaTempRecExt.Enabled = UsrBL.AccRptTicketsRedRecExt(this.Usuario);

            linkLabel1.Enabled = UsrBL.AccRptUsrGrpSol(this.Usuario);
            linkLabel2.Enabled = UsrBL.AccRptUsrGrpSegSol(this.Usuario);
            lnkPwdRqstGrp.Enabled = UsrBL.AccRptPwdGrpSol(this.Usuario);

        }

        private void lnkLstTickets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptTicketsClaves());
        }

        private void lnkUsuariosPorPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptUsuariosPorPerfil());

        }

        private void lnkAltaTempRecExt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FTicketsAltaTempUsrExt());

        }

        private void lnkHistPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void lnkNotifClaves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FReporteNotifClaves());
        }
    }
}

