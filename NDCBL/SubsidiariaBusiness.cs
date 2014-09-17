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
    public class SubsidiariaBusiness
    {
        public SubsidiariaBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string FilNombre { set; get; }

        public SubsidiariaEntity GetById(int id)
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            return factory.GetById(id);
        }

        public SubsidiariaEntityCollection GetAll()
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            factory.FilNombre = FilNombre;

            return factory.GetAll();
        }

        public void Save(SubsidiariaEntity entidad)
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            factory.Save(entidad);
        }

        public void Create(SubsidiariaEntity entidad)
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            factory.Save(entidad);
        }

        public void Update(SubsidiariaEntity entidad)
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            factory.Save(entidad);
        }

        public bool Delete(SubsidiariaEntity subsidiaria)
        {
            SubsidiariaFactory factory = new SubsidiariaFactory();

            return factory.Delete(subsidiaria);
        }
    }
}