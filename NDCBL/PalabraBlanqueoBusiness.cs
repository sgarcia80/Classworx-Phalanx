using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;

namespace NDCBL
{
    /// <summary>
    /// Summary description for ApplicationBusiness
    /// </summary>
    public class PalabraBlanqueoBusiness
    {
        public PalabraBlanqueoBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public PalabraBlanqueoEntityCollection GetAll()
        {
            PalabraBlanqueoFactory factory = new PalabraBlanqueoFactory();

            return factory.GetAll();
        }
    }
}