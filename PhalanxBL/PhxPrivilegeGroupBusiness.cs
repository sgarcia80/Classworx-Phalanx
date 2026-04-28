using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class PhxPrivilegeGroupBusiness
    {
        public PhxPrivilegeGroupEntityCollection GetAll(bool CargaPrivilegios)
        {
            PhxPrivilegeGroupFactory GrpF = new PhxPrivilegeGroupFactory();
            if (CargaPrivilegios)
            {
                GrpF.FilCargaPrivilegios = CargaPrivilegios;
            }
            return GrpF.GetAll();
        }
    }
}
