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
    public class MacroUsuarioBusiness
    {
        public MacroUsuarioBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MacroUsuarioEntity Load(int id)
        {
            MacroUsuarioFactory factory = new MacroUsuarioFactory();

            return factory.Load(id);
        }

        public MacroUsuarioEntityCollection GetAll(int macroid)
        {
            MacroUsuarioFactory factory = new MacroUsuarioFactory();

            return factory.GetAll(macroid, null, null);
        }

        public MacroUsuarioEntityCollection GetAll(int macroid, bool? principal, bool? activo)
        {
            MacroUsuarioFactory factory = new MacroUsuarioFactory();

            return factory.GetAll(macroid, principal, activo);
        }

        public void Save(MacroUsuarioEntity entidad)
        {
            MacroUsuarioFactory factory = new MacroUsuarioFactory();

            factory.Save(entidad);
        }

        public bool Delete(MacroUsuarioEntity MacroUsuario)
        {
            MacroUsuarioFactory factory = new MacroUsuarioFactory();

            return factory.Delete(MacroUsuario);
        }
    }
}