using System;
//using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Reflection;
using PhalanxDAL;
using PhalanxDAL.Data;
using System.Net;
using System.Net.Sockets;
using phxCryptMgr;
using PhxPing;
using phxLog;
using System.DirectoryServices;
using PhalanxDAL.Factories;
//using System.Net.NetworkInformation;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CUser
	{
/*		protected uint m_userid;
		protected string m_username;
		protected bool m_activeuser;
		protected uint m_usertype;
		protected string m_windomain;
*/		
		public CPassword password;
		protected IntPtr tokenHandle;
		public bool tryImpersonate = false; 
		protected CLogger currLog; 
		public string fullName;
		public string description;

		public CUser() //Contructor
		{
			currLog = new CLogger();
			currLog.LogFilePath = "C:\\Classworx\\Phalanx\\logs\\phxLog.txt"; 			
		}

		protected string crypt(string text)
		{
			CCryptMgr crypt = new CCryptMgr();
			string aux = crypt.encrypt(text);
			return aux;
		}

		protected string decrypt(string text)
		{
			CCryptMgr crypt = new CCryptMgr();
			string aux = crypt.decrypt(text);
			return aux;
		}

	}

	public class CUserLocal: CUser
	{
		//private string m_computer;
		protected WinLocalUsers dalLocalUser;
		public string winDomain
		{
			get{
				return dalLocalUser.WinPcId.WinDomainId.NtName;
			}
			set{
				dalLocalUser.WinPcId.WinDomainId.NtName = value;
			}
		}
		public string winComputer
		{
			get
			{
				return dalLocalUser.WinPcId.PcName;
			}
			set
			{
				dalLocalUser.WinPcId.PcName= value;
			}
		}
		public string winUserName
		{
			get
			{
				return dalLocalUser.Username;
			}
			set
			{
				dalLocalUser.Username = value;
			}
		}
		public string winUserPassword
		{
			get
			{
				return base.decrypt(dalLocalUser.UserPasswordId.Password); 
			}
			set
			{
				dalLocalUser.UserPasswordId.Password = base.crypt(value);
			}
		}



		/// <summary>
		/// Contructor vinculado con la Base de Datos
		/// </summary>
		/// <param name="LocalUser">Usuario extraido de la Base de Datos </param>
		/// <remarks>Dentro de este contructor se setea el Password Actual obtenido de la BD Automaticamente</remarks>
		public CUserLocal(WinLocalUsers LocalUser)
		{
			dalLocalUser = LocalUser;
			password = new CPassword(winDomain, winComputer, winUserName, winUserPassword);
		}
		
		/// <summary>
		/// Contructor manual 
		/// </summary>
		/// <param name="domainOfComputer"></param>
		/// <param name="computerName"></param>
		/// <param name="userName"></param>
		/// <remarks>En esta instancia el password no se conoce</remarks>
		public CUserLocal(string domainOfComputer, string computerName, string userName) //Contructor
		{
			dalLocalUser = new WinLocalUsers();
			winDomain = domainOfComputer;
			winComputer = computerName;
			winUserName = userName;
			password = new CPassword(winDomain, winComputer, winUserName);
		}

		public void UpdateCheckedUsrPwdError(WinLocalUsersFactory WinLocalUsrFac)
		{
			//WinLocalUsrFac.UpdateCheckedUsrPwdError(dalLocalUser);
		}
		public void UpdateCheckedUsrPwd(WinLocalUsersFactory WinLocalUsrFac, DateTime currDateTime)
		{
			//WinLocalUsrFac.UpdateCheckedUsrPwd(dalLocalUser, currDateTime);
		}

		public void UpdateChangedUsrPwd(WinLocalUsersFactory WinLocalUsrFac, DateTime currDateTime)
		{
			if ((password.getPassword != string.Empty) && (password.getPassword != null))
				winUserPassword= password.getPassword;
			//WinLocalUsrFac.UpdateChangedUsrPwd(dalLocalUser, currDateTime);
		}

	}

	public class CUserGlobal: CUser
	{
		private string m_activeDomainController;

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)] 
			public struct LOCALGROUP_MEMBERS_INFO_3 
		{ 
			public string lgrmi3_domainandname; 
		} 

		[DllImport("NetAPI32.dll", CharSet=CharSet.Unicode)] 
		public extern static int NetLocalGroupAddMembers( 
			[MarshalAs(UnmanagedType.LPWStr)] string servername, 
			[MarshalAs(UnmanagedType.LPWStr)] string localgroupname, 
			int level, 
			ref LOCALGROUP_MEMBERS_INFO_3 bufptr, 
			int totalentries); 

		protected WinDomainUsers dalGlobalUser;
		public string winDomain
		{
			get
			{
				return dalGlobalUser.WinDomainId.NtName;
			}
			set
			{
				dalGlobalUser.WinDomainId.NtName = value;
			}
		}
		public string winComputer
		{
			get
			{
				return m_activeDomainController;
			}
		}
		public string winUserName
		{
			get
			{
				return dalGlobalUser.Username;
			}
			set
			{
				dalGlobalUser.Username = value;
			}
		}
		public string winUserPassword
		{
			get
			{
				return base.decrypt(dalGlobalUser.UserPasswordId.Password);
			}
			set
			{
				dalGlobalUser.UserPasswordId.Password = base.decrypt(value);
			}
		}

		public CUserGlobal(WinDomainUsers GlobalUser)
		{
			try
			{
				dalGlobalUser = GlobalUser;
				m_activeDomainController= getActiveDomainController();
				if (m_activeDomainController == string.Empty)
					m_activeDomainController = dalGlobalUser.WinDomainId.WinPCsList[0].ToString();
				password = new CPassword(winDomain, winComputer, winUserName, winUserPassword);
			}
			catch (Exception ecug)
			{
			
			}
		}
		
		public CUserGlobal(string domainName, string userName) //Contructor
		{
			dalGlobalUser = new WinDomainUsers();
			winDomain= domainName;
			winUserName= userName;
			try
			{
				m_activeDomainController= getActiveDomainController();
				if (m_activeDomainController == string.Empty)
					m_activeDomainController = dalGlobalUser.WinDomainId.WinPCsList[0].ToString();
			}
			catch
			{
				m_activeDomainController= string.Empty;
				string errorMsg= "cant get Active Domain Controller";
				currLog.registerLog(CLogger.TYPE_WARNING, 0, "Domain Control", errorMsg, true, true);
			}
			password = new CPassword(winDomain, winComputer, winUserName);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string getActiveDomainController() //devuelve la pc que este levantada como controlador, puede ser el PDB o BDC
		{
			string ActDomController = string.Empty;
			WinDCFactory WDCF = new WinDCFactory();
			Ping myPing = new Ping();
			PingResponse resPing;
			foreach (WinDomainControllers objWDC in WDCF.GetDCsByDomainName(winDomain))
			{
				int i = objWDC.WinDcId;
				string strDCType = objWDC.DcType;
				resPing = myPing.PingHost(objWDC.WinPcId.PcName);
				if (resPing != null)
				{
					ActDomController = objWDC.WinPcId.PcName; 
					break;
				}
           	}
			return ActDomController;
		}

		public bool net_AddUserToGroup(string destinationServer, string destinationGroup)
		{
			bool m_return = false;
			LOCALGROUP_MEMBERS_INFO_3 memberInfo = 	new LOCALGROUP_MEMBERS_INFO_3(); 
			memberInfo.lgrmi3_domainandname = winDomain + "\\" + winUserName; 
			
			int NetAPIStatus = NetLocalGroupAddMembers(destinationServer, 
											destinationGroup, 
											3, 
											ref memberInfo, 
											1);
				
			// NetGroupAddUser(m_activeDomainController, group, m_username);

			if (NetAPIStatus == 0)
				m_return= true;
			else if (tryImpersonate)
			{
				CImpersonate imper = new CImpersonate();
				NetAPIStatus = NetLocalGroupAddMembers(destinationServer, 
					destinationGroup, 
					3, 
					ref memberInfo, 
					1);

				imper.closeImpersonate(); 
				if (NetAPIStatus == 0)
					m_return = true;
			}
			return m_return;
		}
		
		public bool AD_AddUserToGroup(string destinationDomain , string destinationServer, string destinationGroup)
		{
			string auxmsg;
			return AD_AddUserToGroup(destinationDomain , destinationServer, destinationGroup, out auxmsg);
		}

		public bool AD_AddUserToGroup(string destinationDomain , string destinationServer, string destinationGroup, out string errorMsg)
		{
			bool retu;
			string Title = "Add User " + winDomain +"/"+ winUserName + " to Group WinNT://"+ destinationDomain+ "/" + destinationServer + "/" + destinationGroup;
			errorMsg= string.Empty;

			if ((destinationDomain == null) || (destinationDomain == string.Empty))
				destinationDomain = winDomain;
			if ((destinationServer == null) || (destinationServer == string.Empty))
				destinationServer = getActiveDomainController();

			DirectoryEntry entry = new DirectoryEntry("WinNT://"+ destinationDomain+ "/" + destinationServer + ",computer" ); 
			try
			{
				//entry.Invoke("add",new object[]{"WinNT://" + m_windomain +"/"+ m_username}); 

				DirectoryEntry grp = entry.Children.Find(destinationGroup, "group"); 
				if (grp.Name != null) 
					grp.Invoke("Add", new Object[] {"WinNT://" + winDomain +"/"+ winUserName}); 

				grp.CommitChanges(); 
				grp.Close(); 
				entry.Close();
				retu= true;
			}
			catch (TargetInvocationException et)
			{
				retu= false;
				errorMsg= et.InnerException.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, 0, Title, errorMsg, true, true);
			}
			catch (Exception ex)
			{
				retu= false;
				errorMsg= "Unknown Exception";
				currLog.registerLog(CLogger.TYPE_ERROR, 0, Title, errorMsg, true, true);
			}
			return retu;
		}

		public bool AD_RemoveUserFromGroup(string sourceDomain , string sourceServer, string sourceGroup)
		{
			bool retu;
			string Title = "Remove User " + winDomain +"/"+ winUserName + " from Group WinNT://"+ sourceDomain+ "/" + sourceServer + "/" + sourceGroup;
			string errorMsg= string.Empty;
			if (sourceDomain == null)
				sourceDomain = winDomain;

			if ((sourceDomain == null) || (sourceDomain == string.Empty))
				sourceDomain = winDomain;
			if ((sourceServer == null) || (sourceServer == string.Empty))
				sourceServer = getActiveDomainController();

			DirectoryEntry entry = new DirectoryEntry("WinNT://"+ sourceDomain+ "/" + sourceServer + ",computer" ); 
			try
			{
				//entry.Invoke("add",new object[]{"WinNT://" + m_windomain +"/"+ m_username}); 

				DirectoryEntry grp = entry.Children.Find(sourceGroup, "group"); 
				if (grp.Name != null) 
					grp.Invoke("Remove", new Object[] {"WinNT://" + winDomain +"/"+ winUserName}); 

				grp.CommitChanges(); 
				grp.Close(); 
				entry.Close();
				retu= true;
			}
			catch (Exception ex)
			{
				retu= false;
				errorMsg= "Unknown Exception";
				currLog.registerLog(CLogger.TYPE_ERROR, 0, Title, errorMsg, true, true);
			}
			return retu;
		}

		public void UpdateCheckedUsrPwd(WinDomainUsersFactory WinGlobalUsrFac, DateTime currDateTime)
		{
			//WinGlobalUsrFac.UpdateCheckedUsrPwd(dalGlobalUser, currDateTime);
		}

		public void UpdateChangedUsrPwd(WinDomainUsersFactory WinGlobalUsrFac, DateTime currDateTime)
		{
			if (password.getPassword != string.Empty)
				winUserPassword= password.getPassword;
			//WinGlobalUsrFac.UpdateChangedUsrPwd(dalGlobalUser, currDateTime);
		}
	}
}
