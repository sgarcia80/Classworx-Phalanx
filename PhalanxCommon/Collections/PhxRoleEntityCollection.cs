using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PhxRoleEntityCollection : BaseEntityCollection
    {
        public int Add(PhxRoleEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxRoleEntity> entityList)
        {
            foreach (PhxRoleEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxRoleEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxRoleEntity this[int index]
        {
            get { return (PhxRoleEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxRoleEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxRoleEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxRoleEntity Find(string entityKeyString)
        {
            foreach (PhxRoleEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
