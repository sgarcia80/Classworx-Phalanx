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
	/// Summary description for AS400Factory.
	/// </summary>
	public class AS400Factory
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

        public AS400EntityCollection GetAll()
        {
            AS400EntityCollection AS400Lst = new AS400EntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(AS400Entity));

                    if (_filNombre.Trim() != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("ServerName", _filNombre, MatchMode.Anywhere));
                    }
                    if (_filActivo != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Active", _filActivo.Value));
                    }
                    DataSearch = DataSearch.AddOrder(Order.Asc("ServerName"));

                    AS400Lst.Add(DataSearch.List<AS400Entity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "AS400Factory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "AS400Factory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "AS400Factory GetAll()"));
            }
            return AS400Lst;
        }

        public AS400Factory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/*
        public AS400Entity SearchPCUsers(AS400Entity AS400)
        {
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    session.Refresh(AS400);
                    int i = AS400.AS400UsersList.Count;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "AS400Factory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "AS400Factory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "AS400Factory GetAll()"));
            }
            return AS400;
        }
         * */

        public AS400Entity GetAS400(string PCName)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(AS400Entity))
                    .Add(Expression.Sql("lower({alias}.as_server_name) = lower('" + PCName + "')"))
					.List();
			}
			if (lstWDPCs.Count != 1)
			{
				return null;
			}
			else
			{
				return (AS400Entity)lstWDPCs[0];
			}


		}

        /// <summary>
        /// Busca equipo AS400 con mismo nombre y diferente Id
        /// </summary>
        /// <param name="PCName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AS400Entity GetAS400(string PCName, int Id)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(AS400Entity))
                    .Add(Expression.Not(Expression.Eq("Id", Id)))
                    .Add(Expression.Sql("lower({alias}.as_server_name) = lower('" + PCName + "')"))
					.List();
			}
			if (lstWDPCs.Count != 1)
			{
				return null;
			}
			else
			{
				return (AS400Entity)lstWDPCs[0];
			}


		}

        public void SaveAS400(AS400Entity PCEntity)
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

        /*
        public void DeleteAS400PC( string PCName)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // borra la pc de la base
                    AS400Entity objWPC = GetAS400PC(PCName) ;
                    if (objWPC != null)
                    {
                        tx = session.BeginTransaction();

                        foreach (AS400UserEntity localsUser in objWPC.AS400UsersList)
                        {
                            session.Delete(localsUser);
                        }

                        session.Delete(objWPC);
                        tx.Commit();
                    }
                    else
                        throw new SystemException("Error al Obtener Datos del equipo");
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();
                    throw new SystemException(e.Message);
                }
            }
        }
        */
	}
}
