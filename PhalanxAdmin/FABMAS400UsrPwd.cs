using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxBL;
using System.Collections;

namespace PhalanxAdmin
{
    public partial class FABMAS400UsrPwd : PhalanxAdmin.FModalBase
    {
        #region Members
        public enum FormType
        {
            New,
            Update,
            View,
            Delete
        }
        private AS400Entity _AS400PCSel = null;
        private AS400UserBusiness m_AS400UserBusiness = null;
        private AS400UserEntity m_CurrentUser = null;
        private const string cAsterisk = "**********";


        private FormType m_FormType = FormType.View;
        #endregion
        #region Constructors
        public FABMAS400UsrPwd(string userlogon) : base()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

        }
        public FABMAS400UsrPwd(FormType formType, string userlogon) : this(userlogon)
        {
            InitializeComponent();

            this.Usuario = userlogon;
            m_FormType = formType;
            lvLista.ListViewItemSorter = new cwxSorter();

            m_AS400UserBusiness = new AS400UserBusiness(userlogon);
        }

       public FABMAS400UsrPwd(AS400UserEntity user, FormType formType, string userlogon): this(formType, userlogon)
        {
            user = m_AS400UserBusiness.Refresh(user);
            if (user.ModifyingDate != null && user.ModifyingUser != null)
            {
                if (user.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
                {
                    if (user.ModifyingDate.Value.AddMinutes(10) > new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate)
                    {
                        lblModifying.Text = "Esta contraseña está siendo modificada por " + user.ModifyingUser.Fullname + " desde el " + user.ModifyingDate.Value.ToShortDateString() + " a las " + user.ModifyingDate.Value.ToShortTimeString();
                        lblModifying.Visible = true;
                        formType = FormType.View;
                    }
                    else
                    {
                        lblModifying.Text = "Esta contraseña estuvo siendo modificada por " + user.ModifyingUser.Fullname + " desde el " + user.ModifyingDate.Value.ToShortDateString() + " a las " + user.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                        lblModifying.Visible = true;
                        if (formType == FormType.Update || m_FormType == FormType.Delete)
                        {
                            user.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                            user.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                            m_AS400UserBusiness.Update(user,  GetGruposSolicitudes(), GetGruposSeguimientos());
                        }
                    }
                }
                else
                {
                    lblModifying.Text = "Esta contraseña estuvo siendo modificada por usted el " + user.ModifyingDate.Value.ToShortDateString() + " a las " + user.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                    lblModifying.Visible = true;
                    if (formType == FormType.Update || m_FormType == FormType.Delete)
                    {
                        user.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                        user.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                        m_AS400UserBusiness.Update(user,  GetGruposSolicitudes(), GetGruposSeguimientos());
                    }
                }
            }
            else
            {
                lblModifying.Visible = false;
                if (formType == FormType.Update || m_FormType == FormType.Delete)
                {
                    user.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                    user.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario);
                    m_AS400UserBusiness.Update(user,  GetGruposSolicitudes(), GetGruposSeguimientos());
                }
            }
            m_FormType = formType;
            m_CurrentUser = user;
            _AS400PCSel = m_CurrentUser.AS400;
            txtEquipo.Text = m_CurrentUser.AS400.ServerName;
            UserActive = m_CurrentUser.ActiveUser;
            UserName = m_CurrentUser.Username;
            UserDescription = m_CurrentUser.Desc;
            Password = m_CurrentUser.UserPassword.Password;
            CriticalUser = m_CurrentUser.Critical;
            PasswordConcurrente = m_CurrentUser.UserPassword.Concurrent;
            lblFolioNro.Text = m_CurrentUser.Key;
        }
        #endregion
        #region Properties
        public string UserName
        {
            set { tBUsuario.Text = value; }
        }
        public string UserDescription
        {
            set { tBUserDescript.Text = value; }
        }
        public string Password
        {
            set
            {
                tPassword1.Text = m_AS400UserBusiness.DecryptPassword(value);
                tPassword2.Text = tPassword1.Text;
            }
        }
        public bool UserActive
        {
            set { cBoxActivo.Checked = value; }
        }

        public bool PasswordConcurrente
        {
            set { chkPwdConcurrente.Checked = value; }
        }

        public bool CriticalUser
        {
            set { chkUsuarioCritico.Checked = value; }
        }
        #endregion
        #region Methods
        public void ConfigureScreen()
        {
            switch (m_FormType)
            {
                case FormType.New:
                    {
                        chkChgPwd.Checked = true;
                        chkChgPwd.Enabled = false;
                        this.Title = "Nuevo Usuario y Contraseña";
                        this.Info = "";
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        tabControl1.TabPages.Remove(tabControl1.TabPages[4]);                        
                        tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
                        this.checkBoxVisualizar.Enabled = true;
                        break;
                    }
                case FormType.Update:
                    {
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        chkChgPwd.Checked = false;
                        chkChgPwd.Enabled = true;
                        chkChgPwd_CheckedChanged(null, null);
                        // Si el equipo no está habilitado no se puede habilitar
                        if (m_CurrentUser.AS400.Active == false)
                        {
                            cBoxActivo.Enabled = false;
                        }
                        this.Title = "Modificación de Usuario y Contraseña";
                        this.Info = m_CurrentUser.AS400.ServerName + " / " + m_CurrentUser.Username;

                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        break;
                    }
                case FormType.View:
                    {
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        tBUsuario.ReadOnly = true;
                        tBUserDescript.ReadOnly = true;
                        tPassword1.ReadOnly = true;
                        tPassword2.ReadOnly = true;
                        cBoxActivo.Enabled = false;
                        //btnAceptar.Visible = false;
                        // deshabilita boton cancelar
                        chkPwdConcurrente.Enabled = false;
                        chkUsuarioCritico.Enabled = false;
                        btnCancelar.Enabled = false;
                        chkChgPwd.Checked = false;
                        chkChgPwd.Enabled = false;
                        btnSelEquipo.Visible = false;
                        this.Title = "Visualización de Usuario y Contraseña";
                        this.Info = m_CurrentUser.AS400.ServerName + " / " + m_CurrentUser.Username;
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        pnlGruposSolicitudes.Visible = false;
                        pnlGruposSeguimientos.Visible = false;
                        break;
                    }
                case FormType.Delete:
                    {
                        chkChgPwd.Checked = false;
                        chkChgPwd.Enabled = false;
                        tBUsuario.ReadOnly = true;
                        tBUserDescript.ReadOnly = true;
                        tPassword1.ReadOnly = true;
                        tPassword2.ReadOnly = true;
                        cBoxActivo.Enabled = true;
                        chkPwdConcurrente.Enabled = false;
                        chkUsuarioCritico.Enabled = false;
                        btnSelEquipo.Visible = false;
                        this.Title = "Baja de Usuario y Contraseña";
                        this.Info = m_CurrentUser.AS400.ServerName + " / " + m_CurrentUser.Username;
                        CargarGruposSolicitudes();
                        CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        pnlGruposSolicitudes.Visible = false;
                        pnlGruposSeguimientos.Visible = false;
                        tabControl1.TabPages.Remove(tabControl1.TabPages[4]);
                        break;
                    }
            }
        }
        private bool verificarDatos()
        {
            if (_AS400PCSel == null)
            {
                MessageBox.Show("Debe seleccionar el equipo");
                return false;
            }
            if (tBUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar el Nombre de Usuario");
                return false;
            }
            else if (tPassword1.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un Password Válido");
                return false;
            }
            else if (tPassword2.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar la confirmación de la Contraseña");
                return false;
            }
            else if (tPassword1.Text != tPassword2.Text)
            {
                MessageBox.Show("Confirmación de Contraseña incorrecta");
                return false;
            }
            if (lvGruposSolicitudesAsociados.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un Grupo de Solicitudes asociado a este usuario");
                return false;
            }
            if (lvGruposSeguimientoAsociados.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un Grupo de Seguimiento de Solicitudes asociado a este usuario");
                return false;
            }
            if (tBUserDescript.Text.Length > 4000)
            {
                MessageBox.Show("La descripción no puede exceder los 4000 caracteres");
                return false;
            }

            return true;
        }
        private void ChangeUserState()
        {
            m_CurrentUser = m_AS400UserBusiness.Refresh(m_CurrentUser);
            if (m_CurrentUser.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
            {
                MessageBox.Show("Su sesión de edición expiró y la contraseña fue tomada por " + m_CurrentUser.ModifyingUser.Fullname + " el " + m_CurrentUser.ModifyingDate.Value.ToShortDateString() + " a las " + m_CurrentUser.ModifyingDate.Value.ToShortTimeString());
                return;
            }

            m_CurrentUser.ActiveUser = cBoxActivo.Checked;
            m_CurrentUser.ModifyingUser = null;
            m_CurrentUser.ModifyingDate = null;

            try
            {
                m_AS400UserBusiness.Update(m_CurrentUser,  GetGruposSolicitudes(), GetGruposSeguimientos());
                if (cBoxActivo.Checked)
                    MessageBox.Show("El Usuario ha sido Activado");
                else
                    MessageBox.Show("El Usuario ha sido Desactivado");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ha ocurrido un error al modificar los datos: " + Environment.NewLine + exp.Message);
            }
        }
        private string GetPassword()
        {
            string auxstr = tPassword1.Text.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }
        private void UpdateUser()
        {
            m_CurrentUser = m_AS400UserBusiness.Refresh(m_CurrentUser);
            if (m_CurrentUser.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
            {
                MessageBox.Show("Su sesión de edición expiró y la contraseña fue tomada por " + m_CurrentUser.ModifyingUser.Fullname + " el " + m_CurrentUser.ModifyingDate.Value.ToShortDateString() + " a las " + m_CurrentUser.ModifyingDate.Value.ToShortTimeString());
                return;
            }
            m_CurrentUser.ModifyingDate = null;
            m_CurrentUser.ModifyingUser = null;

            // si hay cambio de nombre de usuario se verifica que no exista
            if (m_CurrentUser.Username.Trim() != tBUsuario.Text.Trim())
            {
                if (m_AS400UserBusiness.Exists(m_CurrentUser.AS400, tBUsuario.Text))
                {
                    MessageBox.Show("El usuario ya existe");
                    this.DialogResult = DialogResult.None;
                    tBUsuario.SelectionStart = 0;
                    tBUsuario.SelectionLength = tBUsuario.Text.Length;
                    tBUsuario.Focus();
                    return;
                }
            }

            // si hay cambio de pwd
            if (chkChgPwd.Checked)
            {
                string pass = GetPassword();
                m_CurrentUser.UserPassword.Password = m_AS400UserBusiness.EncryptPassword(pass);
                m_CurrentUser.UserPassword.ApplyRealUser = checkBoxRealUser.Checked;
                m_CurrentUser.UserPassword.RealPassword = pass;
            }
            m_CurrentUser.UserPassword.Concurrent = chkPwdConcurrente.Checked;
            m_CurrentUser.Username = tBUsuario.Text.Trim();
            m_CurrentUser.Desc = tBUserDescript.Text.Trim();
            m_CurrentUser.ActiveUser = cBoxActivo.Checked;
            m_CurrentUser.Critical = chkUsuarioCritico.Checked;
            //m_CurrentUser.AS400 = _AS400PCSel;

            try
            {
                m_AS400UserBusiness.Update(m_CurrentUser, chkChgPwd.Checked,  GetGruposSolicitudes(), GetGruposSeguimientos(), true);
                MessageBox.Show("Se han modificado los datos satisfactoriamente");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ha ocurrido un error al modificar los datos: " + Environment.NewLine + exp.Message);
            }
        }
        private void NewUser()
        {
            UserPasswordEntity userPassword = new UserPasswordEntity();
            userPassword.StaticPwd = true;
            string password = GetPassword();
            userPassword.Password = m_AS400UserBusiness.EncryptPassword(password);
            userPassword.ApplyRealUser = checkBoxRealUser.Checked;
            userPassword.RealPassword = password;
            userPassword.Concurrent = chkPwdConcurrente.Checked;

            AS400UserEntity userEntity = new AS400UserEntity(); //Nuevo
            bool actualiza = false;
            if (m_AS400UserBusiness.Exists(_AS400PCSel, tBUsuario.Text.Trim()))
            {
                MessageBox.Show("El usuario ya existe");
                this.DialogResult = DialogResult.None;
                tBUsuario.SelectionStart = 0;
                tBUsuario.SelectionLength = tBUsuario.Text.Length;
                tBUsuario.Focus();
                return;
            }

            userEntity.Username = tBUsuario.Text.Trim();
            userEntity.AS400 = _AS400PCSel;
            userEntity.UserPassword = userPassword;
            userEntity.UserType = m_AS400UserBusiness.AS400LocalUserType;
            userEntity.ActiveUser = cBoxActivo.Checked;
            userEntity.Desc = tBUserDescript.Text.Trim();
            userEntity.Critical = chkUsuarioCritico.Checked;

            try
            {
                m_AS400UserBusiness.Create(userEntity, true,  GetGruposSolicitudes(), GetGruposSeguimientos());
                if (actualiza)
                    MessageBox.Show("Usuario actualizado satisfactoriamente");
                else
                    MessageBox.Show("Usuario y Contraseña creada satisfactoriamente");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ha ocurrido un error al crear Usuario y Contraseña: " + Environment.NewLine + exp.Message);
            }
        }
        #endregion

        #region Events
        private void chkChgPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChgPwd.Checked)
            {
                checkBoxRealUser.Enabled = true;
                tPassword1.Enabled = true;
                tPassword2.Enabled = true;
                this.checkBoxVisualizar.Enabled = true;
            }
            else
            {
                checkBoxRealUser.Enabled = false;
                tPassword1.Enabled = false;
                tPassword2.Enabled = false;
                this.checkBoxVisualizar.Enabled = false;
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (m_FormType == FormType.View)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            if (!verificarDatos())
                this.DialogResult = DialogResult.None;
            else
            {
                switch (m_FormType)
                {
                    case FormType.New:
                        {
                            NewUser();
                            break;
                        }
                    case FormType.Update:
                        {
                            UpdateUser();
                            break;
                        }
                    case FormType.Delete:
                        {
                            ChangeUserState();
                            break;
                        }
                }
            }
        }
        private void checkBoxVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (m_FormType == FormType.Update && checkBoxVisualizar.Tag == null &&
                   checkBoxVisualizar.Checked)
            {
                if (MessageBox.Show("Si visualiza la contraseña, se grabará un registro de log con este evento. Desea continuar?",
                    "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    checkBoxVisualizar.Tag = "logueado";

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
                    checkBoxVisualizar.Checked = false;
                    return;
                }
            }

            if (checkBoxVisualizar.Checked)
            {
                tPassword1.PasswordChar = new char();
                tPassword2.PasswordChar = new char();
                tPassword1.Text = GetPassword();
                tPassword2.Text = tPassword1.Text;
            }
            else
            {
                tPassword1.PasswordChar = '*';
                tPassword2.PasswordChar = '*';
            }
            tPassword1.Refresh();
            tPassword2.Refresh();
        }
        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;
        }
        private void btnSelEquipo_Click(object sender, EventArgs e)
        {
            FSelEquipo FormSelAS400PC = new FSelEquipo();
            FormSelAS400PC.OnlyAS400Pc = true;
            if (FormSelAS400PC.ShowDialog() == DialogResult.OK)
            {
                _AS400PCSel = FormSelAS400PC.AS400PCSelected;
                txtEquipo.Text = _AS400PCSel.ServerName;
            }

        }
        #endregion

        private void FABMAS400UsrPwd_Load(object sender, EventArgs e)
        {
            ConfigureScreen();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (m_FormType == FormType.Update || m_FormType == FormType.Delete)
            {
                m_CurrentUser = m_AS400UserBusiness.Refresh(m_CurrentUser);
                if (m_CurrentUser.ModifyingUser.Username == new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(this.Usuario).Username)
                {
                    m_CurrentUser.ModifyingDate = null;
                    m_CurrentUser.ModifyingUser = null;
                    m_AS400UserBusiness.Update(m_CurrentUser,  GetGruposSolicitudes(), GetGruposSeguimientos());
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
            if (m_CurrentUser != null)
            {
                RqstGrpPwdEntityCollection GruposAsignados = m_AS400UserBusiness.GetGruposSolicitudes(m_CurrentUser);
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
            if (m_CurrentUser != null)
            {
                FollowupRequestGroupPasswordEntityCollection GruposAsignados = m_AS400UserBusiness.GetGruposSeguimiento(m_CurrentUser);
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
            for (int i=0;i<lvGruposSolicitudesAsociados.Items.Count;i++)
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
            _entities = HistPwdChgBL.GetAll(null , Folio, txtFDesde.Text, txtFHasta.Text, m_CurrentUser);
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
            _Solicitudes = new PasswordRequestBusiness().GetPassRqst(m_CurrentUser, _filEstados, txtNroSolicitud.Text, _filGrupos);
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

          private void button3_Click_1(object sender, EventArgs e)
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

