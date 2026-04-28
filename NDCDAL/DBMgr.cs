using System;
using System.Data;
using System.Configuration;
using NHibernate;
using System.Collections;
using System.Reflection;
using Common;

namespace NDCDAL
{
    /*
    /// <summary>
    /// Summary description for DBMgr
    /// </summary>
    public class DBMgr
    {
        static NHibernate.Cfg.Configuration config;
        static public ISessionFactory factory;


        public static void Inicializar()
        {
            try
            {
                config = new NHibernate.Cfg.Configuration();
                IDictionary props = new Hashtable();

                props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
                props["hibernate.dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
                props["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";

                string strLogLevel; // = PhxIni.IniReadValue("Log", "DAL");

                string ConnName = "NDC";

                string strConn = GetConnString(ConnName); // PhxIni.IniReadValue("Config", "connection_string");

                if (strConn == "")
                {
                    throw (new CwxException("No se encontró cadena de conexión", "DBMgr"));

                }

                props["hibernate.connection.connection_string"] = strConn;

                foreach (DictionaryEntry de in props)
                {
                    config.SetProperty(de.Key.ToString(), de.Value.ToString());
                }

                //Assembly nhAssembly = typeof(DBMgr).Assembly;

                Assembly nhAssembly = Assembly.Load("NDCDAL");

                config.AddAssembly(nhAssembly);

                //config.AddFile(HttpContext.Current.Server.MapPath("~\\App_Code\\MappingFiles\\ApplicationEntity.hbm.xml"));

                //config.AddResource("MappingFiles.ApplicationEntity.hbm.xml", nhAssembly);
                //config.AddResource("MappingFiles.BPMSolicitudEntity.hbm.xml", nhAssembly);

                factory = config.BuildSessionFactory();
                //session = factory.OpenSession();
            }
            catch (Exception e)
            {
                throw;
                //string InnerEx = e.InnerException.ToString();
            }
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
     * */
}