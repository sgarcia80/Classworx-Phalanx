using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
    public class HistPasswordChangeFactory
    {
        private int? m_FilUserID = null;
        public int FilUserID
        {
            set { m_FilUserID = value; }
        }
        private DateTime? m_FilFechaCambioDesde = null;
        public DateTime FilFechaCambioDesde { set { m_FilFechaCambioDesde = value; } }
        private DateTime? m_FilFechaCambioHasta = null;
        public DateTime FilFechaCambioHasta { set { m_FilFechaCambioHasta = value; } }
        public enum PwdChgOrderBy
        {
            None,
            FechaCambioAsc,
            FechaCambioDesc
        }
        private PwdChgOrderBy m_OrderBy = PwdChgOrderBy.None;
        public PwdChgOrderBy OrderBy { set { m_OrderBy = value; } }
        private bool m_SoloPrimerRegistro = false;
        public bool SoloPrimerRegistro { set { m_SoloPrimerRegistro = value; } }
        public HistPasswordChangeEntityCollection GetAll()
        {
            IList<HistPasswordChangeEntity> lstWLUs;
            HistPasswordChangeEntityCollection DBUsrEC = new HistPasswordChangeEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(HistPasswordChangeEntity));
                if (m_FilUserID != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("User.Id", m_FilUserID));
                }
                if (m_FilFechaCambioDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Gt("DChange", m_FilFechaCambioDesde.Value));
                }
                if (m_FilFechaCambioHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("DChange", m_FilFechaCambioHasta.Value));
                }
                if (m_SoloPrimerRegistro)
                {
                    DataSearch.SetMaxResults(1);
                }

                if (m_OrderBy != PwdChgOrderBy.None)
                {
                    if (m_OrderBy == PwdChgOrderBy.FechaCambioAsc)
                    {
                        DataSearch = DataSearch.AddOrder(Order.Asc("DChange"));
                    }
                    else if (m_OrderBy == PwdChgOrderBy.FechaCambioDesc)
                    {
                        DataSearch = DataSearch.AddOrder(Order.Desc("DChange"));
                    }
                }

                lstWLUs = DataSearch.List<HistPasswordChangeEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }
        public void AddLog(ISession session, UserEntity User)
        {
            /// hay que hacer un proceso especial para cuando todavia no existe un registro en el historial
            /// para es clave porque en ese caso entra como que tiene que crearlo y ocurre que al
            /// entrar a modificar una clave y no tiene registro en el historial quiere grabar log y
            /// va a poner la fecha en null y ahi salta error
            PhxUsersFactory PUF = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = PUF.GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            IList<HistPasswordChangeEntity> lstWLUs;
            HistPasswordChangeEntityCollection DBUsrEC = new HistPasswordChangeEntityCollection();
            ICriteria DataSearch = session.CreateCriteria(typeof(HistPasswordChangeEntity));
            DataSearch = DataSearch.Add(Expression.Eq("User", User));
            if (User.UserPassword.DLastChange != null)
            {
                DataSearch = DataSearch.Add(Expression.Eq("DChange", User.UserPassword.DLastChange.Value));
            }
            else
            {
                DataSearch = DataSearch.Add(Expression.IsNull("DChange"));
            }
            /// se pone este if porque con contraseñas viejas que no tienen fecha de ultimo cambio insertaria null y da error
            if (User.UserPassword.DLastChange != null)
            {
                // verifica si ya existe el log (o sea, no fue cambio)
                if (DataSearch.List<HistPasswordChangeEntity>().Count == 0)
                {
                    // no existe, entonces inserta log
                    HistPasswordChangeEntity HistPwdChgE = new HistPasswordChangeEntity();
                    HistPwdChgE.User = User;
                    if (User.UserPassword.DLastChange != null)
                    {
                        HistPwdChgE.DChange = User.UserPassword.DLastChange.Value;
                    }
                    HistPwdChgE.PhxUser = PhxUsrE;
                    HistPwdChgE.Password = User.UserPassword.Password;
                    session.Save(HistPwdChgE);

                }
            }
        }

        public void Depurar(DateTime fecha)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                session.GetNamedQuery("DepurarLogCambioPassword")
                        .SetDateTime("fecha", fecha)
                        .UniqueResult();
            }
        }
    }
}
