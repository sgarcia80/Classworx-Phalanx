using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxBL;
using PhalanxCommon.Entities;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FRptUsuariosPorPerfil : PhalanxAdmin.FBaseReportesNormativos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Usuarios por Perfil");
            }
        }

        public override string Id
        {
            get
            {
                return "FRptUsuariosPorPerfil";
            }
        }

        public FRptUsuariosPorPerfil()
        {
            InitializeComponent();
        }

        private void FRptUsuariosPorPerfil_Load(object sender, EventArgs e)
        {
            VwPerfilUsuarioBusiness VwBL = new VwPerfilUsuarioBusiness();
            VwPerfilUsuarioEntityBindingSource.DataSource = VwBL.GetAll();

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                VwPerfilUsuarioBusiness VwBL = new VwPerfilUsuarioBusiness();
                VwPerfilUsuarioEntityCollection Listado = VwBL.GetAllOrdByRole();

                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = "Phalanx Usuarios Por Perfil";
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                sb.Append("Perfil" + Separator);
                sb.Append("Nombre Completo" + Separator);
                sb.Append("ID Usuario" + Separator);
                foreach (VwPerfilUsuarioEntity Registro in Listado)
                {
                    sb.AppendLine();
                    sb.Append(Registro.IndentifRol + Separator);
                    sb.Append(Registro.FullName + Separator);
                    sb.Append(Registro.IndentifUsuario + Separator);
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
    }
}

