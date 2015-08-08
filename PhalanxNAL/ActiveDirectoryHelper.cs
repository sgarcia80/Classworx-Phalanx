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
			return BuscarLDAPEntry(LDAPPath, LDAPBuscarNombreFilter.Replace("[username]", username), new string[] { "description" });
		}

		public static bool UsuarioExiste(string dominio, string usuario)
		{
			string path = String.Format("WinNT://{0}/{1},user", dominio, usuario);

			try
			{
				DirectoryEntry.Exists(path);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
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
