using System;
using System.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for PhxRolesFactory.
	/// </summary>
	public class PhxRolesFactory
	{
		public PhxRolesFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public PhxRoleEntity GetPhxRole(string rolecode)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a PhxRolesFactory.GetPhxRole(string rolecode)"
				, "rolecode: " + rolecode
				, true, false);
			try
			{
				PhxRoleEntity objPR = new PhxRoleEntity();
				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList PRlst = session.CreateCriteria(typeof(PhxRoleEntity))
						.Add(Expression.Sql("lower({alias}.role_code) = lower('"+rolecode+"')"))
						.List();

					if (PRlst.Count == 1)
					{
						objPR = (PhxRoleEntity)PRlst[0];
					}
					else
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
							, "PhxRolesFactory.GetPhxRole(string rolecode"
							, "No se encontró el rol " + rolecode
							, true, false);
						return null;
					}
				}
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
					, "PhxRolesFactory.GetPhxRole(string rolecode"
					, "Se encontró el rol " + rolecode
					, true, false);
				return objPR;
			}
			catch(Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
					, "PhxRolesFactory.GetPhxRole(string rolecode"
					, "No se encontró el rol " + rolecode + " - Ex: " + ex.Message
					, true, false);
				return null;
			}
		

		}
        public PhxRoleEntityCollection GetAll()
        {
            PhxRoleEntityCollection PhxRoleEC = new PhxRoleEntityCollection();
            ICriteria DataSearch;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                DataSearch = session.CreateCriteria(typeof(PhxRoleEntity)).AddOrder(Order.Asc("Name")); //.List();
                PhxRoleEC.Add(DataSearch.List<PhxRoleEntity>());
            }
            return PhxRoleEC;

        }
		/// <summary>
		/// Busca a todos los roles del sistema
		/// </summary>
		/// <returns>Lista completa de roles del sistema ordenados por rolename</returns>
		public IList GetPhxRoles()
		{
			IList PRlst = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				PRlst = session.CreateCriteria(typeof(PhxRoleEntity)).AddOrder(Order.Asc("Name")).List();
			}
			return PRlst;
		}
		/// <summary>
		/// Busca los roles del sistema para un usuario determinado
		/// </summary>
		/// <param name="PhxUserId">Id del usuario</param>
		/// <returns>lista de roles asignados al usuario</returns>
		public IList GetPhxRolesByPhxUserId(int PhxUserId)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a PhxRolesFactory.GetPhxRolesByPhxUserId(int PhxUserId)"
				, "PhxUserId: " + PhxUserId.ToString()
				, true, false);
			IList lstPRU = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstPRU = session.CreateCriteria(typeof(PhxRoleUserEntity))
					.Add(Expression.Eq("PhxUser.Id",PhxUserId))
					.List();
			}
			IList lstPR = new ArrayList();
			foreach (PhxRoleUserEntity auxPRU in lstPRU)
			{
				lstPR.Add(auxPRU.PhxRole);
			}
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "PhxRolesFactory.GetPhxRolesByPhxUserId(int PhxUserId)"
				, "Devuelve " + lstPR.Count.ToString() + " roles para el usuario"
				, true, false);
			return lstPR;


		}

        public int Save(PhxRoleEntity Role, PhxPrivilegeEntityCollection Privileges, PhxUserEntity Responsable)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    // graba el Rol
                    if (Role.Id == 0)
                    {
                        session.Save(Role);
                        // graba el registro de audit del A del rol
                        AuditPhxRoleEntity AuditRol = new AuditPhxRoleEntity(Responsable, Role);
                        AuditRol.SetAlta();
                        session.Save(AuditRol);
                    }
                    else
                    {
                        session.Update(Role);
                        // graba el registro de audit del M del rol
                        AuditPhxRoleEntity AuditRol = new AuditPhxRoleEntity(Responsable, Role);
                        AuditRol.SetModificacion();
                        session.Save(AuditRol);
                    }
                   

                    PhxPrivilegeRoleEntityCollection PrivToDel = new PhxPrivilegeRoleEntityCollection();
                    PhxPrivilegeRoleEntityCollection PrivToAdd = new PhxPrivilegeRoleEntityCollection();
                    PhxPrivilegeRoleFactory PrivRolF = new PhxPrivilegeRoleFactory();

                    PhxPrivilegeRoleEntityCollection DBPrivRolEC = PrivRolF.GetAll(Role);

                    // chequea si los privilegios que vienen están en la BD
                    foreach (PhxPrivilegeEntity Priv in Privileges)
                    {                        
                        // si no está hay que agregarlo
                        if (DBPrivRolEC.FindPrivilegio(Priv.Key) == null)
                        {
                            PhxPrivilegeRoleEntity newPrivRol = new PhxPrivilegeRoleEntity();
                            newPrivRol.Privilege = Priv;
                            newPrivRol.Role = Role;
                            PrivToAdd.Add(newPrivRol);
                        }
                    }

                    // trae los priv de la DB para ver cuales no estan en la lista traida y se borran
                    foreach (PhxPrivilegeRoleEntity PrivRol in DBPrivRolEC)
                    {
                        // si no está en la lista hay que borrarlo
                        if(Privileges.Find(PrivRol.Privilege.Key) == null)
                        {
                            PrivToDel.Add(PrivRol);
                        }
                    }

                    // borrar los de la lista a borrar
                    for (int i = 0; i < PrivToDel.Count; i++)
                    {
                        // graba reg de audit de revoke
                        AuditPhxPrivilegeRoleEntity AuditPriv = new AuditPhxPrivilegeRoleEntity(Responsable, false, Role, PrivToDel[i].Privilege);
                        session.Save(AuditPriv);
                        session.Delete(PrivToDel[i]);
                    }
                    // crear los de la lista a borrar
                    for (int i = 0; i < PrivToAdd.Count; i++)
                    {
                        // graba reg de audit de asignacion
                        AuditPhxPrivilegeRoleEntity AuditPriv = new AuditPhxPrivilegeRoleEntity(Responsable, true, Role, PrivToAdd[i].Privilege);
                        session.Save(AuditPriv);
                        session.Save(PrivToAdd[i]);
                    }
                    tx.Commit();
                    return Role.Id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }
    }
}
