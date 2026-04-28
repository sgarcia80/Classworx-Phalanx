using System;
using PhalanxDAL;
using PhalanxDAL.Data;
using PhalanxDAL.Factories;
using System.Collections;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for userFactory.
	/// </summary>
	public class CUserList
	{
		public CUserList()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}

	public class CUserLocalList: CUserList
	{
		protected IList listLocalUsers;
		protected WinLocalUsersFactory WinLocalUsrFac;
		protected DateTime m_CurrDatetime;

		public CUserLocalList()
		{
			WinLocalUsrFac = new WinLocalUsersFactory();
			m_CurrDatetime = DateTime.Now;
		}
	
		public IList getLocalUsersListToValidate()
		{
			listLocalUsers = new ArrayList();
		
			foreach (WinLocalUsers objWLU in WinLocalUsrFac.GetUsrsByPwdToCheck(m_CurrDatetime))			
			{
				listLocalUsers.Add(new CUserLocal(objWLU));
			}

			return listLocalUsers;
						
		}

		public IList getLocalUsersListToChange()
		{
			listLocalUsers = new ArrayList();
		
			foreach (WinLocalUsers objWLU in WinLocalUsrFac.GetUsrsByPwdToChange(m_CurrDatetime))			
			{
				listLocalUsers.Add(new CUserLocal(objWLU));
			}

			return listLocalUsers;
		}

		public void UpdateCheckedUsrPwd(CUserLocal User)
		{
			User.UpdateCheckedUsrPwd(WinLocalUsrFac, m_CurrDatetime);
		}
		public void UpdateCheckedUsrPwdError(CUserLocal User)
		{
			User.UpdateCheckedUsrPwdError(WinLocalUsrFac);
			
		}

		public void UpdateChangedUsrPwd(CUserLocal User)
		{
			User.UpdateChangedUsrPwd(WinLocalUsrFac, m_CurrDatetime);
		}

	}

	public class CUserGlobalList: CUserList
	{
		protected IList listGlobalUsers;
		protected WinDomainUsersFactory WinGlobalUsrFac;
		protected DateTime m_CurrDatetime;

		public CUserGlobalList()
		{
			WinGlobalUsrFac = new WinDomainUsersFactory();
			m_CurrDatetime = DateTime.Now;
		}
	
		public IList getGlobalUsersListToValidate()
		{
			listGlobalUsers = new ArrayList();
		
			foreach (WinDomainUsers objWDU in WinGlobalUsrFac.GetUsrsByPwdToCheck(m_CurrDatetime))			
			{
				listGlobalUsers.Add(new CUserGlobal(objWDU));
			}

			return listGlobalUsers;
						
		}

		public IList getLocalUsersListToChange()
		{
			listGlobalUsers = new ArrayList();
		
			foreach (WinDomainUsers objWDU in WinGlobalUsrFac.GetUsrsByPwdToChange(m_CurrDatetime))			
			{
				listGlobalUsers.Add(new CUserGlobal(objWDU));
			}

			return listGlobalUsers;
		}

		public void UpdateCheckedUsrPwd(CUserGlobal User)
		{
			User.UpdateCheckedUsrPwd(WinGlobalUsrFac, m_CurrDatetime);
		}

		public void UpdateChangedUsrPwd(CUserGlobal User)
		{
			User.UpdateChangedUsrPwd(WinGlobalUsrFac, m_CurrDatetime);
		}

	}
}
