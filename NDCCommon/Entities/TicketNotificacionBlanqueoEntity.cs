using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for BPMRequestEntity
    /// </summary>
    public class TicketNotificacionBlanqueoEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_tnb_id;
        private AplicacionNotificacionClaveEntity m_tnb_app;
        private string m_tnb_app_user;
        private string m_tnb_user_pass;
        private string m_tnb_user_domain;
        private string m_tnb_solicitante;
        private DateTime? m_tnb_fecha_vigencia;
        private DateTime? m_tnb_fecha_ace_tyc;
        
        private string m_tnb_user;
        private DateTime m_tnb_fecha;

        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public TicketNotificacionBlanqueoEntity()
        {
            m_tnb_id = 0;
            m_tnb_app_user = string.Empty;
            m_tnb_user_pass = string.Empty;
            m_tnb_user_domain = string.Empty;
            m_tnb_user = string.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_tnb_id; }
            set
            {
                m_isChanged |= (m_tnb_id != value);
                m_tnb_id = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public AplicacionNotificacionClaveEntity Aplicacion
        {
            get { return m_tnb_app; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Aplicación", value, "null");

                m_isChanged |= (m_tnb_app != value);
                m_tnb_app = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioAplicacion
        {
            get { return m_tnb_app_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario Aplicación", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Usuario Aplicación", value, value.ToString());

                m_isChanged |= (m_tnb_app_user != value);
                m_tnb_app_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PasswordUsuarioAplicacion
        {
            get { return m_tnb_user_pass; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Application Password Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Password Usuario", value, value.ToString());

                m_isChanged |= (m_tnb_user_pass != value);
                m_tnb_user_pass = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioDominio
        {
            get { return m_tnb_user_domain; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Dominio Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Dominio Usuario", value, value.ToString());

                m_isChanged |= (m_tnb_user_domain != value);
                m_tnb_user_domain = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return m_tnb_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Usuario", value, value.ToString());

                m_isChanged |= (m_tnb_user != value);
                m_tnb_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Solicitante
        {
            get { return m_tnb_solicitante; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Solicitante", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Solicitante", value, value.ToString());

                m_isChanged |= (m_tnb_solicitante != value);
                m_tnb_solicitante = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return m_tnb_fecha; }

            set
            {
                m_isChanged |= (m_tnb_fecha != value);
                m_tnb_fecha = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaVigencia
        {
            get { return m_tnb_fecha_vigencia; }

            set
            {
                m_isChanged |= (m_tnb_fecha_vigencia != value);
                m_tnb_fecha_vigencia = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaAceptacionTyC
        {
            get { return m_tnb_fecha_ace_tyc; }

            set
            {
                m_isChanged |= (m_tnb_fecha_ace_tyc != value);
                m_tnb_fecha_ace_tyc = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public int? MailId { set; get; }

        #endregion

        public override string Key
        {
            get
            {
                return this.m_tnb_id.ToString();
            }
            set
            {
                this.m_tnb_id = Convert.ToInt32(value);
            }
        }

        //public bool Equivalente(TicketNotificacionBlanqueoEntity ticket)
        //{s
        //    bool EsEquivalente = ticket.UsuarioAplicacion.ToLower() == UsuarioAplicacion.ToLower();
        //    EsEquivalente = EsEquivalente && ticket.PasswordUsuarioAplicacion == PasswordUsuarioAplicacion;
        //    EsEquivalente = EsEquivalente && ticket.DominioUsuarioAplicacion.ToLower() == DominioUsuarioAplicacion.ToLower();
        //    EsEquivalente = EsEquivalente && ticket.Usuario.ToLower() == Usuario.ToLower();

        //    return EsEquivalente;
        //}
    }
}