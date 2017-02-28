using System;
using System.Reflection;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using PhalanxCommon;
using PhalanxCommon.Collections;
using System.Collections.Generic;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for WinPCsFactory.
	/// </summary>
	public class WinPCsFactory
	{
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private WinDomainEntity _filDominio;
        public WinDomainEntity FilDominio
        {
            set { _filDominio = value; }
            //get { return _filNombre; }
        }
        private Nullable<bool> _filActivo;
        public Nullable<bool> FilActivo
        {
            set { _filActivo = value; }
        }

        public WinPCEntityCollection GetAll()
        {
            WinPCEntityCollection WinPCLst = new WinPCEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(WinPCEntity));

                    if (_filNombre.Trim() != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre, MatchMode.Anywhere));
                    }
                    if (_filActivo != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Active", _filActivo.Value));
                    }
                    if (_filDominio != null && _filDominio.Id != 0)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("WinDomain", _filDominio));
                    }
                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));
                    /*
                    IList<WinPCEntity> lstPCs = DataSearch.List<WinPCEntity>();
                    foreach (WinPCEntity PCE in lstPCs)
                    {
                        int x = PCE.WinLocalUsersList.Count;
                        WinPCLst.Add(PCE);
                    }*/
                    WinPCLst.Add(DataSearch.List<WinPCEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "WinPCsFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "WinPCsFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "WinPCsFactory GetAll()"));
            }
            return WinPCLst;
        }
        public WinPCEntity SearchPCUsers(WinPCEntity WinPC)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(WinPC);
                    int i = WinPC.WinLocalUsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "WinPCsFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "WinPCsFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "WinPCsFactory GetAll()"));
            }
            return WinPC;
        }
		public WinPCsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public IList GetWinPCsByDomain(int DomainId)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
					lstWDPCs = session.CreateCriteria(typeof(WinPCEntity))
					.Add(Expression.Eq("WinDomain.Id",DomainId))
					.List();
			}
			
			return lstWDPCs;
		}
        public object GetWinPC(string domainName, string pcName, int Id)
        {
            WinDomainsFactory WDF = new WinDomainsFactory();
            WinDomainEntity objWD = WDF.GetWinDomain(domainName);
            if (objWD == null)
            {
                // no existe el dominio en la BD
                return null;
            }
            IList lstWDPCs;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstWDPCs = session.CreateCriteria(typeof(WinPCEntity))
                    .Add(Expression.Not(Expression.Eq("Id", Id)))
                    .Add(Expression.Sql("lower({alias}.pc_name) = lower('" + pcName + "')"))
                    .Add(Expression.Eq("WinDomain.Id", objWD.Id))
                    .List();
            }
            if (lstWDPCs.Count != 1)
            {
                return null;
            }
            else
            {
                return (WinPCEntity)lstWDPCs[0];
            }

        }

        public WinPCEntity GetWinPC(string DomainName, string PCName)
		{
			// busca dominio
			WinDomainsFactory WDF = new WinDomainsFactory();
			WinDomainEntity objWD = WDF.GetWinDomain(DomainName);
			if (objWD == null)
			{
				// no existe el dominio en la BD
				return null;
			}
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(WinPCEntity))
					.Add(Expression.Sql("lower({alias}.pc_name) = lower('"+PCName+"')"))
					.Add(Expression.Eq("WinDomain.Id",objWD.Id))
					.List();
			}
			if (lstWDPCs.Count != 1)
			{
				return null;
			}
			else
			{
				return (WinPCEntity)lstWDPCs[0];
			}


		}

        public void SaveWinPC(WinPCEntity PCEntity)
		{
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					// crear la PC
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(PCEntity);
					tx.Commit();
				}
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw new SystemException(e.Message);
                }
            }
		}
        public bool Update(WinPCEntity PCEntity)
		{
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					// crear la PC
                    tx = session.BeginTransaction();
                    session.Update(PCEntity);
					tx.Commit();
                    return true;
				}
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    //throw new SystemException(e.Message);
                    return false;
                }
            }
		}

        public void DeleteWinPC(string DomainName, string PCName)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // borra la pc de la base
                    WinPCEntity objWPC = GetWinPC(DomainName, PCName) ;
                    if (objWPC != null)
                    {
                        tx = session.BeginTransaction();

                        foreach (WinLocalUserEntity localsUser in objWPC.WinLocalUsersList)
                        {
                            session.Delete(localsUser);
                        }

                        foreach (LocalWinGroupEntity winGroup in objWPC.LocalWinGroupsList)
                        {
                            session.Delete(winGroup);
                        }
                                                
                        session.Delete(objWPC);
                        tx.Commit();
                    }
                    else
                        throw new SystemException("Error al Obtener Datos de la PC");
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw new SystemException(e.Message);
                }
            }
        }



        public bool Refresh(WinPCEntity WinPC)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    session.Refresh(WinPC);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
