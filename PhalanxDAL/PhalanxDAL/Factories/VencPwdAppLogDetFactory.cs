using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Metadata;
using PhalanxCommon;
using System.Collections;
 
namespace PhalanxDAL.Factories
{
    public class VencPwdAppLogDetFactory
    {

        public void Save(VencPwdAppLogDetEntity entity)
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

        public VencPwdAppLogDetEntityCollection GetAll()
        {
            IList<VencPwdAppLogDetEntity> list;
            VencPwdAppLogDetEntityCollection collection = new VencPwdAppLogDetEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(VencPwdAppLogDetEntity)).AddOrder(Order.Desc("FechaEjecucion"));

                list = DataSearch.List<VencPwdAppLogDetEntity>();
                collection.Add(list);

            }

            return collection;

        }

        //public void Depurar(string esquema, DateTime fechaDesde, DateTime fechaHasta)
        //{
        //    string queryFrom = string.Format(@"DELETE FROM dbo.Phx_Log_VencPwdApp_Det WHERE dbo.Phx_Log_VencPwdApp_Det.fecha_ejecucion < GETDATE() - 30", esquema);

        //    ITransaction tx = null;
        //    using (ISession session = DBMgr.factory.OpenSession())
        //    {

        //        tx = session.BeginTransaction();
        //        try
        //        {
        //            session.CreateSQLQuery(queryFrom).ExecuteUpdate();
                    
        //            tx.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            if (tx != null)
        //                tx.Rollback();
        //            throw (e);
        //        }
        //    }
        //}
    
    }
}
