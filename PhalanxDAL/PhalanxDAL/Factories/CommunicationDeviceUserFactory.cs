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
    public class CommunicationDeviceUserFactory
    {
        private CommunicationDeviceTypeEntity _filTipoEC;
        private string _filUserName = "";
        private CommunicationDeviceEntity _filEC;
        private CommunicationDeviceProtocolEntity _filProtocol;
        private bool _orderName = false;
        private bool _orderUserName = false;
        private bool _orderFolio = false;
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;

        public CommunicationDeviceTypeEntity FilTipoEC
        {
            set { _filTipoEC = value; }
        }

        public string FilUserName
        {
            set { _filUserName = value; }
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

        public CommunicationDeviceEntity FilEC
        {
            set { _filEC = value; }
        }

        public CommunicationDeviceProtocolEntity FilProtocol
        {
            set { _filProtocol = value; }
        }

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
        private bool _AvoidInactiveGrps = false;
        public bool SetAvoidInactiveGrps
        { set { _AvoidInactiveGrps = value; } }

        public CommunicationDeviceUserEntityCollection GetAll()
        {
            bool CriteriaECType = false;
            bool CriteriaEC = false;

            IList<CommunicationDeviceUserEntity> lstECUs;
            CommunicationDeviceUserEntityCollection ECUsrEC = new CommunicationDeviceUserEntityCollection();
            
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceUserEntity), "CDU");
                
                if (_filUserName != "")
                    DataSearch = DataSearch.Add(Expression.Like("Username", _filUserName, MatchMode.Anywhere));
                
                if (_filEC != null)
                    DataSearch = DataSearch.Add(Expression.Eq("CommunicationDevice", _filEC));

                if (_filTipoEC != null)
                {
                    DataSearch.CreateCriteria("CommunicationDevice", "Cd");
                    CriteriaEC = true;

                    DataSearch.Add(Expression.Eq("Cd.Type", _filTipoEC));
                }
                if (_filUsuariosActivos != null)
                {
                    DataSearch.Add(Expression.Eq("ActiveUser", _filUsuariosActivos));
                }
                if (_filUsuariosCriticos != null)
                {
                    DataSearch.Add(Expression.Eq("Critical", _filUsuariosCriticos));
                }

                if (_filProtocol != null)
                {
                    DataSearch.CreateCriteria("Protocols", "Pro");

                    DataSearch.Add(Expression.Eq("Pro.Id", _filProtocol.Id));
                }

                if (_orderName)
                {
                    if (!CriteriaEC)
                    {
                        DataSearch.CreateCriteria("CommunicationDevice", "Cd");
                        CriteriaEC = true;
                    }

                    DataSearch.CreateCriteria("Cd.Type", "CDT");
                    CriteriaECType = true;

                    DataSearch = DataSearch.AddOrder(Order.Asc("CDT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Cd.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("CDU.Username"));
                }
                if (_orderUserName)
                {
                    if (!CriteriaEC)
                    {
                        DataSearch.CreateCriteria("CommunicationDevice", "Cd");
                        CriteriaEC = true;
                    }

                    if (!CriteriaECType)
                    {
                        DataSearch.CreateCriteria("Cd.Type", "CDT");
                        CriteriaECType = true;
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("CDU.Username"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("CDT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Cd.Name"));
                }

                if (_orderFolio)
                    DataSearch = DataSearch.AddOrder(Order.Asc("Id"));

                lstECUs = DataSearch.List<CommunicationDeviceUserEntity>();
                
                if (GetGruposAsignados)
                {
                    for (int x = 0; x < lstECUs.Count; x++)
                    {
                        int i = lstECUs[x].UserPassword.RqstGrpsPwdsList.Count;
                    }
                }
                if (GetGruposSeguimAsignados)
                {
                    for (int x = 0; x < lstECUs.Count; x++)
                    {
                        int i = lstECUs[x].UserPassword.FollowupRqstGrpsPwdsList.Count;
                    }
                }

                ECUsrEC.Add(lstECUs);
            }

            return ECUsrEC;
        }

        /*
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
        */
        private string _filFiltroNombreGeneral = "";
        public string FilFiltroNombreGeneral
        {
            set { _filFiltroNombreGeneral = value; }
        }

        public CommunicationDeviceUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            IList<CommunicationDeviceUserEntity> lstCDUs;
            CommunicationDeviceUserEntity mlstCDUs = new CommunicationDeviceUserEntity();

            CommunicationDeviceUserEntityCollection CommunicationDeviceUsrEC = new CommunicationDeviceUserEntityCollection();
            
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceUserEntity), "CDUser");
                if (_filFiltroNombreGeneral != "")
                {
                    DataSearch.Add(Expression.Like("CDUser.Username", _filFiltroNombreGeneral, MatchMode.Anywhere));
                }

                DataSearch = DataSearch.Add(Expression.Eq("CDUser.ActiveUser", true));
                DataSearch = DataSearch.CreateCriteria("UserPassword", "USRPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrpsPwdsList", "RQSTGRPSPWD");
                DataSearch = DataSearch.CreateCriteria("RqstGrp", "RQSTGRP");
                DataSearch.Add(Expression.Eq("RQSTGRP.Active", true));
                DataSearch = DataSearch.CreateCriteria("PhxUsersGroupsList", "USRRQSTGRP");
                DataSearch = DataSearch.Add(Expression.Eq("PhxUser", PhxUserRqst));
                
                if (_orderName)
                {
                    DataSearch.CreateCriteria("CDUser.CommunicationDevice", "CD");
                    DataSearch.CreateCriteria("CD.Type", "CDT");
                    DataSearch = DataSearch.AddOrder(Order.Asc("CDT.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("CD.Name"));
                    DataSearch = DataSearch.AddOrder(Order.Asc("CDUser.Username"));
                }

                lstCDUs = DataSearch.List<CommunicationDeviceUserEntity>();

                CommunicationDeviceUsrEC.Add(lstCDUs);
            }

            return CommunicationDeviceUsrEC;
        }
        
        public void RefreshRequestList(ref CommunicationDeviceUserEntity cdUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(cdUser);
                    int count = cdUser.UserPassword.PasswordsRequestsList.Count;
                    count = cdUser.UserPassword.UsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "CommunicationDeviceUserFactory RefreshRequestList()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "CommunicationDeviceUserFactory RefreshRequestList()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "CommunicationDeviceUserFactory RefreshRequestList()"));
            }
        }

        public RqstGrpPwdEntityCollection  GetGruposSolicitudes(CommunicationDeviceUserEntity CurrentUser)
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


        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(CommunicationDeviceUserEntity CurrentUser)
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

        public int Save(CommunicationDeviceUserEntity CDUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {

                ITransaction tx = null;

                try
                {
                    tx = session.BeginTransaction();

                    session.SaveOrUpdate(CDUser.UserPassword);

                    if (CDUser.UserType == null || CDUser.UserType.Id == 0)
                        CDUser.UserType = new UserTypesFactory().GetCommunicationDeviceUserType();

                    session.SaveOrUpdate(CDUser);

                    if (GruposSolicitudes.Count > 0 && GruposSeguimiento.Count > 0)
                    {
                        IList lstUsrGrp;
                        ICriteria GruposABorrar = session.CreateCriteria(typeof(RqstGrpPwdEntity));
                        GruposABorrar = GruposABorrar.Add(Expression.Eq("UserPassword", CDUser.UserPassword));
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
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", CDUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                RqstGrpPwdEntity newRqstGrpPwd = new RqstGrpPwdEntity();
                                newRqstGrpPwd.UserPassword = CDUser.UserPassword;
                                newRqstGrpPwd.RqstGrp = Grupo;
                                newRqstGrpPwd.Auth1Usr = null;
                                newRqstGrpPwd.Auth2Usr = null;
                                session.Save(newRqstGrpPwd);
                            }
                        }

                        IList lstUsrGrpSeg;
                        ICriteria ExistUsrGroupSeg = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity));
                        ExistUsrGroupSeg = ExistUsrGroupSeg.Add(Expression.Eq("UserPassword", CDUser.UserPassword));
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
                            ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("UserPassword", CDUser.UserPassword));
                            IList lstYaExiste = ExistUsrGroup.List();
                            if (lstYaExiste.Count == 0)
                            {
                                FollowupRequestGroupPasswordEntity newRqstGrpPwdSeg = new FollowupRequestGroupPasswordEntity();
                                newRqstGrpPwdSeg.UserPassword = CDUser.UserPassword;
                                newRqstGrpPwdSeg.FollowupRqstGrp = Grupo;
                                session.Save(newRqstGrpPwdSeg);
                            }
                        }
                    }

                    // tengo que grabar el log de modificación
                    HistPasswordChangeFactory HistPwdChg = new HistPasswordChangeFactory();
                    HistPwdChg.AddLog(session, (UserEntity)CDUser);

                    tx.Commit();

                    return CDUser.Id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    
                    throw (new CwxException(ex.Message, "CommunicationDeviceUserFactory.Save"));
                    //return 0;
                    // handle exception
                }
            }
        }

        public CommunicationDeviceUserEntity Refresh(CommunicationDeviceUserEntity CDUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(CDUser);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "CommunicationDeviceUserFactory Refresh()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "CommunicationDeviceUserFactory Refresh()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "CommunicationDeviceUserFactory Refresh()"));
            }
            return CDUser;
        }


        public string RefreshPassword(CommunicationDeviceUserEntity CDUser)
        {
            string pwd = string.Empty;
            
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(CDUser);
                    
                    pwd = CDUser.UserPassword.Password;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "CommunicationDeviceUserFactory RefreshPassword()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "CommunicationDeviceUserFactory RefreshPassword()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "CommunicationDeviceUserFactory RefreshPassword()"));
            }
            
            return pwd;
        }
        
        public void RefreshPassRequestList(CommunicationDeviceUserEntity CDUser)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(CDUser);
                    int i = CDUser.UserPassword.RqstGrpsPwdsList.Count;
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

        public object GetCDUser(CommunicationDeviceEntity CDEntity, string UserName)
        {
            IList lstWLUs;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstWLUs = session.CreateCriteria(typeof(CommunicationDeviceUserEntity))
                    .Add(Expression.Eq("CommunicationDevice", CDEntity))
                    .Add(Expression.Eq("Username", UserName))
                    .List();
            }

            if (lstWLUs.Count >= 1)
                return (CommunicationDeviceUserEntity)lstWLUs[0];
            else
                return null;
        }

        public void SetPwdState(CommunicationDeviceUserEntityCollection Users, bool Active)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    foreach (CommunicationDeviceUserEntity CDUser in Users)
                    {
                        CDUser.ActiveUser = Active;
                        session.Update(CDUser);
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new CwxException(ex.Message, "CommunicationDeviceUserFactory.SetPwdState");
                }
            }
        }


		public IList GetAll(bool? critico, bool? estadoUsuario, int? tipo, string nombre)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("getAllCommunicationDevicesUsers");

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
        public CommunicationDeviceUserEntity Load(int ID)
        {
            CommunicationDeviceUserEntity objPhxUsr = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                objPhxUsr = (CommunicationDeviceUserEntity)session.Load(typeof(CommunicationDeviceUserEntity), ID);
            }
            return objPhxUsr;
        }
    }
}
