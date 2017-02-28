using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    /// <summary>
    /// Summary description for PwdLockTypesFactory.
    /// </summary>
    public class PwdLockTypesFactory
	{
		public PwdLockTypesFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public PwdLockTypeEntity GetInUseType()
		{
			return GetLockType("BEING_USED");
		}
		public PwdLockTypeEntity GetCheckNOKType()
		{
			return GetLockType("CHK_NOK");
		}
		public PwdLockTypeEntity GetCheckingType()
		{
			return GetLockType("CHECKING");
		}
		public PwdLockTypeEntity GetChangingType()
		{
			return GetLockType("CHANGING");
		}
		public PwdLockTypeEntity GetLockType(string LockType)
		{
			IList lstLockType;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstLockType = session.CreateCriteria(typeof(PwdLockTypeEntity))
					.Add(Expression.Eq("Code",LockType))
					.List();
			}
			if (lstLockType.Count == 0)
			{
				return null;
			}
			else
			{
				return (PwdLockTypeEntity)lstLockType[0];
			}

		}
	}
}
