using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxNAL;
using phxCryptMgr;

namespace PhalanxBL
{
    public class WinLocalUserBusiness
    {
       // const string m_BlowfishKey = "1234567890abcdefghijABCDEFGHIJzxcvbnmlkj";
        UserTypesFactory m_UserTypesFactory = new UserTypesFactory();
        WinLocalUsersFactory m_WinUserFactory = new WinLocalUsersFactory();
        public UserTypeEntity WinLocalUserType
        {
            get { return m_UserTypesFactory.GetWinLocalUserType(); }
        }
        private string _filNombre = "";
        private bool? _filUsuariosActivos;
        private bool _AvoidInactiveGrps = false; // indica que no se tomen los grp de seguim y de solic inactivos
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;
        public string FilNombre
        {
            set { _filNombre = value; }
        }
        public bool? FilUsuariosActivos
        {
            set { _filUsuariosActivos = value; }
        }
        private bool? _filUsuariosCriticos;
        public bool? FilUsuariosCriticos
        {
            set { _filUsuariosCriticos = value; }
        }
        public bool SetAvoidInactiveGrps
        { set { _AvoidInactiveGrps = value; } }
        private bool _orderName = false;
        private bool _orderFolio = false;
        private bool _orderUserName = false;
        public void SetOrderByUserName()
        {
            _orderFolio = false;
            _orderUserName = true;
            _orderName = false;
        }
        private WinDomainEntity _filDomain = null;
        public WinDomainEntity FilDomain
        {
            set { _filDomain = value; }
        }
        private bool? _filEquiposActivos = null;
        public bool FilEquiposActivos
        {
            set { _filEquiposActivos = value; }
        }
        WinPCEntity _filWinPC = null;
        public WinPCEntity FilWinPC
        {
            set { _filWinPC = value; }
        }

        public void SetOrderByName()
        {
            _orderFolio = false;
            _orderName = true;
            _orderUserName = false;
        }
        public void SetOrderByFolio()
        {
            _orderFolio = true;
            _orderName = false;
            _orderUserName = false;
        }

        public WinLocalUserEntityCollection GetAll()
        {
            m_WinUserFactory.FilUserName = _filNombre;
            m_WinUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_WinUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_WinUserFactory.FilWinPC = _filWinPC;
            m_WinUserFactory.OrderByFolio = _orderFolio;
            m_WinUserFactory.OrderByName = _orderName;
            m_WinUserFactory.OrderByUserName = _orderUserName;
            m_WinUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_WinUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;
            m_WinUserFactory.FilDomain = this._filDomain;
            if (_filEquiposActivos != null)
            {
                m_WinUserFactory.FilEquiposActivos = this._filEquiposActivos.Value;
            }
            return m_WinUserFactory.GetAll();

        }
        public WinLocalUserEntityCollection GetAllForLotesChk(WinDomainEntity Dominio)
        {
            m_WinUserFactory.OrderByName = true;
            m_WinUserFactory.FilEquiposActivos = true;
            m_WinUserFactory.FilUsuariosActivos = true;
            m_WinUserFactory.FilEquiposChequeables = true;
            m_WinUserFactory.FilDomain = Dominio;
            m_WinUserFactory.FilWinPC = _filWinPC;
            return m_WinUserFactory.GetAll();
        }
        public WinLocalUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_WinUserFactory.OrderByName = true;
            WinLocalUserEntityCollection tmpCollection = m_WinUserFactory.GetAllForRqst(PhxUserRqst);
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                WinLocalUserEntity tmpUser = tmpCollection[i];
                m_WinUserFactory.RefreshRequestList(ref tmpUser);
            }
            return tmpCollection;
        }

        public WinLocalUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_WinUserFactory.OrderByName = true;
            m_WinUserFactory.FilFiltroNombreGeneral = Filtro;
            WinLocalUserEntityCollection tmpCollection = m_WinUserFactory.GetAllForRqst(PhxUserRqst);
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                WinLocalUserEntity tmpUser = tmpCollection[i];
                m_WinUserFactory.RefreshRequestList(ref tmpUser);
            }
            return tmpCollection;
        }

        public WinLocalUserEntity GetWinPwdForRqst(PhxUserEntity PhxUserRqst, int WLUID)
        {
            return m_WinUserFactory.GetWinPwdForRqst(PhxUserRqst, WLUID);
        }

        public string EncryptPassword(string password)
        {
            return new CCryptMgr().encrypt(password);
        }

        public string DecryptPassword(string passwordEncrypter)
        {
            string pwd= new CCryptMgr().decrypt(passwordEncrypter);

            string auxstr = pwd.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }

        public void Delete(WinLocalUserEntity winUser)
        {
            m_WinUserFactory.Delete(winUser);
        }

        public void Create(WinLocalUserEntity winUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(winUser, true, GruposSolicitudes, GruposSeguimiento);
        }

        public void Update(WinLocalUserEntity winUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(winUser, GruposSolicitudes, GruposSeguimiento);
        }
        /// <summary>
        /// Se creo para identificar si se cambiá la contraseña o no. esto es para setear el campo de fecha
        /// de actualización de contraseña
        /// </summary>
        /// <param name="winUser"></param>
        /// <param name="UpdatePassword"></param>
        /// 
        public bool RepararPwd(WinLocalUserEntity winUser)
        {
            WinLocalUsersFactory WLUF = new WinLocalUsersFactory();
            WLUF.Refresh(winUser);
            CCryptMgr BF = new CCryptMgr();
            
            NUser NUsr = new NUser();
            NUsr.ChangePassword(winUser.WinPc.Name, winUser.Username, BF.decrypt(winUser.UserPassword.Password));
            this.SaveUser(winUser, true);
            return true;
        }
        public void Update(WinLocalUserEntity winUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            _AvoidInactiveGrps = AvoidGrpInactive;
            SaveUser(winUser, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }
        public void Update(WinLocalUserEntity winUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(winUser, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(WinLocalUserEntity CurrentUser)
        {
            return m_WinUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(WinLocalUserEntity CurrentUser)
        {
            return m_WinUserFactory.GetGruposSeguimiento(CurrentUser);
        }


        private void SaveUser(WinLocalUserEntity winUser, bool UpdatePassword)
        {
            try
            {
                if (UpdatePassword)
                {
                    winUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
                }
                if (_AvoidInactiveGrps)
                {
                    m_WinUserFactory.SetAvoidInactiveGrps = true;
                }
                m_WinUserFactory.SaveUser(winUser, new RequestGroupEntityCollection(), new FollowupRequestGroupEntityCollection());

                if (winUser.UserPassword.ApplyRealUser)
                {
                    NUser NalUser = new NUser();
                    NalUser.ChangePassword(winUser.WinPc.Name, winUser.Username, winUser.UserPassword.RealPassword);
                }
                m_WinUserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_WinUserFactory.SaveUserRollBack();
                throw se;
            }
        }

        private void SaveUser(WinLocalUserEntity winUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                if (UpdatePassword)
                {
                    winUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
                }
                m_WinUserFactory.SetAvoidInactiveGrps = _AvoidInactiveGrps;
                m_WinUserFactory.SaveUser(winUser, GruposSolicitudes, GruposSeguimiento);

                if (winUser.UserPassword.ApplyRealUser)
                {
                    NUser NalUser = new NUser();
                    NalUser.ChangePassword(winUser.WinPc.Name, winUser.Username, winUser.UserPassword.RealPassword);
                }
                m_WinUserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_WinUserFactory.SaveUserRollBack();
                throw se;
            }
        }

        public string ManualPwdCheck(string DomainName, string ComputerName, string UserName, string Password)
        {
            string ResultadoChk = "Se verificó la contraseña";
            NUser NalUser = new NUser();
            uint ChkResult = NalUser.validatePassword(DomainName, ComputerName, UserName, Password);
            switch (ChkResult)
            {
                case common.CPASS_ERR_UNKNOWN:
                    ResultadoChk = "Error desconocido";
                    break;
                case common.CPASS_ERR_INVALID_COMPUTER:
                    ResultadoChk = "Nombre de equipo inválido";
                    break;
                case common.CPASS_ERR_INVALID_PASSWORD:
                    ResultadoChk = "Contraseña inválida";
                    break;
                case common.CPASS_ERR_INVALID_USER:
                    ResultadoChk = "El usuario no existe en el equipo";
                    break;
            }
            return ResultadoChk;

        }
        private void SaveUser(WinLocalUserEntity winUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                m_WinUserFactory.SaveUser(winUser,GruposSolicitudes, GruposSeguimiento );

                if (winUser.UserPassword.ApplyRealUser)
                {
                    NUser NalUser = new NUser();
                    NalUser.ChangePassword(winUser.WinPc.Name, winUser.Username, winUser.UserPassword.RealPassword);
                }
                m_WinUserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_WinUserFactory.SaveUserRollBack();
                throw se;
            }
        }

        public bool Exists(WinPCEntity pcEntity, string userName)
        {
            return (m_WinUserFactory.GetWinLocalUser(pcEntity, userName) != null);
        }

        public WinLocalUserEntity FillData(WinLocalUserEntity userEntity)
        {
            return m_WinUserFactory.GetWinLocalUser(userEntity.WinPc, userEntity.Username);
        }

        public WinLocalUserEntityCollection FindNetWinUsers(WinPCEntity pcEntity, string filter)
        {
            return new NUser().FindUsers(pcEntity, filter);
        }

        public string GetPassword(WinLocalUserEntity user)
        {
            string passEncrypt= m_WinUserFactory.RefreshPassword(user);
            return DecryptPassword(passEncrypt);
        }

        public void RefrechGroupsList(WinLocalUserEntity user)
        {
            m_WinUserFactory.RefreshPassRequestList(user);
        }

        public void RefreshPwdLockTypePasswordList(WinLocalUserEntity user)
        {
            m_WinUserFactory.RefreshPwdLockTypePasswordList(user);
        }




        public WinLocalUserEntityCollection GetPCUsers(WinPCEntity WinPC)
        {
            WinLocalUsersFactory WinUsrF = new WinLocalUsersFactory();
            WinUsrF.FilWinPC = WinPC;
            return WinUsrF.GetAll();
        }

        public void SetPwdState(WinLocalUserEntityCollection Users, bool Active)
        {
            WinLocalUsersFactory WinUsrF = new WinLocalUsersFactory();
            WinUsrF.SetPwdState(Users, Active);
        }

        public WinLocalUserEntity Refresh(WinLocalUserEntity User)
        {
            return m_WinUserFactory.Refresh(User);
        }


    }
}
