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
    public class MacroBusiness
    {
        public static class HeaderTags
        {
            public const string Tag_Admin_Usuario_1 = "[UsuarioAdmin1]";
            public const string Tag_Admin_Clave_1 = "[ClaveAdmin1]";
            public const string Tag_Admin_Usuario_2 = "[UsuarioAdmin2]";
            public const string Tag_Admin_Clave_2 = "[ClaveAdmin2]";
        }
        public static class BodyTags
        {
            public const string Tag_Usuario = "[Usuario]";
            public const string Tag_Clave = "[Clave]";
        }

        public MacroBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MacroEntity Load(int id)
        {
            MacroFactory factory = new MacroFactory();

            return factory.Load(id);
        }

        public MacroEntityCollection GetAll()
        {
            MacroFactory factory = new MacroFactory();

            return factory.GetAll(string.Empty);
        }

        public MacroEntityCollection GetAll(string nombre)
        {
            MacroFactory factory = new MacroFactory();

            return factory.GetAll(nombre);
        }

        public void Save(MacroEntity entidad)
        {
            MacroFactory factory = new MacroFactory();

            factory.Save(entidad);
        }

        public bool Delete(MacroEntity Macro)
        {
            MacroFactory factory = new MacroFactory();

            return factory.Delete(Macro);
        }
    }
}