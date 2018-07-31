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
    public class MacroErrorBusiness
    {
        public MacroErrorBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MacroErrorEntity Load(int id)
        {
            MacroErrorFactory factory = new MacroErrorFactory();

            return factory.Load(id);
        }

        public MacroErrorEntityCollection GetAll()
        {
            MacroErrorFactory factory = new MacroErrorFactory();

            return factory.GetAll(string.Empty);
        }

        public MacroErrorEntityCollection GetAll(string descripcion)
        {
            MacroErrorFactory factory = new MacroErrorFactory();

            return factory.GetAll(descripcion);
        }

        public void Save(MacroErrorEntity entidad)
        {
            MacroErrorFactory factory = new MacroErrorFactory();

            factory.Save(entidad);
        }

        public bool Delete(MacroErrorEntity MacroError)
        {
            MacroErrorFactory factory = new MacroErrorFactory();

            return factory.Delete(MacroError);
        }
    }
}