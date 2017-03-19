using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using Phalanx.Util;
using PhalanxCommon.Collections;
using System.Collections.Generic;
using PhalanxCommon;
using Classworx.Common.Trace;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for PasswordsRequestsFactory.
	/// </summary>
	public class PasswordsRequestsFactory
	{
        private int? _fil_pwdrqst_id;
        public int FilPwdRqst
        {
            set
            {
                _fil_pwdrqst_id = value;
            }
        }
		public PasswordsRequestsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Guarda la solicitud de consulta de contraseña
		/// </summary>
		/// <param name="UserId">Id del usuario que se quiere consultar la contraseña</param>
		/// <param name="RequestDesc">Descripción de la solicitud</param>
		/// <param name="RqstUserId">Usuario que realizó la consulta</param>
		/// <param name="Auth1UserId">Usuario autorizador 1</param>
		/// <example>
		/// PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
		/// luego se PRF.CreateRequest(1,"deseo el psfd",1);
		/// </example>
		/// deberá implementar para Usuario Autorizador2
		public uint CreateRequest(int UserId, string RequestDesc, int RqstUserId) //, int Auth1UserId)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a PasswordsRequestsFactory.CreateRequest(int UserId, string RequestDesc, int RqstUserId)"
				, "UserId: " + UserId.ToString() + " - RequestDesc: " + RequestDesc + "RqstUserId: " + RqstUserId.ToString()
				, true, false);
			// busca el obj Usuario a raíz del UserId para traer el obj Password
			UsersFactory UF = new UsersFactory();
			UserEntity objU = UF.GetUserByID(UserId);
			if (objU == null)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}
			PasswordRequestEntity objRqst = new PasswordRequestEntity();

            objRqst.UserPassword.Id = objU.UserPassword.Id;
			objRqst.RequestDesc = RequestDesc;
			objRqst.RequestDate = DateTime.Now;

			// busca el Auth1 autorizador del PWD
			RqstGrpsPwdsFactory RGPF = new RqstGrpsPwdsFactory();
			int Auth1UserId = RGPF.GetAuth1User(RqstUserId, objU.UserPassword.Id);
			if (Auth1UserId == 0)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}
			// busca el obj PhxUser correspondiente al usuario que hizo la solicitud
			
			PhxUsersFactory PUF = new PhxUsersFactory();
			PhxUserEntity objPU = PUF.GetPhxUserByID(RqstUserId);
			if (objPU == null)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}
			objRqst.RqstUser = objPU;
            
			// si son el mismo Id de la misma tabla no instancio un objeto nuevo sino que uso el mismo
			// lo mismo va a pasar cuando agregue auth2
			// si no se hace esto PINCHAAAAAAA!!!
			if (RqstUserId == Auth1UserId)
			{
				objRqst.Auth1Usr = objPU;
			}
			else
			{
				PhxUserEntity objPUAuth1 = PUF.GetPhxUserByID(Auth1UserId);
				objRqst.Auth1Usr = objPUAuth1;
			}

			// busca el obj Request State correspondiente al Estado que tiene que pasar
			RequestStatesFactory RSF = new RequestStatesFactory();
			RequestStateEntity objRS = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.Pending);
			if (objRS == null)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}
			objRqst.RqstState = objRS;

			// otrosssss para prueba
			//objRqst.Auth1Date = DateTime.Now;
			//objRqst.Auth2Date = DateTime.Now;
			
			
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					tx = session.BeginTransaction();
					
					//session.Lock(objPU, LockMode.Read);
					/*
					session.Lock(objU, LockMode.None);
					session.Lock(objRS, LockMode.None);
					//session.Save(objPU);
					*/
					//objPU.RequestsList.Add(objRqst);
					session.SaveOrUpdate(objRqst);
					tx.Commit();
				}
				catch (Exception)
				{
					tx.Rollback();
					return PhxDALUtil.ERROR;
				}
			}
			return PhxDALUtil.SUCCESS;
		}

        //public PasswordRequestEntityCollection GetRequestsToAuthByAuth(PhxUserEntity Auth)
        //{
        //    return this.GetRequestsToAuthByAuth(Auth.Id);
        //}

		/// <summary>
		/// Busca las solicitudes pendientes de autorización. Inicialmente sería para un autorizador
        /// pero ahora supone que el usuario tiene rol de autorizador y con eso suficiente
		/// </summary>
		/// <param name="AuthId">Id del usuario Autorizador</param>
		/// <returns>Lista de Solicitudes. Devuelve null si no encuentra nada</returns>
		/// <example>
		/// PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
		/// foreach (PasswordRequestEntity objPR in PRF.GetRequestsToAuthByAuth(3))
		/// {
		/// 	int i = objPR.RequestId;
		/// }
		/// </example>
		//public PasswordRequestEntityCollection GetRequestsToAuthByAuth(int AuthId)
        public PasswordRequestEntityCollection GetRequestsToAuthByAuth(PhxUserEntity Auth)
		{
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a PasswordsRequestsFactory.GetRequestsToAuthByAuth(int AuthId)"
				, "AuthId: " + Auth.Key
				, true, false);
			IList<PasswordRequestEntity> lstRqsts = null;
			try
			{
				//ITransaction tx = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
                    // esto es para cumplir con el autorizador asignado. Por ahora lo comento
					/*lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity))
						//.Add(Expression.Eq("Auth1UsrId.PhxUserId",AuthId))
						.Add(Expression.Or(Expression.Eq("Auth1Usr.Id",AuthId),Expression.Eq("Auth2Usr.Id",AuthId)))
						.Add(Expression.Eq("RqstState.Id",(int)PhxDALUtil.RequestStates.Pending))
						.AddOrder(Order.Asc("RequestDate"))
						.List<PasswordRequestEntity>();*/

                    /*int groupId= -1;
                    IList<PhxUserGroupEntity> lstGroups = session.CreateCriteria(typeof(PhxUserGroupEntity))
                         .Add(Expression.Eq("PhxUser.Id", AuthId))
                         .List<PhxUserGroupEntity>();
                    foreach (PhxUserGroupEntity userGroup in lstGroups)
                    {
                        groupId= userGroup.RqstGrp.Id;
                        break;
                    }*/

                    /*lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity))
                        .Add(Expression.Eq("RqstState.Id", (int)PhxDALUtil.RequestStates.Pending))
                        .AddOrder(Order.Asc("RequestDate"))
                        .List<PasswordRequestEntity>();*/

                    lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity),"PwdRqst")
                        .Add(Expression.Eq("RqstState.Id", (int)PhxDALUtil.RequestStates.Pending))
                        .CreateCriteria("UserPassword","UP")
                        .CreateCriteria("UP.FollowupRqstGrpsPwdsList","FRQP")
                        .CreateCriteria("FRQP.FollowupRqstGrp","FRG")
                        .Add(Expression.Eq("FRG.Active", true))
                        .CreateCriteria("FRG.FollowupGroupUsersList","FRGU")
                        .Add(Expression.Eq("FRGU.PhxUser",Auth))
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        bool pwdInGroup = false;
                        int j = PwdRqstE.UserPassword.RqstGrpsPwdsList.Count;
                        //foreach (RqstGrpPwdEntity groups in PwdRqstE.UserPassword.RqstGrpsPwdsList)
                        //{
                        //    if (groups.RqstGrp.Id == groupId)
                        //    {
                        //        pwdInGroup= true;
                        //        break;
                        //    }
                        //}
                        //if (pwdInGroup)
                        //{
                            int i = PwdRqstE.UserPassword.UsersList.Count;
                            PwdRqstEC.Add(PwdRqstE);
                        //}
                    }
				}
			}
			catch (Exception)
			{
                return null;
			}
			return PwdRqstEC;

		}
		/// <summary>
		/// Pasa a estado autorizado la solicitud
		/// </summary>
		/// <param name="PwdRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		/// <example>
		/// PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
		/// PRF.AuthorizeRequest(1,2);
		/// </example>
		public uint AuthorizeRequest(int PwdRequestId, int AuthID, string AuthDesc)
		{
			return AuthRejectRequest(PwdRequestId, AuthID, AuthDesc, (int)PhxDALUtil.RequestStates.Authorized);
		}
		/// <summary>
		/// Pasa a estado no autorizado la solicitud
		/// </summary>
		/// <param name="PwdRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		public uint RejectRequest(int PwdRequestId, int AuthID, string AuthDesc)
		{
			return AuthRejectRequest(PwdRequestId, AuthID, AuthDesc, (int)PhxDALUtil.RequestStates.NotAuthorized);
		}
		/// <summary>
		/// Pasa del estado Pendiente al estado indicado (debería ser autorizado / rechazado)
		/// </summary>
		/// <param name="PwdRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		/// <param name="NewStateId">Id del nuevo estado al que pasa</param>
		/// <returns></returns>
		private uint AuthRejectRequest(int PwdRequestId, int AuthID, string AuthDesc, int NewStateId)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a PasswordsRequestsFactory.AuthRejectRequest(int PwdRequestId, int AuthID, string AuthDesc, int NewStateId)"
				, "PwdRequestId: " + PwdRequestId.ToString() + "AuthID: " + AuthID.ToString() + "AuthDesc: " + AuthDesc + "NewStateId: " + NewStateId.ToString()
				, true, false);
			PasswordRequestEntity PwdRqst = null;
			ITransaction tx = null;
			try
			{
				//ITransaction tx = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					// Retrieve data here (with the session)
					//ICriteria myCrit = session.CreateCriteria(typeof(WinLocalUsers));
				
				
					PwdRqst = (PasswordRequestEntity)session.Load(typeof(PasswordRequestEntity), PwdRequestId);
					if (AuthID != PwdRqst.Auth1Usr.Id && AuthID != PwdRqst.Auth2Usr.Id)
					{
						// salir con excepcion
						return PhxDALUtil.NO_DATA_FOUND;
					}
					if (PwdRqst.Auth1Usr != null && AuthID == PwdRqst.Auth1Usr.Id)
					{					
						PwdRqst.Auth1Date = DateTime.Now;
					}
					if (PwdRqst.Auth2Usr != null && AuthID == PwdRqst.Auth2Usr.Id)
					{					
						PwdRqst.Auth2Date = DateTime.Now;
					}
					
					RequestStateEntity newRqstState = null;
					RequestStatesFactory RSF = new RequestStatesFactory();
					newRqstState = RSF.GetRqstStateByID(NewStateId);
					if (newRqstState == null)
					{
						return PhxDALUtil.NO_DATA_FOUND;
					}
					PwdRqst.RqstState = newRqstState;
					PwdRqst.AuthDesc = AuthDesc;
					try
					{
						tx = session.BeginTransaction();
						session.Update(PwdRqst);
						tx.Commit();
					}
					catch (Exception ex)
					{
						tx.Rollback();
						throw(ex);
					}
                    
				}
				int i = PwdRqst.Id;
				int x = 0;
			}
			catch (NHibernate.ObjectNotFoundException ONFex)
			{
				return PhxDALUtil.NO_DATA_FOUND;
                
			}
			catch (Exception)
			{
				
				return PhxDALUtil.ERROR;
			}
			return PhxDALUtil.SUCCESS;
		}

        /// <summary>
        /// Mediante este método se devolverá una contraseña ya visualizada o expirada
        /// </summary>
        /// <param name="pwdRequestId">Contraseña a devolver</param>
        /// <param name="newStateId">Identificador del nuevo estado</param>
        /// <param name="note">Nota relativa a la devolución</param>
        /// <param name="adminUserId">Identificador del administrador que devolvió la contraseña</param>
        /// <returns>Devolverá true si la devolución se efectuó exitosamente, sino devolverá false</returns>
        public uint GetRequestPwdBack(int pwdRequestId, int newStateId, string note, int adminUserId)
        {
            return GetRequestPwdBack(pwdRequestId, newStateId, note, adminUserId, false);
        }
        public uint GetRequestPwdBack(int pwdRequestId, int newStateId, string note, int adminUserId, bool DisableUser )
        {
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entro a PasswordsRequestsFactory.GetRequestPwdBack(int pwdRequestId, int newStateId, string note, int adminUserId, bool DisableUser )"
                , "PwdRequestId: " + pwdRequestId.ToString()  + "NewStateId: " + newStateId.ToString()
                , true, false);
            PasswordRequestEntity PwdRqst = null;
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = (PasswordRequestEntity)session.Load(typeof(PasswordRequestEntity), pwdRequestId);

                    PwdRqst.ReturnDate = DateTime.Now;
                    PwdRqst.ReturnNote = note;
                    //PwdRqst.UserPassword.PwdLockType = null;
                    //PwdRqst.UserPassword.DInUseUntil = null;

                    if (adminUserId > 0)
                        PwdRqst.ReturnUser = PwdRqst.RqstUser;
                    else
                        PwdRqst.ReturnUser = null;
                   
                    RequestStateEntity newRqstState = null;
                    RequestStatesFactory RSF = new RequestStatesFactory();
                    newRqstState = RSF.GetRqstStateByID(newStateId);
                    
                    if (newRqstState == null)
                    {
                        return PhxDALUtil.NO_DATA_FOUND;
                    }
                    PwdRqst.RqstState = newRqstState;
                    tx = session.BeginTransaction();
                    try
                    {
                        session.Update(PwdRqst);

                        if (DisableUser)
                        {
                            PwdRqst.User.ActiveUser = false;
                            session.Update(PwdRqst.User);
                        }
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        throw (ex);
                    }

                }
                int i = PwdRqst.Id;
            }
            catch (NHibernate.ObjectNotFoundException)
            {
                return PhxDALUtil.NO_DATA_FOUND;

            }
            catch (Exception)
            {
                return PhxDALUtil.ERROR;
            }
            return PhxDALUtil.SUCCESS;
        }

        /// <summary>
        /// Mediante este método se devolverá una contraseña ya visualizada o expirada
        /// </summary>
        /// <param name="pwdRequestId">Contraseña a devolver</param>
        /// <param name="newStateId">Identificador del nuevo estado</param>
        /// <param name="note">Nota relativa al cierre</param>
        /// <param name="adminUserId">Identificador del administrador que cerró la contraseña</param>
        /// <returns>Devolverá un 0 si el cierre se efectuó exitosamente, sino devolverá otro valor</returns>
        public uint CloseRequestPwd(int pwdRequestId, int newStateId, string note, int adminUserId, bool disableUser)
        {
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entro a CloseRequestPwd (int pwdRequestId, string note, int adminUserId, bool disableUser)"
                , "PwdRequestId: " + pwdRequestId.ToString(), true, false);
            PasswordRequestEntity PwdRqst = null;
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = (PasswordRequestEntity)session.Load(typeof(PasswordRequestEntity), pwdRequestId);

                    PwdRqst.CloseDate = DateTime.Now;
                    PwdRqst.CloseNote = note;
                    PwdRqst.UserPassword.PwdLockType = null;
                    PwdRqst.UserPassword.DInUseUntil = null;

                    if (adminUserId > 0)
                        PwdRqst.CloseUser = new PhxUsersFactory().GetPhxUserByID ( adminUserId );


                    RequestStateEntity newRqstState = new RequestStatesFactory().GetRqstStateByID(newStateId);

                    if (newRqstState == null)
                    {
                        return PhxDALUtil.NO_DATA_FOUND;
                    }
                    PwdRqst.RqstState = newRqstState;
                    try
                    {
                        tx = session.BeginTransaction();
                        session.Update(PwdRqst);
                        if (disableUser)
                        {
                            PwdRqst.User.ActiveUser = false;
                            session.Update(PwdRqst.User);
                            /*
                            UserEntity newUserEntity = new UsersFactory().GetUserByID(PwdRqst.User.Id);
                            if (newUserEntity == null)
                            {
                                return PhxDALUtil.NO_DATA_FOUND;
                            }
                            newUserEntity.ActiveUser = false;
                            */
                            
                        }
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        throw (ex);
                    }

                }
                int i = PwdRqst.Id;
            }
            catch (NHibernate.ObjectNotFoundException)
            {
                return PhxDALUtil.NO_DATA_FOUND;
            }
            catch (Exception)
            {
                return PhxDALUtil.ERROR;
            }
            return PhxDALUtil.SUCCESS;
        }

		/// <summary>
		/// Busca la solicitud de contraseña correspondiente al ID
		/// </summary>
		/// <param name="PassRqstId">Id de la solicitud de contraseña</param>
		/// <returns>Devuelve la Solicitud de Contraseña. Null si no encuentra datos</returns>
		public PasswordRequestEntity GetPassRqstByID(int PassRqstId)
		{
			try
			{
				PasswordRequestEntity objPassRqst = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objPassRqst = (PasswordRequestEntity)session.Load(typeof(PasswordRequestEntity),PassRqstId);
				}
				return objPassRqst;
			}
			catch(NHibernate.ObjectNotFoundException)
			{
				return null;
			}
			catch(NHibernate.HibernateException)
			{
				return null;
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		public PasswordRequestEntity GetFullPassRqstByID(int PassRqstId)
		{
			try
			{
				PasswordRequestEntity objPassRqst = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objPassRqst = (PasswordRequestEntity)session.Load(typeof(PasswordRequestEntity),PassRqstId);
                    int i = objPassRqst.UserPassword.UsersList.Count;
				}
				return objPassRqst;
			}
			catch(NHibernate.ObjectNotFoundException)
			{
				return null;
			}
			catch(NHibernate.HibernateException)
			{
				return null;
			}
			catch(Exception ex)
			{
				return null;
			}
		}

        /// <summary>
        /// Busca las solicitudes de contraseña que estén en estado Pendiente de autorización, autorizadas y no autorizadas por usuario solicitante
        /// </summary>
        /// <param name="arrayStates">Id del usuario solicitante</param>
        /// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqst(UserEntity User, ArrayList arrayStates, string NumeroSolicitud, ArrayList arrayGroups )
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                ArrayList arrStates = new ArrayList();
                ArrayList arrGroups = new ArrayList();
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    if (arrayStates != null)
                    {
                        for (int i = 0; i < arrayStates.Count; i++)
                        {
                            if (!(arrayStates[i] is RequestStateEntity))
                            {
                                arrayStates.RemoveAt(i);
                                i--;
                            }
                        }
                        arrStates = arrayStates;
                    }
                    if (arrayGroups != null)
                    {
                        for (int i = 0; i < arrayGroups.Count; i++)
                        {
                            if (!(arrayGroups[i] is RequestGroupEntity))
                            {
                                arrayGroups.RemoveAt(i);
                                i--;
                            }
                        }
                        arrGroups = arrayGroups;
                    }


                    ICriteria DataSearch = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst");
                    if (NumeroSolicitud != "")
                    {
                        Int32 numSol = Convert.ToInt32(NumeroSolicitud);
                        DataSearch.Add(Expression.Eq("PwdRqst.Id", numSol)).CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                        .CreateCriteria("FRQP.RqstGrp", "FRG")
                        .Add(Expression.Eq("Usr.Id", User.Id))
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"));
                        DataSearch.SetProjection(Projections.Distinct(Projections.ProjectionList().Add(Projections.Property("PwdRqst.Id"), "Id")
                         .Add(Projections.Property("RqstUser"), "RqstUser")
                         .Add(Projections.Property("RequestDate"), "RequestDate")
                         .Add(Projections.Property("RqstState"), "RqstState")
                         .Add(Projections.Property("Auth1Date"), "Auth1Date")
                         .Add(Projections.Property("ReturnDate"), "ReturnDate")
                         .Add(Projections.Property("ExpirationDate"), "ExpirationDate")
                         .Add(Projections.Property("CloseDate"), "CloseDate")
                         ));
                    }
                    else
                    {
                        if (arrayStates != null && arrayGroups != null)
                        {
                            DataSearch.Add(Expression.In("RqstState", arrStates))
                            .CreateCriteria("UserPassword", "UsrPwd")
                            .CreateCriteria("UsersList", "Usr")
                            .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                            .CreateCriteria("FRQP.RqstGrp", "FRG")
                                    .Add(Expression.Eq("Usr.Id", User.Id))
                            .Add(Expression.In("FRQP.RqstGrp", arrGroups))
                            .AddOrder(Order.Asc("PwdRqst.RequestDate"));
                        }
                        else
                        {
                            if (arrayStates != null)
                            {
                                DataSearch.Add(Expression.In("RqstState", arrStates))
                               .CreateCriteria("UserPassword", "UsrPwd")
                               .CreateCriteria("UsersList", "Usr")
                               .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                               .CreateCriteria("FRQP.RqstGrp", "FRG")
                                    .Add(Expression.Eq("Usr.Id", User.Id))
                               .AddOrder(Order.Asc("PwdRqst.RequestDate"));
                            }
                            else
                            {
                                if (arrayGroups != null)
                                {
                                    DataSearch
                                   .CreateCriteria("UserPassword", "UsrPwd")
                                   .CreateCriteria("UsersList", "Usr")
                                   .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                                   .CreateCriteria("FRQP.RqstGrp", "FRG")
                                    .Add(Expression.Eq("Usr.Id", User.Id))
                                   .Add(Expression.In("FRQP.RqstGrp", arrGroups))
                                   .AddOrder(Order.Asc("PwdRqst.RequestDate"));
                                }
                                else
                                {
                                    DataSearch.CreateCriteria("UserPassword", "UsrPwd")
                                    .CreateCriteria("UsersList", "Usr")
                                    .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                                    .CreateCriteria("FRQP.RqstGrp", "FRG")
                                    .Add(Expression.Eq("Usr.Id", User.Id))
                                    .AddOrder(Order.Asc("PwdRqst.RequestDate"));

                                }
                            }
                        }
                        DataSearch.SetProjection(Projections.Distinct(Projections.ProjectionList().Add(Projections.Property("PwdRqst.Id"), "Id")
                         .Add(Projections.Property("RqstUser"), "RqstUser")
                         .Add(Projections.Property("RequestDate"), "RequestDate")
                         .Add(Projections.Property("RqstState"), "RqstState")
                         .Add(Projections.Property("Auth1Date"), "Auth1Date")
                         .Add(Projections.Property("ReturnDate"), "ReturnDate")
                         .Add(Projections.Property("ExpirationDate"), "ExpirationDate")
                         .Add(Projections.Property("CloseDate"), "CloseDate")
                         ));

                    }
                    DataSearch.SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer(typeof(PasswordRequestEntity)));

                    lstRqsts = DataSearch.List<PasswordRequestEntity>();

                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            return PwdRqstEC;
        }

        public SolicitudPwdEntityCollection GetAllPwdRqstForRpt()
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                IQuery query = session.GetNamedQuery("getAllPasswordRequests");
                IList QyrList = query.List();
                SolicitudPwdEntityCollection SolPwdEC = new SolicitudPwdEntityCollection();
                SolPwdEC.Add(QyrList);
                return SolPwdEC;
            }

        }
        /// <summary>
        /// Busca las solicitudes de contraseña que estén en estado Pendiente de autorización, autorizadas y no autorizadas por usuario solicitante
        /// </summary>
        /// <param name="arrayStates">Id del usuario solicitante</param>
        /// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqstByState(ArrayList arrayStates, ArrayList arrayGroups)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {

                ArrayList arrStates = new ArrayList();
                ArrayList arrGroups = new ArrayList();
                if (arrayStates != null || arrayGroups != null)
                {
                    using (ISession session = DBMgr.factory.OpenSession())
                    {
                        if (arrayStates != null)
                        {
                            for (int i = 0; i < arrayStates.Count; i++)
                            {
                                if (!(arrayStates[i] is RequestStateEntity))
                                {
                                    arrayStates.RemoveAt(i);
                                    i--;
                                }
                            }
                            arrStates = arrayStates;
                        }
                        if (arrayGroups != null)
                        {
                            for (int i = 0; i < arrayGroups.Count; i++)
                            {
                                if (!(arrayGroups[i] is RequestGroupEntity))
                                {
                                    arrayGroups.RemoveAt(i);
                                    i--;
                                }
                            }
                            arrGroups = arrayGroups;
                        }


                        ICriteria DataSearch = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst");
                        if (_fil_pwdrqst_id != null)
                        {
                            DataSearch.Add(Expression.Eq("Id", _fil_pwdrqst_id));
                        }
                        /*
                        PasswordRequestEntity a;
                        a.UserPassword.RqstGrpsPwdsList;
                        */
                        if (arrayStates != null && arrayGroups != null)
                        {
                            lstRqsts = DataSearch.Add(Expression.In("RqstState", arrStates))
                            .CreateCriteria("UserPassword", "UsrPwd")
                            .CreateCriteria("UsersList", "Usr")
                            .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                            .CreateCriteria("FRQP.RqstGrp", "FRG")
                            .Add(Expression.In("FRQP.RqstGrp", arrGroups))
                            .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                            .List<PasswordRequestEntity>();
                        }
                        else
                        {
                            if (arrayStates != null)
                            {
                                lstRqsts = DataSearch.Add(Expression.In("RqstState", arrStates))
                               .CreateCriteria("UserPassword", "UsrPwd")
                               .CreateCriteria("UsersList", "Usr")
                               .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                               .CreateCriteria("FRQP.RqstGrp", "FRG")
                               .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                               .List<PasswordRequestEntity>();
                            }
                            else
                            {
                                if (arrayGroups!= null)
                                {
                                    lstRqsts = DataSearch
                                   .CreateCriteria("UserPassword", "UsrPwd")
                                   .CreateCriteria("UsersList", "Usr")
                                   .CreateCriteria("UsrPwd.RqstGrpsPwdsList", "FRQP")
                                   .CreateCriteria("FRQP.RqstGrp", "FRG")
                                   .Add(Expression.In("FRQP.RqstGrp", arrGroups))
                                   .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                                   .List<PasswordRequestEntity>();
                                }
                            }

                        
                        }

                        /*RqstGrpPwdEntity a;
                        a.RqstGrp.*/
                        foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                        {
                            int i = PwdRqstE.UserPassword.UsersList.Count;
                            PwdRqstEC.Add(PwdRqstE);
                        }
                    }
                }
                else
                {
                    PwdRqstEC = GetAllPassRqst();
                }
            }
            catch (Exception ex)
            {
         
                return null;
            }
            return PwdRqstEC;
        }

        /// <summary>
        /// Devuelve todas las solicitudes de contraseña
        /// </summary>
        /// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetAllPassRqst ()
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst");
                    if (_fil_pwdrqst_id != null)
                    {
                        DataSearch.Add(Expression.Eq("Id", _fil_pwdrqst_id));
                    }

                    lstRqsts = DataSearch.CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();


                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return PwdRqstEC;
        }

		/// <summary>
		/// Busca las solicitudes de contraseña que estén en estado Pendiente de autorización, autorizadas y no autorizadas por usuario solicitante
		/// </summary>
		/// <param name="PhxUsrId">Id del usuario solicitante</param>
		/// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqstByPhxUsr(PhxUserEntity PhxUser)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
			IList<PasswordRequestEntity> lstRqsts = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
                    //UserTypeEntity WinUsrType = new UserTypesFactory().GetWinLocalUserType();

					ArrayList arrStates = new ArrayList();
					arrStates.Add((int)PhxDALUtil.RequestStates.Pending);
					arrStates.Add((int)PhxDALUtil.RequestStates.Authorized);
					arrStates.Add((int)PhxDALUtil.RequestStates.NotAuthorized);
                    arrStates.Add((int)PhxDALUtil.RequestStates.Visualized);
                    arrStates.Add((int)PhxDALUtil.RequestStates.DelDone);
                    arrStates.Add((int)PhxDALUtil.RequestStates.DelFailed);
                    arrStates.Add((int)PhxDALUtil.RequestStates.DelReverseDone);
				
					lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity),"PwdRqst")
                        .Add(Expression.Eq("RqstUser", PhxUser))
						.Add(Expression.In("RqstState.Id",arrStates))
                        .Add(Expression.Eq("RqstUser", PhxUser))
                        .CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
						.List<PasswordRequestEntity>();
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        if ((PwdRqstE.RqstState.Id == (int)PhxDALUtil.RequestStates.NotAuthorized) && (PwdRqstE.RequestDate < DateTime.Now.AddDays(-7)))
                        { 
                        }
                        else
                        {
                            PwdRqstEC.Add(PwdRqstE);
                        }
                    }
				}
			}
			catch (Exception)
			{
				return null;
			}
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqstEC;
		}
        public PasswordRequestEntityCollection GetCriticalPassRqstList(DateTime fechaDesde, DateTime fechaHasta, bool orderByFecha)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                string orderBy = "PwdRqst.UserPassword";
                if (orderByFecha)
                    orderBy = "PwdRqst.RequestDate"; 

                using (ISession session = DBMgr.factory.OpenSession())
                {
                   lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                     .Add(Expression.Between("RequestDate", fechaDesde, fechaHasta))
                        .AddOrder(Order.Asc(orderBy))
                        .List<PasswordRequestEntity>();
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqstEC;

        }

        /// <summary>
        /// Busca las solicitudes de contraseña que estén en estado Visualizadas para un usuario solicitante
        /// </summary>
        /// <param name="PhxUsrId">Id del usuario solicitante</param>
        /// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqstToGetBackByPhxUsr(PhxUserEntity PhxUser)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ArrayList arrStates = new ArrayList();
                    arrStates.Add((int)PhxDALUtil.RequestStates.Visualized);

                    lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        .Add(Expression.Eq("RqstUser", PhxUser))
                        .Add(Expression.In("RqstState.Id", arrStates))
                        .Add(Expression.Eq("RqstUser", PhxUser))
                        .CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return PwdRqstEC;
        }

        /// <summary>
        /// Devuelve las solicitudes de contraseña ya devueltas, para su cierre
        /// </summary>
        /// <param name="PhxUsrId">Id del usuario autorizador responsable de la aprobación de la solicitud</param>
        /// <returns>Devuelve la lista de solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqstToCloseByPhxUsr(PhxUserEntity authUser)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ArrayList arrStates = new ArrayList();
                    arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByAdmin);
                    arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByUser);
                    lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        .Add(Expression.In("RqstState.Id", arrStates))
                        .CreateCriteria("UserPassword", "UP")
                        .CreateCriteria("UsersList", "Usr")
                        .CreateCriteria("UP.FollowupRqstGrpsPwdsList", "FRQP")
                        .CreateCriteria("FRQP.FollowupRqstGrp", "FRG")
                        .Add(Expression.Eq("FRG.Active", true))
                        .CreateCriteria("FRG.FollowupGroupUsersList", "FRGU")
                        .Add(Expression.Eq("FRGU.PhxUser", authUser))
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();

                    /*lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        //.Add(Expression.Or( Expression.Eq ( "Auth1Usr", authUser), Expression.Eq ( "Auth2Usr", authUser)) )
                        .CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();*/
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return PwdRqstEC;
        }

        /// <summary>
        /// Devuelve las solicitudes de contraseñas en estado expiradas
        /// </summary>
        /// <returns></returns>
        public PasswordRequestEntityCollection GetExpiredPassRqstToClose()
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ArrayList arrStates = new ArrayList();
                    arrStates.Add((int)PhxDALUtil.RequestStates.Expired);
                    //arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByUser);

                    lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        //.Add(Expression.Or(Expression.Eq("Auth1Usr", authUser), Expression.Eq("Auth2Usr", authUser)))
                        .Add(Expression.In("RqstState.Id", arrStates))
                        .CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();
                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return PwdRqstEC;
        }
        public PasswordRequestEntityCollection GetExpiredPassRqstToClose(PhxUserEntity authUser)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ArrayList arrStates = new ArrayList();
                    arrStates.Add((int)PhxDALUtil.RequestStates.Expired);
                    //arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByUser);

                    /*lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        //.Add(Expression.Or(Expression.Eq("Auth1Usr", authUser), Expression.Eq("Auth2Usr", authUser)))
                        .Add(Expression.In("RqstState.Id", arrStates))
                        .CreateCriteria("UserPassword", "UsrPwd")
                        .CreateCriteria("UsersList", "Usr")
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();*/
                    lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                        .Add(Expression.In("RqstState.Id", arrStates))
                        .CreateCriteria("UserPassword", "UP")
                        .CreateCriteria("UsersList", "Usr")
                        .CreateCriteria("UP.FollowupRqstGrpsPwdsList", "FRQP")
                        .CreateCriteria("FRQP.FollowupRqstGrp", "FRG")
                        .Add(Expression.Eq("FRG.Active", true))
                        .CreateCriteria("FRG.FollowupGroupUsersList", "FRGU")
                        .Add(Expression.Eq("FRGU.PhxUser", authUser))
                        .AddOrder(Order.Asc("PwdRqst.RequestDate"))
                        .List<PasswordRequestEntity>();

                    foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                    {
                        int i = PwdRqstE.UserPassword.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return PwdRqstEC;
        }
        public bool IsAbleToPwdRqstFollowup(PasswordRequestEntity pwdRequest, PhxUserEntity authUser)
        {
            IList<FollowupRequestGroupPasswordEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    lstRqsts = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity), "FRGP")
                        .Add(Expression.Eq("FRGP.UserPassword", pwdRequest.UserPassword))
                        .CreateCriteria("FRGP.FollowupRqstGrp", "FRG")
                        .CreateCriteria("FRG.FollowupGroupUsersList", "FRGU")
                        .Add(Expression.Eq("FRGU.PhxUser", authUser))
                        .List<FollowupRequestGroupPasswordEntity>();

                    if (lstRqsts.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

		/// <summary>
		/// Devuelve la solicitud de contraseña autorizada para visualizarse al usuario que la solicitó. Pasa la contraseña al
		/// estado visualizada. Establece la nueva fecha de cambio indicada en la solicitud.
		/// </summary>
		/// <param name="PwdRequestId">Id de la solicitud de contraseña</param>
		/// <param name="RqstUsrId">Id del usuario solicitante</param>
		/// <returns>Devuelve la lista de Solicitudes de Contraseña. Si no hay datos devuelve null</returns>
		/// <example>
		/// 	PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
		///		PasswordRequestEntity objPR = PRF.GetPassRqstForView(8,2);
		///		if (objPR != null)
		///		{
		///			string strpwd = objPR.UserPassword.Password;
		///		}
		/// </example>
		public PasswordRequestEntity GetPassRqstForView(int PwdRequestId, int RqstUsrId)
		{
			IList lstRqsts = null;
			PasswordRequestEntity objPwdRqst = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity))
						.Add(Expression.Eq("Id",PwdRequestId))
						.Add(Expression.Eq("RqstUser.Id",RqstUsrId))
						.Add(Expression.Eq("RqstState.Id",(int)PhxDALUtil.RequestStates.Authorized))
						.List();
					if (lstRqsts.Count == 0)
					{
						objPwdRqst = null;
					}
					else
					{
						PwdLockTypesFactory pltf = new PwdLockTypesFactory();
						PwdLockTypeEntity InUseType = pltf.GetInUseType();
						if (InUseType == null)
						{
							return null;
						}

						// asigno el primer pwdrqst de la lista. Debería traer 1 solo
						objPwdRqst = (PasswordRequestEntity)lstRqsts[0];
						// agrego las horas asignadas a la fecha de próximo cambio de pwd
						//objPwdRqst.UserPassword.DNextChange= DateTime.Now.AddHours(Convert.ToDouble(objPwdRqst.HoursGiven));
						// seteo la fecha de uso
						objPwdRqst.UserPassword.DInUseUntil= DateTime.Now.AddHours(Convert.ToDouble(objPwdRqst.HoursGiven));
						// establezco que la contraseña está en uso
						objPwdRqst.UserPassword.PwdLockType = InUseType;
						// se va a buscar el nuevo estado del request, de visualizado
						RequestStateEntity newRqstState = null;
						RequestStatesFactory RSF = new RequestStatesFactory();
						newRqstState = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.Visualized);
						if (newRqstState == null)
						{
							// si no encuentra el estado debe devolver null
							objPwdRqst = null;
						}
						else
						{
							// asigno el nuevo estado al pwd rqst
							objPwdRqst.RqstState = newRqstState;

							ITransaction tx = null;

							// actualizo la DB
							try
							{
								tx = session.BeginTransaction();
								session.Update(objPwdRqst);
								tx.Commit();
							}
							catch (Exception ex)
							{
								tx.Rollback();
								throw(ex);
							}

						}

					}
				}
			}
			catch (Exception)
			{
				return null;
			}
			return objPwdRqst;
		}
        public int Save(PasswordRequestEntity PasswordRequest)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(PasswordRequest);
                    tx.Commit();
                    return PasswordRequest.Id;
                    //return true;
                }
                catch (Exception)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }

        public PasswordRequestEntity Load(int Id)
        {
            PasswordRequestEntity PwdRqst;
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = session.Load <PasswordRequestEntity>(Id);
                    int i = PwdRqst.UserPassword.UsersList.Count;
                    i = PwdRqst.UserPassword.PasswordsRequestsList.Count;
                    if (PwdRqst.UserPassword.PwdLockType == null)
                        PwdRqst.UserPassword.PwdLockType = new PwdLockTypeEntity();
                }
            }
            catch (Exception)
            {
                return null;
            }
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqst;
        }

        /// <summary>
        /// Visualiza una solicitud de contraseña
        /// </summary>
        /// <param name="PwdRqst">Solicitud a visualizar</param>
        /// <returns></returns>
        public bool ViewPwdRqst(PasswordRequestEntity PwdRqst)
        {
            // seteo la fecha de uso
            DateTime expirationDate = (PwdRqst.UnitGiven == "H" ? DateTime.Now.AddHours(Convert.ToDouble(PwdRqst.HoursGiven))
                : DateTime.Now.AddDays(Convert.ToDouble(PwdRqst.HoursGiven)));

            
            PwdRqst.UserPassword.DInUseUntil = expirationDate;

            PwdLockTypesFactory pltf = new PwdLockTypesFactory();
            PwdLockTypeEntity InUseType = pltf.GetInUseType();

            if (PwdRqst.ExpirationDate == null)
                PwdRqst.ExpirationDate = expirationDate;

            // establezco que la contraseña está en uso
            PwdRqst.UserPassword.PwdLockType = InUseType;
            
            // se va a buscar el nuevo estado del request, de visualizado
            RequestStateEntity newRqstState = null;
            RequestStatesFactory RSF = new RequestStatesFactory();
            newRqstState = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.Visualized);
            if (newRqstState == null)
            {
                // si no encuentra el estado debe devolver null
                return false;
            }

            // asigno el nuevo estado al pwd rqst
            PwdRqst.RqstState = newRqstState;

            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(PwdRqst);
                    session.SaveOrUpdate(PwdRqst.UserPassword);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }

            }
            return true;
        }

        public PasswordRequestEntity AcceptWinPwdRqst(PasswordRequestEntity WinPwdRqst, PhxUserEntity Autorizador,
            string ObsAuth, string TimeGiven, string UnitGiven)
        {
            RequestStateEntity newRqstState = null;
            RequestStatesFactory RSF = new RequestStatesFactory();
            newRqstState = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.Authorized);
            if (newRqstState == null)
            {
                return null;
            }

            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    //session.Refresh(WinPwdRqst);
                    //session.Refresh(Autorizador);
                    WinPwdRqst.Auth1Usr = Autorizador;
                    WinPwdRqst.Auth1Date = DateTime.Now;
                    /*
                    if (WinPwdRqst.Auth1Usr != null && WinPwdRqst.Auth1Usr.Id == Autorizador.Id)
                    {
                        WinPwdRqst.Auth1Date = DateTime.Now;
                    }
                    if (WinPwdRqst.Auth2Usr != null && WinPwdRqst.Auth2Usr.Id == Autorizador.Id)
                    {
                        WinPwdRqst.Auth2Date = DateTime.Now;
                    }*/
                    WinPwdRqst.AuthDesc = ObsAuth;
                    WinPwdRqst.HoursGiven = Convert.ToInt32(TimeGiven);
                    WinPwdRqst.UnitGiven = UnitGiven;
                    WinPwdRqst.RqstState = newRqstState;
                    // genera mail de aviso

                    session.Update(WinPwdRqst);
                    tx.Commit();
                }
            }
            catch (Exception)
            {
                tx.Rollback();
                return null;
            }
            return WinPwdRqst;
        }
        public PasswordRequestEntity RejectWinPwdRqst(PasswordRequestEntity WinPwdRqst, PhxUserEntity Autorizador,
            string ObsAuth)
        {
            RequestStateEntity newRqstState = null;
            RequestStatesFactory RSF = new RequestStatesFactory();
            newRqstState = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.NotAuthorized);
            if (newRqstState == null)
            {
                return null;
            }

            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    
                    WinPwdRqst.RqstState = newRqstState;
                    WinPwdRqst.AuthDesc = ObsAuth;
                    WinPwdRqst.Auth1Usr = Autorizador;
                    //WinPwdRqst.Auth1Usr = session.Get<PhxUserEntity>(Autorizador.Id);
                    WinPwdRqst.Auth1Date = DateTime.Now;
                    session.Update(WinPwdRqst);
                    // genera el mail de aviso
                    tx.Commit();
                }
            }
            catch (Exception)
            {
                tx.Rollback();
                return null;
            }
            return WinPwdRqst;
        }
        /// <summary>
        /// Busca las solicitudes en uso de la contraseña
        /// </summary>
        /// <param name="UserPassword">Contraseña para la que se buscan las solicitudes</param>
        /// <returns>Devuelve las solicitudes</returns>
        public PasswordRequestEntityCollection GetRequestsForPwdInUse(UserPasswordEntity UserPassword)
        {
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PasswordRequestEntity));
                    DataSearch = DataSearch.Add(Expression.Eq("UserPassword", UserPassword));
                    DataSearch = DataSearch.Add(Expression.Eq("RqstState", new RequestStatesFactory().GetRqstStateInUse()));
                    PwdRqstEC.Add(DataSearch.List<PasswordRequestEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PasswordsRequestsFactory GetRequestForPwdInUse(UserPasswordEntity UserPassword)"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PasswordsRequestsFactory GetRequestForPwdInUse(UserPasswordEntity UserPassword)"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PasswordsRequestsFactory GetRequestForPwdInUse(UserPasswordEntity UserPassword)"));
            }
            return PwdRqstEC;
        }

        public PasswordRequestEntityCollection ProcessPwdRqstExp()
        {
            PasswordRequestEntityCollection PwdRqstExpired = new PasswordRequestEntityCollection();
            PasswordRequestEntityCollection PwdRqstEC = new PasswordRequestEntityCollection();
            IList<PasswordRequestEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ArrayList arrStates = new ArrayList();
                    arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByAdmin);
                    arrStates.Add((int)PhxDALUtil.RequestStates.ReturnedByUser);

                    ITransaction tx = null;

                    try
                    {
                        tx = session.BeginTransaction();

                        TraceHelper.Information("Se consultan las solicitudes visualizadas cuya fecha expiracion ya paso");

                        lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                            .Add(Expression.Eq("RqstState.Id", (int)PhxDALUtil.RequestStates.Visualized))
                            .Add(Expression.Le("ExpirationDate", new GetDateFactory().GetDate().GetDate))
                            .List<PasswordRequestEntity>();

                        TraceHelper.Information("Se procesaran {0} solicitudes visualizadas", lstRqsts.Count);

                        foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                        {
                            PhxDALUtil.RequestStates state;

                            // si la solicitud fue de contraseña de ATM y fue vista y expirada, la contraseña se inactiva
                            if (PwdRqstE.User.UserType.Equals(new UserTypesFactory().GetATMUserType()))
                            {
                                TraceHelper.Information("Se cierra una Contraseña de ATM con Id {0}", PwdRqstE.Id);

                                PwdRqstE.User.ActiveUser = false;
                                session.Update(PwdRqstE.User);

                                PwdRqstE.CloseDate = DateTime.Now;

                                PwdRqstE.UserPassword.PwdLockType = null;
                                PwdRqstE.UserPassword.DInUseUntil = null;

                                //if (adminUserId > 0)
                                //    PwdRqst.CloseUser = new PhxUsersFactory().GetPhxUserByID(adminUserId);

                                state = PhxDALUtil.RequestStates.Closed;
                            }
                            else
                            {
                                state = PhxDALUtil.RequestStates.Expired;   // solic expirada
                            }

                            PwdRqstE.RqstState = new RequestStatesFactory().GetRqstStateByID((int)state);
                            session.Update(PwdRqstE);

                            // guarda en colección a devolver
                            PwdRqstExpired.Add(PwdRqstE);
                        }

                        TraceHelper.Information("Se consultan las Contraseñas que no fueron visualizadas dentro de las 24h de autorizadas");

                        /*Agregado por Leandro para expirar las claves que no fueron visualizadas dentro de las 24 horas de autorizadas*/
                        lstRqsts = session.CreateCriteria(typeof(PasswordRequestEntity), "PwdRqst")
                            .Add(Expression.Eq("RqstState.Id", (int)PhxDALUtil.RequestStates.Authorized))
                            .Add(Expression.Le("Auth1Date", new GetDateFactory().GetDate().GetDate.AddHours(-24)))
                            .List<PasswordRequestEntity>();

                        TraceHelper.Information("Se procesaran {0} solicitudes autorizadas", lstRqsts.Count);

                        foreach (PasswordRequestEntity PwdRqstE in lstRqsts)
                        {
                            PhxDALUtil.RequestStates state = PwdRqstE.User.UserType.Equals(new UserTypesFactory().GetATMUserType())
                                                                ? PhxDALUtil.RequestStates.Closed
                                                                : PhxDALUtil.RequestStates.Expired;

                            PwdRqstE.RqstState = new RequestStatesFactory().GetRqstStateByID((int)state);
                            PwdRqstE.ExpirationDate = DateTime.Now;
                            PwdRqstE.ExpiradaSinVisualizar = true;
                            session.Update(PwdRqstE);

                            TraceHelper.Information("Se cambia la contraseña {0} a {1}", PwdRqstE.UserDesc, PwdRqstE.RqstState.RqstStateDesc);

                            // guarda en colección a devolver
                            PwdRqstExpired.Add(PwdRqstE);
                        }
                        tx.Commit();

                        /* Fin Agregado Leandro*/

                    }
                    catch (Exception e)
                    {
                        TraceHelper.Error(e, "Error al actualizar las Contraseñas");

                        tx.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                TraceHelper.Error(ex, "Error en la conexión del proceso de expiracion");

                return PwdRqstExpired;
            }
            return PwdRqstExpired;
        }


        public int CreatePwdRqst(PasswordRequestEntity PasswordRequest)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(PasswordRequest);
                    tx.Commit();
                    return PasswordRequest.Id;
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
    }
}

