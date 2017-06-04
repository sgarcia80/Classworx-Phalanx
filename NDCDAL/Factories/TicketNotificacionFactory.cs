using NHibernate;
using NDCCommon.Entities;
using NDCCommon.Collections;
using System.Collections.Generic;
using PhalanxDAL;
using NHibernate.Transform;
using NHibernate.Criterion;
using Classworx.Common.Trace;
using System;

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
                {
                    //DataSearch = DataSearch.Add(Restrictions.Sql("lower({alias}.user_red) = lower('" + _filUsuario + "')"));
                    DataSearch = DataSearch.Add(Restrictions.InsensitiveLike("Usuario", _filUsuario, MatchMode.Exact));
                }

                //if (!string.IsNullOrEmpty(_filDominio))
                //    DataSearch = DataSearch.Add(Restrictions.Eq("Dominio", _filDominio));

                if (!string.IsNullOrEmpty(_filTipoNotif))
                    DataSearch = DataSearch.Add(Restrictions.Eq("Tipo", _filTipoNotif));

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
    }
}
