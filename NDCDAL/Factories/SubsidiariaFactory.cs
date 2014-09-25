using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NHibernate;
using NDCCommon.Entities;
using Common;
using PhalanxDAL;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class SubsidiariaFactory
    {

        public string FilNombre { set; get; }

        public SubsidiariaEntityCollection GetAll()
        {
            SubsidiariaEntityCollection Lst = new SubsidiariaEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(SubsidiariaEntity));

                    if (!string.IsNullOrEmpty(FilNombre))
                        DataSearch = DataSearch.Add(Expression.Like("Nombre", FilNombre, MatchMode.Anywhere));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Nombre"));
                    
                    Lst.Add(DataSearch.List<SubsidiariaEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "SubsidiariaFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "SubsidiariaFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "SubsidiariaFactory GetAll()"));
            }
            return Lst;
        }

        public SubsidiariaEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                SubsidiariaEntity entity = session.Get<SubsidiariaEntity>(id);

                return entity;
            }
        }

        public SubsidiariaEntity GetByCodigo(string codigo)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(SubsidiariaEntity));

                var a = criteria.List();

                criteria.Add(Expression.Eq("Codigo", codigo));

                return criteria.UniqueResult<SubsidiariaEntity>();
            }
        }

        public void Save(SubsidiariaEntity entidad)
        {
            ITransaction tx = null;
            
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(entidad);
                    tx.Commit();
                }
                catch
                {
                    if (tx != null)
                        tx.Rollback();

                    throw;
                }
            }
        }

        public bool Delete(SubsidiariaEntity subsidiaria)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(subsidiaria);
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }
    }
}
