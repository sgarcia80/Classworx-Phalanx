using System;
using System.Data;
using System.Configuration;
using Common;

namespace NDCCommon.Entities
{
    /// <summary>
    /// Summary description for BPMRequestEntity
    /// </summary>
    public class TicketNotificacionClaveEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged;

        private int m_tnc_id;
        private int m_tnc_nro;
        private AplicacionNotificacionClaveEntity m_tnc_app;
        private string m_tnc_app_user;
        private string m_tnc_user_pass;
        private string m_tnc_user_domain;
        private string m_tnc_user;
        private string m_tnc_legajo;
        private string m_tnc_tipo_doc;
        private string m_tnc_nro_doc;
        private bool m_tnc_is_dom_pass;
        private DateTime m_tnc_fecha;
        private DateTime? m_tnc_fecha_ace_tyc;
        private bool m_errado;
        private DateTime? m_tnc_fecha_procesado;
        private int? m_tnc_num_sol_alta;
        private string m_tnc_codigo_gerencia;
        private string m_tnc_nombre_gerencia;
        private string m_tnc_sigla_area;
        private string m_tnc_desc_area;
        private DateTime? m_tnc_fecha_vigencia;
        private string m_tnc_num_leg_solicitud;
        private string m_tnc_cod_emp_sub;
        private string m_tnc_nomb_emp_sub;
        private string m_tnc_nomb_emp_sol;
        private string m_tnc_ape_emp_sol;
        private bool m_tnc_corregido;
        private string m_token;

        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public TicketNotificacionClaveEntity()
        {
            m_tnc_id = 0;
            m_tnc_app_user = string.Empty;
            m_tnc_user_pass = string.Empty;
            m_tnc_user_domain = string.Empty;
            m_tnc_user = string.Empty;
            m_tnc_legajo = string.Empty;
            m_tnc_tipo_doc = string.Empty;
            m_tnc_nro_doc = string.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return m_tnc_id; }
            set
            {
                m_isChanged |= (m_tnc_id != value);
                m_tnc_id = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public int NumeroSolicitud
        {
            get { return m_tnc_nro; }

            set
            {
                m_isChanged |= (m_tnc_nro != value);
                m_tnc_nro = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AplicacionNotificacionClaveEntity Aplicacion
        {
            get { return m_tnc_app; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Aplicación", value, "null");

                m_isChanged |= (m_tnc_app != value);
                m_tnc_app = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UsuarioAplicacion
        {
            get { return m_tnc_app_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario Aplicación", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Usuario Aplicación", value, value.ToString());

                m_isChanged |= (m_tnc_app_user != value);
                m_tnc_app_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PasswordUsuarioAplicacion
        {
            get { return m_tnc_user_pass; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Application Password Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Password Usuario", value, value.ToString());

                m_isChanged |= (m_tnc_user_pass != value);
                m_tnc_user_pass = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DominioUsuario
        {
            get { return m_tnc_user_domain; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Dominio Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Dominio Usuario", value, value.ToString());

                m_isChanged |= (m_tnc_user_domain != value);
                m_tnc_user_domain = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return m_tnc_user; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Usuario", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Application Usuario", value, value.ToString());

                m_isChanged |= (m_tnc_user != value);
                m_tnc_user = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Legajo
        {
            get { return m_tnc_legajo; }

            set
            {
                //if (value == null)
                //    throw new ArgumentOutOfRangeException("Null value not allowed for Legajo", value, "null");

                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Legajo", value, value.ToString());

                m_isChanged |= (m_tnc_legajo != value);
                m_tnc_legajo = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TipoDocumento
        {
            get { return m_tnc_tipo_doc; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Tipo Documento", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Tipo Documento", value, value.ToString());

                m_isChanged |= (m_tnc_tipo_doc != value);
                m_tnc_tipo_doc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Documento
        {
            get { return m_tnc_nro_doc; }

            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Documento", value, "null");

                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Documento", value, value.ToString());

                m_isChanged |= (m_tnc_nro_doc != value);
                m_tnc_nro_doc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EsPasswordDominio
        {
            get { return m_tnc_is_dom_pass; }

            set
            {
                m_isChanged |= (m_tnc_is_dom_pass != value);
                m_tnc_is_dom_pass = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return m_tnc_fecha; }

            set
            {
                m_isChanged |= (m_tnc_fecha != value);
                m_tnc_fecha = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaAceptacionTyC
        {
            get { return m_tnc_fecha_ace_tyc; }

            set
            {
                m_isChanged |= (m_tnc_fecha_ace_tyc != value);
                m_tnc_fecha_ace_tyc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Errado
        {
            get { return m_errado; }

            set
            {
                m_isChanged |= (m_errado != value);
                m_errado = value;
            }
        }

        public DateTime? FechaProcesado
        {
            get { return m_tnc_fecha_procesado; }

            set
            {
                m_isChanged |= (m_tnc_fecha_procesado != value);
                m_tnc_fecha_procesado = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? NumeroSolicitudAltaApp
        {
            get { return m_tnc_num_sol_alta; }
            set
            {
                m_isChanged |= (m_tnc_num_sol_alta != value);
                m_tnc_num_sol_alta = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodigoGerenciaDestino
        {
            get { return m_tnc_codigo_gerencia; }
            set
            {
                m_isChanged |= (m_tnc_codigo_gerencia != value);
                m_tnc_codigo_gerencia = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NombreGerenciaDestino
        {
            get { return m_tnc_nombre_gerencia; }
            set
            {
                m_isChanged |= (m_tnc_nombre_gerencia != value);
                m_tnc_nombre_gerencia = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodigoAreaDestino
        {
            get { return m_tnc_sigla_area; }
            set
            {
                m_isChanged |= (m_tnc_sigla_area != value);
                m_tnc_sigla_area = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NombreAreaDestino
        {
            get { return m_tnc_desc_area; }
            set
            {
                m_isChanged |= (m_tnc_desc_area != value);
                m_tnc_desc_area = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaVigencia
        {
            get { return m_tnc_fecha_vigencia; }
            set
            {
                m_isChanged |= (m_tnc_fecha_vigencia != value);
                m_tnc_fecha_vigencia = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NumeroLegajoEmpleadoSolicitud
        {
            get { return m_tnc_num_leg_solicitud; }
            set
            {
                m_isChanged |= (m_tnc_num_leg_solicitud != value);
                m_tnc_num_leg_solicitud = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodigoEmpresaSubsidiaria
        {
            get { return m_tnc_cod_emp_sub; }
            set
            {
                m_isChanged |= (m_tnc_cod_emp_sub != value);
                m_tnc_cod_emp_sub = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NombreEmpresaSubsidiaria
        {
            get { return m_tnc_nomb_emp_sub; }
            set
            {
                m_isChanged |= (m_tnc_nomb_emp_sub != value);
                m_tnc_nomb_emp_sub = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NombreSolicitante
        {
            get { return m_tnc_nomb_emp_sol; }
            set
            {
                m_isChanged |= (m_tnc_nomb_emp_sol != value);
                m_tnc_nomb_emp_sol = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ApellidoSolicitante
        {
            get { return m_tnc_ape_emp_sol; }
            set
            {
                m_isChanged |= (m_tnc_ape_emp_sol != value);
                m_tnc_ape_emp_sol = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Corregido
        {
            get { return m_tnc_corregido; }
            set
            {
                m_isChanged |= (m_tnc_corregido != value);
                m_tnc_corregido = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Token
        {
            get { return m_token; }
            set
            {
                m_isChanged |= (m_token != value);
                m_token = value;
            }
        }

        public DateTime? AltaTempranaTokenFecha { set; get; }

        public string AltaTempranaTokenTerminal { set; get; }

        public string AltaTempranaTokenUsuario { set; get; }

        public bool ImpactaEnAD { set; get; }

        public DateTime? FechaSeteoMarcaAD { set; get; }

        public DateTime? FechaEliminacionMarcaAD { set; get; }

        public DateTime? FechaExpiracionToken { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int Reclamos { set; get; }

		/// <summary>
		/// 
		/// </summary>
        public int? MailId { set; get; }

        public PhalanxCommon.Entities.MailAlertEntity Mail { set; get; }

        public DateTime? FechaUltimoMail { set; get; }

        public int? EventoId { get; set; }

        public string EventoDescr { get; set; }

        #endregion

        public string TipoDocumentoDesc
        {
            get { return this.m_tnc_tipo_doc; }
        }
        public override string Key
        {
            get
            {
                return this.m_tnc_id.ToString();
            }
            set
            {
                this.m_tnc_id = Convert.ToInt32(value);
            }
        }

        public bool Equivalente(TicketNotificacionClaveEntity ticket)
        {
            bool EsEquivalente = ticket.UsuarioAplicacion.ToLower() == UsuarioAplicacion.ToLower();
            EsEquivalente = EsEquivalente && ticket.PasswordUsuarioAplicacion == PasswordUsuarioAplicacion;
            EsEquivalente = EsEquivalente && ticket.DominioUsuario.ToLower() == DominioUsuario.ToLower();
            EsEquivalente = EsEquivalente && ticket.Usuario.ToLower() == Usuario.ToLower();
            EsEquivalente = EsEquivalente && ticket.Legajo == Legajo;
            EsEquivalente = EsEquivalente && ticket.TipoDocumento == TipoDocumento;
            EsEquivalente = EsEquivalente && ticket.Documento == Documento;
            EsEquivalente = EsEquivalente && ticket.EsPasswordDominio == EsPasswordDominio;
            EsEquivalente = EsEquivalente && ticket.NumeroSolicitudAltaApp == NumeroSolicitudAltaApp;
            EsEquivalente = EsEquivalente && ticket.CodigoGerenciaDestino == CodigoGerenciaDestino;
            EsEquivalente = EsEquivalente && ticket.NombreGerenciaDestino == NombreGerenciaDestino;
            EsEquivalente = EsEquivalente && ticket.CodigoAreaDestino == CodigoAreaDestino;
            EsEquivalente = EsEquivalente && ticket.NombreAreaDestino == NombreAreaDestino;
            if (!ticket.FechaVigencia.HasValue && !FechaVigencia.HasValue)
            {
            }
            else if (ticket.FechaVigencia.HasValue && FechaVigencia.HasValue)
            {
                DateTime D1 = new DateTime(FechaVigencia.Value.Year, FechaVigencia.Value.Month, FechaVigencia.Value.Day, FechaVigencia.Value.Hour
                    , FechaVigencia.Value.Minute, FechaVigencia.Value.Second);
                DateTime D2 = new DateTime(ticket.FechaVigencia.Value.Year, ticket.FechaVigencia.Value.Month, ticket.FechaVigencia.Value.Day
                    , ticket.FechaVigencia.Value.Hour, ticket.FechaVigencia.Value.Minute, ticket.FechaVigencia.Value.Second);
                EsEquivalente = EsEquivalente && (DateTime.Compare(D1, D2) == 0);
            }
            else
            {
                return false;
            }
            
            EsEquivalente = EsEquivalente && ticket.NumeroLegajoEmpleadoSolicitud == NumeroLegajoEmpleadoSolicitud;
            EsEquivalente = EsEquivalente && ticket.CodigoEmpresaSubsidiaria == CodigoEmpresaSubsidiaria;
            EsEquivalente = EsEquivalente && ticket.NombreEmpresaSubsidiaria == NombreEmpresaSubsidiaria;
            EsEquivalente = EsEquivalente && ticket.NombreSolicitante == NombreSolicitante;
            EsEquivalente = EsEquivalente && ticket.ApellidoSolicitante == ApellidoSolicitante;
            return EsEquivalente;
        }

        public bool Expirado()
        {
            return FechaAceptacionTyC == null && FechaExpiracionToken != null && DateTime.Now > FechaExpiracionToken;
        }
    }
}