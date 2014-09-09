using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class AuditPermisosFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;
        public PhalanxCommon.Collections.AuditPermisosEntityCollection GetAll()
        {
            IList<AuditPermisosEntity> lstWLUs;
            AuditPermisosEntityCollection DBUsrEC = new AuditPermisosEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AuditPermisosEntity));
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Desc("Fecha"));


                lstWLUs = DataSearch.List<AuditPermisosEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }
    }
}
