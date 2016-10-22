using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class HistPasswordChangeAccessEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_id;
        private HistPasswordChangeEntity m_histChgPwd;
        private PhxUserEntity m_phxUser;
        private DateTime m_AccessDate;
        #endregion


		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public HistPasswordChangeAccessEntity()
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

        public HistPasswordChangeEntity HistChgPwd
        {
            get { return m_histChgPwd; }
            set
            {
                m_isChanged |= (m_histChgPwd != value);
                m_histChgPwd = value;
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

        public DateTime AccessDate
        {
            get { return m_AccessDate; }
            set
            {
                m_isChanged |= (m_AccessDate != value);
                m_AccessDate = value;
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
