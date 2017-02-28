using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class HistPasswordChangeAccessFactory
    {
        public int Save(HistPasswordChangeAccessEntity entity)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    PhxUsersFactory PUF = new PhxUsersFactory();
                    entity.PhxUser = PUF.GetPhxUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                    tx = session.BeginTransaction();
                    session.Save(entity);
                    tx.Commit();
                    return entity.Id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }

    }
}
