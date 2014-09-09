using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using System.Collections.Generic;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for FollowupFollowupFollowupRequestGroupFactory.
	/// </summary>
    public class FollowupRequestGroupFactory
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }

        private bool? _filActivos;
        public bool? FilActivos
        {
            set { _filActivos = value; }
        }

        public FollowupRequestGroupFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }       
        private bool _filLoadPwds = false;

        public bool FilLoadPwds
        {
            set { _filLoadPwds = value; }
        }

        public FollowupRequestGroupEntityCollection GetAll()
        {
            FollowupRequestGroupEntityCollection FollowupRequestGroupEC = new FollowupRequestGroupEntityCollection();
            ICriteria DataSearch;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupEntity));
                 if (_filNombre != null && _filNombre.Trim() != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre.Trim(), MatchMode.Anywhere));
                }
                if (_filActivos != null)
                {
                    DataSearch.Add(Expression.Eq("Active", _filActivos));
                }
                DataSearch = DataSearch.AddOrder(Order.Asc("Name")); //.List();
                IList<FollowupRequestGroupEntity> lstRqstGrps = DataSearch.List<FollowupRequestGroupEntity>();
                if (_filLoadPwds)
                {
                    for (int i = 0; i < lstRqstGrps.Count; i++)
                    {
                        int x = lstRqstGrps[i].FollowupRequestGroupPasswordList.Count;
                    }
                }
                FollowupRequestGroupEC.Add(lstRqstGrps);
            }
            return FollowupRequestGroupEC;

        }

        public IList<WinLocalUserEntity> LoadWinPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<WinLocalUserEntity> WinPwdLst;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(WinLocalUserEntity), "WinLocUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("WinLocUsr.WinPc", "WinPC").
                        CreateCriteria("WinPC.WinDomain", "Domain").
                        AddOrder(Order.Asc("Domain.NtName")).
                        AddOrder(Order.Asc("WinPC.Name")).
                        AddOrder(Order.Asc("WinLocUsr.Username"));
                    /*

                    ICriteria DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity)).
                        Add(Expression.Eq("FollowupRqstGrp",RqstGrp)).CreateCriteria("UserPassword","usrpwd").
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

        public IList<DatabaseUserEntity> LoadDbPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<DatabaseUserEntity> DbPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseUserEntity), "DatabaseUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("DatabaseUsr.Db", "Db").
                        AddOrder(Order.Asc("DatabaseUsr.Username"));

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
        public IList<ApplicationUserEntity> LoadAppPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<ApplicationUserEntity> AppPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationUserEntity), "AppUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("AppUsr.Application", "Application").
                        AddOrder(Order.Asc("AppUsr.Username"));

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

        public IList<UnixUserEntity> LoadUnixPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<UnixUserEntity> UnixPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(UnixUserEntity), "UnixUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("UnixUsr.Unix", "Unix").
                        AddOrder(Order.Asc("UnixUsr.Username"));

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

        public IList<AS400UserEntity> LoadAS400Pwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<AS400UserEntity> AS400PwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "AS400Usr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("AS400Usr.AS400", "AS400").
                        AddOrder(Order.Asc("AS400Usr.Username"));

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

        public IList<CommunicationDeviceUserEntity> LoadECPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<CommunicationDeviceUserEntity> ECPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceUserEntity), "CDUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("CDUsr.CommunicationDevice", "CommunicationDevice").
                        AddOrder(Order.Asc("CDUsr.Username"));

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

        public IList<FollowupRequestGroupUserEntity> LoadPhxUsers(FollowupRequestGroupEntity RqstGrp)
        {
            IList<FollowupRequestGroupUserEntity> UserLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
//                    FollowupRequestGroupUserEntity a;a.PhxUser
//                    PhxUserEntity a;a.PhxUsersFollowupGroupsList FollowupRequestGroupUserEntityCollection
                    ICriteria DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupUserEntity)).
                        Add(Expression.Eq("FollowupRqstGrp", RqstGrp)).
                        CreateCriteria("PhxUser", "phx").
                        AddOrder(Order.Asc("phx.Username"));

                    UserLst = DataSearch.List<FollowupRequestGroupUserEntity>();

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


        public int Save(FollowupRequestGroupEntity FollowupRequestGroup)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(FollowupRequestGroup);
                    tx.Commit();
                    return FollowupRequestGroup.Id;
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
        public void SetPwdsToRqstGrp(FollowupRequestGroupEntity RequestGroup,
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
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("FollowupRqstGrp", RequestGroup));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("UserPassword", UsersPasswords)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra los que trae
                    foreach (FollowupRequestGroupPasswordEntity UsrGrpE in GrpsUserToDEL)
                    {
                        session.Delete(UsrGrpE);
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (UserPasswordEntity WinPwdINS in UsersPasswords)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            FollowupRequestGroupPasswordEntity newRqstGrpPwd = new FollowupRequestGroupPasswordEntity();
                            newRqstGrpPwd.UserPassword = WinPwdINS;
                            newRqstGrpPwd.FollowupRqstGrp = RequestGroup;
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


        public void SetPwdsToRqstGrp(FollowupRequestGroupEntity RequestGroup,
                UserPasswordEntityCollection UsersPasswords, PhxUserEntityCollection Users)
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
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("FollowupRqstGrp", RequestGroup));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("UserPassword", UsersPasswords)));
                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra los que trae
                    foreach (FollowupRequestGroupPasswordEntity UsrGrpE in GrpsUserToDEL)
                    {
                        session.Delete(UsrGrpE);
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (UserPasswordEntity WinPwdINS in UsersPasswords)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            FollowupRequestGroupPasswordEntity newRqstGrpPwd = new FollowupRequestGroupPasswordEntity();
                            newRqstGrpPwd.UserPassword = WinPwdINS;
                            newRqstGrpPwd.FollowupRqstGrp = RequestGroup;
                            session.Save(newRqstGrpPwd);
                        }
                    }
                    #endregion

                    //FollowupRequestGroupUserEntity a;
                    #region Actualización de Users
                    // trae los phxUser ACTIVOS que están grabados y no están en la collection
                    ICriteria PhxUsrDEL = session.CreateCriteria(typeof(FollowupRequestGroupUserEntity))
                    .Add(Expression.Eq("FollowupRqstGrp", RequestGroup))
                    .Add(Expression.Not(Expression.In("PhxUser", Users)));
                    // Retrieve data here (with the session)
                    IList PhxUsrToDEL;
                    PhxUsrToDEL = PhxUsrDEL.List();

                    // borra los que trae
                    foreach (FollowupRequestGroupUserEntity UsrGrpE in PhxUsrToDEL)
                    {
                        // verifica si esta activo, entonces se considera que se está editando
                        if (UsrGrpE.PhxUser.Active)
                        {
                            session.Delete(UsrGrpE);
                        }
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (PhxUserEntity WinPwdINS in Users)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupUserEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", RequestGroup));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("PhxUser", WinPwdINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            FollowupRequestGroupUserEntity newRqstGrpPwd = new FollowupRequestGroupUserEntity();
                            newRqstGrpPwd.PhxUser = WinPwdINS;
                            newRqstGrpPwd.FollowupRqstGrp = RequestGroup;
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



        public FollowupRequestGroupEntity Load(int FollowupRqstGrpID)
        {
            try
            {
                FollowupRequestGroupEntity objPhxUsr = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    objPhxUsr = (FollowupRequestGroupEntity)session.Load(typeof(FollowupRequestGroupEntity), FollowupRqstGrpID);
                }
                return objPhxUsr;
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "FollowupRequestGroupFactory Load()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "FollowupRequestGroupFactory Load()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "FollowupRequestGroupFactory Load()"));
            }

        }


        public IList<ATMUserEntity> LoadATMPwds(FollowupRequestGroupEntity RqstGrp)
        {
            IList<ATMUserEntity> ATMPwdLst;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ATMUserEntity), "ATMUsr").
                        CreateCriteria("UserPassword", "pwd").
                        CreateCriteria("FollowupRqstGrpsPwdsList", "rqstpwd").
                        Add(Expression.Eq("rqstpwd.FollowupRqstGrp", RqstGrp)).
                        AddOrder(Order.Asc("ATMUsr.Username"));

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
    }
}
