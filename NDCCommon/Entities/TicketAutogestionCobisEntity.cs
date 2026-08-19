using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for BPMRequestEntity
    /// </summary>
    public class TicketAutogestionCobisEntity : BaseEntity
    {
        public const int Desconexion = 3;
        public const int TipoBlanqueo = 2;
        public const int TipoDesbloqueo = 1;

        public static TicketAutogestionCobisEntity CreateDesbloqueo()
        {
            return new TicketAutogestionCobisEntity { TipoNotificacion = TipoDesbloqueo };
        }

        public static TicketAutogestionCobisEntity CreateBlanqueo()
        {
            return new TicketAutogestionCobisEntity { TipoNotificacion = TipoBlanqueo };
        }

        #region Private Members
        private bool m_isChanged;

        private int m_tac_id;
        private int m_tac_tipo_notif;
        private string m_tac_user;
        private DateTime m_tac_fecha;
        private long? m_tac_respuesta_codigo;
        private string m_tac_respuesta_mensaje;

        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public TicketAutogestionCobisEntity()
        {
            //m_tac_id = 0;
            //m_tac_app_user = string.Empty;
            //m_tac_app_user_pass = string.Empty;
            //m_tac_user_domain = string.Empty;
            //m_tac_user = string.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TipoNotificacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TipoNotificacionDescr
        {
            get
            {
                string tipo = string.Empty;
                switch (this.TipoNotificacion)
                {
                    case Desconexion:
                        tipo = "Desconexion";
                        break;
                    case TipoDesbloqueo:
                        tipo = "Desbloqueo";
                        break;
                    case TipoBlanqueo:
                        tipo = "Blanqueo";
                        break;
                    default:
                        tipo = "N/A";
                        break;
                }
                return tipo;
            }
            set
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha { get; set; }
        //{
        //    get { return m_tac_fecha; }

        //    set
        //    {
        //        m_isChanged |= (m_tac_fecha != value);
        //        m_tac_fecha = value;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public long RespuestaCodigo { get; set; }
        //{
        //    get { return m_tac_reclamos; }
        //    set
        //    {
        //        m_isChanged |= (m_tac_reclamos != value);
        //        m_tac_reclamos = value;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public string RespuestaMensaje { get; set; }

        #endregion

        public override string Key
        {
            get
            {
                return this.m_tac_id.ToString();
            }
            set
            {
                this.m_tac_id = Convert.ToInt32(value);
            }
        }
    }
}