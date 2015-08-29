using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;
using NDCCommon.Collections;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class AuditTicketNotificacionFactory
    {
        public bool Visualizado(TicketNotificacionClaveEntity Ticket)
        {
            AuditTicketNotificacionEntityCollection Lst = new AuditTicketNotificacionEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(AuditTicketNotificacionEntity));

                    DataSearch = DataSearch.Add(Expression.Eq("Ticket", Ticket));

                    return DataSearch.List<SubsidiariaEntity>().Count > 0;
                }
            }
            //catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            //{
            //    throw (new CwxException(ObjNotFoundEx.Message, "SubsidiariaFactory GetAll()"));
            //}
            //catch (NHibernate.HibernateException NHEx)
            //{
            //    throw (new CwxException(NHEx.Message, "SubsidiariaFactory GetAll()"));
            //}
            //catch (CwxException ex)
            //{
            //    throw (ex);
            //}
            catch (Exception ex)
            {
                //throw (new CwxException(ex.Message, "SubsidiariaFactory GetAll()"));
            }
            return false;

        }
        public void Save(AuditTicketNotificacionEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    
                    throw e; //new SystemException(e.Message);
                }
            }
        }
    }
}
