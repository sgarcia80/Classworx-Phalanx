using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class BuildingFactory
    {
        string m_fil_dir;
        public string FilNombre
        {
            set { m_fil_dir = value; }
        }

        public BuildingEntityCollection GetAll()
        {
            BuildingEntityCollection WinDomLst = new BuildingEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(BuildingEntity));
                    if (m_fil_dir != null && m_fil_dir != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Address", m_fil_dir, MatchMode.Anywhere));
                    }
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Address"));
                    WinDomLst.Add(DataSearch.List<BuildingEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "BuildingFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "BuildingFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "BuildingFactory GetAll()"));
            }
            return WinDomLst;
        }
        public int Save(BuildingEntity Building)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Building);
                    tx.Commit();
                    return Building.Id;
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


        public bool Delete(BuildingEntity Building)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(Building);
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
    }
}
