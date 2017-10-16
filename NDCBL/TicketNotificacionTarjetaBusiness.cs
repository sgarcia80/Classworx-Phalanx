using System;
using System.Data;
using System.Configuration;
using phxCryptMgr;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCDAL.Factories;
using System.Collections.Generic;
using PhalanxBL;
using log4net;

namespace NDCBL
{
    /// <summary>
    /// Summary description
    /// </summary>
    public class TicketNotificacionTarjetaBusiness
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TicketNotificacionTarjetaBusiness));

        private TicketNotificacionTarjetaFactory factory;

        private TicketNotificacionTarjetaFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new TicketNotificacionTarjetaFactory();
                }

                return factory;
            }
        }
        
        public TicketNotificacionTarjetaBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Create(List<TicketNotificacionTarjetaEntity> list)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            foreach (TicketNotificacionTarjetaEntity item in list)
            {
                item.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Pendiente;
            }

            factory.Save(list);
        }

        public void Create(TicketNotificacionTarjetaEntity entidad)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            entidad.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Pendiente;

            factory.Save(entidad);
        }

        public void Delete(TicketNotificacionTarjetaEntity entidad)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            factory.Delete(entidad);
        }

        public TicketNotificacionTarjetaEntityCollection GetAllByUser(string dominio, string usuario)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            TicketNotificacionTarjetaEntityCollection tmpCollection = factory.GetAllByUser(dominio, usuario);

            return tmpCollection;
        }

        public TicketNotificacionTarjetaEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string usuarioApp, string dominio, string usuario, TicketNotificacionTarjetaEntity.EstadoTicket estado)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilUsuarioApp = usuarioApp;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilEstado = estado;

            TicketNotificacionTarjetaEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public int Save(TicketNotificacionTarjetaEntity ticket)
        {
            return Factory.Save(ticket);
        }

        public TicketNotificacionTarjetaEntity Load(int Id)
        {
            return new TicketNotificacionTarjetaFactory().Load(Id);
        }

        public int EnviarEmail(TicketNotificacionTarjetaEntityCollection collection)
        {
            string debug = string.Empty;
            int sent = 0;

            foreach (TicketNotificacionTarjetaEntity ticket in collection)
            {
                try
                {
                    bool envio = this.EnviarEmail(ticket, out debug);

                    sent++;
                }
                catch (Exception)
                {
                }
            }

            return sent;
        }

        public bool EnviarEmail(TicketNotificacionTarjetaEntity notificacion, out string debug)
        {
            debug = "";

            string mailTo = string.Empty;

            debug += " Busca el Mail del usuario en AD por usuario de red";

            mailTo = PhalanxNAL.ActiveDirectoryHelper.BuscarEmailPorLegajoUsername(notificacion.Usuario);

            if (string.IsNullOrEmpty(mailTo))
            {
                debug += " | No se encontró el Mail del usuario [" + notificacion.Usuario + "] en AD";
                return false;
            }

            debug += " | Busca Nombre del usuario que cargó la notificación";

            string solicitante = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(notificacion.Solicitante);

            MailAlertBusiness MailToSendBL = new MailAlertBusiness();

            debug += " | Envia mail";

            notificacion.MailId = MailToSendBL.NotificacionBlanqueoMail(notificacion.Usuario, mailTo, notificacion.Id, notificacion.Aplicacion.Nombre, solicitante, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            Save(notificacion);

            return true;
        }

        public int ReenviarEmailReclamo(TicketNotificacionTarjetaEntityCollection collection)
        {
            string debug = string.Empty;
            int sent = 0;

            foreach (TicketNotificacionTarjetaEntity ticket in collection)
            {
                try
                {
                    bool envio = this.ReenviarEmailReclamo(ticket, out debug);

                    sent++;
                }
                catch (Exception)
                {
                }
            }

            return sent;
        }

        public bool ReenviarEmailReclamo(TicketNotificacionTarjetaEntity notificacion, out string debug)
        {
            debug = "";

            string mailTo = string.Empty;

            debug += " Busca el Mail del usuario en AD por usuario de red";

            mailTo = PhalanxNAL.ActiveDirectoryHelper.BuscarEmailPorLegajoUsername(notificacion.Usuario);

            if (string.IsNullOrEmpty(mailTo))
            {
                debug += " | No se encontró el Mail del usuario [" + notificacion.Usuario + "] en AD";
                return false;
            }

            MailAlertBusiness MailToSendBL = new MailAlertBusiness();

            debug += " | Envia mail";

            notificacion.MailId = MailToSendBL.ReclamoNotificacionBlanqueoMail(notificacion.Usuario, mailTo, notificacion.Id, notificacion.Aplicacion.Nombre, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            notificacion.Reclamos++;

            Save(notificacion);

            return true;
        }
    }
}