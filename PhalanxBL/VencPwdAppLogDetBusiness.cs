using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using System.Collections;

namespace PhalanxBL
{
    public class VencPwdAppLogDetBusiness
    {
        public void Save(VencPwdAppLogDetEntity log)
        {
            new VencPwdAppLogDetFactory().Save(log);
        }

        public VencPwdAppLogDetEntityCollection GetAll()
        {
            VencPwdAppLogDetFactory fac = new VencPwdAppLogDetFactory();

            return fac.GetAll();
        }

    }
}
