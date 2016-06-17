using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCCommon.Entities;
using NDCBL;
using NDCCommon.Collections;
using System.Collections;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FABMNotifBlanqueoRed : PhalanxAdmin.FModalBase
    {
        TicketNotificacionBlanqueoEntity _entity = new TicketNotificacionBlanqueoEntity();
        DominioLoginEntityCollection _dominios = new DominioLoginEntityCollection();
        AplicacionNotificacionClaveBusiness AplicacionBL = new AplicacionNotificacionClaveBusiness();
        DominioLoginBusiness DominioLoginBL = new DominioLoginBusiness();
        TicketNotificacionBlanqueoBusiness TicketBL = new TicketNotificacionBlanqueoBusiness();
        bool _readOnly = false;

        public enum FormType
        {
            New,
            Update,
            View,
            Delete
        }

        private FormType m_FormType = FormType.View;
        private string user = string.Empty;

        public FABMNotifBlanqueoRed(FormType formType)
        {
            InitializeComponent();
            m_FormType = formType;
        }

        public FABMNotifBlanqueoRed(int id, bool ReadOnly, FormType formType)
            : this(formType)
        {
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = TicketNotificacionBlanqueoEntity.CreateNotificacionBlanqueoRed();
            }

            m_FormType = formType;
            this.user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            _readOnly = ReadOnly;
        }
        
        public void ConfigureScreen()
        {
            string nro = string.Empty;

            if (_entity != null)
            {
                nro = _entity.Id.ToString();
            }

            switch (m_FormType)
            {
                case FormType.New:
                    {
                        this.Title = "Nuevo Ticket de Notificación de Blanqueo de Red";
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Ticket de Notificación de Blanqueode Red";
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Ticket de Notificación de Blanqueo de Red Nro" + nro;
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Ticket de Notificación de Blanqueo de Red";
                        break;
                    }
            }
        }

        private void FABMDBPwd_Load(object sender, EventArgs e)
        {
            base.Title = "Contraseña de Base de Datos";

            // si es visualización
            if (_readOnly)
            {
                btnAceptar.Enabled = false;
            }
            else
            {
            }

            CargarDominios();

            if (_entity.Id == 0)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtUsuarioCarga.Text = user;

                txtEstado.Text = "Pendiente";
            }
            else
            {
                var dominio = _dominios.FindByName(_entity.UsuarioDominio);

                // no es uno nuevo, cargo los datos
                cbDomain.SelectedItem = dominio;
                txtUser.Text = _entity.Usuario;

                string strPwd = TicketBL.DesencriptarPassword(_entity.PasswordUsuario);

                tPassword1.Text = strPwd;

                txtFecha.Text = _entity.Fecha.ToString("dd/MM/yyyy HH:mm");
                txtFechaAyC.Text = _entity.FechaAceptacionTyC.HasValue ? _entity.FechaAceptacionTyC.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                txtUsuarioCarga.Text = _entity.UsuarioCarga;

                txtSolicitante.Text = _entity.Solicitante;

                txtEstado.Text = _entity.FechaAceptacionTyC.HasValue ? "Notificado" : "Pendiente";

                if (_readOnly)
                {
                    // hace readonly los campos
                    txtUser.ReadOnly = true;
                    cbDomain.Enabled = false;

                    tPassword1.ReadOnly = true;

                    txtSolicitante.ReadOnly = true;

                    txtSolicitante.BackColor = tPassword1.BackColor;
                }
                else
                {
                    // si no es readonly (visualizar) cargo los combos
                }
            }

            this.chkVisualizar.Checked = true;
            tPassword1.PasswordChar = new char();
            tPassword1.Refresh();

            ConfigureScreen();
        }

        private void CargarDominios()
        {
            _dominios = DominioLoginBL.GetAllParaCombo();

            cbDomain.Items.Clear();
            cbDomain.DataSource = _dominios; // WithDatabases();
            cbDomain.ValueMember = "Nombre";
            cbDomain.DisplayMember = "Nombre";

            var macro = _dominios.FindByName("MACRO");
            if (macro != null)
            {
                cbDomain.SelectedItem = macro;
            }
        }
        
        private void chkVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizar.Checked)
            {
                tPassword1.PasswordChar = new char();
            }
            else
            {
                tPassword1.PasswordChar = '*';
            }
            tPassword1.Refresh();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // si es visualización sale
            if (_readOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            // chequear campos obligatorios
            // chequear pwd no vacia
            if (txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe introducir un Usuario de Red", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // chequear pwd no vacia
            if (tPassword1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe generar una nueva contraseña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esAlta = false;

            // asignar datos a la entity
            if (_entity.Id == 0)
            {
                _entity.UsuarioDominio = ((DominioLoginEntity)cbDomain.SelectedItem).Nombre.Trim();
                _entity.Fecha = DateTime.Now;

                esAlta = true;
            }

            _entity.Usuario = txtUser.Text.Trim().ToLower();
            _entity.PasswordUsuario = TicketBL.EncriptarPassword(tPassword1.Text);
            _entity.Solicitante = txtSolicitante.Text.Trim();

            _entity.UsuarioCarga = user;

            // grabar
            int Id = TicketBL.Save(_entity);

            if (Id > 0)
            {
                if (esAlta)
                {
                    string debug = string.Empty;

                    //TicketBL.EnviarEmail(_entity, out debug);
                }

                _entity.Id = Id;
                MessageBox.Show("La Notificación de Blanqueo de Red se generó correctamente", "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al grabar el Ticket", "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Random randompin = new Random();
            var randompinresult = randompin.Next(0, 9999).ToString();
            randompinresult = randompinresult.PadLeft(4, '0');

            tPassword1.Text = "macro" + randompinresult;
        }
    }
}

