using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;
using phxLog;
using System.Configuration;
using PhalanxCommon;
using PhalanxCommon.Entities;


namespace PhalanxDAL
{
    /// <summary>
    /// Summary description for DBMgr.
    /// </summary>
    public class DBMgr
    {
        static NHibernate.Cfg.Configuration config;
        static private ISessionFactory _factory;
        static private ISessionFactory _factoryMeta4;
        static public CLogger DBLog;
        //static public ISession session;
        static bool _AmbienteActualProduccion = true;
        //static bool _SistemaDeContingenciaActivo = false;
        private static App application = App.Phalanx;
        private static Assembly assembly;

        public static App Application { set { application = value; } }
        public static Assembly NHAssembly { set { assembly = value; } }
         
        static DBMgr()
        {
            string strLogLevel; // = PhxIni.IniReadValue("Log", "DAL");
            strLogLevel = ConfigurationManager.AppSettings["LogLevel"];
            if (strLogLevel == "")
            {
                DBLog = new CLogger();
            }
            else
            {
                uint uiLogLevel;
                try
                {
                    uiLogLevel = Convert.ToUInt32(strLogLevel);
                    DBLog = new CLogger(uiLogLevel);
                }
                catch
                {
                    DBLog = new CLogger();
                }

            } 
        }

        public static ISessionFactory factory
        {
            get
            {
                if (_factory == null)
                    Inicializar();

                return _factory;
            }

        }

        public static ISessionFactory factoryMeta4
        {
            get {

                /*if (_factoryMeta4 == null)
                    InicializarMeta4();*/
                
                return _factoryMeta4; 
            
            
            }
        }

        public static bool Inicializar()
        {
            try
            {
                config = new NHibernate.Cfg.Configuration();
                IDictionary props = new Hashtable();

                props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
                props["hibernate.dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
                props["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
                //props["hibernate.connection.connection_string"] = "Server=localhost;initial catalog=Northwind;Integrated Security=SSPI" ;
                //string AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );

                //PhxIni = new IniFile(".\\phalanx.ini");
                //string strConn = PhxIni.IniReadValue("Config","connection_string");
                //if (strConn == "")
                //{

                //IniFile PhxIni = new IniFile("c:\\classworx\\phalanx\\inis\\phalanx.ini");
                
                string ConnName = application == App.NotificacionClaves ? "NDC" : "Phalanx";
                //if (ConfigurationManager.AppSettings["ContingenciaActivado"] != null && ConfigurationManager.AppSettings["ContingenciaActivado"] == "1")
                {
                    if (ConfigurationManager.AppSettings["UsaProduccion"].ToString() == "0")
                    {
                        _AmbienteActualProduccion = false;
                        ConnName = application == App.NotificacionClaves ? "NDCCont" : "PhalanxCont";
                    }
                } 
                    
                string strConn = GetConnString(ConnName); // PhxIni.IniReadValue("Config", "connection_string");

                if (strConn == "")
                {
                    throw (new CwxException("No se encontró cadena de conexión", "DBMgr"));
                    //strConn = "initial catalog=phalanx;User ID=sa;pwd=cwxcwx;Data Source=cwxsrv001";
                }

                DBLog.LogFilePath = ConfigurationManager.AppSettings["LogFilePath"]; //"c:\\classworx\\phalanx\\logs\\phxLog.txt";


                //string strConn = GetConnString();
                //}
                DBLog.registerLog(CLogger.TYPE_INFORMATION, 1, 0, "DBMgr.DBMgr()", "Cadena de conexión: " + strConn, true, false);
                props["hibernate.connection.connection_string"] = strConn;
                foreach (DictionaryEntry de in props)
                {
                    config.SetProperty(de.Key.ToString(), de.Value.ToString());
                }

                Assembly nhAssembly = Assembly.Load("PhalanxDAL");

                config.AddResource("PhalanxDAL.MappingFiles.EventoLogin.hbm.xml", nhAssembly);
                config.AddResource("PhalanxDAL.MappingFiles.AuditLogin.hbm.xml", nhAssembly);
                config.AddResource("PhalanxDAL.MappingFiles.MailAlert.hbm.xml", nhAssembly);
                config.AddResource("PhalanxDAL.MappingFiles.MailType.hbm.xml", nhAssembly);
                config.AddResource("PhalanxDAL.MappingFiles.PhxConfig.hbm.xml", nhAssembly);
                config.AddResource("PhalanxDAL.MappingFiles.VwDate.hbm.xml", nhAssembly);

                if (assembly != null)
                {
                    nhAssembly = assembly;
                }

                switch (application)
                {
                    case App.Phalanx:
                        //config.AddAssembly("PhalanxDAL");
                        //config.AddClass(typeof(Users));
                        //config.AddAssembly(nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.UserTypes.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PwdLockTypes.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.Users.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.WinPCs.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.WinDomains.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.WinDomainControllers.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.WinGroups.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.UsersPasswords.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxUsersGroups.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.RequestStates.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.RequestsGroups.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.RqstGrpsDeleg.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.Requests.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.RqstGrpsPwds.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxUsers.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxRoles.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxRolesUsers.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwPhxUsersRqstPwdGroups.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwPhxUsersRqstDelGroups.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwInventario.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.Applications.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.DatabaseTypes.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.DataBases.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.Unix.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AS400.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.HistChangePassword.hbm.xml", nhAssembly);
                        //config.AddResource("PhalanxDAL.MappingFiles.PhxLog.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.DemoConf.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwHistPwdChg.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxUserSuperior.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AuditPhxUser.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AuditUsuarios.hbm.xml", nhAssembly);
                        //config.AddResource("PhalanxDAL.MappingFiles.EventoLogin.hbm.xml", nhAssembly);
                        //config.AddResource("PhalanxDAL.MappingFiles.AuditLogin.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AuditPermisos.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxPrivilegeGroup.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxPrivilege.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxPrivilegeRole.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AuditPhxRole.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AuditPhxPrivilegeRole.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwPerfilUsuario.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.VwPermisoPerfil.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.FollowupRequestGroup.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.FollowupRequestGroupPassword.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.FollowupRequestGroupUser.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.FollowupRequestGroupDefault.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxVersion.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.PhxContingencia.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.LoteChkWinLocalUsers.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.ItemLoteChkWinLocalUsers.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.AccionItemChkWinLocalUser.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.vwCantFollowRqstGrpPwd.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.vwCantRqstGrpPwd.hbm.xml", nhAssembly);

                        //config.AddResource("PhalanxDAL.MappingFiles.", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.Building.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.CommunicationDeviceTypes.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.CommunicationDeviceProtocols.hbm.xml", nhAssembly);
                        config.AddResource("PhalanxDAL.MappingFiles.CommunicationDevices.hbm.xml", nhAssembly);
                        try
                        {
                            nhAssembly = Assembly.Load("NDCDAL");
                            config.AddAssembly(nhAssembly);
                        }
                        catch
                        { }

                         
                        break;
                    case App.NotificacionClaves:
                        config.AddResource("NDCDAL.MappingFiles.AplicacionNotificacionClaveEntity.hbm.xml", nhAssembly);
                        config.AddResource("NDCDAL.MappingFiles.TicketNotificacionClaveEntity.hbm.xml", nhAssembly);
                        config.AddResource("NDCDAL.MappingFiles.AuditTicketNotificacionEntity.hbm.xml", nhAssembly);
                        config.AddResource("NDCDAL.MappingFiles.SubsidiariaEntity.hbm.xml", nhAssembly);
                        //config.AddAssembly(nhAssembly);
                        InicializarMeta4();
                        break;
                }

                _factory = config.BuildSessionFactory();
                //session = factory.OpenSession();

                return true;
            }
            catch (Exception e)
            {
                return false;
                //string InnerEx = e.InnerException.ToString();
            }
        }

        public static bool InicializarMeta4()
        {
            try
            {
                NHibernate.Cfg.Configuration configMeta4 = new NHibernate.Cfg.Configuration();
                IDictionary props = new Hashtable();

                props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
                props["hibernate.dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
                props["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
                
                string ConnName = "Meta4";
                
                if (ConfigurationManager.AppSettings["UsaProduccion"].ToString() == "0")
                {
                    _AmbienteActualProduccion = false;
                    ConnName = "Meta4Cont";
                }
                 
                string strConn = GetConnString(ConnName);

                if (strConn == "")
                {
                    throw (new CwxException("No se encontró cadena de conexión", "DBMgr"));
                }

                DBLog.registerLog(CLogger.TYPE_INFORMATION, 1, 0, "DBMgr.DBMgr()", "Cadena de conexión: " + strConn, true, false);
                
                props["hibernate.connection.connection_string"] = strConn;
                
                foreach (DictionaryEntry de in props)
                    configMeta4.SetProperty(de.Key.ToString(), de.Value.ToString());

                Assembly nhAssembly = Assembly.Load("NDCDAL");

                configMeta4.AddResource("NDCDAL.MappingFiles.Meta4ClassWorxUsuariosEntity.hbm.xml", nhAssembly);
                configMeta4.AddResource("NDCDAL.MappingFiles.Meta4LegajoEntity.hbm.xml", nhAssembly);
                configMeta4.AddResource("NDCDAL.MappingFiles.Meta4SociedadEntity.hbm.xml", nhAssembly);

                _factoryMeta4 = configMeta4.BuildSessionFactory();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        static public bool EsAmbienteActualProduccion
        {
            get { return _AmbienteActualProduccion; }
        }
        //static public bool UsaContingencia
        //{
        //    get { return _SistemaDeContingenciaActivo; }
        //}

        void DBMgr2()
        {
            /*try
            {*/
            config = new NHibernate.Cfg.Configuration();
            IDictionary props = new Hashtable();

            props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
            props["hibernate.dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
            props["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
            //props["hibernate.connection.connection_string"] = "Server=localhost;initial catalog=Northwind;Integrated Security=SSPI" ;
            //string AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );

            //PhxIni = new IniFile(".\\phalanx.ini");
            //string strConn = PhxIni.IniReadValue("Config","connection_string");
            //if (strConn == "")
            //{

            IniFile PhxIni = new IniFile("c:\\classworx\\phalanx\\inis\\phalanx.ini");
            string strLogLevel = PhxIni.IniReadValue("Log", "DAL");
            if (strLogLevel == "")
            {
                DBLog = new CLogger();
            }
            else
            {
                uint uiLogLevel;
                try
                {
                    uiLogLevel = Convert.ToUInt32(strLogLevel);
                    DBLog = new CLogger(uiLogLevel);
                }
                catch
                {
                    DBLog = new CLogger();
                }

            }
            DBLog.LogFilePath = "c:\\classworx\\phalanx\\logs\\phxLog.txt";

            string ConnName = "Phalanx";
            //if (ConfigurationManager.AppSettings["ContingenciaActivado"] != null && ConfigurationManager.AppSettings["ContingenciaActivado"] == "1")
            {
                if (ConfigurationManager.AppSettings["UsaProduccion"].ToString() == "0")
                {
                    _AmbienteActualProduccion = false;
                    ConnName = "PhalanxCont";
                }
            }

            string strConn = GetConnString(ConnName); //PhxIni.IniReadValue("Config", "connection_string");
            if (strConn == "")
            {

                strConn = "initial catalog=phalanx;User ID=sa;pwd=cwxcwx;Data Source=cwxsrv001";

            }
            //}
            DBLog.registerLog(CLogger.TYPE_INFORMATION, 1, 0, "DBMgr.DBMgr()", "Cadena de conexión: " + strConn, true, false);
            props["hibernate.connection.connection_string"] = strConn;


            foreach (DictionaryEntry de in props)
            {
                config.SetProperty(de.Key.ToString(), de.Value.ToString());
            }

            //config.AddAssembly("PhalanxDAL");
            //config.AddClass(typeof(Users));
            Assembly nhAssembly = Assembly.Load("PhalanxDAL");
            //config.AddAssembly(nhAssembly); 
            config.AddResource("PhalanxDAL.BLL.UserTypes.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PwdLockTypes.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.Users.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.WinPCs.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.WinDomains.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.WinDomainControllers.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.WinGroups.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.UsersPasswords.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PhxUsersGroups.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.RequestStates.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.RequestsGroups.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.RqstGrpsDeleg.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.Requests.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.RqstGrpsPwds.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PhxUsers.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PhxRoles.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PhxRolesUsers.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.VwPhxUsersRqstPwdGroups.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.VwPhxUsersRqstDelGroups.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.PhxLog.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.DemoConf.hbm.xml", nhAssembly);
            config.AddResource("PhalanxDAL.BLL.RequestsNotes.hbm.xml", nhAssembly);


            _factory = config.BuildSessionFactory();
            //session = factory.OpenSession();
            /*}
            catch
            {
            }*/
        }
        internal static void ChangeToAlternateConnection()
        {
            string ConnName = "PhalanxCont";
            if (_AmbienteActualProduccion)
            {
                _AmbienteActualProduccion = false;
            }
            else
            {
                _AmbienteActualProduccion = true;
                ConnName = "Phalanx";
            }

            string strConn = GetConnString(ConnName); // PhxIni.IniReadValue("Config", "connection_string");

            if (strConn == "")
            {
                throw (new CwxException("No se encontró cadena de conexión", "DBMgr"));
                //strConn = "initial catalog=phalanx;User ID=sa;pwd=cwxcwx;Data Source=cwxsrv001";
            }

            config.Properties["hibernate.connection.connection_string"] = strConn;
            _factory = config.BuildSessionFactory();


        }
        private static string GetConnString()
        {
            // Get the application configuration file.
            /*System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);*/

            // Get the conectionStrings section.
            //ConnectionStringsSection csSection = _config.ConnectionStrings;
            for (int i = 0; i <
                ConfigurationManager.ConnectionStrings.Count; i++)
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[i];
                //csSection.ConnectionStrings[i];

                if (cs.Name == "Phalanx")
                {
                    return (new phxCryptMgr.CCryptMgr()).decryptConfigFileAndClearBadChars(cs.ConnectionString);
                }

            }
            return string.Empty;

        }
        private static string GetConnString(string ConnName)
        { 
            // Get the conectionStrings section.
            //ConnectionStringsSection csSection = _config.ConnectionStrings;
            for (int i = 0; i <
                ConfigurationManager.ConnectionStrings.Count; i++)
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[i];
                //csSection.ConnectionStrings[i];

                if (cs.Name == ConnName)
                {
                    return (new phxCryptMgr.CCryptMgr()).decryptConfigFileAndClearBadChars(cs.ConnectionString);
                }

            }
            return string.Empty;

        }

        public static void SetConnString(string conn)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(".\\PhalanxAdmin.exe.config");            
            //Looping through all nodes.            
            foreach (System.Xml.XmlNode node in doc.ChildNodes.Item(1))            
            {
                if (node.LocalName == "connectionStrings")               
                {
                    node.ChildNodes.Item(0).Attributes[2].Value = (new phxCryptMgr.CCryptMgr()).encryptConfigFile(conn);                   
                }            
            }//Saving the Updated values in App.config File.Here updating the config //file in the same path.            
            doc.Save(".\\PhalanxAdmin.exe.config");      
        }

        

        /// <summary>
        /// Make sure we clean up session etc.
        /// </summary>
        public void Dispose()
        {
            //session.Dispose();
            factory.Close();
        }


        
    }
}
