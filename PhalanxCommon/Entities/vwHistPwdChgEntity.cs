using System;
using System.Collections.Generic;
using System.Text;
using phxCryptMgr;

namespace PhalanxCommon.Entities
{
    public class vwHistPwdChgEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;
        private int m_id;
        private int m_folio;
        private string m_usuario;
        private DateTime m_d_change;
        private UserTypeEntity m_user_type;
        private PhxUserEntity m_phx_user;
        private string m_password;
        #endregion
        #region Default ( Empty ) Class Constuctor
        public vwHistPwdChgEntity()
        {
            m_folio = 0;
            m_usuario = String.Empty; 

        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties
        public int Id
        {
            get { return m_id; }
            set
            {
                m_isChanged |= (m_id != value);
                m_id = value;
            }

        }
        public int Folio
        {
            get { return m_folio; }
            set
            {
                m_isChanged |= (m_folio != value);
                m_folio = value;
            }

        }
        public string Usuario
        {
            get { return m_usuario; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario", value, "null");

                if (value.Length > 500)
                    throw new ArgumentOutOfRangeException("Invalid value for Usuario", value, value.ToString());

                m_isChanged |= (m_usuario != value); m_usuario = value;
            }
        }
        public DateTime DChange
        {
            get { return m_d_change; }
            set
            {
                m_isChanged |= (m_d_change != value);
                m_d_change = value;
            }

        }
        public UserTypeEntity UserType
        {
            get { return m_user_type; }
            set
            {
                m_isChanged |= (m_user_type != value);
                m_user_type = value;
            }

        }
        public PhxUserEntity PhxUser
        {
            get { return m_phx_user; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for PhxUser", value, "null");

                m_isChanged |= (m_phx_user != value);
                m_phx_user = value;
            }

        }
                /// <summary>
        /// campo de contraseña pensado para encriptación de 448 bits (56 bytes o 112 chars hexa)
        /// </summary>
        public string Password
        {
            get { return m_password; }

            set
            {
                if (value != null && value.Length > 550)
                    throw new ArgumentOutOfRangeException("Invalid value for Password", value, value.ToString());

                m_isChanged |= (m_password != value); m_password = value;
            }
        }
        public string PlainPassword
        {
            get 
            {
                return new CCryptMgr().decrypt(m_password);
            }
        }
        
        #endregion

        public override string Key
        {
            get
            {
                return m_id.ToString();
            }
            set
            {
                m_id = Convert.ToInt32(value);
            }
        }
    }
}
