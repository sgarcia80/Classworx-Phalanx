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
using PhalanxBL;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMDetalleBlanqueoTC : PhalanxAdmin.FModalBase
    {
        TicketNotificacionTarjetaEntity _entity = new TicketNotificacionTarjetaEntity();
        WinDomainEntityCollection _dominios = new WinDomainEntityCollection();
        AplicacionNotificacionClaveBusiness AplicacionBL = new AplicacionNotificacionClaveBusiness();
        DominioLoginBusiness DominioLoginBL = new DominioLoginBusiness();
        TicketNotificacionTarjetaBusiness TicketBL = new TicketNotificacionTarjetaBusiness();
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

        public FABMDetalleBlanqueoTC(FormType formType)
        {
            InitializeComponent();
            m_FormType = formType;
        }

        public FABMDetalleBlanqueoTC(int id, bool ReadOnly, FormType formType)
            : this(formType)
        {
            if (id > 0)
            {
                this._entity = TicketBL.Load(id);
            }
            else
            {
                this._entity = new TicketNotificacionTarjetaEntity();
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
            base.Title = "Blanqueo de Tarjeta de Crédito";

            CargarAplicaciones();
            CargarDominios();

            btnAceptar.Visible = false;
            btnCancelar.Text = "Cerrar";

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

                if (dominio != null)
                {
                    cbDomain.SelectedItem = dominio;
                }
                else
                {
                    cbDomain.Text = _entity.UsuarioDominio;
                }

                txtUser.Text = _entity.Usuario;

                txtUsername.Text = _entity.UsuarioAplicacion;
                string strPwd = _entity.PasswordUsuarioAplicacion;

                tPassword1.Text = strPwd;

                cbAplicacion.SelectedItem = _entity.Aplicacion;

                txtFecha.Text = _entity.Fecha.ToString("dd/MM/yyyy HH:mm");
                txtFechaAyC.Text = _entity.FechaNotificado.HasValue ? _entity.FechaNotificado.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                txtUsuarioCarga.Text = _entity.UsuarioCarga;

                txtSolicitante.Text = _entity.Solicitante;
                txtTicketNro.Text = _entity.NumeroSolicitud.HasValue ? _entity.NumeroSolicitud.Value.ToString() : string.Empty;

                txtEstado.Text = _entity.Estado.ToString();

                // hace readonly los campos
                txtUser.ReadOnly = true;
                cbDomain.Enabled = false;

                cbAplicacion.Enabled = false;
                txtUsername.ReadOnly = true;
                tPassword1.ReadOnly = true;

                txtTicketNro.ReadOnly = true;
                txtSolicitante.ReadOnly = true;

                txtSolicitante.BackColor = tPassword1.BackColor;
                txtTicketNro.BackColor = tPassword1.BackColor;

            }

            //this.chkVisualizar.Checked = true;
            //tPassword1.PasswordChar = new char();
            //tPassword1.Refresh();

            ConfigureScreen();
        }

        private void CargarDominios()
        {
            WinDomainBusiness dominioLoginBL = new WinDomainBusiness();
            dominioLoginBL.FilConfigured = true;

            //_dominios = DominioLoginBL.GetAllParaCombo();
            _dominios = dominioLoginBL.GetAll();

            cbDomain.Items.Clear();
            cbDomain.DataSource = _dominios; // WithDatabases();
            cbDomain.ValueMember = "Id";
            cbDomain.DisplayMember = "NtName";

            var macro = _dominios.FindByName("MACRO");
            if (macro != null)
            {
                cbDomain.SelectedItem = macro;
            }
        }

        private void CargarAplicaciones()
        {
            AplicacionBL.FilEsEmuladores = true;
            var list = AplicacionBL.GetAll();
            list.Insert(0, new AplicacionNotificacionClaveEntity { Id = 0, Codigo = string.Empty, Nombre = "" });

            cbAplicacion.Items.Clear();
            AplicacionBL.FilNotificable = true;
            cbAplicacion.DataSource = list; // WithDatabases();
        }

        private void chkVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizar.Checked)
            {
                tPassword1.PasswordChar = new char();
                tPassword1.Text = _entity.Clave != null ? _entity.Clave.Clave : _entity.PasswordUsuarioAplicacion;
            }
            else
            {
                tPassword1.Text = _entity.Clave != null ? _entity.Clave.ClaveEncriptada : _entity.PasswordUsuarioAplicacion;
                tPassword1.PasswordChar = '*';
            }
            
            tPassword1.Refresh();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        { 
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

