using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxNAL;
using phxCryptMgr;
using System.Collections;

namespace PhalanxBL
{
    public class UnixUserBusiness
    {
        //const string m_BlowfishKey = "1234567890abcdefghijABCDEFGHIJzxcvbnmlkj";
        UserTypesFactory m_UserTypesFactory = new UserTypesFactory();
        UnixUsersFactory m_UnixUserFactory = null;
        private bool _orderName = false;
        private bool _orderFolio = false;
        private bool _orderUserName = false;

        public void SetOrderByUserName()
        {
            _orderFolio = false;
            _orderUserName = true;
            _orderName = false;
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
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;
        public UserTypeEntity UnixLocalUserType
        {
            get { return m_UserTypesFactory.GetUnixUserType(); }
        }
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }

        private UnixEntity _filEquipoUnix;
        public UnixEntity FilEquipoUnix
        {
            set { _filEquipoUnix = value; }
        }
        private bool _AvoidInactiveGrps = false; // indica que no se tomen los grp de seguim y de solic inactivos


        private bool? _filUsuariosActivos;
        public bool? FilUsuariosActivos
        {
            set { _filUsuariosActivos = value; }
        }
        private bool? _filUsuariosCriticos;
        public bool? FilUsuariosCriticos
        {
            set { _filUsuariosCriticos = value; }
        }

        public UnixUserBusiness()
        {
            m_UnixUserFactory = new UnixUsersFactory();
        }
        public UnixUserBusiness(string userlogon)
        {
            m_UnixUserFactory = new UnixUsersFactory(userlogon);
        }

        public UnixUserEntityCollection GetAll()
        {
            m_UnixUserFactory.FilUserName = _filNombre;
            m_UnixUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_UnixUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_UnixUserFactory.FilUnixPC = _filEquipoUnix;
            m_UnixUserFactory.OrderByFolio = _orderFolio;
            m_UnixUserFactory.OrderByName = _orderName;
            m_UnixUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_UnixUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;
            return m_UnixUserFactory.GetAll();

        }
        public UnixUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_UnixUserFactory.OrderByName = true;
            m_UnixUserFactory.FilFiltroNombreGeneral = Filtro;
            return m_UnixUserFactory.GetAllForRqst(PhxUserRqst);
        }
        public UnixUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_UnixUserFactory.OrderByName = true;
            return m_UnixUserFactory.GetAllForRqst(PhxUserRqst);
        }

        public UnixUserEntity GetUnixPwdForRqst(PhxUserEntity PhxUserRqst, int WLUID)
        {
            return m_UnixUserFactory.GetUnixPwdForRqst(PhxUserRqst, WLUID);
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

        public void Delete(UnixUserEntity unixUser)
        {
            m_UnixUserFactory.Delete(unixUser);
        }

        /*public void Create(UnixUserEntity unixUser)
        {
            SaveUser(unixUser);
        }*/
        public void Create(UnixUserEntity unixUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
            {
                unixUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }

            SaveUser(unixUser, GruposSolicitudes, GruposSeguimiento);
        }

        /// <summary>
        /// Se creo para identificar si se cambiá la contraseña o no. esto es para setear el campo de fecha
        /// de actualización de contraseña
        /// </summary>
        /// <param name="unixUser"></param>
        /// <param name="UpdatePassword"></param>
        public void Update(UnixUserEntity unixUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(unixUser, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }

        public void Update(UnixUserEntity unixUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(unixUser, GruposSolicitudes, GruposSeguimiento);
        }


        public RqstGrpPwdEntityCollection GetGruposSolicitudes(UnixUserEntity CurrentUser)
        {
            return m_UnixUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(UnixUserEntity CurrentUser)
        {
            return m_UnixUserFactory.GetGruposSeguimiento(CurrentUser);
        }


        private void SaveUser(UnixUserEntity unixUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                if (UpdatePassword)
                {
                    // si se cambia la contraseña, se establece la fecha de cambio traida del server
                    unixUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
                }
                m_UnixUserFactory.SetAvoidInactiveGrps = _AvoidInactiveGrps;
                m_UnixUserFactory.SaveUser(unixUser, GruposSolicitudes, GruposSeguimiento);

                /*
                 if (unixUser.UserPassword.ApplyRealUser)
                 {
                     NUser NalUser = new NUser();
                     NalUser.ChangePassword(unixUser.WinPc.Name, unixUser.Username, unixUser.UserPassword.RealPassword);
                 }
                 */
                m_UnixUserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_UnixUserFactory.SaveUserRollBack();
                throw se;
            }
        }
        private void SaveUser(UnixUserEntity unixUser, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                m_UnixUserFactory.SaveUser(unixUser, GruposSolicitudes, GruposSeguimiento);

                /*
                 if (unixUser.UserPassword.ApplyRealUser)
                 {
                     NUser NalUser = new NUser();
                     NalUser.ChangePassword(unixUser.WinPc.Name, unixUser.Username, unixUser.UserPassword.RealPassword);
                 }
                 */
                m_UnixUserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_UnixUserFactory.SaveUserRollBack();
                throw se;
            }
        }

        public bool Exists(UnixEntity pcEntity, string userName)
        {
            return (m_UnixUserFactory.GetUnixUser(pcEntity.ServerName, userName) != null);
        }

        public UnixUserEntity FillData(UnixUserEntity userEntity)
        {
            return m_UnixUserFactory.GetUnixUser(userEntity.Unix.ServerName, userEntity.Username);
        }

        public UnixUserEntityCollection GetPCUsers(UnixEntity UnixPC)
        {
            UnixUsersFactory UnixUsrF = new UnixUsersFactory();
            UnixUsrF.FilUnixPC = UnixPC;
            return UnixUsrF.GetAll();
        }

        public string GetPassword(UnixUserEntity user)
        {
            string passEncrypt= m_UnixUserFactory.RefreshPassword(user);

            if (!string.IsNullOrEmpty(passEncrypt))
            {
                passEncrypt = DecryptPassword(passEncrypt);
            }

            return passEncrypt;
        }

        public void RefrechGroupsList(UnixUserEntity user)
        {
            m_UnixUserFactory.RefreshPassRequestList(user);
        }
        public void SetPwdState(UnixUserEntityCollection Users, bool Active)
        {
            UnixUsersFactory UnixUsrF = new UnixUsersFactory();
            UnixUsrF.SetPwdState(Users, Active);
        }

        public UnixUserEntity Refresh(UnixUserEntity User)
        {
            return m_UnixUserFactory.Refresh(User);
        }


        
        public void Update(UnixUserEntity unixUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            _AvoidInactiveGrps = AvoidGrpInactive;
            SaveUser(unixUser, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			return new UnixUsersFactory().GetAll(critico, estadoUsuario, nombre);
		}

        public UnixUserEntity Load(int ID)
        {
            return new UnixUsersFactory().Load(ID);
        }
    }
}
