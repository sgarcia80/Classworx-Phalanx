using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using System.Text;

namespace PhxSvcExpirationManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static int Main(string[] args)
        {
            Console.WriteLine("Se ejecuta el servicio");

            if (System.Environment.UserInteractive)
            {
                Console.WriteLine("Consola interactiva");

                // we only care about the first two characters
                string arg = args[0].ToLowerInvariant().Substring(0, 2);

                Console.WriteLine("Se analiza el parametro recibido");

                switch (arg)
                {
                    case "/i":  // install
                        return InstallService();

                    case "/u":  // uninstall
                        return UninstallService();

                    default:  // unknown option
                        Console.WriteLine("Argument not recognized: {0}", args[0]);
                        Console.WriteLine(string.Empty);
                        //DisplayUsage();
                        return 1;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;

                // More than one user Service may run within the same process. To add
                // another service to this process, change the following line to
                // create a second service object. For example,
                //
                //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
                //
                ServicesToRun = new ServiceBase[] { new PhxSvcExpirationMgr() };

                ServiceBase.Run(ServicesToRun);
            }

            return 0;
        }

        private static int InstallService()
        {
            var service = new PhxSvcExpirationMgr();

            try
            {
                Console.WriteLine("Se instala el servicio");
                // perform specific install steps for our queue service.
                //service.InstallService();

                // install the service with the Windows Service Control Manager (SCM)
                ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });

                Console.WriteLine("Servicio instalado correctamente");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(Win32Exception))
                {
                    Win32Exception wex = (Win32Exception)ex.InnerException;
                    Console.WriteLine("Error(0x{0:X}): Service already installed!", wex.ErrorCode);
                    return wex.ErrorCode;
                }
                else
                {
                    Console.WriteLine(ex.ToString());
                    return -1;
                }
            }

            return 0;
        }

        private static int UninstallService()
        {
            var service = new PhxSvcExpirationMgr();

            try
            {
                Console.WriteLine("Se desinstala el servicio");
                // perform specific uninstall steps for our queue service
                //service.UninstallService();

                // uninstall the service from the Windows Service Control Manager (SCM)
                ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });

                Console.WriteLine("Servicio desinstalado correctamente");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(Win32Exception))
                {
                    Win32Exception wex = (Win32Exception)ex.InnerException;
                    Console.WriteLine("Error(0x{0:X}): Service not installed!", wex.ErrorCode);
                    return wex.ErrorCode;
                }
                else
                {
                    Console.WriteLine(ex.ToString());
                    return -1;
                }
            }

            return 0;
        }

        private static AssemblyInstaller GetInstaller()
        {
            AssemblyInstaller installer = new AssemblyInstaller(
                typeof(PhxSvcExpirationMgr).Assembly, null);
            installer.UseNewContext = true;
            return installer;
        }

        private static int Install()
        {
            try
            {
                Console.WriteLine("Se instala el servicio");

                using (AssemblyInstaller installer = GetInstaller())
                {
                    IDictionary state = new Hashtable();
                    try
                    {
                        installer.Install(state);
                        installer.Commit(state);

                        Console.WriteLine("Servicio instalado correctamente");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        try
                        {
                            installer.Rollback(state);
                        }
                        catch { }
                        //throw;
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
                return -1;
            }

            return 0;
        }

        private static int Uninstall()
        {
            try
            {
                Console.WriteLine("Se desinstala el servicio");

                using (AssemblyInstaller installer = GetInstaller())
                {
                    IDictionary state = new Hashtable();
                    try
                    {
                        installer.Uninstall(state);

                        Console.WriteLine("Servicio desinstalado correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //throw;
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
                return -1;
            }

            return 0;
        }

    }
}