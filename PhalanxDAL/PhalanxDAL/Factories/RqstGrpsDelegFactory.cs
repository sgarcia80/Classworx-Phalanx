using System;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for RqstGrpsDelegFactory.
	/// </summary>
	public class RqstGrpsDelegFactory
	{
		public RqstGrpsDelegFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Busca el usuario autorizador 1 para la solicitud de delegación hecha por un usuario 
		/// </summary>
		/// <param name="RqstPhxUsrId">Id del usuario que hizo la solicitud</param>
		/// <param name="WinGroupId">Id del Grupo de windows</param>
		/// <returns>Id del usuario Autorizador. Si no encuentra devuleve 0</returns>
		public int GetAuth1User(int RqstPhxUsrId, int WinGroupId)
		{
			int retVal;
			try
			{
				VwPhxUserRqstDelGroupEntity objRGP = new VwPhxUserRqstDelGroupEntity();
				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList RGPlst = session.CreateCriteria(typeof(VwPhxUserRqstDelGroupEntity))
						.Add(Expression.Eq("WinGroupId",WinGroupId))
						.Add(Expression.Eq("PhxUserId",RqstPhxUsrId))
						.List();

					if (RGPlst.Count == 0)
					{
						retVal = 0;
					}
					else
					{
						retVal = ((VwPhxUserRqstDelGroupEntity)RGPlst[0]).Auth1UsrId;
					}
					//retVal = objRGP.Auth1UsrId;
					
				}
			}
			catch ( Exception ex)
			{
				retVal = 0;
			}
			return retVal;

		}
		public bool SetAuth1User(int RqstPhxUsrId)
		{
			PhxUsersFactory PUF = new PhxUsersFactory();
			PhxUserEntity objAuthUsr = PUF.GetPhxUserByID(RqstPhxUsrId);
			if (objAuthUsr == null)
			{
				return false;
			}
			using(ISession session = DBMgr.factory.OpenSession())
			{
				IList RGPlst = session.CreateCriteria(typeof(RqstGrpDelegEntity))
					.Add(Expression.Not(Expression.Eq("Auth1Usr",objAuthUsr)))
					.List();
				ITransaction tx = null;
				try
				{
					tx = session.BeginTransaction();

					foreach(RqstGrpDelegEntity objRG in RGPlst)
					{
						objRG.Auth1Usr = objAuthUsr;
						session.Update(objRG);
					}
					tx.Commit();
					return true;

					//retVal = objRGP.Auth1UsrId;
					
				}
			
				catch ( Exception ex)
				{
					tx.Rollback();
					return false;
				}
			}
		}

	}
}
