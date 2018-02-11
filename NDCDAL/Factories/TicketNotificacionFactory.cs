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
using NHibernate.Transform;

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
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionEntity), "TNB").AddOrder(Order.Desc("TNB.Fecha")); ;

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Expression.Sql("lower({alias}.user_red) = lower('" + _filUsuario + "')"));

                //if (!string.IsNullOrEmpty(_filDominio))
                //    DataSearch = DataSearch.Add(Expression.Eq("Dominio", _filDominio));

                if (!string.IsNullOrEmpty(_filTipoNotif))
                    DataSearch = DataSearch.Add(Expression.Eq("Tipo", _filTipoNotif));

                try
                {
                    tickets = DataSearch.List<TicketNotificacionEntity>();
                }
                catch
                {
                    tickets = null;
                }

                TiNotClaEC.Add(tickets);
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
                catch
                {
                    
                }
            }

            return ticket;
        }
    }
}
