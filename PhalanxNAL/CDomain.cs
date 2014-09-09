using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;

namespace PhalanxNAL
{
    public class CDomain
    {
        private string m_ntName;
        private string m_adName;

        public int platform_id;
        public uint type;
        public string comment;
        protected static int GROUP_INFO_3_SIZE;

        public string activeDomainController
        {
            get
            {
                return GetActiveDomainController();
            }
        }

        public string ntName
        {
            get
            {
                return m_ntName;
            }
        }

        public string adName
        {
            get
            {
                return m_adName;
            }
        }

        public CDomain(string ntName, string adName)
        {
            m_ntName = ntName;
            m_adName = adName;
            CommonContructor();
        }

        public CDomain(string ntName)
        {
            m_ntName = ntName;
            m_adName = ntName;
            CommonContructor();
        }
        public CDomain()
        {
            CommonContructor();
        }

        private void CommonContructor()
        {
            unsafe
            {
                GROUP_INFO_3_SIZE = sizeof(common.GROUP_INFO_3);

            }
        }

        public IList getDCs()
        {
            IList currList = new ArrayList();

            foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_CTRL, m_ntName))
            {
                currList.Add(currPC);
            }

            foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL, m_ntName))
            {
                currList.Add(currPC);
            }

            return currList;
        }
        
        public WinDomainControllerEntityCollection getDCs(WinDomainEntity Domain)
        {
            WinDomainControllerEntityCollection WinDCEC = new WinDomainControllerEntityCollection();
            foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_CTRL, Domain.NtName))
            {
                WinPCEntity newPC = new WinPCEntity();
                newPC.Name = currPC.pc_name;
                newPC.PcIP = currPC.pc_ip;
                newPC.WinDomain = Domain;
                WinDomainControllerEntity newPDC = new WinDomainControllerEntity();
                newPDC.Type = "P";
                newPDC.WinPc = newPC;
                newPDC.WinDomain = Domain;
                WinDCEC.Add(newPDC);
            }

            foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL, Domain.NtName))
            {
                WinPCEntity newPC = new WinPCEntity();
                newPC.Name = currPC.pc_name;
                newPC.Name = currPC.pc_ip;
                newPC.WinDomain = Domain;
                WinDomainControllerEntity newPDC = new WinDomainControllerEntity();
                newPDC.Type = "B";
                newPDC.WinPc = newPC;
                newPDC.WinDomain = Domain;
                WinDCEC.Add(newPDC);
            }
            return WinDCEC;
        }
        private IList Net_FindDomains(uint serverType)
        {
            //UInt32.Parse(Enum.Format(typeof(ServerType), (ServerType.SV_TYPE_DOMAIN_ENUM), "x"), System.Globalization.NumberStyles.HexNumber)

            int entriesread;  // number of entries actually read
            int totalentries; // total visible servers and workstations
            int result;		  // result of the call to NetServerEnum
            string _lastError = "";

            IList resultDom;

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
                    //_computers = new NetworkComputers[entriesread];

                    int tmp = (int)pBuf;
                    for (int i = 0; i < entriesread; i++)
                    {
                        // fill our struct
                        si = (common.SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmp, svType);
                        //_computers[i] = new NetworkComputers(si);

                        CDomain currDom = new CDomain(si.sv101_name);
                        currDom.platform_id = si.sv101_platform_id;
                        currDom.type = si.sv101_type;
                        currDom.comment = si.sv101_comment;

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
            return resultDom;
        }

        public string GetActiveDomainController()
        {
            string auxADC = string.Empty;

            foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_CTRL, m_ntName))
            {
                auxADC = currPC.pc_name;
                break;
            }

            if (auxADC == string.Empty)
            {
                foreach (CPc currPC in Net_FindComputers((uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL, m_ntName))
                {
                    auxADC = currPC.pc_name;
                    break;
                }
            }
            return auxADC;
        }

        private IList Net_FindComputers(uint serverType, string domainName)
        {
            int entriesread;  // number of entries actually read
            int result;
            int totalentries; // total visible servers and workstations
            string _lastError = "";
            IList resultPC;

            resultPC = new ArrayList();

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
                    //_computers = new NetworkComputers[entriesread];

                    int tmp = (int)pBuf;
                    for (int i = 0; i < entriesread; i++)
                    {
                        // fill our struct
                        si = (common.SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmp, svType);
                        //_computers[i] = new NetworkComputers(si);

                        CPc currPDC = new CPc(si.sv101_name);
                        currPDC.platform_id = si.sv101_platform_id;
                        currPDC.type = si.sv101_type;
                        currPDC.comment = si.sv101_comment;
                        currPDC.domain = domainName;
                         
                        try
                        {
                            System.Net.IPHostEntry ip = System.Net.Dns.Resolve(si.sv101_name);
                            System.Net.IPAddress[] ipA = ip.AddressList;
                            currPDC.pc_ip = ipA[0].ToString() + "." + ipA[1].ToString() + "." + ipA[2].ToString() + "." + ipA[3].ToString();
                            
                        }
                        catch 
                        {
                            currPDC.pc_ip = string.Empty;
                        }

                        resultPC.Add(currPDC);
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
            return resultPC;
        }

        public IList getGroups()
        {
            return Net_groupDomainList(GetActiveDomainController());
        }

        public CGroup getGroup(string groupName)
        {
            CGroup selectGroup = null;
            foreach (CGroup currGroup in Net_groupDomainList(GetActiveDomainController()))
            {
                if (currGroup.group_name.ToLower() == groupName.ToLower())
                {
                    selectGroup = currGroup;
                    break;
                }
            }
            return selectGroup;
        }


        private IList Net_groupDomainList(string serverName)
        {
            //defining values for getting group names
            uint level = 2, // 
            prefmaxlen = 0xFFFFFFFF, entriesread = 0, totalentries = 0;
            uint result;
            string _lastError;

            IList resultGroup;
            resultGroup = new ArrayList();

            //Values that will receive information.
            IntPtr GroupInfoPtr, UserInfoPtr, ServerNamePtr;
            //string ServerName;
            GroupInfoPtr = IntPtr.Zero;
            UserInfoPtr = IntPtr.Zero;
            ServerNamePtr = Marshal.StringToCoTaskMemAuto(serverName);

            try
            {
                result = common.NetGroupEnum(
                    //IntPtr.Zero, //Server name.it must be null
                    ServerNamePtr,
                    level, //2 for GROUP_INFO_3 
                    ref GroupInfoPtr,//Value that will be receive information
                    prefmaxlen,//maximum length
                    ref entriesread,//value that receives the count of elements actually enumerated. 
                    ref totalentries,//value that receives the approximate total number of entries that could have been enumerated from the current resume position.
                    IntPtr.Zero);

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
                    //getting group names and add them to tree view
                    for (int i = 0; i < entriesread; i++)
                    {
                        //converting unmanaged code to managed codes with using Marshal class 
                        int newOffset = GroupInfoPtr.ToInt32() + GROUP_INFO_3_SIZE * i;
                        common.GROUP_INFO_3 groupInfo = (common.GROUP_INFO_3)Marshal.PtrToStructure(new IntPtr(newOffset), typeof(common.GROUP_INFO_3));

                        string currentGroupName = Marshal.PtrToStringAuto(groupInfo.lpszGroupName);
                        string currentComment = Marshal.PtrToStringAuto(groupInfo.lpszComment);

                        CGroup currGroup = new CGroup(currentGroupName);
                        currGroup.comment = currentComment;
                        currGroup.group_id = groupInfo.group_id;
                        currGroup.attributes = groupInfo.attributes;

                        resultGroup.Add(currGroup);
                    }
                }
            }
            finally
            {
                //free memory
                common.NetApiBufferFree(GroupInfoPtr);
            }
            return resultGroup;
        }

        public IList getPCs()
        {
            return Net_FindComputers((uint)common.ServerType.SV_TYPE_ALL, m_ntName);
        }

        public CPc getPC(string pcName)
        {
            CPc selectPC = null;
            foreach (CPc currPc in Net_FindComputers((uint)common.ServerType.SV_TYPE_ALL, m_ntName))
            {
                if (currPc.pc_name.ToLower() == pcName.ToLower())
                {
                    selectPC = currPc;
                    break;
                }
            }
            return selectPC;
        }

        public IList getUsers()
        {
            return AD_FindUsers();
            //return Net_FindUsers(GetActiveDomainController());
        }

        public CUserGlobal getUser(string userName)
        {
            CUserGlobal selectUser = null;
            foreach (CUserGlobal currUser in AD_FindUsers())
            {
                if (currUser.winUserName.ToLower() == userName.ToLower())
                {
                    selectUser = currUser;
                    break;
                }
            }
            return selectUser;
            //return Net_FindUsers(GetActiveDomainController());
        }

        private IList Net_FindUsers(string DomainController)
        {
            uint EntriesRead = 0;
            uint TotalEntries = 0;
            uint result;
            string _lastError;
            IntPtr bufPtr;
            IList resultUsers;
            //			IntPtr ServerNamePtr;
            uint prefmaxlen = 0xFFFFFFFF;
            resultUsers = new ArrayList();

            bufPtr = IntPtr.Zero;

            //			ServerNamePtr = Marshal.StringToCoTaskMemAuto(m_PDCName);

            result = common.NetUserEnum(DomainController,
                                10,
                //common.FILTER_TEMP_DUPLICATE_ACCOUNT, 
                                common.FILTER_NORMAL_ACCOUNT,
                                ref bufPtr,
                                prefmaxlen,
                                ref EntriesRead,
                                ref TotalEntries,
                                IntPtr.Zero);
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
                if (EntriesRead > 0)
                {
                    common.USER_INFO_10[] Users = new common.USER_INFO_10[EntriesRead];
                    IntPtr iter = bufPtr;
                    for (int i = 0; i < EntriesRead; i++)
                    {
                        Users[i] = (common.USER_INFO_10)Marshal.PtrToStructure(iter, typeof(common.USER_INFO_10));
                        iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(common.USER_INFO_10)));
                        //MessageBox.Show(Users[i].Username);
                        CUserGlobal currGU = new CUserGlobal(m_ntName, Users[i].name);
                        resultUsers.Add(currGU);

                    }
                    common.NetApiBufferFree(bufPtr);
                }
            }
            return resultUsers;
        }

        private IList AD_FindUsers()
        {
            DirectoryEntry obDomEntry = null;
            IList resultUsers;
            resultUsers = new ArrayList();

            try
            {
                obDomEntry = new DirectoryEntry("WinNT://" + m_ntName);     //+"/"+ DomainController);
                obDomEntry.Children.SchemaFilter.Add("User");
                //obDomEntry.AuthenticationType = AuthenticationTypes.Secure;

                foreach (DirectoryEntry currUser in obDomEntry.Children)
                {
                    if (((int)currUser.Properties["UserFlags"].Value & common.UF_NORMAL_ACCOUNT) == common.UF_NORMAL_ACCOUNT)
                    {
                        CUserGlobal currGU = new CUserGlobal(m_ntName, currUser.Name);
                        currGU.fullName = currUser.Properties["FullName"].Value.ToString();
                        currGU.description = currUser.Properties["Description"].Value.ToString();
                        resultUsers.Add(currGU);
                    }
                }
                obDomEntry.Close();

            }
            catch (COMException ex)
            {
                /*
                retu= (uint)ex.ErrorCode;					
                errorMsg= ex.Message;
                currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
                */
            }
            return resultUsers;
        }




    }
}
