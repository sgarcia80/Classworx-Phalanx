using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PhalanxBL.Net
{
    class Common
    {
        public const int SUCCESS = 0;

        // CPASSWORD Return Codes -------------------------------------------
        public const uint CPASS_ERR_UNKNOWN = 0x80005000;
        public const uint CPASS_ERR_INVALID_COMPUTER = 0x80070035;
        public const uint CPASS_ERR_INVALID_PASSWORD = 0x80070001;
        public const uint CPASS_ERR_INVALID_USER = 0x800708ad;
        // CPASSWORD Return Codes -------------------------------------------

        public const int NERR_BASE = 2100;

        public const int ERROR_ACCESS_DENIED = 5;
        public const int ERROR_INVALID_PASSWORD = 86;
        public const int ERROR_NO_SUCH_MEMBER = 1387;
        public const int ERROR_MEMBER_IN_ALIAS = 1378;
        public const int ERROR_INVALID_MEMBER = 1388;

        public const int NERR_GroupNotFound = (NERR_BASE + 120);
        public const int NERR_InvalidComputer = 2351;
        public const int NERR_NotPrimary = 2226;
        public const int NERR_UserNotFound = 2221;
        public const int NERR_PasswordTooShort = 2245;
        public const int ERROR_CANT_ACCESS_DOMAIN_INFO = 1351;

        public const int LOGON32_PROVIDER_DEFAULT = 0;
        public const int LOGON32_LOGON_NETWORK = 3;
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int SecurityImpersonation = 2;

        public const int ERROR_MORE_DATA = 234;

        public const int FILTER_TEMP_DUPLICATE_ACCOUNT = 0x0001; // Local Users
        public const int FILTER_NORMAL_ACCOUNT = 0x0002;  // Global Users

        public const int PLATFORM_ID_DOS = 300;
        public const int PLATFORM_ID_OS2 = 400;
        public const int PLATFORM_ID_NT = 500;
        public const int PLATFORM_ID_OSF = 600;
        public const int PLATFORM_ID_VMS = 700;

        public const int UF_TEMP_DUPLICATE_ACCOUNT = 0x0100;
        public const int UF_NORMAL_ACCOUNT = 0x0200;
        public const int UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800;
        public const int UF_WORKSTATION_TRUST_ACCOUNT = 0x1000;
        public const int UF_SERVER_TRUST_ACCOUNT = 0x2000;


        /*
        FILTER_TEMP_DUPLICATE_ACCOUNT = $0001;
        FILTER_NORMAL_ACCOUNT = $0002;
        FILTER_PROXY_ACCOUNT = $0004;
        FILTER_INTERDOMAIN_TRUST_ACCOUNT = $0008;
        FILTER_WORKSTATION_TRUST_ACCOUNT = $0010;
        FILTER_SERVER_TRUST_ACCOUNT = $0020;
*/



        /*
                public enum ServerType : uint
                {
                    /// All workstations
                    SV_TYPE_WORKSTATION   = 0x00000001, // 1
                    /// All computers that have the server service running
                    SV_TYPE_SERVER    = 0x00000002, // 10
                    /// Any server running Microsoft SQL Server
                    SV_TYPE_SQLSERVER   = 0x00000004, //100
                    /// Primary domain controller
                    SV_TYPE_DOMAIN_CTRL   = 0x00000008,
                    /// Backup domain controller
                    SV_TYPE_DOMAIN_BAKCTRL  = 0x00000010,
                    /// Server running the Timesource service
                    SV_TYPE_TIME_SOURCE   = 0x00000020,
                    /// Apple File Protocol servers
                    SV_TYPE_AFP     = 0x00000040,
                    /// Novell servers
                    SV_TYPE_NOVELL    = 0x00000080,
                    /// LAN Manager 2.x domain member
                    SV_TYPE_DOMAIN_MEMBER  = 0x00000100,
                    /// Server sharing print queue
                    SV_TYPE_PRINTQ_SERVER  = 0x00000200,
                    /// Server running dial-in service
                    SV_TYPE_DIALIN_SERVER  = 0x00000400,
                    /// Xenix server
                    SV_TYPE_XENIX_SERVER  = 0x00000800,
                    /// Windows NT workstation or server
                    SV_TYPE_NT     = 0x00001000,
                    /// Server running Windows for Workgroups
                    SV_TYPE_WFW     = 0x00002000,
                    /// Microsoft File and Print for NetWare
                    SV_TYPE_SERVER_MFPN   = 0x00004000,
                    /// Server that is not a domain controller
                    SV_TYPE_SERVER_NT   = 0x00008000,
                    /// Server that can run the browser service
                    SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
                    /// Server running a browser service as backup
                    SV_TYPE_BACKUP_BROWSER  = 0x00020000,
                    /// Server running the master browser service
                    SV_TYPE_MASTER_BROWSER  = 0x00040000,
                    /// Server running the domain master browser
                    SV_TYPE_DOMAIN_MASTER  = 0x00080000,
                    /// Windows 95 or later
                    SV_TYPE_WINDOWS    = 0x00400000,
                    /// Root of a DFS tree
                    SV_TYPE_DFS     = 0x00800000,
                    /// Terminal Server
                    SV_TYPE_TERMINALSERVER  = 0x02000000,
                    /// Server clusters available in the domain
                    SV_TYPE_CLUSTER_NT   = 0x01000000,
                    /// Cluster virtual servers available in the domain
                    /// (Not supported for Windows 2000/NT)
                    SV_TYPE_CLUSTER_VS_NT  = 0x04000000,
                    /// IBM DSS (Directory and Security Services) or equivalent
                    SV_TYPE_DCE     = 0x10000000,
                    /// Return list for alternate transport
                    SV_TYPE_ALTERNATE_XPORT  = 0x20000000,
                    /// Return local list only
                    SV_TYPE_LOCAL_LIST_ONLY  = 0x40000000,
                    /// Lists available domains
                    SV_TYPE_DOMAIN_ENUM		=  0x80000000,
                    //ALL
                    SV_TYPE_ALL             =  0xFFFFFFFF  
                };
        */
        public enum ServerType : uint
        {
            SV_TYPE_WORKSTATION = 0x00000001,
            SV_TYPE_SERVER = 0x00000002,
            SV_TYPE_SQLSERVER = 0x00000004,
            SV_TYPE_DOMAIN_CTRL = 0x00000008,
            SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,
            SV_TYPE_TIME_SOURCE = 0x00000020,
            SV_TYPE_AFP = 0x00000040,
            SV_TYPE_NOVELL = 0x00000080,
            SV_TYPE_DOMAIN_MEMBER = 0x00000100,
            SV_TYPE_PRINTQ_SERVER = 0x00000200,
            SV_TYPE_DIALIN_SERVER = 0x00000400,
            SV_TYPE_XENIX_SERVER = 0x00000800,
            SV_TYPE_SERVER_UNIX = SV_TYPE_XENIX_SERVER,
            SV_TYPE_NT = 0x00001000,
            SV_TYPE_WFW = 0x00002000,
            SV_TYPE_SERVER_MFPN = 0x00004000,
            SV_TYPE_SERVER_NT = 0x00008000,
            SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
            SV_TYPE_BACKUP_BROWSER = 0x00020000,
            SV_TYPE_MASTER_BROWSER = 0x00040000,
            SV_TYPE_DOMAIN_MASTER = 0x00080000,
            SV_TYPE_SERVER_OSF = 0x00100000,
            SV_TYPE_SERVER_VMS = 0x00200000,
            SV_TYPE_WINDOWS = 0x00400000,  /* Windows95 and above */
            SV_TYPE_DFS = 0x00800000,  /* Root of a DFS tree */
            SV_TYPE_CLUSTER_NT = 0x01000000,  /* NT Cluster */
            SV_TYPE_DCE = 0x10000000,  /* IBM DSS (Directory and Security Services) or equivalent */
            SV_TYPE_ALTERNATE_XPORT = 0x20000000,  /* return list for alternate transport */
            SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,  /* Return local list only */
            SV_TYPE_DOMAIN_ENUM = 0x80000000,
            SV_TYPE_ALL = 0xFFFFFFFF  /* handy for NetServerEnum2 */
        };

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct SERVER_INFO_101
        {
            public int sv101_platform_id;
            public string sv101_name;
            public int sv101_version_major;
            public int sv101_version_minor;
            public uint sv101_type;
            public string sv101_comment;
        };

        [DllImport("Netapi32", CharSet = CharSet.Unicode)]
        public static extern int NetServerEnum(
            string servername,		// must be null
            int level,				// 100 or 101
            out IntPtr bufptr,		// pointer to buffer receiving data
            int prefmaxlen,			// max length of returned data
            out int entriesread,	// num entries read
            out int totalentries,	// total servers + workstations
            uint servertype,		// server type filter
            [MarshalAs(UnmanagedType.LPWStr)]
			string domain,			// domain to enumerate
            IntPtr resume_handle);

        [DllImport("netapi32.dll", EntryPoint = "NetApiBufferFree")]
        internal static extern void NetApiBufferFree(IntPtr bufptr);

        [DllImport("netapi32.dll", EntryPoint = "NetLocalGroupEnum")]
        internal static extern uint NetLocalGroupEnum(
            IntPtr ServerName,
            uint level,
            ref IntPtr siPtr,
            uint prefmaxlen,
            ref uint entriesread,
            ref uint totalentries,
            IntPtr resumeHandle);

        [DllImport("netapi32.dll", EntryPoint = "NetGroupEnum")]
        internal static extern uint NetGroupEnum(
            IntPtr ServerName,
            uint level,
            ref IntPtr siPtr,
            uint prefmaxlen,
            ref uint entriesread,
            ref uint totalentries,
            IntPtr resumeHandle);

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct LOCALGROUP_INFO_1
        {
            public IntPtr lpszGroupName;
            public IntPtr lpszComment;
        };

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct GROUP_INFO_3
        {
            public IntPtr lpszGroupName;
            public IntPtr lpszComment;
            public uint group_id;
            public int attributes;
        };

        [DllImport("netapi32.dll", EntryPoint = "NetUserEnum")]
        internal static extern uint NetUserEnum(
            //[DllImport("Netapi32.dll")]	extern static int 
            //			NetUserEnum(
                [MarshalAs(UnmanagedType.LPWStr)]string servername,
                uint level,
                int filter,
                ref IntPtr bufptr,
                uint prefmaxlen,
                ref uint entriesread,
                ref uint totalentries,
                IntPtr resume_handle
            );

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct USER_INFO_0
        {
            public string Username;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct USER_INFO_10
        {
            public string name;
            public string comment;
            public string usr_comment;
            public string full_name;
        };

    }
}
