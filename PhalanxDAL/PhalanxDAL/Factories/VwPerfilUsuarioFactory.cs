using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
    public class VwPerfilUsuarioFactory
    {
        public enum OrderBy
        {
            DefaultOrder,
            None,
            FullName,
            RoleName
        }
        public OrderBy OrderResultsBy = OrderBy.DefaultOrder;

        public VwPerfilUsuarioEntityCollection GetAll()
        {
            IList<VwPerfilUsuarioEntity> lstWLUs;
            VwPerfilUsuarioEntityCollection DBUsrEC = new VwPerfilUsuarioEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(VwPerfilUsuarioEntity));
                switch (OrderResultsBy)
                {
                    case OrderBy.DefaultOrder:
                        DataSearch = DataSearch.AddOrder(Order.Asc("FullName"));
                        DataSearch = DataSearch.AddOrder(Order.Asc("RoleName"));
                        break;
                    case OrderBy.FullName:
                        DataSearch = DataSearch.AddOrder(Order.Asc("FullName"));
                        DataSearch = DataSearch.AddOrder(Order.Asc("RoleName"));
                        break;
                    case OrderBy.RoleName:
                        DataSearch = DataSearch.AddOrder(Order.Asc("RoleName"));
                        DataSearch = DataSearch.AddOrder(Order.Asc("FullName"));
                        break;
                }


                lstWLUs = DataSearch.List<VwPerfilUsuarioEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

    }
}
