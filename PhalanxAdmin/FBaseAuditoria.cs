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
    public partial class FBaseAuditoria : PhalanxAdmin.FBasePanel
    {
        public override string Titulo
        {
            get
            {
                return  GetTitlePath(base.Titulo, "Auditoria");
            }
        }

        public FBaseAuditoria()
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
            ((FPrincipal)this.MdiParent).OpenForm(new FListadoContingencia());
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

        private void FBaseAuditoria_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //lnk.Enabled = UsrBL.AccRpt(this.Usuario);
            lnkLogPwdChg.Enabled = UsrBL.AccRptLogModifPwd(this.Usuario);
            lnkMailsAlert.Enabled = UsrBL.AccRptMailsNotif(this.Usuario);
            lnkHistPwd.Enabled = UsrBL.AccRptHistPwd(this.Usuario);
            lnkLogueos.Enabled = UsrBL.AccRptLogin(this.Usuario);
            lnkDepuracionLogs.Enabled = UsrBL.AccDepuracionLogs(this.Usuario);
            lnkLogVisPwd.Enabled = UsrBL.AccVisualizacionPwdLogs(this.Usuario);
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

        public override string Id
        {
            get
            {
                return "BaseAudit";
            }
        }

        private void lnkHistPwd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkDepuracionLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FDepuracionLogs());
        }

        private void lnkLogVisPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FLogPwdVis());
        }

    }
}

