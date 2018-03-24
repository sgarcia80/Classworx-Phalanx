using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Entities;
using PhalanxCommon.Entities;
using PhalanxBL;
using System.DirectoryServices;

namespace PhalanxAdmin
{
    public partial class FLogin : Form
    {
        public List<WinDomainEntity> Dominios { get; set; }

        public string Usuario { get; set; }

        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            PhalanxBL.DomainsMgr domainBL = new PhalanxBL.DomainsMgr();
            domainBL.ReloadDBDomains();

            this.Dominios = new List<WinDomainEntity>();
            foreach (WinDomainEntity entity in domainBL.DominiosDB)
            {
                this.Dominios.Add(entity);
            }

            string winuser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] datos = winuser.Split('\\');

            string domain = "MACRO";
            int domainid = 0;
            string user = string.Empty;
            int value = 0;

            if (datos.Length == 2)
            {
                domain = datos[0].Trim().ToUpper();
                user = datos[1].Trim();
            }

            foreach (WinDomainEntity d in this.Dominios)
            {
                if (d.NtName.ToUpper().Contains("MACRO") && domainid == 0)
                {
                    domainid = d.Id;
                }

                if (d.NtName.ToUpper().Contains(domain))
                {
                    value = d.Id;
                    break;
                }
            }

            if (value == 0)
            {
                value = domainid;
            }

            cmbDominios.DataSource = this.Dominios;
            cmbDominios.ValueMember = "Id";
            cmbDominios.DisplayMember = "NtName";

            if (value > 0)
            {
                cmbDominios.SelectedValue = value;
            }

            txtUsuario.Text = user;
            
            this.ActiveControl = txtPassword;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            WinDomainEntity dominio = cmbDominios.SelectedItem as WinDomainEntity;

            if (dominio == null)
            {
                MessageBox.Show("Debe seleccionar un Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Debe introducir el Usuario y Passowrd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Autenticar(dominio, txtUsuario.Text.Trim(), txtPassword.Text.Trim()))
                {
                    this.Usuario = string.Format("{0}\\{1}", dominio.NtName, txtUsuario.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool Autenticar(WinDomainEntity dominio, string usuario, string password)
        {
            bool authentic = false;

            AuditLoginBusiness auditLoginBusiness = new AuditLoginBusiness();

            string nombreUsuario = string.Format(@"{0}\{1}", dominio.NtName, usuario);

            try
            {
                //string provider = "LDAP";

                PhxConfigBusiness pcb = new PhxConfigBusiness();

                //PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionLoginNDC);

                //if (config.ShortTxtValue == "WINNT")
                //    provider = "WinNT";

                string path = dominio.LDAPPath; //provider + "://" + dominio;

                DirectoryEntry entry = new DirectoryEntry(path, usuario, password);

                object nativeObject = entry.NativeObject;
                authentic = true;

                this.Usuario = usuario;
            }
            catch (DirectoryServicesCOMException cex)
            {
                if (cex.ExtendedError == -2146893044)
                    auditLoginBusiness.LogUsrInexist(usuario);
            }
            catch (Exception ex)
            {

            }

            return authentic;
        }
    }
}
