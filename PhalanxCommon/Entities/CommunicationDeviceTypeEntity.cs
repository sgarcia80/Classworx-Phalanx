using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public sealed class CommunicationDeviceTypeEntity: BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_cm_dv_type_id;
        private string m_cm_dv_type_name;
        #endregion

        #region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
        public CommunicationDeviceTypeEntity()
		{
		}
		#endregion // End of Default ( Empty ) Class Constuctor

        #region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
        public CommunicationDeviceTypeEntity(
            string cm_dv_type_name)
			: this()
		{
            m_cm_dv_type_name = cm_dv_type_name;
		}
		#endregion // End Required Fields Only Constructor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_cm_dv_type_id; }
            set
            {
                m_isChanged |= (m_cm_dv_type_id != value);
                m_cm_dv_type_id = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_cm_dv_type_name; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Name", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                m_isChanged |= (m_cm_dv_type_name != value);
                m_cm_dv_type_name = value;
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
                return m_cm_dv_type_id.ToString();
            }
            set
            {
                m_cm_dv_type_id = Convert.ToInt32(value);
            }
        }
        public override string ToString()
        {
            return m_cm_dv_type_name;
        }
    }
}
