using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
    public class PhxUserSuperiorFactory
    {
        string _filNombre;
        public string FilNombre
        {
            set { _filNombre = value; }
        }

        public PhxUserSuperiorEntityCollection GetAll()
        {
            try
            {
                PhxUserSuperiorEntityCollection objPU = new PhxUserSuperiorEntityCollection();
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxUserSuperiorEntity));
                    if (_filNombre != null && _filNombre != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre, MatchMode.Anywhere));
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));
                    IList<PhxUserSuperiorEntity> PUlst = DataSearch.List<PhxUserSuperiorEntity>();
                    objPU.Add(PUlst);
                }
                return objPU;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool IsDeleteable(PhxUserSuperiorEntity Superior)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    session.Refresh(Superior);
                    return (Superior.PhxUsersList.Count == 0 ? true : false);
                }
                catch (Exception ex)
                {
                    return false;
                    // handle exception
                }
            }
        }
        public bool Delete(PhxUserSuperiorEntity Superior)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(Superior);
                    tx.Commit();
                    return true;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }

        public int Save(PhxUserSuperiorEntity Superior)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Superior);
                    tx.Commit();
                    return Superior.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }

    }
}
