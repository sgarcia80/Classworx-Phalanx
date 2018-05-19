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
        private string _filUsuario;
        private string _filNombre;
        private string _filApellido;

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
        
        public string FilUsuario
        {
            set { _filUsuario = value; }
        }

        public string FilNombre
        {
            set { _filNombre = value; }
        }

        public string FilApellido
        {
            set { _filApellido = value; }
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

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.UsuarioRed", _filUsuario));
               
                if (!string.IsNullOrEmpty(_filNombre))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.Nombre", _filNombre));

                if (!string.IsNullOrEmpty(_filApellido))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.Apellido", _filApellido));
                
                try
                {
                    legajos = DataSearch.List<Meta4LegajoEntity>();

                    legajoEC.Add(legajos);
                }
                catch (Exception ex)
                {
                    legajos = null;
                }
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

        public Meta4LegajoEntityCollection Search()
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

                if (_filDoc != null & !string.IsNullOrEmpty(_filDoc))
                    DataSearch = DataSearch.Add(Expression.Eq("ML.Documento", _filDoc));

                if (!string.IsNullOrEmpty(_filUsuario))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.UsuarioRed", _filUsuario, MatchMode.Anywhere));

                if (!string.IsNullOrEmpty(_filNombre))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.Nombre", _filNombre, MatchMode.Anywhere));

                if (!string.IsNullOrEmpty(_filApellido))
                    DataSearch = DataSearch.Add(Expression.InsensitiveLike("ML.Apellido", _filApellido, MatchMode.Anywhere));

                try
                {
                    legajos = DataSearch.List<Meta4LegajoEntity>();

                    legajoEC.Add(legajos);
                }
                catch (Exception ex)
                {
                    legajos = null;
                }
            }

            return legajoEC;
        }
    }
}
