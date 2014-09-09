using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class AS400EntityCollection : BaseEntityCollection
    {
        public int Add(AS400Entity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AS400Entity> entityList)
        {
            foreach (AS400Entity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (AS400Entity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AS400Entity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AS400Entity this[int index]
        {
            get { return (AS400Entity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AS400Entity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AS400Entity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AS400Entity Find(string entityKeyString)
        {
            foreach (AS400Entity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
