using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;

namespace NDCDAL.Factories
{
    public class AuditTicketNotificacionFactory
    {
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
