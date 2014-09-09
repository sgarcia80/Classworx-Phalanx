using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for RqstGrpsPwdsFactory.
	/// </summary>
	public class RqstGrpsPwdsFactory
	{
		public RqstGrpsPwdsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Busca el usuario autorizador 1 para la solicitud de una contraseña hecha por un usuario 
		/// </summary>
		/// <param name="RqstPhxUsrId">Id del usuario que hizo la solicitud</param>
		/// <param name="UserPwdId">Id del Password</param>
		/// <returns>Id del usuario Autorizador. Si no encuentra devuleve 0</returns>
		public int GetAuth1User(int RqstPhxUsrId, int UserPwdId)
		{
			int retVal;
			try
			{
				VwPhxUserRqstPwdGroupEntity objRGP = new VwPhxUserRqstPwdGroupEntity();
				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList RGPlst = session.CreateCriteria(typeof(VwPhxUserRqstPwdGroupEntity))
						.Add(Expression.Eq("UserPasswordId",UserPwdId))
						.Add(Expression.Eq("PhxUserId",RqstPhxUsrId))
						.List();

					if (RGPlst.Count == 0)
					{
						retVal = 0;
					}
					else
					{
						retVal = ((VwPhxUserRqstPwdGroupEntity)RGPlst[0]).Auth1UsrId;
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
				IList RGPlst = session.CreateCriteria(typeof(RqstGrpPwdEntity))
					.Add(Expression.Not(Expression.Eq("Auth1Usr",objAuthUsr)))
					.List();
				ITransaction tx = null;
				try
				{
					tx = session.BeginTransaction();

					foreach(RqstGrpPwdEntity objRG in RGPlst)
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
