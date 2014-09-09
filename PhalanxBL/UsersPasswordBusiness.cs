using System;
using System.Collections.Generic;
using System.Text;
//using PhalanxNAL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class UsersPasswordBusiness
    {
        private string _filNombre = "";
        private UserPasswordEntity m_UserPassword = null;
        private UsersPasswordsFactory m_UserPasswordFactory = null;
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private UserEntity _filUser;

        public UsersPasswordBusiness()
        {
            m_UserPassword = new UserPasswordEntity();
            m_UserPasswordFactory = new UsersPasswordsFactory();
        }

        public UserEntity FilUser
        {
            set { _filUser = value; }
        }
        
        public UserPasswordEntity Get(int userID)
        {
            return (m_UserPasswordFactory.GetUserPassword(userID));
        }

        public void Create(UserPasswordEntity userPassword)
        {
            m_UserPasswordFactory.Save(userPassword);
        }

        public void Update(UserPasswordEntity userPassword)
        {
            m_UserPasswordFactory.Update(userPassword);
            /*
            if (Exists(oldPC.WinDomain.NtName, oldPC.Name))
            {
                WinPCEntity winPC = m_WinPcsFac.GetWinPC(oldPC.WinDomain.NtName, oldPC.Name);
                winPC.Name = Pc.Name;
                winPC.PcIP = Pc.PcIP;
                winPC.WinDomain = Pc.WinDomain;
                m_WinPcsFac.SaveWinPC(winPC);
            }
            else
                throw new SystemException("La PC no existe en el Sistema");
             */
        }



    }
}
