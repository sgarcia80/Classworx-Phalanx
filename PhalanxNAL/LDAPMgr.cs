using System.Collections;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System;

namespace PhalanxMAL
{
    public class LDAPMgr
    {       
        public LDAPMgr(String userName, String domain, String password)
        {
            if (impersonateValidUser(userName, domain, password))
            {
                strDebug += "Hizo impersonation | ";
            }
            else
            {
                strDebug += "NO Hizo impersonation | ";
                
            }

        }
        private string _ImpersonationUserName;
        private string _ImpersonationDomain;
        private string _ImpersonationPassword;

        #region Impersonation
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;

        WindowsImpersonationContext impersonationContext;

        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion

        private bool impersonateValidUser(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
            return false;
        }

        private void undoImpersonation()
        {
            impersonationContext.Undo();
        }

        private string strDebug = "";

        public ArrayList EnumerateOU(string OuDn)
        {
            //strDebug = "";

            ArrayList alObjects = new ArrayList();
            //try
            //{
            //DirectoryEntry directoryObject = new DirectoryEntry(@"LDAP://" + OuDn);
            //DirectoryEntry directoryObject = new DirectoryEntry(OuDn, "administrador", "cascas");
            DirectoryEntry directoryObject = new DirectoryEntry(OuDn);
            //strDebug += "pasó DirectoryEntry(" + OuDn + ")";
            foreach (DirectoryEntry child in directoryObject.Children)
            {
                //strDebug += "entra a foreach";
                string childPath = child.Path.ToString();
                alObjects.Add(childPath.Remove(0, 7));
                //remove the LDAP prefix from the path

                child.Close();
                child.Dispose();
            }
            //strDebug += "directoryObject.Close";
            directoryObject.Close();
            //strDebug += "directoryObject.Dispose";
            directoryObject.Dispose();
            //}
            //catch (DirectoryServicesCOMException e)
            //{
            //    Console.WriteLine("An Error Occurred: " + e.Message.ToString());
            //}
            return alObjects;
        }
        public ArrayList EnumerateOU(string OuDn, string ImpersonationUser, string ImpersonationPassword)
        {
            strDebug = "";

            ArrayList alObjects = new ArrayList();
            //try
            //{
            //DirectoryEntry directoryObject = new DirectoryEntry(@"LDAP://" + OuDn);
            DirectoryEntry directoryObject = new DirectoryEntry(OuDn, ImpersonationUser, ImpersonationPassword);
            //DirectoryEntry directoryObject = new DirectoryEntry(OuDn);
            strDebug += "pasó DirectoryEntry(" + OuDn + ")";
            foreach (DirectoryEntry child in directoryObject.Children)
            {
                //strDebug += "entra a foreach";
                string childPath = child.Path.ToString();
                alObjects.Add(childPath.Remove(0, 7));
                //remove the LDAP prefix from the path

                child.Close();
                child.Dispose();
            }
            //strDebug += "directoryObject.Close";
            directoryObject.Close();
            //strDebug += "directoryObject.Dispose";
            directoryObject.Dispose();
            //}
            //catch (DirectoryServicesCOMException e)
            //{
            //    Console.WriteLine("An Error Occurred: " + e.Message.ToString());
            //}
            return alObjects;
        }
    }
}
