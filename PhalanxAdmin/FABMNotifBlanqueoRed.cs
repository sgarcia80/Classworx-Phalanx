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
using PhalanxNAL;

namespace PhalanxAdmin
{
    public partial class FABMNotifBlanqueoRed : PhalanxAdmin.FModalBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FABMNotifBlanqueoRed));

        TicketNotificacionBlanqueoEntity _entity = new TicketNotificacionBlanqueoEntity();
        WinDomainEntityCollection _dominios = new WinDomainEntityCollection();

        WinDomainBusiness DominioLoginBL = new WinDomainBusiness();
        AplicacionNotificacionClaveBusiness AplicacionBL = new AplicacionNotificacionClaveBusiness();
        TicketNotificacionBlanqueoBusiness TicketBL = new TicketNotificacionBlanqueoBusiness();

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

        public FABMNotifBlanqueoRed(FormType formType)
        {
            InitializeComponent();
            m_FormType = formType;
        }

        public FABMNotifBlanqueoRed(int id, bool ReadOnly, FormType formType, string userlogon)
            : this(formType)
        {
            this.Usuario = userlogon;
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = TicketNotificacionBlanqueoEntity.CreateNotificacionBlanqueoRed();
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
                        this.Title = "Ticket de Notificación de Blanqueo de Red Nro " + nro;
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

                string strPwd = TicketBL.DesencriptarPassword(_entity.PasswordUsuarioAplicacion);

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

            // chequear pwd no vacia
            if (tPassword1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe generar una nueva contraseña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WinDomainEntity dominio = null;

            // asignar datos a la entity
            if (_entity.Id == 0)
            {
                dominio = cbDomain.SelectedItem as WinDomainEntity;

                _entity.UsuarioDominio = dominio.NtName;
                _entity.Fecha = DateTime.Now;
            }

            bool altaTempranaPendiente = ValidarAltaTempranaPendiente(dominio.NtName, txtUser.Text);

            if (altaTempranaPendiente)
            {
                string mensaje = string.Format("El usuario {0} tiene una Notificación de Alta Temprana pendiente", txtUser.Text);
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _entity.Usuario = txtUser.Text.Trim().ToLower();
            _entity.UsuarioAplicacion = _entity.Usuario;
            _entity.PasswordUsuarioAplicacion = tPassword1.Text;
            _entity.Solicitante = txtSolicitante.Text.Trim();
            _entity.SolicitantePuesto = txtSolicitantePuesto.Text.Trim();

            _entity.UsuarioCarga = user;

            // grabar
            int Id = 0;
            string error = string.Empty;

            try
            {
                Id = TicketBL.Save(_entity, dominio);

                if (Id > 0)
                {
                    string debug = string.Empty;

                    TicketBL.EnviarEmail(_entity, out debug);

                    _entity.Id = Id;
                    MessageBox.Show("La Notificación de Blanqueo de Red se generó correctamente", "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(error, "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            NDCBL.PalabraBlanqueoBusiness palabrasBL = new PalabraBlanqueoBusiness();
            PalabraBlanqueoEntityCollection palabras = new PalabraBlanqueoEntityCollection();

            try
            {
                palabras = palabrasBL.GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar las palabras aleatorias", "Notificación de Blanqueo Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int index = 0;

            if (RandomWord == null)
            {
                RandomWord = new Random();
            }
            if (RandomNumber == null)
            {
                RandomNumber = new Random();
            }

            index = RandomWord.Next(0, palabras.Count);

            var randompinresult = RandomNumber.Next(0, 99).ToString();
            randompinresult = randompinresult.PadLeft(2, '0');

            tPassword1.Text = string.Format("{0}{1}{2}", palabras[index].Valor.Substring(0, 2).ToUpper(), palabras[index].Valor.Substring(2), randompinresult);
        }

        private bool ValidarAltaTempranaPendiente(string dominio, string usuario)
        {
            bool ok = false;

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            log.InfoFormat("Se consulta Altas Tempranas del usuario {0}/{1} que estén pendientes", dominio, usuario);

            TicketNotificacionClaveEntityCollection tickets = tncb.GetAltaTempranaPendientes(dominio, usuario);

            if (tickets != null)
            {
                log.InfoFormat("Se encontraron {0} notificaciones de alta temprana pendientes", tickets.Count);

                if (tickets.Count > 0)
                {
                    if (!tickets[0].FechaAceptacionTyC.HasValue)
                    {
                        ok = true;
                    }
                }
            }

            return ok;
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

                if (usuario.Exception || !usuario.Found)
                {
                    log.InfoFormat(usuario.Log);

                    if (usuario.Found)
                    {
                        log.InfoFormat("Se encontró el usuario '{0}' pero hubo un error.", txtSolicitante.Text.Trim());
                    }
                    else
                    {
                        log.InfoFormat("No se encontró el usuario '{0}'", txtSolicitante.Text.Trim());
                    }
                }
                else
                {
                    txtSolicitantePuesto.Text = usuario.Title;
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
            ValidarUsuarioRed();
        }

        private void txtSolicitante_Validating(object sender, CancelEventArgs e)
        {
            ValidarUsuarioSolicitante();
        }

        private void cbDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarUsuarioRed();

            ValidarUsuarioSolicitante();
        }
    }
}

