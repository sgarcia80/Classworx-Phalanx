using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using PhalanxBL;
using System.Configuration;

namespace PhxSvcExpirationManager
{

    public partial class PhxSvcExpirationMgr : ServiceBase
    {
        // This is a flag to indicate the service status
        private bool serviceStarted = false;

        // the thread that will do the work
        Thread workerThread;

        public PhxSvcExpirationMgr()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Create worker thread; this will invoke the WorkerFunction
            // when we start it.
            // Since we use a separate worker thread, the main service
            // thread will return quickly, telling Windows that service has started
            ThreadStart st = new ThreadStart(WorkerFunction);
            workerThread = new Thread(st);

            // set flag to indicate worker thread is active
            serviceStarted = true;

            // start the thread
            workerThread.Start();
        }

        protected override void OnStop()
        {
            // flag to tell the worker process to stop
            serviceStarted = false;
            int SrvcIntMins = 10;
            if (ConfigurationManager.AppSettings["ServiceIntervalMins"] != null)
            {
                try
                {
                    SrvcIntMins = Convert.ToInt32(ConfigurationManager.AppSettings["ServiceIntervalMins"].ToString());
                }
                catch
                {
                }
            }

            // give it a little time to finish any pending work
            workerThread.Join(new TimeSpan(0, 10, 0));
        }
        /// <summary>
        /// This function will do all the work
        /// Once it is done with its tasks, it will be suspended for some time;
        /// it will continue to repeat this until the service is stopped
        /// </summary>
        private void WorkerFunction()
        {
            // start an endless loop; loop will abort only when "serviceStarted"
            // flag = false
            while (serviceStarted)
            {
                try
                {
                    if (ConfigurationManager.AppSettings["LogEventViewer"] != null &&
                        ConfigurationManager.AppSettings["LogEventViewer"] == "1")
                    {

                        EventLog evt = new EventLog("PhxExpiratonManager");

                        string message = "Phalanx Time:"

                          + DateTime.Now.ToShortDateString() + " "

                          + DateTime.Now.ToShortTimeString();

                        evt.Source = "PhxSvcExpirationManager";

                        evt.WriteEntry(message, EventLogEntryType.Information);
                    }
                    PhxContingenciaBusiness phxContB = new PhxContingenciaBusiness();
                    if (phxContB.VerificaSiConexionUsadaEstaActiva())
                    {

                        // busca los requests expirados y los setea en estado expirado
                        PasswordRequestBusiness PRBL = new PasswordRequestBusiness();
                        PRBL.ProcessPwdRqstExpiration();
                    }

                    // yield
                    if (serviceStarted)
                    {
                        Thread.Sleep(new TimeSpan(0, 0, 40));
                    }
                }
                catch (Exception ex)
                {
                    EventLog evt = new EventLog("PhxExpiratonManager");

                    string message = "ERROR! | " + ex.Message + " | " + "  Phalanx Time:"

                      + DateTime.Now.ToShortDateString() + " "

                      + DateTime.Now.ToShortTimeString();

                    evt.Source = "PhxSvcExpirationManager";

                    evt.WriteEntry(message, EventLogEntryType.Information);
                }
               
            }

            // time to end the thread
            Thread.CurrentThread.Abort();
        }
    }
}
