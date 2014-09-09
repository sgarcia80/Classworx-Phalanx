using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NHibernate;
using PhalanxDAL;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class Meta4LegajoFactory
    {
        //private Meta4SociedadEntity _filSociedad = null;
        private string _filSociedad;
        private string _filId;
        private string _filTipoDoc;
        private string _filDoc;

        /*
        public Meta4SociedadEntity FilSociedad
        {
            set { _filSociedad = value; }
        }
        */

        public string FilSociedad
        {
            set { _filSociedad = value; }
        }

        public string FilId
        {
            set { _filId = value; }
        }

        public string FilTipoDocumento
        {
            set { _filTipoDoc = value; }
        }

        public string FilDocumento
        {
            set { _filDoc = value; }
        }

        public Meta4LegajoEntityCollection GetAll()
        {
            IList<Meta4LegajoEntity> legajos;

            Meta4LegajoEntityCollection legajoEC = new Meta4LegajoEntityCollection();

            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(Meta4LegajoEntity), "ML");
                
                if (_filId != null)
                    DataSearch.Add(Expression.Eq("ML.Id", _filId));

                if (_filSociedad != null)
                    DataSearch = DataSearch.Add(Expression.Eq("ML.Sociedad.Id", _filSociedad));

                if (_filTipoDoc != null)
                    DataSearch = DataSearch.Add(Expression.Eq("ML.IdTipoDocumento", _filTipoDoc));

                if (_filDoc != null)
                    DataSearch = DataSearch.Add(Expression.Eq("ML.Documento", _filDoc));

                try
                {
                    legajos = DataSearch.List<Meta4LegajoEntity>();
                }
                catch (Exception ex)
                {
                    legajos = null;
                }

                legajoEC.Add(legajos);
            }

            return legajoEC;
        }

        public IList<string> GetCalles()
        {
            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                return session.CreateQuery("SELECT DISTINCT l.Calle FROM Meta4LegajoEntity l")
                    .List<string>();
            }
        }

        public IList<string> GetTiposDocumento()
        {
            using (ISession session = DBMgr.factoryMeta4.OpenSession())
            {
                return session.CreateQuery("SELECT DISTINCT l.TipoDocumento FROM Meta4LegajoEntity l")
                    .List<string>();
            }
        }
    }
}
