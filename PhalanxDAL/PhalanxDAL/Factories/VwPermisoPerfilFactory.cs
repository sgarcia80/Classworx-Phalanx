using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class VwPermisoPerfilFactory
    {

        public VwPermisoPerfilEntityCollection GetAll()
        {
            IList<VwPermisoPerfilEntity> lstWLUs;
            VwPermisoPerfilEntityCollection DBUsrEC = new VwPermisoPerfilEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(VwPermisoPerfilEntity));
                DataSearch = DataSearch.AddOrder(Order.Asc("RoleName"));
                DataSearch = DataSearch.AddOrder(Order.Asc("PrivilegeName"));


                lstWLUs = DataSearch.List<VwPermisoPerfilEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

    }
}
