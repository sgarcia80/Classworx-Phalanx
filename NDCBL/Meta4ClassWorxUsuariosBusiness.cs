using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;

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

        public void Create(Meta4ClassWorxUsuariosEntity entidad)
        {
            Meta4ClassWorxUsuariosFactory factory = new Meta4ClassWorxUsuariosFactory();

            factory.Save(entidad);
        }

    }
}