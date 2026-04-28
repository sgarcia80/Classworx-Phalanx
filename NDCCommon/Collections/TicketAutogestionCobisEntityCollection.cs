using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class TicketAutogestionCobisEntityCollection : BaseEntityCollection
    {
        public TicketAutogestionCobisEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(TicketAutogestionCobisEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<TicketAutogestionCobisEntity> entityList)
        {
            foreach (TicketAutogestionCobisEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, TicketAutogestionCobisEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new TicketAutogestionCobisEntity this[int index]
        {
            get { return (TicketAutogestionCobisEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new TicketAutogestionCobisEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                TicketAutogestionCobisEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new TicketAutogestionCobisEntity Find(string entityKeyString)
        {
            foreach (TicketAutogestionCobisEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
