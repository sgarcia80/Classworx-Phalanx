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
    public partial class FEsquemas : PhalanxAdmin.FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Esquemas");
            }
        }

        public FEsquemas()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigEsquemas";
            }
        }

        private void btnChgEsquema_Click(object sender, EventArgs e)
        {
            PhxContingenciaBusiness ContBL = new PhxContingenciaBusiness();
            bool EsquemaActualProd = ContBL.EsAmbienteActualProduccion();
            string CambiarA = (EsquemaActualProd ? "Contingencia" : "Producción");
            if (MessageBox.Show("Se va a activar el esquema de " + CambiarA
                + " y luego se cerrará la aplicación. Desea continuar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ContBL.ActivarEsquema(!EsquemaActualProd);
                MessageBox.Show("Se activó el esquema " + CambiarA + ". La aplicación se cerrará");
                Application.Exit();
                return;

            }
        }

        private void FEsquemas_Load(object sender, EventArgs e)
        {
            PhxContingenciaBusiness ContBL = new PhxContingenciaBusiness();
            txtEsquemaActivo.Text = (ContBL.EsAmbienteActualProduccion() ? "Producción" : "Contingencia");

        }

    }
}

