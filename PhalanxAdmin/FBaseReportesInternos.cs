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
    public partial class FBaseReportesInternos : PhalanxAdmin.FBaseReportes
    {
        public override string Id
        {
            get
            {
                return "FBaseReportesInternos";
            }
        }

        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Internos");
            }
        }

        public FBaseReportesInternos()
        {
            InitializeComponent(); 
        }

        private void FBaseConfiguracion_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            linkListados.Enabled = UsrBL.AccRptLstPwd(this.Usuario);
            lnkABMPerf.Enabled = UsrBL.AccRptABMPerf(this.Usuario);
            lnkAsigPerm.Enabled = UsrBL.AccRptAsigPerm(this.Usuario);
            lnkLstPerfiles.Enabled = UsrBL.AccRptLstPerf(this.Usuario);
            lnkLstTickets.Enabled = UsrBL.AccRptLstTickets(this.Usuario);
            lnkAltaTempRecExt.Enabled = UsrBL.AccRptTicketsRedRecExt(this.Usuario);

            lnkAutogestionCobis.Enabled = UsrBL.AccRptAutogestionCobis(this.Usuario);
            linkMeta4Empleados.Enabled = UsrBL.AccRptEmpleadosMeta4(this.Usuario);
            lnkNotifClaves.Enabled = UsrBL.AccRptNotifAltaPend(this.Usuario);

            linkListadosPwdExp.Visible = UsrBL.AccParamConfigViewPassword(this.Usuario);
        }
        
        private void linkListados_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptListadoDePwd());
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

        private void lnkLstTickets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptTicketsClaves());
        }

        private void lnkAltaTempRecExt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FTicketsAltaTempUsrExt());

        }

        private void lnkNotifClaves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FReporteNotifClaves());
        }

        private void lnkAutogestionCobis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FReporteAutogestion());
        }

        private void linkMeta4Empleados_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMeta4Empleados());
        }

        private void linkListadosPwdExp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FRptListadoDePwdExport());
        }
    }
}

