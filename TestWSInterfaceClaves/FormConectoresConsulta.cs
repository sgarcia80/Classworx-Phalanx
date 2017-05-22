using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using TestWSInterfaceClaves.ConectoresWS;
using System.Collections.Generic;

namespace TestWSInterfaceClaves
{
    public partial class FormConectoresConsulta : Form
    {
        public FormConectoresConsulta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtLog.Text = "Inicia Proceso...";
            txtLog.Refresh();

            try
            {
                dataGridView1.DataSource = new List<Item>();

                string cs = "";

                if (rbAutenticacionPlain.Checked)
                {
                    string stringconnection = "dominio=" + txtDominio.Text + ";"
                                                + "usuario=" + txtUsuario.Text + ";"
                                                + "password=" + txtUsrPwd.Text;

                    cs = (new phxCryptMgr.CCryptMgr()).encrypt(stringconnection);
                }
                if (rbAutenticacionEncript.Checked)
                {
                    cs = txtAutEncript.Text;
                }
                if (chkLog.Checked)
                {
                    cs += "DEBUG";
                }

                ListaResultado resultado = null;
                int index = Convert.ToInt32(comboBox1.SelectedValue);

                switch (index)
                {
                    case 1:
                        resultado = EjecutarGrupoSeguimiento(cs);
                        break;
                    case 2:
                        resultado = EjecutarGrupoSolicitudes(cs);
                        break;
                    case 3:
                        resultado = EjecutarRoles(cs);
                        break;
                }

                if (resultado.Exito)
                {
                    txtLog.Text += "Los datos se guardaron correctamente";
                    if (chkLog.Checked)
                    {
                        txtLog.Text += Environment.NewLine + resultado.Mensaje.Replace(" | ", Environment.NewLine);
                    }

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = resultado.Lista;
                }
                else
                    txtLog.Text += "Error: " + resultado.Mensaje.Replace(" | ", Environment.NewLine);
            }
            catch (SoapHeaderException ex)
            {
                if (ex.Code.Name == "FailedAuthentication")
                    txtLog.Text += "Error al autenticar";
                else
                    txtLog.Text += ex.Message;
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    txtLog.Text += ex.InnerException.Message;
            }

        }

        private ListaResultado EjecutarGrupoSeguimiento(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            ListaResultado resultado = null;

            BaseRequest request = new BaseRequest();
            request.StringAutenticacion = cadenaseguridad;

            resultado = serviceProxy.ConsultaGrupoSeguimiento(request);

            return resultado;
        }

        private ListaResultado EjecutarGrupoSolicitudes(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            ListaResultado resultado = null;

            BaseRequest request = new BaseRequest();
            request.StringAutenticacion = cadenaseguridad;

            resultado = serviceProxy.ConsultaGrupoSolicitudes(request);

            return resultado;
        }

        private ListaResultado EjecutarRoles(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            ListaResultado resultado = null;

            BaseRequest request = new BaseRequest();
            request.StringAutenticacion = cadenaseguridad;

            resultado = serviceProxy.ConsultaRoles(request);

            return resultado;
        }

        private void FormConectoresConsulta_Load(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();

            items.Add(new Item { Id = 1, Descripcion = "Grupos de Seguimiento" });
            items.Add(new Item { Id = 2, Descripcion = "Grupos de Solicitudes" });
            items.Add(new Item { Id = 3, Descripcion = "Roles" });

            comboBox1.DataSource = items;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Descripcion";

            comboBox1.SelectedValue = 3;
        }
    }
}