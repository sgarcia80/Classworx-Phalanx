using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NHibernate.Expression;
using NDCCommon.Collections;
using NDCCommon.Entities;
using Common;
using PhalanxDAL;

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
                        DataSearch = DataSearch.Add(Expression.Eq("Codigo", _filCodigo));
                    //DataSearch = DataSearch.Add(Expression.Like("Codigo", _filCodigo, MatchMode.Anywhere));

                    if (!string.IsNullOrEmpty(_filNombre))
                        DataSearch = DataSearch.Add(Expression.Like("Nombre", _filNombre, MatchMode.Anywhere));
                    
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Nombre"));
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
    }
}