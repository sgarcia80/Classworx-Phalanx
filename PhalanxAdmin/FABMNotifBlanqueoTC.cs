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
using PhalanxCommon;
using PhalanxBL;
using PhalanxCommon.Collections;
using log4net;

namespace PhalanxAdmin
{
    public partial class FABMNotifBlanqueoTC : PhalanxAdmin.FModalBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FABMNotifBlanqueoTC));

        TicketNotificacionTarjetaEntity _entity = new TicketNotificacionTarjetaEntity();
        WinDomainEntityCollection _dominios = new WinDomainEntityCollection();

        WinDomainBusiness DominioLoginBL = new WinDomainBusiness();
        AplicacionNotificacionClaveBusiness AplicacionBL = new AplicacionNotificacionClaveBusiness();
        TicketNotificacionTarjetaBusiness TicketBL = new TicketNotificacionTarjetaBusiness();
        MacroUsuarioTarjetaBusiness UserTarjBL = new MacroUsuarioTarjetaBusiness();

        bool _readOnly = false;
        Random RandomWord = null;
        Random RandomNumber = null;

        public enum FormType
        {
            New,
            Update,
            View,
            Delete
        }

        private FormType m_FormType = FormType.View;
        private string user = string.Empty;

        public FABMNotifBlanqueoTC(FormType formType)
        {
            InitializeComponent();

            this._entity = new TicketNotificacionTarjetaEntity();

            m_FormType = formType;
            this.user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            _readOnly = false;
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
                        this.Title = "Nuevo Ticket de Notificación de Blanqueo de Tarj. Créd.";
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Ticket de Notificación de Blanqueo de Tarj. Créd.";
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Ticket de Notificación de Blanqueo de Tarj. Créd. Nro " + nro;
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Ticket de Notificación de Blanqueo de Tarj. Créd.";
                        break;
                    }
            }
        }

        private void FABMDBPwd_Load(object sender, EventArgs e)
        {
            base.Title = "Notificación de Blanqueo de Tarjeta de Crédito";

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

        private void CargarUsuarios()
        {
            MacroUsuarioTarjetaEntityCollection usuarios = null;

            if (picActivo.Visible)
            {
                usuarios = UserTarjBL.GetAll(txtUser.Text.Trim());
            }
            else
            {
                usuarios = new MacroUsuarioTarjetaEntityCollection();
            }

            gvUsuarios.AutoGenerateColumns = false;
            gvUsuarios.DataSource = usuarios;
        }

        private void CargarUsuariosOtros()
        {
            AplicacionBL.FilEsEmuladores = true;
            var apps = AplicacionBL.GetAll();

            MacroUsuarioTarjetaEntity entity = null;
            MacroUsuarioTarjetaEntityCollection list = new MacroUsuarioTarjetaEntityCollection();

            foreach (AplicacionNotificacionClaveEntity app in apps)
            {
                entity = new MacroUsuarioTarjetaEntity
                {
                    Aplicacion = app,
                    PrefijoUsuarioTC = app.PrefijoUsuarioTC,
                    UsuarioTC = string.Empty
                };

                list.Add(entity);
            }

            gvUsuariosOtros.AutoGenerateColumns = false;
            gvUsuariosOtros.DataSource = list;
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
            dominio = cbDomain.SelectedItem as WinDomainEntity;

            bool altaTempranaPendiente = false;// ValidarAltaTempranaPendiente(dominio.NtName, txtUser.Text);

            if (altaTempranaPendiente)
            {
                string mensaje = string.Format("El usuario {0} tiene una Notificación de Alta Temprana pendiente", txtUser.Text);
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nro = 0;
            List<TicketNotificacionTarjetaEntity> list = new List<TicketNotificacionTarjetaEntity>();

            foreach (DataGridViewRow row in gvUsuarios.Rows)
            {
                MacroUsuarioTarjetaEntity tarjeta = row.DataBoundItem as MacroUsuarioTarjetaEntity;

                if (Convert.ToBoolean(row.Cells[colSeleccionarUsr.Name].Value))
                {
                    string usuariotarjeta = row.Cells[colUsuario.Name].Value.ToString();

                    _entity = new TicketNotificacionTarjetaEntity();

                    _entity.Fecha = DateTime.Now;
                    _entity.Solicitante = txtSolicitante.Text.Trim();
                    _entity.UsuarioCarga = this.user;

                    if (int.TryParse(txtTicketNro.Text, out nro))
                    {
                        _entity.NumeroSolicitud = nro;
                    }

                    _entity.UsuarioDominio = dominio.NtName;
                    _entity.Usuario = txtUser.Text.Trim().ToLower();

                    _entity.Aplicacion = tarjeta.Aplicacion;
                    _entity.UsuarioAplicacion = string.Format("{0}{1}", tarjeta.Aplicacion.PrefijoUsuarioTC, usuariotarjeta);

                    list.Add(_entity);
                }
            }

            foreach (DataGridViewRow row in gvUsuariosOtros.Rows)
            {
                MacroUsuarioTarjetaEntity tarjeta = row.DataBoundItem as MacroUsuarioTarjetaEntity;

                if (Convert.ToBoolean(row.Cells[colSeleccionarOtros.Name].Value))
                {
                    string usuariotarjeta = row.Cells[colUsuarioOtros.Name].Value.ToString();

                    if (!string.IsNullOrEmpty(usuariotarjeta))
                    {
                        _entity = new TicketNotificacionTarjetaEntity();

                        _entity.Fecha = DateTime.Now;
                        _entity.Solicitante = txtSolicitante.Text.Trim();
                        _entity.UsuarioCarga = this.user;

                        if (int.TryParse(txtTicketNro.Text, out nro))
                        {
                            _entity.NumeroSolicitud = nro;
                        }

                        _entity.UsuarioDominio = dominio.NtName;
                        _entity.Usuario = txtUser.Text.Trim().ToLower();

                        _entity.Aplicacion = tarjeta.Aplicacion;
                        _entity.UsuarioAplicacion = usuariotarjeta;

                        list.Add(_entity);
                    }
                }
            }

            // grabar
            int Id = 0;
            string error = string.Empty;

            try
            {
                TicketBL.Create(list);

                string debug = string.Empty;

                TicketBL.EnviarEmail(_entity, out debug);

                MessageBox.Show("Las Notificaciones se generaron correctamente", "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(error, "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                string nombreUser = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(txtUser.Text.Trim(), path);

                if (!string.IsNullOrEmpty(nombreUser))
                {
                    picActivo.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }

            return picActivo.Visible;
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            ValidarUsuarioRed();

            CargarUsuarios();

            CargarUsuariosOtros();
        }
    }
}

