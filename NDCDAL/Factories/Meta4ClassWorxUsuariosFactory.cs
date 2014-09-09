using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;

namespace NDCDAL.Factories
{
    public class Meta4ClassWorxUsuariosFactory
    {
        public void Save(Meta4ClassWorxUsuariosEntity entidad)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                try
                {
                    // crear el registro
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(entidad);
                    session.Refresh(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();

                    throw e; // e; //new SystemException(e.Message);
                }
            }
        }
    }
}
