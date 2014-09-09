using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.DirectoryServices;
//using System.DirectoryServices;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for pc.
	/// </summary>
	public class CPc
	{
		public string pc_name;
		public int platform_id;
		public uint type;
		public string comment;
		public string domain;
        public string pc_ip;
		protected static int LOCALGROUP_INFO_1_SIZE;

		public bool isPDC
		{
			get
			{
				return ((this.type & (uint)common.ServerType.SV_TYPE_DOMAIN_CTRL) == (uint)common.ServerType.SV_TYPE_DOMAIN_CTRL);
			}
		}

		public bool isBDC
		{
			get
			{
				return ((this.type & (uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL) == (uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL);
			}
		}

		public CPc()
		{
			CommonContructor();
		}

		public CPc(string name)
		{
			pc_name= name;
			CommonContructor();
		}

		private void CommonContructor()
		{
			unsafe
			{
				LOCALGROUP_INFO_1_SIZE = sizeof(common.LOCALGROUP_INFO_1);
			}
		}

		public CGroup getGroup(string groupName)
		{
			CGroup selectGroup = null;
			foreach (CGroup currGroup in Net_groupLocalList(pc_name))
			{
				if (currGroup.group_name.ToLower() == groupName.ToLower())
				{
					selectGroup= currGroup;
					break;
				}
			}
			return selectGroup;
		}

		public IList getGroups()
		{
			return Net_groupLocalList(pc_name);
		}


		private IList Net_groupLocalList(string serverName)
		{
			//defining values for getting group names
			uint level = 1, prefmaxlen = 0xFFFFFFFF, entriesread = 0, totalentries = 0;
			uint result;
			string _lastError;

			//Values that will receive information.
			IntPtr GroupInfoPtr, ServerNamePtr;
			GroupInfoPtr = IntPtr.Zero;
			//UserInfoPtr = IntPtr.Zero;
			ServerNamePtr = Marshal.StringToCoTaskMemAuto(serverName);

			IList resultGroup;
			resultGroup = new ArrayList();
			
			try
			{
				result= common.NetLocalGroupEnum(
					//IntPtr.Zero, //Server name.it must be null
					ServerNamePtr,
					level,//level can be 0 or 1 for groups.For more information see LOCALGROUP_INFO_0 and LOCALGROUP_INFO_1
					ref GroupInfoPtr,//Value that will be receive information
					prefmaxlen,//maximum length
					ref entriesread,//value that receives the count of elements actually enumerated. 
					ref totalentries,//value that receives the approximate total number of entries that could have been enumerated from the current resume position.
					IntPtr.Zero);
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
					for(int i = 0; i<entriesread; i++)
					{
						//converting unmanaged code to managed codes with using Marshal class 
						int newOffset = GroupInfoPtr.ToInt32() + LOCALGROUP_INFO_1_SIZE * i;
						common.LOCALGROUP_INFO_1 groupInfo = (common.LOCALGROUP_INFO_1)Marshal.PtrToStructure(new IntPtr(newOffset), typeof(common.LOCALGROUP_INFO_1));
						string currentGroupName = Marshal.PtrToStringAuto(groupInfo.lpszGroupName);
						string currentComment = Marshal.PtrToStringAuto(groupInfo.lpszComment);
				
						CGroup currGroup = new CGroup(currentGroupName);
						currGroup.comment = currentComment;
						currGroup.group_id = 0;
						currGroup.attributes = 0;				
				
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

		public CUserLocal getUser(string userName)
		{
			CUserLocal selectUser = null;
			foreach (CUserLocal currUser in AD_FindUsers())
			{
				if (currUser.winUserName.ToLower() == userName.ToLower())
				{
					selectUser= currUser;
					break;
				}
			}
			return selectUser;

			//			if (isServer)
			//return Net_FindUsers();
			//			else
		}

		public IList getUsers()
		{
			return AD_FindUsers();
//			if (isServer)
				//return Net_FindUsers();
//			else
		}

		private IList Net_FindUsers()
		{
			uint EntriesRead = 0;
			uint TotalEntries = 0;
			IntPtr bufPtr;
			IList resultUsers;
			uint prefmaxlen = 0xFFFFFFFF;
			uint result;
			string _lastError;

			//			IntPtr ServerNamePtr;
			resultUsers = new ArrayList();

			//			ServerNamePtr = Marshal.StringToCoTaskMemAuto(m_PDCName);
			bufPtr = IntPtr.Zero;
			
			result= common.NetUserEnum(pc_name, 
				10, 
				common.FILTER_NORMAL_ACCOUNT, //Local Users
				ref bufPtr, 
				prefmaxlen, 
				ref EntriesRead, 
				ref TotalEntries, 
				IntPtr.Zero);

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
				if(EntriesRead> 0)
				{
					common.USER_INFO_10[] Users = new common.USER_INFO_10[EntriesRead];
					IntPtr iter = bufPtr;
					for(int i=0; i < EntriesRead; i++)
					{
						Users[i] = (common.USER_INFO_10)Marshal.PtrToStructure(iter, typeof(common.USER_INFO_10)); 
						iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(common.USER_INFO_10)));
						//MessageBox.Show(Users[i].Username);
						CUserLocal currGU = new CUserLocal(domain, pc_name, Users[i].name);
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
				obDomEntry = new DirectoryEntry("WinNT://"+domain+"/"+ pc_name);
				obDomEntry.Children.SchemaFilter.Add("User");				
				//obDomEntry.AuthenticationType = AuthenticationTypes.Secure;
					
				foreach(DirectoryEntry currUser in obDomEntry.Children)
				{
					CUserLocal currGU = new CUserLocal(domain, pc_name, currUser.Name);
					currGU.fullName = currUser.Properties["FullName"].Value.ToString(); 
					currGU.description = currUser.Properties["Description"].Value.ToString();
					resultUsers.Add(currGU);
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
				/*  User's Properties
					UserFlags 
					MaxStorage 
					PasswordAge 
					PasswordExpired 
					LoginHours 
					FullName 
					Description 
					BadPasswordAttempts 
					LastLogin 
					HomeDirectory 
					LoginScript 
					Profile 
					HomeDirDrive 
					Parameters 
					PrimaryGroupID 
					Name 
					MinPasswordLength 
					MaxPasswordAge 
					MinPasswordAge 
					PasswordHistoryLength 
					AutoUnlockInterval 
					LockoutObservationInterval 
					MaxBadPasswordsAllowed 
					RasPermissions 
					objectSid 
				*/
			return resultUsers;
		}

		public bool isServer()
		{
			if ( ((this.type & (uint)common.ServerType.SV_TYPE_DOMAIN_CTRL) == (uint)common.ServerType.SV_TYPE_DOMAIN_CTRL)
			  || ((this.type & (uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL) == (uint)common.ServerType.SV_TYPE_DOMAIN_BAKCTRL)		
			  || ((this.type & (uint)common.ServerType.SV_TYPE_SERVER_NT) == (uint)common.ServerType.SV_TYPE_SERVER_NT) )
			{
				return  true;
			}
			else{
				return  false;			
			}
		}
	}
}
