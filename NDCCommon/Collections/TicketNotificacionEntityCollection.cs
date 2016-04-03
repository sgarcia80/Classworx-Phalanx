using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class TicketNotificacionEntityCollection : BaseEntityCollection
    {
        public TicketNotificacionEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(TicketNotificacionEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<TicketNotificacionEntity> entityList)
        {
            foreach (TicketNotificacionEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, TicketNotificacionEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new TicketNotificacionEntity this[int index]
        {
            get { return (TicketNotificacionEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new TicketNotificacionEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                TicketNotificacionEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new TicketNotificacionEntity Find(string entityKeyString)
        {
            foreach (TicketNotificacionEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
