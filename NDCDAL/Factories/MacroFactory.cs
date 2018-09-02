using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;
using Common;
using NHibernate.Criterion;

namespace NDCDAL.Factories
{
    public class MacroFactory
    {
        public MacroEntityCollection Exists(string nombre)
        {
            MacroEntityCollection Lst = new MacroEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroEntity));

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("Name", nombre, MatchMode.Exact));
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));

                    Lst.Add(DataSearch.List<MacroEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroFactory GetAll()"));
            }
            return Lst;
        }

        public MacroEntityCollection GetAll(string nombre)
        {
            MacroEntityCollection Lst = new MacroEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroEntity));

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Name", nombre, MatchMode.Anywhere));
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));

                    Lst.Add(DataSearch.List<MacroEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroFactory GetAll()"));
            }
            return Lst;
        }

        public MacroEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                MacroEntity entity = session.Get<MacroEntity>(id);

                int cant = entity.UsuariosList.Count;

                return entity;
            }
        }

        public void Save(MacroEntity entidad)
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

        public bool Delete(MacroEntity Macro)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(Macro);
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