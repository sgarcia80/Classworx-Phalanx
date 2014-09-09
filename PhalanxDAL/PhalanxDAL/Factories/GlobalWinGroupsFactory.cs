using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for GlobalWinGroupsFactory.
	/// </summary>
	public class GlobalWinGroupsFactory
	{
		public GlobalWinGroupsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public IList GetGlobalWinGroupsByDomain(int DomainId)
		{
			IList lstWDPCs;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDPCs = session.CreateCriteria(typeof(GlobalWinGroupEntity))
					.Add(Expression.Eq("WinDomain.Id",DomainId))
					.List();
			}
			
			return lstWDPCs;
		}
		/// <summary>
		/// Busca la lista de Grupos del dominio
		/// </summary>
		/// <param name="DomainName">Nombre del dominio</param>
		/// <returns>Devuelve la lista de Grupos correspondientes al dominio pasado. 
		/// Si no encuentra el dominio o datos devuelve null
		/// </returns>
		public IList GetGlobalWinGroupsByDomain(string DomainName)
		{
			WinDomainsFactory WDF = new WinDomainsFactory();
			WinDomainEntity objWD = WDF.GetWinDomain(DomainName);
			if (objWD == null)
			{
				return null;
			}
			return this.GetGlobalWinGroupsByDomain(objWD.Id);
		}

		/// <summary>
		/// Crea el Grupo Global al Dominio correspondiente
		/// </summary>
		/// <param name="DomainName">Dominio al cual pertenece el Grupo</param>
		/// <param name="GroupName">Nombre del Grupo</param>
		/// <returns>Devuelve el Id del Grupo Global creado. Si hubo algún problema devuelve 0.</returns>
		public int CreateGlobalWinGroup(string DomainName, string GroupName)
		{
			// busca la PC asociada al grupo
			WinDomainsFactory WDF = new WinDomainsFactory();
			WinDomainEntity objWD = WDF.GetWinDomain(DomainName);
			if (objWD == null)
			{
				//return false;
				return 0;
			}
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					tx = session.BeginTransaction();
					// crear el Grupo en la base
					GlobalWinGroupEntity objGWG = new GlobalWinGroupEntity();
					objGWG.NtGroupName = GroupName;
					objGWG.WinDomain = objWD;
					session.Save(objGWG);
					tx.Commit();
					return objGWG.Id;
					//return true;
				}
				catch (Exception ex)
				{
					tx.Rollback();
					return 0;
					//return false;
					// handle exception
				}
			}

		}


	}
}
