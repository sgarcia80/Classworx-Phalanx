using System;
using System.Collections.Generic;
using System.Text;
using phxCryptMgr;

namespace PhalanxCommon.Entities
{
    public class vwHistPwdVisEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;
        private int m_hist_chg_pwd_acc_id;
        private int m_hist_chg_pwd_id;
        private int m_folio;
        private string m_usuario;
        private UserTypeEntity m_user_type;
        private PhxUserEntity m_phx_user;
        private DateTime m_d_access_date;
        #endregion
        #region Default ( Empty ) Class Constuctor
        public vwHistPwdVisEntity()
        {
            m_folio = 0;
            m_usuario = String.Empty; 

        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties
        public int Id
        {
            get { return m_hist_chg_pwd_acc_id; }
            set
            {
                m_isChanged |= (m_hist_chg_pwd_acc_id != value);
                m_hist_chg_pwd_acc_id = value;
            }

        }
        public int Hist_chg_pwd_id
        {
            get { return m_hist_chg_pwd_id; }
            set
            {
                m_isChanged |= (m_hist_chg_pwd_id != value);
                m_hist_chg_pwd_id = value;
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
        public DateTime AccessDate
        {
            get { return m_d_access_date; }
            set
            {
                m_isChanged |= (m_d_access_date != value);
                m_d_access_date = value;
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
        
        #endregion

        public override string Key
        {
            get
            {
                return m_hist_chg_pwd_acc_id.ToString();
            }
            set
            {
                m_hist_chg_pwd_acc_id = Convert.ToInt32(value);
            }
        }
    }
}
