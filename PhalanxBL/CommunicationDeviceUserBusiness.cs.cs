using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxCommon.Collections;
using phxCryptMgr;

namespace PhalanxBL
{
    public class CommunicationDeviceUserBusiness
    {
        private CommunicationDeviceTypeEntity _filTipoEC;
        private CommunicationDeviceEntity _filEC;
        private string _filNombre = "";
        private CommunicationDeviceProtocolEntity _filProtocol;
        private CommunicationDeviceUserFactory m_CDUserFactory = null;
        private bool _orderName = false;
        private bool _orderUserName = false;
        private bool _orderFolio = false;
        public bool GetGruposAsignados = false;
        public bool GetGruposSeguimAsignados = false;

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

        
        public CommunicationDeviceTypeEntity FilTipoEC
        {
            set { _filTipoEC = value; }
        }

        public CommunicationDeviceEntity FilEC
        {
            set { _filEC = value; }
        }

        public CommunicationDeviceProtocolEntity FilProtocol
        {
            set { _filProtocol = value; }
        }

        public string FilNombre
        {
            set { _filNombre = value; }
        }

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

        public CommunicationDeviceUserBusiness()
        {
            m_CDUserFactory = new CommunicationDeviceUserFactory();
        }

        public CommunicationDeviceUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst, string Filtro)
        {
            m_CDUserFactory.OrderByName = true;
            m_CDUserFactory.FilFiltroNombreGeneral = Filtro;
            CommunicationDeviceUserEntityCollection tmpCollection = m_CDUserFactory.GetAllForRqst(PhxUserRqst);
            
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                CommunicationDeviceUserEntity tmpUser = tmpCollection[i];
                m_CDUserFactory.RefreshRequestList(ref tmpUser);
            }

            return tmpCollection;
        }

        public CommunicationDeviceUserEntityCollection GetAllForRqst(PhxUserEntity PhxUserRqst)
        {
            m_CDUserFactory.OrderByName = true;

            CommunicationDeviceUserEntityCollection tmpCollection = m_CDUserFactory.GetAllForRqst(PhxUserRqst);
            
            for (int i = 0; i < tmpCollection.Count; i++)
            {
                CommunicationDeviceUserEntity tmpUser = tmpCollection[i];
                m_CDUserFactory.RefreshRequestList(ref tmpUser);
            }

            return tmpCollection;
        }
        /*
        public DatabaseUserEntity GetDBPwdForRqst(PhxUserEntity PhxUserRqst, int DbUserID)
        {
            return m_DBUserFactory.GetDBPwdForRqst(PhxUserRqst, DbUserID);
        }
         * */

        public CommunicationDeviceUserEntityCollection GetAll()
        {
            m_CDUserFactory.FilUserName = _filNombre;
            m_CDUserFactory.OrderByFolio = _orderFolio;
            m_CDUserFactory.OrderByName = _orderName;
            m_CDUserFactory.OrderByUserName = _orderUserName;
            m_CDUserFactory.FilTipoEC = _filTipoEC;
            m_CDUserFactory.FilEC = _filEC;
            m_CDUserFactory.FilProtocol = _filProtocol;
            m_CDUserFactory.GetGruposAsignados = this.GetGruposAsignados;
            m_CDUserFactory.GetGruposSeguimAsignados = this.GetGruposSeguimAsignados;
            m_CDUserFactory.FilUsuariosActivos = _filUsuariosActivos;
            m_CDUserFactory.FilUsuariosCriticos = _filUsuariosCriticos;
            return m_CDUserFactory.GetAll();
        }

        public CommunicationDeviceUserEntity Refresh(CommunicationDeviceUserEntity CDUser)
        {
            return m_CDUserFactory.Refresh(CDUser);
        }

        public RqstGrpPwdEntityCollection GetGruposSolicitudes(CommunicationDeviceUserEntity CurrentUser)
        {
            return m_CDUserFactory.GetGruposSolicitudes(CurrentUser);
        }

        public FollowupRequestGroupPasswordEntityCollection GetGruposSeguimiento(CommunicationDeviceUserEntity CurrentUser)
        {
            return m_CDUserFactory.GetGruposSeguimiento(CurrentUser);
        }

        public int Save(CommunicationDeviceUserEntity CDUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento)
        {
            if (UpdatePassword)
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                CDUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;

            return m_CDUserFactory.Save(CDUser, GruposSolicitudes, GruposSeguimiento);
        }
        public int Save(CommunicationDeviceUserEntity CDUser, bool UpdatePassword, RequestGroupEntityCollection GruposSolicitudes, FollowupRequestGroupEntityCollection GruposSeguimiento, bool AvoidGrpInactive)
        {
            m_CDUserFactory.SetAvoidInactiveGrps = AvoidGrpInactive;
            if (UpdatePassword)
                // si se cambia la contraseña, se establece la fecha de cambio traida del server
                CDUser.UserPassword.DLastChange = new GetDateBusiness().GetDate().GetDate;

            return m_CDUserFactory.Save(CDUser, GruposSolicitudes, GruposSeguimiento);
        }

        public string GetPassword(CommunicationDeviceUserEntity user)
        {
            string passEncrypt = m_CDUserFactory.RefreshPassword(user);
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

        public void RefreshGroupsList(CommunicationDeviceUserEntity user)
        {
            m_CDUserFactory.RefreshPassRequestList(user);
        }
        
        public bool Exists(CommunicationDeviceEntity CDEntity, string userName)
        {
            return (m_CDUserFactory.GetCDUser(CDEntity, userName) != null);
        }
        
        public CommunicationDeviceUserEntityCollection GetCDUsers(CommunicationDeviceEntity communicationDevice)
        {
            CommunicationDeviceUserFactory CDUsrF = new CommunicationDeviceUserFactory();
            CDUsrF.FilEC = communicationDevice;

            return CDUsrF.GetAll();
        }

        public void SetPwdState(CommunicationDeviceUserEntityCollection Users, bool Active)
        {
            CommunicationDeviceUserFactory CDUsrF = new CommunicationDeviceUserFactory();
            CDUsrF.SetPwdState(Users, Active);
        }
    }
}
