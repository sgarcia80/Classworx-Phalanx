using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class PhxContingenciaBusiness
    {
        public PhxContingenciaEntity EsquemaActualHabilitado()
        {
            return new PhxContingenciaFactory().EsquemaActualHabilitado();
        }
        public bool CheckAlternateConnection()
        {
            PhxContingenciaFactory PUF = new PhxContingenciaFactory();
            return PUF.CheckDataBaseAlternateConnection();
        }
        public bool EsAmbienteActualProduccion()
        {
            return new PhxContingenciaFactory().EsAmbienteActualProduccion();
        }
        public bool CheckConnection()
        {
            PhxContingenciaFactory PUF = new PhxContingenciaFactory();
            return PUF.CheckDataBaseConnection();
        }
        public bool VerificaSiConexionUsadaEstaActiva()
        {
            return new PhxContingenciaFactory().VerificaSiConexionUsadaEstaActiva();
        }
        //public void ActivarEsquemaProduccion()
        //{
        //    PhxContingenciaEntity PhxContE = new PhxContingenciaEntity();
        //    PhxContE.SetProduccion();
        //    PhxContingenciaFactory PUF = new PhxContingenciaFactory();
        //    PUF.Save(PhxContE);
        //}
        //public void ActivarEsquemaContingencia()
        //{
        //    PhxContingenciaEntity PhxContE = new PhxContingenciaEntity();
        //    PhxContingenciaFactory PUF = new PhxContingenciaFactory();
        //    PUF.Save(PhxContE);
        //}
        /// <summary>
        /// Activa el nuevo esquema en la BD y modifica el ini
        /// </summary>
        /// <param name="Produccion"></param>
        public void ActivarEsquema(bool Produccion)
        {
            PhxContingenciaEntity PhxContE = new PhxContingenciaEntity();
            if (Produccion)
            {
                PhxContE.SetProduccion();
            }
            else
            {
                PhxContE.SetContingencia();
            }
            PhxContingenciaFactory PUF = new PhxContingenciaFactory();
            PUF.Save(PhxContE);
            PUF.SetearEsquemaActivo(Produccion);
        }
        /// <summary>
        /// Modifica el ini de la aplicacion
        /// </summary>
        /// <param name="Produccion"></param>
        public void SetearEsquemaActivo(bool Produccion)
        {
            PhxContingenciaFactory PUF = new PhxContingenciaFactory();
            PUF.SetearEsquemaActivo(Produccion);
        }
    }
}
