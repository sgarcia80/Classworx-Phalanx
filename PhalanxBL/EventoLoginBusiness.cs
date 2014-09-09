using System;
using System.Collections.Generic;
using System.Text;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class EventoLoginBusiness
    {
        public EventoLoginEntity GetEventoIngSatisf()
        {
            return new EventoLoginFactory().GetEventoIngSatisf();
        }
        public EventoLoginEntity GetEventoUsrNoExist()
        {
            return new EventoLoginFactory().GetEventoUsrNoExist();
        }

        public EventoLoginEntity GetEventoSinPermiso()
        {
            return new EventoLoginFactory().GetEventoSinPermiso();
        }
        public EventoLoginEntity GetEventoUsrNoActivo()
        {
            return new EventoLoginFactory().GetEventoUsrNoActivo();
        }
        public EventoLoginEntity GetEventoUsrConIncorrecto()
        {
            return new EventoLoginFactory().GetEventoUsrConIncorrecto();
        }
    }
}
