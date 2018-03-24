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
    public class BloqueoFactory
    {
        public BloqueoEntityCollection GetBloqueoActivo(int codigo)
        {
            BloqueoEntityCollection Lst = new BloqueoEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(BloqueoEntity));

                    DataSearch = DataSearch.Add(Expression.Eq("Codigo", codigo));

                    DataSearch = DataSearch.Add(Expression.Eq("Activo", true));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("FechaInicio"));

                    Lst.Add(DataSearch.List<BloqueoEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "BloqueoFactory GetBloqueoActivo()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "BloqueoFactory GetBloqueoActivo()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "BloqueoFactory GetBloqueoActivo()"));
            }
            return Lst;
        }

        public BloqueoEntityCollection GetAll(int codigo, DateTime? fechadesde, DateTime? fechahasta)
        {
            BloqueoEntityCollection Lst = new BloqueoEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(BloqueoEntity));

                    if (codigo > 0)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Codigo", codigo));
                    }

                    if (fechadesde.HasValue)
                    {
                        DataSearch = DataSearch.Add(Expression.Gt("FechaFin", fechadesde));
                    }
                    if (fechahasta.HasValue)
                    {
                        DataSearch = DataSearch.Add(Expression.Lt("FechaInicio", fechahasta.Value.AddDays(1).AddSeconds(-1)));
                    }

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("FechaInicio"));

                    Lst.Add(DataSearch.List<BloqueoEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "BloqueoFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "BloqueoFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "BloqueoFactory GetAll()"));
            }
            return Lst;
        }

        public BloqueoEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                BloqueoEntity entity = session.Get<BloqueoEntity>(id);

                return entity;
            }
        }

        public void Save(BloqueoEntity entidad)
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

        public bool Delete(BloqueoEntity Bloqueo)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(Bloqueo);
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