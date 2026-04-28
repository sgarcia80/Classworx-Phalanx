using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class TicketNotificacionTarjetaEntityCollection : BaseEntityCollection
    {
        public TicketNotificacionTarjetaEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(TicketNotificacionTarjetaEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<TicketNotificacionTarjetaEntity> entityList)
        {
            foreach (TicketNotificacionTarjetaEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, TicketNotificacionTarjetaEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new TicketNotificacionTarjetaEntity this[int index]
        {
            get { return (TicketNotificacionTarjetaEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new TicketNotificacionTarjetaEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                TicketNotificacionTarjetaEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new TicketNotificacionTarjetaEntity Find(string entityKeyString)
        {
            foreach (TicketNotificacionTarjetaEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
