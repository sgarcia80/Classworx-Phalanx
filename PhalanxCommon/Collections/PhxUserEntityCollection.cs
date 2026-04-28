using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PhxUserEntityCollection : BaseEntityCollection
    {
        public int Add(PhxUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxUserEntity> entityList)
        {
            foreach (PhxUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxUserEntity this[int index]
        {
            get { return (PhxUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxUserEntity Find(string entityKeyString)
        {
            foreach (PhxUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
