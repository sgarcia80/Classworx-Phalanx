using System;
using phxCryptMgr;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCDAL.Factories;
using PhalanxBL;
using Classworx.Common.Trace;

namespace NDCBL
{
    /// <summary>
    /// Summary description
    /// </summary>
    public class TicketNotificacionBlanqueoBusiness
    {
        private const int DEFAULT_HORAS_EXPIRACION_TOKEN = 72;

        private TicketNotificacionBlanqueoFactory factory;
        private static int? horasExpiracionToken;

        private TicketNotificacionBlanqueoFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new TicketNotificacionBlanqueoFactory();

                return factory;
            }
        }

        //private static int HorasExpiracionToken
        //{
        //    get
        //    {
        //        if (horasExpiracionToken == null)
        //        {
        //            int horas;

        //            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["HorasExpiracionToken"], out horas))
        //                horas = DEFAULT_HORAS_EXPIRACION_TOKEN;

        //            horasExpiracionToken = new int?(horas);
        //        }

        //        return horasExpiracionToken.Value;
        //    }
        //}

        public TicketNotificacionBlanqueoBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void AceptarTyC(int id)
        {
            AceptarTyC(GetById(id));
        }

        public void AceptarTyC(TicketNotificacionBlanqueoEntity ticket)
        {
            if (ticket == null)
                return;

            ticket.FechaAceptacionTyC = DateTime.Now;

            Factory.Save(ticket);
        }

        public TicketNotificacionBlanqueoEntity Cancelar(int id)
        {
            return Cancelar(GetById(id));
        }

        public TicketNotificacionBlanqueoEntity Cancelar(TicketNotificacionBlanqueoEntity ticket)
        {
            if (ticket == null)
                return null;

            ticket.Intentos++;

            if (ticket.Intentos == 3)
            {
                ticket.FechaCancelado = DateTime.Now;
            }

            Factory.Save(ticket);

            return ticket;
        }

        public void Create(TicketNotificacionBlanqueoEntity entidad)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            factory.Save(entidad);
        }

        public void Delete(TicketNotificacionBlanqueoEntity entidad)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            factory.Delete(entidad);
        }

        public string EncriptarPassword(string pass)
        {
            return new CCryptMgr().encrypt(pass);
        }

        public string DesencriptarPassword(string pass)
        {
            return new CCryptMgr().decryptAndClearBadChars(pass);
        }

        public TicketNotificacionBlanqueoEntityCollection GetAllByUser(string dominio, string usuario)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            TicketNotificacionBlanqueoEntityCollection tmpCollection = factory.GetAllByUser(dominio, usuario);

            return tmpCollection;
        }

        public TicketNotificacionBlanqueoEntity GetMaxByUser(string usuario)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            TicketNotificacionBlanqueoEntity tmpEntity = factory.GetMaxByUser(usuario);

            return tmpEntity;
        }

        public TicketNotificacionBlanqueoEntityCollection GetAll(int tipoNotif, DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string usuarioApp, string dominio, string usuario, bool pendientes, string cargadoPor)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilUsuarioApp = usuarioApp;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilPendiente = pendientes;
            factory.FilTipoNotif = tipoNotif;
            factory.FilCargadoPor = cargadoPor;

            TicketNotificacionBlanqueoEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionBlanqueoEntityCollection GetAll(int tipoNotif, DateTime? fechaDesde, DateTime? fechaHasta, AplicacionNotificacionClaveEntity aplicacion, string usuarioApp, string dominio, string usuario, bool pendientes, string cargadoPor, bool? soloAppRed)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            factory.FilAplicacion = aplicacion;
            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;
            factory.FilUsuarioApp = usuarioApp;
            factory.FilFechaDesde = fechaDesde;
            factory.FilFechaHasta = fechaHasta;
            factory.FilPendiente = pendientes;
            factory.FilTipoNotif = tipoNotif;
            factory.FilCargadoPor = cargadoPor;
            factory.FilSoloAppRed = soloAppRed;

            TicketNotificacionBlanqueoEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionBlanqueoEntity GetById(int id)
        {
            TicketNotificacionBlanqueoEntity ticket = Factory.GetById(id);

            if (ticket.Aplicacion.EsAplicacionRed)
            {
                ticket.EmailExterno = PhalanxNAL.ActiveDirectoryHelper.BuscarEmailExternoPorUsername(ticket.Usuario);
            }

            return ticket;
        }

        public TicketNotificacionBlanqueoEntityCollection GetReporteNotificacionClaves(AplicacionNotificacionClaveEntity aplicacion, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            TicketNotificacionBlanqueoFactory factory = new TicketNotificacionBlanqueoFactory();

            TicketNotificacionBlanqueoEntityCollection tmpCollection = factory.GetReporteNotificacionClaves(aplicacion, fechaDesde, fechaHasta);

            return tmpCollection;
        }

        //public TicketNotificacionBlanqueoEntity GetByToken(string token)
        //{
        //    return Factory.GetByToken(token);
        //}

        //public TicketNotificacionBlanqueoEntity GetAltaTempranaTicket(string tipoDocumento, string documento)
        //{
        //    AplicacionNotificacionClaveBusiness appBusiness = new AplicacionNotificacionClaveBusiness();

        //    Factory.FilTipoDocumento = tipoDocumento;
        //    Factory.FilDocumento = documento;
        //    Factory.FilAplicacion = appBusiness.GetAppRed();
        //    Factory.FilFechaTyCNull = true;
        //    Factory.FilErrado = false;

        //    TicketNotificacionBlanqueoEntityCollection tickets = Factory.GetAll();

        //    if (tickets.Count < 1)
        //        return null;

        //    TicketNotificacionBlanqueoEntity ticket = tickets[0];

        //    return tickets[0];
        //}

        //public void AceptarTyC(int id)
        //{
        //    AceptarTyC(GetById(id));
        //}

        //public void AceptarTyC(TicketNotificacionBlanqueoEntity ticket)
        //{
        //    if (ticket == null)
        //        return;

        //    ticket.FechaAceptacionTyC = DateTime.Now;

        //    Factory.SaveBPMSolicitud(ticket);
        //}

        public int Save(TicketNotificacionBlanqueoEntity ticket)
        {
            return this.Save(ticket, null);
        }

        public int Save(TicketNotificacionBlanqueoEntity ticket, PhalanxCommon.Entities.WinDomainEntity dominio)
        {
            ticket.FechaVigencia = DateTime.Now;

            //Si tiene un dominio
            if (dominio != null)
            {
                string mensaje = string.Empty;
                try
                {
                    bool local = dominio.LDAPPath.ToLower().Contains("winnt");

                    if ((ticket.TipoNotificacion == TicketNotificacionBlanqueoEntity.TipoNotificacionBlanqueoRed ||
                        ticket.TipoNotificacion == TicketNotificacionBlanqueoEntity.TipoNotificacionDesbloqueo) && !local)
                    {
                        if (string.IsNullOrEmpty(dominio.LDAPUser) ||
                            string.IsNullOrEmpty(dominio.LDAPUserPassword))
                        {
                            throw new InvalidOperationException("No se encontraron las credenciales para conectarse al Dominio");
                        }

                        string password = new CCryptMgr().decryptAndClearBadChars(dominio.LDAPUserPassword);

                        PhalanxNAL.ActiveDirectoryHelper.SetAdminConnection(dominio.LDAPPath, dominio.LDAPUser, password);

                        if (ticket.TipoNotificacion == TicketNotificacionBlanqueoEntity.TipoNotificacionBlanqueoRed)
                        {
                            mensaje = "Error al blanquear la contraseña";
                            PhalanxNAL.ActiveDirectoryHelper.ResetPassword(ticket.Usuario, ticket.PasswordUsuarioAplicacion);
                        }
                        if (ticket.TipoNotificacion == TicketNotificacionBlanqueoEntity.TipoNotificacionDesbloqueo)
                        {
                            mensaje = "Error al desbloquear el usuario";
                            PhalanxNAL.ActiveDirectoryHelper.UnlockUserAccount(ticket.Usuario);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    TraceHelper.Error("Error al procesar la Notificación", ex);

                    mensaje = string.Format("{0}{1}{2}", mensaje, System.Environment.NewLine, ex.Message);
                    throw new InvalidOperationException(mensaje, ex);
                }
            }

            //Se encripta la clave solo en el Alta.
            if (!string.IsNullOrEmpty(ticket.PasswordUsuarioAplicacion) && ticket.Id == 0)
            {
                ticket.PasswordUsuarioAplicacion = this.EncriptarPassword(ticket.PasswordUsuarioAplicacion);
            }

            return Factory.Save(ticket);
        }

        public TicketNotificacionBlanqueoEntity Load(int Id)
        {
            return new TicketNotificacionBlanqueoFactory().Load(Id);
        }

        //public TicketNotificacionBlanqueoEntity LoadTktRed(int Id)
        //{

        //    TicketNotificacionBlanqueoEntity Ticket = new TicketNotificacionBlanqueoEntity();
        //    string strErrorMsg = "";
        //    try
        //    {
        //        strErrorMsg = "No se exite la aplicación correspondiente a altas de Red.";
        //        AplicacionNotificacionClaveEntity FilApp = new AplicacionNotificacionClaveBusiness().GetAppRed();

        //        strErrorMsg = "No se encuentra el ticket informado";
        //        Ticket = this.Load(Id);
        //        if (Ticket == null)
        //            throw new Exception();

        //        strErrorMsg = "El ticket informado no corresponde a Alta de Red";
        //        if (Ticket.Aplicacion.Id != FilApp.Id)
        //            throw new Exception();

        //        strErrorMsg = "El ticket informado no corresponde a un recurso externo";
        //        if (Ticket.Legajo != null && Ticket.Legajo != "")
        //            throw new Exception();
        //    }
        //    catch
        //    {
        //        throw new Common.CwxException(strErrorMsg);
        //    }
        //    return Ticket;
        //}

        //public void SetProcesoTicket(int IdTicket, DateTime FechaProcesado)
        //{
        //    TicketNotificacionBlanqueoEntity Ticket = this.Load(IdTicket);
        //    Ticket.FechaProcesado = FechaProcesado;
        //    TicketNotificacionBlanqueoFactory FTNC = new TicketNotificacionBlanqueoFactory();
        //    FTNC.SaveBPMSolicitud(Ticket);

        //}

        //public void SetNombreUsuarioAplicacion(int IdTicket, string nombreUsuario)
        //{
        //    TicketNotificacionBlanqueoEntity ticket = this.Load(IdTicket);

        //    if (ticket == null)
        //        throw new Common.CwxException("No se encuentra el ticket.");

        //    bool esAplicacionRed = false;

        //    AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();

        //    AplicacionNotificacionClaveEntity appRed = ancb.GetAppRed();

        //    if (appRed == null)
        //        throw new Common.CwxException("No se encuentra la app correspondiente a altas de Red.");

        //    esAplicacionRed = ticket.Aplicacion.Codigo == appRed.Codigo;

        //    ticket.UsuarioAplicacion = nombreUsuario;

        //    TicketNotificacionBlanqueoFactory FTNC = new TicketNotificacionBlanqueoFactory();

        //    FTNC.UpdateUsuarioAplicacion(ticket, esAplicacionRed);
        //}

        //public TicketNotificacionBlanqueoEntity GetDuplicado(int idSolicitud, AplicacionNotificacionClaveEntity aplicacion)
        //{
        //    AplicacionNotificacionClaveBusiness appBusiness = new AplicacionNotificacionClaveBusiness();

        //    Factory.FilTicket = idSolicitud;
        //    Factory.FilAplicacion = aplicacion;

        //    TicketNotificacionBlanqueoEntityCollection tickets = Factory.GetAll();

        //    if (tickets.Count < 1)
        //        return null;

        //    return tickets[0];
        //}

        //public bool ReGenerateToken(TicketNotificacionBlanqueoEntity ticket, out string MsgOut)
        //{
        //    MsgOut = "";
        //    try
        //    {
        //        ticket.Token = GenerateToken();
        //        ticket.FechaExpiracionToken = DateTime.Now.Add(TimeSpan.FromHours(HorasExpiracionToken));
        //        this.Save(ticket);
        //        MsgOut = "El token se regeneró con éxito.";
        //        // actualiza contenido del mail con nuevo token
        //    }
        //    catch
        //    {
        //        MsgOut = "Eror al regenerar el token.";
        //        return false;
        //    }
        //    try
        //    {
        //        MailAlertBusiness MABL = new MailAlertBusiness();
        //        if (ticket.MailId != null)
        //        {
        //            string destino;
        //            string solicitante = PhalanxNAL.ActiveDirectoryHelper.BuscarNombrePorUsername(ticket.Usuario);
        //            if (!string.IsNullOrEmpty(ticket.CodigoEmpresaSubsidiaria))
        //            {
        //                destino = ticket.NombreEmpresaSubsidiaria;
        //            }
        //            else
        //            {
        //                destino = ticket.NombreGerenciaDestino;
        //            }
        //            MABL.UpdateMailRegeneraToken(ticket.MailId.Value, ticket.Token, solicitante, ticket.NumeroSolicitud, ticket.Fecha, destino);
        //        }
        //        else
        //        {
        //            // habría que generar mail si no existe?
        //            MsgOut += " El ticket no tiene mail generado.";
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        MsgOut = "Error al actualizar el mail con el token regenerado.";
        //        return false;
        //    }


        //}

        //public void GenerateToken(TicketNotificacionBlanqueoEntity ticket)
        //{
        //    ticket.Token = GenerateToken();
        //    ticket.FechaExpiracionToken = DateTime.Now.Add(TimeSpan.FromHours(HorasExpiracionToken));
        //}

        //public string GenerateToken()
        //{
        //    Guid token;

        //    TicketNotificacionBlanqueoFactory FTNC = new TicketNotificacionBlanqueoFactory();

        //    do
        //    {
        //        token = Guid.NewGuid();
        //    }
        //    while (FTNC.GetByToken(token.ToString()) != null);

        //    return token.ToString();
        //}

        public int EnviarEmail(TicketNotificacionBlanqueoEntityCollection collection)
        {
            string debug = string.Empty;
            int sent = 0;

            foreach (TicketNotificacionBlanqueoEntity ticket in collection)
            {
                try
                {
                    bool envio = false;

                    if (ticket.Aplicacion.EsAplicacionRed)
                    {
                        envio = this.EnviarEmailRed(ticket, out debug);
                    }
                    else
                    {
                        envio = this.EnviarEmail(ticket, out debug);
                    }

                    sent++;
                }
                catch (Exception)
                {
                }
            }

            return sent;
        }

        public bool EnviarEmail(TicketNotificacionBlanqueoEntity notificacion, out string debug)
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

        public bool EnviarEmailRed(TicketNotificacionBlanqueoEntity notificacion, out string debug)
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

            notificacion.MailId = MailToSendBL.NotificacionBlanqueoRedMail(notificacion.Usuario, mailTo, notificacion.Id, solicitante, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            Save(notificacion);

            return true;
        }

        public int ReenviarEmailReclamo(TicketNotificacionBlanqueoEntityCollection collection)
        {
            string debug = string.Empty;
            int sent = 0;

            foreach (TicketNotificacionBlanqueoEntity ticket in collection)
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

        public bool ReenviarEmailReclamo(TicketNotificacionBlanqueoEntity notificacion, out string debug)
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