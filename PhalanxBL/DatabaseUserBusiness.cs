using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using phxCryptMgr;

namespace PhalanxBL
{
    public class DatabaseUserBusiness
    {
        private DataBaseEntity _filDB;
        public DataBaseEntity FilDB
        {
            set { _filDB = value; }
        }

        private DatabaseTypeEntity _filTipoDB;
        public DatabaseTypeEntity FilTipoDB
        {
            set { _filTipoDB = value; }
        }

        private string _filNombre = "";
        private DatabaseUserFactory m_DBUserFactory = null;
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

        public DatabaseUserBusiness()
        {
            m_DBUserFactory = new DatabaseUserFactory();
        }

        public DatabaseUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_DBUserFactory.OrderByName = true;
            m_DBUserFactory.FilFiltroNombreGeneral = Filtro;
            DatabaseUserEntityCollection tmpCollection = m_DBUserFactory.GetAllForRqst(PhxUserRqst);
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                DatabaseUserEntity tmpUser = tmpCollection[i];
                m_DBUserFactory.RefreshRequestList(ref tmpUser);
            }
            return tmpCollection;
        }

        public DatabaseUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_DBUserFactory.OrderByName = true;
            DatabaseUserEntityCollection tmpCollection = m_DBUserFactory.GetAllForRqst(PhxUserRqst);
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                DatabaseUserEntity tmpUser = tmpCollection[i];
                m_DBUserFactory.RefreshRequestList(ref tmpUser);
            }
            return tmpCollection;
        }

        public DatabaseUserEntity GetDBPwdForRqst(PhxUserEntity PhxUserRqst, int DbUserID)
        {
            return m_DBUserFactory.GetDBPwdForRqst(PhxUserRqst, DbUserID);
        }

        public DatabaseUserEntityCollection GetAll()
        {
            m_DBUserFactory.FilUserName = _filNombre;
            m_DBUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_DBUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            m_DBUserFactory.OrderByFolio = _orderFolio;
            m_DBUserFactory.OrderByName = _orderName;
            m_DBUserFactory.OrderByUserName = _orderUserName;
            m_DBUserFactory.FilTipoDB = _filTipoDB;
            m_DBUserFactory.FilDB = _filDB;
            m_DBUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_DBUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;

            return m_DBUserFactory.GetAll();
        }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(DatabaseUserEntity CurrentUser)
        {
            return m_DBUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(DatabaseUserEntity CurrentUser)
        {
            return m_DBUserFactory.GetGruposSeguimiento(CurrentUser);
        }

        public int Save(DatabaseUserEntity DBUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
            {
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                DBUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            return m_DBUserFactory.Save(DBUser, GruposSolicitudes, GruposSeguimiento);

        }
        public int Save(DatabaseUserEntity DBUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            m_DBUserFactory.SetAvoidInactiveGrps = AvoidGrpInactive;
            if (UpdatePassword)
            {
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                DBUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;
            }
            return m_DBUserFactory.Save(DBUser, GruposSolicitudes, GruposSeguimiento);

        }

        public string GetPassword(DatabaseUserEntity user)
        {
            string passEncrypt = m_DBUserFactory.RefreshPassword(user);
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

        public void RefrechGroupsList(DatabaseUserEntity user)
        {
            m_DBUserFactory.RefreshPassRequestList(user);
        }

        public bool Exists(DataBaseEntity DBEntity, string userName)
        {
            return (m_DBUserFactory.GetDBUser(DBEntity, userName) != null);
        }
        public DatabaseUserEntityCollection GetDBUsers(DataBaseEntity DataBase)
        {
            DatabaseUserFactory DBUsrF = new DatabaseUserFactory();
            DBUsrF.FilDB = DataBase;
            return DBUsrF.GetAll();
        }


        public void SetPwdState(DatabaseUserEntityCollection Users, bool Active)
        {
            DatabaseUserFactory DBUsrF = new DatabaseUserFactory();
            DBUsrF.SetPwdState(Users, Active);
        }

        public DatabaseUserEntity Refresh(DatabaseUserEntity User)
        {
            return m_DBUserFactory.Refresh(User);
        }

		public System.Collections.IList GetAll(bool? critico, bool? estadoUsuario, DatabaseTypeEntity tipo, string nombre)
		{
			return new DatabaseUserFactory().GetAll(critico, estadoUsuario, tipo != null ? new int?(tipo.Id) : null, nombre);
		}
    }
}
