using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class Meta4ClassWorxUsuariosFactory
    {
        public string FilIdUsuarioRed { get; set; }

        public IList<Meta4ClassWorxUsuariosEntity> GetAll()
        {
            IList<Meta4ClassWorxUsuariosEntity> legajos;

            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(Meta4ClassWorxUsuariosEntity), "ML");

                DataSearch = DataSearch.Add(Expression.Eq("ML.IdUsuarioRed", FilIdUsuarioRed));

                try
                {
                    legajos = DataSearch.List<Meta4ClassWorxUsuariosEntity>();
                }
                catch (Exception ex)
                {
                    legajos = new List<Meta4ClassWorxUsuariosEntity>();
                }
            }

            return legajos;
        }

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
