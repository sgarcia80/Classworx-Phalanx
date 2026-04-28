using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using PhalanxCommon.Collections;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class ItemLoteChkWinLocalUsersFactory
    {
        //public bool Save(LoteChkWinLocalUsersEntity Lote
        //    , WinLocalUserEntityCollection WinUsrs)
        //{
        //    ITransaction tx = null;
        //    using (ISession session = DBMgr.factory.OpenSession())
        //    {
        //        try
        //        {
        //            tx = session.BeginTransaction();
        //            session.Save(Lote);
        //            for (int i = 0; i < WinUsrs.Count; i++)
        //            {
        //                ItemLoteChkWinLocalUsersEntity ItmLote = new ItemLoteChkWinLocalUsersEntity();
        //                ItmLote.WinLocalUser = WinUsrs[i];
        //                ItmLote.Lote = Lote;
        //                session.Save(ItmLote);
        //            }
        //            tx.Commit();

        //        }
        //        catch (Exception ex)
        //        {
        //            tx.Rollback();

        //            return false;
        //            // handle exception
        //        }
        //        return true;
        //    }
        //}
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;
        private LoteChkWinLocalUsersEntity _filLote;
        public LoteChkWinLocalUsersEntity FilLote
        {
            set { _filLote = value; }
        }
        private bool? _filFechaChkNull = null;
        public bool FilFechaChkNull
        {
            set { _filFechaChkNull = value; }
        }
        private bool? _filChkPwdOK = null;
        public bool FilChkPwdOK
        {
            set { _filChkPwdOK = value; }
        }
        private bool? _filAccesoNombre = null;
        public bool FilAccesoNombre
        {
            set { _filAccesoNombre = value; }
        }
        private bool? _filAccesoIP = null;
        public bool FilAccesoIP
        {
            set { _filAccesoIP = value; }
        }
        public ItemLoteChkWinLocalUsersEntityCollection GetAll()
        {
            IList<ItemLoteChkWinLocalUsersEntity> lstWLUs;
            ItemLoteChkWinLocalUsersEntityCollection DBUsrEC = new ItemLoteChkWinLocalUsersEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(ItemLoteChkWinLocalUsersEntity));
                /*if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("Fecha", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("Fecha", FilFHasta.Value.Date.AddDays(1)));
                }*/
                if (_filLote != null)
                {
                    DataSearch.Add(Expression.Eq("Lote", _filLote));
                }
                if (_filChkPwdOK != null)
                {
                    DataSearch.Add(Expression.Eq("ChkPwd", _filChkPwdOK));
                }
                if (_filAccesoIP != null)
                {
                    DataSearch.Add(Expression.Eq("ChkPingIPEquipo", _filAccesoIP));
                }
                if (_filAccesoNombre != null)
                {
                    DataSearch.Add(Expression.Eq("ChkPingNombreEquipo", _filAccesoNombre));
                }
                if (_filFechaChkNull != null)
                {
                    if (_filFechaChkNull.Value)
                    {
                        DataSearch.Add(Expression.IsNull("FechaChk"));
                    }
                    else
                    {
                        DataSearch.Add(Expression.IsNotNull("FechaChk"));
                    }

                }
                //DataSearch = DataSearch.AddOrder(Order.Desc("FechaProgramada"));
                //DataSearch.AddOrder(Order.Desc("FechaCreacion"));

                lstWLUs = DataSearch.List<ItemLoteChkWinLocalUsersEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

        public void Update(ItemLoteChkWinLocalUsersEntity ItemLote)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Update(ItemLote);
                    tx.Commit();

                }
                catch (Exception ex)
                {
                    tx.Rollback();

                    //return false;
                    // handle exception
                }
                //return true;
            }
        }

        public void Refresh(ItemLoteChkWinLocalUsersEntity ItemChk)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    session.Refresh(ItemChk);
                }
                catch (Exception ex)
                {
                }

            }
        }
    }

    
}
