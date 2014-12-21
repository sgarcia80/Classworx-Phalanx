using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using PhalanxDAL;
using System.Collections;

namespace PhalanxDAL.Factories
{
    public class DatabaseUserFactory
    {

        private DatabaseTypeEntity _filTipoDB;
        public DatabaseTypeEntity FilTipoDB
        {
            set { _filTipoDB = value; }
        }

        private string _filUserName = "";
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


        private DataBaseEntity _filDB;
        public DataBaseEntity FilDB
        {
            set { _filDB = value; }
        }
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
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;
        private bool _AvoidInactiveGrps = false;
        public bool SetAvoidInactiveGrps
        { set { _AvoidInactiveGrps = value; } }

        public DatabaseUserEntity Refresh(DatabaseUserEntity User)
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
                throw (new CwxException(ObjNotFoundEx.Message, "DatabaseUserFactory Refresh()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "DatabaseUserFactory Refresh()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "DatabaseUserFactory Refresh()"));
            }
            return User;
        }


        public DatabaseUserEntityCollection GetAll()
        {
            bool CriteriaDBType = false;
            bool CriteriaDB = false;
            IList<DatabaseUserEntity> lstDBUs;
            DatabaseUserEntityCollection DBUsrEC = new DatabaseUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseUserEntity), "DBU");
                if (_filUserName != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("Username", _filUserName, MatchMode.Anywhere));
                }
                if (_filDB != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("Db", _filDB));
                }
                if (_filUsuariosActivos != null)
                {
                    DataSearch.Add(Expression.Eq("ActiveUser", _filUsuariosActivos));
                }
                if (_filUsuariosCriticos != null)
                {
                    DataSearch.Add(Expression.Eq("Critical", _filUsuariosCriticos));
                }

                if (_filTipoDB != null)
                {
                        if (!CriteriaDB)
                        {
                            DataSearch.CreateCriteria("Db", "Db");
                            CriteriaDB = true;
                        }
                        
                    
                    DataSearch.Add(Expression.Eq("Db.Type", _filTipoDB));
                }
                /*
                DataSearch = DataSearch.CreateCriteria("WinPc", "WPC");
                DataSearch.CreateCriteria("WinDomain", "WD");
                DataSearch.AddOrder(Order.Asc("WD.NtName"));
                DataSearch.AddOrder(Order.Asc("WPC.Name"));*/
                //DataSearch.AddOrder(Order.Asc("Username"));
                if (_orderName)
                {
                    if (!CriteriaDB)
                    {
                        DataSearch.CreateCriteria("Db", "Db");
                        CriteriaDB = true;
                    }
                    if (!CriteriaDBType)
                    {
                        DataSearch.CreateCriteria("Db.Type", "DBT");
                        CriteriaDBType = true;
                    }
                    DataSearch = DataSearch.AddOrder(Order.Asc("DBT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Db.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("DBU.Username"));
                }
                if (_orderUserName)
                {
                    if (!CriteriaDB)
                    {
                        DataSearch.CreateCriteria("Db", "Db");
                        CriteriaDB = true;
                    }
                    if (!CriteriaDBType)
                    {
                        DataSearch.CreateCriteria("Db.Type", "DBT");
                        CriteriaDBType = true;
                    }
                    DataSearch = DataSearch.AddOrder(Order.Asc("DBU.Username"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("DBT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Db.Name"));
                }
                if (_orderFolio)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("Id"));
                }

                lstDBUs = DataSearch.List<DatabaseUserEntity>();
                if (GetGruposAsignados)
                {
                    for (int x = 0; x < lstDBUs.Count; x++)
                    {
                        int i = lstDBUs[x].UserPassword.RqstGrpsPwdsList.Count;
                    }
                }
                if (GetGruposSeguimAsignados)
                {
                    for (int x = 0; x < lstDBUs.Count; x++)
                    {
                        int i = lstDBUs[x].UserPassword.FollowupRqstGrpsPwdsList.Count;
                    }
                }
                DBUsrEC.Add(lstDBUs);

            }

            return DBUsrEC;

        }

        public DatabaseUserEntity GetDBPwdForRqst(PhxUserEntity PhxUserRqst, int DbUserID)
        {
            DatabaseUserEntity DbUsrE = null;
            IList<DatabaseUserEntity> lstDbUsers;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseUserEntity), "DbUser");
                DataSearch = DataSearch.Add(Expression.Eq("DbUser.Id", DbUserID));
                DataSearch = DataSearch.Add(Expression.Eq("DbUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                //DataSearch = DataSearch.Add(Expression.Eq("DbUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                // agregar que esté activo y no esté en uso!!!!!
                //DataSearch.AddOrder(Order.Asc("DbUser.Username"));
                lstDbUsers = DataSearch.List<DatabaseUserEntity>();
                //AppUsrEC.Add(lstAppUsers);
                if (lstDbUsers.Count > 0)
                {
                    DbUsrE = lstDbUsers[0];
                }
            }
            return DbUsrE;
        }
        private string _filFiltroNombreGeneral = "";
        public string FilFiltroNombreGeneral
        {
            set { _filFiltroNombreGeneral = value; }
        }

        public DatabaseUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            IList<DatabaseUserEntity> lstDBUs;
            DatabaseUserEntity mlstDBUs = new DatabaseUserEntity();
            //mlstDBUs.Db.Type
            DatabaseUserEntityCollection DatabaseUsrEC = new DatabaseUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseUserEntity), "DbUser");
                if (_filFiltroNombreGeneral != "")
                {
                    DataSearch.Add(Expression.Like("DbUser.Username", _filFiltroNombreGeneral, MatchMode.Anywhere));
                }
                DataSearch = DataSearch.Add(Expression.Eq("DbUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch.Add(Expression.Eq("RQSTGRP.Active", true));
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                if (_orderName)
                {
                    DataSearch.CreateCriteria("DbUser.Db", "Db");
                    DataSearch.CreateCriteria("Db.Type", "DBT");
                    DataSearch = DataSearch.AddOrder(Order.Asc("DBT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Db.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("DbUser.Username"));
                }
                //DataSearch.AddOrder(Order.Asc("WPC.Name"));
                //DataSearch.AddOrder(Order.Asc("WLU.Username"));
                lstDBUs = DataSearch.List<DatabaseUserEntity>();
                DatabaseUsrEC.Add(lstDBUs);
            }
            return DatabaseUsrEC;
        }

        public void RefreshRequestList(ref DatabaseUserEntity dbUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(dbUser);
                    int count = dbUser.UserPassword.PasswordsRequestsList.Count;
                    count = dbUser.UserPassword.UsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "DatabaseUserFactory RefreshRequestList()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "DatabaseUserFactory RefreshRequestList()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "DatabaseUserFactory RefreshRequestList()"));
            }
        }

        public RqstGrpPwdEntityCollection  GetGruposSolicitudes(DatabaseUserEntity CurrentUser)
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


        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(DatabaseUserEntity CurrentUser)
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

        public int Save(DatabaseUserEntity DBUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(DBUser.UserPassword);
                    if (DBUser.UserType == null || DBUser.UserType.Id == 0)
                    {
                        DBUser.UserType = new UserTypesFactory().GetDataBaseUserType();
                    }
                    session.SaveOrUpdate(DBUser);

                    if (GruposSolicitudes.Count > 0 && GruposSeguimiento.Count > 0)
                    {
                        IList lstUsrGrp;
                        ICriteria GruposABorrar = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        GruposABorrar = GruposABorrar.Add(Expression.Eq("UserPassword", DBUser.UserPassword));
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
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", DBUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                                newRqstGrpPwd.UserPassword = DBUser.UserPassword;
                                newRqstGrpPwd.RqstGrp = Grupo;
                                newRqstGrpPwd.Auth1Usr = null;
                                newRqstGrpPwd.Auth2Usr = null;
                                session.Save(newRqstGrpPwd);
                            }
                        }

                        IList lstUsrGrpSeg;
                        ICriteria ExistUsrGroupSeg = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(Expression.Eq("UserPassword", DBUser.UserPassword));
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
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", DBUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                FollowupRequestGroupPasswordEntity newRqstGrpPwdSeg = new FollowupRequestGroupPasswordEntity();
                                newRqstGrpPwdSeg.UserPassword = DBUser.UserPassword;
                                newRqstGrpPwdSeg.FollowupRqstGrp = Grupo;
                                session.Save(newRqstGrpPwdSeg);
                            }
                        }
                    }

                    // tengo que grabar el log de modificación
                    HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory();
                    HistPwdChg.AddLog(session, (UserEntity)DBUser);
                    tx.Commit();
                }
                return DBUser.Id; ;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw (new CwxException(ex.Message, "DatabaseUserFactory.Save"));
                //return 0;
                // handle exception
            }
        }

        public string RefreshPassword(DatabaseUserEntity DBUser)
        {
            string pwd = string.Empty;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(DBUser);
                    pwd = DBUser.UserPassword.Password;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "DatabaseUserFactory RefreshPassword()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "DatabaseUserFactory RefreshPassword()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "DatabaseUserFactory RefreshPassword()"));
            }
            return pwd;
        }

        public void RefreshPassRequestList(DatabaseUserEntity DBUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(DBUser);
                    int i = DBUser.UserPassword.RqstGrpsPwdsList.Count;
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


        public object GetDBUser(DataBaseEntity DBEntity, string UserName)
        {

			IList lstWLUs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWLUs = session.CreateCriteria(typeof(DatabaseUserEntity))
                    .Add(Expression.Eq("Db", DBEntity))
					.Add(Expression.Eq("Username",UserName))
					.List();
			}

			if (lstWLUs.Count >= 1)
			{
                return (DatabaseUserEntity)lstWLUs[0];
			}
			else
			{
				return null;
			}

        }

        public void SetPwdState(DatabaseUserEntityCollection Users, bool Active)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    foreach (DatabaseUserEntity DBUser in Users)
                    {
                        DBUser.ActiveUser = Active;
                        session.Update(DBUser);
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new CwxException(ex.Message, "DatabaseUserFactory.SetPwdState");
                }
            }
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, int? tipo, string nombre)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("getAllDatabaseUsers");

				int criticoParam = -1;
				int estadoUsuarioParam = -1;
				int tipoParam = -1;

				if (critico != null)
					criticoParam = critico.Value ? 1 : 0;

				if (estadoUsuario != null)
					estadoUsuarioParam = estadoUsuario.Value ? 1 : 0;

				if (tipo != null)
					tipoParam = tipo.Value;

				query.SetString("nombre", nombre != null ? "%" + nombre.ToUpper() + "%" : null);
				query.SetParameter("critico", criticoParam);
				query.SetInt32("estadoUsuario", estadoUsuarioParam);
				query.SetInt32("tipo", tipoParam);

				return query.List();
			}
		}

        public DatabaseUserEntity Load(int ID)
        {
            DatabaseUserEntity objPhxUsr = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                objPhxUsr = (DatabaseUserEntity)session.Load(typeof(DatabaseUserEntity), ID);
            }
            return objPhxUsr;
        }
    }
}
