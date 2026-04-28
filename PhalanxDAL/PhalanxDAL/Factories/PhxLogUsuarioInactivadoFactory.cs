using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
	public class PhxLogUsuarioInactivadoFactory
    {
		public int Save(PhxLogUsuarioInactivado logUsuarioInactivado)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
					session.SaveOrUpdate(logUsuarioInactivado);
                    tx.Commit();
					return logUsuarioInactivado.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }
    }
}
