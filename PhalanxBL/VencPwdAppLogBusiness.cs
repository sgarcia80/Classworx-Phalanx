using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using System.Collections;

namespace PhalanxBL
{
    public class VencPwdAppLogBusiness
    {
        public void Save(VencPwdAppLogEntity log)
        {
            new VencPwdAppLogFactory().Save(log);
        }

        public VencPwdAppLogEntityCollection GetAll(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            VencPwdAppLogFactory fac = new VencPwdAppLogFactory();

            return fac.GetAll();
        }

        public VencPwdAppLogEntityCollection GetAll()
        {
            VencPwdAppLogFactory fac = new VencPwdAppLogFactory();
            return fac.GetAll();
        }

    }
}
