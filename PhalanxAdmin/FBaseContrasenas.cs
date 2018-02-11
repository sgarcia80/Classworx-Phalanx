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
    public partial class FBaseContrasenas : PhalanxAdmin.FBasePanel
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Contraseñas");
            }
        }

        public FBaseContrasenas()
        {
            InitializeComponent();
        }

        private void lnkWinPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FWinPwd());

        }

        private void lnkUnixPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FUnixPwd());
        }

        private void lnkDBPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FDBPwd());

        }

        private void lnkAppPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FAppPwd());

        }

        private void lnkAS400Pwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FAS400Pwd());

        }

        private void FBaseContrasenas_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //lnk.Enabled = UsrBL.AccPwd(this.Usuario);
            lnkAppPwd.Enabled = UsrBL.AccPwdApp(this.Usuario);
            lnkAS400Pwd.Enabled = UsrBL.AccPwdAS400(this.Usuario);
            lnkWinPwd.Enabled = UsrBL.AccPwdWin(this.Usuario);
            lnkDBPwd.Enabled = UsrBL.AccPwdBD(this.Usuario);
            lnkUnixPwd.Enabled = UsrBL.AccPwdUnix(this.Usuario);
            lnkChkWin.Enabled = UsrBL.AccChkWinPwd(this.Usuario);
            linkEcPwd.Enabled = UsrBL.AccPwdEqCom(this.Usuario);
            lnkATMPwd.Enabled = UsrBL.AccATM(this.Usuario);
        }

        private void lnkChkWin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FChkWinPwd());
        }

        private void linkEcPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FECPwd());
        }

        private void lnkATMPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FATMPwd());
        }

    }
}

