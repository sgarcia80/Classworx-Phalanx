using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;

namespace PhalanxDAL.Factories
{
    public class EventoLoginFactory
    {
        public EventoLoginEntity GetEventoIngSatisf()
        {
            return this.Load(1);
        }

        public EventoLoginEntity GetEventoUsrNoExist()
        {
            return this.Load(2);
        }

        private EventoLoginEntity Load(int IdEvento)
        {
            try
            {
                EventoLoginEntity objPhxUsr = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    objPhxUsr = (EventoLoginEntity)session.Load(typeof(EventoLoginEntity), IdEvento);
                }
                return objPhxUsr;
            }
            catch (NHibernate.ObjectNotFoundException)
            {
                return null;
            }
            catch (NHibernate.HibernateException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public EventoLoginEntity GetEventoSinPermiso()
        {
            return this.Load(3);
        }
        
        public EventoLoginEntity GetEventoUsrNoActivo()
        {
            return this.Load(4);
        }

        public EventoLoginEntity GetEventoUsrConIncorrecto()
        {
            return this.Load(5);
        }
    }
}
