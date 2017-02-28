using System;
using NHibernate;
using NDCCommon.Entities;
using NDCCommon.Collections;
using System.Collections.Generic;
using NHibernate.Criterion;
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
        private bool _filPendiente;
        private int _filTipoNotif;

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

        public bool FilPendiente
        {
            set { _filPendiente = value; }
        }

        public int FilTipoNotif
        {
            set { _filTipoNotif = value; }
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
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity), "TNB").AddOrder(Order.Desc("TNB.Fecha"));

                if (_filApp != null)
                {
                    DataSearch.Add(Restrictions.Eq("TNB.Aplicacion", _filApp));
                }

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Restrictions.InsensitiveLike("TNB.Usuario", string.Format("%{0}%", _filUsuario)));

                if (!string.IsNullOrEmpty(_filUsuarioApp))
                    DataSearch = DataSearch.Add(Restrictions.InsensitiveLike("TNB.UsuarioAplicacion", string.Format("%{0}%", _filUsuarioApp)));

                if (!string.IsNullOrEmpty(_filDominio))
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNB.UsuarioDominio", _filDominio));

                if (_filFecha != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNB.Fecha", _filFecha));

                if (_filFechaDesde != null)
                    DataSearch = DataSearch.Add(Restrictions.Ge("TNB.Fecha", _filFechaDesde));

                if (_filFechaHasta != null)
                    DataSearch = DataSearch.Add(Restrictions.Le("TNB.Fecha", _filFechaHasta));

                if (_filPendiente)
                {
                    DataSearch = DataSearch.Add(Restrictions.IsNull("TNB.FechaAceptacionTyC"));
                    DataSearch = DataSearch.Add(Restrictions.IsNull("TNB.FechaCancelado"));
                }

                if (_filTipoNotif > 0)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNB.TipoNotificacion", _filTipoNotif));

                //Que el ticket no haya sido cancelado
                

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
                DataSearch = DataSearch.Add(Restrictions.Eq("TNB.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Restrictions.Eq("TNB.UsuarioDominio", dominio).IgnoreCase());

                //DataSearch.CreateCriteria("Aplicacion")
                //            .Add(Restrictions.Eq("Notificable", true));

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

        public TicketNotificacionBlanqueoEntity GetMaxByUser(string usuario)
        {
            TicketNotificacionBlanqueoEntity ticket;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity), "TNB");
                DataSearch = DataSearch.Add(Restrictions.Eq("TNB.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Restrictions.Eq("TNB.FechaAceptacionTyC", null));
                DataSearch = DataSearch.SetProjection(Projections.Max("TNB.Fecha"));

                try
                {
                    ticket = DataSearch.UniqueResult<TicketNotificacionBlanqueoEntity>();
                }
                catch
                {
                    ticket = null;
                }

            }

            return ticket;
        }

        public TicketNotificacionBlanqueoEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                return session.Get<TicketNotificacionBlanqueoEntity>(id);
            }
        }

        public TicketNotificacionBlanqueoEntityCollection GetReporteNotificacionClaves(AplicacionNotificacionClaveEntity aplicacion, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            IList<TicketNotificacionBlanqueoEntity> tickets;

            TicketNotificacionBlanqueoEntityCollection TiNotClaEC = new TicketNotificacionBlanqueoEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionBlanqueoEntity), "TNB").AddOrder(Order.Desc("TNB.Fecha"));

                if (_filApp != null)
                {
                    DataSearch.Add(Restrictions.Eq("TNB.Aplicacion", _filApp));
                }

                DataSearch.Add(Restrictions.Or(
                    Restrictions.Eq("TNB.TipoNotificacion", 1),
                    Restrictions.Eq("TNB.TipoNotificacion", 2)));

                if (_filApp == null)
                {
                    DataSearch.CreateCriteria("TNB.Aplicacion", "app");

                    DataSearch.Add(Restrictions.Or(
                        Restrictions.Eq("app.EsAplicacionRed", true),
                        Restrictions.Eq("app.EsAplicacionCobis", true)));
                }

                if (_filFechaDesde != null)
                    DataSearch = DataSearch.Add(Restrictions.Ge("TNB.Fecha", _filFechaDesde));

                if (_filFechaHasta != null)
                    DataSearch = DataSearch.Add(Restrictions.Le("TNB.Fecha", _filFechaHasta));

                DataSearch = DataSearch.Add(Restrictions.IsNull("TNB.FechaAceptacionTyC"));

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
        //                                        .Add(Restrictions.Eq("Legajo", entidad.Legajo))
        //                                        .Add(Restrictions.Eq("EsPasswordDominio", true));

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

                criteria.Add(Restrictions.Eq("Token", token));

                return criteria.UniqueResult<TicketNotificacionBlanqueoEntity>();
            }
        }
    }
}
