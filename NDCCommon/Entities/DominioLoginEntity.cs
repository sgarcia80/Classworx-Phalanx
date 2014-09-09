using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for ApplicationEntity
    /// </summary>
    public class DominioLoginEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_id;
        private string m_nombre;
        private string m_direccionAD;

        #endregion

        public DominioLoginEntity()
        {
        }

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

        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return m_nombre; }

            set
            {
                m_nombre = value;
            }
        }

        public string DireccionAD
        {
            get { return m_direccionAD; }

            set
            {
                m_direccionAD = value;
            }
        }

        #endregion

        public override string Key
        {
            get
            {
                return this.m_id.ToString();
            }
            set
            {
                this.m_id = Convert.ToInt32(value);
            }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}