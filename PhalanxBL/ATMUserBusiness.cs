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
    public class ATMUserBusiness
    {
        private string _filUserName = "";
        private string _filATMName;
        private ATMUserFactory m_ATMUserFactory = null;
        private bool _orderName = false;
        private bool _orderUserName = false;
        private bool _orderFolio = false;
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
        public string FilATMName
        {
            set { _filATMName = value; }
        }
        public string FilUserName
        {
            set { _filUserName = value; }
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


        public ATMUserBusiness()
        {
            m_ATMUserFactory = new ATMUserFactory();
        }

        public ATMUserBusiness(string userlogon)
        {
            m_ATMUserFactory = new ATMUserFactory(userlogon);
        }

        public ATMUserEntityCollection GetAll() //string Nombre, ApplicationEntity Application)
        {
            if (_filUserName != "")
            {
                m_ATMUserFactory.FilUserName = _filUserName;
            }
            if (_filATMName != null)
            {
                m_ATMUserFactory.FilATMName = _filATMName;
            }
            m_ATMUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_ATMUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_ATMUserFactory.OrderByFolio = _orderFolio;
            m_ATMUserFactory.OrderByName = _orderName;
            m_ATMUserFactory.OrderByUserName = _orderUserName;
            m_ATMUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_ATMUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;

            return m_ATMUserFactory.GetAll();

        }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(ATMUserEntity CurrentUser)
        {
            return m_ATMUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(ATMUserEntity CurrentUser)
        {
            return m_ATMUserFactory.GetGruposSeguimiento(CurrentUser);
        }

        public int Save(ATMUserEntity AppUser, bool UpdatePassword, int GrupoSolicitudesID, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            RequestGroupEntityCollection GruposSolicitudes = new RequestGroupEntityCollection();
            GruposSolicitudes.Add(new RequestsGroupsFactory().Load(GrupoSolicitudesID));

            return this.Save(AppUser, UpdatePassword, GruposSolicitudes, GruposSeguimiento);
        }
        public int Save(ATMUserEntity AppUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
            {
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                AppUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            return m_ATMUserFactory.Save(AppUser, GruposSolicitudes, GruposSeguimiento);
        }
        /*
        public int Save(ATMUserEntity AppUser)
        {
            return m_AppUserFactory.Save(AppUser);
        }*/

        public ATMUserEntity Refresh(ATMUserEntity User)
        {
            return m_ATMUserFactory.Refresh(User);
        }


        public ATMUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_ATMUserFactory.OrderByName = true;
            m_ATMUserFactory.FilFiltroNombreGeneral = Filtro;
            return m_ATMUserFactory.GetAllForRqst(PhxUserRqst);
        }
        public ATMUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_ATMUserFactory.OrderByName = true;
            return m_ATMUserFactory.GetAllForRqst(PhxUserRqst);
        }

        public ATMUserEntity GetATMPwdForRqst(PhxUserEntity PhxUserRqst, int AppUserID)
        {
            return m_ATMUserFactory.GetAppPwdForRqst(PhxUserRqst, AppUserID);
        }

        public string GetPassword(ATMUserEntity user)
        {
            string passEncrypt = m_ATMUserFactory.RefreshPassword(user);
            return DecryptPassword(passEncrypt);
        }

        public string EncryptPassword(string password)
        {
            return new CCryptMgr().encrypt(password);
        }

        public string DecryptPassword(string passwordEncrypter)
        {
            string pwd = new CCryptMgr().decrypt(passwordEncrypter);

            string auxstr = pwd.Replace((char)4, new char());
            auxstr = auxstr.Replace((char)5, new char());
            return auxstr.Replace("\0", string.Empty).Trim();
        }

        public void RefrechGroupsList(ATMUserEntity user)
        {
            m_ATMUserFactory.RefreshPassRequestList(user);
        }





        public bool Exists(string ATMName, string userName)
        {
            return (m_ATMUserFactory.GetATMUser(ATMName, userName) != null);
        }

        public ATMUserEntityCollection GetATMUsers(string ATMName)
        {
            m_ATMUserFactory.FilATMName = ATMName;
            return m_ATMUserFactory.GetAll();
        }

        public void SetPwdState(ATMUserEntityCollection Users, bool Active)
        {
            m_ATMUserFactory.SetPwdState(Users, Active);
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
            return m_ATMUserFactory.GetAll(critico, estadoUsuario, nombre);
		}

        public ATMUserEntity Load(int ID)
        {
            return m_ATMUserFactory.Load(ID);
        }
    }
}
