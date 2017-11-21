using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Collections;
using System.Collections;

namespace PhalanxAdmin
{
    public partial class FABMECPwd : PhalanxAdmin.FModalBase
    {
        CommunicationDeviceUserEntity _entity = new CommunicationDeviceUserEntity();
        
        CommunicationDeviceTypeBusiness CDTypeBL = new CommunicationDeviceTypeBusiness();
        CommunicationDeviceUserBusiness CDUsrBL = null;


        public enum FormType
        {
            New,
            Update,
            View,
            Delete
        }

        private FormType m_FormType = FormType.View;

        private TextBox txtCDType;
        private TextBox txtCD;
        private const string cAsterisk = "**********";


        bool _readOnly = false;
        bool _esAlta = true;

        private string Username
        {
            get { return txtUsername.Text.Trim(); }
            set { txtUsername.Text = value; }
        }

        private string Description
        {
            get { return txtDescrip.Text; }
            set { txtDescrip.Text = value; }
        }

        private string Password
        {
            get { return tPassword1.Text.Trim(); }
            set { tPassword1.Text = value; }
        }

        private string ConfirmPassword
        {
            get { return tPassword2.Text.Trim(); }
            set { tPassword2.Text = value; }
        }

        private bool Activo
        {
            set { chkActivo.Checked = value; }
            get { return chkActivo.Checked; }
        }

        private bool Concurrente
        {
            set { chkPwdConcurrente.Checked = value; }
            get { return chkPwdConcurrente.Checked; }
        }

        private bool Critico
        {
            set { chkUsuarioCritico.Checked = value; }
            get { return chkUsuarioCritico.Checked; }
        }

        private CommunicationDeviceEntity CommunicationDevice
        {
            get
            {
                if (_esAlta)
                    return cbEC.SelectedItem as CommunicationDeviceEntity;

                return _entity.CommunicationDevice;
            }
            set
            {
                if (_esAlta)
                {
                    cbTipoEC.SelectedItem = value.Type;
                }
                else
                    txtCD.Text = value.Name;

                cbEC.SelectedItem = value;
            }
        }

        public FABMECPwd(FormType formType, string userlogon)
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

            this.Usuario = userlogon;
            CDUsrBL = new CommunicationDeviceUserBusiness(this.Usuario);
            m_FormType = formType;
        }

        public FABMECPwd(CommunicationDeviceUserEntity usuario, bool ReadOnly, FormType formType, string userlogon) : this(formType, userlogon)
        {
            usuario = CDUsrBL.Refresh(usuario);
            if (usuario.ModifyingDate != null && usuario.ModifyingUser != null)
            {
                if (usuario.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
                {
                    if (usuario.ModifyingDate.Value.AddMinutes(10) > new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate)
                    {
                        lblModifying.Text = "Esta contraseña está siendo modificada por " + usuario.ModifyingUser.Fullname + " desde el " + usuario.ModifyingDate.Value.ToShortDateString() + " a las " + usuario.ModifyingDate.Value.ToShortTimeString();
                        lblModifying.Visible = true;
                        formType = FormType.View;
                        ReadOnly = true;
                    }
                    else
                    {
                        lblModifying.Text = "Esta contraseña estuvo siendo modificada por " + usuario.ModifyingUser.Fullname + " desde el " + usuario.ModifyingDate.Value.ToShortDateString() + " a las " + usuario.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                        lblModifying.Visible = true;
                        if (formType == FormType.Update || m_FormType == FormType.Delete)
                        {
                            usuario.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                            usuario.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                            CDUsrBL.Save(usuario, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                        }
                    }
                }
                else
                {
                    lblModifying.Text = "Esta contraseña estuvo siendo modificada por usted el " + usuario.ModifyingDate.Value.ToShortDateString() + " a las " + usuario.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                    lblModifying.Visible = true;
                    if (formType == FormType.Update || m_FormType == FormType.Delete)
                    {
                        usuario.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                        usuario.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                        CDUsrBL.Save(usuario, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                    }
                }
            }
            else
            {
                lblModifying.Visible = false;
                if (formType == FormType.Update || m_FormType == FormType.Delete)
                {
                    usuario.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                    usuario.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                    CDUsrBL.Save(usuario, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                }
            }

            m_FormType = formType;
            _entity = usuario;
            _readOnly = ReadOnly;
            _esAlta = false;
        }

        public void ConfigureScreen()
        {
            switch (m_FormType)
            {
                case FormType.New:
                    {
                        this.Title = "Nuevo Usuario y Contraseña";
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        tabControl1.TabPages.Remove(tabControl1.TabPages[4]);
                        tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
                        this.chkVisualizar.Enabled = true;
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Usuario y Contraseña";
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Visualización de Usuario y Contraseña";
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        pnlGruposSolicitudes.Visible = false;
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        pnlGruposSeguimientos.Visible = false;
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Usuario y Contraseña";
                        tabControl1.TabPages.Remove(tabControl1.TabPages[4]);
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        pnlGruposSolicitudes.Visible = false;
                        pnlGruposSeguimientos.Visible = false;
                        break;
                    }
            }
        }

        private void FABMCDPwd_Load(object sender, EventArgs e)
        {
            base.Title = "Contraseña de Equipo de Comunicación";

            if (_entity.Id > 0)
                base.Info = _entity.CommunicationDeviceType + " / " +
                            _entity.CommunicationDevice.Name + " / " +
                            _entity.Username;
            else
                base.Info = "";

            if (_readOnly)
                DeshabilitarControles();
            else
                CargarComboTipos();
            
            if (_entity.Id == 0)
            {
                // es un nuevo registro
                chkChgPwd.Checked = true;
                chkChgPwd.Enabled = false;
            }
            else
            {
                DeshabilitarComboTipo();
                DeshabilitarComboCD();
                CargarProtocolos();

                // no es uno nuevo, cargo los datos
                Username = _entity.Username;
                Description = _entity.Desc;
                Password = CDUsrBL.DecryptPassword(_entity.UserPassword.Password);
                ConfirmPassword = Password;
                Activo = _entity.ActiveUser;
                chkActivo.Enabled = !_readOnly && _entity.CommunicationDevice.Active;
                Concurrente = _entity.UserPassword.Concurrent;
                Critico = _entity.Critical;
                CommunicationDevice = _entity.CommunicationDevice;
                
                lblFolioNro.Text = _entity.Key;
            }
            
            chkChgPwd_CheckedChanged(null, null);
            ConfigureScreen();
        }

        private void CargarProtocolos()
        {
            clbCDProtocols.Items.Clear();

            foreach (CommunicationDeviceProtocolEntity protocol in CommunicationDevice.Protocols)
            {
                ListViewItem item = new ListViewItem();
                item.Text = protocol.Name;
                item.Tag = protocol;
                item.Checked = _entity.Protocols.Contains(protocol);

                clbCDProtocols.Items.Add(item);
            }
        }

        private void DeshabilitarControles()
        {
            chkActivo.Enabled = false;
            clbCDProtocols.Enabled = false;
            txtUsername.ReadOnly = true;
            txtDescrip.ReadOnly = true;
            chkUsuarioCritico.Enabled = false;
            chkChgPwd.Enabled = false;
            chkChgPwd.Checked = false;
            tPassword1.ReadOnly = true;
            tPassword2.ReadOnly = true;
            chkPwdConcurrente.Enabled = false;

            // deshabilita boton cancelar
            btnCancelar.Enabled = false;
        }

        private void DeshabilitarComboTipo()
        {
            txtCDType = new TextBox();
            txtCDType.Location = cbTipoEC.Location;
            txtCDType.ReadOnly = true;
            txtCDType.Width = cbTipoEC.Width;
            txtCDType.Text = _entity.CommunicationDevice.Type.Name;

            this.tpGeneral.Controls.Add(txtCDType);

            cbTipoEC.Visible = false;
        }

        private void DeshabilitarComboCD()
        {
            txtCD = new TextBox();
            txtCD.Location = cbEC.Location;
            txtCD.ReadOnly = true;
            txtCD.Width = cbEC.Width;
            txtCD.Height = cbEC.Height;

            this.tpGeneral.Controls.Add(txtCD);

            cbEC.Visible = false;
        }

        private void CargarComboTipos()
        {
            CommunicationDeviceTypeBusiness CDTypeBL = new CommunicationDeviceTypeBusiness();
            cbTipoEC.DataSource = CDTypeBL.GetAll();
        }

        private void cbTipoEC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommunicationDeviceBusiness blCD = new CommunicationDeviceBusiness();
            blCD.FilTipoCD = (CommunicationDeviceTypeEntity)cbTipoEC.SelectedItem;
            cbEC.DataSource = blCD.GetAll();
            cbEC.ValueMember = "Key";
            cbEC.DisplayMember = "Name";            
        }

        private void chkVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (m_FormType == FormType.Update && chkVisualizar.Tag == null &&
                     chkVisualizar.Checked)
            {
                if (MessageBox.Show("Si visualiza la contraseña, se grabará un registro de log con este evento. Desea continuar?",
                    "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chkVisualizar.Tag = "logueado";

                    int id = 0;
                    if (this._entities != null && this._entities.Count > 0)
                    {
                        //Se obtiene el ultimo historial
                        foreach (vwHistPwdChgEntity entity in this._entities)
                        {
                            if (entity.Id > id)
                                id = entity.Id;
                        }
                    }

                    HistPasswordChangeAccessBusiness accessBL = new HistPasswordChangeAccessBusiness();
                    HistPasswordChangeAccessEntity accessE = new HistPasswordChangeAccessEntity();

                    accessE.HistChgPwd = new HistPasswordChangeEntity();
                    accessE.HistChgPwd.Id = id;
                    accessE.PhxUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                    accessE.AccessDate = DateTime.Now;

                    int Id = accessBL.Save(accessE);
                    if (Id <= 0)
                    {
                        MessageBox.Show("Hubo un error al grabar log de visualización de contraseñas", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    chkVisualizar.Checked = false;
                    return;
                }
            }

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

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !chkActivo.Checked;
            picActivo.Visible = chkActivo.Checked;

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

            if (_entity.Id != 0)
            {
                _entity = CDUsrBL.Refresh(_entity);
                if (_entity.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
                {
                    MessageBox.Show("Su sesión de edición expiró y la contraseña fue tomada por " + _entity.ModifyingUser.Fullname + " el " + _entity.ModifyingDate.Value.ToShortDateString() + " a las " + _entity.ModifyingDate.Value.ToShortTimeString());
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                _entity.ModifyingDate = null;
                _entity.ModifyingUser = null;
            }

            string errorMessage = null;

            if (Username == null)
                errorMessage = "Debe ingresar un nombre de usuario";
            else if (CommunicationDevice == null)
                errorMessage = "Debe seleccionar un equipo de comunicación";
            else if (Password.Trim().Length == 0)
                errorMessage = "La contraseña no es válida";
            else if (Password != ConfirmPassword)
                errorMessage = "La contraseña y su confirmación no coinciden";
            // verificar que el usuario no exista para esa BD
            else if ((_esAlta || Username != _entity.Username)             // es un alta o es modif pero cambió el nombre de usuario
                    && CDUsrBL.Exists(CommunicationDevice, txtUsername.Text.Trim())) 
                errorMessage = "El usuario ya existe";

            if (lvGruposSolicitudesAsociados.Items.Count == 0)
            {
                errorMessage="Debe seleccionar al menos un Grupo de Solicitudes asociado a este usuario";
            }
            if (lvGruposSeguimientoAsociados.Items.Count == 0)
            {
               errorMessage="Debe seleccionar al menos un Grupo de Seguimiento de Solicitudes asociado a este usuario";
            }



            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage);

                return;
            }            

            // asignar datos a la entity
            if (_esAlta)
                _entity.CommunicationDevice = CommunicationDevice;

            _entity.Desc = Description;
            _entity.Username = Username;
            
            if (chkChgPwd.Checked)
                _entity.UserPassword.Password = CDUsrBL.EncryptPassword(Password);

            _entity.ActiveUser = Activo;
            _entity.Critical = Critico;
            _entity.UserPassword.Concurrent = Concurrente;

            foreach (ListViewItem lvProtocol in clbCDProtocols.Items)
            {
                CommunicationDeviceProtocolEntity protocol = (CommunicationDeviceProtocolEntity)lvProtocol.Tag;

                bool existe = _entity.Protocols.Contains(protocol);

                if (lvProtocol.Checked && !existe)
                    _entity.Protocols.Add(protocol);

                if (!lvProtocol.Checked && existe)
                    _entity.Protocols.Remove(protocol);
            }

            // grabar

            int Id = CDUsrBL.Save(_entity, chkChgPwd.Checked, this.GetGruposSolicitudes(), this.GetGruposSeguimientos(), true);
            
            if (Id == 0)
            {
                MessageBox.Show("Hubo un error al grabar el Usuario de Base de Datos", "Usuarios de Equipos de Comunicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                
                return;
            }

            MessageBox.Show("Los datos se han guardado satisfactoriamente");

            this.DialogResult = DialogResult.OK;
        }

        private void chkChgPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChgPwd.Checked)
            {
                tPassword1.Enabled = true;
                tPassword2.Enabled = true;
                this.chkVisualizar.Enabled = true;
            }
            else
            {
                tPassword1.Enabled = false;
                tPassword2.Enabled = false;
                this.chkVisualizar.Enabled = false;
            }

        }

        private void cbEC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProtocolos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (m_FormType == FormType.Update || m_FormType == FormType.Delete)
            {
                _entity = CDUsrBL.Refresh(_entity);
                if (_entity.ModifyingUser != null &&
                    _entity.ModifyingUser.Username == new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
                {
                    _entity.ModifyingDate = null;
                    _entity.ModifyingUser = null;
                    CDUsrBL.Save(_entity, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                }
            }

        }
        #region GruposSolicitudes

        private void CargarGruposSolicitudes()
        {
            RequestGroupBusiness RqstGrpBL = new RequestGroupBusiness();
            RequestGroupEntityCollection _GruposSolicitudes;
            RqstGrpBL.FilActivos = true;
            _GruposSolicitudes = RqstGrpBL.GetAll(true);
            lvGruposSolicitudesNoAsociados.Items.Clear();
            foreach (RequestGroupEntity RqstGrpEnt in _GruposSolicitudes)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = RqstGrpEnt.Active ? 0 : 1;
                lviNuevo.Tag = RqstGrpEnt;
                lviNuevo.Text = RqstGrpEnt.RqstGrpName;
                lviNuevo.Name = RqstGrpEnt.RqstGrpName;
                lvGruposSolicitudesNoAsociados.Items.Add(lviNuevo);
            }
            lvGruposSolicitudesNoAsociados.Refresh();
            if (_entity.Id != 0)
            {
                RqstGrpPwdEntityCollection GruposAsignados = CDUsrBL.GetGruposSolicitudes(_entity);
                lvGruposSolicitudesAsociados.Items.Clear();
                foreach (RqstGrpPwdEntity RqstGrpEnt in GruposAsignados)
                {
                    if (RqstGrpEnt.RqstGrp.Active)
                    {
                        ListViewItem lviNuevo = new ListViewItem();
                        lviNuevo.ImageIndex = RqstGrpEnt.RqstGrp.Active ? 0 : 1;
                        lviNuevo.Text = RqstGrpEnt.RqstGrp.RqstGrpName;
                        lviNuevo.Tag = RqstGrpEnt.RqstGrp;
                        lvGruposSolicitudesAsociados.Items.Add(lviNuevo);
                        lvGruposSolicitudesNoAsociados.Items.RemoveByKey(lviNuevo.Text);
                    }
                }
                lvGruposSolicitudesAsociados.Refresh();
                lvGruposSolicitudesNoAsociados.Refresh();
            }
        }

        private void CargarGruposSeguimiento()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            FollowupRequestGroupEntityCollection _GruposSeguimiento;
            RqstGrpBL.FilActivos = true;
            _GruposSeguimiento = RqstGrpBL.GetAll(true);
            lvGruposSeguimientoNoAsociados.Items.Clear();
            foreach (FollowupRequestGroupEntity RqstGrpEnt in _GruposSeguimiento)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = RqstGrpEnt.Active ? 0 : 1;
                lviNuevo.Tag = RqstGrpEnt;
                lviNuevo.Text = RqstGrpEnt.Name;
                lviNuevo.Name = RqstGrpEnt.Name;
                lvGruposSeguimientoNoAsociados.Items.Add(lviNuevo);
            }
            lvGruposSeguimientoNoAsociados.Refresh();
            if (_entity.Id != 0)
            {
                FollowupRequestGroupPasswordEntityCollection GruposAsignados = CDUsrBL.GetGruposSeguimiento(_entity);
                lvGruposSeguimientoAsociados.Items.Clear();
                foreach (FollowupRequestGroupPasswordEntity RqstGrpEnt in GruposAsignados)
                {
                    if (RqstGrpEnt.FollowupRqstGrp.Active)
                    {
                        ListViewItem lviNuevo = new ListViewItem();
                        lviNuevo.ImageIndex = RqstGrpEnt.FollowupRqstGrp.Active ? 0 : 1;
                        lviNuevo.Text = RqstGrpEnt.FollowupRqstGrp.Name;
                        lviNuevo.Tag = RqstGrpEnt.FollowupRqstGrp;
                        lvGruposSeguimientoAsociados.Items.Add(lviNuevo);
                        lvGruposSeguimientoNoAsociados.Items.RemoveByKey(lviNuevo.Text);
                    }
                }
                lvGruposSeguimientoAsociados.Refresh();
                lvGruposSeguimientoNoAsociados.Refresh();
            }

        }



        private void btnAddGrupoSolicitud_Click(object sender, EventArgs e)
        {
            if (lvGruposSolicitudesNoAsociados.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesNoAsociados.SelectedItems)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSolicitudesAsociados.Items.Add(lviNuevo);
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesNoAsociados.SelectedItems)
            {
                lvGruposSolicitudesNoAsociados.Items.Remove(lviSeleccionado);
            }
        }

        private void btnAddAllGrupoSolicitud_Click(object sender, EventArgs e)
        {
            if (lvGruposSolicitudesNoAsociados.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesNoAsociados.Items)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSolicitudesAsociados.Items.Add(lviNuevo);
            }
            lvGruposSolicitudesNoAsociados.Items.Clear();

        }

        private void btnDelAllGrupoSolicitud_Click(object sender, EventArgs e)
        {
            if (lvGruposSolicitudesAsociados.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesAsociados.Items)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSolicitudesNoAsociados.Items.Add(lviNuevo);
            }
            lvGruposSolicitudesAsociados.Items.Clear();

        }

        private void btnDelGrupoSolicitud_Click(object sender, EventArgs e)
        {
            if (lvGruposSolicitudesAsociados.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesAsociados.SelectedItems)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSolicitudesNoAsociados.Items.Add(lviNuevo);
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSolicitudesAsociados.SelectedItems)
            {
                lvGruposSolicitudesAsociados.Items.Remove(lviSeleccionado);
            }

        }

        private void btnAddGrupoSeguimiento_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimientoNoAsociados.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoNoAsociados.SelectedItems)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSeguimientoAsociados.Items.Add(lviNuevo);
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoNoAsociados.SelectedItems)
            {
                lvGruposSeguimientoNoAsociados.Items.Remove(lviSeleccionado);
            }
        }

        private void btnAddAllGrupoSeguimiento_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimientoNoAsociados.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoNoAsociados.Items)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSeguimientoAsociados.Items.Add(lviNuevo);
            }
            lvGruposSeguimientoNoAsociados.Items.Clear();

        }

        private void btnDelAllGrupoSeguimiento_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimientoAsociados.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoAsociados.Items)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSeguimientoNoAsociados.Items.Add(lviNuevo);
            }
            lvGruposSeguimientoAsociados.Items.Clear();

        }

        private void btnDelGrupoSeguimiento_Click(object sender, EventArgs e)
        {
            if (lvGruposSeguimientoAsociados.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoAsociados.SelectedItems)
            {
                ListViewItem lviNuevo = new ListViewItem();
                lviNuevo.ImageIndex = lviSeleccionado.ImageIndex;
                lviNuevo.Tag = lviSeleccionado.Tag;
                lviNuevo.Text = lviSeleccionado.Text;
                for (int i = 1; i < lviSeleccionado.SubItems.Count; i++)
                {
                    lviNuevo.SubItems.Add(lviSeleccionado.SubItems[i]);
                }
                lvGruposSeguimientoNoAsociados.Items.Add(lviNuevo);
            }
            foreach (ListViewItem lviSeleccionado in lvGruposSeguimientoAsociados.SelectedItems)
            {
                lvGruposSeguimientoAsociados.Items.Remove(lviSeleccionado);
            }

        }

        private RequestGroupEntityCollection GetGruposSolicitudes()
        {
            RequestGroupEntityCollection GruposSolicitudes = new RequestGroupEntityCollection();
            for (int i = 0; i < lvGruposSolicitudesAsociados.Items.Count; i++)
            {
                GruposSolicitudes.Add((RequestGroupEntity)lvGruposSolicitudesAsociados.Items[i].Tag);
            }
            return GruposSolicitudes;
        }

        private FollowupRequestGroupEntityCollection GetGruposSeguimientos()
        {
            FollowupRequestGroupEntityCollection GruposSeguimientos = new FollowupRequestGroupEntityCollection();
            for (int i = 0; i < lvGruposSeguimientoAsociados.Items.Count; i++)
            {
                GruposSeguimientos.Add((FollowupRequestGroupEntity)lvGruposSeguimientoAsociados.Items[i].Tag);
            }
            return GruposSeguimientos;
        }

        #endregion

        #region HistorialCambios

        protected vwHistPwdChgEntityCollection _entities;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha de inicio (dd/mm/aaaa)";
            try
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                DateTime dTest;
                if (txtFDesde.Text.Trim() != "/  /")
                {
                    dTest = Convert.ToDateTime(txtFDesde.Text, dtfi);
                }
                if (txtFHasta.Text.Trim() != "/  /")
                {
                    strErrorMsg = "Verifique el formato de la fecha de fin (dd/mm/aaaa)";
                    dTest = Convert.ToDateTime(txtFHasta.Text, dtfi);
                }

                //DateTime FDesde = Convert.ToDateTime(txtFDesde.Text,
                ExecEntitiesRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErrorMsg, "Error en filtros de búsqueda");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();

        }

        private void CleanFilters()
        {
            this.txtFDesde.Text = "";
            this.txtFHasta.Text = "";
            this.lvLista.Items.Clear();
            this.lvLista.Refresh();

        }

        private void ExecEntitiesRefresh()
        {
            if (lvLista.Columns.Count == 0)
            {
                //throw new Exception("Se deben definir las columnas del ListView");
            }

            this.Cursor = Cursors.WaitCursor;
            this.lnkCancelar.Visible = true;
            this.pbDB.Visible = true;
            this.lblStatus.Text = "Buscando...";
            this.pnlFilters.Enabled = false;
            this.pnlList.Enabled = false;
            if (bwRefreshEntities.IsBusy)
            {
                bwRefreshEntities.CancelAsync();
            }
            else
            {
                this.bwRefreshEntities.RunWorkerAsync();
            }
        }

        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DBRefreshEntites();
        }
        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            //HistPasswordChangeBusiness HistPwdChgBL = new HistPasswordChangeBusiness();
            vwHistPwdChgBusiness HistPwdChgBL = new vwHistPwdChgBusiness();
            // seteo filtros
            int Folio = 0;
            _entities = HistPwdChgBL.GetAll(null, Folio, txtFDesde.Text, txtFHasta.Text, _entity);
        }

        /// <summary>
        /// Llama a la función que genera el array de LV Items y si hay items llama a la que hace el llenado
        /// usando el delegado
        /// </summary>
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }
        delegate void SetItemsAddRangeCallback(ListViewItem[] lvitems);

        /// <summary>
        /// Llena el Listview con los items pasados en el array
        /// </summary>
        /// <param name="lviArr">Array de Listview Items para llenar el Listview</param>
        private void SetLVItems(ListViewItem[] lviArr)
        {
            if (this.lvLista.InvokeRequired)
            {
                SetItemsAddRangeCallback d = new SetItemsAddRangeCallback(SetLVItems);
                this.Invoke(d, new object[] { lviArr });
            }
            else
            {
                this.lvLista.Items.Clear();
                if (lviArr.Length > 0)
                {

                    this.lvLista.Items.AddRange(lviArr);
                }
            }
        }

        /// <summary>
        /// Genera los list view items para llenar el list view
        /// </summary>
        /// <returns>Devuelve el arrary de list view items para llenar el listview</returns>
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (vwHistPwdChgEntity HistChgPwdEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();

                /*lviArr[i].Text = HistChgPwdEnt.Usuario; // HistChgPwdEnt.User.Username;
                lviArr[i].SubItems.Add(HistChgPwdEnt.UserType.Desc);
                lviArr[i].SubItems.Add(HistChgPwdEnt.DChange.ToString("dd/MM/yyyy HH:m:ss"));
                lviArr[i].SubItems.Add(HistChgPwdEnt.PhxUser.Fullname);
                lviArr[i].SubItems.Add(HistChgPwdEnt.PlainPassword);
                lviArr[i].Tag = HistChgPwdEnt;
                 * */

                lviArr[i].Text = HistChgPwdEnt.DChange.ToString("dd/MM/yyyy HH:m:ss");
                lviArr[i].SubItems.Add(HistChgPwdEnt.PhxUser.Fullname);
                lviArr[i].SubItems.Add(cAsterisk);
                //lviArr[i].SubItems.Add(HistChgPwdEnt.PlainPassword);
                lviArr[i].Tag = HistChgPwdEnt;


                i++;
            }
            return lviArr;

        }

        private void bwRefreshEntities_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                this.lblStatus.Text = "Cancelado";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                this.lblStatus.Text = "Listo"; // e.Result.ToString();
                this.lnkCancelar.Visible = false;
                this.pbDB.Visible = false;
                this.pnlFilters.Enabled = true;
                this.pnlList.Enabled = true;
                if (this.lvLista.Items.Count > 0)
                {
                    this.lvLista.Items[0].Selected = true;
                    this.lvLista.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Solicitudes

        private ArrayList _filEstados;
        private ArrayList _filGrupos;
        protected PasswordRequestEntityCollection _Solicitudes;

        private void PopulateRequestStates()
        {
            cbEstadoSolicitud.Items.Clear();
            RequestStateEntityCollection reqStates = new RequestStateBusiness().FillFilter();
            cbEstadoSolicitud.DataSource = reqStates;
            cbEstadoSolicitud.SelectedIndex = 0;
        }

        private void PopulateGrupoTareas()
        {
            cbGrupoTareas.Items.Clear();
            RequestGroupEntityCollection reqGroups = new RequestGroupBusiness().FillFilter();
            cbGrupoTareas.DisplayMember = "RqstGrpName";
            cbGrupoTareas.ValueMember = "Id";
            cbGrupoTareas.DataSource = reqGroups;
            cbGrupoTareas.SelectedIndex = 0;
        }

        private void btnBuscarSolicitudes_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha de inicio (dd/mm/aaaa)";
            try
            {
                ExecEntitiesSolicitudesRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErrorMsg, "Error en filtros de búsqueda");
            }
        }

        private void SetQueryFilters()
        {
            _filEstados = null;
            if (cbEstadoSolicitud.Items.Count > 0 && cbEstadoSolicitud.SelectedIndex > 0)
            {
                _filEstados = new ArrayList();
                _filEstados.Add(cbEstadoSolicitud.SelectedItem);
            }
            _filGrupos = null;
            if (cbGrupoTareas.Items.Count > 0 && cbGrupoTareas.SelectedIndex > 0)
            {
                _filGrupos = new ArrayList();
                _filGrupos.Add(cbGrupoTareas.SelectedItem);
            }

        }


        private void ExecEntitiesSolicitudesRefresh()
        {
            this.Cursor = Cursors.WaitCursor;
            this.lnkCancelarSolicitudes.Visible = true;
            this.pbDBSolicitudes.Visible = true;
            this.lblStatusSolicitudes.Text = "Buscando...";
            SetQueryFilters();
            this.pnlFiltersSolicitudes.Enabled = false;
            this.pnlListSolicitudes.Enabled = false;
            if (bwRefreshEntitiesSolicitudes.IsBusy)
            {
                bwRefreshEntitiesSolicitudes.CancelAsync();
            }
            else
            {
                this.bwRefreshEntitiesSolicitudes.RunWorkerAsync();
            }
        }

        private void bwRefreshEntitiesSolicitudes_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DBRefreshEntitesSolicitudes();
        }

        private void DBRefreshEntitesSolicitudes()
        {
            LoadEntitiesSolicitudes();
            RefreshEntitiesSolicitudesLV();
        }
        private void LoadEntitiesSolicitudes()
        {
            _Solicitudes = new PasswordRequestBusiness().GetPassRqst(_entity, _filEstados, txtNroSolicitud.Text, _filGrupos);
        }
        private void RefreshEntitiesSolicitudesLV()
        {
            ListViewItem[] lviArr = GenerateLVItemsSolicitudes();
            SetLVItemsSolicitudes(lviArr);
        }
        delegate void SetItemsAddRangeCallbackSolicitudes(ListViewItem[] lvitems);
        private void SetLVItemsSolicitudes(ListViewItem[] lviArr)
        {
            if (this.lvListaSolicitudes.InvokeRequired)
            {
                SetItemsAddRangeCallbackSolicitudes d = new SetItemsAddRangeCallbackSolicitudes(SetLVItemsSolicitudes);
                this.Invoke(d, new object[] { lviArr });
            }
            else
            {
                this.lvListaSolicitudes.Items.Clear();
                if (lviArr.Length > 0)
                {
                    this.lvListaSolicitudes.Items.AddRange(lviArr);
                }
            }
        }
        private ListViewItem[] GenerateLVItemsSolicitudes()
        {
            ListViewItem[] lviArr = new ListViewItem[this._Solicitudes.Count];
            int i = 0;
            foreach (PasswordRequestEntity reqpwd in this._Solicitudes)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = reqpwd.Id.ToString();
                lviArr[i].SubItems.Add(reqpwd.RqstUsrFullName);
                lviArr[i].SubItems.Add(reqpwd.RqstDateddmmyyyy.ToString());
                lviArr[i].SubItems.Add(reqpwd.RqstState.RqstStateDesc);
                lviArr[i].SubItems.Add(reqpwd.RequestDate.ToString("dd/MM/yyyy HH:m:ss"));
                string tmpString = "";
                // Determino la fecha según el estado
                switch (reqpwd.RqstState.Id)
                {
                    // Autorizada
                    case 2:
                    // Rechazada
                    case 3:
                        tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Visualizada
                    case 4:
                        tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Asignaciones
                    case 5:
                    case 6:
                    case 7:
                        tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Devuelta por el usuario
                    case 8:
                    // Devuelta por el administrador
                    case 9:
                        tmpString = ((DateTime)reqpwd.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Expirada
                    case 10:
                        tmpString = ((DateTime)reqpwd.ExpirationDate).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Cerrada
                    case 11:
                        tmpString = ((DateTime)reqpwd.CloseDate).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                }
                lviArr[i].SubItems.Add(tmpString);
                lviArr[i].Tag = reqpwd;
                i++;
            }
            return lviArr;
        }

        private void bwRefreshEntitiesSolicitudes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
            }
            else if (e.Cancelled)
            {
                this.lblStatusSolicitudes.Text = "Cancelado";
            }
            else
            {
                this.lblStatusSolicitudes.Text = "Listo"; // e.Result.ToString();
                this.lnkCancelarSolicitudes.Visible = false;
                this.pbDBSolicitudes.Visible = false;
                this.pnlFiltersSolicitudes.Enabled = true;
                this.pnlListSolicitudes.Enabled = true;
                if (this.lvListaSolicitudes.Items.Count > 0)
                {
                    this.lvListaSolicitudes.Items[0].Selected = true;
                    this.lvListaSolicitudes.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void MostrarReporteSolicitudes()
        {
            if (lvListaSolicitudes.SelectedItems.Count > 0)
            {
                ReporteDeUsoEntityCollection RptUsoLst = new ReporteDeUsoEntityCollection();
                for (int i = 0; i < lvListaSolicitudes.SelectedItems.Count; i++)
                {
                    RptUsoLst.Add((PasswordRequestEntity)lvListaSolicitudes.SelectedItems[i].Tag);
                }

                FRptUso Rpt = new FRptUso(RptUsoLst);
                Rpt.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }

        private void lvListaSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }

        #endregion

        private void btnBuscarSolicitudes_Click_1(object sender, EventArgs e)
        {
            ExecEntitiesSolicitudesRefresh();

        }

        private void btnLimpiarSolicitudes_Click(object sender, EventArgs e)
        {
            this.lvListaSolicitudes.Items.Clear();
            this.lvListaSolicitudes.Refresh();
            this.cbEstadoSolicitud.SelectedIndex = 0;
            this.cbGrupoTareas.SelectedIndex = 0;
            this.txtNroSolicitud.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();

        }
        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
            {
                return;
            }
            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;
            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            ((ListView)sender).Sort();

        }

        private void lvLista_DoubleClick(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count == 1)
            {

                if (((ListView)sender).SelectedItems[0].SubItems[2].Text != cAsterisk)
                    return;

                if (MessageBox.Show("Si visualiza la contraseña, se grabará un registro de log con este evento. Desea continuar?",
                    "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HistPasswordChangeAccessBusiness accessBL = new HistPasswordChangeAccessBusiness();
                    HistPasswordChangeAccessEntity accessE = new HistPasswordChangeAccessEntity();

                    accessE.HistChgPwd = new HistPasswordChangeEntity();
                    accessE.HistChgPwd.Id = ((vwHistPwdChgEntity)((ListView)sender).SelectedItems[0].Tag).Id;
                    accessE.PhxUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                    accessE.AccessDate = DateTime.Now;

                    int Id = accessBL.Save(accessE);
                    if (Id > 0)
                        ((ListView)sender).SelectedItems[0].SubItems[2].Text =
                            ((vwHistPwdChgEntity)((ListView)sender).SelectedItems[0].Tag).PlainPassword;
                    else
                        MessageBox.Show("Hubo un error al grabar log de visualización de contraseñas", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }

    }
}

