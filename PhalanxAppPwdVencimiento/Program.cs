using System;
using System.Collections.Generic;
using System.Text;
using PhalanxBL;
using System.Collections;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;



namespace PhalanxAppPwdVencimiento
{
    class Program
    {

        static int Main(string[] args) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Iniciando el proceso");

            string sEMail = string.Empty;
            string sFolio = string.Empty;
            string sAplicativo = string.Empty;
            string sUsuario = string.Empty;

            int vFolio;
            int vCantVenc;
            int errores_det = 0;

            ApplicationUserBusiness DBUsrBL = new ApplicationUserBusiness();

            VencPwdAppLogBusiness logBL = new VencPwdAppLogBusiness();

            Console.WriteLine("Obteniendo los próximos Vencimientos de Clave de Aplicativos ...");
            MailAlertBusiness maBL = new MailAlertBusiness();
            IList vencimientos;

            //Obtengo los proximos vencimientos de clave de aplicativos
            try
            {
                vencimientos = DBUsrBL.GetProxVencimientos();

            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al obtener vencimientos. Error interno: {0}", ex.ToString());

                Console.WriteLine(mensaje);
                LogError(mensaje);

                System.Threading.Thread.Sleep(3000);
                return -1;
            }

            //Console.WriteLine("Depurando Historicos ...");
            //logBL.Depurar();
            
            Console.WriteLine("Procesando vencimientos ...");

            VencPwdAppLogDetEntityCollection vpaldC = new VencPwdAppLogDetEntityCollection();

            try
            {
                //Recorro vencimientos y envio de mail
                int i = 0;
                foreach (object[] AppUsrEnt in vencimientos)
                {

                    try
                    {

                        ApplicationUserBusiness usrBL = new ApplicationUserBusiness();
                        ApplicationUserEntity auE = new ApplicationUserEntity();


                        sFolio = string.Empty;
                        sAplicativo = string.Empty;
                        sUsuario = string.Empty;

                        sFolio = AppUsrEnt[0].ToString();
                        sAplicativo = AppUsrEnt[1].ToString();
                        sUsuario = AppUsrEnt[2].ToString();

                        vFolio = Int32.Parse(AppUsrEnt[0].ToString());
                        vCantVenc = Int32.Parse(AppUsrEnt[3].ToString());

                        auE = usrBL.GetById(vFolio);

                        maBL.CreateVencPwdAppMail(auE, vCantVenc);

                        VencPwdAppLogDetEntity logdet = new VencPwdAppLogDetEntity();

                        //Logueo detalle de resultado
                        logdet.Folio = vFolio;
                        logdet.Aplicativo = sAplicativo;
                        logdet.UsuarioApp = sUsuario;
                        logdet.EmailUsrSeg = sEMail;
                        logdet.DiasRestantes = vCantVenc;
                        logdet.FechaEjecucion = DateTime.Now;
                        logdet.Resultado = "Ok";
                        vpaldC.Add(logdet);

                    }
                    catch (Exception ex)
                    {
                        string mensaje = string.Format("Error al procesar vencimiento. Folio: {0}, Error interno: {1}", sFolio, ex.ToString());

                        Console.WriteLine(mensaje);
                        if (LogDetError(mensaje, sFolio) < 0)
                            return -1;
                        errores_det++;

                    }


                    i++;
                }
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al procesar vencimientos. Error interno: {0}", ex.ToString());

                Console.WriteLine(mensaje);
                LogError(mensaje);

                System.Threading.Thread.Sleep(3000);
                return -1;
            }


            //Logueo el resultado final
            VencPwdAppLogEntity log = new VencPwdAppLogEntity();
            try
            {
                log.CantidadVencimientos = vencimientos.Count;
                log.FechaEjecucion = DateTime.Now;
                log.Usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                if (errores_det > 0)
                {
                    log.Observaciones = "Existen avisos de vencimiento con error. Revisar detalle de Log.";
                    log.Resultado = "Warning";
                }
                else
                {
                    log.Observaciones = string.Empty;
                    log.Resultado = "Ok";
                }

                logBL.Save(log);
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al guardar log. Error interno: {0}", ex.ToString());

                Console.WriteLine(mensaje);
                LogError(mensaje);

                System.Threading.Thread.Sleep(3000);
                return -1;
            }

            try
            {
                VencPwdAppLogDetBusiness logdetBL = new VencPwdAppLogDetBusiness();
                foreach (VencPwdAppLogDetEntity entity in vpaldC)
                {
                    entity.Ejecucion = log;
                    logdetBL.Save(entity);
                }
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al guardar detalle de log. Error interno: {0}", ex.ToString());

                Console.WriteLine(mensaje);
                LogError(mensaje);

                System.Threading.Thread.Sleep(3000);
                return -1;
            }

            Console.WriteLine("Ejecución finalizada correctamente");

            System.Threading.Thread.Sleep(3000);
            //Console.Clear();

            var borde = '*';
            var titulo = borde + "---------Resultados de la ejecución----------------" + borde;
            var widthResult = titulo.Length - 1;
            Console.WriteLine(titulo);
            Console.WriteLine(string.Format(borde + " Ejecutado por {0}.", log.Usuario).PadRight(widthResult, ' ') + borde);
            Console.WriteLine(string.Format(borde + " Cantidad de avisos de vencimiento enviados {0}.", log.CantidadVencimientos).PadRight(widthResult, ' ') + borde);
            Console.WriteLine("".PadRight(widthResult + 1, borde));

            return 0;
        }

        private static void LogError(string msj)
        {
            VencPwdAppLogBusiness logBL = new VencPwdAppLogBusiness();
            VencPwdAppLogEntity log = new VencPwdAppLogEntity();
            try
            {
                log.FechaEjecucion = DateTime.Now;
                log.Usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                log.Resultado = "Error";
                log.Observaciones = msj;
                logBL.Save(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado:", ex.Message);
                System.Threading.Thread.Sleep(3000);
            }

        }

        private static int LogDetError(string msj, string sFolio)
        {
            VencPwdAppLogDetBusiness logdetBL = new VencPwdAppLogDetBusiness();
            VencPwdAppLogDetEntity logdet = new VencPwdAppLogDetEntity();

            try
            {
                logdet.Folio = Int32.Parse(sFolio);
            }
            catch (Exception ex)
            {
            }

            try
            {
                logdet.FechaEjecucion = DateTime.Now;
                logdet.Resultado = "Error";
                logdet.Observaciones = msj;
                logdetBL.Save(logdet);
                return 0;
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Error al guardar detalle de log con error. Error interno: {0}", ex.Message);

                Console.WriteLine(mensaje);
                LogError(mensaje);

                System.Threading.Thread.Sleep(3000);
                return -1;
            }

        }
    
    }
}
