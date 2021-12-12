using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestWSInterfaceClaves
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;

        public Principal()
        {
            InitializeComponent();
        }

        //private void ShowNewForm<T>() where T : Form
        //{
        //    T childForm = new T();
        //    childForm.MdiParent = this;
        //    childForm.Text = "Ventana " + childFormNumber++;
        //    childForm.Show();
        //}

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notificacionAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotificacionAlta childForm = new FormNotificacionAlta();
            childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void conectorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConectores childForm = new FormConectores();
            childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void conectorConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConectoresConsulta childForm = new FormConectoresConsulta();
            childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMeta4Empleados childForm = new FormMeta4Empleados();
            childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }
    }
}
