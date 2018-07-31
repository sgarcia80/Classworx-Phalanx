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
    public class MacroUsuarioTarjetaFactory
    {
        public MacroUsuarioTarjetaEntityCollection GetAll(string usuariored, string usuariotc, string appcode)
        {
            MacroUsuarioTarjetaEntityCollection Lst = new MacroUsuarioTarjetaEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroUsuarioTarjetaEntity), "tc");
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("UsuarioRed"));

                    if (!string.IsNullOrEmpty(usuariored))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("tc.UsuarioRed", usuariored, MatchMode.Anywhere));
                    }
                    if (!string.IsNullOrEmpty(usuariotc))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("tc.UsuarioTC", usuariotc, MatchMode.Anywhere));
                    }
                    if (!string.IsNullOrEmpty(appcode))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("tc.AplicacionCodigo", appcode, MatchMode.Anywhere));
                    }
                    
                    var data = DataSearch.List<MacroUsuarioTarjetaEntity>();

                    Lst.Add(data);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            return Lst;
        }

        public MacroUsuarioTarjetaEntityCollection GetAll(string usuariored)
        {
            MacroUsuarioTarjetaEntityCollection Lst = new MacroUsuarioTarjetaEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroUsuarioTarjetaEntity), "tc");
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("UsuarioRed"));

                    if (!string.IsNullOrEmpty(usuariored))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("tc.UsuarioRed", usuariored, MatchMode.Exact));
                    }

                    var data = DataSearch.List<MacroUsuarioTarjetaEntity>();

                    Lst.Add(data);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            return Lst;
        }

        public bool EsUsuarioTC(string usuariored)
        {
            bool es = false;

            MacroUsuarioTarjetaEntityCollection Lst = new MacroUsuarioTarjetaEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MacroUsuarioTarjetaEntity), "tc");
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("UsuarioRed"));

                    if (!string.IsNullOrEmpty(usuariored))
                    {
                        DataSearch = DataSearch.Add(Expression.InsensitiveLike("tc.UsuarioRed", usuariored, MatchMode.Anywhere));
                    }

                    var data = DataSearch.List<MacroUsuarioTarjetaEntity>();

                    es = (data != null && data.Count > 0);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MacroUsuarioTarjetaFactory GetAll()"));
            }
            return es;
        }

        public MacroUsuarioTarjetaEntity Load(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                MacroUsuarioTarjetaEntity entity = session.Get<MacroUsuarioTarjetaEntity>(id);

                return entity;
            }
        }

        public void Save(List<MacroUsuarioTarjetaEntity> list)
        {
            ITransaction tx = null;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();

                    var metadata = DBMgr.factory.GetClassMetadata(typeof(MacroUsuarioTarjetaEntity)) as NHibernate.Persister.Entity.AbstractEntityPersister;
                    string table = metadata.TableName;

                    string query = string.Format("DELETE from {0}; select @@ROWCOUNT count;", table);
                    var q = session.CreateSQLQuery(query).AddScalar("count", NHibernateUtil.Int32);

                    q.UniqueResult();

                    foreach (MacroUsuarioTarjetaEntity entity in list)
                    {
                        session.SaveOrUpdate(entity);
                    }
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

        public bool Delete(MacroUsuarioTarjetaEntity MacroUsuarioTarjeta)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(MacroUsuarioTarjeta);
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