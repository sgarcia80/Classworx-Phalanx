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
            lnkAplicativos.Enabled = UsrBL.AccAdmAplicativos(this.Usuario);
            lnkEqWin.Enabled = UsrBL.AccAdmEqWin(this.Usuario);
            lnkEqUnix.Enabled = UsrBL.AccAdmEqUnix(this.Usuario);
            lnkEqAS400.Enabled = UsrBL.AccAdmEqAS400(this.Usuario);
            lnkBD.Enabled = UsrBL.AccAdmBD(this.Usuario);
            lnkUsuarios.Enabled = UsrBL.AccAdmUsuarios(this.Usuario);
            lnkGrpsSol.Enabled = UsrBL.AccAdmGrpsSolicitudes(this.Usuario);
            lnkGrpsSeguimSol.Enabled = UsrBL.AccAdmGrpsSeguimSolicitudes(this.Usuario);
            linkEqCom.Enabled = UsrBL.AccAdmEqCom(this.Usuario);
            lnkPerfiles.Enabled = UsrBL.AccAdmPerfiles(this.Usuario);
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

