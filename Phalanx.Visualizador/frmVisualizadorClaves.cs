using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using phxCryptMgr;
using System.IO;
using PhalanxAdmin;
using Classworx.Common.Trace;

namespace DesencriptadorContrasenias
{
    public partial class frmVisualizadorClaves : Form
    {
        private string[] _source;
        private string[] _filtrado;
        private string[] _tipos;


        public frmVisualizadorClaves()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            openFileDialog1.Title = "Desencriptar CSV";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                btnDesencriptar.Enabled = false;
                btnFiltrar.Enabled = false;

                string filename = openFileDialog1.FileName;
                txtArchivo.Text = filename;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtArchivo.Text))
                {
                    MessageBox.Show("Debe seleccionar un archivo", "Desencriptar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] contenido = phxCryptAES256.DecryptFile(txtArchivo.Text);

                _source = contenido;

                //MemoryStream stream = new MemoryStream(contenido);

                //byte[] bytearrayinput = new byte[contenido.Length];
                //stream.Read(bytearrayinput, 0, bytearrayinput.Length);

                ////Convert byte[] to string[]
                //var table = (Encoding.Default.GetString(
                //                 bytearrayinput,
                //                 0,
                //                 bytearrayinput.Length - 1)).Split(new string[] { "\r\n", "\r", "\n" },
                //                                             StringSplitOptions.None);


                //string mensaje = string.Format("Se leyeron {0} lineas", contenido.Length);
                //MessageBox.Show(mensaje, "Desencriptar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var items = GenerateLVItems(contenido);
                SetLVItems(items);

                foreach (string tipo in _tipos)
                {
                    checkedListBox1.Items.Add(tipo);
                }

                btnDesencriptar.Enabled = true;
                btnFiltrar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Desencriptar CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ListViewItem[] GenerateLVItems(string[] lineas)
        {
            ListViewItem[] lviArr = new ListViewItem[lineas.Length - 1];
            List<string> tipos = new List<string>();

            int i = 0;
            int cant = 0;

            lblResultados.Text = string.Format("Resultados: {0}", lineas.Length-1);

            string separatorconfig = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            char separator = ' ';
            if (separatorconfig.Length > 0)
            {
                separator = separatorconfig.ToCharArray()[0];
            }

            foreach (string linea in lineas)
            {
                cant++;

                if (cant == 1)
                {
                    //Se saltea la primera linea.
                    continue;
                }

                string[] datos = linea.Split(separator);

                lviArr[i] = new ListViewItem();

                /// hay que armar los items de lo que se traiga de la DB
                lviArr[i].Text = datos[0];

                if (!tipos.Contains(datos[1]))
                {
                    tipos.Add(datos[1]);
                }
                lviArr[i].SubItems.Add(datos[1]);

                lviArr[i].SubItems.Add(datos[2]);
                lviArr[i].SubItems.Add(datos[3]);
                lviArr[i].SubItems.Add(datos[4]);
                lviArr[i].SubItems.Add(datos[5]);
                lviArr[i].Tag = linea;
                i++;
            }

            tipos.Sort();
            _tipos = tipos.ToArray();

            return lviArr;
        }

        private void SetLVItems(ListViewItem[] lviArr)
        {
            this.lvLista.Items.Clear();
            if (lviArr.Length > 0)
            {

                this.lvLista.Items.AddRange(lviArr);
            }
        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
                return;

            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;

            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                else
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            ((ListView)sender).Sort();

        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog1.Filter = "csv files (*.csv)|*.csv";
                openFileDialog1.Title = "Desencriptar CSV";
                DialogResult dr = saveFileDialog1.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    string filename = saveFileDialog1.FileName;
                    txtArchivo.Text = filename;

                    StreamWriter sw = new StreamWriter(filename, false, Encoding.Unicode);

                    foreach (string dato in _filtrado)
                    {
                        if (dato.Trim() != string.Empty)
                        {
                            sb.Append(dato);
                            sb.AppendLine();
                        }
                    }

                    sw.Write(sb.ToString());
                    sw.Close();

                }
            }
            catch (Exception ex)
            {
                TraceHelper.Error(ex, "Error al generar el archivo");
                MessageBox.Show("Error al generar el archivo");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> tipos = new List<string>();
            //this.lvLista.Items.Clear();

            if (checkedListBox1.SelectedItems != null)
            {
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    tipos.Add(item.ToString());
                }
            }

            List<string> contenido = new List<string>();

            string estado = string.Empty;
            if (rbActivo.Checked)
            {
                estado = "Activo";
            }
            if (rbInactivo.Checked)
            {
                estado = "Inactivo";
            }

            string separatorconfig = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            char separator = ' ';
            if (separatorconfig.Length > 0)
            {
                separator = separatorconfig.ToCharArray()[0];
            }

            foreach (string linea in _source)
            {
                string[] datos = linea.Split(separator);

                if (tipos.Count > 0)
                {
                    if (!tipos.Contains(datos[1]))
                    {
                        continue;
                    }
                }
                if (!string.IsNullOrEmpty(estado))
                {
                    if (!datos[4].StartsWith(estado))
                    {
                        continue;
                    }
                }

                contenido.Add(linea);
            }

            _filtrado = contenido.ToArray();

            var items = GenerateLVItems(contenido.ToArray());
            SetLVItems(items);
        }
    }
}
