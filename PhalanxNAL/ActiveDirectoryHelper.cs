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

			return (T) settings[nombre];
		}

		public static DirectoryEntry BuscarUsuarioPorNombre(string username)
		{
			return BuscarUsuarioPorNombre(LDAPPath, username, new string[] { "description" });
		}

		public static DirectoryEntry BuscarUsuarioPorNombre(string path, string username, IEnumerable<string> propiedades)
		{
			return BuscarLDAPEntry(path, LDAPBuscarNombreFilter.Replace("[username]", username), propiedades);
		}

		public static bool UsuarioExiste(string ldapPath, string usuario)
		{
            //return BuscarUsuarioPorNombre(@"LDAP://" + ldapPath, usuario, new string[] { }) != null;
            if (ldapPath.ToLower().StartsWith("winnt"))
            {
                ldapPath = "WinNT"+ldapPath.Substring(5);
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
                    { return true; }
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
			try
			{

				DirectoryEntry directoryEntry = new DirectoryEntry(path);

				DirectorySearcher search = new DirectorySearcher(directoryEntry);

				search.Filter = filter;

				foreach (string property in properties)
					search.PropertiesToLoad.Add(property);

				SearchResult sr = search.FindOne();

				return sr.GetDirectoryEntry();
			}
			catch (Exception ex)
			{
				//log exception
			}

			return null;
		}
	}
}
