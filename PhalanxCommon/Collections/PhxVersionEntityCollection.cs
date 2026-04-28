using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxVersionEntityCollection : BaseEntityCollection
    {
        public int Add(PhxVersionEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxVersionEntity> entityList)
        {
            foreach (PhxVersionEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxVersionEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxVersionEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxVersionEntity this[int index]
        {
            get { return (PhxVersionEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxVersionEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxVersionEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxVersionEntity Find(string entityKeyString)
        {
            foreach (PhxVersionEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
