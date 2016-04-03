using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for BPMRequestEntity
    /// </summary>
    public class TicketNotificacionEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_id;
        private int m_numerosolicitud;
        private string m_tipo;
        private string m_usuario;
        private string m_dominio;
        private AplicacionNotificacionClaveEntity m_aplicacion;
        private DateTime m_fecha;

        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public TicketNotificacionEntity()
        {
            m_id = 0;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

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
        public string Tipo
        {
            get { return m_tipo; }

            set
            {
                m_isChanged |= (m_tipo != value);
                m_tipo = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumeroSolicitud
        {
            get { return m_numerosolicitud; }
            set
            {
                m_isChanged |= (m_numerosolicitud != value);
                m_numerosolicitud = value;
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        public AplicacionNotificacionClaveEntity Aplicacion
        {
            get { return m_aplicacion; }

            set
            {
                m_isChanged |= (m_aplicacion != value);
                m_aplicacion = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return m_usuario; }

            set
            {
                m_isChanged |= (m_usuario != value);
                m_usuario = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Dominio
        {
            get { return m_dominio; }

            set
            {
                m_isChanged |= (m_dominio != value);
                m_dominio = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return m_fecha; }

            set
            {
                m_isChanged |= (m_fecha != value);
                m_fecha = value;
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