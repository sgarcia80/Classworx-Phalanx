using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using PhalanxCommon.Collections;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class LoteChkWinLocalUsersFactory
    {
        private int? _filNroLote = null;
        public int FilNroLote
        {
            set { _filNroLote = value; }
        }

        public bool Save(LoteChkWinLocalUsersEntity Lote
            , WinLocalUserEntityCollection WinUsrs)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Save(Lote);
                    for (int i = 0; i < WinUsrs.Count; i++)
                    {
                        ItemLoteChkWinLocalUsersEntity ItmLote = new ItemLoteChkWinLocalUsersEntity();
                        ItmLote.WinLocalUser = WinUsrs[i];
                        ItmLote.Lote = Lote;
                        session.Save(ItmLote);
                    }
                    tx.Commit();

                }
                catch (Exception ex)
                {
                    tx.Rollback();

                    return false;
                    // handle exception
                }
                return true;
            }
        }
        public Nullable<DateTime> FilFProgramadaDesde = null;
        public Nullable<DateTime> FilFProgramadaHasta = null;
        private bool? _filFFinNull = null;
        public bool FilFFinNull
        {
            set { _filFFinNull = value; }
        }
        public LoteChkWinLocalUsersEntityCollection GetAll()
        {
            IList<LoteChkWinLocalUsersEntity> lstWLUs;
            LoteChkWinLocalUsersEntityCollection DBUsrEC = new LoteChkWinLocalUsersEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(LoteChkWinLocalUsersEntity));
                if (FilFProgramadaDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("FechaProgramada", FilFProgramadaDesde.Value.Date));
                }
                if (FilFProgramadaHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("FechaProgramada", FilFProgramadaHasta.Value));
                }
                if (_filNroLote != null)
                {
                    DataSearch.Add(Expression.Eq("Id", _filNroLote.Value));
                }
                if (_filFFinNull != null)
                {
                    if (_filFFinNull.Value)
                    {
                        DataSearch.Add(Expression.IsNull("FechaFinProceso"));
                    }
                    else
                    {
                        DataSearch.Add(Expression.IsNotNull("FechaFinProceso"));
                    }
                }

                DataSearch.AddOrder(Order.Desc("FechaProgramada"));
                DataSearch.AddOrder(Order.Desc("FechaCreacion"));

                lstWLUs = DataSearch.List<LoteChkWinLocalUsersEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

        public void Update(LoteChkWinLocalUsersEntity Lote)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Update(Lote);
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

        public void Refresh(LoteChkWinLocalUsersEntity Lote)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    session.Refresh(Lote);

                }
                catch (Exception ex)
                {

                    //return false;
                    // handle exception
                }
                //return true;
            }
        }

        public bool Baja(LoteChkWinLocalUsersEntity Lote)
        {
                        ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();

                    ItemLoteChkWinLocalUsersFactory ItemsF = new ItemLoteChkWinLocalUsersFactory();
                    ItemsF.FilLote = Lote;
                    ItemLoteChkWinLocalUsersEntityCollection Items = ItemsF.GetAll();
                    foreach (ItemLoteChkWinLocalUsersEntity ItemLote in Items)
                    {
                        session.Delete(ItemLote);
                    }
                    session.Delete(Lote);
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();

                    return false;
                    // handle exception
                }
                //return true;
            }

        }
    }


}
