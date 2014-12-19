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
            //lnk.Enabled = UsrBL.AccPwd(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAppPwd.Enabled = UsrBL.AccPwdApp(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkAS400Pwd.Enabled = UsrBL.AccPwdAS400(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkWinPwd.Enabled = UsrBL.AccPwdWin(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkDBPwd.Enabled = UsrBL.AccPwdBD(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkUnixPwd.Enabled = UsrBL.AccPwdUnix(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            linkEcPwd.Enabled = UsrBL.AccPwdEqCom(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            lnkATMPwd.Enabled = UsrBL.AccATM(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
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

