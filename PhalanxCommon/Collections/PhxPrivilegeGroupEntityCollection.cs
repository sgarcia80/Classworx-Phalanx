using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxPrivilegeGroupEntityCollection : BaseEntityCollection
    {
        public int Add(PhxPrivilegeGroupEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxPrivilegeGroupEntity> entityList)
        {
            foreach (PhxPrivilegeGroupEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxPrivilegeGroupEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxPrivilegeGroupEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxPrivilegeGroupEntity this[int index]
        {
            get { return (PhxPrivilegeGroupEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxPrivilegeGroupEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxPrivilegeGroupEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxPrivilegeGroupEntity Find(string entityKeyString)
        {
            foreach (PhxPrivilegeGroupEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
