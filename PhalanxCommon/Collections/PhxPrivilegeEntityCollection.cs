using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxPrivilegeEntityCollection : BaseEntityCollection
    {
        public int Add(PhxPrivilegeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxPrivilegeEntity> entityList)
        {
            foreach (PhxPrivilegeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxPrivilegeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxPrivilegeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxPrivilegeEntity this[int index]
        {
            get { return (PhxPrivilegeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxPrivilegeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxPrivilegeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxPrivilegeEntity Find(string entityKeyString)
        {
            foreach (PhxPrivilegeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
