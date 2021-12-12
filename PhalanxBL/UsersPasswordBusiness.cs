using System;
using System.Collections.Generic;
using System.Linq;
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


        public bool CheckAutoApproval(PhxUserEntity Auth, UserPasswordEntity userpwd)
        {
            bool auto = false;

            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();

            bool phxadmin = PhxUsrBL.AccPwdAll(Auth);

            if (phxadmin)
            {
                //Se busca el Request y si el usuario solicitante esta dentro de algun Grupo de Seguimiento asociado
                var requests = m_UserPasswordFactory.GetPasswordToAuthByAutomatic(Auth, userpwd);

                if (requests != null && requests.Count == 1)
                {
                    if (requests[0].FollowupRqstGrpsPwdsList != null)
                    {
                        var groups = (from followupgroup in requests[0].FollowupRqstGrpsPwdsList.ToList()
                                      where followupgroup.FollowupRqstGrp.AutoApproval
                                      select followupgroup.FollowupRqstGrp);

                        foreach (FollowupRequestGroupEntity group in groups)
                        {
                            if (group.AutoApproval && group.Approver != null)
                            {
                                auto = group.AutoApproval;
                                break;
                            }
                        }
                    }
                }
            }

            return auto;
        }

    }
}
