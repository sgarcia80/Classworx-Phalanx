using System;
using System.Collections.Generic;
using System.Text;
using NDCBL;
using NDCCommon.Entities;
using PhalanxNAL;
using PhxADService.Properties;
using log4net;

namespace PhxADService
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Comienzo ejecución servicio...");

            try
            {
                if (InicializarDB())
                {
                    AgregarMarcaAD();

                    QuitarMarcaAD();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al ejecutar el servicio", ex);
            }

            log.Info("Fin ejecución servicio.");
        }

        private static bool InicializarDB()
        {
            log.Info("Inicializando base de datos...");

            PhalanxDAL.DBMgr.Application = PhalanxCommon.Entities.App.NotificacionClaves;
            PhalanxDAL.DBMgr.NHAssembly = System.Reflection.Assembly.Load("NDCDAL");
            
            if (PhalanxDAL.DBMgr.Inicializar())
            {
                log.Info("Base de datos inicializada correctamente");

                return true;
            }
            else
                log.Info("Error al inicializar la Base de datos");

            return false;
        }

        private static void AgregarMarcaAD()
        {
            log.Info("Comienzo agregado de marcas en AD...");

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            foreach (TicketNotificacionClaveEntity ticket in tncb.ObtenerTodosAgregarMarcaAD())
            {
                log.Info("Procesando ticket Id = " + ticket.Id.ToString() + " ...");

                log.Info("Agregando marca al usuario " + ticket.Usuario + " ...");

                if (ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(ticket.Usuario, Settings.Default.PrefijoDescripcionUsuarioRed, Settings.Default.LDAPPath, Settings.Default.FiltroBuscarNombreLDAP))
                {
                    log.Info("Marca agregada correctamente");

                    log.Info("Seteando fecha de agregado de marca...");

                    ticket.FechaSeteoMarcaAD = DateTime.Now;

                    tncb.Save(ticket);

                    log.Info("Fecha de agregado de marca seteada correctamente");
                }
                else
                    log.Info("No se pudo agregar la marca");

                log.Info("Procesado de ticket finalizado");
            }

            log.Info("Fin agregado de marcas en AD");
        }

        private static void QuitarMarcaAD()
        {
            log.Info("Comienzo eliminación de marcas en AD...");

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            foreach (TicketNotificacionClaveEntity ticket in tncb.ObtenerTodosQuitarMarcaAD())
            {
                log.Info("Procesando ticket Id = " + ticket.Id.ToString() + " ...");

                log.Info("Eliminando marca al usuario " + ticket.Usuario + " ...");

                if (ActiveDirectoryHelper.EliminarPrefijoDescripcionUsuario(ticket.Usuario, Settings.Default.PrefijoDescripcionUsuarioRed, Settings.Default.LDAPPath, Settings.Default.FiltroBuscarNombreLDAP))
                {
                    log.Info("Marca eliminada correctamente");

                    log.Info("Seteando fecha de eliminación de marca...");

                    ticket.FechaEliminacionMarcaAD = DateTime.Now;

                    tncb.Save(ticket);

                    log.Info("Fecha de eliminación de marca seteada correctamente");
                }
                else
                    log.Info("No se pudo eliminar la marca");

                log.Info("Procesado de ticket finalizado");
            }

            log.Info("Fin de eliminación de marcas en AD...");
        }
    }
}
