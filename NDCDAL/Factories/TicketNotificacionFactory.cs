using NHibernate;
using NDCCommon.Entities;
using NDCCommon.Collections;
using System.Collections.Generic;
using PhalanxDAL;
using NHibernate.Transform;
using NHibernate.Criterion;
using Classworx.Common.Trace;
using System;
using log4net;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketNotificacionFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TicketNotificacionFactory));

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
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionEntity), "TNB").CreateCriteria("TNB.Aplicacion", "a", NHibernate.SqlCommand.JoinType.InnerJoin);

                string column = "TNB.Fecha";

                if (!string.IsNullOrEmpty(_filSortColumn))
                {
                    column = string.Format("TNB.{0}",_filSortColumn);
                }
                if (_filSortColumn == "Aplicacion")
                {
                    column = "a.Nombre";
                }

                if (_filSortDirection == 0)
                {
                    DataSearch.AddOrder(Order.Asc(column)); ;
                }
                else
                {
                    DataSearch.AddOrder(Order.Desc(column)); ;
                }

                if (!string.IsNullOrEmpty(_filUsuario))
                {
                    //DataSearch = DataSearch.Add(Restrictions.Sql("lower({alias}.user_red) = lower('" + _filUsuario + "')"));
                    DataSearch = DataSearch.Add(Restrictions.InsensitiveLike("Usuario", _filUsuario, MatchMode.Exact));
                }

                //if (!string.IsNullOrEmpty(_filDominio))
                //    DataSearch = DataSearch.Add(Restrictions.Eq("Dominio", _filDominio));

                if (!string.IsNullOrEmpty(_filTipoNotif))
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNB.Tipo", _filTipoNotif));

                try
                {
                    tickets = DataSearch.List<TicketNotificacionEntity>();

                    TiNotClaEC.Add(tickets);
                }
                catch(Exception ex)
                {
                    TraceHelper.Error(ex, "Error al consultar los Tickets de Notificación del usuario");
                }
            }

            return TiNotClaEC;
        }

        public TicketNotificacionEntity Load(int id, string tipo)
        {
            TicketNotificacionEntity ticket = null;
            IList<TicketNotificacionEntity> tickets;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionEntity), "TNB").AddOrder(Order.Desc("TNB.Fecha")); ;

                DataSearch = DataSearch.Add(Expression.Eq("Id", id));
                DataSearch = DataSearch.Add(Expression.Eq("Tipo", tipo));

                try
                {
                    tickets = DataSearch.List<TicketNotificacionEntity>();

                    if (tickets.Count > 0)
                    {
                        ticket = tickets[0];
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error al consultar el Ticket de Notificacion de Clave", e);
                }
            }

            return ticket;
        }
    }
}
