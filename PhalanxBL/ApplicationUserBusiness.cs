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
    public class ApplicationUserBusiness
    {
        private string _filUserName = "";
        private ApplicationEntity _filApp;
        private ApplicationUserFactory m_AppUserFactory = null;
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
        public ApplicationEntity FilApplication
        {
            set { _filApp = value; }
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



        public ApplicationUserBusiness()
        {
            m_AppUserFactory = new ApplicationUserFactory();   
        }

        public ApplicationUserEntityCollection GetAll() //string Nombre, ApplicationEntity Application)
        {
            if (_filUserName != "")
            {
                m_AppUserFactory.FilUserName = _filUserName;
            }
            if (_filApp != null)
            {
                m_AppUserFactory.FilApplication = _filApp;
            }
            m_AppUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_AppUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_AppUserFactory.OrderByFolio = _orderFolio;
            m_AppUserFactory.OrderByName = _orderName;
            m_AppUserFactory.OrderByUserName = _orderUserName;
            m_AppUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_AppUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;

            return m_AppUserFactory.GetAll();

        }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(ApplicationUserEntity CurrentUser)
        {
            return m_AppUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(ApplicationUserEntity CurrentUser)
        {
            return m_AppUserFactory.GetGruposSeguimiento(CurrentUser);
        }

        public int Save(ApplicationUserEntity AppUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            m_AppUserFactory.SetAvoidInactiveGrps = AvoidGrpInactive;
            if (UpdatePassword)
            {
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                AppUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            return m_AppUserFactory.Save(AppUser, GruposSolicitudes, GruposSeguimiento);
        }

        public int Save(ApplicationUserEntity AppUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
            {
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                AppUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            return m_AppUserFactory.Save(AppUser, GruposSolicitudes, GruposSeguimiento);
        }
        /*
        public int Save(ApplicationUserEntity AppUser)
        {
            return m_AppUserFactory.Save(AppUser);
        }*/

        public ApplicationUserEntity Refresh(ApplicationUserEntity User)
        {
            return m_AppUserFactory.Refresh(User);
        }


        public ApplicationUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_AppUserFactory.OrderByName = true;
            m_AppUserFactory.FilFiltroNombreGeneral = Filtro;
            return m_AppUserFactory.GetAllForRqst(PhxUserRqst);
        }
        public ApplicationUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_AppUserFactory.OrderByName = true;
            return m_AppUserFactory.GetAllForRqst(PhxUserRqst);
        }

        public ApplicationUserEntity GetAppPwdForRqst(PhxUserEntity PhxUserRqst, int AppUserID)
        {
            return m_AppUserFactory.GetAppPwdForRqst(PhxUserRqst, AppUserID);
        }

        public string GetPassword(ApplicationUserEntity user)
        {
            string passEncrypt = m_AppUserFactory.RefreshPassword(user);
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

        public void RefrechGroupsList(ApplicationUserEntity user)
        {
            m_AppUserFactory.RefreshPassRequestList(user);
        }





        public bool Exists(ApplicationEntity AppEntity, string userName)
        {
            return (m_AppUserFactory.GetAppUser(AppEntity, userName) != null);
        }

        public ApplicationUserEntityCollection GetAppUsers(ApplicationEntity Application)
        {
            ApplicationUserFactory DBUsrF = new ApplicationUserFactory();
            DBUsrF.FilApplication = Application;
            return DBUsrF.GetAll();
        }

        public void SetPwdState(ApplicationUserEntityCollection Users, bool Active)
        {
            ApplicationUserFactory DBUsrF = new ApplicationUserFactory();
            DBUsrF.SetPwdState(Users, Active);
        }

		public IList GetAll(bool? critico, bool? estadoUsuario, string nombre)
		{
			return new ApplicationUserFactory().GetAll(critico, estadoUsuario, nombre);
		}

        public ApplicationUserEntity Load(int ID)
        {
            return new ApplicationUserFactory().Load(ID);
        }

        public string getDiasRestantes(string sDuration, DateTime? dModifyingPassDate)
        {
            if (!dModifyingPassDate.HasValue)
                return sDuration;

            string sRestantes = "";
            int duration = 0;

            if (!sDuration.Equals(string.Empty))
                duration = Int32.Parse(sDuration.Trim());

            if (duration == 999)
                return sRestantes;

            TimeSpan? ts = DateTime.Now - dModifyingPassDate;
            if (ts.HasValue)
                sRestantes = (duration - ts.Value.Days).ToString();

            return sRestantes;
        }

        public IList GetProxVencimientos()
        {
            return new ApplicationUserFactory().GetProxVencimientos();
        }

    }
}
