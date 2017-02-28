using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class AuditLoginFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;

        public void Save(AuditLoginEntity AudLogin)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                tx = session.BeginTransaction();
                try
                {
                    session.Save(AudLogin);
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


        public AuditLoginEntityCollection GetAll()
        {
            IList<AuditLoginEntity> lstWLUs;
            AuditLoginEntityCollection DBUsrEC = new AuditLoginEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AuditLoginEntity));
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Desc("Fecha"));


                lstWLUs = DataSearch.List<AuditLoginEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

        public void Depurar(DateTime fecha)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                session.GetNamedQuery("DepurarAuditLogin")
                            .SetDateTime("fecha", fecha)
                            .UniqueResult();
            }
        }
    }
}
