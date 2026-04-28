using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class vwCantFollowRqstGrpPwdBusiness
    {
        public bool FollowRqstGrpIsDesactivable(int FollowRqstGrpId)
        {
            vwCantFollowRqstGrpPwdFactory CantFRGPF = new vwCantFollowRqstGrpPwdFactory();
            CantFRGPF.FilFollowRqstGrpId = FollowRqstGrpId;
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
