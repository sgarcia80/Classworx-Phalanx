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
    public partial class FBaseNotifClaves : PhalanxAdmin.FBasePanel
    {
        public FBaseNotifClaves()
        {
            InitializeComponent();
        }

        private void FBaseNotifClaves_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            //linkLabel1.Enabled = UsrBL.AccRptUsrGrpSol(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }

        private void linkNotifBlanqueos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FNotifBlanqueos());
        }
    }
}

