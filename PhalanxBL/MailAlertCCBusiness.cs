using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxMAL;
using System.Net.Mail;
using System.Reflection;
using System.Collections;

namespace PhalanxBL
{
    public class MailAlertCCBusiness
    {
        public MailAlertCCEntity CreateCC(string ccAddress)
        {
            MailAlertCCEntity entityCC = new MailAlertCCEntity();

            if (ccAddress != string.Empty && ccAddress != "")
                entityCC.CcAddress = ccAddress;

            return entityCC;
        }

        public MailAlertCCEntity CreateCC(string ccName, string ccAddress, MailAlertEntity mailAlert)
        {
            MailAlertCCEntity entityCC = new MailAlertCCEntity();

            if (ccName != string.Empty && ccName != "")
                entityCC.CcName = ccName;

            if (ccAddress != string.Empty && ccAddress != "")
                entityCC.CcAddress = ccAddress;

            entityCC.MailAlert = mailAlert;

            return entityCC;
        }

        public MailAddressCollection LoadMailAddressC(MailAddressCollection MailAC, IList MailCCList)
        {
            MailAddressCollection MailAC_CC = new MailAddressCollection();
            MailAC_CC = MailAC;

            foreach (MailAlertCCEntity MailAlertCC in MailCCList)
            {
                MailAddress MailAdd;
                if (MailAlertCC.CcName != string.Empty && MailAlertCC.CcName != "")
                {
                    MailAdd = new MailAddress(MailAlertCC.CcAddress, MailAlertCC.CcName);
                }
                else
                {
                    MailAdd = new MailAddress(MailAlertCC.CcAddress);
                }
                MailAC_CC.Add(MailAdd);
            }

            return MailAC_CC;
        }

    }
}
