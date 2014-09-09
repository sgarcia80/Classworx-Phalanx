using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class VwPermisoPerfilBusiness
    {
        public VwPermisoPerfilEntityCollection GetAll()
        {
            return new VwPermisoPerfilFactory().GetAll();
        }
    }
}
