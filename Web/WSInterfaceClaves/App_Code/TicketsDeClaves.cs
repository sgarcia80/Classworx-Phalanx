using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Security.Permissions;
using NDCBL;
using NDCCommon.Entities;
using System.Configuration;
using System.DirectoryServices;
using System.Collections.Generic;
using PhalanxBL;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class TicketsDeClaves : System.Web.Services.WebService
{
    public TicketsDeClaves () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    private bool _debugMode = false;
    [WebMethod]
    public AgregarTicketResultado AgregarTicket(TicketNotificacionClave ticket)
    {
        string strDebug = "";
    
        AgregarTicketResultado resultado = new AgregarTicketResultado();

        if (ticket.StringAutenticacion.Length > 5 && ticket.StringAutenticacion.Substring(ticket.StringAutenticacion.Length - 5) == "DEBUG")
        {
            ticket.StringAutenticacion = ticket.StringAutenticacion.Substring(0, ticket.StringAutenticacion.Length - 5);
            _debugMode = true;
        }

        DatosAutenticacion datosAutenticacion = ObtenerDatosAutenticacion(ticket.StringAutenticacion);

        string usuariosAutorizados = ConfigurationManager.AppSettings["UsuariosAutorizados"];

        if (usuariosAutorizados == null || ! new List<string>(usuariosAutorizados.Split(',')).Contains(datosAutenticacion.Usuario))
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

        AplicacionNotificacionClaveBusiness bamb = new AplicacionNotificacionClaveBusiness();

        if (_debugMode)
        {
            strDebug += " | Busca aplicación codigo: " + ticket.CodigoAplicacion;
        }
        AplicacionNotificacionClaveEntity aplicacion = bamb.GetByCodigo(ticket.CodigoAplicacion);

        if (aplicacion == null)
        {
            aplicacion = new AplicacionNotificacionClaveEntity();

            aplicacion.Codigo = ticket.CodigoAplicacion;
            aplicacion.Nombre = ticket.NombreAplicacion;
            aplicacion.Notificable = true;

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

        TicketNotificacionClaveEntity ticketOriginal = bsolb.GetDuplicado(ticket.IdSolicitud, aplicacion);
        bool HayQueInsertar = true;
        if (ticketOriginal != null)
        {
            if (ticketOriginal.Equivalente(solicitudBPM))
            {
                HayQueInsertar = false;
            }
            else
            {
                // si el ticket no fue visto, se actualiza 
                if (ticketOriginal.FechaAceptacionTyC == null)
                {
                    solicitudBPM.Id = ticketOriginal.Id;
                    solicitudBPM.Fecha = ticketOriginal.Fecha;
                    bsolb.Save(solicitudBPM);
                    HayQueInsertar = false;
                }
                else
                {
                    ticketOriginal.Corregido = true;
                    bsolb.Save(ticketOriginal);
                }
            }

        }
         
        bool PasaInsertM4 = true; // esto indica true si no hubo que insertar o si hubo que hacerlo y se logro
        bool altaUsuarioRedExterno = string.IsNullOrEmpty(ticket.Legajo) && ticket.CodigoAplicacion.Trim().ToLower() == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower();

        try
        {
            if (HayQueInsertar)
            {
                if (altaUsuarioRedExterno)
                    //Alta de red usuario externo
                    solicitudBPM.Token = bsolb.GenerateToken();

                if (_debugMode)
                {
                    strDebug += " | Va a grabar ticket en phx";
                }
                bsolb.Create(solicitudBPM);
                if (_debugMode)
                {
                    strDebug += " | Guardó ticket en phx";
                }

                // si se informa legajo (o sea es un alta para recurso interno) 
                if (ticket.Legajo != null && ticket.Legajo != "")
                {
                    if (_debugMode)
                    {
                        strDebug += " | Es alta para recurso interno, legajo nro " + ticket.Legajo;
                    }
                    //y es alta de red o cobis
                    if (ticket.CodigoAplicacion.Trim().ToLower() == ConfigurationManager.AppSettings["CodigoAplicacionCOBIS"].Trim().ToLower()
                        || ticket.CodigoAplicacion.Trim().ToLower() == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower())
                    {
                        if (_debugMode)
                        {
                            strDebug += " | Tiene que grabar ticket en M4";
                        }
                        PasaInsertM4 = false;
                        Meta4ClassWorxUsuariosEntity Meta4Usuarios = new Meta4ClassWorxUsuariosEntity();
                        Meta4Usuarios.Cod_Aplicacion = ticket.CodigoAplicacion;
                        Meta4Usuarios.Cod_Novedad = "A";//Alta
                        Meta4Usuarios.Dominio_Red = ticket.DominioUsuario;
                        Meta4Usuarios.Id_Empleado = ticket.Legajo.Trim().PadLeft(6, '0');
                        Meta4Usuarios.Id_Sociedad = "01";
                        if (ticket.CodigoAplicacion.Trim().ToLower() == ConfigurationManager.AppSettings["CodigoAplicacionCOBIS"].Trim().ToLower())
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
                        Meta4Business.Create(Meta4Usuarios);
                        if (_debugMode)
                        {
                            strDebug += " | Grabó ticket en M4";
                        }
                        PasaInsertM4 = true;

                        if (ticket.CodigoAplicacion.Trim().ToLower() == ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower())
                        {
                            if (_debugMode)
                                strDebug += " | Enviando email de alta de usuario de red";


                            MailAlertBusiness MailToSendBL = new MailAlertBusiness();

                            MailToSendBL.AltaUsuarioRedMail(Meta4Usuarios.IdUsuarioRed, solicitudBPM.NumeroSolicitud, Meta4Usuarios.FechaNovedad);

                            if (_debugMode)
                                strDebug += " | Email enviado";
                        }
                    }
                    if (ticket.CodigoAplicacion.Trim().ToLower() != ConfigurationManager.AppSettings["CodigoAplicacionAltaRed"].Trim().ToLower()
                        && aplicacion.Notificable)
                    {
                        if (_debugMode) strDebug += " | El alta de usuario de aplicativo";
                        // es alta de aplicativo
                        // busca mail de la persona en Meta4, si no encuentra, no hace mas nada
                        Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();

                        if (_debugMode) strDebug += " | Busca mail del usuario";
                        Meta4LegajoEntity legajo = m4lb.GetByDocumento(ticket.TipoDocumento, ticket.Documento);
                        if (legajo != null && legajo.EMail != null && legajo.EMail != "")
                        {
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
                        string debug;
                                                
                        EnviarEmailAltaUsuarioRedExterno(solicitudBPM, out debug);

                        if (debug != null)
                            strDebug += " | " + debug;
                    }
                }
            }
            resultado.Exito = true;
            if (_debugMode) resultado.Mensaje = strDebug;
        }
        catch (Exception ex)
        {
            try
            {
                if (!PasaInsertM4)
                {
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



        return resultado;
    }

    private bool Autenticar(string dominio, string usuario, string password)
    {
        bool authentic = false;

        string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

        try
        {
            string provider = "LDAP";

            if (ConfigurationManager.AppSettings["UsarWinNT"] == "1")
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
        debug = null;

        string destino;
        List<string> mailTo = new List<string>();

        if (!string.IsNullOrEmpty(solicitudBPM.CodigoEmpresaSubsidiaria))
        {
            //Subsidiaria
            SubsidiariaBusiness subsidiariaBusiness = new SubsidiariaBusiness();

            SubsidiariaEntity subsidiaria = subsidiariaBusiness.GetByCodigo(solicitudBPM.CodigoEmpresaSubsidiaria);

            if (subsidiaria == null)
            {
                debug = "No se encuentra la empresa subsidiaria con código = " + solicitudBPM.CodigoEmpresaSubsidiaria;

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
            destino = solicitudBPM.NombreGerenciaDestino;

            string email = BuscarEmailPorLegajo(solicitudBPM.NumeroLegajoEmpleadoSolicitud);

            if (email == null)
            {
                debug = "No se encuentra el email para el legajo = " + solicitudBPM.NumeroLegajoEmpleadoSolicitud;

                return false;
            }

            mailTo.Add(email);
        }

        string solicitante = BuscarNombrePorUsername(solicitudBPM.Usuario);

        MailAlertBusiness MailToSendBL = new MailAlertBusiness();

		solicitudBPM.MailId = MailToSendBL.AltaUsuarioRedExternoMail(mailTo.ToArray(), solicitante, solicitudBPM.NumeroSolicitud, solicitudBPM.Fecha, solicitudBPM.Token, destino);

		TicketNotificacionClaveBusiness bsolb = new TicketNotificacionClaveBusiness();

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

        return BuscarLDAP(path, filter, "givenName");
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


