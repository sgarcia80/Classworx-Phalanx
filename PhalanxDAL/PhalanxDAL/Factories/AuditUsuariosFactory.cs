using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class AuditUsuariosFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;
        public void Save(AuditUsuariosEntity AudUsr)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                tx = session.BeginTransaction();
                try
                {
                    if (AudUsr.AuditPhxUserNew != null)
                    {
                        session.Save(AudUsr.AuditPhxUserNew);
                    }
                    if (AudUsr.AuditPhxUserOld != null)
                    {
                        session.Save(AudUsr.AuditPhxUserOld);
                    }
                    session.Save(AudUsr);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw new SystemException(e.Message);

                }
            }
        }

        public PhalanxCommon.Collections.AuditUsuariosEntityCollection GetAll()
        {
            IList<AuditUsuariosEntity> lstWLUs;
            AuditUsuariosEntityCollection DBUsrEC = new AuditUsuariosEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AuditUsuariosEntity));
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Desc("Fecha"));


                lstWLUs = DataSearch.List<AuditUsuariosEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }
    }
}
