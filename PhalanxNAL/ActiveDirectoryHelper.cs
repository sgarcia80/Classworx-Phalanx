using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.DirectoryServices;

namespace PhalanxNAL
{
    public class ActiveDirectoryHelper
    {
        private static Dictionary<string, object> settings = new Dictionary<string, object>();

        private static string LDAPPath
        {
            get
            {
                return BuscarSetting<string>("LDAPPath");
            }
        }

        private static string LDAPBuscarNombreFilter
        {
            get
            {
                return BuscarSetting<string>("LDAPBuscarNombreFilter");
            }
        }

        private static T BuscarSetting<T>(string nombre)
        {
            if (!settings.ContainsKey(nombre))
                settings.Add(nombre, Convert.ChangeType(ConfigurationManager.AppSettings[nombre], typeof(T)));

            return (T)settings[nombre];
        }

        public static DirectoryEntry BuscarUsuarioPorNombre(string username)
        {
            return BuscarUsuarioPorNombre(LDAPPath, username, new string[] { "description" });
        }

        public static DirectoryEntry BuscarUsuarioPorNombre(string path, string username, IEnumerable<string> propiedades)
        {
            return BuscarLDAPEntry(path, LDAPBuscarNombreFilter.Replace("[username]", username), propiedades);
        }

        public static DomainUser BuscarUsuarioADPorNombre(string path, string username)
        {
            DomainUser Usuario = new DomainUser();
            Usuario.Username = username;
            if (path.ToLower().StartsWith("winnt"))
            {
                path = "WinNT" + path.Substring(5);
                Usuario.LDAPPath = path;

                DirectoryEntry obDirEntry = new DirectoryEntry(path + "/" + username + ",user");
                // falta controlar si encuentra al usuario
                try
                {
                    if (obDirEntry.Properties.Count > 0)
                    {
                        foreach (System.DirectoryServices.PropertyValueCollection strVal in obDirEntry.Properties)
                        {
                        }
                        Usuario.Found = true;
                    }
                }
                catch
                {

                }
            }
            else
            {
                IEnumerable<string> propiedades = new string[] { "givenName", "sn", "streetAddress", "mail", "department", "physicalDeliveryOfficeName" };
                string filter = LDAPBuscarNombreFilter.Replace("[username]", username);
                IEnumerable<string> properties = propiedades;
                Usuario.Username = username;
                Usuario.LDAPPath = path;
                try
                {
                    Usuario.Log += "|filter:" + filter + "|";
                    Usuario.Log += "|path:" + path + "|";

                    DirectoryEntry directoryEntry = new DirectoryEntry(path);
                    Usuario.Log += "|directoryEntry|";

                    DirectorySearcher search = new DirectorySearcher(directoryEntry);

                    Usuario.Log += "|filter:" + filter + "|";
                    search.Filter = filter;

                    foreach (string property in properties)
                    {
                        Usuario.Log += "|Load:" + property + "|";

                        search.PropertiesToLoad.Add(property);
                    }

                    Usuario.Log += "|foreach|";
                    //Usuario.Log += "|search.FindOne|";
                    //SearchResult sr = search.FindOne();
                    foreach (SearchResult sr in search.FindAll())
                    {
                        Usuario.Found = true;
                        Usuario.Log += "|givenName|";
                        if (sr.Properties["givenName"] != null && sr.Properties["givenName"].Count > 0)
                            Usuario.Name = sr.Properties["givenName"][0].ToString();

                        if (sr.Properties["sn"] != null && sr.Properties["sn"].Count > 0)
                        {
                            Usuario.Log += "|sn|";
                            Usuario.Surname = sr.Properties["sn"][0].ToString();
                        }

                        if (sr.Properties["mail"] != null && sr.Properties["mail"].Count > 0)
                        {
                            Usuario.Log += "|mail|";
                            Usuario.email = sr.Properties["mail"][0].ToString();
                        }

                        if (sr.Properties["streetAddress"] != null && sr.Properties["streetAddress"].Count > 0)
                        {
                            Usuario.Log += "|streetAddress|";
                            Usuario.Address = sr.Properties["streetAddress"][0].ToString();
                        }

                        if (sr.Properties["department"] != null && sr.Properties["department"].Count > 0)
                        {
                            Usuario.Log += "|department|";
                            Usuario.Office = sr.Properties["department"][0].ToString() + " ";
                        }

                        if (sr.Properties["physicalDeliveryOfficeName"] != null && sr.Properties["physicalDeliveryOfficeName"].Count > 0)
                        {
                            Usuario.Log += "|physicalDeliveryOfficeName|";
                            Usuario.Office += sr.Properties["physicalDeliveryOfficeName"][0].ToString();
                        }
                        break;
                    }
                    /*
                    Usuario.Log += "|sr.GetDirectoryEntry|";
                    DirectoryEntry FoundUser = sr.GetDirectoryEntry();
                    Usuario.Log += "|givenName|";
                    Usuario.Name = FoundUser.Properties["givenName"].Value.ToString();
                    Usuario.Log += "|sn|";
                    Usuario.Surname = FoundUser.Properties["sn"].Value.ToString();
                    Usuario.Log += "|mail|";
                    Usuario.email = FoundUser.Properties["mail"].Value.ToString();
                    Usuario.Log += "|streetAddress|";
                    Usuario.Address = FoundUser.Properties["streetAddress"].Value.ToString();
                    */
                }
                catch (Exception ex)
                {
                    Usuario.Log += ex.Message;
                    Usuario.Exception = true;
                }
            }
            return Usuario;
        }
        public static bool LDAPPathExists(string LDAPPathToCheck)
        {
            try
            {
                return (DirectoryEntry.Exists(LDAPPathToCheck));
            }
            catch
            {
                return false;
            }
        }
        public static bool UsuarioExiste(string ldapPath, string usuario)
        {
            //return BuscarUsuarioPorNombre(@"LDAP://" + ldapPath, usuario, new string[] { }) != null;
            if (ldapPath.ToLower().StartsWith("winnt"))
            {
                ldapPath = "WinNT" + ldapPath.Substring(5);
                //DirectoryEntry obDirEntry2 = new DirectoryEntry("WinNT://castab/Cristian,user");
                //if (obDirEntry2.Properties.Count > 0)
                //{ }
                //DirectoryEntry obDirEntry3 = new DirectoryEntry("WinNT://castab/AAACristian,user");
                //if (obDirEntry3.Properties.Count > 0)
                //{ }
                DirectoryEntry obDirEntry = new DirectoryEntry(ldapPath + "/" + usuario + ",user");
                try
                {
                    if (obDirEntry.Properties.Count > 0)
                    {
                        foreach (System.DirectoryServices.PropertyValueCollection strVal in obDirEntry.Properties)
                        {
                        }
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
                return false;

            }
            else
                return BuscarUsuarioPorNombre(ldapPath, usuario, new string[] { }) != null;
        }

        private static DirectoryEntry BuscarLDAPEntry(string path, string filter, IEnumerable<string> properties)
        {
            string strDebug = "";
            try
            {

                strDebug = "1";
                DirectoryEntry directoryEntry = new DirectoryEntry(path);
                strDebug = "2";

                DirectorySearcher search = new DirectorySearcher(directoryEntry);
                strDebug = "3";

                search.Filter = filter;
                strDebug = "4";

                foreach (string property in properties)
                    search.PropertiesToLoad.Add(property);
                strDebug = "5 path: " + path + " - filter: " + filter;

                SearchResult sr = search.FindOne();
                if (sr == null)
                {
                    strDebug = "No se encontró el usuario";
                }
                return sr.GetDirectoryEntry();
            }
            catch (Exception ex)
            {
                //log exception
                string error = strDebug + " | " + ex.Message;
                if (ex.InnerException != null)
                    error += " | Inner: " + ex.InnerException.Message;
                if (ConfigurationManager.AppSettings["DebugChgAD"] != null && ConfigurationManager.AppSettings["DebugChgAD"].ToString() == "1")
                { throw (new Exception(error)); }
            }

            return null;
        }
        public static string ActualizarDescripcionUsuarioRed(string NombreUsuario)
        {
            DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(NombreUsuario);
            string strErr = "";
            if (usuario == null)
            {
                strErr = "usuario == null";
                return strErr;
            }
            if (usuario.Properties["description"] != null)
            {
                string descripcion = usuario.Properties["description"].Value.ToString();

                if (descripcion.StartsWith(ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"]))
                {
                    usuario.Properties["description"].Value = descripcion.Remove(0, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"].Length);
                    strErr = "Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
                    usuario.CommitChanges();
                }
                else
                {
                    strErr = "NOT Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
                }
            }
            else
            {
                strErr = "(usuario.Properties[description] == null)";
            }
            return strErr;
        }

        public static string ActualizarDescripcionUsuarioRed(string NombreUsuario, string PrefijoDesc, string PathLDAP, string FilterBuscarNombre)
        {
            //DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(NombreUsuario);
            //DirectoryEntry usuario = ActiveDirectoryHelper.BuscarUsuarioPorNombre(PathLDAP, NombreUsuario, new string[] { "description" });
            DirectoryEntry usuario = BuscarLDAPEntry(PathLDAP, FilterBuscarNombre.Replace("[username]", NombreUsuario), new string[] { "description" });
            string strErr = "";
            if (usuario == null)
            {
                strErr = "usuario == null";
                return strErr;
            }
            if (usuario.Properties["description"] != null)
            {
                string descripcion = usuario.Properties["description"].Value.ToString();

                if (descripcion.StartsWith(PrefijoDesc))
                {
                    usuario.Properties["description"].Value = descripcion.Remove(0, PrefijoDesc.Length);
                    strErr = "Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
                    usuario.CommitChanges();
                }
                else
                {
                    strErr = "NOT Starts with Prefijo Descrip. Value: " + usuario.Properties["description"].Value;
                }
            }
            else
            {
                strErr = "(usuario.Properties[description] == null)";
            }
            return strErr;
        }
    }
}
