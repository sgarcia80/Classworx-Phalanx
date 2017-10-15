using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;
using System.Collections.Generic;

namespace NDCBL
{
    /// <summary>
    /// Summary description for ApplicationBusiness
    /// </summary>
    public class MacroUsuarioTarjetaBusiness
    {
        public MacroUsuarioTarjetaBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MacroUsuarioTarjetaEntity Load(int id)
        {
            MacroUsuarioTarjetaFactory factory = new MacroUsuarioTarjetaFactory();

            return factory.Load(id);
        }

        public MacroUsuarioTarjetaEntityCollection GetAll(string usuariored, string usuariotc, string appcode)
        {
            MacroUsuarioTarjetaFactory factory = new MacroUsuarioTarjetaFactory();

            return factory.GetAll(usuariored, usuariotc, appcode);
        }

        public void Save(List<MacroUsuarioTarjetaEntity> list)
        {
            MacroUsuarioTarjetaFactory factory = new MacroUsuarioTarjetaFactory();

            factory.Save(list);
        }

        public bool Delete(MacroUsuarioTarjetaEntity MacroUsuarioTarjeta)
        {
            MacroUsuarioTarjetaFactory factory = new MacroUsuarioTarjetaFactory();

            return factory.Delete(MacroUsuarioTarjeta);
        }
    }
}