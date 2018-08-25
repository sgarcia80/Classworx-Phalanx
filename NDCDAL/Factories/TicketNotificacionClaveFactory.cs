using System;
using System.Data;
using System.Configuration;
using NHibernate;
using NDCCommon.Entities;
using NDCDAL;
using NDCCommon.Collections;
using System.Collections.Generic;
using NHibernate.Expression;
using PhalanxDAL;
using log4net;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketNotificacionClaveFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TicketNotificacionClaveFactory));

        private AplicacionNotificacionClaveEntity _filApp = null;
        private string _filUsuario;
        private string _filUsuarioApp;
        private string _filDominio;
        private DateTime? _filFecha;
        private DateTime? _filFechaDesde;
        private DateTime? _filFechaHasta;
        private string _filTipoDoc;
        private string _filDoc;
        private bool? _filErrado;
        private bool? _filSinLegajo;
        private int? _filTicket;
        private bool? _filCorregido = false;
        private DateTime? _filFilFechaVigencia;

        public AplicacionNotificacionClaveEntity FilAplicacion
        {
            set { _filApp = value; }
        }

        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public string FilUsuarioApp
        {
            set { _filUsuarioApp = value; }
        }

        public string FilDominio
        {
            set { _filDominio = value; }
        }

        public DateTime? FilFecha
        {
            set { _filFecha = value; }
        }

        public DateTime? FilFechaDesde
        {
            set { _filFechaDesde = value; }
        }

        public DateTime? FilFechaHasta
        {
            set { _filFechaHasta = value; }
        }

        public DateTime? FilFechaVigencia
        {
            set { _filFilFechaVigencia = value; }
        }

        public string FilTipoDocumento
        {
            set { _filTipoDoc = value; }
        }

        public string FilDocumento
        {
            set { _filDoc = value; }
        }

        public bool? FilFechaTyCNull { set; get; }

        public bool FilErrado
        {
            set { _filErrado = value; }
        }

        public bool? FilSinLegajo
        {
            set { _filSinLegajo = value; }
        }

        public int? FilTicket
        {
            set { _filTicket = value; }
        }

        public bool? FilCorregido
        {
            set { _filCorregido = value; }
        }

        public bool? FilImpactaEnAD { set; private get; }

        public bool? FilMarcadoEnAD { set; private get; }

        public bool? FilMarcaEliminadaEnAD { set; private get; }

        public bool? FilVisualizado { set; private get; }

        public bool? FilVencido { set; private get; }

        public bool FilReporteNotif { set; private get; }

        public TicketNotificacionClaveFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SaveBPMSolicitud(TicketNotificacionClaveEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(entidad);
                    //session.Refresh(entidad);
                    tx.Commit();
                    session.Refresh(entidad);
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw e; //new SystemException(e.Message);
                }
            }
        }

        public void DeleteBPMSolicitud(TicketNotificacionClaveEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();
                    session.Delete(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw e; //new SystemException(e.Message);
                }
            }
        }

        public TicketNotificacionClaveEntityCollection GetAll()
        {
            IList<TicketNotificacionClaveEntity> tickets;

            TicketNotificacionClaveEntityCollection TiNotClaEC = new TicketNotificacionClaveEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionClaveEntity), "TNC");

                if (_filApp != null)
                {
                    DataSearch.Add(Expression.Eq("TNC.Aplicacion", _filApp));
                }
                if (_filUsuarioApp != null && !string.IsNullOrEmpty(_filUsuarioApp))
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.UsuarioAplicacion", _filUsuarioApp));
                }
                if (_filUsuario != null && !string.IsNullOrEmpty(_filUsuario))
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.Usuario", _filUsuario));
                }
                if (_filDominio != null && !string.IsNullOrEmpty(_filDominio))
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.DominioUsuario", _filDominio));
                }
                if (_filFecha != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.Fecha", _filFecha));
                }
                if (_filFechaDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("TNC.Fecha", _filFechaDesde));
                }
                if (_filFechaHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Le("TNC.Fecha", _filFechaHasta));
                }
                if (_filTipoDoc != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.TipoDocumento", _filTipoDoc));
                }
                if (_filTicket != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.NumeroSolicitud", _filTicket));
                }
                if (_filDoc != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.Documento", _filDoc));
                }
                if (FilFechaTyCNull != null)
                {
                    if (FilFechaTyCNull.Value)
                    {
                        DataSearch = DataSearch.Add(Expression.IsNull("TNC.FechaAceptacionTyC"));
                    }
                    else
                    {
                        DataSearch = DataSearch.Add(Expression.IsNotNull("TNC.FechaAceptacionTyC"));
                        DataSearch = DataSearch.Add(Expression.Not(Expression.Eq("TNC.FechaAceptacionTyC", new DateTime(1900,1,1))));

                    }
                }
                if (_filErrado != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.Errado", _filErrado));
                }
                if (_filFilFechaVigencia != null)
                {
                    DataSearch = DataSearch.Add(Expression.Or(Expression.IsNull("TNC.FechaVigencia"),
                        Expression.Le("TNC.FechaVigencia", _filFilFechaVigencia.Value)));
                }

                if (FilReporteNotif && _filApp == null)
                {
                    DataSearch.CreateCriteria("TNC.Aplicacion", "app");

                    DataSearch.Add(Expression.Or(
                        Expression.Eq("app.EsAplicacionRed", true),
                        Expression.Eq("app.EsAplicacionCobis", true)));
                }

                if (_filSinLegajo != null)
                {
                    if (_filSinLegajo.Value)
                    {
                        DataSearch.Add(Expression.Or(
                            Expression.IsNull("TNC.Legajo"), Expression.Eq("TNC.Legajo", "")));
                    }
                    else
                    {
                        DataSearch.Add(Expression.IsNotNull("TNC.Legajo")).Add(Expression.Eq("TNC.Legajo", ""));
                    }
                }

                if (FilImpactaEnAD != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.ImpactaEnAD", FilImpactaEnAD));
                }
                if (FilMarcadoEnAD != null)
                {
                    DataSearch = FilMarcadoEnAD.Value
                       ? DataSearch.Add(Expression.IsNotNull("TNC.FechaSeteoMarcaAD"))
                       : DataSearch.Add(Expression.IsNull("TNC.FechaSeteoMarcaAD"));
                }
                if (FilMarcaEliminadaEnAD != null)
                {
                    DataSearch = FilMarcaEliminadaEnAD.Value
                       ? DataSearch.Add(Expression.IsNotNull("TNC.FechaEliminacionMarcaAD"))
                       : DataSearch.Add(Expression.IsNull("TNC.FechaEliminacionMarcaAD"));
                }
                if (FilVisualizado != null)
                {
                    if (FilVisualizado.Value)
                    {
                        DataSearch = DataSearch.Add(Expression.IsNull("TNC.FechaAceptacionTyC"));
                    }
                    else
                    {
                        DataSearch = DataSearch.Add(Expression.IsNotNull("TNC.FechaAceptacionTyC"));
                        DataSearch = DataSearch.Add(Expression.Not(Expression.Eq("TNC.FechaAceptacionTyC", new DateTime(1900, 1, 1))));

                    } 
                }
                if (FilVencido != null)
                {
                    DataSearch = FilVencido.Value
                        ? DataSearch.Add(Expression.Lt("TNC.FechaExpiracionToken", DateTime.Now))
                        : DataSearch.Add(Expression.Gt("TNC.FechaExpiracionToken", DateTime.Now));
                }
                try
                {
                    tickets = DataSearch.List<TicketNotificacionClaveEntity>();

                    TiNotClaEC.Add(tickets);
                }
                catch (Exception e)
                {
                    log.Error("Error al consultar Tickets de Notificacion de Clave", e);

                    tickets = null;
                }
            }

            return TiNotClaEC;
        }

		public TicketNotificacionClaveEntityCollection GetAllByUser(string dominio, string usuario)
		{
			return GetAllByUser(dominio, usuario, null);
		}

		public TicketNotificacionClaveEntityCollection GetAllActiveByUser(string dominio, string usuario)
		{
			return GetAllByUser(dominio, usuario, DateTime.Now.Date);
		}

        public TicketNotificacionClaveEntityCollection GetAllActiveByUser(string dominio, string usuario ,string aplicacion)
        {
            return GetAllByUser(dominio, usuario, DateTime.Now.Date, aplicacion);
        }

        private TicketNotificacionClaveEntityCollection GetAllByUser(string dominio, string usuario, DateTime? fechaVigenciaDesde)
        {
            return GetAllByUser(dominio, usuario, fechaVigenciaDesde, string.Empty);
		}

        private TicketNotificacionClaveEntityCollection GetAllByUser(string dominio, string usuario, DateTime? fechaVigenciaDesde, string aplicacion)
        {
            IList<TicketNotificacionClaveEntity> tickets;

            TicketNotificacionClaveEntityCollection TiNotClaEC = new TicketNotificacionClaveEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(TicketNotificacionClaveEntity), "TNC");
                DataSearch = DataSearch.Add(Expression.Eq("TNC.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Expression.Eq("TNC.DominioUsuario", dominio).IgnoreCase());

                if (_filCorregido != null)
                    DataSearch = DataSearch.Add(Expression.Eq("TNC.Corregido", _filCorregido.Value));

                DataSearch.CreateCriteria("Aplicacion","APP")
                            .Add(Expression.Eq("APP.Notificable", true));

                if (!string.IsNullOrEmpty(aplicacion))
                    DataSearch = DataSearch.Add(Expression.Eq("APP.Codigo", aplicacion));
                
                if (fechaVigenciaDesde != null)
					DataSearch = DataSearch.Add(Expression.Or(Expression.IsNull("TNC.FechaVigencia"), 
						Expression.Le("TNC.FechaVigencia", fechaVigenciaDesde)));


                try
                {
                    tickets = DataSearch.List<TicketNotificacionClaveEntity>();
                }
                catch
                {
                    tickets = null;
                }

                TiNotClaEC.Add(tickets);
            }

            return TiNotClaEC;
        }

        public TicketNotificacionClaveEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                return session.Get<TicketNotificacionClaveEntity>(id);
            }
        }

        public TicketNotificacionClaveEntity Load(int Id)
        {
            TicketNotificacionClaveEntity PwdRqst;
            IList<TicketNotificacionClaveEntity> lstRqsts = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    PwdRqst = session.Load<TicketNotificacionClaveEntity>(Id);
                }
            }
            catch (Exception)
            {
                return null;
            }
            //lstRqsts[0].UserPassword.UsersList
            return PwdRqst;
        }

        public void UpdateUsuarioAplicacion(TicketNotificacionClaveEntity entidad, bool esAplicacionRed)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear la PC
                    tx = session.BeginTransaction();

                    session.SaveOrUpdate(entidad);

                    if (esAplicacionRed)
                    {
                        ICriteria criteria = session.CreateCriteria(typeof(TicketNotificacionClaveEntity))
                                                .Add(Expression.Eq("Legajo", entidad.Legajo))
                                                .Add(Expression.Eq("EsPasswordDominio", true));

                        foreach (TicketNotificacionClaveEntity ticket in criteria.List<TicketNotificacionClaveEntity>())
                        {
                            ticket.UsuarioAplicacion = entidad.UsuarioAplicacion;

                            session.SaveOrUpdate(ticket);
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    if (tx != null)
                        tx.Rollback();
                    
                    throw; //new SystemException(e.Message);
                }
            }
        }

        public TicketNotificacionClaveEntity GetByToken(string token)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(TicketNotificacionClaveEntity));

                criteria.Add(Expression.Eq("Token", token));

                return criteria.UniqueResult<TicketNotificacionClaveEntity>();
            }
        }
    }
}
