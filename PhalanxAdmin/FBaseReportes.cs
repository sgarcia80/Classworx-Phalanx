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
        public FBaseReportes()
        {
            InitializeComponent();
        }
        private void linkListados_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FPwdListados());
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
            //lnk.Enabled = UsrBL.AccRpt(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            linkListados.Enabled = UsrBL.AccRptLstPwd(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            linkConingencia.Enabled = UsrBL.AccRptPlanCtrlPwd(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkInventario.Enabled = UsrBL.AccRptInventPwd(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkABMUsr.Enabled = UsrBL.AccRptABMUsr(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAsigPerf.Enabled = UsrBL.AccRptAsigPerf(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkLstUsuarios.Enabled = UsrBL.AccRptLstUsr(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkUsuariosPorPerfil.Enabled = UsrBL.AccRptUsrPorPerf(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkABMPerf.Enabled = UsrBL.AccRptABMPerf(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAsigPerm.Enabled = UsrBL.AccRptAsigPerm(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkLstPerfiles.Enabled = UsrBL.AccRptLstPerf(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkLstTickets.Enabled = UsrBL.AccRptLstTickets(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAltaTempRecExt.Enabled = UsrBL.AccRptTicketsRedRecExt(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
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
    }
}

