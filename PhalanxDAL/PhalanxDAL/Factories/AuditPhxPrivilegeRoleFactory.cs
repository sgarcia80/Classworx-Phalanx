using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class AuditPhxPrivilegeRoleFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;
        public PhalanxCommon.Collections.AuditPhxPrivilegeRoleEntityCollection GetAll()
        {
            IList<AuditPhxPrivilegeRoleEntity> lstWLUs;
            AuditPhxPrivilegeRoleEntityCollection DBUsrEC = new AuditPhxPrivilegeRoleEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(AuditPhxPrivilegeRoleEntity));
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Desc("Fecha"));


                lstWLUs = DataSearch.List<AuditPhxPrivilegeRoleEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }
    }
}
