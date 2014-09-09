using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class TicketNotificacionClaveEntityCollection : BaseEntityCollection
    {
        public TicketNotificacionClaveEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(TicketNotificacionClaveEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<TicketNotificacionClaveEntity> entityList)
        {
            foreach (TicketNotificacionClaveEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, TicketNotificacionClaveEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new TicketNotificacionClaveEntity this[int index]
        {
            get { return (TicketNotificacionClaveEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new TicketNotificacionClaveEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                TicketNotificacionClaveEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new TicketNotificacionClaveEntity Find(string entityKeyString)
        {
            foreach (TicketNotificacionClaveEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
