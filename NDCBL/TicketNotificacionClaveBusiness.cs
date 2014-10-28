using System;
using System.Data;
using System.Configuration;
using phxCryptMgr;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    /// <summary>
    /// Summary description for BPMSolicitudBusiness
    /// </summary>
    public class TicketNotificacionClaveBusiness
    {
        private static string codigoAppAltaTemprana;
        private TicketNotificacionClaveFactory factory;

        private static string CodigoAppAltaTemprana
        {
            get
            {
                if (codigoAppAltaTemprana == null)
                    codigoAppAltaTemprana = ConfigurationManager.AppSettings["CodigoAppAltaTemprana"];

                return codigoAppAltaTemprana;
            }
        }

        private TicketNotificacionClaveFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new TicketNotificacionClaveFactory();

                return factory;
            }
        }

        public TicketNotificacionClaveBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Create(TicketNotificacionClaveEntity entidad)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.SaveBPMSolicitud(entidad);
        }

        public void Delete(TicketNotificacionClaveEntity entidad)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.DeleteBPMSolicitud(entidad);
        }

        public string EncriptarPassword(string pass)
        {
            return new CCryptMgr().encrypt(pass);
        }

        public static string DesencriptarPassword(string pass)
        {
            return new CCryptMgr().decryptAndClearBadChars(pass);
        }

        public TicketNotificacionClaveEntityCollection GetAllByUser(string dominio, string usuario)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAllByUser(dominio, usuario);

            return tmpCollection;
        }

		public TicketNotificacionClaveEntityCollection GetAllActiveByUser(string dominio, string usuario)
		{
			TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

			TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAllActiveByUser(dominio, usuario);

			return tmpCollection;
		}

        public TicketNotificacionClaveEntityCollection GetAllUsrExt(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, int? ticket)
        {
            return this.GetAll(fechaDesde, fechaHasta, aplicacion, dominio, usuario, ticket, true, false);
        }

        public TicketNotificacionClaveEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario)
        {
            return this.GetAll(fechaDesde, fechaHasta, aplicacion, dominio, usuario, null, null, false);
        }
        public TicketNotificacionClaveEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, int? ticket, bool? SinLegajo, bool? corregido)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilSinLegajo = SinLegajo;
            factory.FilTicket = ticket;
            factory.FilCorregido = corregido;

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionClaveEntity GetById(int id)
        {
            return Factory.GetById(id);
        }

        public TicketNotificacionClaveEntity GetByToken(string token)
        {
            return Factory.GetByToken(token);
        }

        public TicketNotificacionClaveEntity GetAltaTempranaTicket(string tipoDocumento, string documento)
        {
            AplicacionNotificacionClaveBusiness appBusiness = new AplicacionNotificacionClaveBusiness();

            Factory.FilTipoDocumento = tipoDocumento;
            Factory.FilDocumento = documento;
            Factory.FilAplicacion = appBusiness.GetByCodigo(CodigoAppAltaTemprana);
            Factory.FilFechaTyCNull = true;
            Factory.FilErrado = false;

            TicketNotificacionClaveEntityCollection tickets = Factory.GetAll();

            if (tickets.Count < 1)
                return null;

            TicketNotificacionClaveEntity ticket = tickets[0];

            return tickets[0];
        }

        public void AceptarTyC(int id)
        {
            TicketNotificacionClaveEntity ticket = GetById(id);

            if (ticket == null)
                return;

            ticket.FechaAceptacionTyC = DateTime.Now;

            Factory.SaveBPMSolicitud(ticket);

            return;
        }

        public void Save(TicketNotificacionClaveEntity ticket)
        {
            Factory.SaveBPMSolicitud(ticket);
        }
        public TicketNotificacionClaveEntity Load(int Id)
        {
            return new TicketNotificacionClaveFactory().Load(Id);
        }
        public TicketNotificacionClaveEntity LoadTktRed(int Id)
        {

            TicketNotificacionClaveEntity Ticket = new TicketNotificacionClaveEntity();
            string strErrorMsg = "";
            try
            {
                strErrorMsg = "No se encuentra la parametrización del Código correspondiente a altas de Red en el archivo de configuración de la aplicación.";
                string strCodRed = ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].ToString();

                strErrorMsg = "No se encuentra la aplicación correspondiente a altas de Red informada en el archivo de configuración de la aplicación.";
                AplicacionNotificacionClaveEntity FilApp = new AplicacionNotificacionClaveBusiness().GetByCodigo(strCodRed);

                strErrorMsg = "No se encuentra el ticket informado";
                Ticket = this.Load(Id);
                if (Ticket == null)
                    throw new Exception();

                strErrorMsg = "El ticket informado no corresponde a Alta de Red";
                if (Ticket.Aplicacion.Id != FilApp.Id)
                    throw new Exception();

                strErrorMsg = "El ticket informado no corresponde a un recurso externo";
                if (Ticket.Legajo != null && Ticket.Legajo != "")
                    throw new Exception();
            }
            catch
            {
                throw new Common.CwxException(strErrorMsg);
            }
            return Ticket;
        }

        public void SetProcesoTicket(int IdTicket, DateTime FechaProcesado)
        {
            TicketNotificacionClaveEntity Ticket = this.Load(IdTicket);
            Ticket.FechaProcesado = FechaProcesado;
            TicketNotificacionClaveFactory FTNC = new TicketNotificacionClaveFactory();
            FTNC.SaveBPMSolicitud(Ticket);

        }

        public void SetNombreUsuarioAplicacion(int IdTicket, string nombreUsuario)
        {
            TicketNotificacionClaveEntity ticket = this.Load(IdTicket);

            if (ticket == null)
                throw new Common.CwxException("No se encuentra el ticket.");

            bool esAplicacionRed = false;

            string strCodRed = ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].ToString();

            if (strCodRed == null)
                throw new Common.CwxException("No se encuentra la parametrización del Código correspondiente a altas de Red en el archivo de configuración de la aplicación.");

            esAplicacionRed = ticket.Aplicacion.Codigo == strCodRed;
            
            ticket.UsuarioAplicacion = nombreUsuario;

            TicketNotificacionClaveFactory FTNC = new TicketNotificacionClaveFactory();

            FTNC.UpdateUsuarioAplicacion(ticket, esAplicacionRed);
        }

        public TicketNotificacionClaveEntity GetDuplicado(int idSolicitud, AplicacionNotificacionClaveEntity aplicacion)
        {
            AplicacionNotificacionClaveBusiness appBusiness = new AplicacionNotificacionClaveBusiness();

            Factory.FilTicket = idSolicitud;
            Factory.FilAplicacion = aplicacion;
            
            TicketNotificacionClaveEntityCollection tickets = Factory.GetAll();

            if (tickets.Count < 1)
                return null;

            return tickets[0];
        }

        public string GenerateToken()
        {
            Guid token;

            TicketNotificacionClaveFactory FTNC = new TicketNotificacionClaveFactory();

            do
            {
                token = Guid.NewGuid();
            }
            while (FTNC.GetByToken(token.ToString()) != null);

            return token.ToString();
        }
    }
}