using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PhxRoleUserEntityCollection : BaseEntityCollection
    {
        public int Add(PhxRoleUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxRoleUserEntity> entityList)
        {
            foreach (PhxRoleUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxRoleUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxRoleUserEntity this[int index]
        {
            get { return (PhxRoleUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxRoleUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxRoleUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxRoleUserEntity Find(string entityKeyString)
        {
            foreach (PhxRoleUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
