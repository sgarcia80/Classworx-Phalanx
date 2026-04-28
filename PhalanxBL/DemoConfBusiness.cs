using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class DemoConfBusiness
    {
        public PhxUserEntity GetPwdRqstAuth()
        {
            DemoConfFactory democonfF = new DemoConfFactory();
            string AuthID = democonfF.GetPwdRqstAuthId();
            if (AuthID == null || AuthID == "")
            {
                return null;
            }
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            return PhxUsrBL.Load(Convert.ToInt32(AuthID));
        }
        public bool SetPwdRqstAuthUserParam(int PwdRqstAuthUserId)
        {
            DemoConfFactory DCF = new DemoConfFactory();
            return DCF.SetPwdRqstAuthId(PwdRqstAuthUserId.ToString());
        }

    }
}
