using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class CommunicationDeviceProtocolEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_cm_dv_protocol_id;
        private string m_cm_dv_protocol_name;
        #endregion

        #region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
        public CommunicationDeviceProtocolEntity()
		{
		}
		#endregion // End of Default ( Empty ) Class Constuctor

        #region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
        public CommunicationDeviceProtocolEntity(
            string cm_dv_protocol_name)
			: this()
		{
            m_cm_dv_protocol_name = cm_dv_protocol_name;
		}
		#endregion // End Required Fields Only Constructor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_cm_dv_protocol_id; }
            set
            {
                m_isChanged |= (m_cm_dv_protocol_id != value);
                m_cm_dv_protocol_id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_cm_dv_protocol_name; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Name", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                m_isChanged |= (m_cm_dv_protocol_name != value);
                m_cm_dv_protocol_name = value;
            }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsChanged
        {
            get { return m_isChanged; }
        }

        #endregion 

        public override string Key
        {
            get
            {
                return m_cm_dv_protocol_id.ToString();
            }
            set
            {
                m_cm_dv_protocol_id = Convert.ToInt32(value);
            }
        }
        
        public override string ToString()
        {
            return m_cm_dv_protocol_name;
        }
    }
}
