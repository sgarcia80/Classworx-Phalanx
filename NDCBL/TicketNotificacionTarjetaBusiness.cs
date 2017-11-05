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
using System.Text;

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
                item.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Ingresado;
            }

            factory.Save(list);
        }

        public void Create(TicketNotificacionTarjetaEntity entidad)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            entidad.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Ingresado;

            factory.Save(entidad);
        }

        public void Delete(TicketNotificacionTarjetaEntity entidad)
        {
            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            factory.Delete(entidad);
        }

        public List<MacroArchivoEntity> Generar(List<TicketNotificacionTarjetaEntity> list, AplicacionNotificacionClaveEntityCollection apps)
        {
            Random rnd = new Random();

            MacroBusiness macrobusiness = new MacroBusiness();
            MacroClaveEntityCollection claves = new MacroClaveBusiness().GetAll();

            TicketNotificacionTarjetaFactory factory = new TicketNotificacionTarjetaFactory();

            TicketNotificacionTarjetaEntityCollection tickets = new TicketNotificacionTarjetaEntityCollection();
            List<MacroArchivoEntity> archivos = new List<MacroArchivoEntity>();
            MacroArchivoEntity archivo = null;
            MacroEntity macro = null;
            StringBuilder contenido = null;

            bool generar = false;
            int indice = 0;

            string header = string.Empty;
            StringBuilder body = new StringBuilder();
            string footer = string.Empty;
            StringBuilder filecontent = new StringBuilder();

            MacroUsuarioEntity usuarioprincipal = null;
            MacroUsuarioEntity usuariosecundario = null;

            if (claves.Count == 0)
            {
                throw new Common.CwxException("No se encontraron Claves definidas");
            }

            foreach (AplicacionNotificacionClaveEntity aplicacion in apps)
            {
                macro = macrobusiness.Load(aplicacion.Macro.Id);

                try
                {
                    //Se obtienen los usuarios para la cabecera.
                    foreach (MacroUsuarioEntity us in macro.UsuariosList)
                    {
                        if (usuarioprincipal == null && us.Principal)
                        {
                            usuarioprincipal = us;
                        }
                        if (usuariosecundario == null && !us.Principal)
                        {
                            usuariosecundario = us;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string mensaje = string.Format("Error al obtener los Usuarios Login de la Macro '{0}'", macro.Name);
                    log.Error(mensaje, ex);
                    
                    throw new Common.CwxException(mensaje);
                }

                if (usuarioprincipal == null)
                {
                    string mensaje = string.Format("No se encontró el Usuario Login Principal de la Macro '{0}'", macro.Name);
                    throw new Common.CwxException(mensaje);
                }

                header = macrobusiness.ReplaceHeader(macro.Header,
                                                    usuarioprincipal,
                                                    usuariosecundario);
                footer = macro.Footer;

                //Se resetea el flag
                generar = false;

                //Se recorren los tickets
                foreach (TicketNotificacionTarjetaEntity item in list)
                {
                    //Si el ticket corresponde a la aplicación 
                    if (item.Aplicacion.Id == aplicacion.Id)
                    {
                        //Se activa el flag para indicar que se encontraron tickets y se debe generar
                        generar = true;

                        //Si el ticket está Ingresado
                        if (item.Estado == TicketNotificacionTarjetaEntity.EstadoTicket.Ingresado)
                        {
                            //Se calcula al azar una clave
                            indice = rnd.Next(claves.Count);

                            //Se actualiza como Generado
                            item.Estado = TicketNotificacionTarjetaEntity.EstadoTicket.Generado;
                            item.FechaProcesado = DateTime.Now;
                            item.PasswordUsuarioAplicacion = claves[indice].ClaveEncriptada;
                        }

                        //Se agrega el cuerpo con el usuario y su clave asignada
                        body.AppendLine(macrobusiness.ReplaceBody(macro.Body, item.UsuarioAplicacion, item.PasswordUsuarioAplicacion));
                    }
                }

                if (generar)
                {
                    //Se crea el archivo
                    archivo = new MacroArchivoEntity();
                    archivo.Aplicacion = aplicacion;
                    archivo.Nombre = string.Format("macro_{0:yyyyMMdd}_{0:HHmm}.txt", DateTime.Now);

                    contenido = new StringBuilder();
                    //Se arma el contenido del archivo
                    contenido.AppendLine(header);
                    contenido.AppendLine(body.ToString());
                    contenido.AppendLine(footer);
                    archivo.Contenido = contenido.ToString();

                    archivos.Add(archivo);
                }
            }

            try
            {
                factory.Save(list);
            }
            catch (Exception ex)
            {
                string mensaje = "Error al grabar los tickets luego de generar las macros";
                log.Error(mensaje, ex);
            }

            return archivos;
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

        public void Save(List<TicketNotificacionTarjetaEntity> list)
        {
            Factory.Save(list);
        }

        public int Save(TicketNotificacionTarjetaEntity ticket)
        {
            return Factory.Save(ticket);
        }

        public TicketNotificacionTarjetaEntity Load(int Id)
        {
            return new TicketNotificacionTarjetaFactory().Load(Id);
        }

        public int EnviarEmail(List<TicketNotificacionTarjetaEntity> collection)
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

            notificacion.MailId = MailToSendBL.NotificacionBlanqueoMail(notificacion.UsuarioAplicacion, mailTo, notificacion.Id, notificacion.Aplicacion.Nombre, solicitante, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            Save(notificacion);

            return true;
        }

        public int ReenviarEmailReclamo(List<TicketNotificacionTarjetaEntity> collection)
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

            notificacion.MailId = MailToSendBL.ReclamoNotificacionBlanqueoMail(notificacion.UsuarioAplicacion, mailTo, notificacion.Id, notificacion.Aplicacion.Nombre, notificacion.Fecha);

            debug += " | Graba ticket BPM";

            notificacion.Reclamos++;

            Save(notificacion);

            return true;
        }
    }
}