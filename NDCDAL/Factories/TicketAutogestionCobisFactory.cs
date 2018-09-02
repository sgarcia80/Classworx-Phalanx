using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NDCCommon.Entities;
using NDCDAL;
using NDCCommon.Collections;
using System.Collections.Generic;
using PhalanxDAL;
using NHibernate.Criterion;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketAutogestionCobisFactory
    {
        private string _filUsuario;
        private DateTime? _filFechaDesde;
        private DateTime? _filFechaHasta;
        private int _filTipoNotif;

        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public DateTime? FilFechaDesde
        {
            set { _filFechaDesde = value; }
        }

        public DateTime? FilFechaHasta
        {
            set { _filFechaHasta = value; }
        }

        public int FilTipoNotif
        {
            set { _filTipoNotif = value; }
        }

        public TicketAutogestionCobisFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Save(TicketAutogestionCobisEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();

                    session.Save(entidad);

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

        public TicketAutogestionCobisEntityCollection GetAll()
        {
            IList<TicketAutogestionCobisEntity> tickets;

            TicketAutogestionCobisEntityCollection TiNotClaEC = new TicketAutogestionCobisEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketAutogestionCobisEntity), "TAC").AddOrder(Order.Desc("TAC.Fecha"));

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Restrictions.InsensitiveLike("TAC.Usuario", string.Format("%{0}%", _filUsuario)));

                if (_filFechaDesde != null)
                    DataSearch = DataSearch.Add(Restrictions.Ge("TAC.Fecha", _filFechaDesde.Value.Date));

                if (_filFechaHasta != null)
                    DataSearch = DataSearch.Add(Restrictions.Le("TAC.Fecha", _filFechaHasta.Value.Date.AddDays(1).AddSeconds(-1)));

                if (_filTipoNotif > 0)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TAC.TipoNotificacion", _filTipoNotif));

                //Que el ticket no haya sido cancelado                

                try
                {
                    tickets = DataSearch.List<TicketAutogestionCobisEntity>();
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
