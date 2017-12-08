using System;
using System.Reflection;
using System.Collections;
using PhalanxDAL;
using PhalanxCommon;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Cfg;
using System.Collections.Generic;
//using Nullables;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// 
	/// </summary>
	public class AS400UsersFactory : BaseFactory
	{
		/*
		Configuration config;
		ISessionFactory factory;
		ISession session;
		*/
        private ITransaction txSaveUser = null;
        private ISession SessionSaveUser = null;
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

		public AS400UsersFactory() : base()
		{
			/*
			config = new Configuration();
			IDictionary props = new Hashtable();

			props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider"; 
			props["hibernate.dialect" ] = "NHibernate.Dialect.MsSql2000Dialect"; 
			props["hibernate.connection.driver_class" ] = "NHibernate.Driver.SqlClientDriver" ;
			//props["hibernate.connection.connection_string"] = "Server=localhost;initial catalog=Northwind;Integrated Security=SSPI" ;
			props["hibernate.connection.connection_string"] = "initial catalog=phalanx;User ID=sa;pwd=cwxcwx;Data Source=cwxsrv001" ;
			
			foreach( DictionaryEntry de in props ) 
			{
				config.SetProperty( de.Key.ToString(), de.Value.ToString() );
			}

			//config.AddAssembly("nhibernator");
			//config.AddAssembly("PhalanxDAL");
			//config.AddClass(typeof(Users));
			Assembly nhAssembly = Assembly.Load("PhalanxDAL");
			//config.AddAssembly(nhAssembly);
			config.AddResource("PhalanxDAL.BLL.Users.hbm.xml",nhAssembly);
			config.AddResource("PhalanxDAL.BLL.AS400Entity.hbm.xml",nhAssembly);
			config.AddResource("PhalanxDAL.BLL.WinDomains.hbm.xml",nhAssembly);
			config.AddResource("PhalanxDAL.BLL.WinDomainControllers.hbm.xml",nhAssembly);
			config.AddResource("PhalanxDAL.BLL.WinGroups.hbm.xml",nhAssembly);
			config.AddResource("PhalanxDAL.BLL.UserPasswordEntity.hbm.xml",nhAssembly);

			factory = config.BuildSessionFactory();
			session = factory.OpenSession();*/
            
		}
        public AS400UsersFactory(string userlogon) : base(userlogon)
        { 
        }

		/// <summary>
		/// Make sure we clean up session etc.
		/// </summary>
		public void Dispose()
		{
			/*
			session.Dispose();
			factory.Close();
			*/
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

        private AS400Entity _filAS400PC = null;
        public AS400Entity FilAS400PC
        {
            set
            {
                _filAS400PC = value;
            }
        }

        public AS400UserEntity Refresh(AS400UserEntity User)
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
                throw (new CwxException(ObjNotFoundEx.Message, "AS400UserFactory Refresh()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "AS400UserFactory Refresh()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "AS400UserFactory Refresh()"));
            }
            return User;
        }



        public AS400UserEntityCollection GetAll()
        {
            IList<AS400UserEntity> lstWLUs;
            AS400UserEntityCollection WinLocUsrEC = new AS400UserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "WLU");
                if (_filUserName != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("Username", _filUserName, MatchMode.Anywhere));
                }
                if (_filAS400PC != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("AS400", _filAS400PC));
                }
                if (_filUsuariosActivos != null)
                {
                    DataSearch.Add(Expression.Eq("ActiveUser", _filUsuariosActivos));
                }
                if (_filUsuariosCriticos != null)
                {
                    DataSearch.Add(Expression.Eq("Critical", _filUsuariosCriticos));
                }
                if (_filAS400PC == null)
                {
                }
                if (_orderName)
                {
                    DataSearch = DataSearch.CreateCriteria("AS400", "WPC");
                    DataSearch.AddOrder(Order.Asc("WPC.ServerName"));
                    DataSearch.AddOrder(Order.Asc("WLU.Username"));
                }
                if (_orderUserName)
                {
                    DataSearch = DataSearch.CreateCriteria("AS400", "WPC");
                    DataSearch.AddOrder(Order.Asc("WLU.Username"));
                    DataSearch.AddOrder(Order.Asc("WPC.ServerName"));
                }
                if (_orderFolio)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("WLU.Id"));
                }
                lstWLUs = DataSearch.List<AS400UserEntity>();
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
                WinLocUsrEC.Add(lstWLUs);

            }

            return WinLocUsrEC;

        }

        public RqstGrpPwdEntityCollection  GetGruposSolicitudes(AS400UserEntity CurrentUser)
        {
            IList<RqstGrpPwdEntity> lstRequestGroups;
            RqstGrpPwdEntityCollection colRequestGroups = new RqstGrpPwdEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(RqstGrpPwdEntity) );
                DataSearch = DataSearch.Add(Expression.Eq("UserPassword", CurrentUser.UserPassword));
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                lstRequestGroups = DataSearch.List<RqstGrpPwdEntity>();
                colRequestGroups.Add(lstRequestGroups);
            }
            return colRequestGroups;
        }


        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(AS400UserEntity CurrentUser)
        {
            IList<FollowupRequestGroupPasswordEntity> lstRequestGroups;
            FollowupRequestGroupPasswordEntityCollection colRequestGroups = new FollowupRequestGroupPasswordEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity) );
                DataSearch = DataSearch.Add(Expression.Eq("UserPassword", CurrentUser.UserPassword));
                DataSearch = DataSearch.CreateCriteria("FollowupRqstGrp", "FOLLOWUPRQSTGRP");
                lstRequestGroups = DataSearch.List<FollowupRequestGroupPasswordEntity>();
                colRequestGroups.Add(lstRequestGroups);
            }
            return colRequestGroups;
        }

        public void SaveUser(AS400UserEntity winUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            txSaveUser = null;
            try
            {
                //using (ISession SessionSaveUser = DBMgr.factory.OpenSession())
                {
                    SessionSaveUser = DBMgr.factory.OpenSession();
                    txSaveUser = SessionSaveUser.BeginTransaction();
                    SessionSaveUser.SaveOrUpdate(winUser.UserPassword);
                    // crear el usuario en la base
                    SessionSaveUser.SaveOrUpdate(winUser);

                    if (GruposSolicitudes.Count > 0 && GruposSeguimiento.Count > 0)
                    {
                        IList lstUsrGrp;
                        ICriteria GruposABorrar = SessionSaveUser.CreateCriteria(typeof(RqstGrpPwdEntity));
                        GruposABorrar = GruposABorrar.Add(Expression.Eq("UserPassword", winUser.UserPassword));
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
                                SessionSaveUser.Delete(e);
                            }
                        }
                        foreach (RequestGroupEntity Grupo in GruposSolicitudes)
                        {
                            ICriteria ExistUsrGroup = SessionSaveUser.CreateCriteria(typeof(RqstGrpPwdEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", winUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                                newRqstGrpPwd.UserPassword = winUser.UserPassword;
                                newRqstGrpPwd.RqstGrp = Grupo;
                                newRqstGrpPwd.Auth1Usr = null;
                                newRqstGrpPwd.Auth2Usr = null;
                                SessionSaveUser.Save(newRqstGrpPwd);
                            }
                        }

                        IList lstUsrGrpSeg; 
                        ICriteria ExistUsrGroupSeg = SessionSaveUser.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(Expression.Eq("UserPassword", winUser.UserPassword));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(!Expression.In("FollowupRqstGrp",GruposSeguimiento));
                        lstUsrGrpSeg = ExistUsrGroupSeg.List();
                        foreach (FollowupRequestGroupPasswordEntity e in lstUsrGrpSeg)
                        {
                            if (_AvoidInactiveGrps && e.FollowupRqstGrp.Active == false)
                            {
                                /// si se evita trabajar con grupos inactivos y es inactivo no se borra
                            }
                            else
                            {
                                SessionSaveUser.Delete(e);
                            }
                        }
                        foreach (FollowupRequestGroupEntity Grupo in GruposSeguimiento)
                        {
                            ICriteria ExistUsrGroup = SessionSaveUser.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", Grupo));
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", winUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                FollowupRequestGroupPasswordEntity newRqstGrpPwdSeg = new FollowupRequestGroupPasswordEntity();
                                newRqstGrpPwdSeg.UserPassword = winUser.UserPassword;
                                newRqstGrpPwdSeg.FollowupRqstGrp = Grupo;
                                SessionSaveUser.Save(newRqstGrpPwdSeg);
                            }
                        }
                    }



                    // tengo que grabar el log de modificación
                    HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory(this.UserLogon);
                    HistPwdChg.AddLog(SessionSaveUser, (UserEntity)winUser);

                    //txSaveUser.Commit();
                }
            }
            catch (Exception ex)
            {
                //txSaveUser.Rollback();
                throw new SystemException(ex.Message);
            }
        }

        public void SaveUserCommit()
        {
            txSaveUser.Commit();
            SessionSaveUser.Close();
            SessionSaveUser = null;
        }

        public void SaveUserRollBack()
        {
            txSaveUser.Rollback();
            SessionSaveUser.Close();
            SessionSaveUser = null;
        }


        /// <summary>
		/// Get All Users, should rarely be used...
		/// </summary>
		/// <returns>Complete list of customers</returns>
        public IList GetAS400Users()
		{
			IList WLUlst = null;
			//ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				WLUlst = session.CreateCriteria(typeof(AS400UserEntity)).List();
			}
			return WLUlst;
		}
		/// <summary>
		/// Busca todos los usuarios de AS400 de una PC 
		/// </summary>
		/// <param name="PCName">Nombre de la PC</param>
		/// <returns>La lista de Usuarios de AS400</returns>
		public IList GetAS400Usrs(string PCName)
		{
			IList lstWLUs = new ArrayList();
			AS400Factory WPCF = new AS400Factory();
            AS400Entity objWPC = WPCF.GetAS400(PCName);
			if (objWPC == null)
			{
				return lstWLUs;
			}
			return this.GetAS400UsrsByAS400PC(objWPC.Id);

		}
        /// <summary>
        /// Busca todos los usuarios Locales de windows de una PC
        /// </summary>
        /// <returns>La lista de Usuarios Locales de Windows</returns>
        public IList GetAS400UsrsByAS400PC(int AS400PCId)
        {
            IList lstWLUs;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstWLUs = session.CreateCriteria(typeof(AS400UserEntity))
                    .Add(Expression.Eq("AS400Id.AS400PcId", AS400PCId))
                    .List();
            }

            return lstWLUs;
        }

         public AS400UserEntity GetAS400LocalUser(AS400Entity AS400, string UserName)
         {
             return GetAS400User( AS400.ServerName, UserName);
         }

         public AS400UserEntity GetAS400User(string PCName, string UserName)
         {
             AS400Factory WPCF = new AS400Factory();
             AS400Entity objWPC = WPCF.GetAS400(PCName);
             if (objWPC == null)
             {
                 return null;
             }

             IList lstWLUs;

             using(ISession session = DBMgr.factory.OpenSession())
             {
                 lstWLUs = session.CreateCriteria(typeof(AS400UserEntity))
                     .Add(Expression.Eq("AS400.Id",objWPC.Id))
                     .Add(Expression.Eq("Username",UserName))
                     //.Add(Expression.InsensitiveLike("Username",UserName))
                     //.Add(Expression.Sql("lower({alias}.username) = lower('"+UserName+"')"))
                     .List();
             }

             if (lstWLUs.Count == 1)
             {
                 return (AS400UserEntity)lstWLUs[0];
             }
             else
             {
                 return null;
             }

         }

         public string RefreshPassword(AS400UserEntity AS400User)
         {
             string pwd = string.Empty;
             try
             {
                 using (ISession session = DBMgr.factory.OpenSession())
                 {
                     session.Refresh(AS400User);
                     pwd = AS400User.UserPassword.Password;
                 }
             }
             catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
             {
                 throw (new CwxException(ObjNotFoundEx.Message, "AS400UsersFactory RefreshPassword()"));
             }
             catch (NHibernate.HibernateException NHEx)
             {
                 throw (new CwxException(NHEx.Message, "AS400UsersFactory RefreshPassword()"));
             }
             catch (CwxException ex)
             {
                 throw (ex);
             }
             catch (Exception ex)
             {
                 throw (new CwxException(ex.Message, "AS400UsersFactory RefreshPassword()"));
             }
             return pwd;
         }

         public void RefreshPassRequestList(AS400UserEntity AS400User)
         {
             try
             {
                 using (ISession session = DBMgr.factory.OpenSession())
                 {
                     session.Refresh(AS400User);
                     int i = AS400User.UserPassword.RqstGrpsPwdsList.Count;
                 }
             }
             catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
             {
                 throw (new CwxException(ObjNotFoundEx.Message, "RefreshPassRequestList RefreshPassword()"));
             }
             catch (NHibernate.HibernateException NHEx)
             {
                 throw (new CwxException(NHEx.Message, "RefreshPassRequestList RefreshPassword()"));
             }
             catch (CwxException ex)
             {
                 throw (ex);
             }
             catch (Exception ex)
             {
                 throw (new CwxException(ex.Message, "RefreshPassRequestList RefreshPassword()"));
             }
         }
         private string _filFiltroNombreGeneral = "";
         public string FilFiltroNombreGeneral
         {
             set { _filFiltroNombreGeneral = value; }
         }

        public AS400UserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            IList<AS400UserEntity> lstAS400Users;
            AS400UserEntityCollection AS400UsrEC = new AS400UserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "WLU");
                if (_filFiltroNombreGeneral != "")
                {
                    DataSearch.Add(Expression.Like("WLU.Username", _filFiltroNombreGeneral, MatchMode.Anywhere));
                }
                DataSearch = DataSearch.Add(Expression.Eq("WLU.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch.Add(Expression.Eq("RQSTGRP.Active", true));
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                if (_orderName)
                {
                    DataSearch = DataSearch.CreateCriteria("WLU.AS400", "WPC");
                    DataSearch.AddOrder(Order.Asc("WPC.ServerName"));
                    DataSearch.AddOrder(Order.Asc("WLU.Username"));
                }
                //DataSearch.AddOrder(Order.Asc("WPC.Name"));
                //DataSearch.AddOrder(Order.Asc("WLU.Username"));
                lstAS400Users = DataSearch.List<AS400UserEntity>();
                AS400UsrEC.Add(lstAS400Users);

            }

            return AS400UsrEC;
        }


        public AS400UserEntity GetAS400PwdForRqst(PhxUserEntity PhxUserRqst, int WLUID)
        {
            AS400UserEntity AS400UserE = null;
            IList<AS400UserEntity> lstAS400Users;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "AS400");
                DataSearch = DataSearch.Add(Expression.Eq("AS400.Id", WLUID));
                DataSearch = DataSearch.Add(Expression.Eq("AS400.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                lstAS400Users = DataSearch.List<AS400UserEntity>();
                if (lstAS400Users.Count > 0)
                {
                    AS400UserE = lstAS400Users[0];
                }
            }

            return AS400UserE;
        }
 
        /*
         public bool DeleteAS400User(string DomainName, string PCName, string UserName)
         {
             AS400Factory WPCF = new AS400Factory();
             AS400Entity objWPC = WPCF.GetAS400PC(PCName);
             if (objWPC == null)
             {
                 return false;
             }

             IList lstWLUs;

             using(ISession session = DBMgr.factory.OpenSession())
             {
                 lstWLUs = session.CreateCriteria(typeof(AS400UserEntity))
                     .Add(Expression.Eq("AS400.Id",objWPC.Id))
                     .Add(Expression.Eq("Username",UserName))
                     //.Add(Expression.InsensitiveLike("Username",UserName))
                     //.Add(Expression.Sql("lower({alias}.username) = lower('"+UserName+"')"))
                     .List();
                 if (lstWLUs.Count != 1)
                 {
                     return false;
                 }
                 session.Delete(((AS400UserEntity)lstWLUs[0]).UserPassword);

             }
             return true;


         }



         /// <summary>
         /// Lockea la contraseña por chequeo inválido
         /// </summary>
         /// <param name="AS400User"></param>
         public void UpdateCheckedUsrPwdError(AS400UserEntity AS400User)
         {
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.UpdateCheckedUsrPwdError(AS400UserEntity WLU)"
                 , "PC: " + AS400User.AS400.ServerName + "Username: " + AS400User.Username 
                 , true, false);
             PwdLockTypesFactory pltf = new PwdLockTypesFactory();
             PwdLockTypeEntity CheckNOKType = pltf.GetCheckNOKType();
             if (CheckNOKType == null)
             {
                 return;
             }

             ITransaction tx = null;

             using(ISession session = DBMgr.factory.OpenSession())
             {
                 AS400User.UserPassword.PwdLockType = CheckNOKType;
                 AS400User.ActiveUser = false;
                 tx = session.BeginTransaction();
                 session.Update(AS400User);
                 session.Update(AS400User.UserPassword);
                 tx.Commit();
             }
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Termina AS400UsersFactory.UpdateCheckedUsrPwdError(AS400UserEntity WLU)"
                 , "Sin errores"
                 , true, false);

         }
         /// <summary>
         /// Busca todos los usuarios Locales de windows de una PC cuya contraseña debe ser chequeada
         /// </summary>
         /// <returns>La lista de Usuarios Locales de Windows</returns>
         public IList GetUsrsByPwdToCheck(DateTime dChkDate)
         {
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.GetUsrsByPwdToCheck(DateTime dChkDate)"
                 , "dChkDate: " + dChkDate.ToString()
                 , true, false);
             Nullable<DateTime> nulldtChkDate = dChkDate;
             PwdLockTypesFactory pltf = new PwdLockTypesFactory();
             PwdLockTypeEntity CheckingType = pltf.GetCheckingType();
             PwdLockTypeEntity ChangingType = pltf.GetChangingType();
             PwdLockTypeEntity InUseType = pltf.GetInUseType();
             if (CheckingType == null || ChangingType == null || InUseType == null)
             {
                 return null;
             }

             ITransaction tx = null;
             string TimeOutLockChk = "3"; // expresado en minutos

             IList lstUPwd = new ArrayList();
             using(ISession session = DBMgr.factory.OpenSession())
             {
             
                 lstUPwd = session.CreateCriteria(typeof(AS400UserEntity))
                     .Add(Expression.Eq("ActiveUser",true)) // contraseñas activas
                     .CreateCriteria("UserPasswordId")
                     .Add(Expression.Eq("ChkPwd", true)) // contraseñas no estáticas
                     .Add(Expression.And( // es no lock o TO Y prox fecha de chequeo <= ahora
                                 Expression.Or( // o es (no lock o (chk o chg Time out))
                                         Expression.Sql("{alias}.d_lock_pwd is null"), // * no estén lockeadas
                                         Expression.And( // (chk o chg Time out)
                                                 Expression.Or( // que estén lockeadas por chequeo o cambio y haya pasado mas de n minutos del lockeo (se supone que hubo un error en la ejecución y no se llegó a completar la tarea)
                                                         Expression.Eq("PwdLockTypeId",ChangingType),
                                                         Expression.Eq("PwdLockTypeId", CheckingType) //	* o, que estén lockeadas por chequeo o cambio
                                                     ),
                                                 Expression.Sql("dateadd(mi,"+TimeOutLockChk+",{alias}.d_lock_pwd) <= getdate() ") // y haya pasado mas de n minutos del lockeo (se supone que hubo un error en la ejecución y no se llegó a completar la tarea)
                                             )
                                     ),
                                 Expression.Le("DNextChk", nulldtChkDate) // - cuya fecha de próximo chequeo sea <= ahora
                             )
                         )
                     .List();

                 //session.Lock(lstUPwd, LockMode.UpgradeNoWait);

                 if (lstUPwd != null)
                 {
                     foreach (AS400UserEntity wlu in lstUPwd)
                     {
                         wlu.UserPassword.PwdLockType = CheckingType;
                         tx = session.BeginTransaction();
                         session.Update(wlu.UserPassword);
                         tx.Commit();
						
                     }
                     //session.Transaction.Commit();
                 }
             }
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.GetUsrsByPwdToCheck(DateTime dChkDate)"
                 , "Devuelve " + lstUPwd.Count.ToString() + " contraseñas para chequear"
                 , true, false);
             return lstUPwd;

         }

         /// <summary>
         /// Actualiza un usuario Locales de windows de una PC cuya contraseña fue chequeada
         /// </summary>
         public void UpdateCheckedUsrPwd(AS400UserEntity objWLU, DateTime dChkDate)
         {
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.UpdateCheckedUsrPwd(AS400UserEntity objWLU ,DateTime dChkDate)"
                 , "Username: " + objWLU.Username + " - dChkDate: " + dChkDate.ToString()
                 , true, false);

             ITransaction tx = null;
             using(ISession session = DBMgr.factory.OpenSession())
             {
                 try
                 {
                     objWLU.UserPassword.DLastChk = dChkDate;
                     // se quita el lockeo que tenía
                     objWLU.UserPassword.PwdLockType = null;
                     // se borra la fecha de uso
                     objWLU.UserPassword.DInUseUntil = null;
                     Nullable<DateTime> nulldtChkDate = dChkDate;
                     // se setea la fecha de prox chequeo en base a la configuración siempre y cuando 
                     // sea menor a la fecha ingresada. En este caso también abarca si el chequeo fue caducidad de uso
                     // y por configuración debería haber sido chequeada durante el periodo en que coincidió el uso
                     while (objWLU.UserPassword.DNextChk.Value <= nulldtChkDate.Value)
                     {
                         switch (objWLU.UserPassword.ChkFreqUnit.ToUpper())
                         {
                             case "H":
                                 objWLU.UserPassword.DNextChk = objWLU.UserPassword.DNextChk.Value.AddHours(Convert.ToDouble(objWLU.UserPassword.ChkFreq));
                                 break;
                             case "D":
                                 objWLU.UserPassword.DNextChk = objWLU.UserPassword.DNextChk.Value.AddDays(Convert.ToDouble(objWLU.UserPassword.ChkFreq));
                                 break;
                             case "W":
                                 objWLU.UserPassword.DNextChk = objWLU.UserPassword.DNextChk.Value.AddDays(7*Convert.ToDouble(objWLU.UserPassword.ChkFreq));
                                 break;
                             case "M":
                                 objWLU.UserPassword.DNextChk = objWLU.UserPassword.DNextChk.Value.AddMonths(Convert.ToInt32(objWLU.UserPassword.ChkFreq));
                                 break;
                             case "Y":
                                 objWLU.UserPassword.DNextChk = objWLU.UserPassword.DNextChk.Value.AddYears(Convert.ToInt32(objWLU.UserPassword.ChkFreq));
                                 break;
                             default:
                                 break;
                         }
                     }

                     tx = session.BeginTransaction();
                     session.Update(objWLU.UserPassword);
                     tx.Commit();
                     DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                         , "AS400UsersFactory.UpdateCheckedUsrPwd(AS400UserEntity objWLU ,DateTime dChkDate)"
                         , "Actualizo OK"
                         , true, false);

                 }
                 catch (Exception ex)
                 {
                     DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
                         , "AS400UsersFactory.UpdateCheckedUsrPwd(AS400UserEntity objWLU ,DateTime dChkDate)"
                         , "Error: " + ex.Message
                         , true, false);
                     tx.Rollback();
                     // handle exception
                 }

             }

         }
         /// <summary>
         /// Actualiza un usuario Local de windows de una PC cuya contraseña fue cambiada
         /// </summary>
         public void UpdateChangedUsrPwd(AS400UserEntity objWLU, DateTime dChangeDate)
         {
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.UpdateChangedUsrPwd(AS400UserEntity objWLU ,DateTime dChangeDate)"
                 , "Username: " + objWLU.Username + " - dChangeDate: " + dChangeDate.ToString()
                 , true, false);

             ITransaction tx = null;
             using(ISession session = DBMgr.factory.OpenSession())
             {
                 try
                 {
                     objWLU.UserPassword.DLastChange = dChangeDate;
                     // se quita el lockeo que tenía
                     objWLU.UserPassword.PwdLockType = null;
                     // se borra la fecha de uso
                     objWLU.UserPassword.DInUseUntil = new DateTime();
                     Nullable<DateTime> nulldtChgDate = dChangeDate; // (NullableDateTime)dChangeDate;
                     // se setea la fecha de prox cambio en base a la configuración siempre y cuando 
                     // sea menor a la fecha ingresada. En este caso también abarca si el cambio fue caducidad de uso
                     // y por configuración debería haber sido cambiada durante el periodo en que coincidió el uso
                     while (objWLU.UserPassword.DNextChange.Value <= nulldtChgDate.Value)
                     {
                         // quizás haya que hacer un while por si el uso pasa por dos periodos de la config (while (fnextchg <= dchange))
                         switch (objWLU.UserPassword.ChangeFreqUnit.ToUpper())
                         {
                             case "H":
                                 objWLU.UserPassword.DNextChange = objWLU.UserPassword.DNextChange.Value.AddHours(Convert.ToDouble(objWLU.UserPassword.ChangeFreq));
                                 break;
                             case "D":
                                 objWLU.UserPassword.DNextChange = objWLU.UserPassword.DNextChange.Value.AddDays(Convert.ToDouble(objWLU.UserPassword.ChangeFreq));
                                 break;
                             case "W":
                                 objWLU.UserPassword.DNextChange = objWLU.UserPassword.DNextChange.Value.AddDays(7*Convert.ToDouble(objWLU.UserPassword.ChangeFreq));
                                 break;
                             case "M":
                                 objWLU.UserPassword.DNextChange = objWLU.UserPassword.DNextChange.Value.AddMonths(Convert.ToInt32(objWLU.UserPassword.ChangeFreq));
                                 break;
                             case "Y":
                                 objWLU.UserPassword.DNextChange = objWLU.UserPassword.DNextChange.Value.AddYears(Convert.ToInt32(objWLU.UserPassword.ChangeFreq));
                                 break;
                             default:
                                 break;
                         }
                     }

                     tx = session.BeginTransaction();
                     session.Update(objWLU.UserPassword);
                     tx.Commit();
                     DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                         , "AS400UsersFactory.UpdateChangedUsrPwd(AS400UserEntity objWLU ,DateTime dChangeDate)"
                         , "Actualizó OK"
                         , true, false);

                 }
                 catch (Exception ex)
                 {
                     DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
                         , "AS400UsersFactory.UpdateChangedUsrPwd(AS400UserEntity objWLU ,DateTime dChangeDate)"
                         , "Error: " + ex.Message
                         , true, false);

                     tx.Rollback();
                     // handle exception
                 }

             }

         }
         /// <summary>
         /// Busca todos los usuarios Locales de windows de una PC cuya contraseña debe ser cambiada
         /// </summary>
         /// <returns>La lista de Usuarios Locales de Windows</returns>
         public IList GetUsrsByPwdToChange(DateTime dChgDate)
         {
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "Entra a AS400UsersFactory.GetUsrsByPwdToChange(DateTime dChgDate)"
                 , "dChgDate: " + dChgDate.ToString()
                 , true, false);
             Nullable<DateTime> nulldtChgDate = dChgDate; // new NullableDateTime(dChgDate);
             PwdLockTypesFactory pltf = new PwdLockTypesFactory();
             PwdLockTypeEntity CheckingType = pltf.GetCheckingType();
             PwdLockTypeEntity ChangingType = pltf.GetChangingType();
             PwdLockTypeEntity InUseType = pltf.GetInUseType();
             if (CheckingType == null || ChangingType == null || InUseType == null)
             {
                 return null;
             }

             ITransaction tx = null;
             string TimeOutLockChg = "3"; // expresado en minutos

             IList lstUPwd = null;
             using(ISession session = DBMgr.factory.OpenSession())
             {
                 // Precondición del Caso de Uso CU02:
                 // Que existan contraseñas no estáticas y habilitadas para ser cambiadas:
                 // - cuya fecha de próximo cambio sea <= ahora y:
                 //		* no estén lockeadas
                 //		* o, que estén lockeadas por chequeo o cambio y haya pasado mas de n minutos del lockeo (se supone que hubo un error en la ejecución y no se llegó a completar la tarea)
                 //	- o, que estén lockeadas por uso y la fecha de caducidad de uso =< ahora

                 lstUPwd = session.CreateCriteria(typeof(AS400UserEntity))
                     .Add(Expression.Eq("ActiveUser",true)) // contraseñas activas
                     .CreateCriteria("UserPasswordId")
                     .Add(Expression.Eq("StaticPwd", false)) // contraseñas no estáticas
                     .Add(Expression.And(
                                 Expression.Or( // es InUse o es (no lock o (chk o chg Time out))
                                         Expression.Eq("PwdLockTypeId",InUseType), // está en uso
                                         Expression.Or( // o es (no lock o (chk o chg Time out))
                                                 Expression.Sql("{alias}.d_lock_pwd is null"), // * no estén lockeadas
                                                 Expression.And( // (chk o chg Time out)
                                                         Expression.Or( // que estén lockeadas por chequeo o cambio y haya pasado mas de n minutos del lockeo (se supone que hubo un error en la ejecución y no se llegó a completar la tarea)
                                                                 Expression.Eq("PwdLockTypeId",ChangingType),
                                                                 Expression.Eq("PwdLockTypeId", CheckingType) //	* o, que estén lockeadas por chequeo o cambio
                                                             ),
                                                         Expression.Sql("dateadd(mi,"+TimeOutLockChg+",{alias}.d_lock_pwd) <= getdate() ") // y haya pasado mas de n minutos del lockeo (se supone que hubo un error en la ejecución y no se llegó a completar la tarea)
                                                     )
                                             )
                                         ),
                                 Expression.Or( // la FUse (si hay) o la F prox cbio (si no hay use) es menor a la fecha ingresada
                                         Expression.And( // hay FUse y es menor a la fecha pasada
                                                 Expression.IsNotNull("DInUseUntil"),
                                                 Expression.Le("DInUseUntil",nulldtChgDate)
                                             ),
                                         Expression.And( // no hay FUse y la fecha de prox cambio es menor a la pasada
                                                 Expression.IsNull("DInUseUntil"),
                                                 Expression.Le("DNextChange", nulldtChgDate) // - cuya fecha de próximo cambio sea <= ahora
                                             )
                                     )
                             ))
                     .List();

                 if (lstUPwd != null)
                 {
                     foreach (AS400UserEntity wlu in lstUPwd)
                     {
                         wlu.UserPassword.PwdLockType = ChangingType;
                         tx = session.BeginTransaction();
                         session.Update(wlu.UserPassword);
                         tx.Commit();
						
                     }
                     //session.Transaction.Commit();
                 }
             }
             DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                 , "AS400UsersFactory.GetUsrsByPwdToChange(DateTime dChgDate)"
                 , "Devuelve " + lstUPwd.Count.ToString() + " contraseñas para cambiar"
                 , true, false);

             return lstUPwd;

         }

         public void SaveUser(AS400UserEntity winUser)
         {
             txSaveUser= null;
             try
             {
                 //using (ISession SessionSaveUser = DBMgr.factory.OpenSession())
                 {
                     SessionSaveUser = DBMgr.factory.OpenSession();
                     txSaveUser = SessionSaveUser.BeginTransaction();
                     SessionSaveUser.SaveOrUpdate(winUser.UserPassword);
                     // crear el usuario en la base
                     SessionSaveUser.SaveOrUpdate(winUser);
                     // tengo que grabar el log de modificación
                     HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory(this.UserLogon);
                     HistPwdChg.AddLog(SessionSaveUser, (UserEntity)winUser);

                     //txSaveUser.Commit();
                 }
             }
             catch (Exception ex)
             {
                 //txSaveUser.Rollback();
                 throw new SystemException(ex.Message);
             }
         }

         public void SaveUserCommit()
         { 
             txSaveUser.Commit();
             SessionSaveUser.Close();
             SessionSaveUser = null;
         }

         public void SaveUserRollBack()
         {
             txSaveUser.Rollback();
             SessionSaveUser.Close();
             SessionSaveUser = null;
         }

         public void Delete(AS400UserEntity winUser)
         {
             ITransaction tx = null;
             try
             {
                 using (ISession session = DBMgr.factory.OpenSession())
                 {
                     tx = session.BeginTransaction();
                     session.Delete(winUser.UserPassword);
                     // crear el usuario en la base
                     session.Delete(winUser);
                     tx.Commit();
                 }
             }
             catch (Exception ex)
             {
                 tx.Rollback();
                 throw new SystemException(ex.Message);
             }

         }
         public int CreateAS400User(string DomainName, string PCName, string UserName)
         {
             AS400Factory WPCF = new AS400Factory();
             AS400Entity objWPC = WPCF.GetAS400PC(PCName);
             if (objWPC == null)
             {
                 //return false;
                 return 0;
             }
             UserTypesFactory UTF = new UserTypesFactory();
             UserTypeEntity objUT = UTF.GetAS400UserType();
             if (objUT == null)
             {
                 //return false;
                 return 0;
             }
             ITransaction tx = null;
             using(ISession session = DBMgr.factory.OpenSession())
             {
                 try
                 {
                     tx = session.BeginTransaction();
                     UserPasswordEntity objUP = new UserPasswordEntity();
                     session.Save(objUP);
                     // crear el usuario en la base
                     AS400UserEntity objWLU = new AS400UserEntity();
                     objWLU.AS400 = objWPC;
                     objWLU.Username = UserName.ToLower();
                     objWLU.UserType = objUT;
                     objWLU.ActiveUser = false;
                     objWLU.UserPassword = objUP;
                     //tx = session.BeginTransaction();
                     session.Save(objWLU);
                     tx.Commit();
                     return objWLU.Id;
                     //return true;
                 }
                 catch (Exception ex)
                 {
                     tx.Rollback();
                     return 0;
                     //return false;
                     // handle exception
                 }
             }

         }
         public bool UpdateAS400User(AS400UserEntity AS400User)
         {
             ITransaction tx = null;
             using(ISession session = DBMgr.factory.OpenSession())
             {
                 try
                 {
                     tx = session.BeginTransaction();
                     session.Update(AS400User.UserPassword);
                     session.Update(AS400User);
                     tx.Commit();
                 }
                 catch (Exception ex)
                 {
                     tx.Rollback();
                     return false;
                     // handle exception
                 }
             }
             return true;
         }

         public AS400UserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
         {
             IList<AS400UserEntity> lstAS400Users;
             AS400UserEntityCollection AS400UsrEC = new AS400UserEntityCollection();
             using (ISession session = DBMgr.factory.OpenSession())
             {
                 ICriteria DataSearch = session.CreateCriteria(typeof(AS400UserEntity), "WLU");
                 DataSearch = DataSearch.Add(Expression.Eq("WLU.ActiveUser", true));
                 DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                 DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                 DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                 DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                 DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                 //DataSearch.AddOrder(Order.Asc("WPC.Name"));
                 //DataSearch.AddOrder(Order.Asc("WLU.Username"));
                 lstAS400Users = DataSearch.List<AS400UserEntity>();
                 AS400UsrEC.Add(lstAS400Users);

             }

             return AS400UsrEC;
         }

         public void RefreshRequestList(ref AS400UserEntity unixUser)
         {
             try
             {
                 using (ISession session = DBMgr.factory.OpenSession())
                 {
                     session.Refresh(unixUser);
                     int count = unixUser.UserPassword.PasswordsRequestsList.Count;
                     count = unixUser.UserPassword.UsersList.Count;
                 }
             }
             catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
             {
                 throw (new CwxException(ObjNotFoundEx.Message, "AS400UserFactory RefreshRequestList()"));
             }
             catch (NHibernate.HibernateException NHEx)
             {
                 throw (new CwxException(NHEx.Message, "AS400UserFactory RefreshRequestList()"));
             }
             catch (CwxException ex)
             {
                 throw (ex);
             }
             catch (Exception ex)
             {
                 throw (new CwxException(ex.Message, "AS400UserFactory RefreshRequestList()"));
             }
         }

         */

        public void SetPwdState(AS400UserEntityCollection Users, bool Active)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    foreach (AS400UserEntity AS400User in Users)
                    {
                        AS400User.ActiveUser = Active;
                        session.Update(AS400User);
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new CwxException(ex.Message, "AS400UsersFactory.SetPwdState");
                }
            }

        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("getAllAS400Users");

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

        public AS400UserEntity Load(int ID)
        {
            AS400UserEntity objPhxUsr = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                objPhxUsr = (AS400UserEntity)session.Load(typeof(AS400UserEntity), ID);
            }
            return objPhxUsr;
        }
    }
}
