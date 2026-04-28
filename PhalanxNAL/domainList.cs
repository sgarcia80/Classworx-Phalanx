using System;
using System.Collections;
using System.Runtime.InteropServices;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for domainList.
	/// </summary>
	public class CDomainList
	{
		public CDomainList()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public CDomain getDomain(string domainName)
		{
			CDomain selectDomain = null;
			foreach (CDomain currDomain in Net_FindDomains((uint)common.ServerType.SV_TYPE_DOMAIN_ENUM))
			{
				if (currDomain.ntName.ToLower() == domainName.ToLower())
				{
					selectDomain = currDomain;
					break;
				}
			}
			return selectDomain;
					
		}

        public WinDomainEntityCollection getDomainList()
		{
			return Net_FindDomains((uint)common.ServerType.SV_TYPE_DOMAIN_ENUM);
					
		}


        private WinDomainEntityCollection Net_FindDomains(uint serverType)
		{			
			//UInt32.Parse(Enum.Format(typeof(ServerType), (ServerType.SV_TYPE_DOMAIN_ENUM), "x"), System.Globalization.NumberStyles.HexNumber)
			
			int entriesread;  // number of entries actually read
			int totalentries; // total visible servers and workstations
			int result;		  // result of the call to NetServerEnum
			string _lastError = "";

			IList resultDom;
            WinDomainEntityCollection WinDomEC = new WinDomainEntityCollection();

			resultDom = new ArrayList();

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
				if(result != 0) 
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
							_lastError = "Unknown error code "+result;
							break;
					}					
				}
				else
				{
					//_computers = new NetworkComputers[entriesread];

					int tmp = (int)pBuf;
					for(int i = 0; i < entriesread; i++ )
					{
						// fill our struct
						si = (common.SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmp, svType);
						//_computers[i] = new NetworkComputers(si);

						CDomain currDom = new CDomain(si.sv101_name);
						currDom.platform_id = si.sv101_platform_id;
						currDom.type = si.sv101_type; 
						currDom.comment = si.sv101_comment;

                        WinDomainEntity WinDomE = new WinDomainEntity();
                        WinDomE.NtName = si.sv101_name;

                        WinDomEC.Add(WinDomE);

						resultDom.Add(currDom);
						tmp += Marshal.SizeOf(svType);
					}
				}
			}
			finally
			{
				// free the buffer
				common.NetApiBufferFree(pBuf); 
				pBuf = IntPtr.Zero;
			}
            return WinDomEC;
			//return resultDom;
		}
	}

}
