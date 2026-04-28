using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace phxCryptMgr
{
    public class phxCryptAES
    {
        protected static string m_keyAesConfigFile = "???60'??";

        // Function to Generate a 64 bits Key.
        //public static string GenerateKey()
        //{
        //    // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
        //    DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

        //    // Use the Automatically generated key for Encryption. 
        //    return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        //}

        public static void EncryptFile(string sInputFilename, string sOutputFilename)//, string sKey)
        {
            string sKey = m_keyAesConfigFile;

            FileStream fsInput = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            fsInput.Close();

            FileStream fsEncrypted = new FileStream(sInputFilename, //sOutputFilename,
               FileMode.Create,
               FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform desencrypt = DES.CreateEncryptor();

            CryptoStream cryptostream = new CryptoStream(fsEncrypted,
               desencrypt,
               CryptoStreamMode.Write);


            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();

            fsEncrypted.Close();
        }

        public static void DecryptFile(string sInputFilename, string sOutputFilename) //, string sKey)
        {
            string sKey = m_keyAesConfigFile;

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
               desdecrypt,
               CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        public static string[] DecryptFile(string sInputFilename)
        {
            List<string> lineas = new List<string>();

            string sKey = m_keyAesConfigFile;

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
               desdecrypt,
               CryptoStreamMode.Read);

            using (StreamReader reader = new StreamReader(cryptostreamDecr))
            {
                while (reader.Peek() >= 0)
                {
                    lineas.Add(reader.ReadLine());
                }
            }

            return lineas.ToArray();
        }
    }
}
