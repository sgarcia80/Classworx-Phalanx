using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using System.Collections;

namespace PhalanxNAL
{
    public class NDomain
    {
        protected static int GROUP_INFO_3_SIZE;

        public NDomain()
        {
            unsafe
            {
                GROUP_INFO_3_SIZE = sizeof(common.GROUP_INFO_3);

            }
        }


        public WinDomainEntityCollection FindDomains(string filter)
        {
            //UInt32.Parse(Enum.Format(typeof(ServerType), (ServerType.SV_TYPE_DOMAIN_ENUM), "x"), System.Globalization.NumberStyles.HexNumber)

            int entriesread;  // number of entries actually read
            int totalentries; // total visible servers and workstations
            int result;		  // result of the call to NetServerEnum
            string _lastError = "";
            uint serverType= (uint)common.ServerType.SV_TYPE_DOMAIN_ENUM;

            WinDomainEntityCollection WinDomEC = new WinDomainEntityCollection();
            

            // Pointer to buffer that receives the data
            IntPtr pBuf = IntPtr.Zero;
            Type svType = typeof(common.SERVER_INFO_101);

            // structure containing info about the server
            common.SERVER_INFO_101 si;

            try
            {
                result = common.NetServerEnum(
                    null,
                    101,
                    out pBuf,
                    -1,
                    out entriesread,
                    out totalentries,
                    serverType,
                    null, //domainName,
                    IntPtr.Zero);

                // Successful?
                if (result != 0)
                {
                    switch (result)
                    {
                        case common.ERROR_MORE_DATA:
                            _lastError = "More data is available";
                            break;
                        case common.ERROR_ACCESS_DENIED:
                            _lastError = "Access was denied";
                            break;
                        default:
                            _lastError = "Unknown error code " + result;
                            break;
                    }
                }
                else
                {
                    int tmp = (int)pBuf;
                    for (int i = 0; i < entriesread; i++)
                    {
                        // fill our struct
                        si = (common.SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmp, svType);
                        //_computers[i] = new NetworkComputers(si);

                        bool validDom= true;
                        if (filter != null && filter.Length > 0)
                        {
                            if (si.sv101_name.ToUpper().IndexOf(filter.ToUpper()) == -1)
                                validDom= false;
                        }
                        if (validDom)
                        {
                            WinDomainEntity currDom = new WinDomainEntity();
                            currDom.NtName = si.sv101_name;
                            currDom.AdName = si.sv101_name;
                            currDom.Comments = si.sv101_comment;

                            WinDomEC.Add(currDom);
                        }
                        tmp += Marshal.SizeOf(svType);
                    }
                }
            }
            finally
            {
                common.NetApiBufferFree(pBuf);
                pBuf = IntPtr.Zero;
            }
            return WinDomEC;
        }

    }

}
