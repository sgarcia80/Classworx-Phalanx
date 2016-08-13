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
using PhalanxCommon.Collections;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FABMNotifDesbloqueoRed : PhalanxAdmin.FModalBase
    {
        TicketNotificacionBlanqueoEntity _entity = new TicketNotificacionBlanqueoEntity();
        WinDomainEntityCollection _dominios = new WinDomainEntityCollection();
        AplicacionNotificacionClaveBusiness AplicacionBL = new AplicacionNotificacionClaveBusiness();
        WinDomainBusiness DominioLoginBL = new WinDomainBusiness();
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

        public FABMNotifDesbloqueoRed(FormType formType)
        {
            InitializeComponent();
            m_FormType = formType;
        }

        public FABMNotifDesbloqueoRed(int id, bool ReadOnly, FormType formType)
            : this(formType)
        {
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = TicketNotificacionBlanqueoEntity.CreateNotificacionDesbloqueoRed();
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
                        this.Title = "Nuevo Ticket de Notificación de Desbloqueo de Red";
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Ticket de Notificación de Desbloqueo de Red";
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Ticket de Notificación de Desbloqueo de Red Nro" + nro;
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Ticket de Notificación de Desbloqueo de Red";
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

                _entity.Aplicacion = new AplicacionNotificacionClaveBusiness().GetAppRed();
            }
            else
            {
                WinDomainEntity dominio = null;

                foreach (WinDomainEntity dom in _dominios)
                {
                    if (dom.NtName.Trim().ToUpper().Equals(_entity.UsuarioDominio))
                    {
                        dominio = dom;
                        break;
                    }
                }

                // no es uno nuevo, cargo los datos
                cbDomain.SelectedItem = dominio;
                txtUser.Text = _entity.Usuario;

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

                    txtSolicitante.ReadOnly = true;

                    txtSolicitante.BackColor = txtUsuarioCarga.BackColor;
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
            _dominios = DominioLoginBL.GetAll();

            cbDomain.Items.Clear();
            cbDomain.DataSource = _dominios; // WithDatabases();
            cbDomain.ValueMember = "Id";
            cbDomain.DisplayMember = "NtName";

            WinDomainEntity macro = null;

            foreach (WinDomainEntity dom in _dominios)
            {
                if (dom.NtName.Trim().ToUpper().Equals("MACRO"))
                {
                    macro = dom;
                    break;
                }
            }

            if (macro != null)
            {
                cbDomain.SelectedItem = macro;
            }
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

            WinDomainEntity dominio = null;

            // asignar datos a la entity
            if (_entity.Id == 0)
            {
                dominio = cbDomain.SelectedItem as WinDomainEntity;

                _entity.UsuarioDominio = dominio.NtName.Trim();
                _entity.Fecha = DateTime.Now;
            }

            _entity.Usuario = txtUser.Text.Trim().ToLower();
            _entity.UsuarioAplicacion = _entity.Usuario;
            _entity.Solicitante = txtSolicitante.Text.Trim();

            _entity.UsuarioCarga = user;
            _entity.FechaAceptacionTyC = _entity.Fecha;

            // grabar
            int Id = 0;
            string error = string.Empty;

            try
            {
                Id = TicketBL.Save(_entity, dominio);

                if (Id > 0)
                {
                    _entity.Id = Id;
                    MessageBox.Show("La Notificación de Desbloqueo de Red se generó correctamente", "Notificación de Desbloqueo de Red", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidOperationException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = string.Format("Error al grabar el Ticket ({0})", ex.Message);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Notificación de Desbloqueo de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

