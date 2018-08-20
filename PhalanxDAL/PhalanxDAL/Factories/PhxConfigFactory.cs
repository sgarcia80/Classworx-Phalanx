using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;

namespace PhalanxDAL.Factories
{
    public class PhxConfigFactory
    {
        public PhxConfigEntity GetConfigParam(string ParamCode)
        {
            PhxConfigEntity objParam = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {

                    objParam = (PhxConfigEntity)session.Load(typeof(PhxConfigEntity), ParamCode);
                    //objParam = (PhxConfigEntity)session.Load(typeof(PhxConfigEntity), "'" + ParamCode + "'");
                    
                    return objParam;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public void Save(PhxConfigEntity ConfigParam)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(ConfigParam);
                    tx.Commit();
                    //return ConfigParam.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    //return 0;
                    // handle exception
                }
            }
        }
    }

}
