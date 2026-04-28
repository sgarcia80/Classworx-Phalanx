using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using TestWSInterfaceClaves.ConectoresWS;
using System.Collections.Generic;
using NDCCommon.Entities;
using NDCBL;
using NDCCommon.Collections;

namespace TestWSInterfaceClaves
{
    public partial class FormMeta4Empleados : Form
    {
        public FormMeta4Empleados()
        {
            InitializeComponent();
        }

        private void FormMeta4Empleados_Load(object sender, EventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtLog.Text = "Inicia Proceso...";
            txtLog.Refresh();

            try
            {
                PhalanxDAL.DBMgr.InicializarMeta4();

                dgvEmpleados.DataSource = new List<Meta4LegajoEntity>();

                var empleados = EjecutarConsultaEmpleados();

                dgvEmpleados.AutoGenerateColumns = true;
                dgvEmpleados.DataSource = empleados;
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    txtLog.Text += ex.InnerException.Message;
            }

        }

        private Meta4LegajoEntityCollection EjecutarConsultaEmpleados()
        {
            Meta4LegajoBusiness meta4BL = new Meta4LegajoBusiness();

            Meta4LegajoEntityCollection list = meta4BL.GetAll(txtUsuario.Text, txtNombre.Text, txtApellido.Text);

            return list;
        }
    }
}