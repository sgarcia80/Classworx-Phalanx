using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxPrivilegeRoleEntityCollection : BaseEntityCollection
    {
        public int Add(PhxPrivilegeRoleEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxPrivilegeRoleEntity> entityList)
        {
            foreach (PhxPrivilegeRoleEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxPrivilegeRoleEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxPrivilegeRoleEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxPrivilegeRoleEntity this[int index]
        {
            get { return (PhxPrivilegeRoleEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxPrivilegeRoleEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxPrivilegeRoleEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxPrivilegeRoleEntity Find(string entityKeyString)
        {
            foreach (PhxPrivilegeRoleEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public new PhxPrivilegeRoleEntity FindPrivilegio(string entityPrivKeyString)
        {
            foreach (PhxPrivilegeRoleEntity entity in InnerList)
            {
                if (entity.Privilege.Key.ToString() == entityPrivKeyString)
                    return entity;
            }
            return null;
        }
    }
}
