using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSInterfaceConectores.Response
{
    public class Resultado
    {
        private bool exito;
        private string mensaje;

        public bool Exito
        {
            set { exito = value; }
            get { return exito; }
        }

        public string Mensaje
        {
            set { mensaje = value; }
            get { return mensaje; }
        }
    }
}