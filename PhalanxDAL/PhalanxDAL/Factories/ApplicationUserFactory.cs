using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;
using System.Collections;
 
namespace PhalanxDAL.Factories
{
    public class ApplicationUserFactory
    {
        private string _filUserName = "";
        private ApplicationEntity _filApp;
        private bool _orderName = false;
        private bool _orderUserName = false;
        private bool _orderFolio = false;
        public bool OrderByUserName
        {
            set { _orderUserName = value; }
        }
        public bool OrderByName
        {
            set { _orderName = value; }
        }
        public bool OrderByFolio
        {
            set { _orderFolio = value; }
        }
        public ApplicationEntity FilApplication
        {
            set { _filApp = value; }
        }
        public string FilUserName
        {
            set { _filUserName = value; }
            //get { return _filNombre; }
        }
        private bool? _filUsuariosActivos;
        public bool? FilUsuariosActivos
        {
            set { _filUsuariosActivos = value; }
        }
        private bool? _filUsuariosCriticos;
        public bool? FilUsuariosCriticos
        {
            set { _filUsuariosCriticos = value; }
        }
        private bool _AvoidInactiveGrps = false;
        public bool SetAvoidInactiveGrps
        { set { _AvoidInactiveGrps = value; } }


        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;

        public ApplicationUserEntityCollection GetAll()
        {
            IList<ApplicationUserEntity> lstWLUs;
            ApplicationUserEntityCollection DBUsrEC = new ApplicationUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationUserEntity), "AppU");
                if (_filUserName != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("Username", _filUserName, MatchMode.Anywhere));
                }
                if (_filUsuariosActivos != null)
                {
                    DataSearch.Add(Expression.Eq("ActiveUser", _filUsuariosActivos));
                }
                if (_filUsuariosCriticos != null)
                {
                    DataSearch.Add(Expression.Eq("Critical", _filUsuariosCriticos));
                }
                if (_filApp != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("Application", _filApp));
                }
                if (_orderName)
                {
                    DataSearch.CreateCriteria("Application", "App");
                    DataSearch = DataSearch.AddOrder(Order.Asc("App.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("AppU.Username"));
                }
                if (_orderUserName)
                {
                    DataSearch.CreateCriteria("Application", "App");
                    DataSearch = DataSearch.AddOrder(Order.Asc("AppU.Username"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("App.Name"));
                }
                if (_orderFolio)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("Id"));
                }

                lstWLUs = DataSearch.List<ApplicationUserEntity>();
                if (GetGruposAsignados)
                {
                    for (int x = 0; x < lstWLUs.Count; x++)
                    {
                        int i = lstWLUs[x].UserPassword.RqstGrpsPwdsList.Count;
                    }
                }
                if (GetGruposSeguimAsignados)
                {
                    for (int x = 0; x < lstWLUs.Count; x++)
                    {
                        int i = lstWLUs[x].UserPassword.FollowupRqstGrpsPwdsList.Count;
                    }
                }

                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

        public ApplicationUserEntity Refresh(ApplicationUserEntity User)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(User);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ApplicationUserFactory Refresh()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ApplicationUserFactory Refresh()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ApplicationUserFactory Refresh()"));
            }
            return User;
        }

        private string _filFiltroNombreGeneral = "";
        public string FilFiltroNombreGeneral
        {
            set { _filFiltroNombreGeneral = value; }
        }

        public ApplicationUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            IList<ApplicationUserEntity> lstDBUs;
            ApplicationUserEntityCollection ApplicationUsrEC = new ApplicationUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationUserEntity), "AppUser");
                if (_filFiltroNombreGeneral != "")
                {
                    DataSearch.Add(Expression.Like("AppUser.Username", _filFiltroNombreGeneral, MatchMode.Anywhere));
                }
                DataSearch = DataSearch.Add(Expression.Eq("AppUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch.Add(Expression.Eq("RQSTGRP.Active", true));
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                if (_orderName)
                {
                    DataSearch.CreateCriteria("AppUser.Application", "App");
                    DataSearch = DataSearch.AddOrder(Order.Asc("App.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("AppUser.Username"));

                }
                //DataSearch.AddOrder(Order.Asc("WLU.Username"));
                lstDBUs = DataSearch.List<ApplicationUserEntity>();
                ApplicationUsrEC.AddUnique(lstDBUs);
            }
            return ApplicationUsrEC;
        }

        public void RefreshRequestList(ref ApplicationUserEntity appUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(appUser);
                    int count = appUser.UserPassword.PasswordsRequestsList.Count;
                    count = appUser.UserPassword.UsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ApplicationUserFactory RefreshRequestList()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ApplicationUserFactory RefreshRequestList()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ApplicationUserFactory RefreshRequestList()"));
            }
        }

        public ApplicationUserEntity GetAppPwdForRqst(PhxUserEntity PhxUserRqst, int AppUserID)
        {
            ApplicationUserEntity AppUsrE = null;
            //AppUsrE.UserPassword.
            IList<ApplicationUserEntity> lstAppUsers;
            //ApplicationUserEntityCollection AppUsrEC = new ApplicationUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationUserEntity), "AppUser");
                DataSearch = DataSearch.Add(Expression.Eq("AppUser.Id", AppUserID));
                DataSearch = DataSearch.Add(Expression.Eq("AppUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                // agregar que esté activo y no esté en uso!!!!!
                try
                {
                    //DataSearch.AddOrder(Order.Asc("AppUser.Username"));
                    lstAppUsers = DataSearch.List<ApplicationUserEntity>();
                }
                catch
                {
                    lstAppUsers = null;
                }
                //AppUsrEC.Add(lstAppUsers);
                if (lstAppUsers.Count > 0)
                {
                    AppUsrE = lstAppUsers[0];
                }
            }

            return AppUsrE;
        }

        public RqstGrpPwdEntityCollection  GetGruposSolicitudes(ApplicationUserEntity CurrentUser)
        {
            IList<RqstGrpPwdEntity> lstRequestGroups;
            RqstGrpPwdEntityCollection colRequestGroups = new RqstGrpPwdEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                DataSearch = DataSearch.Add(Expression.Eq("UserPassword", CurrentUser.UserPassword));
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                lstRequestGroups = DataSearch.List<RqstGrpPwdEntity>();
                colRequestGroups.Add(lstRequestGroups);
            }
            return colRequestGroups;
        }


        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(ApplicationUserEntity CurrentUser)
        {
            IList<FollowupRequestGroupPasswordEntity> lstRequestGroups;
            FollowupRequestGroupPasswordEntityCollection colRequestGroups = new FollowupRequestGroupPasswordEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                DataSearch = DataSearch.Add(Expression.Eq("UserPassword", CurrentUser.UserPassword));
                DataSearch = DataSearch.CreateCriteria("FollowupRqstGrp", "FOLLOWUPRQSTGRP");
                lstRequestGroups = DataSearch.List<FollowupRequestGroupPasswordEntity>();
                colRequestGroups.Add(lstRequestGroups);
            }
            return colRequestGroups;
        }

        public int Save(ApplicationUserEntity AppUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {

            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(AppUser.UserPassword);
                    if (AppUser.UserType == null || AppUser.UserType.Id == 0)
                    {
                        AppUser.UserType = new UserTypesFactory().GetApplicationUserType();
                    }
                    session.SaveOrUpdate(AppUser);
                    if (GruposSolicitudes.Count > 0 && GruposSeguimiento.Count > 0)
                    {
                        IList lstUsrGrp;
                        ICriteria GruposABorrar = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        GruposABorrar = GruposABorrar.Add(Expression.Eq("UserPassword", AppUser.UserPassword));
                        GruposABorrar = GruposABorrar.Add(!Expression.In("RqstGrp", GruposSolicitudes));
                        lstUsrGrp = GruposABorrar.List();
                        foreach (RqstGrpPwdEntity e in lstUsrGrp)
                        {
                            if (_AvoidInactiveGrps && e.RqstGrp.Active == false)
                            {
                                /// si se evita trabajar con grupos inactivos y es inactivo no se borra
                            }
                            else
                            {
                                session.Delete(e);
                            }
                        }
                        foreach (RequestGroupEntity Grupo in GruposSolicitudes)
                        {
                            ICriteria ExistUsrGroup = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", AppUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                                newRqstGrpPwd.UserPassword = AppUser.UserPassword;
                                newRqstGrpPwd.RqstGrp = Grupo;
                                newRqstGrpPwd.Auth1Usr = null;
                                newRqstGrpPwd.Auth2Usr = null;
                                session.Save(newRqstGrpPwd);
                            }
                        }

                        IList lstUsrGrpSeg;
                        ICriteria ExistUsrGroupSeg = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(Expression.Eq("UserPassword", AppUser.UserPassword));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(!Expression.In("FollowupRqstGrp", GruposSeguimiento));
                        lstUsrGrpSeg = ExistUsrGroupSeg.List();
                        foreach (FollowupRequestGroupPasswordEntity e in lstUsrGrpSeg)
                        {
                            if (_AvoidInactiveGrps && e.FollowupRqstGrp.Active == false)
                            {
                                /// si se evita trabajar con grupos inactivos y es inactivo no se borra
                            }
                            else
                            {
                                session.Delete(e);
                            }
                        }
                        foreach (FollowupRequestGroupEntity Grupo in GruposSeguimiento)
                        {
                            ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", AppUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                FollowupRequestGroupPasswordEntity newRqstGrpPwdSeg = new FollowupRequestGroupPasswordEntity();
                                newRqstGrpPwdSeg.UserPassword = AppUser.UserPassword;
                                newRqstGrpPwdSeg.FollowupRqstGrp = Grupo;
                                session.Save(newRqstGrpPwdSeg);
                            }
                        }
                    }
                    // tengo que grabar el log de modificación
                    HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory();
                    HistPwdChg.AddLog(session, (UserEntity)AppUser);
                    tx.Commit();
                }
                return AppUser.Id; ;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw (new CwxException(ex.Message, "ApplicationUserFactory.Save"));
                //return 0;
                // handle exception
            }
        }

        public string RefreshPassword(ApplicationUserEntity AppUser)
        {
            string pwd = string.Empty;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(AppUser);
                    pwd = AppUser.UserPassword.Password;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ApplicationUserFactory RefreshPassword()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ApplicationUserFactory RefreshPassword()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ApplicationUserFactory RefreshPassword()"));
            }
            return pwd;
        }

        public void RefreshPassRequestList(ApplicationUserEntity AppUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(AppUser);
                    int i = AppUser.UserPassword.RqstGrpsPwdsList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RefreshPassRequestList "));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RefreshPassRequestList "));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RefreshPassRequestList "));
            }
        }



        public object GetAppUser(ApplicationEntity AppEntity, string UserName)
        {

			IList lstWLUs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
                lstWLUs = session.CreateCriteria(typeof(ApplicationUserEntity))
                    .Add(Expression.Eq("Application", AppEntity))
					.Add(Expression.Eq("Username",UserName))
					.List();
			}

			if (lstWLUs.Count >= 1)
			{
                return (ApplicationUserEntity)lstWLUs[0];
			}
			else
			{
				return null;
			}

        }

        public void SetPwdState(ApplicationUserEntityCollection Users, bool Active)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    foreach (ApplicationUserEntity AppUser in Users)
                    {
                        AppUser.ActiveUser = Active;
                        session.Update(AppUser);
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new CwxException(ex.Message, "ApplicationUserFactory.SetPwdState");
                }
            }
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("getAllApplicationUsers");

				int criticoParam = -1;
				int estadoUsuarioParam = -1;

				if (critico != null)
					criticoParam = critico.Value ? 1 : 0;

				if (estadoUsuario != null)
					estadoUsuarioParam = estadoUsuario.Value ? 1 : 0;

				query.SetString("nombre", nombre != null ? "%" + nombre.ToUpper() + "%" : null);
				query.SetParameter("critico", criticoParam);
				query.SetInt32("estadoUsuario", estadoUsuarioParam);

				return query.List();
			}
		}

        public ApplicationUserEntity Load(int ID)
        {
            ApplicationUserEntity objPhxUsr = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                objPhxUsr = (ApplicationUserEntity)session.Load(typeof(ApplicationUserEntity), ID);
            }
            return objPhxUsr;
        }
    }
}
