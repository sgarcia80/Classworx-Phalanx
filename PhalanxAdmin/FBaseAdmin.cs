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
    public partial class FBaseAdmin : PhalanxAdmin.FBasePanel
    {
        public FBaseAdmin()
        {
            InitializeComponent();
        }

        private void lnkDominios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FDominios());

        }

        private void lnkPCs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FPCs());
        }

        private void lnkBD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FBaseDeDatos());

        }

        private void lnkAplicativos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FAplicativos());

        }

        private void lnkEqWin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEquiposWin());

        }

        private void lnkEqUnix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEquiposUnix());

        }

        private void lnkEqAS400_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEquiposAS400());

        }
        private void lnkUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FUsuarios());
        }
        private void lnkGrpsSol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FGrpsSolic());

        }

        private void FBaseAdmin_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAplicativos.Enabled = UsrBL.AccAdmAplicativos(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkEqWin.Enabled = UsrBL.AccAdmEqWin(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkEqUnix.Enabled = UsrBL.AccAdmEqUnix(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkEqAS400.Enabled = UsrBL.AccAdmEqAS400(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkBD.Enabled = UsrBL.AccAdmBD(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkUsuarios.Enabled = UsrBL.AccAdmUsuarios(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkGrpsSol.Enabled = UsrBL.AccAdmGrpsSolicitudes(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkGrpsSeguimSol.Enabled = UsrBL.AccAdmGrpsSeguimSolicitudes(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            linkEqCom.Enabled = UsrBL.AccAdmEqCom(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkPerfiles.Enabled = UsrBL.AccAdmPerfiles(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnk.Enabled = UsrBL.AccAdm(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }

        private void lnkGrpsSeguimSol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FGrpsSeguimSolic());

        }

        private void linkEqCom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FEquiposCom());
        }

        private void lnkPerfiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FPerfiles());
        }



    }
}

