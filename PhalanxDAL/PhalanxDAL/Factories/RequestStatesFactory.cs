using System;
using System.Collections.Generic;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for RequestsStatesFactory.
	/// </summary>
	public class RequestStatesFactory
	{
		public RequestStatesFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Busca el Estado de la solicitud correspondiente al ID
		/// </summary>
		/// <param name="RqstStateId">Id de estado de la solicitud</param>
		/// <returns>Objeto del estado de la solicitud. Si no encuentra nada devuelve null</returns>
		public RequestStateEntity GetRqstStateByID(int RqstStateId)
		{
			try
			{
				RequestStateEntity objRqstState = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objRqstState = (RequestStateEntity)session.Load(typeof(RequestStateEntity),RqstStateId);
				}
				return objRqstState;
			}
			catch (Exception ex)
			{
				return null;
			}

		}

        public RequestStateEntity GetRqstStateInUse()
        {
            return this.GetRqstStateByID(4);
        }

        public RequestStateEntityCollection GetAll()
        {
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entra a RequestStateEntityCollectionFactory.GetAll()"
                , "No parameters "
                , true, false);
            RequestStateEntityCollection lstReqStates = new RequestStateEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstReqStates.Add(session.CreateCriteria(typeof(RequestStateEntity))
                    .AddOrder(Order.Asc("Id"))
                    .List<RequestStateEntity>());
            }
            return lstReqStates;
        }
    }
}
