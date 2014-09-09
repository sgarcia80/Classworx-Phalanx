using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Common.Collections
{
    public class EventoLoginEntityCollection : BaseEntityCollection
    {
        public int Add(EventoLoginEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<EventoLoginEntity> entityList)
        {
            foreach (EventoLoginEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, EventoLoginEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new EventoLoginEntity this[int index]
        {
            get { return (EventoLoginEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new EventoLoginEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                EventoLoginEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new EventoLoginEntity Find(string entityKeyString)
        {
            foreach (EventoLoginEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
