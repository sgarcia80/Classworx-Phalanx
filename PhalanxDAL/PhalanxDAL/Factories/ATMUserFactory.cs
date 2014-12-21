using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using System.Collections;
 
namespace PhalanxDAL.Factories
{
    public class ATMUserFactory
    {
        private string _filUserName = "";
        private bool _orderName = false;
        private string _filATMName;
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
        public string FilATMName
        {
            set { _filATMName = value; }
        }

        
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;

        public ATMUserEntityCollection GetAll()
        {
            IList<ATMUserEntity> lstWLUs;
            ATMUserEntityCollection DBUsrEC = new ATMUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ATMUserEntity), "ATMU");
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
                if (_orderName)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMU.ATMName"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMU.Username"));
                }
                if (_orderUserName)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMU.Username"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMU.ATMName"));
                }
                if (_orderFolio)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("Id"));
                }

                lstWLUs = DataSearch.List<ATMUserEntity>();
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

        public ATMUserEntity Refresh(ATMUserEntity User)
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
                throw (new CwxException(ObjNotFoundEx.Message, "ATMUserFactory Refresh()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ATMUserFactory Refresh()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ATMUserFactory Refresh()"));
            }
            return User;
        }

        private string _filFiltroNombreGeneral = "";
        public string FilFiltroNombreGeneral
        {
            set { _filFiltroNombreGeneral = value; }
        }

        public ATMUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            IList<ATMUserEntity> lstDBUs;
            ATMUserEntityCollection ApplicationUsrEC = new ATMUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ATMUserEntity), "ATMUser");
                if (_filFiltroNombreGeneral != "")
                {
                    DataSearch.Add(Expression.Like("ATMUser.Username", _filFiltroNombreGeneral, MatchMode.Anywhere));
                }
                DataSearch = DataSearch.Add(Expression.Eq("ATMUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch.Add(Expression.Eq("RQSTGRP.Active", true));
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                if (_orderName)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMUser.ATMName"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("ATMUser.Username"));

                }
                //DataSearch.AddOrder(Order.Asc("WLU.Username"));
                lstDBUs = DataSearch.List<ATMUserEntity>();
                ApplicationUsrEC.AddUnique(lstDBUs);
            }
            return ApplicationUsrEC;
        }

        public void RefreshRequestList(ref ATMUserEntity ATMUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(ATMUser);
                    int count = ATMUser.UserPassword.PasswordsRequestsList.Count;
                    count = ATMUser.UserPassword.UsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ATMUserFactory RefreshRequestList()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ATMUserFactory RefreshRequestList()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ATMUserFactory RefreshRequestList()"));
            }
        }

        public ATMUserEntity GetAppPwdForRqst(PhxUserEntity PhxUserRqst, int AppUserID)
        {
            ATMUserEntity AppUsrE = null;
            //AppUsrE.UserPassword.
            IList<ATMUserEntity> lstAppUsers;
            //ATMUserEntityCollection AppUsrEC = new ATMUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ATMUserEntity), "ATMUser");
                DataSearch = DataSearch.Add(Expression.Eq("ATMUser.Id", AppUserID));
                DataSearch = DataSearch.Add(Expression.Eq("ATMUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                // agregar que esté activo y no esté en uso!!!!!
                try
                {
                    //DataSearch.AddOrder(Order.Asc("ATMUser.Username"));
                    lstAppUsers = DataSearch.List<ATMUserEntity>();
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

        public RqstGrpPwdEntityCollection  GetGruposSolicitudes(ATMUserEntity CurrentUser)
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


        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(ATMUserEntity CurrentUser)
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

        public int Save(ATMUserEntity ATMUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {

            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(ATMUser.UserPassword);
                    if (ATMUser.UserType == null || ATMUser.UserType.Id == 0)
                    {
                        ATMUser.UserType = new UserTypesFactory().GetATMUserType();
                    }
                    session.SaveOrUpdate(ATMUser);
                    if (GruposSolicitudes.Count > 0 && GruposSeguimiento.Count > 0)
                    {
                        IList lstUsrGrp;
                        ICriteria GruposABorrar = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        GruposABorrar = GruposABorrar.Add(Expression.Eq("UserPassword", ATMUser.UserPassword));
                        GruposABorrar = GruposABorrar.Add(!Expression.In("RqstGrp", GruposSolicitudes));
                        lstUsrGrp = GruposABorrar.List();
                        foreach (RqstGrpPwdEntity e in lstUsrGrp)
                        {
                            session.Delete(e);
                        }
                        foreach (RequestGroupEntity Grupo in GruposSolicitudes)
                        {
                            ICriteria ExistUsrGroup = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", ATMUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                                newRqstGrpPwd.UserPassword = ATMUser.UserPassword;
                                newRqstGrpPwd.RqstGrp = Grupo;
                                newRqstGrpPwd.Auth1Usr = null;
                                newRqstGrpPwd.Auth2Usr = null;
                                session.Save(newRqstGrpPwd);
                            }
                        }

                        IList lstUsrGrpSeg;
                        ICriteria ExistUsrGroupSeg = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(Expression.Eq("UserPassword", ATMUser.UserPassword));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(!Expression.In("FollowupRqstGrp", GruposSeguimiento));
                        lstUsrGrpSeg = ExistUsrGroupSeg.List();
                        foreach (FollowupRequestGroupPasswordEntity e in lstUsrGrpSeg)
                        {
                            session.Delete(e);
                        }
                        foreach (FollowupRequestGroupEntity Grupo in GruposSeguimiento)
                        {
                            ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", ATMUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                FollowupRequestGroupPasswordEntity newRqstGrpPwdSeg = new FollowupRequestGroupPasswordEntity();
                                newRqstGrpPwdSeg.UserPassword = ATMUser.UserPassword;
                                newRqstGrpPwdSeg.FollowupRqstGrp = Grupo;
                                session.Save(newRqstGrpPwdSeg);
                            }
                        }
                    }
                    // tengo que grabar el log de modificación
                    HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory();
                    HistPwdChg.AddLog(session, (UserEntity)ATMUser);
                    tx.Commit();
                }
                return ATMUser.Id; ;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw (new CwxException(ex.Message, "ATMUserFactory.Save"));
                //return 0;
                // handle exception
            }
        }

        public string RefreshPassword(ATMUserEntity ATMUser)
        {
            string pwd = string.Empty;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(ATMUser);
                    pwd = ATMUser.UserPassword.Password;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ATMUserFactory RefreshPassword()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ATMUserFactory RefreshPassword()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ATMUserFactory RefreshPassword()"));
            }
            return pwd;
        }

        public void RefreshPassRequestList(ATMUserEntity ATMUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(ATMUser);
                    int i = ATMUser.UserPassword.RqstGrpsPwdsList.Count;
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



        public object GetATMUser(string ATMName, string UserName)
        {

            IList lstWLUs;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstWLUs = session.CreateCriteria(typeof(ATMUserEntity))
                    .Add(Expression.Eq("ATMName", ATMName))
                    .Add(Expression.Eq("Username", UserName))
                    .List();
            }

            if (lstWLUs.Count >= 1)
            {
                return (ATMUserEntity)lstWLUs[0];
            }
            else
            {
                return null;
            }

        }

        public void SetPwdState(ATMUserEntityCollection Users, bool Active)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    foreach (ATMUserEntity ATMUser in Users)
                    {
                        ATMUser.ActiveUser = Active;
                        session.Update(ATMUser);
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new CwxException(ex.Message, "ATMUserFactory.SetPwdState");
                }
            }
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("getAllATMUsers");

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
    }
}
