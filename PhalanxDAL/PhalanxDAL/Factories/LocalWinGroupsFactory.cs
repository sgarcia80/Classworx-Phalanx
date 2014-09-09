using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for LocalWinGroupsFactory.
	/// </summary>
	public class LocalWinGroupsFactory
	{
		public LocalWinGroupsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Busca los grupos de Windows de una PC
		/// </summary>
		/// <param name="WinPCId">Id de la PC</param>
		/// <returns>Devuelve la lista de Grupos de la PC. Si no hay datos devuelve null</returns>
		/// <example>
		/// LocalWinGroupsFactory LWGF = new LocalWinGroupsFactory();
		/// foreach(LocalWinGroupEntity objLWG in LWGF.GetLocalWinGroupsByWinPC(1))
		/// {
		/// 	int i = objLWG.WinGroupId;
		/// }
		/// </example>
		public IList GetLocalWinGroupsByWinPC(int WinPCId)
		{
			IList lstWDPCs;

			try
			{

				using(ISession session = DBMgr.factory.OpenSession())
				{
					lstWDPCs = session.CreateCriteria(typeof(LocalWinGroupEntity))
						.Add(Expression.Eq("WinPc.Id",WinPCId))
						.List();
				}
			}
			catch (Exception ex)
			{
				lstWDPCs = null;
			}
				
			
			return lstWDPCs;
		}

		/// <summary>
		/// Busca los grupos locales de windows de la PC especificada.
		/// </summary>
		/// <param name="DomainName">Nombre del dominio al que pertenece la PC</param>
		/// <param name="PCName">Nombre de la PC</param>
		/// <returns>Devuelve la lista de grupos locales de windows. Si no encuentra nada, devuelve null.</returns>
		public IList GetLocalWinGroups(string DomainName, string PCName)
		{
			WinPCsFactory WPCF = new WinPCsFactory();
			WinPCEntity objWPC = WPCF.GetWinPC(DomainName,PCName);
			if (objWPC == null)
			{
				return null;
			}

			return this.GetLocalWinGroupsByWinPC(objWPC.Id);

		}
		/// <summary>
		/// Crea el Grupo Local a la PC correspondiente
		/// </summary>
		/// <param name="DomainName">Dominio al cual pertenece la PC</param>
		/// <param name="PCName">Nombre de la PC</param>
		/// <param name="GroupName">Nombre del Grupo</param>
		/// <returns>Devuelve el Id del Grupo Local creado. Si hubo algún problema devuelve 0.</returns>
		public int CreateLocalWinGroup(string DomainName, string PCName, string GroupName)
		{
			// busca la PC asociada al grupo
			WinPCsFactory WPCF = new WinPCsFactory();
			WinPCEntity objWPC = WPCF.GetWinPC(DomainName,PCName);
			if (objWPC == null)
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
					LocalWinGroupEntity objLWG = new LocalWinGroupEntity();
					objLWG.NtGroupName = GroupName;
					objLWG.WinPc = objWPC;
					session.Save(objLWG);
					tx.Commit();
					return objLWG.Id;
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
