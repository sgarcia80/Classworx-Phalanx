using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxBL;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FRptInventarioPwd : PhalanxAdmin.FBaseReportes
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Inventario de Claves en Custodia");
            }
        }

        protected WinLocalUserEntityCollection _entities;
        public override string Id
        {
            get
            {
                return "FRptInventarioPwd";
            }
        }
        public FRptInventarioPwd()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            VwInventarioBusiness InventBL = new VwInventarioBusiness();
            bool IncActivas = true;
            bool IncNoActivas = true;
            bool IncCriticas = true;
            bool IncNoCriticas = true;
            if (!rbFilActivasTodas.Checked)
            {
                IncActivas = rbFilActivasSi.Checked;
                IncNoActivas = rbFilActivasNo.Checked;
            }
            if (!rbFilCriticasTodas.Checked)
            {
                IncCriticas = rbFilCriticasSi.Checked;
                IncNoCriticas = rbFilCriticasNo.Checked;
            }

            VwInventarioEntityBindingSource.DataSource = InventBL.GetAll(IncActivas, IncNoActivas, IncCriticas, IncNoCriticas
                , chkAmbWin.Checked, chkAmbUnix.Checked, chkAmbAS400.Checked, chkAmbApp.Checked, chkAmbDB.Checked, chkAmbEC.Checked, chkAmbATM.Checked, rbOrderFolio.Checked);
            reportViewer1.RefreshReport();
        }

        private void FRptInventarioPwd_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                VwInventarioBusiness InventBL = new VwInventarioBusiness();
                bool IncActivas = true;
                bool IncNoActivas = true;
                bool IncCriticas = true;
                bool IncNoCriticas = true;
                if (!rbFilActivasTodas.Checked)
                {
                    IncActivas = rbFilActivasSi.Checked;
                    IncNoActivas = rbFilActivasNo.Checked;
                }
                if (!rbFilCriticasTodas.Checked)
                {
                    IncCriticas = rbFilCriticasSi.Checked;
                    IncNoCriticas = rbFilCriticasNo.Checked;
                }

                VwInventarioEntityCollection Inventario = InventBL.GetAll(IncActivas, IncNoActivas, IncCriticas, IncNoCriticas
                    , chkAmbWin.Checked, chkAmbUnix.Checked, chkAmbAS400.Checked, chkAmbApp.Checked, chkAmbDB.Checked, chkAmbEC.Checked, chkAmbATM.Checked, rbOrderFolio.Checked);
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = "InventarioClaves";
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                sb.Append("Folio" + Separator);
                sb.Append("Ambiente" + Separator);
                sb.Append("Usuario" + Separator);
                sb.Append("Critico" + Separator);
                sb.Append("Estado");
                foreach (VwInventarioEntity Contrasenias in Inventario)
                {
                    sb.AppendLine();
                    sb.Append(Contrasenias.Folio + Separator);
                    sb.Append(Contrasenias.Ambiente + Separator);
                    sb.Append(Contrasenias.Usuario + Separator);
                    if (Contrasenias.Critico)
                    {
                        sb.Append("Si" + Separator);
                    }
                    else
                    {
                        sb.Append("No" + Separator);
                    }
                    if (Contrasenias.Activo)
                    {
                        sb.Append("Activa");
                    }
                    else
                    {
                        sb.Append("Inactiva");
                    }
                }
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
                    sw.Write(sb.ToString());
                    sw.Close();
                MessageBox.Show("La exportación ha sido completada", "Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Exportar()
        {

        }




    }
}

