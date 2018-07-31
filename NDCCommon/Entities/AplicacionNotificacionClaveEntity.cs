using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for ApplicationEntity
    /// </summary>
    public class AplicacionNotificacionClaveEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_anc_id;
        private string m_anc_code;
        private string m_anc_name;
        private bool m_anc_notificable;

        #endregion

        public AplicacionNotificacionClaveEntity()
        {
        }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_anc_id; }
            set
            {
                m_isChanged |= (m_anc_id != value);
                m_anc_id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return m_anc_code; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Application Code", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Code", value, value.ToString());

                m_isChanged |= (m_anc_code != value);
                m_anc_code = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return m_anc_name; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Valor nulo no permitido para la propiedad Nombre", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Valor no válido para la propiedad Nombre", value, value.ToString());

                m_isChanged |= (m_anc_name != value);
                m_anc_name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Notificable
        {
            get { return m_anc_notificable; }

            set
            {
                m_isChanged |= (m_anc_notificable != value);

                m_anc_notificable = value;
            }
        }

        public bool EsAplicacionRed { set; get; }

        public bool EsAplicacionCobis { set; get; }

        public bool EsEmuladores { get; set; }

        public string PrefijoUsuarioTC { get; set; }

        public MacroEntity Macro { get; set; }

        #endregion

        public override string Key
        {
            get
            {
                return this.m_anc_id.ToString();
            }
            set
            {
                this.m_anc_id = Convert.ToInt32(value);
            }
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}