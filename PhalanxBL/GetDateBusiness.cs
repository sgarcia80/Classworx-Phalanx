using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class GetDateBusiness
    {
        public VwDateEntity GetDate()
        {
            return new GetDateFactory().GetDate();
        }
    }
}
