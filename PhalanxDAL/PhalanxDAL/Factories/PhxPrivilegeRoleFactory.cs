using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using NHibernate;
using PhalanxCommon.Entities;
using PhalanxCommon;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
    public class PhxPrivilegeRoleFactory
    {

        public PhxPrivilegeRoleEntityCollection GetAll(PhxRoleEntity Rol)
        {
            return this.GetAll(Rol, null);
            /*
            PhxPrivilegeRoleEntityCollection WinDomLst = new PhxPrivilegeRoleEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxPrivilegeRoleEntity));
                    DataSearch.Add(Expression.Eq("Role", Rol));
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    WinDomLst.Add(DataSearch.List<PhxPrivilegeRoleEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            return WinDomLst;*/

        }

        public PhxPrivilegeRoleEntityCollection GetAll(PhxRoleEntity Rol, PhxPrivilegeEntity Privilegio)
        {
            PhxPrivilegeRoleEntityCollection WinDomLst = new PhxPrivilegeRoleEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxPrivilegeRoleEntity));
                    if (Rol != null && Rol.Id > 0)
                    { DataSearch.Add(Expression.Eq("Role", Rol)); }
                    if (Privilegio != null && Privilegio.Id > 0)
                    { DataSearch.Add(Expression.Eq("Privilege", Privilegio)); }
                    WinDomLst.Add(DataSearch.List<PhxPrivilegeRoleEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PhxPrivilegeRoleFactory GetAll()"));
            }
            return WinDomLst;

        }
    }
}
