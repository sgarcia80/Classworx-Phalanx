using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Data;
//using System.Net;
//using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Reflection;
using phxLog;
using phxCryptMgr;
using PhalanxDAL;
using PhalanxDAL.Data;
using System.Text;
using System.DirectoryServices;


//using System.Collections.Specialized;
namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CPassword
	{

		//		private UsersPasswords
		private string m_password = string.Empty;
		private string m_domainname;
		private string m_computername;
		private string m_username;
		public bool tryImpersonate = false;
		
		//Generación de Password----------------------------
		protected int maxLong = 12;
		protected bool can_Numeric = true;
		protected bool can_CapitalLetter = true;
		protected bool can_SpecialChars = false;
		
		protected char[] numbers = new char[10] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
		protected char[] letters = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'k', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
		protected char[] capitalLetters = new char[26] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'K', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
		protected char[] specialChars = new char[11] {(char)95, (char)33, (char)35, (char)36, (char)37, (char)38, (char)58, (char)59, (char)61, (char)63, (char)64};
									//					_			!		#			$		%			&		:			;		=			?		@
		//--------------------------------------------------

		protected string pathIni = "c:\\classworx\\phalanx\\inis\\phalanx.ini";
		protected string pathLog = "c:\\classworx\\phalanx\\logs\\phxLog.txt";

		public string getPassword
		{
			get
			{
					return m_password;
			}
		}
		private CLogger currLog; 

		[DllImport("netapi32.dll", CharSet=CharSet.Auto)]
		public static extern uint NetUserChangePassword( 
			string domainName, string userName, string oldPass, string newPass);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,
			string key,string def, StringBuilder retVal,
			int size,string filePath);


		public CPassword(string domainname, string computername, string username, string currPassword )
		{
			m_domainname= domainname;
			m_computername= computername;
			m_username= username;
			m_password = currPassword;
			
			string level= IniReadValue("Log", "USERMANAGER", this.pathIni);
			uint ilevel = 1;
			try
			{
				ilevel = Convert.ToUInt32(level);
			}
			catch
			{
				ilevel = 1;
			}
			currLog = new CLogger(ilevel);
			currLog.LogFilePath = pathLog; 
		}
		
		public CPassword(string domainname, string computername, string username)
		{
			m_domainname= domainname;
			m_computername= computername;
			m_username= username;
			currLog = new CLogger();
			currLog.LogFilePath = "C:\\Classworx\\Phalanx\\logs\\phxLog.txt"; 
		}

		public uint validatePassword(string password)
		{
			m_password = password;
			return validatePassword();
		}
		public uint validatePassword()
		{
			uint retu = common.CPASS_ERR_UNKNOWN;
			string Title = "Check Password WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username;
			string errorMsg= string.Empty;

			DirectoryEntry obDirEntry = null;			
			try
			{
				obDirEntry = new DirectoryEntry("WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username+",User");
				obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
				obDirEntry.Invoke("ChangePassword", new object[]{m_password, m_password });
				obDirEntry.CommitChanges(); 
				obDirEntry.Close(); 
				retu= 0;
			}		
			catch (COMException ex)
			{
				retu= (uint)ex.ErrorCode;					
				errorMsg= ex.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (TargetInvocationException et)
			{
				errorMsg= et.InnerException.Message;
				int ErrorDeDirectivas = errorMsg.IndexOf("no ccumple con los requisitos de la directiva");
				if ( ErrorDeDirectivas < 0)
				{
					// chequea en inglés
					ErrorDeDirectivas = errorMsg.IndexOf("does not meet the password policy requirements");
				}
				if ( ErrorDeDirectivas > -1)
				{
					// si da error de requisitos de directiva de contraseña, es porque el chequeo ya lo hizo y fue OK
					// si el pwd pasado es NOK no llega a dar este error sino directamente dice pwd NOK
					// 2147942401
					// "La contraseña no cumple con los requisitos de la directiva de contraseña. Compruebe los requisitos de longitud mínima, complejidad e historial de la contraseña."
					// "The password does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements."
					retu = 0;
				}
				else
				{
					retu= common.CPASS_ERR_INVALID_PASSWORD; 
					currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
				}
			}
			catch (Exception e)
			{
				retu= common.CPASS_ERR_UNKNOWN;					
				errorMsg= "Unknown Exception";
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			return retu;
		}
		
		public uint forcePassword(string newPassword)
		{
			uint retu = common.CPASS_ERR_UNKNOWN;
			string Title = "Force Password WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username;
			string errorMsg= string.Empty;

			DirectoryEntry obDirEntry = null;			
			try
			{
				obDirEntry = new DirectoryEntry("WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username+",User");
				obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
				obDirEntry.Invoke("SetPassword", new object[]{newPassword});
				obDirEntry.CommitChanges(); 
				obDirEntry.Close(); 
				m_password = newPassword;
				retu= 0;
			}		
			catch (COMException ex)
			{
				retu= (uint)ex.ErrorCode;					
				errorMsg= ex.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (TargetInvocationException et)
			{
				retu= common.CPASS_ERR_INVALID_PASSWORD; 
				errorMsg= et.InnerException.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (Exception e)
			{
				retu= common.CPASS_ERR_UNKNOWN;					
				errorMsg= "Unknown Exception";
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			return retu;
		}

		public uint changePasswordRandom()
		{
			string newpassword= generateNewPassword();
			return changePassword(newpassword);
		}
		public uint changePasswordRandom(string oldpassword, out string newpassword)
		{
			m_password = oldpassword;
			return changePasswordRandom(out newpassword);
		}
		public uint changePasswordRandom(out string newpassword)
		{
			newpassword= generateNewPassword();
			return changePassword(newpassword);
		}
		
		public uint changePassword(string oldpassword, string newpassword)
		{
			m_password = oldpassword;
			return changePassword(newpassword);
		}

		public uint changePassword(string newpassword)
		{
			uint retu = common.CPASS_ERR_UNKNOWN;
			string Title = "Change Password WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username;
			string errorMsg= string.Empty;

			DirectoryEntry obDirEntry = null;			
			try
			{
				obDirEntry = new DirectoryEntry("WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username+",User");
				//obDirEntry = new DirectoryEntry("WinNT://"+m_computername+"/"+m_username+",User");
				obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
					
				object[] oPassword = new object[] {newpassword}; 
				obDirEntry.Invoke("setPassword", oPassword); 
				//obDirEntry.Invoke("ChangePassword", new object[]{m_password, newpassword });
				obDirEntry.CommitChanges(); 
				obDirEntry.Close(); 

				m_password= newpassword;
				retu= 0;
			}		
			catch (COMException ex)
			{
				retu= (uint)ex.ErrorCode;					
				errorMsg= ex.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (TargetInvocationException et)
			{
				retu= common.CPASS_ERR_INVALID_PASSWORD; 
				errorMsg= et.InnerException.Message;
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (Exception e)
			{
				retu= common.CPASS_ERR_UNKNOWN;					
				errorMsg= "Unknown Exception";
				currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);

			}
			return retu;
		}

		private string generateNewPassword()
		{
			string newpassword= string.Empty;
/*
			bool set_CharAlfanumeric= false;
			bool set_CapitalLetter= false;
			bool set_SpecialChars= false;
*/
			Random currRandom = new Random(unchecked((int)DateTime.Now.Ticks)); 

			for (int i=0; i < maxLong; i++)
			{
				switch (currRandom.Next(1, 6))
				{
					case 1:{ //charAlfanumeric
						if (can_Numeric)
						{
							newpassword+= numbers[currRandom.Next(1, numbers.Length)];
//							set_CharAlfanumeric= true;
						}
						else
						{
							newpassword+= letters[currRandom.Next(1, letters.Length)];
						}
						break;
					}
					case 2:{//capitalLetter
						if (can_CapitalLetter)
						{
							newpassword+= capitalLetters[currRandom.Next(1, capitalLetters.Length)];
//							set_CapitalLetter= true;
						}
						else
						{
							newpassword+= letters[currRandom.Next(1, letters.Length)];
						}
						break;
					}
					case 3:{//specialChars
						if (can_SpecialChars)
						{
							newpassword+= specialChars[currRandom.Next(1, specialChars.Length)];
//							set_SpecialChars= true;
						}
						else
						{
							newpassword+= letters[currRandom.Next(1, letters.Length)];
						}
						break;
					}
					default:{ //4 y 5 normal
						newpassword+= letters[currRandom.Next(1, letters.Length)];
						break;
					}
				}
			
			}
/*
			if (!set_CharAlfanumeric)
			{
			}
			if (!set_CapitalLetter)
			{
			}
			if (!set_SpecialChars)
			{
			}
*/
			currLog.registerLog(CLogger.TYPE_AUDIT, 30, 0, "CPasswword", "NewPassword: " + newpassword, true, true);
			return newpassword;
		}

		private string IniReadValue(string Section,string Key, string currPath)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Section,Key,"",temp, 
				255, currPath);
			return temp.ToString();
		}

	}
}
