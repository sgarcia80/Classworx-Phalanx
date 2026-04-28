using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace phxBlowfish
{
	/// <summary>
	/// Summary description for CBlowfish.
	/// </summary>
	public class CBlowfish
	{
		//private HashAlgorithm EncodeMethod;
		private BlowfishAlgorithm EncodeMethod;
		public CBlowfish()
		{
			EncodeMethod = new BlowfishAlgorithm();
			EncodeMethod.Mode = CipherMode.CBC;
			EncodeMethod.KeySize = 40;
			EncodeMethod.GenerateKey();
			EncodeMethod.GenerateIV();
		}

		public string Encrypt(string Source, string Key)
		{
			long lLen;
			int nRead, nReadTotal;
			byte[] buf = new byte[3];
			byte[] srcData;
			byte[] encData;
			System.IO.MemoryStream sin;
			System.IO.MemoryStream sout;
			CryptoStream encStream;
			
			srcData = System.Text.ASCIIEncoding.ASCII.GetBytes(Source);
			sin = new MemoryStream();
			sin.Write(srcData,0,srcData.Length);
			sin.Position = 0;
			sout = new MemoryStream();
				
			EncodeMethod.Key = getValidKey(Key);
			EncodeMethod.IV = getValidIV(Key, EncodeMethod.IV.Length); 

			encStream = new CryptoStream(sout, 
				EncodeMethod.CreateEncryptor(), 
				CryptoStreamMode.Write);
			lLen = sin.Length;
			nReadTotal = 0;
			while (nReadTotal < lLen)
			{
				nRead = sin.Read(buf, 0, buf.Length);
				encStream.Write(buf, 0, nRead);
				nReadTotal += nRead;
			}
			encStream.Close();  
				
			encData = sout.ToArray();
			return System.Convert.ToBase64String(encData);
		}

		public string Decrypt(string Source, string Key)
		{
			if(Source==null || Key==null || Source.Length==0 || Key.Length == 0)
				return null;
				
			if(EncodeMethod == null) return "Under Construction";

			long lLen;
			int nRead, nReadTotal;
			byte[] buf = new byte[3];
			byte[] decData;
			byte[] encData;
			System.IO.MemoryStream sin;
			System.IO.MemoryStream sout;
			CryptoStream decStream;

			try
			{
				encData = System.Convert.FromBase64String(Source);
				sin = new MemoryStream(encData);
				sout = new MemoryStream();
						
				EncodeMethod.Key = getValidKey(Key);
				EncodeMethod.IV = getValidIV(Key, EncodeMethod.IV.Length); 

				decStream = new CryptoStream(sin, 
					EncodeMethod.CreateDecryptor(), 
					CryptoStreamMode.Read);
						
				lLen = sin.Length;
				nReadTotal = 0;
				while (nReadTotal < lLen)
				{
					nRead = decStream.Read(buf, 0, buf.Length);
					if (0 == nRead) break;
					
					sout.Write(buf, 0, nRead);
					nReadTotal += nRead;
				}
						
				decStream.Close();  
				decData = sout.ToArray();

				ASCIIEncoding ascEnc = new ASCIIEncoding();
				//return ascEnc.GetString(decData);
                // los replace es porque llena con esos ascii no imprimibles
                return ascEnc.GetString(decData).Replace((char)1, (char)0).Replace((char)2, (char)0)
                    .Replace((char)3, (char)0).Replace((char)4, (char)0).Replace((char)5, (char)0).
                    Replace((char)8, (char)0).Replace((char)6, (char)0).Replace((char)7, (char)0);

			}
			catch(FormatException e)
			{
				return null;
			}

			
		}

		private byte[] getValidKey(string Key)
		{
			string sTemp;
			if (EncodeMethod.LegalKeySizes.Length > 0)
			{
				int lessSize = 0, moreSize = EncodeMethod.LegalKeySizes[0].MinSize;
				// key sizes are in bits
				
				while (Key.Length * 8 > moreSize && 
					EncodeMethod.LegalKeySizes[0].SkipSize > 0 && 
					moreSize < EncodeMethod.LegalKeySizes[0].MaxSize)
				{
					lessSize = moreSize;
					moreSize += EncodeMethod.LegalKeySizes[0].SkipSize;
				}

				if(Key.Length * 8 > moreSize)
					sTemp = Key.Substring(0, (moreSize / 8));
				else
					sTemp = Key.PadRight(moreSize / 8, ' ');
			}
			else
				sTemp = Key;
			// convert the secret key to byte array
			return ASCIIEncoding.ASCII.GetBytes(sTemp);
		}

		private byte[] getValidIV(String InitVector, int ValidLength)
		{
			if( InitVector.Length > ValidLength ) 
			{
				return ASCIIEncoding.ASCII.GetBytes(InitVector.Substring(0, ValidLength));
			} 
			else 
			{
				return ASCIIEncoding.ASCII.GetBytes(InitVector.PadRight(ValidLength,' '));
			}
		}
	}
}
