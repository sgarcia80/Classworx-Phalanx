using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net;

namespace PhalanxNAL
{
    public class NPc
    {
        protected static int LOCALGROUP_INFO_1_SIZE;


        public NPc()
        {
            unsafe
            {
                LOCALGROUP_INFO_1_SIZE = sizeof(common.LOCALGROUP_INFO_1);
            }
        }
        
        public static string[] GetServerList(common.ServerType serverType)
        {

            IntPtr lpBuffer = IntPtr.Zero;
            IntPtr lpTmpBuffer = IntPtr.Zero;
            Int32 dwEntriesRead = 0;
            Int32 dwTotalEntries = 0;
            //Int32 dwResumeHandle = 0;
            common.SERVER_INFO_101 se101 = new common.SERVER_INFO_101();
            Int32 nStructSize = 0;
            string[] servers = null;

            nStructSize = Marshal.SizeOf(se101);
            Int32 iRet = common.NetServerEnum(null,
                                        101,
                                        out lpBuffer,
                                        common.MAX_PREFERRED_LENGTH,
                                        out dwEntriesRead,
                                        out dwTotalEntries,
                                        (uint)serverType,
                                        null,
                                        IntPtr.Zero);

            if ((iRet == common.NERR_SUCCESS) && (iRet != common.ERROR_MORE_DATA))
            {
                servers = (string[])Array.CreateInstance(typeof(string), dwEntriesRead);
                lpTmpBuffer = lpBuffer;
                for (Int32 i = 0; i < dwEntriesRead; i++)
                {
                    se101 = (common.SERVER_INFO_101)Marshal.PtrToStructure(lpTmpBuffer, se101.GetType());
                    servers[i] = se101.sv101_name;
                    lpTmpBuffer = new IntPtr(lpTmpBuffer.ToInt32() + nStructSize);
                }
            }
            
            if (!lpBuffer.Equals(IntPtr.Zero))
                common.NetApiBufferFree(lpBuffer);

            return servers;
        }

        public WinPCEntityCollection FindWinComputers(WinDomainEntity domain, string filter)
        {
            int entriesread;  // number of entries actually read
            int result;
            int totalentries; // total visible servers and workstations
            string _lastError = "";
            WinPCEntityCollection resultPC = new WinPCEntityCollection();

            uint serverType = (uint)common.ServerType.SV_TYPE_ALL;

            // Pointer to buffer that receives the data
            IntPtr pBuf = IntPtr.Zero;
            Type svType = typeof(common.SERVER_INFO_101);

            // structure containing info about the server
            common.SERVER_INFO_101 si;

            string domainName = null;
            if (domain != null)
                domainName= domain.NtName;
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
                    domainName,
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

                        bool validPC= true;
                        if (filter != null && filter.Length > 0)
                        {
                            if (si.sv101_name.ToUpper().IndexOf(filter.ToUpper()) == -1)
                                validPC= false;
                        }
                        if (validPC)
                        {
                            WinPCEntity newPC = new WinPCEntity();
                            newPC.Name = si.sv101_name;
                            try
                            {
                                newPC.PcIP = System.Net.Dns.GetHostEntry(si.sv101_name).AddressList[0].ToString();
                            }
                            catch 
                            {
                                newPC.PcIP = "";                            
                            }
                            newPC.WinDomain = domain;
                            resultPC.Add(newPC);
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
            return resultPC;
        }

        public UnixPCEntityCollection FindUnixComputers(string filter)
        {
            int entriesread;  // number of entries actually read
            int result;
            int totalentries; // total visible servers and workstations
            string _lastError = "";
            UnixPCEntityCollection resultPC = new UnixPCEntityCollection();

            uint serverType = (uint)common.ServerType.SV_TYPE_SERVER_UNIX;

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
                    null,
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

                                                bool validPC= true;
                        if (filter != null && filter.Length > 0)
                        {
                            if (si.sv101_name.ToUpper().IndexOf(filter.ToUpper()) == -1)
                                validPC= false;
                        }
                        if (validPC)
                        {

                            UnixEntity newPC = new UnixEntity();
                            newPC.ServerName = si.sv101_name;
                            newPC.Ip = System.Net.Dns.GetHostEntry(si.sv101_name).AddressList[0].ToString();
                            resultPC.Add(newPC);
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
            return resultPC;
        }

        public string PcPing(string RemoteComputer)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 500;
            try
            {
                PingReply reply = pingSender.Send(RemoteComputer, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    return "Se realizó Ping con éxito";
                }
                else
                {
                    return "No se pudo realizar Ping. Status: " + reply.Status.ToString();
                }
            }
            catch (System.Net.NetworkInformation.PingException e)
            {
                return "No se pudo realizar Ping. Error: " + e.InnerException.Message;

                /*Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);*/
            }
            //IPHostEntry hostInfo = Dns.GetHostEntry("www.contoso.com");

        }
        public bool PingOK(string RemoteComputer)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 500;
            try
            {
                PingReply reply = pingSender.Send(RemoteComputer, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    //return "Se realizó Ping con éxito";
                    return true;
                }
                else
                {
                    //return "No se pudo realizar Ping. Status: " + reply.Status.ToString();
                    return false;
                }
            }
            catch (System.Net.NetworkInformation.PingException e)
            {
                //return "No se pudo realizar Ping. Error: " + e.InnerException.Message;
                return false;

                /*Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);*/
            }
            //IPHostEntry hostInfo = Dns.GetHostEntry("www.contoso.com");

        }
        public string ResolveHostName(string IPAddr)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(IPAddr);
                //return "Nombre del equipo: " + hostInfo.HostName;
                return hostInfo.HostName;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                //return "Mensaje de error:" + e.Message + ". Error: " + e.ErrorCode.ToString();
                return "";
            }
        }
    }

}
