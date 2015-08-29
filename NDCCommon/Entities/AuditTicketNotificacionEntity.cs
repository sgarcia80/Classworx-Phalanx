using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class AuditTicketNotificacionEntity : BaseEntity
    {
        private bool m_isChanged;

        private int m_atn_id;
        private DateTime m_atn_fecha;
        private TicketNotificacionClaveEntity m_atn_tnc;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_atn_id; }
            set
            {
                m_isChanged |= (m_atn_id != value);
                m_atn_id = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return m_atn_fecha; }
            set
            {
                m_isChanged |= (m_atn_fecha != value);
                m_atn_fecha = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public TicketNotificacionClaveEntity Ticket
        {
            get { return m_atn_tnc; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Ticket", value, "null");

                m_isChanged |= (m_atn_tnc != value);
                m_atn_tnc = value;
            }
        }

        public override string Key
        {
            get
            {
                return m_atn_id.ToString();
            }
            set
            {
                m_atn_id = Convert.ToInt32(value);
            }
        }
    }
}
