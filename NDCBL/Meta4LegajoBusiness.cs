using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;

namespace NDCBL
{
    public class Meta4LegajoBusiness
    {
        public Meta4LegajoEntityCollection GetAll(string usuario, string nombre, string apellido)
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            factory.FilUsuario = usuario;
            factory.FilApellido = apellido;
            factory.FilNombre = nombre;

            Meta4LegajoEntityCollection legajos = factory.GetAll();

            return legajos;
        }
        
        public Meta4LegajoEntity GetByLegajoAndSociedad(string legajo, string idSociedad)
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            factory.FilId = legajo;
            factory.FilSociedad = idSociedad;

            Meta4LegajoEntityCollection legajos = factory.GetAll();

            if (legajos.Count < 1)
                return null;

            return legajos[0];
        }

        public Meta4LegajoEntity GetByUsuario(string usuario)
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            factory.FilUsuario = usuario;

            Meta4LegajoEntityCollection legajos = factory.GetAll();

            if (legajos.Count < 1)
                return null;

            return legajos[0];
        }

        public Meta4LegajoEntity GetByDocumento(string tipo, string documento)
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            factory.FilTipoDocumento = tipo;
            factory.FilDocumento = documento;

            Meta4LegajoEntityCollection legajos = factory.GetAll();

            if (legajos.Count < 1)
                return null;

            return legajos[0];
        }

        public IList<string> GetCalles()
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            return factory.GetCalles();
        }

        public IList<string> GetTiposDocumento()
        {
            Meta4LegajoFactory factory = new Meta4LegajoFactory();

            return factory.GetTiposDocumento();
        }
    }
}
