using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class HistPasswordChangeEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_id;
        private UserEntity m_user;
        private PhxUserEntity m_phxUser;
        private DateTime m_dChange;
        private string m_password;
        #endregion


		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public HistPasswordChangeEntity()
		{
			m_id = 0; 
        }
		#endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_id; }
            set
            {
                m_isChanged |= (m_id != value);
                m_id = value;
            }

        }

        public UserEntity User
        {
            get { return m_user; }
            set
            {
                m_isChanged |= (m_user != value);
                m_user = value;
            }

        }

        public PhxUserEntity PhxUser
        {
            get { return m_phxUser; }
            set
            {
                m_isChanged |= (m_phxUser != value);
                m_phxUser = value;
            }

        }

        public DateTime DChange
        {
            get { return m_dChange; }
            set
            {
                m_isChanged |= (m_dChange != value);
                m_dChange = value;
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
