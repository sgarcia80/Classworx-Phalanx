using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class FollowupRequestGroupBusiness
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private bool? _filActivos;
        public bool? FilActivos
        {
            set { _filActivos = value; }
        }

        public FollowupRequestGroupEntityCollection GetAll()
        {
            //FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            //WDF.FilNombre = _filNombre;

            //return RqstGrpF.GetAll();
            return this.GetAll(false);

        }
        public FollowupRequestGroupEntityCollection GetAll(bool LoadRqstGrpPwd)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            //WDF.FilNombre = _filNombre;
            RqstGrpF.FilLoadPwds = LoadRqstGrpPwd;
            RqstGrpF.FilNombre = _filNombre;
            RqstGrpF.FilActivos = _filActivos;
            return RqstGrpF.GetAll();

        }
        public IList<WinLocalUserEntity> LoadWinPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadWinPwds(RqstGrp);
        }
        public IList<WinLocalUserEntity> LoadActiveWinPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadWinPwds(RqstGrp);
        }
        public IList<DatabaseUserEntity> LoadDbPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadDbPwds(RqstGrp);
        }
        public IList<DatabaseUserEntity> LoadActiveDbPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadDbPwds(RqstGrp);
        }
        
        public IList<ApplicationUserEntity> LoadAppPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadAppPwds(RqstGrp);
        }
        public IList<ApplicationUserEntity> LoadActiveAppPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadAppPwds(RqstGrp);
        }

        public IList<UnixUserEntity> LoadUnixPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadUnixPwds(RqstGrp);
        }
        public IList<UnixUserEntity> LoadActiveUnixPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadUnixPwds(RqstGrp);
        }

        public IList<AS400UserEntity> LoadAS400Pwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadAS400Pwds(RqstGrp);
        }
        public IList<AS400UserEntity> LoadActiveAS400Pwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadAS400Pwds(RqstGrp);
        }

        public IList<CommunicationDeviceUserEntity> LoadECPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadECPwds(RqstGrp);
        }
        public IList<CommunicationDeviceUserEntity> LoadActiveECPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadECPwds(RqstGrp);
        }

        public IList<FollowupRequestGroupUserEntity> LoadPhxUsers(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadPhxUsers(RqstGrp);
        }
        public IList<FollowupRequestGroupUserEntity> LoadActivePhxUsers(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadPhxUsers(RqstGrp);
        }

        public int Save(FollowupRequestGroupEntity FollowupRequestGroup)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.Save(FollowupRequestGroup);

        }
        public void SetPwdsToRqstGrp(FollowupRequestGroupEntity FollowupRequestGroup,
            UserPasswordEntityCollection UsersPasswords)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.SetPwdsToRqstGrp(FollowupRequestGroup, UsersPasswords);
        } 
        
        /// <summary>
        /// Asocia a los usuarios al grupo. Tener en cuenta que con los inactivos no se trabaja
        /// </summary>
        /// <param name="FollowupRequestGroup"></param>
        /// <param name="UsersPasswords"></param>
        /// <param name="Users"></param>
        public void SetPwdsToRqstGrp(FollowupRequestGroupEntity FollowupRequestGroup,
            UserPasswordEntityCollection UsersPasswords, PhxUserEntityCollection Users, bool ModificaPwds, bool ModificaUsrs)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            RqstGrpF.SetPwdsToRqstGrp(FollowupRequestGroup, UsersPasswords, Users,  ModificaPwds,  ModificaUsrs);
        }
        public IList<ATMUserEntity> LoadATMPwds(FollowupRequestGroupEntity RqstGrp)
        {
            FollowupRequestGroupFactory RqstGrpF = new FollowupRequestGroupFactory();
            return RqstGrpF.LoadATMPwds(RqstGrp);
        }
    }
}
