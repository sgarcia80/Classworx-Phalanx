using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class TicketNotificacionBlanqueoEntityCollection : BaseEntityCollection
    {
        public TicketNotificacionBlanqueoEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(TicketNotificacionBlanqueoEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<TicketNotificacionBlanqueoEntity> entityList)
        {
            foreach (TicketNotificacionBlanqueoEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, TicketNotificacionBlanqueoEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new TicketNotificacionBlanqueoEntity this[int index]
        {
            get { return (TicketNotificacionBlanqueoEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new TicketNotificacionBlanqueoEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                TicketNotificacionBlanqueoEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new TicketNotificacionBlanqueoEntity Find(string entityKeyString)
        {
            foreach (TicketNotificacionBlanqueoEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
