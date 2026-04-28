using System;
using System.Collections.Generic;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;
using NHibernate.Criterion;

namespace NDCDAL.Factories
{
    public class Meta4ClassWorxUsuariosFactory
    {
        public string FilIdUsuarioRed { get; set; }
        public string FilTipoDocumento { get; set; }
        public string FilDocumento { get; set; }

        public IList<Meta4ClassWorxUsuariosEntity> GetAll()
        {
            IList<Meta4ClassWorxUsuariosEntity> legajos;

            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(Meta4ClassWorxUsuariosEntity), "ML");

                if (!string.IsNullOrEmpty(FilIdUsuarioRed))
                {
                    DataSearch = DataSearch.Add(Restrictions.Eq("ML.IdUsuarioRed", FilIdUsuarioRed));
                }

                if (!string.IsNullOrEmpty(FilTipoDocumento))
                {
                    DataSearch = DataSearch.Add(Restrictions.Eq("ML.TipoDocumento", FilTipoDocumento));
                }

                if (!string.IsNullOrEmpty(FilDocumento))
                {
                    DataSearch = DataSearch.Add(Restrictions.Eq("ML.Num_Documento", FilDocumento));
                }

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
                    //session.SaveOrUpdate(entidad);
                    //session.Refresh(entidad);

                    session.Save(entidad);

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
