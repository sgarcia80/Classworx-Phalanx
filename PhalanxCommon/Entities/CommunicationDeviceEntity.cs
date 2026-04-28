using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class CommunicationDeviceEntity : BaseEntity
    {
        #region Private Members
		private bool m_isChanged;

		private int m_cm_dv_id;
        private IList<CommunicationDeviceProtocolEntity> m_CommunicationDeviceProtocolsList;
        private IList<CommunicationDeviceUserEntity> m_CommunicationDeviceUsersList;
		private CommunicationDeviceTypeEntity m_cm_dv_type_id; 
		private string m_cm_dv_name; 
		private string m_cm_dv_description; 
        private string m_cm_dv_ip; 
		private bool m_active = true;

		#endregion

		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public CommunicationDeviceEntity()
		{
			m_cm_dv_id = 0; 
            m_CommunicationDeviceProtocolsList = new List<CommunicationDeviceProtocolEntity>();
            m_CommunicationDeviceUsersList = new List<CommunicationDeviceUserEntity>();
			m_cm_dv_type_id = new CommunicationDeviceTypeEntity(); 
			m_cm_dv_name = String.Empty; 
			m_cm_dv_description = String.Empty; 
			m_cm_dv_ip = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
        public CommunicationDeviceEntity(
            CommunicationDeviceTypeEntity cm_dv_type_id,
            string cm_dv_name, string cm_dv_ip)
			: this()
		{
            m_cm_dv_type_id = cm_dv_type_id;
            m_cm_dv_name = cm_dv_name;
            m_cm_dv_ip = cm_dv_ip;
		}
		#endregion // End Required Fields Only Constructor

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return m_cm_dv_id; }
			set
			{
				m_isChanged |= ( m_cm_dv_id != value ); 
				m_cm_dv_id = value;
			}

		}

        public IList<CommunicationDeviceProtocolEntity> Protocols
        {
            get { return m_CommunicationDeviceProtocolsList; }
            set { m_CommunicationDeviceProtocolsList = value; }
        }

        public IList<CommunicationDeviceUserEntity> Users
        {
            get { return m_CommunicationDeviceUsersList; }
            set { m_CommunicationDeviceUsersList = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        public CommunicationDeviceTypeEntity Type
		{
			get { return m_cm_dv_type_id; }
			set
			{
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for TypeId", value, "null");

				m_isChanged |= ( m_cm_dv_type_id != value );
                m_cm_dv_type_id = value;
			}

		}
			
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return m_cm_dv_name; }

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for Name", value, "null");
				
				if(  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                m_isChanged |= (m_cm_dv_name != value);
                m_cm_dv_name = value;
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get { return m_cm_dv_description; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());

                m_isChanged |= (m_cm_dv_description != value);
                m_cm_dv_description = value;
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			get { return m_cm_dv_ip; }

			set	
			{
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Ip", value, "null");

                if (value.Length > 15)
                    throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());

                m_isChanged |= (m_cm_dv_ip != value);
                m_cm_dv_ip = value;
			}
		}

        public bool Active
        {
            get { return m_active; }
            set
            {
                m_isChanged |= (m_active != value);
                m_active = value;
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
                return m_cm_dv_id.ToString();
            }
            set
            {
                m_cm_dv_id = Convert.ToInt32(value);
            }
        }
        
        public override string ToString()
        {
            return m_cm_dv_name;
        }
    }
}
