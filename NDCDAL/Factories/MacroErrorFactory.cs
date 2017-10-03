using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;
using Common;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class MacroErrorFactory
    {
        public MacroErrorEntityCollection GetAll(string descripcion)
        {
            MacroErrorEntityCollection Lst = new MacroErrorEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroErrorEntity));

                    if (!string.IsNullOrEmpty(descripcion))
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Descripcion", descripcion, MatchMode.Anywhere));
                    }

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Descripcion"));

                    Lst.Add(DataSearch.List<MacroErrorEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroErrorFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroErrorFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroErrorFactory GetAll()"));
            }
            return Lst;
        }

        public MacroErrorEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                MacroErrorEntity entity = session.Get<MacroErrorEntity>(id);

                return entity;
            }
        }

        public void Save(MacroErrorEntity entidad)
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

        public bool Delete(MacroErrorEntity MacroError)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(MacroError);
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