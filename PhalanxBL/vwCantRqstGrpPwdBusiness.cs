using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class vwCantRqstGrpPwdBusiness
    {
        public bool RqstGrpIsDesactivable(int RqstGrpId)
        {
            vwCantRqstGrpPwdFactory CantFRGPF = new vwCantRqstGrpPwdFactory();
            CantFRGPF.FilRqstGrpId = RqstGrpId;
            CantFRGPF.CheckOneAssociation = true;
            if (CantFRGPF.GetAll().Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
