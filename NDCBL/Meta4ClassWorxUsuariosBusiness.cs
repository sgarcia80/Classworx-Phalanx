using NDCCommon.Entities;
using NDCDAL.Factories;
using System.Collections.Generic;

namespace NDCBL
{
    /// <summary>
    /// Summary description for Meta4ClassWorxUsuariosBusiness
    /// </summary>
    public class Meta4ClassWorxUsuariosBusiness
    {
        public Meta4ClassWorxUsuariosBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public IList<Meta4ClassWorxUsuariosEntity> GetUser(string usuario)
        {
            Meta4ClassWorxUsuariosFactory factory = new Meta4ClassWorxUsuariosFactory();
            factory.FilIdUsuarioRed = usuario;

            return factory.GetAll();
        }

        public void Create(Meta4ClassWorxUsuariosEntity entidad)
        {
            Meta4ClassWorxUsuariosFactory factory = new Meta4ClassWorxUsuariosFactory();

            factory.Save(entidad);
        }

    }
}