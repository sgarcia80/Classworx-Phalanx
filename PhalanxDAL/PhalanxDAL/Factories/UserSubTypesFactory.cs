using System;
using NHibernate;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxCommon;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for UserSubTypesFactory.
	/// </summary>
	public class UserSubTypesFactory
	{
		public UserSubTypesFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public UserSubTypeEntityCollection GetAll()
        {
            UserSubTypeEntityCollection WinDomLst = new UserSubTypeEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(UserSubTypeEntity));

                    DataSearch = DataSearch.AddOrder(Order.Asc("Desc"));
                    WinDomLst.Add(DataSearch.List<UserSubTypeEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "UserSubTypeFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "UserSubTypeFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "UserSubTypeFactory GetAll()"));
            }
            return WinDomLst;

        }
    }
}
