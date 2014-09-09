using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public sealed class PhxUserSuperiorEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;
        private int m_sup_id;
        private string m_sup_name;
        private string m_sup_mail; 
        private IList m_PhxUsersList;
        #endregion

        public PhxUserSuperiorEntity()
        {
            m_sup_id = 0;
            m_PhxUsersList = new ArrayList();
            m_sup_name = String.Empty;
            m_sup_mail = String.Empty;

        }
        #region Public Properties
        public int Id
        {
            get { return m_sup_id; }
            set
            {
                m_isChanged |= (m_sup_id != value);
                m_sup_id = value;
            }

        }
        public string Name
        {
            get { return m_sup_name; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Name", value, "null");

                if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                m_isChanged |= (m_sup_name != value); m_sup_name = value;
            }
        }

        public string Mail
        {
            get { return m_sup_mail; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Mail", value, "null");

                if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Invalid value for Mail", value, value.ToString());

                m_isChanged |= (m_sup_mail != value); m_sup_mail = value;
            }
        }
        public IList PhxUsersList
        {
            get
            {
                return m_PhxUsersList;
            }
            set
            {
                m_PhxUsersList = value;
            }
        }

        #endregion

        public override string Key
        {
            get
            {
                return m_sup_id.ToString();
            }
            set
            {
                m_sup_id = Convert.ToInt32(value);
            }
        }
        public override string ToString()
        {
            string strNameMail = Name;
            if (Mail != "")
            {
                strNameMail += " (" + Mail + ")";
            }
            return strNameMail;
        }
    }
}
