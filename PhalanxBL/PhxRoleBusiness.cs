using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class PhxRoleBusiness
    {
        public PhxRoleEntityCollection GetAll()
        {
            PhxRolesFactory PhxRoleF = new PhxRolesFactory();
            //WDF.FilNombre = _filNombre;

            return PhxRoleF.GetAll();

        }

        public int Save(PhxRoleEntity Role, PhxPrivilegeEntityCollection PrivEC, string Responsable)
        {
            PhxUsersFactory UsrFac = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = UsrFac.GetPhxUser(Responsable);

            PhxRolesFactory PhxRoleF = new PhxRolesFactory();
            return PhxRoleF.Save(Role, PrivEC, PhxUsrE);
        }
    }
}
