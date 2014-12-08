using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using phxCryptMgr;
using System.Collections;

namespace PhalanxBL
{
    public class AS400UserBusiness
    {
        UserTypesFactory m_UserTypesFactory = new UserTypesFactory();
        AS400UsersFactory m_AS400UserFactory = new AS400UsersFactory();
        private bool _orderName = false;
        private bool _orderUserName = false;
        private bool _orderFolio = false;
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;

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

        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }

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

        private AS400Entity _filEquipoAS400;
        public AS400Entity FilEquipoAS400
        {
            set { _filEquipoAS400 = value; }
        }
        private bool _AvoidInactiveGrps = false; // indica que no se tomen los grp de seguim y de solic inactivos
        public bool SetAvoidInactiveGrps
        { set { _AvoidInactiveGrps = value; } }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(AS400UserEntity CurrentUser)
        {
            return m_AS400UserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(AS400UserEntity CurrentUser)
        {
            return m_AS400UserFactory.GetGruposSeguimiento(CurrentUser);
        }

        
        public AS400UserEntityCollection GetAll()
        {
            m_AS400UserFactory.FilUserName = _filNombre;
            m_AS400UserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_AS400UserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_AS400UserFactory.FilAS400PC = _filEquipoAS400;
            m_AS400UserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_AS400UserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;
            m_AS400UserFactory.OrderByFolio = _orderFolio;
            m_AS400UserFactory.OrderByName = _orderName;
            m_AS400UserFactory.OrderByUserName = _orderUserName;
            return m_AS400UserFactory.GetAll();

        }

        public AS400UserEntity Refresh(AS400UserEntity As400User)
        {
            return m_AS400UserFactory.Refresh(As400User);
        }

        public string DecryptPassword(string passwordEncrypter)
        {
            string pwd = new CCryptMgr().decrypt(passwordEncrypter);

            string auxstr = pwd.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }
        /// <summary>
        /// Se creo para identificar si se cambiá la contraseña o no. esto es para setear el campo de fecha
        /// de actualización de contraseña
        /// </summary>
        /// <param name="AS400User"></param>
        /// <param name="UpdatePassword"></param>
        public void Update(AS400UserEntity AS400User, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(AS400User, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }
        public void Update(AS400UserEntity AS400User, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            _AvoidInactiveGrps = AvoidGrpInactive;
            SaveUser(AS400User, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }

        public void Update(AS400UserEntity AS400User, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            SaveUser(AS400User, GruposSolicitudes, GruposSeguimiento);
        }

        private void SaveUser(AS400UserEntity AS400User, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                if (UpdatePassword)
                {
                    // si se cambia la contraseña, se establece la fecha de cambio traida del server
                    AS400User.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
                }
                if (_AvoidInactiveGrps)
                {
                    m_AS400UserFactory.SetAvoidInactiveGrps = true;
                }
                m_AS400UserFactory.SaveUser(AS400User, GruposSolicitudes, GruposSeguimiento);

                /*
                 if (AS400User.UserPassword.ApplyRealUser)
                 {
                     NUser NalUser = new NUser();
                     NalUser.ChangePassword(AS400User.WinPc.Name, AS400User.Username, AS400User.UserPassword.RealPassword);
                 }
                 */
                m_AS400UserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_AS400UserFactory.SaveUserRollBack();
                throw se;
            }
        }
        private void SaveUser(AS400UserEntity AS400User, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            try
            {
                m_AS400UserFactory.SaveUser(AS400User, GruposSolicitudes, GruposSeguimiento);
                m_AS400UserFactory.SaveUserCommit();
            }
            catch (SystemException se)
            {
                m_AS400UserFactory.SaveUserRollBack();
                throw se;
            }
        }
        public bool Exists(AS400Entity pcEntity, string userName)
        {
            return (m_AS400UserFactory.GetAS400User(pcEntity.ServerName, userName) != null);
        }
        public string EncryptPassword(string password)
        {
            return new CCryptMgr().encrypt(password);
        }
        public AS400UserEntity FillData(AS400UserEntity userEntity)
        {
            return m_AS400UserFactory.GetAS400User(userEntity.AS400.ServerName, userEntity.Username);
        }

        public UserTypeEntity AS400LocalUserType
        {
            get { return m_UserTypesFactory.GetAS400UserType(); }
        }
        public void Create(AS400UserEntity AS400User, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
            {
                AS400User.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            SaveUser(AS400User, GruposSolicitudes, GruposSeguimiento);

        }
        public string GetPassword(AS400UserEntity user)
        {
            string passEncrypt = m_AS400UserFactory.RefreshPassword(user);
            return DecryptPassword(passEncrypt);
        }

        public void RefrechGroupsList(AS400UserEntity user)
        {
            m_AS400UserFactory.RefreshPassRequestList(user);
        }

        public AS400UserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_AS400UserFactory.OrderByName = true;
            m_AS400UserFactory.FilFiltroNombreGeneral = Filtro;
            return m_AS400UserFactory.GetAllForRqst(PhxUserRqst);
        }
        public AS400UserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_AS400UserFactory.OrderByName = true;
            return m_AS400UserFactory.GetAllForRqst(PhxUserRqst);
        }
        public AS400UserEntity GetAS400PwdForRqst(PhxUserEntity PhxUserRqst, int WLUID)
        {
            return m_AS400UserFactory.GetAS400PwdForRqst(PhxUserRqst, WLUID);
        }

        public AS400UserEntityCollection GetPCUsers(AS400Entity AS400PC)
        {
            AS400UsersFactory AS400UsrF = new AS400UsersFactory();
            AS400UsrF.FilAS400PC = AS400PC;
            return AS400UsrF.GetAll();
        }

        public void SetPwdState(AS400UserEntityCollection Users, bool Active)
        {
            AS400UsersFactory AS400UsrF = new AS400UsersFactory();
            AS400UsrF.SetPwdState(Users, Active);
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			return new AS400UsersFactory().GetAll(critico, estadoUsuario, nombre);
		}
    }
}
