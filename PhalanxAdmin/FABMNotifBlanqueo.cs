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
    public partial class FABMNotifBlanqueo : PhalanxAdmin.FModalBase
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

        public FABMNotifBlanqueo(FormType formType)
        {
            InitializeComponent();
            m_FormType = formType;
        }

        public FABMNotifBlanqueo(int id, bool ReadOnly, FormType formType)
            : this(formType)
        {
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = new TicketNotificacionBlanqueoEntity();
            }

            m_FormType = formType;
            this.user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            _readOnly = ReadOnly;
        }


        public void ConfigureScreen()
        {
            switch (m_FormType)
            {
                case FormType.New:
                    {
                        this.Title = "Nuevo Ticket de Notificación de Blanqueo";
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Ticket de Notificación de Blanqueo";
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Visualización de Ticket de Notificación de Blanqueo";
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Ticket de Notificación de Blanqueo";
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

            CargarAplicaciones();
            CargarDominios();

            if (_entity.Id == 0)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtSolicitante.Text = user;
            }
            else
            {
                txtTicketNro.Text = _entity.Id.ToString();

                var dominio = _dominios.FindByName(_entity.UsuarioDominio);

                // no es uno nuevo, cargo los datos
                cbDomain.SelectedItem = dominio;
                txtUser.Text = _entity.Usuario;

                txtUsername.Text = _entity.UsuarioAplicacion;
                string strPwd = TicketBL.DesencriptarPassword(_entity.PasswordUsuarioAplicacion);

                tPassword1.Text = strPwd;
                tPassword2.Text = strPwd;

                cbAplicacion.SelectedItem = _entity.Aplicacion;

                txtFecha.Text = _entity.Fecha.ToString("dd/MM/yyyy");
                txtFechaAyC.Text = _entity.FechaAceptacionTyC.HasValue ? _entity.FechaAceptacionTyC.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtSolicitante.Text = user;
                
                if (_readOnly)
                {
                    // hace readonly los campos
                    txtUsername.ReadOnly = true;
                    cbDomain.Enabled = false;
                    tPassword1.ReadOnly = true;
                    tPassword2.ReadOnly = true;
                    cbAplicacion.Enabled = false;
                }
                else
                {
                    // si no es readonly (visualizar) cargo los combos
                }
            }

            ConfigureScreen();
        }

        private void CargarDominios()
        {
            _dominios = DominioLoginBL.GetAllParaCombo();

            cbDomain.Items.Clear();
            cbDomain.DataSource = _dominios; // WithDatabases();
            cbDomain.ValueMember = "Nombre";
            cbDomain.DisplayMember = "Nombre";
        }

        private void CargarAplicaciones()
        {
            cbAplicacion.Items.Clear();
            //cbAplicacion.DataSource = DBTypeBL.GetAllWithDatabases();
            cbAplicacion.DataSource = AplicacionBL.GetAll(); // WithDatabases();
        }

        private void chkVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizar.Checked)
            {
                tPassword1.PasswordChar = new char();
                tPassword2.PasswordChar = new char();
            }
            else
            {
                tPassword1.PasswordChar = '*';
                tPassword2.PasswordChar = '*';
            }
            tPassword1.Refresh();
            tPassword2.Refresh();

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
            // chequear que se hayan elegido bases de datos
            if (_entity.Id == 0 && cbAplicacion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una Aplicación");
                this.DialogResult = DialogResult.None;
                return;
            }

            // chequear pwd no vacia
            if (txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe introducir un Usuario de Red");
                return;
            }
            // chequear pwd no vacia
            if (txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe introducir un Usuario");
                return;
            }

            // chequear pwd no vacia
            if (tPassword1.Text.Trim().Length == 0)
            {
                MessageBox.Show("La contraseña no es válida");
                return;
            }

            // chequear pwd1 y 2 iguales
            if (tPassword1.Text != tPassword2.Text)
            {
                MessageBox.Show("La contraseña y su confirmación no coinciden");
                this.DialogResult = DialogResult.None;
                return;
            }

            bool esAlta = false;

            // asignar datos a la entity
            if (_entity.Id == 0)
            {
                _entity.UsuarioDominio = ((DominioLoginEntity)cbDomain.SelectedItem).Nombre.Trim();
                _entity.Aplicacion = (AplicacionNotificacionClaveEntity)cbAplicacion.SelectedItem;
                _entity.Fecha = DateTime.Now;

                esAlta = true;
            }

            _entity.Usuario = txtUser.Text.Trim();
            _entity.UsuarioAplicacion = txtUsername.Text.Trim();
            _entity.PasswordUsuarioAplicacion = TicketBL.EncriptarPassword(tPassword1.Text);

            _entity.Solicitante = user;

            // grabar
            int Id = TicketBL.Save(_entity);

            if (Id > 0)
            {
                if (esAlta)
                {
                    string debug = string.Empty;

                    TicketBL.EnviarEmail(_entity, out debug);
                }

                _entity.Id = Id;
                MessageBox.Show("La notificación se generó correctamente", "Ticket de Notificación de Blanqueo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hubo un error al grabar el Ticket", "Ticket de Notificación de Blanqueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //if (m_FormType == FormType.Update || m_FormType == FormType.Delete)
            //{
            //    _entity = TicketBL.Refresh(_entity);
            //    if (_entity.ModifyingUser.Username == new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Username)
            //    {
            //        _entity.ModifyingDate = null;
            //        _entity.ModifyingUser = null;
            //        TicketBL.Save(_entity, false, this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
            //    }
            //}
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

