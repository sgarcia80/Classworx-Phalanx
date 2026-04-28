using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CImpersonate
	{
		private string m_domUserName;
		private string m_domName; 
		private string m_dompassword;
		private WindowsImpersonationContext impersonatedUser = null;
		private IntPtr tokenHandle;
		private	IntPtr dupeTokenHandle;
		public bool IsImpersonated= false;

		[DllImport("advapi32.dll", SetLastError=true)]
		public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, 
			int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

		[DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		public extern static bool DuplicateToken(IntPtr ExistingTokenHandle, 
			int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		public extern static bool CloseHandle(IntPtr handle);

		public CImpersonate()
		{
			m_domUserName= null;
			m_domName= null;
			m_dompassword= null;
			beginImpersonate();
		}
		
		public CImpersonate(string domUserName, string domName, string dompassword)
		{
			m_domUserName= domUserName;
			m_domName= domName;
			m_dompassword= dompassword;
			beginImpersonate();
		}


		private bool beginImpersonate()
		{

			tokenHandle = new IntPtr(0);
			dupeTokenHandle = new IntPtr(0);

			if ((m_domName == null) && (m_dompassword == null) && (m_domUserName == null))
			{
				//string domUserName, domName, dompassword;
				//getDomainInfo(out domUserName, out domName, out dompassword);
				getDomainInfo(out m_domUserName, out m_domName, out m_dompassword);
			}

			bool returnValue = LogonUser(m_domUserName, m_domName, m_dompassword, 
				common.LOGON32_LOGON_INTERACTIVE, common.LOGON32_PROVIDER_DEFAULT,
				ref tokenHandle);

/*			returnValue = DuplicateToken(tokenHandle, SecurityImpersonation, ref dupeTokenHandle);
			if (false == retVal)
			{
				CloseHandle(tokenHandle);
				return false;
			}
*/
			if (returnValue)
			{
				try
				{
					WindowsIdentity newId = new WindowsIdentity(tokenHandle); //dupeTokenHandle);
					impersonatedUser = newId.Impersonate();
				}
				finally
				{
					IsImpersonated = true;
				}

			}
			
			return returnValue;
		}

		public bool closeImpersonate()
		{
			if (impersonatedUser != null)
				impersonatedUser.Undo();
			if (tokenHandle != IntPtr.Zero)
				CloseHandle(tokenHandle);
			if (dupeTokenHandle != IntPtr.Zero) 
				CloseHandle(dupeTokenHandle);
   
			return true;
		}

		private bool getDomainInfo(out string userName, out string domainName, out string password)
		{
			userName= "administrator";
			domainName= "sistemas";
			password= "cwxcwx";
			return true;
		}


	}
}
