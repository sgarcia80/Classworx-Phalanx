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
    public partial class FBaseConfiguracionTC : PhalanxAdmin.FBaseSistema
    {
        public FBaseConfiguracionTC()
        {
            InitializeComponent(); 
        }

        private void FBaseConfiguracion_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkMacros.Enabled = UsrBL.AccParamConfigMacros(this.Usuario);
            lnkUsuarioLoginMacro.Enabled = UsrBL.AccParamConfigMacroUsuario(this.Usuario);
            lnkMacroErrores.Enabled = UsrBL.AccParamConfigMacroErrores(this.Usuario);
            lnkMacroClaves.Enabled = UsrBL.AccParamConfigMacroClaves(this.Usuario);
            lnkUsuarioTC.Enabled = UsrBL.AccParamConfigMacroUsuarioTarjeta(this.Usuario);
        }

        private void lnkMacros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FConfigMacros());
        }

        private void lnkUsuarioLoginMacro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMacroUsuarios());
        }

        private void lnkMacroErrores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMacroErrores());
        }

        private void lnkMacroClaves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMacroClaves());
        }

        private void lnkUsuarioTC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FMacroUsuarioTarjeta());
        }
    }
}

