using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using Classworx.Common.Trace;

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
                    //entity.PhxUser = PUF.GetPhxUser();

                    tx = session.BeginTransaction();

                    session.Save(entity);
                    tx.Commit();
                    return entity.Id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();

                    TraceHelper.Error(ex,"Error al grabar historial de visualizacion de contrasenas");
                    return 0;
                }
            }
        }

    }
}
