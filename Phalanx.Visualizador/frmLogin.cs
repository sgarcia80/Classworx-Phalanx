using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.DirectoryServices;

namespace DesencriptadorContrasenias
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = false;

            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar el Usuario y la Password", "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ok = Autenticar("MACRO", usuario, password);

                if (ok)
                {
                    ok = Autorizar(usuario);
                }

                if (!ok)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ok)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private bool Autenticar(string dominio, string usuario, string password)
        {
            bool authentic = false;

            string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

            string provider = string.Empty;
            string path = string.Empty;

            if (ConfigurationManager.AppSettings["Provider"] != null)
            {
                provider = ConfigurationManager.AppSettings["Provider"].ToString();
            }
            if (ConfigurationManager.AppSettings["LDAPPath"] != null)
            {
                path = ConfigurationManager.AppSettings["LDAPPath"].ToString();
            }

            try
            {
                DirectoryEntry entry = new DirectoryEntry(path, usuario, password);

                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException cex)
            {
                MessageBox.Show("Usuario o contraseña inválida", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar el usuario", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return authentic;
        }

        private bool Autorizar(string usuario)
        {
            bool ok = false;

            string cadena = ConfigurationManager.AppSettings["Seguridad"].ToString();

            string usuariosAutorizados = new phxCryptMgr.CCryptMgr().decryptConfigFileAndClearBadChars(cadena);

            if (!string.IsNullOrEmpty(usuariosAutorizados))
            {
                usuariosAutorizados = usuariosAutorizados.ToLower();
            }

            if (usuariosAutorizados == null || !new List<string>(usuariosAutorizados.Split(',')).Contains(usuario.ToLower()))
            {
                MessageBox.Show("Usuario no autorizado", "Error de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ok = true;
            }

            return ok;
        }
    }
}
