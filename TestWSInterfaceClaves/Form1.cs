using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestWSInterfaceClaves.WSInterfaceIngresoTickets;
using System.Web.Services.Protocols;

namespace TestWSInterfaceClaves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

                AgregarTicketResultado resultado = serviceProxy.AgregarTicket(solicitud);

                if (resultado.Exito)
                    txtLog.Text += "Los datos se guardaron correctamente";
                else
                    txtLog.Text += "Error: " + resultado.Mensaje;
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
            }

        }

    }
}