using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;

namespace NDCBL
{
    /// <summary>
    /// Summary description for ApplicationBusiness
    /// </summary>
    public class AplicacionNotificacionClaveBusiness
    {
        private string _filNombre = string.Empty;
        private bool _filNotificable = false;
        private bool _filEsAppRed = false;
        private bool _filEsAppCobis = false;

        public AplicacionNotificacionClaveBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string FilNombre
        {
            set { _filNombre = value; }
        }

        public bool FilNotificable
        {
            set { _filNotificable = value; }
        }
        public bool FilEsAppRed
        {
            set { _filEsAppRed = value; }
        }
        public bool FilEsAppCobis
        {
            set { _filEsAppCobis = value; }
        }

        public AplicacionNotificacionClaveEntity GetById(int id)
        {
            AplicacionNotificacionClaveFactory AppFac = new AplicacionNotificacionClaveFactory();

            return AppFac.GetById(id);
        }

        public AplicacionNotificacionClaveEntity GetByCodigo(string codigo)
        {
            AplicacionNotificacionClaveFactory AppFac = new AplicacionNotificacionClaveFactory();
            AppFac.FilCodigo = codigo;

            AplicacionNotificacionClaveEntityCollection lista = AppFac.GetAll();

            if (lista.Count > 0)
                return lista[0];

            return null;
        }

        public AplicacionNotificacionClaveEntityCollection GetAll()
        {
            AplicacionNotificacionClaveFactory AppFac = new AplicacionNotificacionClaveFactory();

            AppFac.FilNombre = _filNombre;
            AppFac.FilNotificable = _filNotificable;

            return AppFac.GetAll();
        }

        public void Create(AplicacionNotificacionClaveEntity entidad)
        {
            AplicacionNotificacionClaveFactory factory = new AplicacionNotificacionClaveFactory();

            factory.SaveBPMAplicacion(entidad);
        }

        public void Update(AplicacionNotificacionClaveEntity entidad)
        {
            AplicacionNotificacionClaveFactory factory = new AplicacionNotificacionClaveFactory();

            factory.SaveBPMAplicacion(entidad);
        }

        public bool SetearAppRed(AplicacionNotificacionClaveEntity entidad)
        {
            AplicacionNotificacionClaveFactory factory = new AplicacionNotificacionClaveFactory();

            return factory.SetearAppRed(entidad.Id);
        }

        public AplicacionNotificacionClaveEntity GetAppRed()
        {
            AplicacionNotificacionClaveFactory AppFac = new AplicacionNotificacionClaveFactory();
            AppFac.FilAppRed = true;

            AplicacionNotificacionClaveEntityCollection lista = AppFac.GetAll();

            if (lista.Count > 0)
                return lista[0];

            return null;
        }

        public AplicacionNotificacionClaveEntity GetAppCobis()
        {
            AplicacionNotificacionClaveFactory AppFac = new AplicacionNotificacionClaveFactory();

            return AppFac.GetAppCobis();
        }

        public bool SetearAppCobis(AplicacionNotificacionClaveEntity entidad)
        {
            AplicacionNotificacionClaveFactory factory = new AplicacionNotificacionClaveFactory();

            return factory.SetearAppCobis(entidad.Id);
        }
    }
}