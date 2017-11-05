using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for BPMRequestEntity
    /// </summary>
    public class TicketNotificacionTarjetaEntity : BaseEntity
    {
        public enum EstadoTicket
        {
            Ninguno,
            Ingresado,
            Generado,
            Procesado,
            Error
        }

        public const int TipoNotificacionBlanqueoApp = 1;
        public const int TipoNotificacionBlanqueoRed = 2;
        public const int TipoNotificacionDesbloqueo = 3;

        public static TicketNotificacionTarjetaEntity CreateTicket()
        {
            return new TicketNotificacionTarjetaEntity();
        }

        #region Private Members
        private bool m_isChanged;

        private int m_tnt_id;
        private int? m_tnt_numero;
        private AplicacionNotificacionClaveEntity m_tnt_app;
        
        private string m_tnt_app_user;
        private string m_tnt_app_user_pass;
        
        private string m_tnt_user_domain;
        private string m_tnt_user;

        private string m_tnt_solicitante;
        private string m_tnt_user_load;

        private DateTime m_tnt_fecha;
        private DateTime? m_tnt_fecha_cierre;

        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public TicketNotificacionTarjetaEntity()
        {
            m_tnt_id = 0;
            m_tnt_app_user = string.Empty;
            m_tnt_app_user_pass = string.Empty;
            m_tnt_user_domain = string.Empty;
            m_tnt_user = string.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_tnt_id; }
            set
            {
                m_isChanged |= (m_tnt_id != value);
                m_tnt_id = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public int? NumeroSolicitud
        {
            get { return m_tnt_numero; }
            set
            {
                m_isChanged |= (m_tnt_numero != value);
                m_tnt_numero = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public AplicacionNotificacionClaveEntity Aplicacion
        {
            get { return m_tnt_app; }

            set
            {
                m_isChanged |= (m_tnt_app != value);
                m_tnt_app = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioAplicacion
        {
            get { return m_tnt_app_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario Aplicación", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Usuario Aplicación", value, value.ToString());

                m_isChanged |= (m_tnt_app_user != value);
                m_tnt_app_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PasswordUsuarioAplicacion
        {
            get { return m_tnt_app_user_pass; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Application Password Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Password Usuario", value, value.ToString());

                m_isChanged |= (m_tnt_app_user_pass != value);
                m_tnt_app_user_pass = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioDominio
        {
            get { return m_tnt_user_domain; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Dominio Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Dominio Usuario", value, value.ToString());

                m_isChanged |= (m_tnt_user_domain != value);
                m_tnt_user_domain = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return m_tnt_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Usuario", value, value.ToString());

                m_isChanged |= (m_tnt_user != value);
                m_tnt_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Solicitante
        {
            get { return m_tnt_solicitante; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Solicitante", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Solicitante", value, value.ToString());

                m_isChanged |= (m_tnt_solicitante != value);
                m_tnt_solicitante = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioCarga
        {
            get { return m_tnt_user_load; }

            set
            {
                m_isChanged |= (m_tnt_user_load != value);
                m_tnt_user_load = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return m_tnt_fecha; }

            set
            {
                m_isChanged |= (m_tnt_fecha != value);
                m_tnt_fecha = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaNotificado
        {
            get { return m_tnt_fecha_cierre; }

            set
            {
                m_isChanged |= (m_tnt_fecha_cierre != value);
                m_tnt_fecha_cierre = value;
            }
        }

        public DateTime? FechaProcesado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EstadoTicket Estado { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int? MailId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public MacroErrorEntity Error { set; get; }

        public int Reclamos { get; set; }

        #endregion

        public override string Key
        {
            get
            {
                return this.m_tnt_id.ToString();
            }
            set
            {
                this.m_tnt_id = Convert.ToInt32(value);
            }
        }
    }
}