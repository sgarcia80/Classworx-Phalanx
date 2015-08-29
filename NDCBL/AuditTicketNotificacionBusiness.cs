using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NDCDAL.Factories;

namespace NDCBL
{
    public class AuditTicketNotificacionBusiness
    {
        public void LogVisualizacion(TicketNotificacionClaveEntity ticket)
        {
            AuditTicketNotificacionEntity audit = new AuditTicketNotificacionEntity();

            audit.Ticket = ticket;

            this.Save(audit);
        }
        public bool Visualizado(TicketNotificacionClaveEntity ticket)
        {
            return new AuditTicketNotificacionFactory().Visualizado(ticket); 
        }
        private void Save(AuditTicketNotificacionEntity audit)
        {
            new AuditTicketNotificacionFactory().Save(audit);
        }
    }
}
