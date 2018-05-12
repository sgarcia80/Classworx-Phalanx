using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.DirectoryServices;
using log4net;
using PhalanxCommon;

namespace PhalanxNAL
{
    public class ActiveDirectoryHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ActiveDirectoryHelper));

        private const string NOMBRE_PROPIEDAD_DESCRIPCION_AD = "description";
        private const string NOMBRE_PROPIEDAD_PATH_AD = "adspath";
        private const string NOMBRE_PROPIEDAD_MAIL_AD = "mail";
        private const string NOMBRE_PROPIEDAD_USERNAME_AD = "displayName";
        private const string NOMBRE_PROPIEDAD_DISABLED_AD = "userAccountControl";
        private const string NOMBRE_PROPIEDAD_LOCKOUTTIME_AD = "LockOutTime";
        private const string NOMBRE_PROPIEDAD_PWDLASTSET_AD = "pwdLastSet";
        private const string NOMBRE_PROPIEDAD_EMPLOYEEID = "employeeID";

        private const string UserAccountControl = "userAccountControl";
        private const string SetPassword = "SetPassword";
        private const string LockOutTime = "LockOutTime";
        private const string PwdLastSet = "pwdLastSet";
        private const int DontExpirePassword = 0x10000;


        private static Dictionary<string, object> settings = new Dictionary<string, object>();

        private static DirectoryEntry DirectoryAdmin { get; set; }

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

        static ActiveDirectoryHelper()
        {
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
                IEnumerable<string> propiedades = new string[] { "givenName", "sn", "streetAddress", "mail", "department", "physicalDeliveryOfficeName", "title" };
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

                        if (sr.Properties["title"] != null && sr.Properties["title"].Count > 0)
                        {
                            Usuario.Log += "|title|";
                            Usuario.Title = sr.Properties["title"][0].ToString() + " ";
                        }

                        break;
                    }
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
                        //foreach (System.DirectoryServices.PropertyValueCollection strVal in obDirEntry.Properties)
                        //{
                        //}
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

        public static string BuscarEmailPorLegajo(string legajo)
        {
            return BuscarLDAPEntryPropiedad(ConfigurationManager.AppSettings["LDAPBuscarEmailFilter"].Replace("[legajo]", legajo), NOMBRE_PROPIEDAD_MAIL_AD);
        }

        public static string BuscarEmailPorLegajoUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return string.Empty;
            }

            return BuscarLDAPEntryPropiedad(ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"].Replace("[username]", username), NOMBRE_PROPIEDAD_MAIL_AD);
        }

        public static string BuscarNombrePorUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return string.Empty;
            }

            return BuscarLDAPEntryPropiedad(ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"].Replace("[username]", username), NOMBRE_PROPIEDAD_USERNAME_AD);
        }

        public static string BuscarNombrePorUsername(string username, string path)
        {
            string name = string.Empty;
            string filtroBuscarNombre = ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"];

            DirectoryEntry usuario = BuscarLDAPEntryRecursivo(path, filtroBuscarNombre.Replace("[username]", username), new string[] { NOMBRE_PROPIEDAD_USERNAME_AD });

            try
            {
                if (usuario != null)
                {
                    if (usuario.Properties.Contains(NOMBRE_PROPIEDAD_USERNAME_AD))
                    {
                        if (usuario.Properties[NOMBRE_PROPIEDAD_USERNAME_AD] != null)
                        {
                            name = usuario.Properties[NOMBRE_PROPIEDAD_USERNAME_AD].Value.ToString();

                            log.InfoFormat("Se consulta la propiedad {0} con valor '{1}'", NOMBRE_PROPIEDAD_USERNAME_AD, name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new Exception("Error al validar el usuario en el Dominio", ex);
            }

            return name;
        }

        public static string BuscarEmployeeID(string username, string path)
        {
            string name = string.Empty;
            string filtroBuscarNombre = ConfigurationManager.AppSettings["LDAPBuscarNombreFilter"];

            DirectoryEntry usuario = BuscarLDAPEntryRecursivo(path, filtroBuscarNombre.Replace("[username]", username), new string[] { NOMBRE_PROPIEDAD_EMPLOYEEID });

            try
            {
                if (usuario != null)
                {
                    if (usuario.Properties.Contains(NOMBRE_PROPIEDAD_EMPLOYEEID))
                    {
                        if (usuario.Properties[NOMBRE_PROPIEDAD_EMPLOYEEID] != null)
                        {
                            name = usuario.Properties[NOMBRE_PROPIEDAD_EMPLOYEEID].Value.ToString();

                            log.InfoFormat("Se consulta la propiedad {0} con valor '{1}'", NOMBRE_PROPIEDAD_EMPLOYEEID, name);
                        }
                    }
                }

                if (string.IsNullOrEmpty(name))
                {
                    log.InfoFormat("No se encontró la propiedad '{0}'", NOMBRE_PROPIEDAD_EMPLOYEEID);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new Exception("Error al validar el usuario en el Dominio", ex);
            }

            return name;
        }

        private static DirectoryEntry BuscarLDAPEntry(string path, string filter, IEnumerable<string> properties)
        {
            log.Info("Comienza busqueda LDAP");
            log.Info("Path: " + path);
            log.Info("Filtro: " + filter);
            log.Info("Propiedades a cargar: " + string.Join(",", new List<string>(properties).ToArray()));

            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry(path);

                DirectoryEntry dr = BuscarLDAPEntry(directoryEntry, filter, properties);

                if (dr != null)
                {
                    log.Info("Busqueda LDAP finalizada con exito");

                    return dr;
                }

                log.Info("Busqueda LDAP finalizada, no se encontró la entrada");
            }
            catch (Exception ex)
            {
                log.Error("Error al realizar la búsqueda", ex);

                log.Info("Busqueda LDAP finalizada con errores");
            }

            return null;
        }

        public static string ActualizarDescripcionUsuarioRed(string NombreUsuario)
        {
            return ActiveDirectoryHelper.ActualizarDescripcionUsuarioRed(NombreUsuario, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"]
                , LDAPPath, LDAPBuscarNombreFilter);
        }

        public static string ActualizarDescripcionUsuarioRed(string NombreUsuario, string PrefijoDesc, string PathLDAP, string FilterBuscarNombre)
        {
            return ActualizarDescripcionUsuarioRed(NombreUsuario, PrefijoDesc, PathLDAP, FilterBuscarNombre, false);
        }

        public static string ActualizarDescripcionUsuarioRed(string NombreUsuario, string PrefijoDesc, string PathLDAP, string FilterBuscarNombre, bool busquedaRecursiva)
        {
            string strErr = "";
            try
            {
                DirectoryEntry usuario = busquedaRecursiva
                    ? BuscarLDAPEntryRecursivo(PathLDAP, FilterBuscarNombre.Replace("[username]", NombreUsuario), new string[] { "description" })
                    : BuscarLDAPEntry(PathLDAP, FilterBuscarNombre.Replace("[username]", NombreUsuario), new string[] { "description" });

                if (usuario == null)
                {
                    strErr = "usuario == null";
                    return strErr;
                }

                foreach (string propertyName in usuario.Properties.PropertyNames)
                    strErr += propertyName + Environment.NewLine;

                // falta verificar si la propiedad description existe sino da error
                if (usuario.Properties.Contains("description"))
                {
                    if (usuario.Properties["description"] != null)
                    {
                        string descripcion = usuario.Properties["description"].Value.ToString();

                        if (descripcion.StartsWith(PrefijoDesc))
                        {
                            //suario.Properties["description"].Value = descripcion.Remove(0, PrefijoDesc.Length);
                            //string strDescrip = descripcion.Remove(0, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"].Length);
                            string strDescrip = descripcion.Remove(0, PrefijoDesc.Length);
                            if (string.IsNullOrEmpty(strDescrip) || strDescrip == "" || strDescrip.Length == 0)
                            {
                                strErr = "Va a borrar la descripcion.";
                                usuario.Properties["description"].Clear();
                                //usuario.Properties["description"].Value = null;
                            }
                            else
                            {
                                strErr = "Va a asignar la descripcion " + strDescrip;
                                usuario.Properties["description"].Value = strDescrip;
                            }
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
                }
                else
                    strErr += "No se pudo cargar la propiedad \"description\"";
            }
            catch (Exception ex)
            {
                strErr += ex.Message;
            }
            return strErr;

        }

        private static DirectoryEntry BuscarLDAPEntryRecursivo(string path, string filter, IEnumerable<string> properties)
        {
            log.Info("Comienza busqueda LDAP recursiva");

            try
            {
                //Buscar entrada raiz
                log.Info("Buscando entrada raiz...");
                log.Debug("Path: " + path);
                DirectoryEntry rootEntry = new DirectoryEntry(path);

                if (rootEntry == null)
                {
                    log.Info("No se encontró la entrada raíz");

                    return null;
                }

                log.Info("Buscando entrada según filtro");
                log.Debug("Filter: " + filter);

                DirectoryEntry entry = BuscarLDAPEntry(rootEntry, filter, properties);

                if (entry == null)
                {
                    log.Info("No se encontró la entrada");
                    log.Info("Buscando OU hijas...");
                    //Buscar todas las OU
                    DirectorySearcher ouSearch =
                        new DirectorySearcher(rootEntry, path) { Filter = "(objectCategory=organizationalUnit)", SearchScope = SearchScope.OneLevel };

                    ouSearch.PropertiesToLoad.Add(NOMBRE_PROPIEDAD_PATH_AD);

                    foreach (SearchResult sr in ouSearch.FindAll())
                    {
                        log.Info("OU hija encontrada");

                        log.Debug("Propiedades:");

                        foreach (string propertyName in sr.Properties.PropertyNames)
                        {
                            List<string> values = new List<string>();

                            foreach (var value in sr.Properties[propertyName])
                                values.Add(value.ToString());

                            log.Debug(propertyName + " = " + string.Join(",", values.ToArray()));
                        }

                        entry = BuscarLDAPEntryRecursivo(sr.Properties[NOMBRE_PROPIEDAD_PATH_AD][0].ToString(), filter, properties);

                        if (entry != null)
                            return entry;
                    }

                    log.Info("No se encontró la entrada en las OU hijas");
                }
                else
                {
                    log.Info("Busqueda LDAP recursiva finalizada con exito");

                    return entry;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al realizar la búsqueda", ex);

                log.Info("Busqueda LDAP finalizada con errores");
            }

            return null;
        }

        private static DirectoryEntry BuscarLDAPEntryAdmin(string filter, IEnumerable<string> properties)
        {
            log.Info("Comienza busqueda LDAP recursiva");

            try
            {
                //Buscar entrada raiz
                log.Info("Buscando entrada raiz...");
                log.Debug("Path: " + DirectoryAdmin.Path);

                DirectoryEntry rootEntry = DirectoryAdmin;

                if (rootEntry == null)
                {
                    log.Info("No se encontró la entrada raíz");

                    return null;
                }

                log.Info("Buscando entrada según filtro");
                log.Debug("Filter: " + filter);

                DirectoryEntry entry = BuscarLDAPEntry(rootEntry, filter, properties);

                if (entry != null)
                {
                    log.Info("Busqueda LDAP recursiva finalizada con exito");

                    return entry;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al realizar la búsqueda", ex);

                log.Info("Busqueda LDAP finalizada con errores");

                throw;
            }

            return null;
        }

        public static bool AgregarPrefijoDescripcionUsuario(string nombreUsuario)
        {
            return ActiveDirectoryHelper.AgregarPrefijoDescripcionUsuario(nombreUsuario, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"],
                LDAPPath, LDAPBuscarNombreFilter);
        }

        public static bool AgregarPrefijoDescripcionUsuario(string nombreUsuario, string prefijo, string pathLDAP, string filtroBuscarNombre)
        {
            return ActualizarPrefijoDescripcionUsuario(nombreUsuario, prefijo, pathLDAP, filtroBuscarNombre, false);
        }

        public static bool EliminarPrefijoDescripcionUsuario(string nombreUsuario)
        {
            return ActiveDirectoryHelper.EliminarPrefijoDescripcionUsuario(nombreUsuario, ConfigurationManager.AppSettings["PrefijoDescripcionUsuarioRed"],
                LDAPPath, LDAPBuscarNombreFilter);
        }

        public static bool EliminarPrefijoDescripcionUsuario(string nombreUsuario, string prefijo, string pathLDAP, string filtroBuscarNombre)
        {
            return ActualizarPrefijoDescripcionUsuario(nombreUsuario, prefijo, pathLDAP, filtroBuscarNombre, true);
        }

        public static bool ActualizarPrefijoDescripcionUsuario(string nombreUsuario, string prefijo, string pathLDAP, string filtroBuscarNombre, bool quitarPrefijo)
        {
            log.Info("Comienza actualizacion descripción...");
            log.Debug("Nombre usuario: " + nombreUsuario);
            log.Debug("Prefijo: " + prefijo);

            DirectoryEntry usuario = BuscarLDAPEntryRecursivo(pathLDAP, filtroBuscarNombre.Replace("[username]", nombreUsuario), new string[] { NOMBRE_PROPIEDAD_DESCRIPCION_AD });

            try
            {
                if (usuario != null)
                {
                    log.Info("Usuario encontrado");
                    log.Info("Buscando propiedad \"" + NOMBRE_PROPIEDAD_DESCRIPCION_AD + "\" ...");

                    string descripcion = null;

                    if (usuario.Properties.Contains(NOMBRE_PROPIEDAD_DESCRIPCION_AD))
                    {
                        log.Info("Propiedad encontrada");

                        if (usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD] != null)
                        {
                            descripcion = usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD].Value.ToString();
                            log.Debug("Valor de la propiedad: " + descripcion);
                        }
                        else
                            log.Debug("El valor de la propiedad es null");

                        if (quitarPrefijo)
                        {
                            log.Info("Comienzo eliminación del prefijo...");

                            if (descripcion.StartsWith(prefijo))
                            {
                                string strDescrip = descripcion.Remove(0, prefijo.Length);

                                if (string.IsNullOrEmpty(strDescrip) || strDescrip == "" || strDescrip.Length == 0)
                                {
                                    log.Info("Se va a eliminar la descripción...");

                                    usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD].Clear();
                                }
                                else
                                {
                                    log.Info("Se va a eliminar el prefijo...");

                                    usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD].Value = strDescrip;
                                }

                                usuario.CommitChanges();

                                log.Info("Descripción actualizada");
                            }
                            else
                                log.Info("El valor de la propiedad no comienza con el prefijo dado");
                        }
                    }
                    else
                        log.Info("No se pudo cargar la propiedad \"" + NOMBRE_PROPIEDAD_DESCRIPCION_AD + "\"");

                    if (!quitarPrefijo)
                    {
                        log.Info("Comienzo adición del prefijo...");

                        if (descripcion != null)
                            usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD].Value = prefijo + descripcion;
                        else
                            usuario.Properties[NOMBRE_PROPIEDAD_DESCRIPCION_AD].Add(prefijo);

                        usuario.CommitChanges();

                        log.Info("Descripción actualizada");
                    }
                }
                else
                {
                    log.Info("No se encontró el usuario");

                    return false;
                }

                log.Info("Actualización de descripción finalizada");

                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error al actualizar la descripción del usuario", ex);

                log.Info("Actualización de descripción finalizada con errores");
            }

            return false;
        }

        private static DirectoryEntry BuscarLDAPEntry(DirectoryEntry directoryEntry, string filter, IEnumerable<string> properties)
        {
            DirectorySearcher search = new DirectorySearcher(directoryEntry);

            search.Filter = filter;

            foreach (string property in properties)
            {
                search.PropertiesToLoad.Add(property);
            }

            SearchResult sr = search.FindOne();

            if (sr != null)
                return sr.GetDirectoryEntry();

            return null;
        }

        public static string BuscarLDAPEntryPropiedad(string filtro, string propiedad)
        {
            DirectoryEntry entry = BuscarLDAPEntry(LDAPPath, filtro, new string[] { propiedad });

            if (entry != null)
            {
                if (entry.Properties.Contains(propiedad))
                {
                    if (entry.Properties[propiedad] != null)
                        return entry.Properties[propiedad].Value.ToString();
                    else
                        log.Debug("El valor de la propiedad es null");
                }
                else
                    log.Info("No se encuentra la propiedad " + propiedad);
            }

            return string.Empty;
        }

        public static bool ResetPassword(string user, string password)
        {
            log.Info("Usuario: " + user);

            if (DirectoryAdmin == null)
            {
                return false;
            }

            string filtroBuscarNombre = "((samaccountname=[username]))";

            log.Debug("Se busca con filtro: " + filtroBuscarNombre);

            DirectoryEntry usuario = BuscarLDAPEntryAdmin(filtroBuscarNombre.Replace("[username]", user), new string[] { NOMBRE_PROPIEDAD_DISABLED_AD, NOMBRE_PROPIEDAD_LOCKOUTTIME_AD, NOMBRE_PROPIEDAD_PWDLASTSET_AD });

            try
            {
                bool disabled = false;
                string mensaje = string.Empty;
                bool lockouttime = false;

                if (usuario != null)
                {
                    using (usuario)
                    {
                        log.Info("Usuario encontrado");

                        //Se consulta si la cuenta esta deshabilitada
                        disabled = GetAccountDisable(usuario);
                        //Se consulta si la cuenta esta bloqueada
                        lockouttime = GetAccountLocked(usuario);

                        //Si la cuenta está bloqueada
                        if (disabled)
                        {
                            mensaje = string.Format("El usuario {0} se encuentra deshabilitado", user);
                            throw new InvalidOperationException(mensaje);
                        }

                        log.Info("Consultando usuario bloqueado...");
                        bool locked = Convert.ToBoolean(usuario.InvokeGet("IsAccountLocked"));

                        log.Debug("Valor de la propiedad: " + locked.ToString());

                        if (locked)
                        {
                            log.Debug("Se desbloquea el usuario: " + locked.ToString());
                            usuario.InvokeSet("IsAccountLocked", false);
                        }

                        log.Info("Se blanquea la contraseña...");


                        // Set the password, unlock the account and force the user to change password at next logon
                        log.Info("Se cambia contraseña");
                        usuario.Invoke(SetPassword, new object[] { password });
                        
                        log.Info("Se marca el cambio de contraseña (pwdLastSet)");
                        usuario.Properties[PwdLastSet].Value = 0; // force change at next logon
                        
                        log.Info("Se desbloquea la cuenta");
                        usuario.Properties[LockOutTime].Value = 0; // unlock account

                        usuario.CommitChanges();

                        log.Info("Blanqueo de contraseña finalizada");
                    }
                }
                else
                {
                    log.Info("No se encontró el usuario");

                    mensaje = string.Format("No se encontró el usuario {0}", user);
                    throw new InvalidOperationException(mensaje);
                }

                return true;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log.Error("Error al blanquear la contraseña del usuario", ex);

                log.Info("Blanqueo de contraseña finalizada con errores");

                throw;
            }

            //return false;
        }

        public static bool ResetPassword2(string user, string password, bool searched, bool searchedproperties, bool esadmin, bool essecure, string admin, string adminpwd, string path, StringBuilder history)
        {
            if (history == null)
            {
                history = new StringBuilder();
            }

            history.AppendLine("Usuario: " + user);

            if (esadmin && DirectoryAdmin == null)
            {
                return false;
            }

            //string filtroBuscarNombre = "((samaccountname=[username]))";//LDAPBuscarNombreFilter;

            //log.Debug("Se busca con filtro: " + filtroBuscarNombre);
            //DirectoryEntry usuario = BuscarLDAPEntryAdmin(filtroBuscarNombre.Replace("[username]", user), new string[] { NOMBRE_PROPIEDAD_DISABLED_AD, NOMBRE_PROPIEDAD_LOCKOUTTIME_AD, NOMBRE_PROPIEDAD_PWDLASTSET_AD });

            string filtro = path.Replace("*", string.Format("samaccountname={0},", user));

            history.AppendLine("Filtro: " + filtro);

            DirectoryEntry usuario = null;

            try
            {
                if (searched)
                {
                    history.AppendLine("Si va por busqueda de usuario");
                    System.DirectoryServices.DirectoryServicesPermission permission = new System.DirectoryServices.DirectoryServicesPermission(System.Security.Permissions.PermissionState.Unrestricted);
                    permission.Assert();

                    history.AppendLine("Se setea el dominio: " + path);
                    System.DirectoryServices.DirectoryEntry directory = null;

                    if (esadmin)
                    {
                        if (essecure)

                            directory = new System.DirectoryServices.DirectoryEntry(path, admin, adminpwd, AuthenticationTypes.Secure);
                        else
                            directory = new System.DirectoryServices.DirectoryEntry(path, admin, adminpwd);
                    }
                    else
                    {
                        directory = new System.DirectoryServices.DirectoryEntry(path);
                    }

                    string filter = String.Format("(&(objectClass=user)(samaccountname=" + user + "))");
                    System.DirectoryServices.DirectorySearcher findUser = new System.DirectoryServices.DirectorySearcher(directory, filter);

                    history.AppendLine("Filtro: " + filter);

                    if (searchedproperties)
                    {
                        findUser.PropertiesToLoad.Add(UserAccountControl);
                        findUser.PropertiesToLoad.Add(PwdLastSet);
                        findUser.PropertiesToLoad.Add(LockOutTime);
                    }

                    System.DirectoryServices.SearchResult result = findUser.FindOne();

                    usuario = result.GetDirectoryEntry();
                }
                else
                {
                    if (esadmin)
                    {
                        if (essecure)

                            usuario = new DirectoryEntry(filtro, admin, adminpwd, AuthenticationTypes.Secure);
                        else
                            usuario = new DirectoryEntry(filtro, admin, adminpwd);
                    }
                    else
                    {
                        usuario = new DirectoryEntry(filtro);
                    }
                }

                bool disabled = false;
                string mensaje = string.Empty;
                bool lockouttime = false;

                using (usuario)
                {
                    if (usuario != null)
                    {
                        history.AppendLine("Usuario encontrado");

                        //if (usuario.Properties != null)
                        //{
                        //    history.AppendLine("Propiedades: " + usuario.Properties.Count);
                        //}

                        //Se consulta si la cuenta esta deshabilitada
                        disabled = GetAccountDisable(usuario);
                        //Se consulta si la cuenta esta bloqueada
                        lockouttime = GetAccountLocked(usuario);

                        //Si la cuenta está bloqueada
                        if (disabled)
                        {
                            mensaje = string.Format("El usuario {0} se encuentra deshabilitado", user);
                            throw new InvalidOperationException(mensaje);
                        }

                        log.Info("Consultando usuario bloqueado...");
                        bool locked = Convert.ToBoolean(usuario.InvokeGet("IsAccountLocked"));

                        log.Debug("Valor de la propiedad: " + locked.ToString());

                        if (locked)
                        {
                            log.Debug("Se desbloquea el usuario: " + locked.ToString());
                            usuario.InvokeSet("IsAccountLocked", false);
                        }

                        history.AppendLine("Se blanquea la contraseña...");

                        //if (usuario.Properties.Contains(UserAccountControl))
                        //{
                        //    int userAccountControl = (int)usuario.Properties[UserAccountControl].Value;

                        //    bool passwordNeverExpires = (userAccountControl & DontExpirePassword) == DontExpirePassword;
                        //    if (passwordNeverExpires)
                        //    {
                        //        history.AppendLine("Se quita contraseña nunca expira");
                        //        userAccountControl = userAccountControl & ~DontExpirePassword;
                        //        usuario.Properties[UserAccountControl].Value = userAccountControl;
                        //        usuario.CommitChanges();
                        //        history.AppendLine("Se removio contraseña nunca expira");
                        //    }
                        //}

                        // Set the password, unlock the account and force the user to change password at next logon
                        history.AppendLine("Se cambia contraseña");
                        usuario.Invoke(SetPassword, new object[] { password });
                        history.AppendLine("Se marca el cambio de contraseña (pwdLastSet)");
                        usuario.Properties[PwdLastSet].Value = 0; // force change at next logon
                        history.AppendLine("Se desbloquea la cuenta");
                        usuario.Properties[LockOutTime].Value = 0; // unlock account

                        usuario.CommitChanges();

                        history.AppendLine("Blanqueo de contraseña finalizada");
                    }
                    else
                    {
                        history.AppendLine("No se encontró el usuario");

                        mensaje = string.Format("No se encontró el usuario {0}", user);
                        throw new InvalidOperationException(mensaje);
                    }
                }

                return true;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log.Error("Error al blanquear la contraseña del usuario", ex);

                log.Info("Blanqueo de contraseña finalizada con errores");

                throw;
            }

            //return false;
        }

        public static bool UnlockUserAccount(string user)
        {
            log.Info("Comienza desbloqueo de usuario...");
            log.Debug("Usuario: " + user);

            string filtroBuscarNombre = LDAPBuscarNombreFilter;

            if (DirectoryAdmin == null)
            {
                return false;
            }

            DirectoryEntry usuario = BuscarLDAPEntryAdmin(filtroBuscarNombre.Replace("[username]", user), new string[] { NOMBRE_PROPIEDAD_DISABLED_AD, NOMBRE_PROPIEDAD_LOCKOUTTIME_AD });

            try
            {
                bool disabled = false;
                string mensaje = string.Empty;
                bool lockouttime = false;

                if (usuario != null)
                {
                    log.Info("Usuario encontrado");

                    //Se consulta si la cuenta esta deshabilitada
                    disabled = GetAccountDisable(usuario);
                    //Se consulta si la cuenta esta bloqueada
                    lockouttime = GetAccountLocked(usuario);

                    //Si la cuenta está bloqueada
                    if (disabled)
                    {
                        mensaje = string.Format("El usuario {0} se encuentra deshabilitado", user);
                        throw new InvalidOperationException(mensaje);
                    }

                    log.Info("Consultando usuario bloqueado...");
                    bool locked = Convert.ToBoolean(usuario.InvokeGet("IsAccountLocked"));

                    log.Debug("Valor de la propiedad: " + locked.ToString());

                    if (locked)
                    {
                        log.Debug("Se desbloquea el usuario: " + locked.ToString());
                        usuario.InvokeSet("IsAccountLocked", false);
                    }
                    else
                    {
                        mensaje = string.Format("El usuario {0} no se encuentra bloqueado", user);
                        throw new InvalidOperationException(mensaje);
                    }
                }
                else
                {
                    log.Info("No se encontró el usuario");

                    mensaje = string.Format("No se encontró el usuario {0}", user);
                    throw new InvalidOperationException(mensaje);
                }

                log.Info("Comienzo Desbloqueo de Usuario...");

                if (lockouttime)
                {
                    usuario.Properties["LockOutTime"].Value = 0; //unlock account
                }

                usuario.CommitChanges();

                log.Info("Desbloqueo de Usuario finalizado");

                return true;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log.Error("Error al blanquear la contraseña del usuario", ex);

                log.Info("Desbloqueo de Usuario finalizada con errores");

                throw;
            }

            //return false;
        }

        public static void SetAdminConnection(string path, string user, string password)
        {
            string adminUser = string.Empty;
            string adminUserPassword = string.Empty;

            if (!string.IsNullOrEmpty(user))
            {
                adminUser = user;
            }
            if (!string.IsNullOrEmpty(password))
            {
                adminUserPassword = password;
            }

            DirectoryAdmin = new DirectoryEntry(path, adminUser, adminUserPassword, AuthenticationTypes.Secure);
        }

        public static string TestAdminConnection(string user)
        {
            string filtroBuscarNombre = LDAPBuscarNombreFilter;
            string propiedad = NOMBRE_PROPIEDAD_MAIL_AD;

            DirectoryEntry entry = BuscarLDAPEntryAdmin(filtroBuscarNombre.Replace("[username]", user), new string[] { propiedad });

            if (entry != null)
            {
                if (entry.Properties.Contains(propiedad))
                {
                    if (entry.Properties[propiedad] != null)
                        return entry.Properties[propiedad].Value.ToString();
                }
                else
                    log.Info("No se encuentra la propiedad " + propiedad);
            }

            return null;
        }

        private static bool GetAccountDisable(DirectoryEntry usuario)
        {
            bool disabled = false;
            string propertyvalue = string.Empty;

            log.Info("Buscando propiedad \"" + NOMBRE_PROPIEDAD_DISABLED_AD + "\" ...");

            if (usuario.Properties.Contains(NOMBRE_PROPIEDAD_DISABLED_AD))
            {
                log.Info("Propiedad encontrada");

                if (usuario.Properties[NOMBRE_PROPIEDAD_DISABLED_AD] != null)
                {
                    propertyvalue = usuario.Properties[NOMBRE_PROPIEDAD_DISABLED_AD].Value.ToString();
                    log.Debug("Valor de la propiedad: " + propertyvalue);

                    int userAccountControl = 0;
                    int.TryParse(propertyvalue, out userAccountControl);

                    disabled = ((userAccountControl & 2) > 0);
                }
                else
                {
                    log.Debug("El valor de la propiedad es null");
                }
            }
            else
            {
                log.Info("No se pudo cargar la propiedad \"" + NOMBRE_PROPIEDAD_DISABLED_AD + "\"");
            }

            return disabled;
        }

        private static bool GetAccountLocked(DirectoryEntry usuario)
        {
            bool lockouttime = false;
            string propertyvalue = string.Empty;

            log.Info("Buscando propiedad \"" + NOMBRE_PROPIEDAD_LOCKOUTTIME_AD + "\" ...");

            if (usuario.Properties.Contains(NOMBRE_PROPIEDAD_LOCKOUTTIME_AD))
            {
                log.Info("Propiedad encontrada");

                if (usuario.Properties[NOMBRE_PROPIEDAD_LOCKOUTTIME_AD] != null)
                {
                    lockouttime = true;

                    propertyvalue = usuario.Properties[NOMBRE_PROPIEDAD_LOCKOUTTIME_AD].Value.ToString();
                    log.Debug("Valor de la propiedad: " + propertyvalue);
                }
                else
                {
                    log.Debug("El valor de la propiedad es null");
                }
            }
            else
            {
                log.Info("No se pudo cargar la propiedad \"" + NOMBRE_PROPIEDAD_LOCKOUTTIME_AD + "\"");
            }

            return lockouttime;
        }
    }
}
