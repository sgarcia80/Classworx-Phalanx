using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AuditPhxRoleEntityCollection : BaseEntityCollection
    {
        public int Add(AuditPhxRoleEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditPhxRoleEntity> entityList)
        {
            foreach (AuditPhxRoleEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditPhxRoleEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditPhxRoleEntity this[int index]
        {
            get { return (AuditPhxRoleEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditPhxRoleEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditPhxRoleEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditPhxRoleEntity Find(string entityKeyString)
        {
            foreach (AuditPhxRoleEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
