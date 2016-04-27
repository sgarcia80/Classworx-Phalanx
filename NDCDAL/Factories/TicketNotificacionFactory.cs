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

        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public string FilDominio
        {
            set { _filDominio = value; }
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
                    DataSearch = DataSearch.Add(Expression.Eq("Usuario", _filUsuario));

                //if (!string.IsNullOrEmpty(_filDominio))
                //    DataSearch = DataSearch.Add(Expression.Eq("Dominio", _filDominio));
                
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
    }
}
