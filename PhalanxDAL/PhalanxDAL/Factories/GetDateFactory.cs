using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace PhalanxDAL.Factories
{
    public class GetDateFactory
    {
        public VwDateEntity GetDate()
        {
            try
            {
                VwDateEntity objPR = new VwDateEntity();
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    IList<VwDateEntity> PRlst = session.CreateCriteria(typeof(VwDateEntity)).List<VwDateEntity>();
                    if (PRlst.Count == 1)
                    {
                        objPR = PRlst[0];
                    }
                    else
                    {
                        return null;
                    }

                    return objPR;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
