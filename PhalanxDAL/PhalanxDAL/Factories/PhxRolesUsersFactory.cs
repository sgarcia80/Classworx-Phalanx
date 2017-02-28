using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for PhxRolesUsersFactory.
	/// </summary>
	public class PhxRolesUsersFactory
	{
		public PhxRolesUsersFactory()
		{
		}

        public bool UserHasRole(PhxUserEntity PhxUser, string rolecode)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
                , "username: " + PhxUser.Username + " - domain:" + PhxUser.Domain + " - rolecode:" + rolecode
				, true, false);
			try
			{

				// busca el rol en la base por el role code
				PhxRolesFactory PRF = new PhxRolesFactory();
				PhxRoleEntity objPR = PRF.GetPhxRole(rolecode);
				if (objPR == null)
				{
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
						, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
						, "No encontró el rol"
						, true, false);
					// si no encuentra el rol devuelve false
					return false;
				}

				using(ISession session = DBMgr.factory.OpenSession())
				{
                    session.Refresh(PhxUser);
					IList PRUlst = session.CreateCriteria(typeof(PhxRoleUserEntity))
						//.Add(Expression.Eq("PhxRoleId",objPR.PhxRoleId))
						//.Add(Expression.Eq("PhxUserId",objPU.PhxUserId))
						.Add(Expression.Eq("PhxRole",objPR))
                        .Add(Expression.Eq("PhxUser", PhxUser))
						.List();

					if (PRUlst.Count == 0)
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
							, "No encontró la relación usuario - rol"
							, true, false);
						return false;
					}
					else
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
							, "Encontró la relación usuario - rol"
							, true, false);
						return true;
					}
					
				}
			}
			catch ( Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
					, "Hubo un error en la búsqueda de usuario - rol. Error: " + ex.Message
					, true, false);
				return false;
			}

			return true;
		}
        public bool UserHasAnyPrivilege(PhxUserEntity PhxUser, string[] PrivilegeCodes)
		{
            /*
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entra a PhxRolesUsersFactory.UserHasAnyProvilege(PhxUserEntity PhxUser, string[] PrivilegeCodes)"
                , "username: " + PhxUser.Username + " - domain:" + PhxUser.Domain + " - rolecode:" + rolecodes
				, true, false);*/
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
                    session.Refresh(PhxUser);
					IList PRUlst = session.CreateCriteria(typeof(PhxRoleUserEntity), "RU")
                        .Add(Expression.Eq("PhxUser", PhxUser))
                        .CreateCriteria("PhxRole","R")
                        .CreateCriteria("R.PhxPrivilegeRoleList","PR")
                        .CreateCriteria("PR.Privilege","P")
                        .Add(Expression.In("P.Code",PrivilegeCodes))
						.List();

					if (PRUlst.Count == 0)
					{
						/*DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
							, "No encontró la relación usuario - rol"
							, true, false);*/
						return false;
					}
					else
					{
						/*DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
							, "Encontró la relación usuario - rol"
							, true, false);*/
						return true;
					}
					
				}
			}
			catch ( Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "PhxRolesUsersFactory.UserHasRole(string username, string domain, string rolecode)"
					, "Hubo un error en la búsqueda de usuario - rol. Error: " + ex.Message
					, true, false);
				return false;
			}

			return true;
		}
		public PhxRoleUserEntity GetRoleUser(int phxuserid, string rolecode)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
				, "phxuserid: " + phxuserid.ToString() + " - rolecode:" + rolecode
				, true, false);
			PhxRoleUserEntity objRoleUser = null;
			try
			{
				// busca al usuario en la base
				PhxUsersFactory PUF = new PhxUsersFactory();
				PhxUserEntity objPU = PUF.GetPhxUserByID(phxuserid);
				if (objPU == null)
				{
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
						, "PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
						, "No encontró el usuario"
						, true, false);
					// si no encuetra al usuario devuelve false
					return null;
				}

				// busca el rol en la base por el role code
				PhxRolesFactory PRF = new PhxRolesFactory();
				PhxRoleEntity objPR = PRF.GetPhxRole(rolecode);
				if (objPR == null)
				{
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
						, "PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
						, "No encontró el rol"
						, true, false);
					// si no encuentra el rol devuelve false
					return null;
				}

				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList PRUlst = session.CreateCriteria(typeof(PhxRoleUserEntity))
						//.Add(Expression.Eq("PhxRoleId",objPR.PhxRoleId))
						//.Add(Expression.Eq("PhxUserId",objPU.PhxUserId))
						.Add(Expression.Eq("PhxRole",objPR))
						.Add(Expression.Eq("PhxUser",objPU))
						.List();

					if (PRUlst.Count == 0)
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
							, "No encontró la relación usuario - rol"
							, true, false);
						return null;
					}
					else
					{
						objRoleUser = (PhxRoleUserEntity)PRUlst[0];
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
							, "PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
							, "Encontró la relación usuario - rol"
							, true, false);
						return objRoleUser;
					}
					
				}
			}
			catch ( Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "PhxRolesUsersFactory.GetRoleUser(int phxuserid, string rolecode)"
					, "Hubo un error en la búsqueda de usuario - rol. Error: " + ex.Message
					, true, false);
				return null;
			}

		}
		public bool AddRoleToUser(int phxuserid, string rolecode)
		{
			// busca el objeto phxuser por el ID
			PhxUsersFactory PUF = new PhxUsersFactory();
			PhxUserEntity objPU = PUF.GetPhxUserByID(phxuserid);
			if (objPU == null)
			{
				return false;
			}

			// busca el role por el rolecode
			PhxRolesFactory PRF = new PhxRolesFactory();
			PhxRoleEntity objPR = PRF.GetPhxRole(rolecode);
			if (objPR == null)
			{
				return false;
			}

			PhxRoleUserEntity objPRU = new PhxRoleUserEntity();
			objPRU.PhxUser = objPU;
			objPRU.PhxRole = objPR;
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					tx = session.BeginTransaction();
					session.SaveOrUpdate(objPRU);
					tx.Commit();
					//return true;
				}
				catch (Exception ex)
				{
					tx.Rollback();
					return false;
					// handle exception
				}
			}
			return true;

		}
		public bool RemoveRoleFromUser(int phxuserid, string rolecode)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a PhxRolesUsersFactory.RemoveRoleFromUser(int phxuserid, string rolecode)"
				, "phxuserid: " + phxuserid.ToString() + " - rolecode:" + rolecode
				, true, false);
			PhxRoleUserEntity objPRU = this.GetRoleUser(phxuserid, rolecode);
			// verifica si encontró la relación usuario - rol
			if (objPRU == null)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
					, "PhxRolesUsersFactory.RemoveRoleFromUser(int phxuserid, string rolecode)"
					, "No encontró la relación usuario - rol"
					, true, false);
				return false;
			}
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					tx = session.BeginTransaction();
					session.Delete(objPRU);
					tx.Commit();
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
						, "PhxRolesUsersFactory.RemoveRoleFromUser(int phxuserid, string rolecode)"
						, "Borró la relación usuario - rol"
						, true, false);
					//return true;
				}
				catch (Exception ex)
				{
					tx.Rollback();
					DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_ERROR, 4, 0
						, "PhxRolesUsersFactory.RemoveRoleFromUser(int phxuserid, string rolecode)"
						, "Error: " + ex.Message
						, true, false);
					return false;
					// handle exception
				}
			}
			return true;

		}
	}
}
