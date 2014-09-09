using System;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using Phalanx.Util;
using NHibernate;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for WinGroupsFactory.
	/// </summary>
	public class WinGroupsFactory
	{
		public WinGroupsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Busca el Grupo que corresponde con el Id
		/// </summary>
		/// <param name="UsrId">Id de Grupo. Tabla.Campo: Win_Groups.win_group_Id</param>
		/// <returns>Devuelve el objeto WinGroup. Si no encuentra datos devuelve null</returns>
		public WinGroupEntity GetWinGroupByID(int WinGroupId)
		{
			WinGroupEntity objWG = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objWG = (WinGroupEntity)session.Load(typeof(WinGroupEntity),WinGroupId);
				}
			}
			catch (ObjectNotFoundException ONFex)
			{
				return null;
			}					
			catch(NHibernate.ADOException ADOex) // esto se dispara cuando por ejemplo no hay conexion a la base
			{
				//throw(ADOex);
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			return objWG;
		}
		/// <summary>
		/// Busca el usuario asociado al Id del Password
		/// </summary>
		/// <param name="PwdId">Id del Password</param>
		/// <param name="User">Objeto Usuario Local o de dominio. Si no encuentra usuario devuelve null</param>
		/// <param name="UserType">Tipo de usuario que devuelve</param>
		/// <returns></returns>
		public uint GetWinGroupById(int WinGroupId, out object WinGroup, out System.Type WGType)
		{
			WinGroup = null;
			WGType = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					try
					{
						WinGroup = (LocalWinGroupEntity)session.Load(typeof(LocalWinGroupEntity),WinGroupId);
						WGType = typeof(LocalWinGroupEntity);
					}
					catch (ObjectNotFoundException ONFex)
					{
						try
						{
							session.Clear();
							WinGroup = (GlobalWinGroupEntity)session.Load(typeof(GlobalWinGroupEntity),WinGroupId);
							WGType = typeof(GlobalWinGroupEntity);
						}
						catch (ObjectNotFoundException ONFex2)
						{
							return PhxDALUtil.NO_DATA_FOUND;
						}					
						return PhxDALUtil.SUCCESS;
					}					
				}
			}
			catch (ObjectNotFoundException ONFex3)
			{
				return PhxDALUtil.NO_DATA_FOUND;
			}					
			catch(NHibernate.ADOException ADOex3) // esto se dispara cuando por ejemplo no hay conexion a la base
			{
				return PhxDALUtil.ERROR;
			}
			catch (Exception ex3)
			{
				return PhxDALUtil.ERROR;
			}
			return PhxDALUtil.SUCCESS;

		}

	}
}
