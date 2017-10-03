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
    public class MacroClaveBusiness
    {
        public MacroClaveBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MacroClaveEntity Load(int id)
        {
            MacroClaveFactory factory = new MacroClaveFactory();

            return factory.Load(id);
        }

        public MacroClaveEntityCollection GetAll()
        {
            MacroClaveFactory factory = new MacroClaveFactory();

            return factory.GetAll(string.Empty);
        }

        public MacroClaveEntityCollection GetAll(string clave)
        {
            MacroClaveFactory factory = new MacroClaveFactory();

            return factory.GetAll(clave);
        }

        public void Save(MacroClaveEntity entidad)
        {
            MacroClaveFactory factory = new MacroClaveFactory();

            factory.Save(entidad);
        }

        public bool Delete(MacroClaveEntity MacroClave)
        {
            MacroClaveFactory factory = new MacroClaveFactory();

            return factory.Delete(MacroClave);
        }
    }
}