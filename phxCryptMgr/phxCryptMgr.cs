using System;
using phxBlowfish;
using System.Security.Cryptography;

namespace phxCryptMgr
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CCryptMgr
	{
		protected CBlowfish Blwfsh;
		protected string m_keyBlowfish = "12345678901234567890123456789012345678901234567890123456";
        protected string m_keyBlowfishConfigFile = "qweoimcbadfh837bwcmchge9230càejafhnrybefh28yvb<,mvn.eyba";
		
		public CCryptMgr() //por ahora solo trabaja con Blowfish
		{
			Blwfsh = new CBlowfish();			
		}

		public string encrypt(string Source)
		{
			return Blwfsh.Encrypt(Source, m_keyBlowfish);
		}

		public string decrypt(string Source)
		{
			return Blwfsh.Decrypt(Source, m_keyBlowfish);
		}

        public string decryptAndClearBadChars(string Source)
        {
            string pwd = Blwfsh.Decrypt(Source, m_keyBlowfish);
            string auxstr = pwd.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }

        public string encryptConfigFile(string Source)
        {
            return Blwfsh.Encrypt(Source, m_keyBlowfishConfigFile);
        }

        public string decryptConfigFileAndClearBadChars(string Source)
        {
            string pwd = Blwfsh.Decrypt(Source, m_keyBlowfishConfigFile);
            string auxstr = pwd.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }

	}

	public class CMd5Mgr
	{
		private HashAlgorithm EncodeMethod;

		public CMd5Mgr()
		{
			EncodeMethod = new MD5CryptoServiceProvider();
		}

		public string encrypt(string Source)
		{
			string auxSource= Source + Source.Length.ToString() + Source.Substring(1,1) + "CLASSWORX-PALANX";
			auxSource+= Convert.ToByte(Source).ToString();
			
			byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(auxSource);
			byte[] bytOut = EncodeMethod.ComputeHash(bytIn);
			
			return System.Convert.ToBase64String(bytOut, 0, bytOut.Length);
		}
	}
}
