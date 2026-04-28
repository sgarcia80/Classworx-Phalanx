using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSInterfaceConectores.Entities;

namespace WSInterfaceConectores.Response
{
    public class ListaResultado : Resultado
    {
        public List<Item> Lista { get; set; }
    }
}