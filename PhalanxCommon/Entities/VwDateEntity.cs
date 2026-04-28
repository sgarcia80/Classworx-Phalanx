using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    /// <summary>
    /// Esta clase se usa para traer el getdate del motor consultando una vista creada a tal fin
    /// </summary>
    [Serializable]
    public class VwDateEntity
    {
        private DateTime m_getdate;

        public VwDateEntity()
        {
            // por defecto setea la fecha actual de la PC
            m_getdate = DateTime.Now;
        }

        public DateTime GetDate
        {
            get { return m_getdate; }
            set { m_getdate = value; }
        }
    
    }
}
