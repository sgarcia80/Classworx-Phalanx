using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NDCCommon.Entities;
using NDCDAL;
using NDCCommon.Collections;
using System.Collections.Generic;
using PhalanxDAL;
using NHibernate.Transform;
using NHibernate.Criterion;
using Classworx.Common.Trace;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketNotificacionFactory
    {
        private static readonly IResultTransformer ResultTransformer;

        private string _filUsuario;
        private string _filDominio;
        private string _filTipoNotif;
        private string _filSortColumn;
        private Int32 _filSortDirection = 1;

        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public string FilDominio
        {
            set { _filDominio = value; }
        }

        public string FilTipoNotif
        {
            set { _filTipoNotif = value; }
        }

        public DateTime FilFechaDesde { get; set; }
        public DateTime FilFechaHasta { get; set; }

        public string FilSortColumn
        {
            set { _filSortColumn = value; }
        }

        public int FilSortDirection
        {
            set { _filSortDirection = value; }
        }

        static TicketNotificacionFactory()
        {
            //
            // TODO: Add constructor logic here
            //
            ResultTransformer = Transformers.AliasToBean(typeof(TicketNotificacionEntity));
        }

        public TicketNotificacionEntityCollection GetAll()
        {
            IList<TicketNotificacionEntity> tickets;

            TicketNotificacionEntityCollection TiNotClaEC = new TicketNotificacionEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                //ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionEntity), "TNB").CreateCriteria("TNB.Aplicacion", "a", NHibernate.SqlCommand.JoinType.InnerJoin);

                //string column = "TNB.Fecha";

                //if (!string.IsNullOrEmpty(_filSortColumn))
                //{
                //    column = string.Format("TNB.{0}", _filSortColumn);
                //}
                //if (_filSortColumn == "Aplicacion")
                //{
                //    column = "a.Nombre";
                //}

                //if (_filSortDirection == 0)
                //{
                //    DataSearch.AddOrder(Order.Asc(column)); ;
                //}
                //else
                //{
                //    DataSearch.AddOrder(Order.Desc(column)); ;
                //}

                //if (!string.IsNullOrEmpty(_filUsuario))
                //{
                //    //DataSearch = DataSearch.Add(Expression.Sql("lower(TNB.Usuario) = lower('" + _filUsuario + "')"));
                //    DataSearch = DataSearch.Add(Expression.InsensitiveLike("TNB.Usuario", _filUsuario, MatchMode.Exact));
                //}
                ////if (!string.IsNullOrEmpty(_filDominio))
                ////    DataSearch = DataSearch.Add(Expression.Eq("Dominio", _filDominio));

                //if (!string.IsNullOrEmpty(_filTipoNotif))
                //    DataSearch = DataSearch.Add(Expression.Eq("TNB.Tipo", _filTipoNotif));

                //try
                //{
                //    tickets = DataSearch.List<TicketNotificacionEntity>();

                //    TiNotClaEC.Add(tickets);
                //}
                //catch (Exception e)
                //{
                //    log.Error("Error al consultar Tickets de Notificacion de Clave", e);
                //    tickets = null;
                //}

                IQuery query = session.GetNamedQuery("GetNotificacionByUser");

                query.SetParameter("usuario", _filUsuario);
                query.SetParameter("tipo", _filTipoNotif);
                query.SetParameter("fecha_desde", this.FilFechaDesde);
                query.SetParameter("fecha_hasta", this.FilFechaHasta.AddDays(1).AddSeconds(-1));

                query.SetResultTransformer(ResultTransformer);

                tickets = query.List<TicketNotificacionEntity>();

                TiNotClaEC.Add(tickets);
            }

            return TiNotClaEC;
        }

        public TicketNotificacionEntity Load(string usuario, int id, string tipo)
        {
            TicketNotificacionEntity ticket = null;
            IList<TicketNotificacionEntity> tickets;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionEntity), "TNB").AddOrder(Order.Desc("TNB.Fecha")); ;

                DataSearch = DataSearch.Add(Restrictions.Eq("Id", id));
                DataSearch = DataSearch.Add(Restrictions.Eq("Tipo", tipo));

                try
                {
                    //tickets = DataSearch.List<TicketNotificacionEntity>();

                    //if (tickets.Count > 0)
                    //{
                    //    ticket = tickets[0];
                    //}

                    IQuery query = session.GetNamedQuery("GetNotificacionById");

                    query.SetParameter("usuario", usuario);
                    query.SetParameter("id", id);
                    query.SetParameter("tipo", tipo);

                    query.SetResultTransformer(ResultTransformer);

                    tickets = query.List<TicketNotificacionEntity>();

                    if (tickets != null && tickets.Count > 0)
                    {
                        ticket = tickets[0];
                    }
                }
                catch (Exception e)
                {
                    TraceHelper.Error(e, "Error al consultar el Ticket de Notificacion de Clave");
                }
            }

            return ticket;
        }
    }
}
