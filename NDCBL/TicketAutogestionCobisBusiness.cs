using System;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    /// <summary>
    /// Summary description
    /// </summary>
    public class TicketAutogestionCobisBusiness
    {
        private TicketAutogestionCobisFactory factory;

        private TicketAutogestionCobisFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new TicketAutogestionCobisFactory();

                return factory;
            }
        }

        public TicketAutogestionCobisBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public TicketAutogestionCobisEntityCollection GetAll(int tipoNotif, DateTime? fechaDesde, DateTime? fechaHasta, string usuario)
        {
            TicketAutogestionCobisFactory factory = new TicketAutogestionCobisFactory();

            factory.FilUsuario = usuario;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilTipoNotif = tipoNotif;

            TicketAutogestionCobisEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public int Save(TicketAutogestionCobisEntity ticket)
        {
            return this.Factory.Save(ticket);
        }
    }
}