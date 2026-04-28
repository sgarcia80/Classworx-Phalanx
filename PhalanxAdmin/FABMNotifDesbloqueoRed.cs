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
using PhalanxNAL;
using Classworx.Common.Trace;

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

        public FABMNotifDesbloqueoRed(int id, bool ReadOnly, FormType formType, string userlogon) : this(formType)
        {
            this.Usuario = userlogon;
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = TicketNotificacionBlanqueoEntity.CreateNotificacionDesbloqueoRed();
            }

            m_FormType = formType;
            this.user = this.Usuario;

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

                ValidarUsuarioCarga();
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

                txtUsuarioCarga.Text = _entity.UsuarioCarga;
                txtFecha.Text = _entity.Fecha.ToString("dd/MM/yyyy HH:mm");
                txtFechaAyC.Text = _entity.FechaAceptacionTyC.HasValue ? _entity.FechaAceptacionTyC.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;

                txtSolicitante.Text = _entity.Solicitante;
                txtSolicitantePuesto.Text = _entity.SolicitantePuesto;
                txtSolicitanteNombre.Text = _entity.SolicitanteNombre;
                txtSolicitanteDpto.Text = _entity.SolicitanteDepto;
                txtSolicitanteOfic.Text = _entity.SolicitanteOficina;
                txtSolicitanteProv.Text = _entity.SolicitanteProvincia;

                txtUsuarioNombre.Text = _entity.UsuarioNombre;
                txtUsuarioDpto.Text = _entity.UsuarioDepto;
                txtUsuarioOfic.Text = _entity.UsuarioOficina;
                txtUsuarioProv.Text = _entity.UsuarioProvincia;

                txtUsuarioCargaDpto.Text = _entity.UsuarioCargaDepto;
                txtUsuarioCargaProv.Text = _entity.UsuarioCargaProvincia;

                txtEstado.Text = _entity.FechaAceptacionTyC.HasValue ? "Notificado" : "Pendiente";
                txtTicketNro.Text = _entity.NumeroSolicitud.HasValue ? _entity.NumeroSolicitud.Value.ToString() : string.Empty;


                if (_readOnly)
                {
                    // hace readonly los campos
                    txtUser.ReadOnly = true;
                    cbDomain.Enabled = false;

                    txtSolicitante.ReadOnly = true;
                    txtTicketNro.ReadOnly = true;

                    txtSolicitante.BackColor = txtUsuarioCarga.BackColor;
                    txtTicketNro.BackColor = txtUsuarioCarga.BackColor;
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

            if (txtSolicitante.Text.Trim().Length > 0)
            {
                if (!picSolicitante.Visible)
                {
                    bool ok = ValidarUsuarioSolicitante();

                    if (!ok)
                    {
                        MessageBox.Show("El Solicitante es inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // chequear pwd no vacia
            if (txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe introducir un Usuario de Red", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!picActivo.Visible)
                {
                    bool ok = ValidarUsuarioRed();

                    if (!ok)
                    {
                        MessageBox.Show("El Usuario de Red es inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            WinDomainEntity dominio = null;

            // asignar datos a la entity
            if (_entity.Id == 0)
            {
                dominio = cbDomain.SelectedItem as WinDomainEntity;

                _entity.UsuarioDominio = dominio.NtName.Trim();
                _entity.Fecha = DateTime.Now;
            }

            int nro = 0;
            if (int.TryParse(txtTicketNro.Text, out nro))
            {
                _entity.NumeroSolicitud = nro;
            }

            _entity.Usuario = txtUser.Text.Trim().ToLower();
            _entity.UsuarioAplicacion = _entity.Usuario;

            _entity.UsuarioNombre = txtUsuarioNombre.Text;
            _entity.UsuarioDepto = txtUsuarioDpto.Text;
            _entity.UsuarioOficina = txtUsuarioOfic.Text;
            _entity.UsuarioProvincia = txtUsuarioProv.Text;

            _entity.Solicitante = txtSolicitante.Text.Trim();
            _entity.SolicitanteNombre = txtSolicitanteNombre.Text;
            _entity.SolicitantePuesto = txtSolicitantePuesto.Text.Trim();
            _entity.SolicitanteDepto = txtSolicitanteDpto.Text;
            _entity.SolicitanteOficina = txtSolicitanteOfic.Text;
            _entity.SolicitanteProvincia = txtSolicitanteProv.Text;

            _entity.UsuarioCarga = user;
            _entity.UsuarioCargaDepto = txtUsuarioCargaDpto.Text;
            _entity.UsuarioCargaProvincia = txtUsuarioCargaProv.Text;

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

        private void ValidarUsuarioCarga()
        {
            if (string.IsNullOrEmpty(txtUsuarioCarga.Text.Trim()))
            {
                return;
            }

            WinDomainEntity dominio = cbDomain.SelectedItem as WinDomainEntity;

            string path = string.Empty;

            if (!string.IsNullOrEmpty(dominio.LDAPPath))
            {
                path = dominio.LDAPPath;
            }

            try
            {
                string[] userinfo = txtUsuarioCarga.Text.Trim().Split(new char[] { '\\' });
                string userload = userinfo[1];

                DomainUser usuario = ActiveDirectoryHelper.BuscarUsuarioADPorNombre(path, userload);

                if (usuario.Exception || !usuario.Found)
                {
                    if (usuario.Found)
                    {
                        TraceHelper.Information("Se encontró el usuario '{0}' pero hubo un error.", txtUsuarioCarga.Text.Trim());
                    }
                    else
                    {
                        TraceHelper.Information("No se encontró el usuario '{0}'", txtUsuarioCarga.Text.Trim());
                    }
                }
                else
                {
                    txtUsuarioCargaDpto.Text = usuario.Department;
                    txtUsuarioCargaProv.Text = usuario.State;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidarUsuarioRed()
        {
            picActivo.Visible = false;

            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                return false;
            }

            WinDomainEntity dominio = cbDomain.SelectedItem as WinDomainEntity;

            string path = string.Empty;

            if (!string.IsNullOrEmpty(dominio.LDAPPath))
            {
                path = dominio.LDAPPath;
            }

            try
            {
                //string nombreUser = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(txtUser.Text.Trim(), path);

                //if (!string.IsNullOrEmpty(nombreUser))
                //{
                //    picActivo.Visible = true;
                //}

                DomainUser usuario = ActiveDirectoryHelper.BuscarUsuarioADPorNombre(path, txtUser.Text.Trim());

                TraceHelper.Information(usuario.Log);

                if (usuario.Exception || !usuario.Found)
                {

                    if (usuario.Found)
                    {
                        TraceHelper.Information("Se encontró el usuario '{0}' pero hubo un error.", txtUser.Text.Trim());
                    }
                    else
                    {
                        TraceHelper.Information("No se encontró el usuario '{0}'", txtUser.Text.Trim());
                    }
                }
                else
                {
                    txtUsuarioNombre.Text = usuario.DisplayName;
                    txtUsuarioDpto.Text = usuario.Department;
                    txtUsuarioOfic.Text = usuario.Office;
                    txtUsuarioProv.Text = usuario.State;
                    picActivo.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }

            return picActivo.Visible;
        }

        private bool ValidarUsuarioSolicitante()
        {
            picSolicitante.Visible = false;
            txtSolicitantePuesto.Text = string.Empty;

            if (string.IsNullOrEmpty(txtSolicitante.Text.Trim()))
            {
                return false;
            }

            WinDomainEntity dominio = cbDomain.SelectedItem as WinDomainEntity;

            string path = string.Empty;

            if (!string.IsNullOrEmpty(dominio.LDAPPath))
            {
                path = dominio.LDAPPath;
            }

            try
            {
                picSolicitante.Visible = false;

                DomainUser usuario = ActiveDirectoryHelper.BuscarUsuarioADPorNombre(path, txtSolicitante.Text.Trim());

                TraceHelper.Information(usuario.Log);

                if (usuario.Exception || !usuario.Found)
                {
                    if (usuario.Found)
                    {
                        TraceHelper.Information("Se encontró el usuario '{0}' pero hubo un error.", txtSolicitante.Text.Trim());
                    }
                    else
                    {
                        TraceHelper.Information("No se encontró el usuario '{0}'", txtSolicitante.Text.Trim());
                    }
                }
                else
                {
                    txtSolicitantePuesto.Text = usuario.Title;
                    txtSolicitanteNombre.Text = usuario.DisplayName;
                    txtSolicitanteDpto.Text = usuario.Department;
                    txtSolicitanteOfic.Text = usuario.Office;
                    txtSolicitanteProv.Text = usuario.State;
                    picSolicitante.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }

            return picActivo.Visible;
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (!this._readOnly)
            {
                ValidarUsuarioRed();
            }
        }

        private void txtSolicitante_Validating(object sender, CancelEventArgs e)
        {
            if (!this._readOnly)
            {
                ValidarUsuarioSolicitante();
            }
        }

        private void cbDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._readOnly)
            {
                ValidarUsuarioRed();

                ValidarUsuarioSolicitante();
            }
        }
    }
}

