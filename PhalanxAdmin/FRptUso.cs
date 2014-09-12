using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FRptUso : Form
    {
        private ReporteDeUsoEntityCollection _rptUsoLst;
        public FRptUso(ReporteDeUsoEntityCollection RptUsoLst)
        {
            //ReporteUsoBindingSource = new BindingSource();
            _rptUsoLst = RptUsoLst;
            InitializeComponent();
        }

        private void FRptUso_Load(object sender, EventArgs e)
        {
            ReporteUsoBindingSource.DataSource = _rptUsoLst;
            reportViewer1.RefreshReport();

        }
    }
}