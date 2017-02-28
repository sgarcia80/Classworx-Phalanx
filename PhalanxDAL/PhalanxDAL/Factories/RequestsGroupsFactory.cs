using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for RequestsGroupsFactory.
	/// </summary>
    public class RequestsGroupsFactory
    {
        private bool? _filActivos;
        public bool? FilActivos
        {
            set { _filActivos = value; }
        }

        public RequestsGroupsFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Busca los autorizadores para un pwd y un solicitador determinado
        /// </summary>
        /// <param name="PasswordRequest"></param>
        /// <param name="PhxUsrRqst"></param>
        /// <returns></returns>
        public PhxUserEntityCollection GetRqstAuths(PasswordRequestEntity PasswordRequest) //, PhxUserEntity PhxUsrRqst)
        {
            PhxUserEntityCollection Autorizadores = new PhxUserEntityCollection();
            IList<RqstGrpPwdEntity> GrpsLst = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                    DataSearch = DataSearch.Add(Expression.Eq("UserPassword", PasswordRequest.UserPassword));
                    DataSearch = DataSearch.CreateCriteria("RqstGrp");
                    DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "usrsgrp");
                    DataSearch = DataSearch.Add(Expression.Eq("usrsgrp.PhxUser", PasswordRequest.RqstUser));
                    GrpsLst = DataSearch.List<RqstGrpPwdEntity>();
                    foreach (RqstGrpPwdEntity RqstGrpE in GrpsLst)
                    {
                        if (Autorizadores.Find(RqstGrpE.Auth1Usr.Key) == null)
                        {
                            Autorizadores.Add(RqstGrpE.Auth1Usr);
                        }
                        if (Autorizadores.Find(RqstGrpE.Auth1Usr.Key) == null)
                        {
                            Autorizadores.Add(RqstGrpE.Auth2Usr);
                        }
                    }
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return Autorizadores;

        }
        public PhxUserEntityCollection GetRqstAuths(int PasswordId, int PhxUsrRqstId)
        {
            PhxUserEntityCollection Autorizadores = new PhxUserEntityCollection();
            IList<RqstGrpPwdEntity> GrpsLst = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                    DataSearch = DataSearch.Add(Expression.Eq("UserPassword.Id", PasswordId));
                    DataSearch = DataSearch.CreateCriteria("RqstGrp");
                    DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "usrs");
                    DataSearch = DataSearch.Add(Expression.Eq("usrs.Id", PhxUsrRqstId));
                    GrpsLst = DataSearch.List<RqstGrpPwdEntity>();
                    foreach (RqstGrpPwdEntity RqstGrpE in GrpsLst)
                    {
                        if (Autorizadores.Find(RqstGrpE.Auth1Usr.Key) == null)
                        {
                            Autorizadores.Add(RqstGrpE.Auth1Usr);
                        }
                        if (Autorizadores.Find(RqstGrpE.Auth1Usr.Key) == null)
                        {
                            Autorizadores.Add(RqstGrpE.Auth2Usr);
                        }
                    }
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(int PasswordId, int PhxUsrRqstId)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(int PasswordId, int PhxUsrRqstId)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(int PasswordId, int PhxUsrRqstId)"));
            }
            return Autorizadores;

        }
        /// <summary>
        /// Busca los Grupos de solicitudes para un usuario determinado
        /// </summary>
        /// <param name="PhxUserId">Id del usuario</param>
        /// <returns>lista de roles asignados al usuario</returns>
        public IList GetRqstGrpsByPhxUserId(int PhxUserId)
        {
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entra a RequestsGroupsFactory.GetRqstGrpsByPhxUserId(int PhxUserId)"
                , "PhxUserId: " + PhxUserId.ToString()
                , true, false);
            IList lstPUG = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstPUG = session.CreateCriteria(typeof(PhxUserGroupEntity))
                    .Add(Expression.Eq("PhxUser.Id", PhxUserId))
                    .List();
            }
            IList lstRG = new ArrayList();
            foreach (PhxUserGroupEntity auxPGU in lstPUG)
            {
                lstRG.Add(auxPGU.RqstGrp);
            }
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "RequestsGroupsFactory.GetRqstGrpsByPhxUserId(int PhxUserId)"
                , "Devuelve " + lstRG.Count.ToString() + " Grupos de permisos para el usuario"
                , true, false);
            return lstRG;
        }

        /// <summary>
        /// Busca a todos los Grupos de Solicitudes del sistema
        /// </summary>
        /// <returns>Lista completa de Requests Groups del sistema ordenados por nombre</returns>
        public IList GetRequestsGroups()
        {
            IList RGlst = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                RGlst = session.CreateCriteria(typeof(RequestGroupEntity)).AddOrder(Order.Asc("RqstGrpName")).List();
            }
            return RGlst;
        }
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private bool _filATMs = false;

        public bool FilATMs
        {
            set { _filATMs = value; }
        }

        private bool _filLoadPwds = false;

        public bool FilLoadPwds
        {
            set { _filLoadPwds = value; }
        }

        public RequestGroupEntityCollection GetAll()
        {
            RequestGroupEntityCollection RequestGroupEC = new RequestGroupEntityCollection();
            ICriteria DataSearch;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                DataSearch = session.CreateCriteria(typeof(RequestGroupEntity));
                if (_filNombre != null && _filNombre.Trim() != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("RqstGrpName", _filNombre.Trim(), MatchMode.Anywhere));
                }
                if (_filATMs )
                {
                    DataSearch.Add(Expression.Like("RqstGrpName", "ATM", MatchMode.Start));
                }
                
                if (_filActivos != null)
                {
                    DataSearch.Add(Expression.Eq("Active", _filActivos));
                }
                DataSearch = DataSearch.AddOrder(Order.Asc("RqstGrpName")); //.List();
                IList<RequestGroupEntity> lstRqstGrps = DataSearch.List<RequestGroupEntity>();
                if (_filLoadPwds)
                {
                    for (int i = 0; i < lstRqstGrps.Count; i++)
                    {
                        int x = lstRqstGrps[i].RqstGrpsPwdsList.Count;
                    }
                }
                RequestGroupEC.Add(lstRqstGrps);
            }
            return RequestGroupEC;

        }

        public IList<WinLocalUserEntity> LoadWinPwds(RequestGroupEntity RqstGrp)
        {
            IList<WinLocalUserEntity> WinPwdLst;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(WinLocalUserEntity), "WinLocUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("WinLocUsr.WinPc", "WinPC").
                        CreateCriteria("WinPC.WinDomain", "Domain").
                        AddOrder(Order.Asc("Domain.NtName")).
                        AddOrder(Order.Asc("WinPC.Name")).
                        AddOrder(Order.Asc("WinLocUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("WinLocUsr.ActiveUser", _filActivos.Value));
                    }
                    /*

                    ICriteria DataSearch = session.CreateCriteria(typeof(RqstGrpPwdEntity)).
                        Add(Expression.Eq("RqstGrp",RqstGrp)).CreateCriteria("UserPassword","usrpwd").
                        CreateCriteria("UsersList","usrlst").
                        Add(Expression.Eq("UserType", new UserTypesFactory().GetWinLocalUserType()));
                     * */
                    WinPwdLst = DataSearch.List<WinLocalUserEntity>();
                    /*
                    for(int i = 0;i<WinPwdLst.Count; i++)
                    {
                        int x = WinPwdLst[i].UserPassword.UsersList.Count;
                    }*/

                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return WinPwdLst;
        }

        public IList<DatabaseUserEntity> LoadDbPwds(RequestGroupEntity RqstGrp)
        {
            IList<DatabaseUserEntity> DbPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseUserEntity), "DatabaseUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("DatabaseUsr.Db", "Db").
                        AddOrder(Order.Asc("DatabaseUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("DatabaseUsr.ActiveUser", _filActivos.Value));
                    }

                    DbPwdLst = DataSearch.List<DatabaseUserEntity>();
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return DbPwdLst;
        }

        public IList<ApplicationUserEntity> LoadAppPwds(RequestGroupEntity RqstGrp)
        {
            IList<ApplicationUserEntity> AppPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationUserEntity), "AppUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("AppUsr.Application", "Application").
                        AddOrder(Order.Asc("AppUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("AppUsr.ActiveUser", _filActivos.Value));
                    }

                    AppPwdLst = DataSearch.List<ApplicationUserEntity>();

                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return AppPwdLst;
        }

        public IList<UnixUserEntity> LoadUnixPwds(RequestGroupEntity RqstGrp)
        {
            IList<UnixUserEntity> UnixPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(UnixUserEntity), "UnixUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("UnixUsr.Unix", "Unix").
                        AddOrder(Order.Asc("UnixUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("UnixUsr.ActiveUser", _filActivos.Value));
                    }

                    UnixPwdLst = DataSearch.List<UnixUserEntity>();

                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return UnixPwdLst;
        }

        public IList<AS400UserEntity> LoadAS400Pwds(RequestGroupEntity RqstGrp)
        {
            IList<AS400UserEntity> AS400PwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "AS400Usr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("AS400Usr.AS400", "AS400").
                        AddOrder(Order.Asc("AS400Usr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("AS400Usr.ActiveUser", _filActivos.Value));
                    }

                    AS400PwdLst = DataSearch.List<AS400UserEntity>();

                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return AS400PwdLst;
        }

        public IList<ATMUserEntity> LoadATMPwds(RequestGroupEntity RqstGrp)
        {
            IList<ATMUserEntity> ATMPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ATMUserEntity), "ATMUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        AddOrder(Order.Asc("ATMUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("ATMUsr.ActiveUser", _filActivos.Value));
                    }

                    ATMPwdLst = DataSearch.List<ATMUserEntity>();

                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return ATMPwdLst;
        }

        public IList<CommunicationDeviceUserEntity> LoadECPwds(RequestGroupEntity RqstGrp)
        {
            IList<CommunicationDeviceUserEntity> ECPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceUserEntity), "CDUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("RqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.RqstGrp", RqstGrp)).
                        CreateCriteria("CDUsr.CommunicationDevice", "CommunicationDevice").
                        AddOrder(Order.Asc("CDUsr.Username"));
                    if (_filActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("CDUsr.ActiveUser", _filActivos.Value));
                    }


                    ECPwdLst = DataSearch.List<CommunicationDeviceUserEntity>();
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return ECPwdLst;
        }

        public IList<PhxUserGroupEntity> LoadPhxUsers(RequestGroupEntity RqstGrp)
        {
            IList<PhxUserGroupEntity> UserLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxUserGroupEntity)).
                        Add(Expression.Eq("RqstGrp", RqstGrp)).
                        CreateCriteria("PhxUser", "phx").
                        AddOrder(Order.Asc("phx.Username"));

                    UserLst = DataSearch.List<PhxUserGroupEntity>();
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestsGroupsFactory GetRqstAuths(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)"));
            }
            return UserLst;
        }
        public int Save(RequestGroupEntity RequestGroup)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(RequestGroup);
                    tx.Commit();
                    return RequestGroup.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }
        public void SetPwdsToRqstGrp(RequestGroupEntity RequestGroup,
                 UserPasswordEntityCollection UsersPasswords)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();
                    #region Actualización de Pwd
                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("RqstGrp", RequestGroup));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("UserPassword", UsersPasswords)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra los que trae
                    foreach (RqstGrpPwdEntity UsrGrpE in GrpsUserToDEL)
                    {
                        session.Delete(UsrGrpE);
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (UserPasswordEntity WinPwdINS in UsersPasswords)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                            newRqstGrpPwd.UserPassword = WinPwdINS;
                            newRqstGrpPwd.RqstGrp = RequestGroup;
                            newRqstGrpPwd.Auth1Usr = null;
                            newRqstGrpPwd.Auth2Usr = null;
                            session.Save(newRqstGrpPwd);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
                    //return 0;
                    // handle exception
                }
            }
        }

        public void SetPwdsToRqstGrp(RequestGroupEntity RequestGroup, UserPasswordEntityCollection UsersPasswords, PhxUserEntityCollection Users)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();
                    #region Actualización de Pwd
                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("RqstGrp", RequestGroup));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("UserPassword", UsersPasswords)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra los que trae
                    foreach (RqstGrpPwdEntity UsrGrpE in GrpsUserToDEL)
                    {
                        if (((UserEntity)UsrGrpE.UserPassword.UsersList[0]).ActiveUser)
                        {
                            session.Delete(UsrGrpE);
                        }
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (UserPasswordEntity WinPwdINS in UsersPasswords)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                            newRqstGrpPwd.UserPassword = WinPwdINS;
                            newRqstGrpPwd.RqstGrp = RequestGroup;
                            newRqstGrpPwd.Auth1Usr = null;
                            newRqstGrpPwd.Auth2Usr = null;
                            session.Save(newRqstGrpPwd);
                        }
                    }
                    #endregion


                    #region Actualización de Users
                    // trae los phxUser que están grabados y no están en la collection
                    ICriteria PhxUsrDEL = session.CreateCriteria(typeof(PhxUserGroupEntity))
                    .Add(Expression.Eq("RqstGrp", RequestGroup))
                    .Add(Expression.Not(Expression.In("PhxUser", Users)));
                    // Retrieve data here (with the session)
                    IList PhxUsrToDEL;
                    PhxUsrToDEL = PhxUsrDEL.List();

                    // borra los que trae
                    foreach (PhxUserGroupEntity UsrGrpE in PhxUsrToDEL)
                    {
                        if (UsrGrpE.PhxUser.Active)
                        {
                            session.Delete(UsrGrpE);
                        }
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (PhxUserEntity WinPwdINS in Users)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(PhxUserGroupEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("PhxUser", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            PhxUserGroupEntity newRqstGrpPwd = new PhxUserGroupEntity();
                            newRqstGrpPwd.PhxUser = WinPwdINS;
                            newRqstGrpPwd.RqstGrp = RequestGroup;
                            session.Save(newRqstGrpPwd);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
                    //return 0;
                    // handle exception
                }
            }
        }

        public RequestGroupEntity Load(int RqstGrpID)
        {
            try
            {
                RequestGroupEntity objPhxUsr = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    objPhxUsr = (RequestGroupEntity)session.Load(typeof(RequestGroupEntity), RqstGrpID);
                }
                return objPhxUsr;
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "RequestGroupFactory Load()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "RequestGroupFactory Load()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "RequestGroupFactory Load()"));
            }

        }

    }
}
