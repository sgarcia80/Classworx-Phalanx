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
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Notificaciones");
            }
        }

        public FBaseNotifClaves()
        {
            InitializeComponent();
        }

        private void FBaseNotifClaves_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            linkNotifBlanqueos.Enabled = UsrBL.AccBlanqueoAppRed(this.Usuario);
            linkNotifBlanqueosTC.Enabled = UsrBL.AccBlanqueoTarjeta(this.Usuario);
        }

        private void linkNotifBlanqueos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FNotifBlanqueos());
        }

        private void linkNotifBlanqueosTC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FNotifBlanqueosTC());
        }
    }
}

