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
    public partial class FormMeta4Usuarios : Form
    {
        public FormMeta4Usuarios()
        {
            InitializeComponent();
        }

        private void FormMeta4Usuarios_Load(object sender, EventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtLog.Text = "Inicia Proceso...";
            txtLog.Refresh();

            try
            {
                PhalanxDAL.DBMgr.InicializarMeta4();

                dgvEmpleados.DataSource = new List<Meta4ClassWorxUsuariosEntity>();

                var empleados = EjecutarConsultaUsuarios();

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

        private IList<Meta4ClassWorxUsuariosEntity> EjecutarConsultaUsuarios()
        {
            Meta4ClassWorxUsuariosBusiness meta4BL = new Meta4ClassWorxUsuariosBusiness();

            IList<Meta4ClassWorxUsuariosEntity> list = meta4BL.GetAll(txtUsuario.Text, txtTipoDocumento.Text, txtDocumento.Text);

            return list;
        }
    }
}