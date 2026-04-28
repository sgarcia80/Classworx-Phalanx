using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxConfigEntityCollection : BaseEntityCollection
    {
        public int Add(PhxConfigEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxConfigEntity> entityList)
        {
            foreach (PhxConfigEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxConfigEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxConfigEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxConfigEntity this[int index]
        {
            get { return (PhxConfigEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxConfigEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxConfigEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxConfigEntity Find(string entityKeyString)
        {
            foreach (PhxConfigEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
