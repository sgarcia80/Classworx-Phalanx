using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class PhxPrivilegeRoleBusiness
    {
        public PhxPrivilegeRoleEntityCollection GetAll(PhxRoleEntity Rol)
        {
            PhxPrivilegeRoleFactory GrpF = new PhxPrivilegeRoleFactory();
            return GrpF.GetAll(Rol);
        }
    }
}
