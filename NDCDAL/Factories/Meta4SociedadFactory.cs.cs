using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;

namespace NDCDAL.Factories
{
    public class Meta4SociedadFactory
    {
        public Meta4SociedadEntityCollection GetAll()
        {
            IList<Meta4SociedadEntity> sociedades;

            Meta4SociedadEntityCollection sociedadEC = new Meta4SociedadEntityCollection();

            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(Meta4SociedadEntity), "MS");

                try
                {
                    sociedades = DataSearch.List<Meta4SociedadEntity>();
                    sociedadEC.Add(sociedades);
                }
                catch
                {
                }

            }

            return sociedadEC;
        }
    }
}