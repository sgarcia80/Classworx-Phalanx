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
    public class MacroBusiness
    {
        public static class HeaderTags
        {
            public const string Tag_Admin_Usuario_1 = "[Principal]";
            public const string Tag_Admin_Clave_1 = "[ClavePrincipal]";
            public const string Tag_Admin_Usuario_2 = "[Secundario]";
            public const string Tag_Admin_Clave_2 = "[ClaveSecundario]";
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

        public MacroEntityCollection Exists(string nombre)
        {
            MacroFactory factory = new MacroFactory();

            return factory.Exists(nombre);
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

        public string ReplaceHeader(string contenido, MacroUsuarioEntity principal, MacroUsuarioEntity secundario)
        {
            CCryptMgr crypt = new CCryptMgr();

            string usr1 = string.Empty;
            string pwd1 = string.Empty;

            string usr2 = string.Empty;
            string pwd2 = string.Empty;

            if (principal != null)
            {
                usr1 = principal.UsuarioTC;
                pwd1 = crypt.decryptAndClearBadChars(principal.ClaveTC);
            }
            if (secundario != null)
            {
                usr2 = secundario.UsuarioTC;
                pwd2 = crypt.decryptAndClearBadChars(secundario.ClaveTC);
            }

            return ReplaceHeader(contenido, usr1, pwd1, usr2, pwd2);
        }

        public string ReplaceHeader(string contenido, string admin1, string adminclave1, string admin2, string adminclave2)
        { 
            string value = contenido;

            value = value.Replace(HeaderTags.Tag_Admin_Usuario_1, admin1);
            value = value.Replace(HeaderTags.Tag_Admin_Clave_1, adminclave1);

            value = value.Replace(HeaderTags.Tag_Admin_Usuario_2, admin2);
            value = value.Replace(HeaderTags.Tag_Admin_Clave_2, adminclave2);

            return value;
        }

        public string ReplaceBody(string contenido, string usuario, string clave)
        {
            string value = contenido;

            value = value.Replace(BodyTags.Tag_Usuario, usuario);
            value = value.Replace(BodyTags.Tag_Clave, clave);

            return value;
        }
    }
}