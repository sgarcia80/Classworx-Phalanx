using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;
using phxCryptMgr;

namespace NDCBL
{
    /// <summary>
    /// Summary description for ApplicationBusiness
    /// </summary>
    public class BloqueoBusiness
    {
        public BloqueoBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public BloqueoEntity Load(BloqueoEntity.TipoBLoqueo id)
        {
            BloqueoFactory factory = new BloqueoFactory();

            return factory.Load((int)id);
        }

        public BloqueoEntityCollection GetBloqueos()
        {
            BloqueoEntityCollection list = new BloqueoEntityCollection();

            list.Add(new BloqueoEntity { Codigo = (int)BloqueoEntity.TipoBLoqueo.Ninguno });
            list.Add(new BloqueoEntity { Codigo = (int)BloqueoEntity.TipoBLoqueo.AutogestionCobis });

            return list;
        }

        public bool IsBloqueoActivo(BloqueoEntity.TipoBLoqueo tipobloqueo)
        {
            bool active = false;
            int codigo = Convert.ToInt32(tipobloqueo);

            BloqueoFactory factory = new BloqueoFactory();
            BloqueoEntityCollection bloqueos = factory.GetBloqueoActivo(codigo);

            if (bloqueos != null && bloqueos.Count > 0)
            {
                active = bloqueos[0].Activo;
            }

            return active;
        }

        public BloqueoEntityCollection GetBloqueoActivo(int codigo)
        {
            BloqueoFactory factory = new BloqueoFactory();

            return factory.GetBloqueoActivo(codigo);
        }

        public BloqueoEntityCollection GetAll()
        {
            BloqueoFactory factory = new BloqueoFactory();

            return factory.GetAll(0, null, null);
        }

        public BloqueoEntityCollection GetAll(int codigo, DateTime? fechadesde, DateTime? fechahasta)
        {
            BloqueoFactory factory = new BloqueoFactory();

            return factory.GetAll(codigo, fechadesde, fechahasta);
        }

        public void Save(BloqueoEntity entidad)
        {
            BloqueoFactory factory = new BloqueoFactory();

            factory.Save(entidad);
        }

        public bool Delete(BloqueoEntity Bloqueo)
        {
            BloqueoFactory factory = new BloqueoFactory();

            return factory.Delete(Bloqueo);
        }
    }
}