using System;
using System.Windows.Forms;
using TestWSInterfaceClaves.WSTickets;
using System.Web.Services.Protocols;
using PhalanxNAL;
using System.IO;

namespace TestWSInterfaceClaves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtLog.Text = "Inicia Proceso...";
            txtLog.Refresh();
            
            try
            {
                //Service serviceProxy = new Service();

                TicketsDeClaves serviceProxy = new TicketsDeClaves();
                //Service serviceProxy = new Service();

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

                TicketNotificacionClave solicitud = new TicketNotificacionClave();
                solicitud.StringAutenticacion = cs;

                solicitud.DominioUsuario = txtDomDest.Text;
                solicitud.Usuario = txtUsrDest.Text;

                solicitud.Legajo = txtLegajo.Text;
                solicitud.TipoDocumento = txtTipoDoc.Text;
                solicitud.Documento = txtNroDoc.Text;

                solicitud.IdSolicitud = Convert.ToInt32(txtNroTicket.Text);

                solicitud.CodigoAplicacion = txtCodApp.Text;
                solicitud.NombreAplicacion = txtNombreApp.Text;
                solicitud.UsuarioAplicacion = txtNombreUsrApp.Text;
                solicitud.PasswordUsuario = txtPwdUsrApp.Text;
                solicitud.UsaPasswordDominio = chkPwdRed.Checked;

                solicitud.SolicitudID = int.Parse(txtSolicitudID.Text);
                solicitud.NomSolicitante = txtNomSolicitante.Text;
                solicitud.NroLegajoSoli = txtNroLegajoSoli.Text;
                solicitud.ApeSolicitante = txtApeSolicitante.Text;

                solicitud.FechaVigDesde = dtpFechaVigDesde.Value;

                solicitud.CodigoGerencia = txtCodigoGerencia.Text;
                solicitud.NombreGerencia = txtNombreGerencia.Text;
                solicitud.SiglaArea = txtSiglaArea.Text;
                solicitud.DescripcionArea = txtDescripcionArea.Text;
                solicitud.CodSubsidiaria = txtCodSubsidiaria.Text;
                solicitud.NomSubsidiaria = txtNomSubsidiaria.Text;
                serviceProxy.Timeout = 60 * 4 * 1000;
                AgregarTicketResultado resultado = serviceProxy.AgregarTicket(solicitud);

                if (resultado.Exito)
                {
                    txtLog.Text += "Los datos se guardaron correctamente";
                    if (chkLog.Checked)
                    {
                        txtLog.Text += Environment.NewLine + resultado.Mensaje.Replace(" | ", Environment.NewLine);
                    }
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
                if(ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    txtLog.Text += ex.InnerException.Message;
            }

        }

        private void btnTestLDAP_Click(object sender, EventArgs e)
        {
            txtTestLDAP.Text = "";
            if (rbWS.Checked)
            {
                TicketsDeClaves serviceProxy = new TicketsDeClaves();
                string resultado = serviceProxy.TestLDAPConfig(txtLDAPUsername.Text, txtLDAPEmployeeID.Text);
                txtTestLDAP.Text = resultado.Replace(" | ", Environment.NewLine);
            }
            else
            {
                if (txtLDAPUsername.Text == "")
                {
                    MessageBox.Show("Se debe ingresar el usuario a buscar");
                    txtLDAPUsername.Focus();
                    return;
                }
                if (txtLDAPPathUsr.Text == "")
                {
                    MessageBox.Show("Se debe ingresar el Path del LDAP donde buscar el usuario");
                    txtLDAPPathUsr.Focus();
                    return;
                }
                txtTestLDAP.Text += "Va a hacer la llamada a ver si existe el usuario en el LDAP especificado" + Environment.NewLine;
                try
                {
                    if (ActiveDirectoryHelper.UsuarioExiste(txtLDAPPathUsr.Text, txtLDAPUsername.Text))
                    {
                        txtTestLDAP.Text += "El usuario fue encontrado." + Environment.NewLine;
                    }
                    else
                    {
                        txtTestLDAP.Text += "El usuario no fue encontrado." + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    txtTestLDAP.Text += "Excepcion:" + Environment.NewLine + ex.Message;
                }
            }
        }

        private void btnChgDescAD_Click(object sender, EventArgs e)
        {
            txtResultTestCambioDescAD.Text = "";
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                if (chkUsaConfig.Checked)
                    ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(txtUsrAD.Text);
                else
                    ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(txtUsrAD.Text, txtPrefijoDescUsrAD.Text, txtLDAPChgDescAD.Text, txtFilBuscNombreAD.Text);
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al actualizar la descripción: {0}{1}", System.Environment.NewLine, ex.ToString());
                txtResultTestCambioDescAD.Text = mensaje;
            }
            
            this.Cursor = Cursors.Default;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            txtResultTestCambioDescAD.Text = "";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (chkUsaConfig.Checked)
                    ActiveDirectoryHelper.EliminarPrefijoDescripcionUsuario(txtUsrAD.Text);
                else
                    ActiveDirectoryHelper.EliminarPrefijoDescripcionUsuario(txtUsrAD.Text, txtPrefijoDescUsrAD.Text, txtLDAPChgDescAD.Text, txtFilBuscNombreAD.Text);
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al actualizar la descripción: {0}{1}", System.Environment.NewLine, ex.ToString());
                txtResultTestCambioDescAD.Text = mensaje;
            }

            this.Cursor = Cursors.Default;
        }
    }
}