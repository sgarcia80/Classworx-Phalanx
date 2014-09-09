using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    public class DominioLoginBusiness
    {
        public DominioLoginEntityCollection GetAllParaCombo()
        {
            return new DominioLoginFactory().GetAllFromConfig();
        }

    }
}
