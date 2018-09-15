using System;
using System.Web.Services;
using NDCBL;
using NDCCommon.Entities;
using System.Configuration;
using System.DirectoryServices;
using System.Collections.Generic;
using PhalanxBL;
using System.Collections;

using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using PhalanxNAL;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using log4net;
using NDCCommon.Collections;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class TicketsDeClaves : System.Web.Services.WebService
{
    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const int LOGON32_PROVIDER_DEFAULT = 0;

    private static readonly ILog log = LogManager.GetLogger(typeof(ActiveDirectoryHelper));

    WindowsImpersonationContext impersonationContext;

    [DllImport("advapi32.dll")]
    public static extern int LogonUserA(String lpszUserName,
        String lpszDomain,
        String lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        ref IntPtr phToken);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int DuplicateToken(IntPtr hToken,
        int impersonationLevel,
        ref IntPtr hNewToken);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool RevertToSelf();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);

    private bool impersonateValidUser(String userName, String domain, String password)
    {
        WindowsIdentity tempWindowsIdentity;
        IntPtr token = IntPtr.Zero;
        IntPtr tokenDuplicate = IntPtr.Zero;

        if (RevertToSelf())
        {
            if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    impersonationContext = tempWindowsIdentity.Impersonate();
                    if (impersonationContext != null)
                    {
                        CloseHandle(token);
                        CloseHandle(tokenDuplicate);
                        return true;
                    }
                }
            }
        }
        if (token != IntPtr.Zero)
            CloseHandle(token);
        if (tokenDuplicate != IntPtr.Zero)
            CloseHandle(tokenDuplicate);
        return false;
    }

    private void undoImpersonation()
    {
        impersonationContext.Undo();
    }

    public TicketsDeClaves()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    private bool _debugMode = false;
    [WebMethod]
    public AgregarTicketResultado AgregarTicket(TicketNotificacionClave ticket)
    {
        string strDebug = "";

        log.InfoFormat("{0}", "-".PadLeft(80, '-'));
        log.InfoFormat("NumeroSolicitud: '{0}'", ticket.IdSolicitud);
        log.InfoFormat("Aplicacion: '{0}'", string.IsNullOrEmpty(ticket.CodigoAplicacion) ? string.Empty : ticket.CodigoAplicacion);
        log.InfoFormat("Usuario Aplicacion: '{0}'", string.IsNullOrEmpty(ticket.UsuarioAplicacion) ? string.Empty : ticket.UsuarioAplicacion);
        log.InfoFormat("Dominio: '{0}'", string.IsNullOrEmpty(ticket.DominioUsuario) ? string.Empty : ticket.DominioUsuario);
        log.InfoFormat("Usuario: '{0}'", string.IsNullOrEmpty(ticket.Usuario) ? string.Empty : ticket.Usuario);
        log.InfoFormat("Legajo: '{0}'", string.IsNullOrEmpty(ticket.Legajo) ? string.Empty : ticket.Legajo);
        log.InfoFormat("TipoDocumento: '{0}'", string.IsNullOrEmpty(ticket.TipoDocumento) ? string.Empty : ticket.TipoDocumento);
        log.InfoFormat("Documento: '{0}'", string.IsNullOrEmpty(ticket.Documento) ? string.Empty : ticket.Documento);
        log.InfoFormat("EsPasswordDominio: '{0}'", ticket.UsaPasswordDominio ? "Si" : "No");
        log.InfoFormat("NumeroSolicitudAltaApp: '{0}'", ticket.SolicitudID.HasValue ? ticket.SolicitudID.Value.ToString() : string.Empty);
        log.InfoFormat("CodigoGerenciaDestino: '{0}'", string.IsNullOrEmpty(ticket.CodigoGerencia) ? string.Empty : ticket.CodigoGerencia);
        log.InfoFormat("NombreGerenciaDestino: '{0}'", string.IsNullOrEmpty(ticket.NombreGerencia) ? string.Empty : ticket.NombreGerencia);
        log.InfoFormat("CodigoAreaDestino: '{0}'", string.IsNullOrEmpty(ticket.SiglaArea) ? string.Empty : ticket.SiglaArea);
        log.InfoFormat("NombreAreaDestino: '{0}'", string.IsNullOrEmpty(ticket.DescripcionArea) ? string.Empty : ticket.DescripcionArea);
        log.InfoFormat("FechaVigencia: '{0}'", ticket.FechaVigDesde.HasValue ? ticket.FechaVigDesde.Value.ToString("dd/MM/yyyy") : string.Empty);
        log.InfoFormat("NumeroLegajoEmpleadoSolicitud: '{0}'", string.IsNullOrEmpty(ticket.NroLegajoSoli) ? string.Empty : ticket.NroLegajoSoli);
        log.InfoFormat("CodigoEmpresaSubsidiaria: '{0}'", string.IsNullOrEmpty(ticket.CodSubsidiaria) ? string.Empty : ticket.CodSubsidiaria);
        log.InfoFormat("NombreEmpresaSubsidiaria: '{0}'", string.IsNullOrEmpty(ticket.NomSubsidiaria) ? string.Empty : ticket.NomSubsidiaria);
        log.InfoFormat("NombreSolicitante: '{0}'", string.IsNullOrEmpty(ticket.NomSolicitante) ? string.Empty : ticket.NomSolicitante);
        log.InfoFormat("ApellidoSolicitante: '{0}'", string.IsNullOrEmpty(ticket.ApeSolicitante) ? string.Empty : ticket.ApeSolicitante);
        //log.InfoFormat("EventoId: '{0}'", string.IsNullOrEmpty(ticket.EventoId) ? string.Empty : ticket.EventoId);
        //log.InfoFormat("EventoDescr: '{0}'", string.IsNullOrEmpty(ticket.EventoDescr) ? string.Empty : ticket.EventoDescr);
        log.InfoFormat("{0}", "-".PadLeft(80, '-'));

        AgregarTicketResultado resultado = new AgregarTicketResultado();

        // chequea si es DEBUG
        if (ticket.StringAutenticacion.Length > 5 && ticket.StringAutenticacion.Substring(ticket.StringAutenticacion.Length - 5) == "DEBUG")
        {
            ticket.StringAutenticacion = ticket.StringAutenticacion.Substring(0, ticket.StringAutenticacion.Length - 5);
            _debugMode = true;
        }

        // verifica si el usuario de red informado es correcto y está autorizado para llamar al servicio
        DatosAutenticacion datosAutenticacion = ObtenerDatosAutenticacion(ticket.StringAutenticacion);

        PhxConfigBusiness pcb = new PhxConfigBusiness();

        PhxConfigEntity configParam = pcb.GetConfigParam(ConfigCodes.UsuariosAutorizadosWSBPM);

        string usuariosAutorizados = configParam != null ? configParam.LongTxtValue : null;

        if (usuariosAutorizados == null || !new List<string>(usuariosAutorizados.Split(',')).Contains(datosAutenticacion.Usuario))
        {
            resultado.Exito = false;
            resultado.Mensaje = "Usuario no autorizado";

            return resultado;
        }

        if (!Autenticar(datosAutenticacion.Dominio, datosAutenticacion.Usuario, datosAutenticacion.Password))
        {
            resultado.Exito = false;
            resultado.Mensaje = "Error al autenticar";

            return resultado;
        }

        // verifica si la aplicación informada existe y si no, la crea
        AplicacionNotificacionClaveBusiness bamb = new AplicacionNotificacionClaveBusiness();

        if (_debugMode)
        {
            strDebug += " | Busca aplicación codigo: " + ticket.CodigoAplicacion;
        }

        log.InfoFormat("{0}", "-".PadLeft(80, '-'));

        log.InfoFormat("Se procesa el ticket {0}", ticket.IdSolicitud);
        log.InfoFormat("Se busca la aplicación {0}", ticket.CodigoAplicacion);

        AplicacionNotificacionClaveEntity aplicacion = bamb.GetByCodigo(ticket.CodigoAplicacion);

        if (aplicacion == null)
        {
            aplicacion = new AplicacionNotificacionClaveEntity();

            aplicacion.Codigo = ticket.CodigoAplicacion;
            aplicacion.Nombre = ticket.NombreAplicacion;
            aplicacion.Notificable = true;

            log.InfoFormat("No existe la aplicacion. Se da de alta [{0}]-[{1}]", ticket.CodigoAplicacion, ticket.NombreAplicacion);

            if (_debugMode)
            {
                strDebug += " | No existe aplicación, va a crearla en tabla de aplicaciones phx";
            }
            bamb.Create(aplicacion);
            if (_debugMode)
            {
                strDebug += " | Creó aplicación en tabla de aplicaciones phx";

                strDebug += " | Enviando email";
            }

            MailAlertBusiness MailToSendBL = new MailAlertBusiness();

            MailToSendBL.NuevoAplicativoBPMMail(aplicacion.Nombre);

            if (_debugMode)
                strDebug += " | Email enviado";
        }
        else if (ticket.NombreAplicacion != String.Empty && aplicacion.Nombre != ticket.NombreAplicacion)
        {
            log.InfoFormat("Se encontro la aplicacion [{0}]", ticket.CodigoAplicacion);
            if (_debugMode)
            {
                strDebug += " | Encontró aplicación en tabla de aplicaciones phx y va a actualizar nombre";
            }
            aplicacion.Nombre = ticket.NombreAplicacion;

            bamb.Update(aplicacion);
            if (_debugMode)
            {
                strDebug += " | Actualizó nombre";
            }
        }

        // genera un ticket con los datos recibidos
        TicketNotificacionClaveBusiness bsolb = new TicketNotificacionClaveBusiness();

        TicketNotificacionClaveEntity solicitudBPM = new TicketNotificacionClaveEntity();

        solicitudBPM.NumeroSolicitud = ticket.IdSolicitud;
        solicitudBPM.Aplicacion = aplicacion;
        solicitudBPM.UsuarioAplicacion = ticket.UsuarioAplicacion;
        solicitudBPM.PasswordUsuarioAplicacion = bsolb.EncriptarPassword(ticket.PasswordUsuario);
        solicitudBPM.DominioUsuario = ticket.DominioUsuario;
        solicitudBPM.Usuario = ticket.Usuario;
        solicitudBPM.Legajo = ticket.Legajo;
        solicitudBPM.TipoDocumento = ticket.TipoDocumento;
        solicitudBPM.Documento = ticket.Documento;
        solicitudBPM.EsPasswordDominio = ticket.UsaPasswordDominio;
        solicitudBPM.NumeroSolicitudAltaApp = ticket.SolicitudID;
        solicitudBPM.CodigoGerenciaDestino = ticket.CodigoGerencia;
        solicitudBPM.NombreGerenciaDestino = ticket.NombreGerencia;
        solicitudBPM.CodigoAreaDestino = ticket.SiglaArea;
        solicitudBPM.NombreAreaDestino = ticket.DescripcionArea;
        solicitudBPM.FechaVigencia = ticket.FechaVigDesde;
        solicitudBPM.NumeroLegajoEmpleadoSolicitud = ticket.NroLegajoSoli;
        solicitudBPM.CodigoEmpresaSubsidiaria = ticket.CodSubsidiaria;
        solicitudBPM.NombreEmpresaSubsidiaria = ticket.NomSubsidiaria;
        solicitudBPM.NombreSolicitante = ticket.NomSolicitante;
        solicitudBPM.ApellidoSolicitante = ticket.ApeSolicitante;

        //int eventoid = 0;
        //int.TryParse(ticket.EventoId, out eventoid);

        //solicitudBPM.EventoId = eventoid > 0 ? eventoid : (int?)null;
        //solicitudBPM.EventoDescr = ticket.EventoDescr;

        log.InfoFormat("Se valida si existe una solicitud con el numero {0}", ticket.IdSolicitud);

        // verifica si el ticket ingresado ya fue ingresado anteriormente, en función de la aplicación y la solicitud (puede ser una modficación de algunos datos)
        TicketNotificacionClaveEntity ticketOriginal = bsolb.GetDuplicado(ticket.IdSolicitud, aplicacion);
        bool HayQueInsertar = true;

        if (ticketOriginal != null)
        {
            log.InfoFormat("Ya existe el ticket {0}", ticket.IdSolicitud);

            if (ticketOriginal.Equivalente(solicitudBPM))
            {
                HayQueInsertar = false;
            }
            else
            {
                // si el ticket no fue visto, se actualiza 
                if (ticketOriginal.FechaAceptacionTyC == null)
                {
                    log.InfoFormat("Si el ticket {0} no fue visto, se actualiza", ticket.IdSolicitud);
                    solicitudBPM.Id = ticketOriginal.Id;
                    solicitudBPM.Fecha = ticketOriginal.Fecha;
                    ticketOriginal.EventoId = solicitudBPM.EventoId;
                    ticketOriginal.EventoDescr = solicitudBPM.EventoDescr;
                    bsolb.Save(solicitudBPM);
                    HayQueInsertar = false;
                }
                else
                {
                    log.InfoFormat("Se actualiza la marca de corregido del ticket {0}", ticket.IdSolicitud);

                    ticketOriginal.Corregido = true;
                    bsolb.Save(ticketOriginal);
                }
            }

        }

        bool altaUsuarioRed = ticket.CodigoAplicacion.Trim().ToLower() == bamb.GetAppRed().Codigo.ToLower();

        //Nuevo control: Usuario ya notificado
        if (altaUsuarioRed || aplicacion.Notificable)
        {
            //Se buscan si la aplicacion/usuario ya tienen algun ticket previo donde se haya notificado
            TicketNotificacionClaveEntityCollection notificados = bsolb.GetTickesByUser(solicitudBPM.Aplicacion, solicitudBPM.DominioUsuario, solicitudBPM.Usuario, solicitudBPM.UsuarioAplicacion, true);

            if (notificados != null && notificados.Count > 0)
            {
                solicitudBPM.FechaAceptacionTyC = new DateTime(1900, 1, 1);
            }
        }

        bool PasaInsertM4 = true; // esto indica true si no hubo que insertar o si hubo que hacerlo y se logro

        try
        {
            if (HayQueInsertar)
            {
                solicitudBPM.ImpactaEnAD = altaUsuarioRed;

                // verifica si es un alta de red para usuario externo
                bool altaUsuarioRedExterno = string.IsNullOrEmpty(ticket.Legajo) && altaUsuarioRed;

                log.InfoFormat("El ticket {0} es de RED y {1} es externo", (altaUsuarioRed ? "SI" : "NO"), (altaUsuarioRedExterno ? "SI" : "NO"));

                if (altaUsuarioRedExterno)
                {
                    //Alta de red usuario externo
                    if (_debugMode)
                    {
                        strDebug += " | Es alta de red para usuario externo y va a generar token";
                    }

                    log.InfoFormat("Se genera el token", ticket.IdSolicitud);

                    // genera token para alta de red de usuario externo
                    bsolb.GenerateToken(solicitudBPM);
                }

                if (_debugMode)
                {
                    strDebug += " | Va a grabar ticket en phx";
                }

                log.InfoFormat("Se graba el ticket {0}", ticket.IdSolicitud);

                // graba el ticket
                bsolb.Create(solicitudBPM);
                if (_debugMode)
                {
                    strDebug += " | Guardó ticket en phx";
                }

                // y que la notificacion no tenga fecha de notificado
                if (!solicitudBPM.FechaAceptacionTyC.HasValue)
                {
                    // si se informa legajo (o sea es un alta para recurso interno) 
                    if (ticket.Legajo != null && ticket.Legajo != "")
                    {
                        if (_debugMode)
                        {
                            strDebug += " | Es alta para recurso interno, legajo nro " + ticket.Legajo;
                        }

                        AplicacionNotificacionClaveEntity appCobis = bamb.GetAppCobis();

                        //y es alta de red o cobis
                        if (ticket.CodigoAplicacion.Trim().ToLower() == appCobis.Codigo.ToLower()
                            || altaUsuarioRed)
                        {
                            if (ticket.CodigoAplicacion.Trim().ToLower() == appCobis.Codigo.ToLower())
                            {
                                log.InfoFormat("Es alta de Cobis ({0})", appCobis.Codigo);
                            }
                            if (altaUsuarioRed)
                            {
                                log.InfoFormat("Es alta de Red");
                            }

                            if (_debugMode)
                            {
                                strDebug += " | Tiene que grabar ticket en M4";
                            }
                            log.InfoFormat("Tiene que grabar ticket en Meta4");

                            PasaInsertM4 = false;
                            Meta4ClassWorxUsuariosEntity Meta4Usuarios = new Meta4ClassWorxUsuariosEntity();
                            Meta4Usuarios.Cod_Aplicacion = ticket.CodigoAplicacion;
                            Meta4Usuarios.Cod_Novedad = "A";//Alta
                            Meta4Usuarios.Dominio_Red = ticket.DominioUsuario;
                            Meta4Usuarios.Id_Empleado = ticket.Legajo.Trim().PadLeft(6, '0');
                            Meta4Usuarios.Id_Sociedad = "01";
                            if (ticket.CodigoAplicacion.Trim().ToLower() == appCobis.Codigo.ToLower())
                            { Meta4Usuarios.IdUsuarioCore = ticket.UsuarioAplicacion; }
                            else
                            { Meta4Usuarios.IdUsuarioCore = null; }
                            Meta4Usuarios.IdUsuarioRed = ticket.Usuario;
                            Meta4Usuarios.Num_Documento = ticket.Documento;
                            Meta4Usuarios.TipoDocumento = ticket.TipoDocumento; //.Trim().PadLeft(2, '0');

                            Meta4ClassWorxUsuariosBusiness Meta4Business = new Meta4ClassWorxUsuariosBusiness();
                            if (_debugMode)
                            {
                                strDebug += " | Va a grabar ticket en M4";
                            }

                            log.InfoFormat("Se graba el usuario {0} en META4", ticket.Usuario);

                            Meta4Business.Create(Meta4Usuarios);
                            if (_debugMode)
                            {
                                strDebug += " | Grabó ticket en M4";
                            }
                            PasaInsertM4 = true;

                            if (altaUsuarioRed)
                            {
                                if (_debugMode)
                                    strDebug += " | Enviando email de alta de usuario de red";

                                log.Info("Se envia el mail de alta de usuario de red");

                                MailAlertBusiness MailToSendBL = new MailAlertBusiness();

                                MailToSendBL.AltaUsuarioRedMail(Meta4Usuarios.IdUsuarioRed, solicitudBPM.NumeroSolicitud, Meta4Usuarios.FechaNovedad);

                                if (_debugMode)
                                    strDebug += " | Email enviado";
                            }
                        }
                        if (altaUsuarioRed
                            || aplicacion.Notificable)
                        {
                            if (_debugMode) strDebug += " | El alta de usuario de aplicativo";
                            // es alta de aplicativo
                            // busca mail de la persona en Meta4, si no encuentra, no hace mas nada
                            Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();

                            log.InfoFormat("Se busca en META4 el mail del usuario (Documento {0} - {1})", ticket.TipoDocumento, ticket.Documento);

                            if (_debugMode) strDebug += " | Busca mail del usuario";
                            Meta4LegajoEntity legajo = m4lb.GetByDocumento(ticket.TipoDocumento, ticket.Documento);
                            if (legajo != null && legajo.EMail != null && legajo.EMail != "")
                            {
                                log.InfoFormat("Se encontro en META4 y se envia mail a {0}", legajo.EMail);

                                if (_debugMode) strDebug += " | Encontro mail del usuario";
                                MailAlertBusiness MailToSendBL = new MailAlertBusiness();

                                // enviar mail al usuario si es notificable
                                if (ticket.UsaPasswordDominio)
                                {
                                    if (_debugMode) strDebug += " | Es aplicativo con seguridad integrada y va a enviar mail";
                                    // si es aplicativo con seguridad integrada envia mail de tal fin
                                    MailToSendBL.MailAltaUsuarioAplicativoConSegInt(solicitudBPM.Aplicacion.Nombre, solicitudBPM.Fecha.ToString("dd/MM/yyyy"), solicitudBPM.NumeroSolicitud.ToString(), legajo.EMail);
                                }
                                else
                                {
                                    // si es aplicativo con seguridad propia envia mail de tal fin
                                    if (_debugMode) strDebug += " | Es aplicativo con seguridad propia y va a enviar mail";
                                    MailToSendBL.MailAltaUsuarioAplicativoConSegProp(solicitudBPM.Aplicacion.Nombre, solicitudBPM.Fecha.ToString("dd/MM/yyyy"), solicitudBPM.NumeroSolicitud.ToString(), legajo.EMail);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_debugMode)
                        {
                            strDebug += " | Es alta para recurso externo";
                        }

                        if (altaUsuarioRedExterno)
                        {
                            log.Info("Se envia mail para recurso externo");

                            string debug;

                            if (_debugMode)
                            {
                                strDebug += " | Se va a enviar mail de alta de red para recurso externo";
                            }
                            EnviarEmailAltaUsuarioRedExterno(solicitudBPM, out debug);

                            if (debug != null)
                                strDebug += " | " + debug;
                        }
                    }
                }
            }
            resultado.Exito = true;
            if (_debugMode) resultado.Mensaje = strDebug;
        }
        catch (Exception ex)
        {
            log.Error("Error al procesar el ticket", ex);

            try
            {
                if (!PasaInsertM4)
                {
                    log.InfoFormat("Se borra el ticket");
                    if (_debugMode)
                    {
                        strDebug += " | Va a borrar ticket en phx";
                    }
                    bsolb.Delete(solicitudBPM);
                    if (_debugMode)
                    {
                        strDebug += " | Borró ticket en phx";
                    }
                }
            }
            catch
            {
            }
            resultado.Exito = false;
            if (_debugMode)
            {
                if (ex.Message != null)
                {
                    strDebug += " | " + ex.Message;
                    if (ex.InnerException != null && ex.InnerException.Message != null)
                    {
                        strDebug += " | " + ex.InnerException.Message;
                    }
                }
            }
            //resultado.Mensaje = ex.Message + ex.InnerException;
            if (PasaInsertM4)
            {
                resultado.Mensaje = "No se pudo almacenar el alta de usuario informado." + strDebug;
            }
            else
            {
                resultado.Mensaje = "No se pudo almacenar el alta de usuario debido a que Meta4 informa que los datos ingresados son inconsistentes." + strDebug;
            }
        }

        log.InfoFormat(resultado.Mensaje);

        return resultado;
    }

    private bool Autenticar(string dominio, string usuario, string password)
    {
        bool authentic = false;

        string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

        try
        {
            string provider = "LDAP";

            PhxConfigBusiness pcb = new PhxConfigBusiness();

            PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionUsuariosAutorizadosWSBPM);

            if (config.ShortTxtValue == "WINNT")
                provider = "WinNT";

            DirectoryEntry entry = new DirectoryEntry(provider + "://" + dominio, usuario, password);

            object nativeObject = entry.NativeObject;
            authentic = true;
        }
        catch (Exception ex)
        {

        }

        return authentic;
    }

    private DatosAutenticacion ObtenerDatosAutenticacion(string stringAutenticacion)
    {
        DatosAutenticacion datosAutenticacion = new DatosAutenticacion();

        string autenticacion = (new phxCryptMgr.CCryptMgr()).decryptAndClearBadChars(stringAutenticacion);

        foreach (string dato in autenticacion.Split(';'))
        {
            if (dato.StartsWith("usuario=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Usuario = dato.Substring(8);
            else if (dato.StartsWith("dominio=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Dominio = dato.Substring(8);
            else if (dato.StartsWith("password=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Password = dato.Substring(9);
        }

        return datosAutenticacion;
    }

    private bool EnviarEmailAltaUsuarioRedExterno(TicketNotificacionClaveEntity solicitudBPM, out string debug)
    {
        debug = "";

        string destino = string.Empty;
        List<string> mailTo = new List<string>();

        if (!string.IsNullOrEmpty(solicitudBPM.CodigoEmpresaSubsidiaria))
        {
            log.InfoFormat("Se busca la subsidiaria {0}", solicitudBPM.CodigoEmpresaSubsidiaria);

            debug += " | Se busca por Subsidiaria";
            //Subsidiaria
            SubsidiariaBusiness subsidiariaBusiness = new SubsidiariaBusiness();

            SubsidiariaEntity subsidiaria = subsidiariaBusiness.GetByCodigo(solicitudBPM.CodigoEmpresaSubsidiaria);

            //if (subsidiaria == null)
            //{
            //    debug += " | No se encuentra la empresa subsidiaria con código = " + solicitudBPM.CodigoEmpresaSubsidiaria;

            //    return false;
            //}

            //Si no se encontró la subsidiaria
            if (subsidiaria == null)
            {
                log.Info("No se encontro la subsidiaria");

                debug += " | No se encuentra la empresa subsidiaria con código = " + solicitudBPM.CodigoEmpresaSubsidiaria;
            }
            else
            {
                log.InfoFormat("Se encontro la subsidiaria [{0}]", subsidiaria.Nombre);

                destino = solicitudBPM.NombreEmpresaSubsidiaria;

                if (!string.IsNullOrEmpty(subsidiaria.Email01))
                {
                    mailTo.Add(subsidiaria.Email01);
                }
                if (!string.IsNullOrEmpty(subsidiaria.Email02))
                {
                    mailTo.Add(subsidiaria.Email02);
                }
            }
        }

        //Si no se encontró mails de Subsidiaria
        if (mailTo.Count == 0)
        {
            log.InfoFormat("No se encontro mail de la subsidiaria, se busca por Legajo {0}", solicitudBPM.NumeroLegajoEmpleadoSolicitud);

            debug += " | Se busca por Gerencia destino";

            destino = solicitudBPM.NombreGerenciaDestino;

            debug += " | Busca mail en AD por legajo de solicitante";
            string email = BuscarEmailPorLegajo(solicitudBPM.NumeroLegajoEmpleadoSolicitud);

            if (email == null)
            {
                log.Info("No se encontro el usuario en AD");

                debug += " | No se encuentra el email para el legajo = " + solicitudBPM.NumeroLegajoEmpleadoSolicitud;

                return false;
            }

            mailTo.Add(email);
        }

        debug += " | Busca Nombre de la pesrona la que se le dió de alta el usuario en AD por usuario de red";

        string solicitante = BuscarNombrePorUsername(solicitudBPM.Usuario);

        MailAlertBusiness MailToSendBL = new MailAlertBusiness();

        debug += " | Envia mail";

        log.Info("Se envia mail de alta de usuario externo");

        solicitudBPM.MailId = MailToSendBL.AltaUsuarioRedExternoMail(mailTo.ToArray(), solicitante, solicitudBPM.NumeroSolicitud, solicitudBPM.Fecha, solicitudBPM.Token, destino);

        TicketNotificacionClaveBusiness bsolb = new TicketNotificacionClaveBusiness();

        debug += " | Graba ticket BPM";

        bsolb.Save(solicitudBPM);

        return true;
    }

    private string BuscarEmailPorLegajo(string legajo)
    {
        string path = ConfigurationManager.AppSettings["LDAPPath"];
        string filter = ConfigurationManager.AppSettings["LDAPBuscarEmailFilter"].Replace("[legajo]", legajo);

        return BuscarLDAP(path, filter, "mail");
    }

    private string BuscarNombrePorUsername(string username)
    {
        string path = ConfigurationManager.AppSettings["LDAPPath"];
        string filter = ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"].Replace("[username]", username);

        return BuscarLDAP(path, filter, "displayName");
    }

    private string BuscarLDAP(string path, string filter, string property)
    {
        try
        {
            DirectoryEntry directoryEntry = new DirectoryEntry(path);

            DirectorySearcher search = new DirectorySearcher(directoryEntry);

            search.Filter = filter;

            search.PropertiesToLoad.Add(property);

            foreach (SearchResult sr in search.FindAll())
            {
                if (sr.Properties[property] != null && sr.Properties[property].Count > 0)
                    return sr.Properties[property][0].ToString();
            }
        }
        catch (Exception ex)
        {

        }

        return null;
    }

    private struct DatosAutenticacion
    {
        public string Dominio;
        public string Usuario;
        public string Password;
    }
    private string strDebug = "";
    [WebMethod]
    public string TestLDAPConfig(string username, string legajo)
    {
        string Result = "";
        try
        {
            //if (impersonateValidUser("administrador", "Cwxtest", "cascas"))
            //{
            //    Result += "Hizo impersonation | " + Environment.NewLine;
            //}
            //else
            //{
            //    Result += "NO Hizo impersonation | " + Environment.NewLine;
            //    //Your impersonation failed. Therefore, include a fail-safe mechanism here.
            //}

            Result += "Conectado como: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string path = ConfigurationManager.AppSettings["LDAPPath"];

            Result += " | Objetos en el path LDAP: " + path + " | ";
            ArrayList list = EnumerateOU(path);
            Result += strDebug;
            Result += " | Cantidad de objetos: " + list.Count.ToString() + " | ";
            string result = string.Join("|", (string[])list.ToArray(typeof(string)));
            Result += result;
            if (!string.IsNullOrEmpty(username))
            {
                string filterUsername = ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"].Replace("[username]", username);
                Result += " | " + "Prueba de filtro por usuario: " + filterUsername;
                string RespFiltUsername = BuscarLDAP(path, filterUsername, "displayName");
                Result += " | " + "Búsqueda de nombre por usuario: " + username + " | " + RespFiltUsername;
            }
            if (!string.IsNullOrEmpty(username))
            {
                string filterEmployeeID = ConfigurationManager.AppSettings["LDAPBuscarEmailFilter"].Replace("[legajo]", legajo);
                Result += " | " + "Prueba de filtro por legajo: " + filterEmployeeID;
                string RespFiltEmployeeID = BuscarLDAP(path, filterEmployeeID, "mail");
                Result += " | " + "Búsqueda de usuario: " + legajo + " | " + RespFiltEmployeeID;
            }
        }
        catch (Exception ex)
        {
            Result += strDebug;
            Result += " | " + ex.Message;

        }
        //finally
        //{
        //    undoImpersonation();
        //    Result += "Cerro impersonation | Conectado como: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        //}

        return Result;
    }


    private ArrayList EnumerateOU(string OuDn)
    {
        strDebug = "";

        ArrayList alObjects = new ArrayList();
        //try
        //{
        //DirectoryEntry directoryObject = new DirectoryEntry(@"LDAP://" + OuDn);
        //DirectoryEntry directoryObject = new DirectoryEntry(OuDn, "administrador", "cascas");
        DirectoryEntry directoryObject = new DirectoryEntry(OuDn);
        //strDebug += "pasó DirectoryEntry(" + OuDn + ")";
        foreach (DirectoryEntry child in directoryObject.Children)
        {
            //strDebug += "entra a foreach";
            string childPath = child.Path.ToString();
            alObjects.Add(childPath.Remove(0, 7));
            //remove the LDAP prefix from the path

            child.Close();
            child.Dispose();
        }
        //strDebug += "directoryObject.Close";
        directoryObject.Close();
        //strDebug += "directoryObject.Dispose";
        directoryObject.Dispose();
        //}
        //catch (DirectoryServicesCOMException e)
        //{
        //    Console.WriteLine("An Error Occurred: " + e.Message.ToString());
        //}
        return alObjects;
    }

}

public class AgregarTicketResultado
{
    private bool exito;
    private string mensaje;

    public bool Exito
    {
        set { exito = value; }
        get { return exito; }
    }

    public string Mensaje
    {
        set { mensaje = value; }
        get { return mensaje; }
    }
}


