using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class AuditPhxRoleFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;

        public PhalanxCommon.Collections.AuditPhxRoleEntityCollection GetAll()
        {
            IList<AuditPhxRoleEntity> lstWLUs;
            AuditPhxRoleEntityCollection DBUsrEC = new AuditPhxRoleEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AuditPhxRoleEntity));
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Desc("Fecha"));


                lstWLUs = DataSearch.List<AuditPhxRoleEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }
    }
}
