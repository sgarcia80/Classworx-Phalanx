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

namespace PhalanxAdmin
{
    public partial class FABMGrpsSeguimSolic : PhalanxAdmin.FModalBase
    {
        FollowupRequestGroupEntity _entity = new FollowupRequestGroupEntity();
        bool _readOnly = false;
        bool _ModificaPwd = false;
        bool _ModificaUsrs = false;
        PhxUserEntity m_Approver;

        public FABMGrpsSeguimSolic()
        {
            InitializeComponent();
            lvAppPwdDB.ListViewItemSorter = new cwxSorter();
            lvAppPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvAS400PwdDB.ListViewItemSorter = new cwxSorter();
            lvAS400PwdGrupo.ListViewItemSorter = new cwxSorter();
            lvDbPwdDB.ListViewItemSorter = new cwxSorter();
            lvDbPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvUnixPwdDB.ListViewItemSorter = new cwxSorter();
            lvUnixPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvWinPwdDB.ListViewItemSorter = new cwxSorter();
            lvWinPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvECPwdDB.ListViewItemSorter = new cwxSorter();
            lvECPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvATMPwdDB.ListViewItemSorter = new cwxSorter();
            lvATMPwdGrupo.ListViewItemSorter = new cwxSorter();
            lvUsuariosDB.ListViewItemSorter = new cwxSorter();
            lvUsuariosGrupo.ListViewItemSorter = new cwxSorter();
        }
        public FABMGrpsSeguimSolic(FollowupRequestGroupEntity RqstGrp, bool ReadOnly, string userlogon)
            : this()
        {
            _entity = RqstGrp;
            _readOnly = ReadOnly;

            this.Usuario = userlogon;

        }

        private void FABMGrpsSeguimSolic_Load(object sender, EventArgs e)
        {
            base.Title = "Grupo de Seguimientos de Solicitudes";
            /// las contraseñas de ATMs siempre son readonly y se pusieron los controles
            /// de DB por si se cambia la lógica
            pnlATMPwdDB.Visible = false;

            // si es visualización
            if (_readOnly)
            {
                // deshabilita boton cancelar
                btnCancelar.Enabled = false;
                // muestra panel de botón aceptar y dockea el panel

                pnlWinPwdDB.Visible = false;
                pnlDbPwdDB.Visible = false;
                pnlUnixPwdDB.Visible = false;
                pnlAS400PwdDB.Visible = false;
                pnlAppPwdDB.Visible = false;
                pnlECPwdDB.Visible = false;
                pnlUsuarios.Visible = false;
                chkActivo.Enabled = false;
            }
            else
            {
                // carga combos de autorizadores
                /*if (!CargarComboAuth1())
                {
                    // no hay usuarios con rol de autorizador
                    tabSolic.Enabled = false;

                }
                else
                {
                    CargarComboAuth2();
                    CargarWinPwdDelGrupo();
                }*/
            }

            if (_entity.Id == 0)
            {
                chkActivo.Checked = true;
            }
            else
            {
                // muestra los datos
                txtGroupName.Text = _entity.Name;
                chkActivo.Checked = _entity.Active;
                /*
                txtUserName.Text = _entity.Username;
                txtFullName.Text = _entity.Fullname;
                txtEmail.Text = _entity.Email;
                cbDominio.Text = _entity.Domain;
                 */

                chkAprobAutomatica.Checked = _entity.AutoApproval;
                if (_entity.Approver != null)
                {
                    m_Approver = _entity.Approver;
                    txtResponsible.Text = _entity.Approver.Fullname + " (" + _entity.Approver.Username + ")";
                }

                PhxUserBusiness UsrBL = new PhxUserBusiness();
                //chkAprobAutomatica.Visible = UsrBL.AccParamConfigViewPassword(this.Usuario);

                if (_readOnly)
                {
                    txtGroupName.ReadOnly = true;
                    pnlWinPwdDB.Visible = false;
                    pnlDbPwdDB.Visible = false;
                    pnlAppPwdDB.Visible = false;
                    chkActivo.Enabled = false;
                }
                else if (_entity.Active == false)
                {
                    pnlWinPwdDB.Visible = false;
                    pnlDbPwdDB.Visible = false;
                    pnlUnixPwdDB.Visible = false;
                    pnlAS400PwdDB.Visible = false;
                    pnlAppPwdDB.Visible = false;
                    pnlECPwdDB.Visible = false;
                    pnlUsuarios.Visible = false;
                    txtGroupName.ReadOnly = true;
                    pnlWinPwdDB.Visible = false;
                    pnlDbPwdDB.Visible = false;
                    pnlAppPwdDB.Visible = false;
                    // si está inactivo solo deja el cambio de estado habilitado
                }
            }
            if (_entity.Id > 0)
            {
                CargarWinPwdDelGrupo();
                CargarDbPwdDelGrupo();
                CargarAppPwdDelGrupo();
                CargarUnixPwdDelGrupo();
                CargarAS400PwdDelGrupo();
                CargarECPwdDelGrupo();
                CargarUsuariosDelGrupo();
                CargarATMPwdDelGrupo();
            }
            if (!_readOnly)
            {
                /*Modificado en Version 15 para que no levante directamente todos los datos
                CargarWinPwdDB();
                CargarDbPwdDB();
                CargarAppPwdDB();
                CargarUnixPwdDB();
                CargarAS400PwdDB();
                CargarECPwdDB();
                 * */
            }
            //CargarPermisosDelUsuario();
            //CargarPermisosDB();
            //CargarGruposDelUsuario();
            //CargarGruposDB();

        }

        private void CargarATMPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvATMPwdGrupo.Items.AddRange(GenerarLVItmsATMPwd(RqstGrpBL.LoadATMPwds(_entity)));
        }

        private ListViewItem[] GenerarLVItmsATMPwd(IList<ATMUserEntity> ATMUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[ATMUsrLst.Count];
            int i = 0;
            foreach (ATMUserEntity ATMUsrEnt in ATMUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(ATMUsrEnt.ATMName);
                lviArr[i].SubItems.Add(ATMUsrEnt.Username);
                lviArr[i].SubItems.Add(ATMUsrEnt.Desc);
                lviArr[i].Text = ATMUsrEnt.Key;
                lviArr[i].Tag = ATMUsrEnt;
                i++;
            }
            return lviArr;
        }

        #region Passwords de Windows
        private void CargarWinPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvWinPwdGrupo.Items.AddRange(GenerarLVItmsWinPwd(RqstGrpBL.LoadActiveWinPwds(_entity)));
        }
        private void CargarWinPwdDB()
        {
            // traigo todos los roles de la base
            WinLocalUserBusiness WinPwdBL = new WinLocalUserBusiness();
            WinPwdBL.GetGruposSeguimAsignados = true;
            WinPwdBL.FilUsuariosActivos = true;
            WinLocalUserEntityCollection WinPwdEC = WinPwdBL.GetAll();
            IList<WinLocalUserEntity> WinPwdAAsignarALvDB = new List<WinLocalUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (WinLocalUserEntity WinLocUsrEnt in WinPwdEC)
            {

                /*if (!lvWinPwdGrupo.Items.Contains(lviAux))
                {
                    WinPwdAAsignarALvDB.Add(WinLocUsrEnt);
                }*/

                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvWinPwdGrupo.Items)
                {
                    if (((WinLocalUserEntity)lviPermisosUsr.Tag).Id == WinLocUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    //WinPwdAAsignarALvDB.Add(WinLocUsrEnt);
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(WinLocUsrEnt.Domain);
                    lviAux.SubItems.Add(WinLocUsrEnt.PCName);
                    lviAux.SubItems.Add(WinLocUsrEnt.Username);
                    lviAux.SubItems.Add(WinLocUsrEnt.Desc);
                    lviAux.SubItems.Add(WinLocUsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = WinLocUsrEnt.Key;
                    lviAux.Tag = WinLocUsrEnt;

                    lvWinPwdDB.Items.Add(lviAux);
                }
            }
            lvWinPwdDB.Items.AddRange(GenerarLVItmsWinPwd(WinPwdAAsignarALvDB));

        }
        private void PasarWinPwdDeDBaUsr()
        {
            if (lvWinPwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpWinPwd = new ListViewItem();
                lviGrpWinPwd.Tag = lviDB.Tag;
                lviGrpWinPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                /*
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                lvWinPwdGrupo.Items.Add(lviGrpWinPwd);
            }
            foreach (ListViewItem lviDB in lvWinPwdDB.SelectedItems)
            {
                lvWinPwdDB.Items.Remove(lviDB);
            }
            _ModificaPwd = true;
        }
        private void PasarTodoWinPwdDeDBaUsr()
        {
            if (lvWinPwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpWinPwd = new ListViewItem();
                lviGrpWinPwd.Tag = lviDB.Tag;
                lviGrpWinPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                /*
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                lvWinPwdGrupo.Items.Add(lviGrpWinPwd);
            }
            lvWinPwdDB.Items.Clear();
            _ModificaPwd = true;

        }
        private void PasarWinPwdDeGrpaDB()
        {
            if (lvWinPwdGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpWinPwd = new ListViewItem();
                lviGrpWinPwd.Tag = lviDB.Tag;
                lviGrpWinPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                /*
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                lvWinPwdDB.Items.Add(lviGrpWinPwd);
            }
            foreach (ListViewItem lviDB in lvWinPwdGrupo.SelectedItems)
            {
                lvWinPwdGrupo.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }
        private void PasarTodoWinPwdDeGrpaDB()
        {
            if (lvWinPwdGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpWinPwd = new ListViewItem();
                lviGrpWinPwd.Tag = lviDB.Tag;
                lviGrpWinPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                /*
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                lvWinPwdDB.Items.Add(lviGrpWinPwd);
            }
            lvWinPwdGrupo.Items.Clear();
            _ModificaPwd = true;

        }

        private ListViewItem[] GenerarLVItmsWinPwd(IList<WinLocalUserEntity> WinLocUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[WinLocUsrLst.Count];
            int i = 0;
            foreach (WinLocalUserEntity WinLocUsrEnt in WinLocUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(WinLocUsrEnt.Domain);
                lviArr[i].SubItems.Add(WinLocUsrEnt.PCName);
                lviArr[i].SubItems.Add(WinLocUsrEnt.Username);
                lviArr[i].SubItems.Add(WinLocUsrEnt.Desc);
                lviArr[i].Text = WinLocUsrEnt.Key;
                lviArr[i].Tag = WinLocUsrEnt;
                i++;
            }
            return lviArr;
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            PasarWinPwdDeDBaUsr();
        }

        private void lvWinPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarWinPwdDeDBaUsr();
        }

        private void btnAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoWinPwdDeDBaUsr();
        }

        private void btnDelRole_Click(object sender, EventArgs e)
        {
            PasarWinPwdDeGrpaDB();
        }

        private void lvWinPwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarWinPwdDeGrpaDB();
            }
        }

        private void btnDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoWinPwdDeGrpaDB();
        }

        #endregion

        #region Passwords de Base de Datos
        private void CargarDbPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvDbPwdGrupo.Items.AddRange(GenerarLVItmsDbPwd(RqstGrpBL.LoadActiveDbPwds(_entity)));
        }
        private void CargarDbPwdDB()
        {
            // traigo todos los roles de la base
            DatabaseUserBusiness DbPwdBL = new DatabaseUserBusiness();
            DbPwdBL.GetGruposSeguimAsignados = true;
            DbPwdBL.FilUsuariosActivos = true;
            DatabaseUserEntityCollection DbPwdEC = DbPwdBL.GetAll();
            IList<DatabaseUserEntity> DbPwdAAsignarALvDB = new List<DatabaseUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (DatabaseUserEntity DbUsrEnt in DbPwdEC)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvDbPwdGrupo.Items)
                {
                    if (((DatabaseUserEntity)lviPermisosUsr.Tag).Id == DbUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(DbUsrEnt.Username);
                    lviAux.SubItems.Add(DbUsrEnt.Db.Type.Name);
                    lviAux.SubItems.Add(DbUsrEnt.Db.Desc);
                    //lviAux.SubItems.Add(DbUsrEnt.Db.ServerName);
                    lviAux.SubItems.Add(DbUsrEnt.Db.PCName);
                    lviAux.SubItems.Add(DbUsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = DbUsrEnt.Key;

                    lviAux.Tag = DbUsrEnt;

                    lvDbPwdDB.Items.Add(lviAux);
                }
            }
            lvDbPwdDB.Items.AddRange(GenerarLVItmsDbPwd(DbPwdAAsignarALvDB));
        }

        private void PasarDbPwdDeDBaUsr()
        {
            if (lvDbPwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvDbPwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpDbPwd = new ListViewItem();
                lviGrpDbPwd.Tag = lviDB.Tag;
                lviGrpDbPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpDbPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvDbPwdGrupo.Items.Add(lviGrpDbPwd);
            }
            foreach (ListViewItem lviDB in lvDbPwdDB.SelectedItems)
            {
                lvDbPwdDB.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }
        private void PasarTodoDbPwdDeDBaUsr()
        {
            if (lvDbPwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvDbPwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpDbPwd = new ListViewItem();
                lviGrpDbPwd.Tag = lviDB.Tag;
                lviGrpDbPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpDbPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvDbPwdGrupo.Items.Add(lviGrpDbPwd);
            }
            lvDbPwdDB.Items.Clear();
            _ModificaPwd = true;

        }
        private void PasarDbPwdDeGrpaDB()
        {
            if (lvDbPwdGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvDbPwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpDbPwd = new ListViewItem();
                lviGrpDbPwd.Tag = lviDB.Tag;
                lviGrpDbPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpDbPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvDbPwdDB.Items.Add(lviGrpDbPwd);
            }
            foreach (ListViewItem lviDB in lvDbPwdGrupo.SelectedItems)
            {
                lvDbPwdGrupo.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }

        private void PasarTodoDbPwdDeGrpaDB()
        {
            if (lvDbPwdGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvDbPwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpDbPwd = new ListViewItem();
                lviGrpDbPwd.Tag = lviDB.Tag;
                lviGrpDbPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpDbPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvDbPwdDB.Items.Add(lviGrpDbPwd);
            }
            lvDbPwdGrupo.Items.Clear();
            _ModificaPwd = true;
        }

        private ListViewItem[] GenerarLVItmsDbPwd(IList<DatabaseUserEntity> DbUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[DbUsrLst.Count];
            int i = 0;
            foreach (DatabaseUserEntity DbUsrEnt in DbUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(DbUsrEnt.Username);
                lviArr[i].SubItems.Add(DbUsrEnt.Db.Name);
                lviArr[i].SubItems.Add(DbUsrEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(DbUsrEnt.Db.Desc);
                //lviArr[i].SubItems.Add(DbUsrEnt.Db.ServerName);
                lviArr[i].SubItems.Add(DbUsrEnt.Db.PCName);
                lviArr[i].Text = DbUsrEnt.Key;

                lviArr[i].Tag = DbUsrEnt;
                i++;
            }
            return lviArr;
        }

        private void btnDbAddRole_Click(object sender, EventArgs e)
        {
            PasarDbPwdDeDBaUsr();
        }

        private void btnDbAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoDbPwdDeDBaUsr();
        }

        private void btnDbDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoDbPwdDeGrpaDB();
        }

        private void btnDbDelRole_Click(object sender, EventArgs e)
        {
            PasarDbPwdDeGrpaDB();
        }
        #endregion

        #region Passwords de Aplicaciones

        private void CargarAppPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvAppPwdGrupo.Items.AddRange(GenerarLVItmsAppPwd(RqstGrpBL.LoadActiveAppPwds(_entity)));
        }

        private void CargarAppPwdDB()
        {
            // traigo todos los roles de la base
            ApplicationUserBusiness AppPwdBL = new ApplicationUserBusiness();
            AppPwdBL.GetGruposSeguimAsignados = true;
            AppPwdBL.FilUsuariosActivos = true;
            ApplicationUserEntityCollection AppPwdEC = AppPwdBL.GetAll();
            IList<ApplicationUserEntity> AppPwdAAsignarALvDB = new List<ApplicationUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (ApplicationUserEntity AppUsrEnt in AppPwdEC)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvAppPwdGrupo.Items)
                {
                    if (((ApplicationUserEntity)lviPermisosUsr.Tag).Id == AppUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(AppUsrEnt.Application.Name);
                    lviAux.SubItems.Add(AppUsrEnt.Username);
                    lviAux.SubItems.Add(AppUsrEnt.Application.Desc);
                    lviAux.SubItems.Add(AppUsrEnt.Application.Field1Desc);
                    lviAux.SubItems.Add(AppUsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = AppUsrEnt.Key;
                    lviAux.Tag = AppUsrEnt;

                    lvAppPwdDB.Items.Add(lviAux);
                }
            }
            lvAppPwdDB.Items.AddRange(GenerarLVItmsAppPwd(AppPwdAAsignarALvDB));

        }
        private void PasarAppPwdDeDBaUsr()
        {
            if (lvAppPwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAppPwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAppPwd = new ListViewItem();
                lviGrpAppPwd.Tag = lviDB.Tag;
                lviGrpAppPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAppPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvAppPwdGrupo.Items.Add(lviGrpAppPwd);
            }
            foreach (ListViewItem lviDB in lvAppPwdDB.SelectedItems)
            {
                lvAppPwdDB.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }

        private void PasarTodoAppPwdDeDBaUsr()
        {
            if (lvAppPwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAppPwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAppPwd = new ListViewItem();
                lviGrpAppPwd.Tag = lviDB.Tag;
                lviGrpAppPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAppPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvAppPwdGrupo.Items.Add(lviGrpAppPwd);
            }
            lvAppPwdDB.Items.Clear();
            _ModificaPwd = true;

        }
        private void PasarAppPwdDeGrpaDB()
        {
            if (lvAppPwdGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAppPwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAppPwd = new ListViewItem();
                lviGrpAppPwd.Tag = lviDB.Tag;
                lviGrpAppPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAppPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvAppPwdDB.Items.Add(lviGrpAppPwd);
            }
            foreach (ListViewItem lviDB in lvAppPwdGrupo.SelectedItems)
            {
                lvAppPwdGrupo.Items.Remove(lviDB);
            }
            _ModificaPwd = true;
        }

        private void PasarTodoAppPwdDeGrpaDB()
        {
            if (lvAppPwdGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAppPwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAppPwd = new ListViewItem();
                lviGrpAppPwd.Tag = lviDB.Tag;
                lviGrpAppPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAppPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvAppPwdDB.Items.Add(lviGrpAppPwd);
            }
            lvAppPwdGrupo.Items.Clear();
            _ModificaPwd = true;
        }

        private ListViewItem[] GenerarLVItmsAppPwd(IList<ApplicationUserEntity> AppUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[AppUsrLst.Count];
            int i = 0;
            foreach (ApplicationUserEntity AppUsrEnt in AppUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(AppUsrEnt.Application.Name);
                lviArr[i].SubItems.Add(AppUsrEnt.Username);
                lviArr[i].SubItems.Add(AppUsrEnt.Application.Desc);
                lviArr[i].SubItems.Add(AppUsrEnt.Application.Field1Desc);
                lviArr[i].Text = AppUsrEnt.Key;
                lviArr[i].Tag = AppUsrEnt;
                i++;
            }
            return lviArr;
        }

        private void btnAppAddRole_Click(object sender, EventArgs e)
        {
            PasarAppPwdDeDBaUsr();
        }

        private void lvAppPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarAppPwdDeDBaUsr();
        }

        private void btnAppAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoAppPwdDeDBaUsr();
        }

        private void btnAppDelRole_Click(object sender, EventArgs e)
        {
            PasarAppPwdDeGrpaDB();
        }

        private void lvAppPwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarAppPwdDeGrpaDB();
            }
        }

        private void btnAppDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoAppPwdDeGrpaDB();
        }

        #endregion

        #region Passwords de Unix
        private void CargarUnixPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvUnixPwdGrupo.Items.AddRange(GenerarLVItmsUnixPwd(RqstGrpBL.LoadActiveUnixPwds(_entity)));
        }
        private void CargarUnixPwdDB()
        {
            // traigo todos los roles de la base
            UnixUserBusiness UnixPwdBL = new UnixUserBusiness();
            UnixPwdBL.GetGruposSeguimAsignados = true;
            UnixPwdBL.FilUsuariosActivos = true;
            UnixUserEntityCollection UnixPwdEC = UnixPwdBL.GetAll();
            IList<UnixUserEntity> UnixPwdAAsignarALvDB = new List<UnixUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (UnixUserEntity UnixUsrEnt in UnixPwdEC)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvUnixPwdGrupo.Items)
                {
                    if (((UnixUserEntity)lviPermisosUsr.Tag).Id == UnixUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(UnixUsrEnt.Unix.ServerName);
                    lviAux.SubItems.Add(UnixUsrEnt.Username);
                    lviAux.SubItems.Add(UnixUsrEnt.Unix.Ip);
                    lviAux.SubItems.Add(UnixUsrEnt.Unix.Desc);
                    lviAux.SubItems.Add(UnixUsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = UnixUsrEnt.Key;
                    lviAux.Tag = UnixUsrEnt;

                    lvUnixPwdDB.Items.Add(lviAux);
                }
            }
            lvUnixPwdDB.Items.AddRange(GenerarLVItmsUnixPwd(UnixPwdAAsignarALvDB));

        }
        private void PasarUnixPwdDeDBaUsr()
        {
            if (lvUnixPwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUnixPwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpUnixPwd = new ListViewItem();
                lviGrpUnixPwd.Tag = lviDB.Tag;
                lviGrpUnixPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpUnixPwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUnixPwdGrupo.Items.Add(lviGrpUnixPwd);
            }
            foreach (ListViewItem lviDB in lvUnixPwdDB.SelectedItems)
            {
                lvUnixPwdDB.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }
        private void PasarTodoUnixPwdDeDBaUsr()
        {
            if (lvUnixPwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUnixPwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpUnixPwd = new ListViewItem();
                lviGrpUnixPwd.Tag = lviDB.Tag;
                lviGrpUnixPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpUnixPwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUnixPwdGrupo.Items.Add(lviGrpUnixPwd);
            }
            lvUnixPwdDB.Items.Clear();
            _ModificaPwd = true;

        }
        private void PasarUnixPwdDeGrpaDB()
        {
            if (lvUnixPwdGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUnixPwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpUnixPwd = new ListViewItem();
                lviGrpUnixPwd.Tag = lviDB.Tag;
                lviGrpUnixPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpUnixPwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUnixPwdDB.Items.Add(lviGrpUnixPwd);
            }
            foreach (ListViewItem lviDB in lvUnixPwdGrupo.SelectedItems)
            {
                lvUnixPwdGrupo.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }

        private void PasarTodoUnixPwdDeGrpaDB()
        {
            if (lvUnixPwdGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUnixPwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpUnixPwd = new ListViewItem();
                lviGrpUnixPwd.Tag = lviDB.Tag;
                lviGrpUnixPwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpUnixPwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvUnixPwdDB.Items.Add(lviGrpUnixPwd);
            }
            lvUnixPwdGrupo.Items.Clear();
            _ModificaPwd = true;

        }

        private ListViewItem[] GenerarLVItmsUnixPwd(IList<UnixUserEntity> UnixUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[UnixUsrLst.Count];
            int i = 0;
            foreach (UnixUserEntity UnixUsrEnt in UnixUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(UnixUsrEnt.Unix.ServerName);
                lviArr[i].SubItems.Add(UnixUsrEnt.Username);
                lviArr[i].SubItems.Add(UnixUsrEnt.Unix.Ip);
                lviArr[i].SubItems.Add(UnixUsrEnt.Unix.Desc);
                lviArr[i].Text = UnixUsrEnt.Key;
                lviArr[i].Tag = UnixUsrEnt;
                i++;
            }
            return lviArr;
        }

        private void btnUnixAddRole_Click(object sender, EventArgs e)
        {
            PasarUnixPwdDeDBaUsr();
        }

        private void lvUnixPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarUnixPwdDeDBaUsr();
        }

        private void btnUnixAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoUnixPwdDeDBaUsr();
        }

        private void btnUnixDelRole_Click(object sender, EventArgs e)
        {
            PasarUnixPwdDeGrpaDB();
        }

        private void lvUnixPwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarUnixPwdDeGrpaDB();
            }
        }

        private void btnUnixDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoUnixPwdDeGrpaDB();
        }

        #endregion

        #region Passwords de AS400
        private void CargarAS400PwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            //_win_pwds = RqstGrpBL.LoadWinPwds(_entity);
            lvAS400PwdGrupo.Items.AddRange(GenerarLVItmsAS400Pwd(RqstGrpBL.LoadActiveAS400Pwds(_entity)));
        }
        private void CargarAS400PwdDB()
        {
            // traigo todos los roles de la base
            AS400UserBusiness AS400PwdBL = new AS400UserBusiness();
            AS400PwdBL.GetGruposSeguimAsignados = true;
            AS400PwdBL.FilUsuariosActivos = true;
            AS400UserEntityCollection AS400PwdEC = AS400PwdBL.GetAll();
            IList<AS400UserEntity> AS400PwdAAsignarALvDB = new List<AS400UserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (AS400UserEntity AS400UsrEnt in AS400PwdEC)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvAS400PwdGrupo.Items)
                {
                    if (((AS400UserEntity)lviPermisosUsr.Tag).Id == AS400UsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(AS400UsrEnt.AS400.ServerName);
                    lviAux.SubItems.Add(AS400UsrEnt.Username);
                    lviAux.SubItems.Add(AS400UsrEnt.AS400.Ip);
                    lviAux.SubItems.Add(AS400UsrEnt.AS400.Desc);
                    lviAux.SubItems.Add(AS400UsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = AS400UsrEnt.Key;
                    lviAux.Tag = AS400UsrEnt;

                    lvAS400PwdDB.Items.Add(lviAux);
                }
            }
            lvAS400PwdDB.Items.AddRange(GenerarLVItmsAS400Pwd(AS400PwdAAsignarALvDB));

        }
        private void PasarAS400PwdDeDBaUsr()
        {
            if (lvAS400PwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAS400PwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAS400Pwd = new ListViewItem();
                lviGrpAS400Pwd.Tag = lviDB.Tag;
                lviGrpAS400Pwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAS400Pwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvAS400PwdGrupo.Items.Add(lviGrpAS400Pwd);
            }
            foreach (ListViewItem lviDB in lvAS400PwdDB.SelectedItems)
            {
                lvAS400PwdDB.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }
        private void PasarTodoAS400PwdDeDBaUsr()
        {
            if (lvAS400PwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAS400PwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAS400Pwd = new ListViewItem();
                lviGrpAS400Pwd.Tag = lviDB.Tag;
                lviGrpAS400Pwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAS400Pwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvAS400PwdGrupo.Items.Add(lviGrpAS400Pwd);
            }
            lvAS400PwdDB.Items.Clear();
            _ModificaPwd = true;

        }
        private void PasarAS400PwdDeGrpaDB()
        {
            if (lvAS400PwdGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAS400PwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAS400Pwd = new ListViewItem();
                lviGrpAS400Pwd.Tag = lviDB.Tag;
                lviGrpAS400Pwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAS400Pwd.SubItems.Add(lviDB.SubItems[i]);
                }

                lvAS400PwdDB.Items.Add(lviGrpAS400Pwd);
            }
            foreach (ListViewItem lviDB in lvAS400PwdGrupo.SelectedItems)
            {
                lvAS400PwdGrupo.Items.Remove(lviDB);
            }
            _ModificaPwd = true;

        }

        private void PasarTodoAS400PwdDeGrpaDB()
        {
            if (lvAS400PwdGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvAS400PwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpAS400Pwd = new ListViewItem();
                lviGrpAS400Pwd.Tag = lviDB.Tag;
                lviGrpAS400Pwd.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpAS400Pwd.SubItems.Add(lviDB.SubItems[i]);
                }
                lvAS400PwdDB.Items.Add(lviGrpAS400Pwd);
            }
            lvAS400PwdGrupo.Items.Clear();
            _ModificaPwd = true;

        }

        private ListViewItem[] GenerarLVItmsAS400Pwd(IList<AS400UserEntity> AS400UsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[AS400UsrLst.Count];
            int i = 0;
            foreach (AS400UserEntity AS400UsrEnt in AS400UsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.ServerName);
                lviArr[i].SubItems.Add(AS400UsrEnt.Username);
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.Ip);
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.Desc);
                lviArr[i].Text = AS400UsrEnt.Key;
                lviArr[i].Tag = AS400UsrEnt;
                i++;
            }
            return lviArr;
        }

        private void btnAS400AddRole_Click(object sender, EventArgs e)
        {
            PasarAS400PwdDeDBaUsr();
        }

        private void lvAS400PwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarAS400PwdDeDBaUsr();
        }

        private void btnAS400AddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoAS400PwdDeDBaUsr();
        }

        private void btnAS400DelRole_Click(object sender, EventArgs e)
        {
            PasarAS400PwdDeGrpaDB();
        }

        private void lvAS400PwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarAS400PwdDeGrpaDB();
            }
        }

        private void btnAS400DelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoAS400PwdDeGrpaDB();
        }

        #endregion

        #region Equipos de Comunicación
        private void CargarECPwdDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();

            lvECPwdGrupo.Items.AddRange(GenerarLVItmsECPwd(RqstGrpBL.LoadActiveECPwds(_entity)));
        }
        private void CargarECPwdDB()
        {
            // traigo todos los roles de la base
            CommunicationDeviceUserBusiness ECPwdBL = new CommunicationDeviceUserBusiness();
            ECPwdBL.GetGruposSeguimAsignados = true;
            ECPwdBL.FilUsuariosActivos = true;
            CommunicationDeviceUserEntityCollection CDPwdEC = ECPwdBL.GetAll();
            IList<CommunicationDeviceUserEntity> CDPwdAAsignarALvDB = new List<CommunicationDeviceUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            foreach (CommunicationDeviceUserEntity CDUsrEnt in CDPwdEC)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvECPwdGrupo.Items)
                {
                    if (((CommunicationDeviceUserEntity)lviPermisosUsr.Tag).Id == CDUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(CDUsrEnt.CommunicationDevice.Name);
                    lviAux.SubItems.Add(CDUsrEnt.Username);
                    lviAux.SubItems.Add(CDUsrEnt.CommunicationDevice.IP);
                    lviAux.SubItems.Add(CDUsrEnt.CommunicationDevice.Description);
                    lviAux.SubItems.Add(CDUsrEnt.UserPassword.FollowupRqstGrpsPwdsList.Count.ToString());
                    lviAux.Text = CDUsrEnt.Key;
                    lviAux.Tag = CDUsrEnt;

                    lvECPwdDB.Items.Add(lviAux);
                }
            }

            lvECPwdDB.Items.AddRange(GenerarLVItmsECPwd(CDPwdAAsignarALvDB));
        }

        private void PasarECPwdDeDBaUsr()
        {
            if (lvECPwdDB.SelectedItems.Count <= 0)
                return;

            foreach (ListViewItem lviDB in lvECPwdDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpECPwd = new ListViewItem();
                lviGrpECPwd.Tag = lviDB.Tag;
                lviGrpECPwd.Text = lviDB.Text;

                for (int i = 1; i < lviDB.SubItems.Count; i++)
                    lviGrpECPwd.SubItems.Add(lviDB.SubItems[i]);

                lvECPwdGrupo.Items.Add(lviGrpECPwd);
            }

            foreach (ListViewItem lviDB in lvECPwdDB.SelectedItems)
                lvECPwdDB.Items.Remove(lviDB);
            _ModificaPwd = true;
        }

        private void PasarTodoECPwdDeDBaUsr()
        {
            if (lvECPwdDB.Items.Count <= 0)
                return;

            foreach (ListViewItem lviDB in lvECPwdDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpECPwd = new ListViewItem();
                lviGrpECPwd.Tag = lviDB.Tag;
                lviGrpECPwd.Text = lviDB.Text;

                for (int i = 1; i < lviDB.SubItems.Count; i++)
                    lviGrpECPwd.SubItems.Add(lviDB.SubItems[i]);

                lvECPwdGrupo.Items.Add(lviGrpECPwd);
            }

            lvECPwdDB.Items.Clear();
            _ModificaPwd = true;
        }

        private void PasarECPwdDeGrpaDB()
        {
            if (lvECPwdGrupo.SelectedItems.Count <= 0)
                return;

            foreach (ListViewItem lviDB in lvECPwdGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpECPwd = new ListViewItem();
                lviGrpECPwd.Tag = lviDB.Tag;
                lviGrpECPwd.Text = lviDB.Text;

                for (int i = 1; i < lviDB.SubItems.Count; i++)
                    lviGrpECPwd.SubItems.Add(lviDB.SubItems[i]);

                lvECPwdDB.Items.Add(lviGrpECPwd);
            }

            foreach (ListViewItem lviDB in lvECPwdGrupo.SelectedItems)
                lvECPwdGrupo.Items.Remove(lviDB);
            _ModificaPwd = true;
        }

        private void PasarTodoECPwdDeGrpaDB()
        {
            if (lvECPwdGrupo.Items.Count <= 0)
                return;

            foreach (ListViewItem lviDB in lvECPwdGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpECPwd = new ListViewItem();
                lviGrpECPwd.Tag = lviDB.Tag;
                lviGrpECPwd.Text = lviDB.Text;

                for (int i = 1; i < lviDB.SubItems.Count; i++)
                    lviGrpECPwd.SubItems.Add(lviDB.SubItems[i]);

                lvECPwdDB.Items.Add(lviGrpECPwd);
            }

            lvECPwdGrupo.Items.Clear();
            _ModificaPwd = true;
        }

        private ListViewItem[] GenerarLVItmsECPwd(IList<CommunicationDeviceUserEntity> ECUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[ECUsrLst.Count];

            int i = 0;

            foreach (CommunicationDeviceUserEntity ECUsrEnt in ECUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(ECUsrEnt.CommunicationDevice.Name);
                lviArr[i].SubItems.Add(ECUsrEnt.Username);
                lviArr[i].SubItems.Add(ECUsrEnt.CommunicationDevice.IP);
                lviArr[i].SubItems.Add(ECUsrEnt.CommunicationDevice.Description);
                lviArr[i].Text = ECUsrEnt.Key;
                lviArr[i].Tag = ECUsrEnt;
                i++;
            }

            return lviArr;
        }

        private void btnECAddRole_Click(object sender, EventArgs e)
        {
            PasarECPwdDeDBaUsr();
        }

        private void lvECPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarECPwdDeDBaUsr();
        }

        private void btnECAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoECPwdDeDBaUsr();
        }

        private void btnECDelRole_Click(object sender, EventArgs e)
        {
            PasarECPwdDeGrpaDB();
        }

        private void lvECPwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
                PasarECPwdDeGrpaDB();
        }

        private void btnECDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoECPwdDeGrpaDB();
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            // si es visualización sale
            if (_readOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            if (txtGroupName.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre del grupo", "Grupos de Seguimientos de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGroupName.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            // si es alta o moficiación
            // grabo al usuario
            _entity.Name = txtGroupName.Text;
            _entity.AutoApproval = chkAprobAutomatica.Checked;

            if (txtResponsible.Text != "" && m_Approver != null)
            {
                _entity.Approver = m_Approver;
            }
            else
            {
                _entity.Approver = null;
            }

            bool Desactivacion = false;
            if (_entity.Id > 0)
            {
                if (_entity.Active != chkActivo.Checked && !chkActivo.Checked)
                {
                    Desactivacion = true;
                }
            }
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            if (Desactivacion)
            {
                // verificar que no haya una contraseña que tiene este grupo como único grupo de seguim
                vwCantFollowRqstGrpPwdBusiness CantFRGPBL = new vwCantFollowRqstGrpPwdBusiness();
                if (!CantFRGPBL.FollowRqstGrpIsDesactivable(_entity.Id))
                {
                    MessageBox.Show("El grupo no se puede desactivar ya que hay contraseñas que lo tienen como único grupo de Seguimiento de Solicitudes", "Grupos de Seguimientos de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGroupName.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            _entity.Active = chkActivo.Checked;
            int SaveId = RqstGrpBL.Save(_entity);
            if (SaveId == 0)
            {

            }
            if (!Desactivacion)
            {
                //FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
                // grabo win pwd
                UserPasswordEntityCollection RqstPwdEC = new UserPasswordEntityCollection();
                foreach (ListViewItem lviWinPwd in lvWinPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((WinLocalUserEntity)lviWinPwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviDbPwd in lvDbPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((DatabaseUserEntity)lviDbPwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviAppPwd in lvAppPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((ApplicationUserEntity)lviAppPwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviUnixPwd in lvUnixPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((UnixUserEntity)lviUnixPwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviAS400Pwd in lvAS400PwdGrupo.Items)
                {
                    RqstPwdEC.Add(((AS400UserEntity)lviAS400Pwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviECPwd in lvECPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((CommunicationDeviceUserEntity)lviECPwd.Tag).UserPassword);
                }
                foreach (ListViewItem lviATMPwd in lvATMPwdGrupo.Items)
                {
                    RqstPwdEC.Add(((ATMUserEntity)lviATMPwd.Tag).UserPassword);
                }
                PhxUserEntityCollection PhxUsersAsociados = new PhxUserEntityCollection();
                foreach (ListViewItem lviPhxUsr in lvUsuariosGrupo.Items)
                {
                    PhxUsersAsociados.Add(((PhxUserEntity)lviPhxUsr.Tag));
                }

                RqstGrpBL.SetPwdsToRqstGrp(_entity, RqstPwdEC, PhxUsersAsociados, _ModificaPwd, _ModificaUsrs);
            }
            Cursor.Current = Cursors.Default;
            this.DialogResult = DialogResult.OK;

        }

        private void lvDbPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarDbPwdDeDBaUsr();
        }

        private void lvDbPwdGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                PasarDbPwdDeGrpaDB();
            }
        }
        /*
        /// <summary>
        /// Carga el combo de autorizadores 1. Si no hay autorizadores devuelve false
        /// </summary>
        /// <returns></returns>
        private bool CargarComboAuth1()
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntityCollection AuthEC = PhxUsrBL.GetAllAuth();
            if (AuthEC.Count == 0)
            {
                return false;
            }
            cbAuth1.DataSource = AuthEC;
            return true;
            //PhxUserEntityCollection 
        }
        private void CargarComboAuth2()
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntityCollection AuthEC = PhxUsrBL.GetAuthForFilter();
            cbAuth2.DataSource = AuthEC;

            //PhxUserEntityCollection 
        }
        */
        private void lvs_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void btnCargarWindows_Click(object sender, EventArgs e)
        {
            lvWinPwdDB.Items.Clear();
            CargarWinPwdDB();
        }

        private void btnCargarBaseDatos_Click(object sender, EventArgs e)
        {
            lvDbPwdDB.Items.Clear();
            CargarDbPwdDB();
        }

        private void btnCargarUnix_Click(object sender, EventArgs e)
        {
            lvUnixPwdDB.Items.Clear();
            CargarUnixPwdDB();
        }

        private void btnCargarAplicativos_Click(object sender, EventArgs e)
        {
            lvAppPwdDB.Items.Clear();
            CargarAppPwdDB();
        }

        private void btnCargarAS400_Click(object sender, EventArgs e)
        {
            lvAS400PwdDB.Items.Clear();
            CargarAS400PwdDB();
        }

        private void btnCargarEC_Click(object sender, EventArgs e)
        {
            lvECPwdDB.Items.Clear();
            CargarECPwdDB();
        }

        private void btnCargarUsuarios_Click(object sender, EventArgs e)
        {
            lvUsuariosDB.Items.Clear();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            UsrBL.FilActive = true;
            PhxUserEntityCollection Usuarios = UsrBL.GetAllWithGroupsAndRoles();
            foreach (PhxUserEntity PxhUsrEnt in Usuarios)
            {
                bool PermisoAsignado = false;
                foreach (ListViewItem lviPermisosUsr in lvUsuariosGrupo.Items)
                {
                    if (((PhxUserEntity)lviPermisosUsr.Tag).Id == PxhUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }
                if (!PermisoAsignado)
                {
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(PxhUsrEnt.Domain);
                    lviAux.SubItems.Add(PxhUsrEnt.Fullname);
                    lviAux.Text = PxhUsrEnt.Username;
                    lviAux.Tag = PxhUsrEnt;
                    lvUsuariosDB.Items.Add(lviAux);
                }
            }
        }

        private void CargarUsuariosDelGrupo()
        {
            FollowupRequestGroupBusiness RqstGrpBL = new FollowupRequestGroupBusiness();
            lvUsuariosGrupo.Items.AddRange(GenerarLVItemsUsuarios(RqstGrpBL.LoadPhxUsers(_entity)));
        }

        private void PasarPhxUserDeDBaUsr()
        {
            if (lvUsuariosDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUsuariosDB.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpPhxUser = new ListViewItem();
                lviGrpPhxUser.Tag = lviDB.Tag;
                lviGrpPhxUser.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpPhxUser.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUsuariosGrupo.Items.Add(lviGrpPhxUser);
            }
            foreach (ListViewItem lviDB in lvUsuariosDB.SelectedItems)
            {
                lvUsuariosDB.Items.Remove(lviDB);
            }
            _ModificaUsrs = true;

        }
        private void PasarTodoPhxUserDeDBaUsr()
        {
            if (lvUsuariosDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUsuariosDB.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpPhxUser = new ListViewItem();
                lviGrpPhxUser.Tag = lviDB.Tag;
                lviGrpPhxUser.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpPhxUser.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUsuariosGrupo.Items.Add(lviGrpPhxUser);
            }
            lvUsuariosDB.Items.Clear();
            _ModificaUsrs = true;

        }
        private void PasarPhxUserDeGrpaDB()
        {
            if (lvUsuariosGrupo.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUsuariosGrupo.SelectedItems)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpPhxUser = new ListViewItem();
                lviGrpPhxUser.Tag = lviDB.Tag;
                lviGrpPhxUser.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpPhxUser.SubItems.Add(lviDB.SubItems[i]);
                }

                lvUsuariosDB.Items.Add(lviGrpPhxUser);
            }
            foreach (ListViewItem lviDB in lvUsuariosGrupo.SelectedItems)
            {
                lvUsuariosGrupo.Items.Remove(lviDB);
            }
            _ModificaUsrs = true;

        }

        private void PasarTodoPhxUserDeGrpaDB()
        {
            if (lvUsuariosGrupo.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvUsuariosGrupo.Items)
            {
                // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                ListViewItem lviGrpPhxUser = new ListViewItem();
                lviGrpPhxUser.Tag = lviDB.Tag;
                lviGrpPhxUser.Text = lviDB.Text;
                for (int i = 1; i < lviDB.SubItems.Count; i++)
                {
                    lviGrpPhxUser.SubItems.Add(lviDB.SubItems[i]);
                }
                lvUsuariosDB.Items.Add(lviGrpPhxUser);
            }
            lvUsuariosGrupo.Items.Clear();
            _ModificaUsrs = true;

        }

        private ListViewItem[] GenerarLVItmsPhxUser(IList<AS400UserEntity> AS400UsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[AS400UsrLst.Count];
            int i = 0;
            foreach (AS400UserEntity AS400UsrEnt in AS400UsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.ServerName);
                lviArr[i].SubItems.Add(AS400UsrEnt.Username);
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.Ip);
                lviArr[i].SubItems.Add(AS400UsrEnt.AS400.Desc);
                lviArr[i].Text = AS400UsrEnt.Key;
                lviArr[i].Tag = AS400UsrEnt;
                i++;
            }
            return lviArr;
        }

        private ListViewItem[] GenerarLVItemsUsuarios(IList<FollowupRequestGroupUserEntity> PhxUsrLst)
        {
            ListViewItem[] lviArr = new ListViewItem[PhxUsrLst.Count];
            int i = 0;
            foreach (FollowupRequestGroupUserEntity PhxUsrEnt in PhxUsrLst)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].SubItems.Add(PhxUsrEnt.PhxUser.Domain);
                lviArr[i].SubItems.Add(PhxUsrEnt.PhxUser.Fullname);
                lviArr[i].Text = PhxUsrEnt.PhxUser.Username;
                lviArr[i].Tag = PhxUsrEnt.PhxUser;
                i++;
            }
            return lviArr;
        }

        private void btnUsuariosAddRole_Click(object sender, EventArgs e)
        {
            PasarPhxUserDeDBaUsr();
        }

        private void btnUsuarioAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoPhxUserDeDBaUsr();
        }

        private void btnUsuarioDelAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoPhxUserDeGrpaDB();
        }

        private void btnUsuarioDelRole_Click(object sender, EventArgs e)
        {
            PasarPhxUserDeGrpaDB();
        }

        private void lvUsuariosDB_DoubleClick(object sender, EventArgs e)
        {
            PasarPhxUserDeDBaUsr();
        }

        private void lvUsuariosGrupo_DoubleClick(object sender, EventArgs e)
        {
            if (!_readOnly)
                PasarPhxUserDeGrpaDB();
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !chkActivo.Checked;
            picActivo.Visible = chkActivo.Checked;
            /// se deshabilita la edición si esta activo
            pnlWinPwdDB.Visible = chkActivo.Checked;
            pnlDbPwdDB.Visible = chkActivo.Checked;
            pnlUnixPwdDB.Visible = chkActivo.Checked;
            pnlAS400PwdDB.Visible = chkActivo.Checked;
            pnlAppPwdDB.Visible = chkActivo.Checked;
            pnlECPwdDB.Visible = chkActivo.Checked;
            pnlUsuarios.Visible = chkActivo.Checked;
            txtGroupName.ReadOnly = !chkActivo.Checked;
            pnlWinPwdDB.Visible = chkActivo.Checked;
            pnlDbPwdDB.Visible = chkActivo.Checked;
            pnlAppPwdDB.Visible = chkActivo.Checked;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            FSelectPhxUser selectPhxUsers = new FSelectPhxUser(); //(WinPCEntity)cBPC.SelectedValue);
            selectPhxUsers.Title = "Busqueda de Usuarios";

            if (selectPhxUsers.ShowDialog() == DialogResult.OK)
            {
                PhxUserEntity selectedUser = (PhxUserEntity)selectPhxUsers.GetSelectedEntity();
                if (selectedUser != null)
                {
                    m_Approver = selectedUser;
                    txtResponsible.Text = selectedUser.Fullname + " (" + selectedUser.Username + ")";
                }
            }
        }
    }
}

