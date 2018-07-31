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
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Reportes");
            }
        }

        public FBaseReportes()
        {
            InitializeComponent();
        }

        private void FBaseReportes_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //linkInternos.Enabled = UsrBL.AccRptLstPwd(this.Usuario);
            //linkNormativos.Enabled = UsrBL.AccRptPlanCtrlPwd(this.Usuario);
        }

        private void linkNormativos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FBaseReportesNormativos());
        }

        private void linkInternos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((FPrincipal)this.MdiParent).OpenForm(new FBaseReportesInternos());
        }
    }
}

