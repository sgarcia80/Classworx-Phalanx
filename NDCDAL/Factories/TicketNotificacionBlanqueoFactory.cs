using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NDCCommon.Entities;
using NDCDAL;
using NDCCommon.Collections;
using System.Collections.Generic;
using NHibernate.Expression;
using PhalanxDAL;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketNotificacionBlanqueoFactory
    {
        private AplicacionNotificacionClaveEntity _filApp = null;
        private string _filUsuario;
        private string _filUsuarioApp;
        private string _filDominio;
        private DateTime? _filFecha;
        private DateTime? _filFechaDesde;
        private DateTime? _filFechaHasta;

        public AplicacionNotificacionClaveEntity FilAplicacion
        {
            set { _filApp = value; }
        }

        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public string FilUsuarioApp
        {
            set { _filUsuarioApp = value; }
        }

        public string FilDominio
        {
            set { _filDominio = value; }
        }

        public DateTime? FilFecha
        {
            set { _filFecha = value; }
        }

        public DateTime? FilFechaDesde
        {
            set { _filFechaDesde = value; }
        }

        public DateTime? FilFechaHasta
        {
            set { _filFechaHasta = value; }
        }

        public TicketNotificacionBlanqueoFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Save(TicketNotificacionBlanqueoEntity entidad)
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
                    throw e; //new SystemException(e.Message);
                }
            }

            return entidad.Id;
        }

        public void Delete(TicketNotificacionBlanqueoEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();
                    session.Delete(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw e; //new SystemException(e.Message);
                }
            }
        }

        public TicketNotificacionBlanqueoEntityCollection GetAll()
        {
            IList<TicketNotificacionBlanqueoEntity> tickets;

            TicketNotificacionBlanqueoEntityCollection TiNotClaEC = new TicketNotificacionBlanqueoEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity), "TNB");

                if (_filApp != null)
                    DataSearch.Add(Expression.Eq("TNB.Aplicacion", _filApp));

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("TNB.Usuario", string.Format("%{0}%", _filUsuario)));

                if (!string.IsNullOrEmpty(_filUsuarioApp))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("TNB.UsuarioAplicacion", string.Format("%{0}%", _filUsuarioApp)));

                if (!string.IsNullOrEmpty(_filDominio))
                    DataSearch = DataSearch.Add(Expression.Eq("TNB.UsuarioDominio", _filDominio));

                if (_filFecha != null)
                    DataSearch = DataSearch.Add(Expression.Eq("TNB.Fecha", _filFecha));

                if (_filFechaDesde != null)
                    DataSearch = DataSearch.Add(Expression.Ge("TNB.Fecha", _filFechaDesde));

                if (_filFechaHasta != null)
                    DataSearch = DataSearch.Add(Expression.Le("TNB.Fecha", _filFechaHasta));

                try
                {
                    tickets = DataSearch.List<TicketNotificacionBlanqueoEntity>();
                }
                catch
                {
                    tickets = null;
                }

                TiNotClaEC.Add(tickets);
            }

            return TiNotClaEC;
        }

        public TicketNotificacionBlanqueoEntityCollection GetAllByUser(string dominio, string usuario)
        {
            IList<TicketNotificacionBlanqueoEntity> tickets;

            TicketNotificacionBlanqueoEntityCollection TiNotClaEC = new TicketNotificacionBlanqueoEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity), "TNB");
                DataSearch = DataSearch.Add(Expression.Eq("TNB.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Expression.Eq("TNB.UsuarioDominio", dominio).IgnoreCase());

                //DataSearch.CreateCriteria("Aplicacion")
                //            .Add(Expression.Eq("Notificable", true));

                try
                {
                    tickets = DataSearch.List<TicketNotificacionBlanqueoEntity>();
                }
                catch
                {
                    tickets = null;
                }

                TiNotClaEC.Add(tickets);
            }

            return TiNotClaEC;
        }

        public TicketNotificacionBlanqueoEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                return session.Get<TicketNotificacionBlanqueoEntity>(id);
            }
        }

        public TicketNotificacionBlanqueoEntity Load(int Id)
        {
            TicketNotificacionBlanqueoEntity PwdRqst;
            IList<TicketNotificacionBlanqueoEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = session.Load<TicketNotificacionBlanqueoEntity>(Id);
                }
            }
            catch (Exception)
            {
                return null;
            }
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqst;
        }

        //public void UpdateUsuarioAplicacion(TicketNotificacionBlanqueoEntity entidad, bool esAplicacionRed)
        //{
        //    ITransaction tx = null;
        //    using (ISession session = DBMgr.factory.OpenSession())
        //    {
        //        try
        //        {
        //            // crear la PC
        //            tx = session.BeginTransaction();

        //            session.SaveOrUpdate(entidad);

        //            if (esAplicacionRed)
        //            {
        //                ICriteria criteria = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity))
        //                                        .Add(Expression.Eq("Legajo", entidad.Legajo))
        //                                        .Add(Expression.Eq("EsPasswordDominio", true));

        //                foreach (TicketNotificacionBlanqueoEntity ticket in criteria.List<TicketNotificacionBlanqueoEntity>())
        //                {
        //                    ticket.UsuarioAplicacion = entidad.UsuarioAplicacion;

        //                    session.SaveOrUpdate(ticket);
        //                }
        //            }

        //            tx.Commit();
        //        }
        //        catch
        //        {
        //            if (tx != null)
        //                tx.Rollback();
                    
        //            throw; //new SystemException(e.Message);
        //        }
        //    }
        //}

        public TicketNotificacionBlanqueoEntity GetByToken(string token)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity));

                criteria.Add(Expression.Eq("Token", token));

                return criteria.UniqueResult<TicketNotificacionBlanqueoEntity>();
            }
        }
    }
}
