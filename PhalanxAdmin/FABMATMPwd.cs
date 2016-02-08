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
    public partial class FABMATMPwd : PhalanxAdmin.FModalBase
    {
        ATMUserEntity _entity = new ATMUserEntity();
        ATMUserBusiness ATMUsrBL = new ATMUserBusiness();
        FollowupRequestGroupEntity _GrupoSeguimDefecto;
        FollowupRequestGroupEntityCollection _GruposSeguimientoSolic = new FollowupRequestGroupEntityCollection();
        //FollowupRequestGroupPasswordEntityCollection _GruposSeguimientoSolic = new FollowupRequestGroupPasswordEntityCollection();
        RequestGroupEntityCollection _GruposSolic = new RequestGroupEntityCollection();

        bool _readOnly = false;

        public enum FormType
        {
            New,
            Update,
            View,
            Delete
        }

        private FormType m_FormType = FormType.View;


        public FABMATMPwd(FormType formType)
        {
            InitializeComponent();

            m_FormType = formType;
            lvLista.ListViewItemSorter = new cwxSorter();
        }


        public FABMATMPwd(ATMUserEntity ATMUsr, bool ReadOnly, FormType formType): this(formType)
        {
            
            ATMUsr = ATMUsrBL.Refresh(ATMUsr);
            if (ATMUsr.ModifyingDate != null)
            {
                if (ATMUsr.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Username)
                {
                    if (ATMUsr.ModifyingDate.Value.AddMinutes(10) > new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate)
                    {
                        lblModifying.Text = "Esta contraseña está siendo modificada por " + ATMUsr.ModifyingUser.Fullname + " desde el " + ATMUsr.ModifyingDate.Value.ToShortDateString() + " a las " + ATMUsr.ModifyingDate.Value.ToShortTimeString();
                        lblModifying.Visible = true;
                        formType = FormType.View;
                        ReadOnly = true;
                    }
                    else
                    {
                        lblModifying.Text = "Esta contraseña estuvo siendo modificada por " + ATMUsr.ModifyingUser.Fullname + " desde el " + ATMUsr.ModifyingDate.Value.ToShortDateString() + " a las " + ATMUsr.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                        lblModifying.Visible = true;
                        if (formType == FormType.Update || m_FormType == FormType.Delete)
                        {
                            ATMUsr.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                            ATMUsr.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            ATMUsrBL.Save(ATMUsr, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                        }
                    }
                }
                else
                {
                    lblModifying.Text = "Esta contraseña estuvo siendo modificada por usted el " + ATMUsr.ModifyingDate.Value.ToShortDateString() + " a las " + ATMUsr.ModifyingDate.Value.ToShortTimeString() + " pero no se finalizó la sesión";
                    lblModifying.Visible = true;
                    if (formType == FormType.Update || m_FormType == FormType.Delete)
                    {
                        ATMUsr.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                        ATMUsr.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                        ATMUsrBL.Save(ATMUsr, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                    }
                }
            }
            else
            {
                lblModifying.Visible = false;
                if (formType == FormType.Update || m_FormType == FormType.Delete)
                {
                    ATMUsr.ModifyingDate = new PhalanxDAL.Factories.GetDateFactory().GetDate().GetDate;
                    ATMUsr.ModifyingUser = new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    ATMUsrBL.Save(ATMUsr, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                }
            }

            m_FormType = formType;
            _entity = ATMUsr;
            _readOnly = ReadOnly;
        }


        public void ConfigureScreen()
        {
            switch (m_FormType)
            {
                case FormType.New:
                    {
                        this.Title = "Nuevo Usuario y Contraseña";
                        //CargarGruposSolicitudes();
                        //CargarGruposSeguimiento();
                        //tabControl1.TabPages.Remove(tabControl1.TabPages[4]);
                        //tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
                        break;
                    }
                case FormType.Update:
                    {
                        this.Title = "Modificación de Usuario y Contraseña";
                        //CargarGruposSolicitudes();
                        //CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        break;
                    }
                case FormType.View:
                    {
                        this.Title = "Visualización de Usuario y Contraseña";
                        //CargarGruposSolicitudes();
                        //CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        PopulateRequestStates();
                        PopulateGrupoTareas();
                        ExecEntitiesSolicitudesRefresh();
                        break;
                    }
                case FormType.Delete:
                    {
                        this.Title = "Baja de Usuario y Contraseña";
                        //CargarGruposSolicitudes();
                        //CargarGruposSeguimiento();
                        ExecEntitiesRefresh();
                        tabControl1.TabPages.Remove(tabControl1.TabPages[4]);
                        break;
                    }
            }
        }

        private void FABMATMPwd_Load(object sender, EventArgs e)
        {
            if (m_FormType == FormType.New)
            {
                /// chequear si está realizada la parametrización del grupo de seguimiento por defecto
                _GrupoSeguimDefecto = new FollowupRequestGroupDefaultBusiness().GetDefaultFollowupRqstGrpATMs();
                if (_GrupoSeguimDefecto == null)
                {
                    MessageBox.Show("No hay grupo de seguimiento de solicitudes por defecto asignado a los usuarios del ambiente ATM"
                    , "Usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                /// asigna grupo de seguimiento por defecto
                _GruposSeguimientoSolic.Add(_GrupoSeguimDefecto);

                CargarGruposSolicitudes();
                if (cbGSRegion.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos de solicitudes del ambiente ATM para GS Región"
                       , "Usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }

            base.Title = "Contraseña de ATM";
            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;

                chkChgPwd.Checked = false;
                chkChgPwd.Enabled = false;
            }
            else
            {
                chkChgPwd.Checked = false;
                chkChgPwd.Enabled = true;
            }

            if (_entity.Id == 0)
            {
                // es un nuevo registro
                // si no es visualización cargo los combos
                chkChgPwd.Checked = true;
                chkChgPwd.Enabled = false;

            }
            else // si es modif o visualización
            {
                CargarGruposSeguimiento();
                CargarGruposSolicitudes();
                if (cbGSRegion.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos de solicitudes del ambiente ATM para GS Región"
                       , "Usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                // no es uno nuevo, cargo los datos
                txtATMName.Text = _entity.ATMName;
                txtComponente.Text = _entity.Componente;
                txtUsername.Text = _entity.Username;
                txtDescrip.Text = _entity.Desc;
                string strPwd = ATMUsrBL.DecryptPassword(_entity.UserPassword.Password);
                tPassword1.Text = strPwd;
                tPassword2.Text = strPwd;
                chkActivo.Checked = _entity.ActiveUser;

                //Agregado MG
                chkPwdConcurrente.Checked = _entity.UserPassword.Concurrent;
                chkPwdConcurrente.Enabled = !_readOnly;
                chkUsuarioCritico.Checked = _entity.Critical;
                chkUsuarioCritico.Enabled = !_readOnly;


                    lblFolioNro.Text = _entity.Key;

                if (_readOnly)
                {
                    // hace readonly los campos
                    txtATMName.ReadOnly = true;
                    txtComponente.ReadOnly = true;
                    txtUsername.BackColor = txtComponente.BackColor;
                    //txtUsername.ReadOnly = true;
                    txtDescrip.ReadOnly = true;
                    tPassword1.ReadOnly = true;
                    tPassword2.ReadOnly = true;
                    chkActivo.Enabled = false;
                    cbGSRegion.DropDownStyle = ComboBoxStyle.DropDown;
                    cbGSRegion.Enabled = false;
                    if (_GruposSolic.Count > 0)
                    {
                        cbGSRegion.Text = _GruposSolic[0].RqstGrpName;
                    }
                }
                else
                {
                    // si es modif cargo los combos
                    if (_GruposSolic.Count > 0)
                    {
                        
                        cbGSRegion.SelectedValue = _GruposSolic[0].Id;
                    }
                }
            }
            txtGrpSeguim.Text = _GruposSeguimientoSolic[0].Name;
            chkChgPwd_CheckedChanged(null, null);
            ConfigureScreen();
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
                _entity = ATMUsrBL.Refresh(_entity);
                if (_entity.ModifyingUser.Username != new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Username)
                {
                    MessageBox.Show("Su sesión de edición expiró y la contraseña fue tomada por " + _entity.ModifyingUser.Fullname + " el " + _entity.ModifyingDate.Value.ToShortDateString() + " a las " + _entity.ModifyingDate.Value.ToShortTimeString());
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                _entity.ModifyingDate = null;
                _entity.ModifyingUser = null;
            }

            // chequear campos obligatorios
            // ATM
            if (txtATMName.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el ID del ATM");
                this.DialogResult = DialogResult.None;
                txtATMName.Focus();
                return;
            }
            // Componente
            if (txtComponente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el campo Componente");
                this.DialogResult = DialogResult.None;
                txtComponente.Focus();
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

            //if (lvGruposSolicitudesAsociados.Items.Count == 0)
            //{
            //    MessageBox.Show("Debe seleccionar al menos un Grupo de Solicitudes asociado a este usuario");
            //    return;
            //}
            //if (lvGruposSeguimientoAsociados.Items.Count == 0)
            //{
            //    MessageBox.Show("Debe seleccionar al menos un Grupo de Seguimiento de Solicitudes asociado a este usuario");
            //    return;
            //}



            // verificar que el usuario no exista para esa BD
            if (_entity.Id == 0 || txtUsername.Text.Trim() != _entity.Username) // es un alta o es modif pero cambió el nombre de usuario
            {
                if (ATMUsrBL.Exists(txtATMName.Text.Trim(), txtUsername.Text.Trim()))
                {
                    MessageBox.Show("El usuario ya existe");
                    this.DialogResult = DialogResult.None;
                    //txtUsername.SelectionStart = 0;
                    //txtUsername.SelectionLength = txtUsername.Text.Length;
                    //txtUsername.Focus();
                    return;
                }
            }

            // asignar datos a la entity
            _entity.ATMName = txtATMName.Text.Trim();
            _entity.Componente = txtComponente.Text.Trim();
            _entity.Desc = txtDescrip.Text;
            _entity.Username = txtUsername.Text.Trim();
            if (chkChgPwd.Checked)
            {
                _entity.UserPassword.Password = ATMUsrBL.EncryptPassword(tPassword1.Text);
            }
            _entity.ActiveUser = chkActivo.Checked;

            // Agregado MG
            _entity.Critical = chkUsuarioCritico.Checked;
            _entity.UserPassword.Concurrent = chkPwdConcurrente.Checked;

            // grabar
            
            int Id = ATMUsrBL.Save(_entity, chkChgPwd.Checked,  (int)cbGSRegion.SelectedValue, _GruposSeguimientoSolic);
            if (Id > 0)
            {
                _entity.Id = Id;
            }
            else
            {
                MessageBox.Show("Hubo un error al grabar el Usuario de ATM", "Usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void chkChgPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChgPwd.Checked)
            {
                tPassword1.Enabled = true;
                tPassword2.Enabled = true;
            }
            else
            {
                tPassword1.Enabled = false;
                tPassword2.Enabled = false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (m_FormType == FormType.Update || m_FormType == FormType.Delete)
            {
                _entity = ATMUsrBL.Refresh(_entity);
                if (_entity.ModifyingUser.Username == new PhalanxDAL.Factories.PhxUsersFactory().GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Username)
                {
                    _entity.ModifyingDate = null;
                    _entity.ModifyingUser = null;
                    ATMUsrBL.Save(_entity, false,  this.GetGruposSolicitudes(), this.GetGruposSeguimientos());
                }
            }


        }

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
                lviArr[i].SubItems.Add(HistChgPwdEnt.PlainPassword);
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
                        if (reqpwd.Auth1Date != null)
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Visualizada
                    case 4:
                        if (reqpwd.Auth1Date != null)
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Asignaciones
                    case 5:
                    case 6:
                    case 7:
                        if (reqpwd.Auth1Date != null)
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Devuelta por el usuario
                    case 8:
                    // Devuelta por el administrador
                    case 9:
                        if (reqpwd.ReturnDate != null)
                            tmpString = ((DateTime)reqpwd.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Expirada
                    case 10:
                        if (reqpwd.ExpirationDate != null)
                            tmpString = ((DateTime)reqpwd.ExpirationDate).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    // Cerrada
                    case 11:
                        if (reqpwd.CloseDate != null)
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

        private void lvListaSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }


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
        #endregion

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

        private RequestGroupEntityCollection GetGruposSolicitudes()
        {
            RequestGroupEntityCollection GruposSolicitudes = new RequestGroupEntityCollection();
            //for (int i = 0; i < lvGruposSolicitudesAsociados.Items.Count; i++)
            //{
            //    GruposSolicitudes.Add((RequestGroupEntity)lvGruposSolicitudesAsociados.Items[i].Tag);
            //}
            return GruposSolicitudes;
        }

        private FollowupRequestGroupEntityCollection GetGruposSeguimientos()
        {
            FollowupRequestGroupEntityCollection GruposSeguimientos = new FollowupRequestGroupEntityCollection();
            //for (int i = 0; i < lvGruposSeguimientoAsociados.Items.Count; i++)
            //{
            //    GruposSeguimientos.Add((FollowupRequestGroupEntity)lvGruposSeguimientoAsociados.Items[i].Tag);
            //}
            return GruposSeguimientos;
        }

        private void txtATMName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtATMName.Text + "_" + txtComponente.Text;
        }

        private void txtComponente_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtATMName.Text + "_" + txtComponente.Text;
        }

        private void CargarGruposSolicitudes()
        {
            RequestGroupBusiness RqstGrpBL = new RequestGroupBusiness();
            RqstGrpBL.FilActivos = true;
            RequestGroupEntityCollection GruposSolicitudes;
            GruposSolicitudes = RqstGrpBL.GetATMs();
            cbGSRegion.DataSource = null;
            cbGSRegion.Items.Clear();
            cbGSRegion.DataSource = GruposSolicitudes;
            ATMUserBusiness ATMUsrBL = new ATMUserBusiness();
            if (_entity.Id > 0)
            {
                RqstGrpPwdEntityCollection RGPEC = ATMUsrBL.GetGruposSolicitudes(_entity);
                foreach (RqstGrpPwdEntity RqstGrpE in RGPEC)
                {
                    _GruposSolic.Add(RqstGrpE.RqstGrp);
                }
            }
        }

        private void CargarGruposSeguimiento()
        {
            ATMUserBusiness ATMUsrBL = new ATMUserBusiness();            
            FollowupRequestGroupPasswordEntityCollection FRGPEC = ATMUsrBL.GetGruposSeguimiento(_entity);
            foreach (FollowupRequestGroupPasswordEntity FRqstGrpE in FRGPEC)
            {
                _GruposSeguimientoSolic.Add(FRqstGrpE.FollowupRqstGrp);
            }

        }

    }
}

