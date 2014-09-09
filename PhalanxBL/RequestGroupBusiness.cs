using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class RequestGroupBusiness
    {
        private string _filNombre = "";
        private bool? _filActivos;
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        public bool? FilActivos
        {
            set { _filActivos = value; }
        }

        public RequestGroupEntityCollection GetAll()
        {
            //RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            //WDF.FilNombre = _filNombre;

            //return RqstGrpF.GetAll();
            return this.GetAll(false);

        }

        public RequestGroupEntityCollection FillFilter()
        {
            RequestGroupEntityCollection RqstGroupEC = this.GetAll();
            RequestGroupEntity Todos = new RequestGroupEntity();
            Todos.RqstGrpName = "Todos";
            Todos.Active = true;
            Todos.Id = 0;
            RqstGroupEC.Insert(0, Todos);
            return RqstGroupEC;
        }

        public RequestGroupEntityCollection GetATMs()
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilATMs = true;
            RqstGrpF.FilNombre = _filNombre;
            RqstGrpF.FilActivos = _filActivos;
            return RqstGrpF.GetAll();
        }

        public RequestGroupEntityCollection GetAll(bool LoadRqstGrpPwd)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            //WDF.FilNombre = _filNombre;
            RqstGrpF.FilLoadPwds = LoadRqstGrpPwd;
            RqstGrpF.FilNombre = _filNombre;
            RqstGrpF.FilActivos = _filActivos;
            return RqstGrpF.GetAll();

        }
        public IList<WinLocalUserEntity> LoadWinPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadWinPwds(RqstGrp);
        }
        public IList<WinLocalUserEntity> LoadActiveWinPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadWinPwds(RqstGrp);
        }
        public IList<DatabaseUserEntity> LoadDbPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadDbPwds(RqstGrp);
        }
        public IList<DatabaseUserEntity> LoadActiveDbPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadDbPwds(RqstGrp);
        }
        
        public IList<ApplicationUserEntity> LoadActiveAppPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadAppPwds(RqstGrp);
        }
        public IList<ApplicationUserEntity> LoadAppPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadAppPwds(RqstGrp);
        }

        public IList<UnixUserEntity> LoadUnixPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadUnixPwds(RqstGrp);
        }
        public IList<UnixUserEntity> LoadActiveUnixPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadUnixPwds(RqstGrp);
        }

        public IList<AS400UserEntity> LoadAS400Pwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadAS400Pwds(RqstGrp);
        }
        public IList<AS400UserEntity> LoadActiveAS400Pwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadAS400Pwds(RqstGrp);
        }

        public IList<CommunicationDeviceUserEntity> LoadECPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadECPwds(RqstGrp);
        }
        public IList<CommunicationDeviceUserEntity> LoadActiveECPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadECPwds(RqstGrp);
        }

        public IList<PhxUserGroupEntity> LoadPhxUsers(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadPhxUsers(RqstGrp);
        }

        public IList<PhxUserGroupEntity> LoadActivePhxUsers(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrp.Active = true;
            return RqstGrpF.LoadPhxUsers(RqstGrp);
        }

        /*
        public PhxUserEntityCollection GetRqstAuth(PasswordRequestEntity PasswordRequest, PhxUserEntity PhxUsrRqst)
        {

        }*/

        public int Save(RequestGroupEntity RequestGroup)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.Save(RequestGroup);

        }
        public void SetPwdsToRqstGrp(RequestGroupEntity RequestGroup, UserPasswordEntityCollection UsersPasswords)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.SetPwdsToRqstGrp(RequestGroup, UsersPasswords);
        }

        public void SetPwdsToRqstGrp(RequestGroupEntity RequestGroup, UserPasswordEntityCollection UsersPasswords, PhxUserEntityCollection Users)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.SetPwdsToRqstGrp(RequestGroup, UsersPasswords, Users);
        }


        public IList<ATMUserEntity> LoadATMPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            return RqstGrpF.LoadATMPwds(RqstGrp);
        }
        public IList<ATMUserEntity> LoadActiveATMPwds(RequestGroupEntity RqstGrp)
        {
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.FilActivos = true;
            return RqstGrpF.LoadATMPwds(RqstGrp);
        }
    }
}
