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
    public class MacroUsuarioFactory
    {
        public MacroUsuarioEntityCollection GetAll(int macroid, bool? principal, bool? activo)
        {
            MacroUsuarioEntityCollection Lst = new MacroUsuarioEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroUsuarioEntity));
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Id"));

                    if (macroid > 0)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Macro.Id", macroid));
                    }

                    if (principal.HasValue)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Principal", principal));
                    }

                    if (activo.HasValue)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Activo", activo));
                    }

                    Lst.Add(DataSearch.List<MacroUsuarioEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroUsuarioFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroUsuarioFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroUsuarioFactory GetAll()"));
            }
            return Lst;
        }

        public MacroUsuarioEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                MacroUsuarioEntity entity = session.Get<MacroUsuarioEntity>(id);

                return entity;
            }
        }

        public void Save(MacroUsuarioEntity entidad)
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

        public bool Delete(MacroUsuarioEntity MacroUsuario)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(MacroUsuario);
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