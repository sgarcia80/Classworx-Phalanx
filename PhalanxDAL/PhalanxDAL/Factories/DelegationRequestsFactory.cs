using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using Phalanx.Util;
using NHibernate;
using NHibernate.Expression;
//using Nullables;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for DelegationRequestsFactory.
	/// </summary>
	public class DelegationRequestsFactory
	{
		public DelegationRequestsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Guarda la solicitud de consulta de asignación en grupo
		/// </summary>
		/// <param name="UserId">Id del grupo al que se quiere asignar</param>
		/// <param name="RequestDesc">Descripción de la solicitud</param>
		/// <param name="RqstUserId">Usuario que realizó la consulta</param>
		/// <param name="Auth1UserId">Usuario autorizador 1</param>
		/// <example>
		/// 	DelegationRequestsFactory PRF = new DelegationRequestsFactory();
		///		PRF.CreateRequest(1,"deseo el psfd",1);
		/// </example>
		/// luego se deberá implementar para Usuario Autorizador2
		public uint CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId) //, int Auth1UserId)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
				, "WinGroupId: " + WinGroupId.ToString() + " - RequestDesc: " + RequestDesc + "RqstUserId: " + RqstUserId.ToString()
				, true, false);

			// busca el obj Usuario a raíz del UserId para traer el obj Password
			WinGroupsFactory WGF = new WinGroupsFactory();
			WinGroupEntity objWG = WGF.GetWinGroupByID(WinGroupId);
			if (objWG == null)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)", "No encontró el WinGroup por el wingroupId: " + WinGroupId.ToString(), true, false);
				return PhxDALUtil.NO_DATA_FOUND;
			}
			DelegationRequestEntity objRqst = new DelegationRequestEntity();

			objRqst.WinGroup.Id = objWG.Id;
			objRqst.RequestDesc = RequestDesc;
			objRqst.RequestDate = DateTime.Now;

			// busca el Auth1 autorizador del PWD
			RqstGrpsDelegFactory RGPF = new RqstGrpsDelegFactory();
			int Auth1UserId = RGPF.GetAuth1User(RqstUserId, WinGroupId);
			if (Auth1UserId == 0)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
					, "No encontró el Auth1 para el RqstUserId: " + RqstUserId.ToString() + " WinGroupId: " + WinGroupId.ToString()
					, true, false);
				return PhxDALUtil.NO_DATA_FOUND;
			}
			// busca el obj PhxUser correspondiente al usuario que hizo la solicitud
			
			PhxUsersFactory PUF = new PhxUsersFactory();
			PhxUserEntity objPU = PUF.GetPhxUserByID(RqstUserId);
			if (objPU == null)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
					, "No encontró el usuario que hizo la solicitud, RqstUserId: " + RqstUserId.ToString()
					, true, false);
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
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
					, "No encontró el RequestState para el estado pendiente", true, false);
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
					//objPU.RequestsList.Add(objRqst);
					session.SaveOrUpdate(objRqst);
					tx.Commit();
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
						, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
						, "Creó la solicitud", true, false);
				}
				catch (Exception ex)
				{
					tx.Rollback();
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
						, "DelegationRequestsFactory.CreateRequest(int WinGroupId, string RequestDesc, int RqstUserId)"
						, "Error al crear en la BD la solicitud", true, false);
					return PhxDALUtil.ERROR;
				}
			}
			return PhxDALUtil.SUCCESS;
		}

		/// <summary>
		/// Busca las solicitudes pendientes de autorización para un autorizador
		/// </summary>
		/// <param name="AuthId">Id del usuario Autorizador</param>
		/// <returns>Lista de Solicitudes. Devuelve null si no encuentra nada</returns>
		/// <example>
		/// DelegationRequestsFactory DRF = new DelegationRequestsFactory();
		/// foreach (DelegationRequestEntity objDR in DRF.GetRequestsToAuthByAuth(1))
		/// {
		/// 	int i = objDR.RequestId;
		/// }
		/// </example>
		public IList GetRequestsToAuthByAuth(int AuthId)
		{
			IList lstRqsts = null;
			try
			{
				//ITransaction tx = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					lstRqsts = session.CreateCriteria(typeof(DelegationRequestEntity))
						.Add(Expression.Or(Expression.Eq("Auth1Usr.Id",AuthId),Expression.Eq("Auth2Usr.Id",AuthId)))
						.Add(Expression.Eq("RqstState.Id",(int)PhxDALUtil.RequestStates.Pending))
						.AddOrder(Order.Asc("RequestDate"))
						.List();
				}
			}
			catch (Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.GetRequestsToAuthByAuth(int AuthId)"
					, "No encontró solicitudes pendientes para autorizar para el autorizador AuthId: " + AuthId
					, true, false);
				return null;
			}
			return lstRqsts;

		}

		/// <summary>
		/// Pasa a estado autorizado la solicitud
		/// </summary>
		/// <param name="DelRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si pudo autorizar la solicitud. PhxDALUtil.NO_DATA_FOUND si
		/// no encontró algún dato con las condiciones necesarias. PhxDALUtil.ERROR ante cualquier otro error</returns>
		/// <example>
		/// DelegationRequestsFactory DRF = new DelegationRequestsFactory();
		/// if (DRF.AuthorizeRequest(22,1,"clablabasd") != Phalanx.Util.PhxDALUtil.SUCCESS)
		/// {
		/// 	MessageBox.Show("error!");
		/// }
		/// </example>
		public uint AuthorizeRequest(int DelRequestId, int AuthID, string AuthDesc)
		{
			return AuthRejectRequest(DelRequestId, AuthID, AuthDesc, (int)PhxDALUtil.RequestStates.Authorized);
		}
		/// <summary>
		/// Pasa a estado no autorizado la solicitud
		/// </summary>
		/// <param name="DelRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si pudo rechazar la solicitud. PhxDALUtil.NO_DATA_FOUND si
		/// <example>
		/// DelegationRequestsFactory DRF = new DelegationRequestsFactory();
		/// if (DRF.RejectRequest(22,1,"clablabasd") != Phalanx.Util.PhxDALUtil.SUCCESS)
		/// {
		/// 	MessageBox.Show("error!");
		/// }
		/// </example>
		/// no encontró algún dato con las condiciones necesarias. PhxDALUtil.ERROR ante cualquier otro error</returns>
		public uint RejectRequest(int DelRequestId, int AuthID, string AuthDesc)
		{
			return AuthRejectRequest(DelRequestId, AuthID, AuthDesc, (int)PhxDALUtil.RequestStates.NotAuthorized);
		}
		/// <summary>
		/// Pasa del estado Pendiente al estado indicado (debería ser autorizado / rechazado)
		/// </summary>
		/// <param name="DelRequestId">Id de la solicitud</param>
		/// <param name="AuthID">Id del Autorizador</param>
		/// <param name="AuthDesc">Descripción del autorizador</param>
		/// <param name="NewStateId">Id del nuevo estado al que pasa</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si pudo cambiar de estado la solicitud. PhxDALUtil.NO_DATA_FOUND si
		/// no encontró algún dato con las condiciones necesarias. PhxDALUtil.ERROR ante cualquier otro error</returns>
		private uint AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)
		{
			DelegationRequestEntity DelRqst = null;
			ITransaction tx = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					// busca la solicitud correspondiente al ID y al autorizador
					DelRqst = (DelegationRequestEntity)session.Load(typeof(DelegationRequestEntity), DelRequestId);
					if (AuthID != DelRqst.Auth1Usr.Id && AuthID != DelRqst.Auth2Usr.Id)
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
							, "DelegationRequestsFactory.AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)"
							, "No encontró solicitudes pendientes para autorizar para el autorizador AuthId: " + AuthID.ToString()
							, true, false);
						// salir con excepcion porque no encontró solicitud con ese ID para ese autorizador
						return PhxDALUtil.NO_DATA_FOUND;
					}
					// dependiendo del autorizador, pone la fecha de autorización
					if (DelRqst.Auth1Usr != null && AuthID == DelRqst.Auth1Usr.Id)
					{					
						DelRqst.Auth1Date = DateTime.Now;
					}
					if (DelRqst.Auth2Usr != null && AuthID == DelRqst.Auth2Usr.Id)
					{					
						DelRqst.Auth2Date = DateTime.Now;
					}
					
					// busca el Estado por el ID que se ingresó
					RequestStateEntity newRqstState = null;
					RequestStatesFactory RSF = new RequestStatesFactory();
					newRqstState = RSF.GetRqstStateByID(NewStateId);
					if (newRqstState == null)
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
							, "DelegationRequestsFactory.AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)"
							, "No se encontró el estado de solicitud con Id:" + NewStateId.ToString()
							, true, false);

						// no se encontró el estado con ese ID
						return PhxDALUtil.NO_DATA_FOUND;
					}

					// asigna el objeto del nuevo estado a la solicitud
					DelRqst.RqstState = newRqstState;

					// asigna la descripción del autorizador
					DelRqst.AuthDesc = AuthDesc;
					try
					{
						tx = session.BeginTransaction();
						session.Update(DelRqst);
						tx.Commit();
					}
					catch (Exception ex)
					{
						tx.Rollback();
						throw(ex);
					}
                    
				}
				int i = DelRqst.Id;
				int x = 0;
			}
			catch (NHibernate.ObjectNotFoundException ONFex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)"
					, "No se pudo pasar la solicitud al estado NewStateId:" + NewStateId.ToString()
					, true, false);
				return PhxDALUtil.NO_DATA_FOUND;
                
			}
			catch (Exception ex)
			{
				
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)"
					, "No se pudo pasar la solicitud al estado NewStateId:" + NewStateId.ToString()
					, true, false);
				return PhxDALUtil.ERROR;
			}
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "DelegationRequestsFactory.AuthRejectRequest(int DelRequestId, int AuthID, string AuthDesc, int NewStateId)"
				, "Se pasó la solicitud DelRequestId: " + DelRequestId.ToString() + " al estado NewStateId:" + NewStateId.ToString()
				, true, false);
			return PhxDALUtil.SUCCESS;
		}

		/// <summary>
		/// Busca la solicitud de delegación de permisos correspondiente al Id
		/// </summary>
		/// <param name="RqstId">Id de la solicitud</param>
		/// <returns>Devuelve la solicitud de permisos. Si no encuentra datos devuelve null.</returns>
		public DelegationRequestEntity GetRequestById(int RqstId)
		{
			DelegationRequestEntity DelRqst = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					// busca la solicitud correspondiente al ID y al autorizador
					DelRqst = (DelegationRequestEntity)session.Load(typeof(DelegationRequestEntity), RqstId);
				}
			}
			catch (NHibernate.ObjectNotFoundException ONFex)
			{
				DelRqst = null;
                
			}
			catch (Exception ex)
			{
				
				DelRqst = null;
			}
			return DelRqst;

		}

		/// <summary>
		/// Graba el estado asignado a la solicitud especificada
		/// </summary>
		/// <param name="RqstId">Id de la solicitud</param>
		/// <param name="NewStateId">Estado a asignar a la solicitud</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si pudo grabar el nuevo estado de la solicitud</returns>
		private uint ChangeState(int RqstId, int NewStateId)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "DelegationRequestsFactory.ChangeState(int RqstId, int NewStateId)"
				, "RqstId: " + RqstId + " -  NewStateId: "+ NewStateId.ToString()
				, true, false);
			// Busca la solicitud por Id
			DelegationRequestEntity DelRqst = GetRequestById(RqstId);
			if (DelRqst == null)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}

			// busca el Estado por el ID que se ingresó
			RequestStateEntity newRqstState = null;
			RequestStatesFactory RSF = new RequestStatesFactory();
			newRqstState = RSF.GetRqstStateByID(NewStateId);
			if (newRqstState == null)
			{
				// no se encontró el estado con ese ID
				return PhxDALUtil.NO_DATA_FOUND;
			}

			// asigna el objeto del nuevo estado a la solicitud
			DelRqst.RqstState = newRqstState;

			// graba la solicitud
			ITransaction tx = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					tx = session.BeginTransaction();
					session.Update(DelRqst);
					tx.Commit();
				}
			}
			catch (Exception ex)
			{
				tx.Rollback();
				return PhxDALUtil.ERROR;
			}
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
				, "DelegationRequestsFactory.ChangeState(int RqstId, int NewStateId)"
				, "Graba el estado NewStateId: " + NewStateId.ToString() + " a la solicitud RqstId:" + RqstId.ToString()
				, true, false);
			return PhxDALUtil.SUCCESS;

		}

		/// <summary>
		/// Pasa la solicitud al estado Asignación de permisos realizada. Esto es cuando, luego de autorizada
		/// se pudo agregar al usuario al grupo solicitado
		/// </summary>
		/// <param name="RqstId">Id de la solicitud</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si se pudo actualizar el estado de la solicitud</returns>
		public uint DelegDone(int RqstId)
		{
			return this.ChangeState(RqstId, (int)PhxDALUtil.RequestStates.DelDone);
		}
		/// <summary>
		/// Pasa la solicitud al estado Asignación de permisos realizada. Esto es cuando, luego de
		/// expirado el tiempo que debía permanecer el usuario en el grupo, se pudo sacarlo del mismo
		/// </summary>
		/// <param name="RqstId">Id de la solicitud</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si se pudo actualizar el estado de la solicitud</returns>
		public uint DelegReverseDone(int RqstId)
		{
			return this.ChangeState(RqstId, (int)PhxDALUtil.RequestStates.DelReverseDone);
		}
		/// <summary>
		/// Pasa la solicitud al estado Asignación de permisos realizada. Esto es cuando, luego de autorizada
		/// NO se pudo agregar al usuario al grupo solicitado
		/// </summary>
		/// <param name="RqstId">Id de la solicitud</param>
		/// <returns>Devuelve PhxDALUtil.SUCCESS si se pudo actualizar el estado de la solicitud</returns>
		public uint DelegFailed(int RqstId)
		{
			return this.ChangeState(RqstId, (int)PhxDALUtil.RequestStates.DelFailed);
		}
	
		/// <summary>
		/// Busca las solicitudes de delegación de permisos que estén en estado Pendiente de autorización, 
		/// autorizadas, rechazadas y asignación realizada por usuario solicitante
		/// </summary>
		/// <param name="PhxUsrId">Id del usuario solicitante</param>
		/// <returns>Devuelve la lista de Solicitudes de asignación de permisos. Si no hay datos 
		/// devuelve null</returns>
		/// <example>
		/// DelegationRequestsFactory DRF = new DelegationRequestsFactory();
		/// foreach(DelegationRequestEntity objDR in DRF.GetDelegRqstByPhxUsr(1))
		/// {
		/// 	int i = objDR.RequestId;
		/// }
		/// </example>
		public IList GetDelegRqstByPhxUsr(int PhxUsrId)
		{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a DelegationRequestsFactory.GetDelegRqstByPhxUsr(int PhxUsrId)"
				, "PhxUsrId: " + PhxUsrId.ToString()
				, true, false);
		IList lstRqsts = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					ArrayList arrStates = new ArrayList();
					arrStates.Add((int)PhxDALUtil.RequestStates.Pending);
					arrStates.Add((int)PhxDALUtil.RequestStates.Authorized);
					arrStates.Add((int)PhxDALUtil.RequestStates.NotAuthorized);
					arrStates.Add((int)PhxDALUtil.RequestStates.DelDone);
				
					lstRqsts = session.CreateCriteria(typeof(DelegationRequestEntity))
						.Add(Expression.Eq("RqstUser.Id",PhxUsrId))
						.Add(Expression.In("RqstState.Id",arrStates))
						.AddOrder(Order.Asc("RequestDate"))
						.List();
				}
			}
			catch (Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.GetDelegRqstByPhxUsr(int PhxUsrId)"
					, "No encontró solicitudes de deleg de permisos pendientes de respuesta para el usuario PhxUsrId: " + PhxUsrId.ToString() + "ex: " + ex.Message
					, true, false);
				return null;
			}
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "DelegationRequestsFactory.GetDelegRqstByPhxUsr(int PhxUsrId)"
				, "Devuelve solicitudes de deleg de permisos pendientes de respuesta para el usuario PhxUsrId: " + PhxUsrId.ToString()
				, true, false);
			return lstRqsts;

		}

		/// <summary>
		/// Busca las solicitudes de delegación de permiso que estén en estado "delegación realizada" 
		/// y que expiraron
		/// </summary>
		/// <param name="UntilDate">Fecha que debe considerarse como expiración</param>
		/// <returns>Devuelve la lista de solicitudes que expiraron para reversar la asignación a grupo.
		/// Devuelve null si no hay datos que cumplan los criterios</returns>
		/// <example>
		/// DelegationRequestsFactory DRF = new DelegationRequestsFactory();
		/// foreach(DelegationRequestEntity objDR in DRF.GetDelegRqstToReverse(DateTime.Now))
		/// {
		/// 	int i = objDR.RequestId;
		/// }
		/// </example>
		public IList GetDelegRqstToReverse(Nullable<DateTime> UntilDate)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entro a DelegationRequestsFactory.GetDelegRqstToReverse(DateTime UntilDate)"
				, "UntilDate: " + UntilDate.ToString()
				, true, false);
			IList lstRqsts = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					lstRqsts = session.CreateCriteria(typeof(DelegationRequestEntity))
						.Add(Expression.Le("ExpirationDate",UntilDate))
						.Add(Expression.Eq("RqstState.Id",(int)PhxDALUtil.RequestStates.DelDone))
						.List();
				}
			}
			catch (Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "DelegationRequestsFactory.GetDelegRqstToReverse(DateTime UntilDate)"
					, "Error: " + ex.Message
					, true, false);
				return null;
			}
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "DelegationRequestsFactory.GetDelegRqstToReverse(DateTime UntilDate)"
				, "Devuelve " + lstRqsts.Count.ToString() + " solicitudes para reversar"
				, true, false);
			return lstRqsts;

		}
	}
}
