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
	/// Summary description for UnixPCsFactory.
	/// </summary>
	public class UnixPCsFactory
	{
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private Nullable<bool> _filActivo;
        public Nullable<bool> FilActivo
        {
            set { _filActivo = value; }
        }

        public UnixPCEntityCollection GetAll()
        {
            UnixPCEntityCollection UnixPCLst = new UnixPCEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(UnixEntity));

                    if (_filNombre.Trim() != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("ServerName", _filNombre, MatchMode.Anywhere));
                    }
                    if (_filActivo != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Active", _filActivo.Value));
                    }
                    DataSearch = DataSearch.AddOrder(Order.Asc("ServerName"));

                    UnixPCLst.Add(DataSearch.List<UnixEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "UnixPCsFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "UnixPCsFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "UnixPCsFactory GetAll()"));
            }
            return UnixPCLst;
        }
        public UnixEntity SearchPCUsers(UnixEntity UnixPC)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(UnixPC);
                    int i = UnixPC.UnixUsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "UnixPCsFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "UnixPCsFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "UnixPCsFactory GetAll()"));
            }
            return UnixPC;
        }
        public UnixPCsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
        public UnixEntity GetUnixPC(string PCName)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(UnixEntity))
                    .Add(Expression.Sql("lower({alias}.unx_server_name) = lower('" + PCName + "')"))
					.List();
			}
			if (lstWDPCs.Count != 1)
			{
				return null;
			}
			else
			{
				return (UnixEntity)lstWDPCs[0];
			}


		}

        /// <summary>
        /// Busca un equipo Unix con mismo nombre y distinto Id
        /// </summary>
        /// <param name="PCName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UnixEntity GetUnixPC(string PCName, int Id)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(UnixEntity))
                    .Add(Expression.Not(Expression.Eq("Id",Id)))
                    .Add(Expression.Sql("lower({alias}.unx_server_name) = lower('" + PCName + "')"))
					.List();
			}
			if (lstWDPCs.Count != 1)
			{
				return null;
			}
			else
			{
				return (UnixEntity)lstWDPCs[0];
			}


		}

        public void SaveUnixPC(UnixEntity PCEntity)
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

        public void DeleteUnixPC( string PCName)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // borra la pc de la base
                    UnixEntity objWPC = GetUnixPC(PCName) ;
                    if (objWPC != null)
                    {
                        tx = session.BeginTransaction();

                        foreach (UnixUserEntity localsUser in objWPC.UnixUsersList)
                        {
                            session.Delete(localsUser);
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

	}
}
