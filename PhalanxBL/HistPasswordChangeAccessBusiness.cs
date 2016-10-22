using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class HistPasswordChangeAccessBusiness
    {
        public int Save(HistPasswordChangeAccessEntity entity)
        {
            return new HistPasswordChangeAccessFactory().Save(entity);
        }
    }
}
