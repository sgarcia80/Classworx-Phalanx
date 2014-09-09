using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    public class Meta4SociedadBusiness
    {
        public Meta4SociedadEntityCollection GetAll()
        {
            Meta4SociedadFactory SocFac = new Meta4SociedadFactory();

            return SocFac.GetAll();
        }
    }
}
