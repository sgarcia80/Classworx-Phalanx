using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PhxUserGroupEntityCollection : BaseEntityCollection
    {
        public int Add(PhxUserGroupEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxUserGroupEntity> entityList)
        {
            foreach (PhxUserGroupEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxUserGroupEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxUserGroupEntity this[int index]
        {
            get { return (PhxUserGroupEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxUserGroupEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxUserGroupEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxUserGroupEntity Find(string entityKeyString)
        {
            foreach (PhxUserGroupEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
