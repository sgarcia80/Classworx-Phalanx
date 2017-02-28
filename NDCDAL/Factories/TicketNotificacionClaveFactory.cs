using System;
using NHibernate;
using NDCCommon.Entities;
using NDCCommon.Collections;
using System.Collections.Generic;
using PhalanxDAL;
using NHibernate.Criterion;

/// <summary>
/// Summary description for BPMSolicitudFactory
/// </summary>
namespace NDCDAL.Factories
{
    public class TicketNotificacionClaveFactory
    {
        private AplicacionNotificacionClaveEntity _filApp = null;
        private string _filUsuario;
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
                    DataSearch.Add(Restrictions.Eq("TNC.Aplicacion", _filApp));

                if (_filUsuario != null && !string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Usuario", _filUsuario));

                if (_filDominio != null && !string.IsNullOrEmpty(_filDominio))
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.DominioUsuario", _filDominio));

                if (_filFecha != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Fecha", _filFecha));

                if (_filFechaDesde != null)
                    DataSearch = DataSearch.Add(Restrictions.Ge("TNC.Fecha", _filFechaDesde));

                if (_filFechaHasta != null)
                    DataSearch = DataSearch.Add(Restrictions.Le("TNC.Fecha", _filFechaHasta));

                if (_filTipoDoc != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.TipoDocumento", _filTipoDoc));

                if (_filTicket != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.NumeroSolicitud", _filTicket));

                if (_filDoc != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Documento", _filDoc));

                if (FilFechaTyCNull != null)
                    DataSearch = FilFechaTyCNull.Value
                        ? DataSearch.Add(Restrictions.IsNull("TNC.FechaAceptacionTyC"))
                        : DataSearch.Add(Restrictions.IsNotNull("TNC.FechaAceptacionTyC"));

                if (_filErrado != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Errado", _filErrado));

                if (_filFilFechaVigencia != null)
                {
                    DataSearch = DataSearch.Add(Restrictions.Or(Restrictions.IsNull("TNC.FechaVigencia"),
                        Restrictions.Le("TNC.FechaVigencia", _filFilFechaVigencia.Value)));
                }

                if (FilReporteNotif && _filApp == null)
                {
                    DataSearch.CreateCriteria("TNC.Aplicacion", "app");

                    DataSearch.Add(Restrictions.Or(
                        Restrictions.Eq("app.EsAplicacionRed", true),
                        Restrictions.Eq("app.EsAplicacionCobis", true)));
                }

                if (_filSinLegajo != null)
                {
                    if (_filSinLegajo.Value)
                    {
                        DataSearch.Add(Restrictions.Or(
                            Restrictions.IsNull("TNC.Legajo"), Restrictions.Eq("TNC.Legajo", "")));
                    }
                    else
                    {
                        DataSearch.Add(Restrictions.IsNotNull("TNC.Legajo")).Add(Restrictions.Eq("TNC.Legajo", ""));
                    }
                }

                if (FilImpactaEnAD != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.ImpactaEnAD", FilImpactaEnAD));

                if (FilMarcadoEnAD != null)
                    DataSearch = FilMarcadoEnAD.Value
                        ? DataSearch.Add(Restrictions.IsNotNull("TNC.FechaSeteoMarcaAD"))
                        : DataSearch.Add(Restrictions.IsNull("TNC.FechaSeteoMarcaAD"));

                if (FilMarcaEliminadaEnAD != null)
                    DataSearch = FilMarcaEliminadaEnAD.Value
                        ? DataSearch.Add(Restrictions.IsNotNull("TNC.FechaEliminacionMarcaAD"))
                        : DataSearch.Add(Restrictions.IsNull("TNC.FechaEliminacionMarcaAD"));

                if (FilVisualizado != null)
                    DataSearch = FilVisualizado.Value
                        ? DataSearch.Add(Restrictions.IsNotNull("TNC.FechaAceptacionTyC"))
                        : DataSearch.Add(Restrictions.IsNull("TNC.FechaAceptacionTyC"));

                if (FilVencido != null)
                    DataSearch = FilVencido.Value
                        ? DataSearch.Add(Restrictions.Lt("TNC.FechaExpiracionToken", DateTime.Now))
                        : DataSearch.Add(Restrictions.Gt("TNC.FechaExpiracionToken", DateTime.Now));

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
                DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Usuario", usuario).IgnoreCase());
                DataSearch = DataSearch.Add(Restrictions.Eq("TNC.DominioUsuario", dominio).IgnoreCase());

                if (_filCorregido != null)
                    DataSearch = DataSearch.Add(Restrictions.Eq("TNC.Corregido", _filCorregido.Value));

                DataSearch.CreateCriteria("Aplicacion","APP")
                            .Add(Restrictions.Eq("APP.Notificable", true));

                if (!string.IsNullOrEmpty(aplicacion))
                    DataSearch = DataSearch.Add(Restrictions.Eq("APP.Codigo", aplicacion));
                
                if (fechaVigenciaDesde != null)
					DataSearch = DataSearch.Add(Restrictions.Or(Restrictions.IsNull("TNC.FechaVigencia"), 
						Restrictions.Le("TNC.FechaVigencia", fechaVigenciaDesde)));


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
                                                .Add(Restrictions.Eq("Legajo", entidad.Legajo))
                                                .Add(Restrictions.Eq("EsPasswordDominio", true));

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

                criteria.Add(Restrictions.Eq("Token", token));

                return criteria.UniqueResult<TicketNotificacionClaveEntity>();
            }
        }
    }
}
