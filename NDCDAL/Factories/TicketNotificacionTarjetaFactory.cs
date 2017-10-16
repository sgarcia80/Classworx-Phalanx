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
    public class TicketNotificacionTarjetaFactory
    {
        public AplicacionNotificacionClaveEntity FilAplicacion { get; set; }

        public string FilUsuario { get; set; }

        public string FilUsuarioApp { get; set; }

        public string FilDominio { get; set; }

        public DateTime? FilFechaDesde { get; set; }

        public DateTime? FilFechaHasta { get; set; }

        public TicketNotificacionTarjetaEntity.EstadoTicket FilEstado { get; set; }

        public TicketNotificacionTarjetaFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Save(List<TicketNotificacionTarjetaEntity> list)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();

                    foreach (TicketNotificacionTarjetaEntity entity in list)
                    {
                        session.SaveOrUpdate(entity);
                    }

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

        public int Save(TicketNotificacionTarjetaEntity entidad)
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

        public void Delete(TicketNotificacionTarjetaEntity entidad)
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

        public TicketNotificacionTarjetaEntityCollection GetAll()
        {
            IList<TicketNotificacionTarjetaEntity> tickets;

            TicketNotificacionTarjetaEntityCollection TiNotClaEC = new TicketNotificacionTarjetaEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionTarjetaEntity), "TNT").AddOrder(Order.Desc("TNT.Fecha"));

                if (this.FilAplicacion != null)
                {
                    DataSearch.Add(Expression.Eq("TNT.Aplicacion", this.FilAplicacion));
                }

                if (!string.IsNullOrEmpty(this.FilUsuario))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("TNT.Usuario", string.Format("%{0}%", this.FilUsuario)));

                if (!string.IsNullOrEmpty(this.FilUsuarioApp))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("TNT.UsuarioAplicacion", string.Format("%{0}%", this.FilUsuarioApp)));

                if (!string.IsNullOrEmpty(this.FilDominio))
                    DataSearch = DataSearch.Add(Expression.Eq("TNT.UsuarioDominio", this.FilDominio));

                if (this.FilFechaDesde != null)
                    DataSearch = DataSearch.Add(Expression.Ge("TNT.Fecha", this.FilFechaDesde));

                if (this.FilFechaHasta != null)
                    DataSearch = DataSearch.Add(Expression.Le("TNT.Fecha", this.FilFechaHasta));

                if (this.FilEstado != TicketNotificacionTarjetaEntity.EstadoTicket.Ninguno)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNT.Estado", this.FilEstado));
                }

                try
                {
                    tickets = DataSearch.List<TicketNotificacionTarjetaEntity>();

                    TiNotClaEC.Add(tickets);
                }
                catch
                {
                    throw;
                }
            }

            return TiNotClaEC;
        }

        public TicketNotificacionTarjetaEntityCollection GetAllByUser(string dominio, string usuario)
        {
            IList<TicketNotificacionTarjetaEntity> tickets;

            TicketNotificacionTarjetaEntityCollection TiNotClaEC = new TicketNotificacionTarjetaEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionTarjetaEntity), "TNT");
                DataSearch = DataSearch.Add(Expression.Eq("TNT.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Expression.Eq("TNT.UsuarioDominio", dominio).IgnoreCase());

                try
                {
                    tickets = DataSearch.List<TicketNotificacionTarjetaEntity>();

                    TiNotClaEC.Add(tickets);
                }
                catch
                {
                    throw;
                }
            }

            return TiNotClaEC;
        }

        public TicketNotificacionTarjetaEntity Load(int Id)
        {
            TicketNotificacionTarjetaEntity PwdRqst;
            IList<TicketNotificacionTarjetaEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = session.Load<TicketNotificacionTarjetaEntity>(Id);
                }
            }
            catch (Exception)
            {
                return null;
            }
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqst;
        }
    }
}
