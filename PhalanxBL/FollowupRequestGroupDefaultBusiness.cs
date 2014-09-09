using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class FollowupRequestGroupDefaultBusiness
    {
        public FollowupRequestGroupEntity GetDefaultFollowupRqstGrpATMs()
        {
            FollowupRequestGroupEntity DefaultFollowupRqstGrpATMs = null;
            /// buscar UserTypeATMs
            UserTypeEntity UserTypeATM = new UserTypeBusiness().GetUserTypeATM();
            /// buscar registro en followup_request_group_default
            FollowupRequestGroupDefaultFactory FRqstGrpDefFac = new FollowupRequestGroupDefaultFactory();
            FRqstGrpDefFac.FilUserType = UserTypeATM;
            FollowupRequestGroupDefaultEntityCollection FRqstGrpDefEC = FRqstGrpDefFac.GetAll();
            if (FRqstGrpDefEC.Count > 0)
            {
                DefaultFollowupRqstGrpATMs = FRqstGrpDefEC[0].FollowupRqstGrp;
            }
            return DefaultFollowupRqstGrpATMs;

        }

        public FollowupRequestGroupDefaultEntity SetFollowupRqstGrpATMs(int FollowupRqstGrpID)
        {
            FollowupRequestGroupDefaultEntity ATMsDefaultFRqstGrp = new FollowupRequestGroupDefaultEntity();
            /// buscar UserTypeATMs
            UserTypeEntity UserTypeATM = new UserTypeBusiness().GetUserTypeATM();
            /// buscar registro en followup_request_group_default
            FollowupRequestGroupDefaultFactory FRqstGrpDefFac = new FollowupRequestGroupDefaultFactory();
            FRqstGrpDefFac.FilUserType = UserTypeATM;
            FollowupRequestGroupDefaultEntityCollection FRqstGrpDefEC = FRqstGrpDefFac.GetAll();
            FollowupRequestGroupEntity FRqstGrp = new FollowupRequestGroupFactory().Load(FollowupRqstGrpID);
            if (FRqstGrpDefEC.Count > 0)
            {
                ATMsDefaultFRqstGrp = FRqstGrpDefEC[0];
            }
            else
            {
                ATMsDefaultFRqstGrp.UserType = UserTypeATM;
            }
            ATMsDefaultFRqstGrp.FollowupRqstGrp = FRqstGrp;
            FRqstGrpDefFac.Save(ATMsDefaultFRqstGrp);
            // actualizar el rqst grp de todas las claves

            return ATMsDefaultFRqstGrp;
        }
    }
}
