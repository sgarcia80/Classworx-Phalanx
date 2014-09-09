using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class VwPerfilUsuarioBusiness
    {
        public VwPerfilUsuarioEntityCollection GetAll()
        {
            return new VwPerfilUsuarioFactory().GetAll();
        }
        public VwPerfilUsuarioEntityCollection GetAllOrdByRole()
        {
            VwPerfilUsuarioFactory PerfFac = new VwPerfilUsuarioFactory();
            PerfFac.OrderResultsBy = VwPerfilUsuarioFactory.OrderBy.RoleName;
            return PerfFac.GetAll();
        }
    }
}
