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
    /// Summary description for BPMSolicitudBusiness
    /// </summary>
    public class TicketNotificacionClaveBusiness
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TicketNotificacionClaveBusiness));

        private const int DEFAULT_HORAS_EXPIRACION_TOKEN = 72;

        private TicketNotificacionClaveFactory factory;
        private static int? horasExpiracionToken;
        private static AplicacionNotificacionClaveEntity AppCobis = null;
        private static AplicacionNotificacionClaveEntity AppRed = null;

        private TicketNotificacionClaveFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new TicketNotificacionClaveFactory();

                return factory;
            }
        }

        private static int HorasExpiracionToken
        {
            get
            {
                if (horasExpiracionToken == null)
                {
                    int horas;

                    if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["HorasExpiracionToken"], out horas))
                        horas = DEFAULT_HORAS_EXPIRACION_TOKEN;

                    horasExpiracionToken = new int?(horas);
                }

                return horasExpiracionToken.Value;
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
            return GetAllActiveByUser(dominio, usuario, string.Empty);
        }

        public TicketNotificacionClaveEntityCollection GetAllActiveByUser(string dominio, string usuario, string aplicacion)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAllActiveByUser(dominio, usuario, aplicacion);

            return tmpCollection;
        }

        public TicketNotificacionClaveEntityCollection GetAllUsrExt(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, int? ticket, bool? vencido, bool? notificado)
        {
            return this.GetAll(fechaDesde, fechaHasta, aplicacion, dominio, usuario, ticket, true, false, vencido, notificado);
        }

        public TicketNotificacionClaveEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario)
        {
            return this.GetAll(fechaDesde, fechaHasta, aplicacion, dominio, usuario, null, null, false);
        }

        public TicketNotificacionClaveEntityCollection GetReporteNotif(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilSinLegajo = null;
            factory.FilTicket = null;
            factory.FilCorregido = false;
            factory.FilVencido = null;

            factory.FilReporteNotif = true;

            factory.FilFechaTyCNull = true;

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionClaveEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, int? ticket, bool? SinLegajo, bool? corregido)
        {
            return GetAll(fechaDesde, fechaHasta, aplicacion, dominio, usuario, ticket, SinLegajo, corregido, null, null);
        }

        public TicketNotificacionClaveEntityCollection GetAll(DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, int? ticket, bool? SinLegajo, bool? corregido, bool? vencido, bool? notificado)
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
            factory.FilVencido = vencido;

            if (notificado != null)
                factory.FilFechaTyCNull = !notificado.Value;

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionClaveEntityCollection GetTickesByUser(AplicacionNotificacionClaveEntity aplicacion, string dominio, string usuario, string app_user, bool? notificado)
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilUsuarioApp = app_user;
            
            if (notificado != null)
                factory.FilFechaTyCNull = !notificado.Value;

            TicketNotificacionClaveEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }
        public TicketNotificacionClaveEntityCollection ObtenerTodosAgregarMarcaAD()
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.FilImpactaEnAD = true;
            factory.FilMarcadoEnAD = false;

            return factory.GetAll();
        }

        public TicketNotificacionClaveEntityCollection ObtenerTodosQuitarMarcaAD()
        {
            TicketNotificacionClaveFactory factory = new TicketNotificacionClaveFactory();

            factory.FilImpactaEnAD = true;
            factory.FilMarcadoEnAD = true;
            factory.FilMarcaEliminadaEnAD = false;
            factory.FilVisualizado = true;

            return factory.GetAll();
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
            Factory.FilAplicacion = appBusiness.GetAppRed();
            Factory.FilFechaTyCNull = true;
            Factory.FilErrado = false;

            TicketNotificacionClaveEntityCollection tickets = Factory.GetAll();

            if (tickets.Count < 1)
                return null;

            TicketNotificacionClaveEntity ticket = tickets[0];

            return tickets[0];
        }

        public TicketNotificacionClaveEntityCollection GetAltaTempranaPendientes(string dominio, string usuario)
        {
            AplicacionNotificacionClaveBusiness appBusiness = new AplicacionNotificacionClaveBusiness();
            var app = appBusiness.GetAppRed();

            //No se utiliza el Dominio por la diferencia MACRO vs MACRO.COM.AR
            //Factory.FilDominio = dominio;

            Factory.FilUsuario = usuario;
            Factory.FilAplicacion = app;
            //Factory.FilFechaTyCNull = true;
            //Factory.FilErrado = false;

            log.InfoFormat("Se busca la aplicación {0} para el usuario {1}/{2}", app.Id, dominio, usuario);

            TicketNotificacionClaveEntityCollection tickets = Factory.GetAll();

            return tickets;
        }

        public void AceptarTyC(int id)
        {
            AceptarTyC(GetById(id));
        }

        public void AceptarTyC(TicketNotificacionClaveEntity ticket)
        {
            if (ticket == null)
                return;

            ticket.FechaAceptacionTyC = DateTime.Now;

            Factory.SaveBPMSolicitud(ticket);
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
                strErrorMsg = "No se exite la aplicación correspondiente a altas de Red.";
                AplicacionNotificacionClaveEntity FilApp = new AplicacionNotificacionClaveBusiness().GetAppRed();

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

            AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();

            AplicacionNotificacionClaveEntity appRed = ancb.GetAppRed();

            if (appRed == null)
                throw new Common.CwxException("No se encuentra la app correspondiente a altas de Red.");

            esAplicacionRed = ticket.Aplicacion.Codigo == appRed.Codigo;

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
        public bool ReGenerateToken(TicketNotificacionClaveEntity ticket, out string MsgOut)
        {
            MsgOut = "";
            try
            {
                ticket.Token = GenerateToken();
                ticket.FechaExpiracionToken = DateTime.Now.Add(TimeSpan.FromHours(HorasExpiracionToken));
                this.Save(ticket);
                MsgOut = "El token se regeneró con éxito.";
                // actualiza contenido del mail con nuevo token
            }
            catch
            {
                MsgOut = "Eror al regenerar el token.";
                return false;
            }
            try
            {
                MailAlertBusiness MABL = new MailAlertBusiness();
                if (ticket.MailId != null)
                {
                    string destino;
                    string solicitante = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(ticket.Usuario);
                    if (!string.IsNullOrEmpty(ticket.CodigoEmpresaSubsidiaria))
                    {
                        destino = ticket.NombreEmpresaSubsidiaria;
                    }
                    else
                    {
                        destino = ticket.NombreGerenciaDestino;
                    }
                    MABL.UpdateMailRegeneraToken(ticket.MailId.Value, ticket.Token, solicitante, ticket.NumeroSolicitud, ticket.Fecha, destino);
                }
                else
                {
                    // habría que generar mail si no existe?
                    MsgOut += " El ticket no tiene mail generado.";
                }
                return true;
            }
            catch
            {
                MsgOut = "Error al actualizar el mail con el token regenerado.";
                return false;
            }


        }
        public void GenerateToken(TicketNotificacionClaveEntity ticket)
        {
            ticket.Token = GenerateToken();
            ticket.FechaExpiracionToken = DateTime.Now.Add(TimeSpan.FromHours(HorasExpiracionToken));
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

        public bool EnviarEmailAltaUsuarioRedExterno(TicketNotificacionClaveEntity solicitudBPM, out string debug)
        {
            debug = "";

            string destino;
            List<string> mailTo = new List<string>();

            if (!string.IsNullOrEmpty(solicitudBPM.CodigoEmpresaSubsidiaria))
            {
                debug += " | Se busca por Subsidiaria";
                //Subsidiaria
                SubsidiariaBusiness subsidiariaBusiness = new SubsidiariaBusiness();

                SubsidiariaEntity subsidiaria = subsidiariaBusiness.GetByCodigo(solicitudBPM.CodigoEmpresaSubsidiaria);

                if (subsidiaria == null)
                {
                    debug += " | No se encuentra la empresa subsidiaria con código = " + solicitudBPM.CodigoEmpresaSubsidiaria;

                    return false;
                }

                destino = solicitudBPM.NombreEmpresaSubsidiaria;

                if (!string.IsNullOrEmpty(subsidiaria.Email01))
                    mailTo.Add(subsidiaria.Email01);

                if (!string.IsNullOrEmpty(subsidiaria.Email02))
                    mailTo.Add(subsidiaria.Email02);
            }
            else
            {
                debug += " | Se busca por Gerencia destino";

                destino = solicitudBPM.NombreGerenciaDestino;

                debug += " | Busca mail en AD por legajo de solicitante";
                string email = PhalanxNAL.ActiveDirectoryHelper.BuscarEmailPorLegajo(solicitudBPM.NumeroLegajoEmpleadoSolicitud);

                if (email == null)
                {
                    debug += " | No se encuentra el email para el legajo = " + solicitudBPM.NumeroLegajoEmpleadoSolicitud;

                    return false;
                }

                mailTo.Add(email);
            }

            debug += " | Busca Nombre de la pesrona la que se le dió de alta el usuario en AD por usuario de red";

            string solicitante = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(solicitudBPM.Usuario);

            MailAlertBusiness MailToSendBL = new MailAlertBusiness();

            debug += " | Envia mail";

            solicitudBPM.MailId = MailToSendBL.AltaUsuarioRedExternoMail(mailTo.ToArray(), solicitante, solicitudBPM.NumeroSolicitud, solicitudBPM.Fecha, solicitudBPM.Token, destino);

            debug += " | Graba ticket BPM";

            Save(solicitudBPM);

            return true;
        }

        public int ReenviarEmailReclamo(TicketNotificacionClaveEntityCollection collection)
        {
            string debug = string.Empty;
            int sent = 0;
            AplicacionNotificacionClaveBusiness bamb = new AplicacionNotificacionClaveBusiness();

            if (AppCobis == null)
            {
                AppCobis = bamb.GetAppCobis();
            }
            if (AppRed == null)
            {
                AppRed = bamb.GetAppRed();
            }

            foreach (TicketNotificacionClaveEntity ticket in collection)
            {
                try
                {
                    bool envio = this.ReenviarEmailReclamo(ticket, out debug);

                    log.Info("Debug de ticket id " + ticket.Id.ToString() + ".");
                    log.Info(debug);

                    sent++;
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("Error al reclamar la notificación (Id {0}) de alta de usuario", ticket.Id), ex);
                }
            }

            return sent;
        }

        public bool ReenviarEmailReclamo(TicketNotificacionClaveEntity notificacion, out string debug)
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

            //mailTo = "sgarcia@classworx.com.ar";

            notificacion.MailId = MailToSendBL.ReclamoNotificacionBlanqueoMail(notificacion.Usuario, mailTo, notificacion.Id, notificacion.Aplicacion.Nombre, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            if (notificacion.MailId.HasValue)
            {
                notificacion.Reclamos++;

                Save(notificacion);
            }

            return true;
        }
    }
}