using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using System.Collections;
 
namespace PhalanxDAL.Factories
{
    public class VencPwdAppLogFactory
    {
        public void Save(VencPwdAppLogEntity entity)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                tx = session.BeginTransaction();
                try
                {
                    session.Save(entity);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw (e);

                }
            }
        }

        public VencPwdAppLogEntityCollection GetAll()
        {
            IList<VencPwdAppLogEntity> list;
            VencPwdAppLogEntityCollection collection = new VencPwdAppLogEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(VencPwdAppLogEntity)).AddOrder(Order.Desc("FechaEjecucion"));

                list = DataSearch.List<VencPwdAppLogEntity>();
                collection.Add(list);

            }

            return collection;

        }
    }
}
