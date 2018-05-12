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
    public partial class FRptLstPerfiles : PhalanxAdmin.FBaseReportesInternos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Listado de Perfiles");
            }
        }

        public override string Id
        {
            get
            {
                return "FRptLstPerfiles";
            }
        }

        public FRptLstPerfiles()
        {
            InitializeComponent();
        }

        private void FRptLstPerfiles_Load(object sender, EventArgs e)
        {
            VwPermisoPerfilBusiness VwBL = new VwPermisoPerfilBusiness();
            VwPermisoPerfilEntityBindingSource.DataSource = VwBL.GetAll();

            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}

