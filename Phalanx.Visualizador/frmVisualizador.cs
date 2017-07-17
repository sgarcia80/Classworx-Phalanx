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

namespace DesencriptadorContrasenias
{
    public partial class frmVisualizador : Form
    {
        public frmVisualizador()
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

                string[] contenido = phxCryptAES.DecryptFile(txtArchivo.Text);

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
            ListViewItem[] lviArr = new ListViewItem[lineas.Length-1];

            int i = 0;
            int cant = 0;

            foreach (string linea in lineas)
            {
                cant++;

                if (cant == 1)
                {
                    //Se saltea la primera linea.
                    continue;
                }

                string[] datos = linea.Split(';');

                lviArr[i] = new ListViewItem();

                /// hay que armar los items de lo que se traiga de la DB
                lviArr[i].Text = datos[0];
                lviArr[i].SubItems.Add(datos[1]);
                lviArr[i].SubItems.Add(datos[2]);
                lviArr[i].SubItems.Add(datos[3]);
                lviArr[i].SubItems.Add(datos[4]);
                lviArr[i].SubItems.Add(datos[5]);
                lviArr[i].Tag = linea;
                i++;
            }
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

    }
}
