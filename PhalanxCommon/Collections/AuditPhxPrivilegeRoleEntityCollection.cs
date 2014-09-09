using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AuditPhxPrivilegeRoleEntityCollection : BaseEntityCollection
    {
        public int Add(AuditPhxPrivilegeRoleEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditPhxPrivilegeRoleEntity> entityList)
        {
            foreach (AuditPhxPrivilegeRoleEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditPhxPrivilegeRoleEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditPhxPrivilegeRoleEntity this[int index]
        {
            get { return (AuditPhxPrivilegeRoleEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditPhxPrivilegeRoleEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditPhxPrivilegeRoleEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditPhxPrivilegeRoleEntity Find(string entityKeyString)
        {
            foreach (AuditPhxPrivilegeRoleEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
