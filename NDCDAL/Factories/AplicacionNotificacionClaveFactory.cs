using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NDCCommon.Collections;
using NDCCommon.Entities;
using Common;
using PhalanxDAL;
using NHibernate.Criterion;

namespace NDCDAL.Factories
{
    /// <summary>
    /// Summary description for ApplicationFactory
    /// </summary>
    public class AplicacionNotificacionClaveFactory
    {
        private string _filCodigo = "";
        private string _filNombre = string.Empty;
        
        
        public string FilCodigo
        {
            set { _filCodigo = value; }
        }

        public string FilNombre
        {
            set { _filNombre = value; }
        }

        public bool? FilAppRed { set; get; }

        public bool? FilAppCobis { set; get; }

        public bool? FilNotificable { set; get; }

        public bool? FilEsEmuladores { get; set; }

        public AplicacionNotificacionClaveFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public AplicacionNotificacionClaveEntityCollection GetAll()
        {
            AplicacionNotificacionClaveEntityCollection Lst = new AplicacionNotificacionClaveEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(AplicacionNotificacionClaveEntity));
                    
                    if (_filCodigo != null && _filCodigo != "")
                        DataSearch = DataSearch.Add(Restrictions.Eq("Codigo", _filCodigo));

                    if (!string.IsNullOrEmpty(_filNombre))
                        DataSearch = DataSearch.Add(Restrictions.Like("Nombre", _filNombre, MatchMode.Anywhere));

                    if (FilAppRed != null)
                        DataSearch = DataSearch.Add(Restrictions.Eq("EsAplicacionRed", FilAppRed.Value));

                    if (FilNotificable.HasValue && FilNotificable.Value)
                        DataSearch = DataSearch.Add(Restrictions.Eq("Notificable", true));

                    if (FilEsEmuladores.HasValue)
                        DataSearch = DataSearch.Add(Restrictions.Eq("EsEmuladores", FilEsEmuladores.Value));
        
                    DataSearch = DataSearch.AddOrder(Order.Asc("Nombre"));
                    Lst.Add(DataSearch.List<AplicacionNotificacionClaveEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "AplicacionNotificacionClaveFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "AplicacionNotificacionClaveFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "AplicacionNotificacionClaveFactory GetAll()"));
            }
            return Lst;

        }

        public AplicacionNotificacionClaveEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                AplicacionNotificacionClaveEntity app = session.Get<AplicacionNotificacionClaveEntity>(id);
                
                return app;
            }
        }

        public void SaveBPMAplicacion(AplicacionNotificacionClaveEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw e; // e; //new SystemException(e.Message);
                }
            }
        }

        public bool SetearAppRed(int id)
        {
            ITransaction transaction = null;

            try
            {

                using (ISession session = DBMgr.factory.OpenSession())
                {
                    using (transaction = session.BeginTransaction())
                    {

                        foreach (AplicacionNotificacionClaveEntity entity in GetAll())
                        {
                            if (entity.Id == id || entity.EsAplicacionRed)
                            {
                                entity.EsAplicacionRed = entity.Id == id;

                                session.SaveOrUpdate(entity);
                            }
                        }

                        transaction.Commit();

                        return true;
                    }
                }
            }
            catch
            {
                transaction.Rollback();
            }

            return false;
        }

        public AplicacionNotificacionClaveEntity GetAppCobis()
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(AplicacionNotificacionClaveEntity));

                criteria.Add(Restrictions.Eq("EsAplicacionCobis", true));

                return criteria.UniqueResult<AplicacionNotificacionClaveEntity>();
            }
        }

        public bool SetearAppCobis(int id)
        {
            ITransaction transaction = null;

            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    using (transaction = session.BeginTransaction())
                    {

                        foreach (AplicacionNotificacionClaveEntity entity in GetAll())
                        {
                            if (entity.Id == id || entity.EsAplicacionCobis)
                            {
                                entity.EsAplicacionCobis = entity.Id == id;

                                session.SaveOrUpdate(entity);
                            }
                        }

                        transaction.Commit();

                        return true;
                    }
                }
            }
            catch
            {
                transaction.Rollback();
            }

            return false;
        }
    }
}