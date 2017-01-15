using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using PhalanxNAL;
using log4net.Config;
using log4net.Appender;
using log4net;
using log4net.Repository.Hierarchy;
using System.IO;
using TestWSInterfaceClaves.ConectoresWS;

namespace TestWSInterfaceClaves
{
    public partial class FormConectores : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));

        private MemoryAppender memoryAppender;

        public FormConectores()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
            memoryAppender = hierarchy.Root.GetAppender("MemoryAppender") as MemoryAppender;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtLog.Text = "Inicia Proceso...";
            txtLog.Refresh();

            try
            {
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

                Resultado resultado = null;

                if (tabControl1.SelectedTab == tabUsuario)
                {
                    resultado = EjecutarUsuario(cs);
                }
                if (tabControl1.SelectedTab == tabPerfil)
                {
                    resultado = EjecutarPerfil(cs);
                }
                if (tabControl1.SelectedTab == tabGrupoSeguimiento)
                {
                    resultado = EjecutarGrupoSeguimiento(cs);
                }
                if (tabControl1.SelectedTab == tabGrupoSolicitud)
                {
                    resultado = EjecutarGrupoSolicitudes(cs);
                }

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
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    txtLog.Text += ex.InnerException.Message;
            }

        }

        private void rbnBaja_CheckedChanged(object sender, EventArgs e)
        {
            Enable(rbnAlta.Checked);
        }

        private void rbnAlta_CheckedChanged(object sender, EventArgs e)
        {
            Enable(rbnAlta.Checked);
        }

        private Resultado EjecutarGrupoSeguimiento(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            Resultado resultado = null;

            GrupoSeguimientoRequest request = new GrupoSeguimientoRequest();
            request.StringAutenticacion = cadenaseguridad;
            request.Dominio = txtDomDest.Text;
            request.Usuario = txtUsrDest.Text;

            request.IdGrupos = txtGrupoSeguimiento.Text;

            if (rbnAlta.Checked)
            {
                resultado = serviceProxy.AltaGrupoSeguimiento(request);
            }
            if (rbnBaja.Checked)
            {
                resultado = serviceProxy.BajaGrupoSeguimiento(request);
            }

            return resultado;
        }

        private Resultado EjecutarGrupoSolicitudes(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            Resultado resultado = null;

            GrupoSolicitudesRequest request = new GrupoSolicitudesRequest();
            request.StringAutenticacion = cadenaseguridad;
            request.Dominio = txtDomDest.Text;
            request.Usuario = txtUsrDest.Text;

            request.IdGrupos = txtGrupoSolicitudes.Text;

            if (rbnAlta.Checked)
            {
                resultado = serviceProxy.AltaGrupoSolicitudes(request);
            }
            if (rbnBaja.Checked)
            {
                resultado = serviceProxy.BajaGrupoSolicitudes(request);
            }

            return resultado;
        }

        private Resultado EjecutarPerfil(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            Resultado resultado = null;

            PerfilRequest request = new PerfilRequest();
            request.StringAutenticacion = cadenaseguridad;
            request.Dominio = txtDomDest.Text;
            request.Usuario = txtUsrDest.Text;

            request.IdPerfiles = txtPerfil.Text;

            if (rbnAlta.Checked)
            {
                resultado = serviceProxy.AltaPerfil(request);
            }
            if (rbnBaja.Checked)
            {
                resultado = serviceProxy.BajaPerfil(request);
            }

            return resultado;
        }

        private Resultado EjecutarUsuario(string cadenaseguridad)
        {
            ConectoresWS.UsuarioService serviceProxy = new ConectoresWS.UsuarioService();
            serviceProxy.Timeout = 60 * 4 * 1000;

            Resultado resultado = null;

            if (rbnAlta.Checked)
            {
                AltaUsuarioRequest request = new AltaUsuarioRequest();
                request.StringAutenticacion = cadenaseguridad;
                request.Dominio = txtDomDest.Text;
                request.Usuario = txtUsrDest.Text;
                request.Legajo = txtLegajo.Text;
                request.NombreCompleto = txtNombreCompleto.Text;
                request.Email = txtEmail.Text;

                resultado = serviceProxy.AltaUsuario(request);
            }
            if (rbnBaja.Checked)
            {
                BajaUsuarioRequest request = new BajaUsuarioRequest();
                request.StringAutenticacion = cadenaseguridad;
                request.Dominio = txtDomDest.Text;
                request.Usuario = txtUsrDest.Text;

                resultado = serviceProxy.BajaUsuario(request);
            }

            return resultado;
        }

        private void Enable(bool alta)
        {
            if (tabControl1.SelectedTab == tabUsuario)
            {
                EnableUsuario(alta);
            }
            if (tabControl1.SelectedTab == tabPerfil)
            {
            }
            if (tabControl1.SelectedTab == tabGrupoSeguimiento)
            {
            }
            if (tabControl1.SelectedTab == tabGrupoSolicitud)
            {
            }
        }

        private void EnableUsuario(bool alta)
        {
            txtDomDest.Enabled = alta;
            txtUsrDest.Enabled = alta;
            txtLegajo.Enabled = alta;
            txtNombreCompleto.Enabled = alta;
            txtEmail.Enabled = alta;

            if (!alta)
            {
                txtLegajo.Text = string.Empty;
                txtNombreCompleto.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
        }
    }
}