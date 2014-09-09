using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class CommunicationDeviceUserEntity : UserEntity
    {
        #region Private Members
        private bool m_isChanged;

		private CommunicationDeviceEntity m_cm_dv_id;
        private IList<CommunicationDeviceProtocolEntity> m_CommunicationDeviceProtocolsList;
		#endregion

		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public CommunicationDeviceUserEntity():base()
		{
            m_cm_dv_id = new CommunicationDeviceEntity();
            m_CommunicationDeviceProtocolsList = new List<CommunicationDeviceProtocolEntity>();
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
        public CommunicationDeviceUserEntity(
            CommunicationDeviceEntity cm_dv_id)
			: this()
		{
            m_cm_dv_id = cm_dv_id;
		}
		#endregion // End Required Fields Only Constructor

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>
        public CommunicationDeviceEntity CommunicationDevice
		{
            get { return m_cm_dv_id; }
			set
			{
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for CdId", value, "null");

                m_isChanged |= (m_cm_dv_id != value);
                m_cm_dv_id = value;
			}
		}

        public string CommunicationDeviceName
        {
            get { return CommunicationDevice.Name; }
        }

        public string CommunicationDeviceType
        {
            get { return CommunicationDevice.Type.Name; }
        }

        public IList<CommunicationDeviceProtocolEntity> Protocols
        {
            get { return m_CommunicationDeviceProtocolsList; }
            set { m_CommunicationDeviceProtocolsList = value; }
        }

		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsChanged
		{
			get { return m_isChanged; }
		}
				
		#endregion 
    }
}
