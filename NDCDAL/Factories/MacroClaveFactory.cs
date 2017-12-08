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
    public class MacroClaveFactory
    {
        public MacroClaveEntityCollection GetAll(string clave, bool? activo)
        {
            MacroClaveEntityCollection Lst = new MacroClaveEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroClaveEntity));

                    if (!string.IsNullOrEmpty(clave))
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Clave", clave, MatchMode.Anywhere));
                    }

                    if (activo.HasValue)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Activo", activo));
                    }

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Clave"));

                    Lst.Add(DataSearch.List<MacroClaveEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroClaveFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroClaveFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroClaveFactory GetAll()"));
            }
            return Lst;
        }

        public MacroClaveEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                MacroClaveEntity entity = session.Get<MacroClaveEntity>(id);

                return entity;
            }
        }

        public void Save(MacroClaveEntity entidad)
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

        public bool Delete(MacroClaveEntity MacroClave)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(MacroClave);
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