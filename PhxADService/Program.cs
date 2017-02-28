using System;
using NDCBL;
using NDCCommon.Entities;
using PhalanxNAL;
using PhxADService.Properties;
using log4net;
using Classworx.Common.Trace;

namespace PhxADService
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            TraceHelper.Information("Comienzo ejecución servicio...");

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
                TraceHelper.Error("Error al ejecutar el servicio", ex);
            }

            TraceHelper.Information("Fin ejecución servicio.");
        }

        private static bool InicializarDB()
        {
            TraceHelper.Information("Inicializando base de datos...");

            PhalanxDAL.DBMgr.Application = PhalanxCommon.Entities.App.NotificacionClaves;
            PhalanxDAL.DBMgr.NHAssembly = System.Reflection.Assembly.Load("NDCDAL");
            
            if (PhalanxDAL.DBMgr.Inicializar())
            {
                TraceHelper.Information("Base de datos inicializada correctamente");

                return true;
            }
            else
                TraceHelper.Information("Error al inicializar la Base de datos");

            return false;
        }

        private static void AgregarMarcaAD()
        {
            TraceHelper.Information("Comienzo agregado de marcas en AD...");

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            foreach (TicketNotificacionClaveEntity ticket in tncb.ObtenerTodosAgregarMarcaAD())
            {
                TraceHelper.Information("Procesando ticket Id = " + ticket.Id.ToString() + " ...");

                TraceHelper.Information("Agregando marca al usuario " + ticket.Usuario + " ...");

                if (ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(ticket.Usuario, Settings.Default.PrefijoDescripcionUsuarioRed, Settings.Default.LDAPPath, Settings.Default.FiltroBuscarNombreLDAP))
                {
                    TraceHelper.Information("Marca agregada correctamente");

                    TraceHelper.Information("Seteando fecha de agregado de marca...");

                    ticket.FechaSeteoMarcaAD = DateTime.Now;

                    tncb.Save(ticket);

                    TraceHelper.Information("Fecha de agregado de marca seteada correctamente");
                }
                else
                    TraceHelper.Information("No se pudo agregar la marca");

                TraceHelper.Information("Procesado de ticket finalizado");
            }

            TraceHelper.Information("Fin agregado de marcas en AD");
        }

        private static void QuitarMarcaAD()
        {
            TraceHelper.Information("Comienzo eliminación de marcas en AD...");

            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            foreach (TicketNotificacionClaveEntity ticket in tncb.ObtenerTodosQuitarMarcaAD())
            {
                TraceHelper.Information("Procesando ticket Id = " + ticket.Id.ToString() + " ...");

                TraceHelper.Information("Eliminando marca al usuario " + ticket.Usuario + " ...");

                if (ActiveDirectoryHelper.EliminarPrefijoDescripcionUsuario(ticket.Usuario, Settings.Default.PrefijoDescripcionUsuarioRed, Settings.Default.LDAPPath, Settings.Default.FiltroBuscarNombreLDAP))
                {
                    TraceHelper.Information("Marca eliminada correctamente");

                    TraceHelper.Information("Seteando fecha de eliminación de marca...");

                    ticket.FechaEliminacionMarcaAD = DateTime.Now;

                    tncb.Save(ticket);

                    TraceHelper.Information("Fecha de eliminación de marca seteada correctamente");
                }
                else
                    TraceHelper.Information("No se pudo eliminar la marca");

                TraceHelper.Information("Procesado de ticket finalizado");
            }

            TraceHelper.Information("Fin de eliminación de marcas en AD...");
        }
    }
}
