using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AuditLoginEntityCollection : BaseEntityCollection
    {
        public int Add(AuditLoginEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditLoginEntity> entityList)
        {
            foreach (AuditLoginEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditLoginEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditLoginEntity this[int index]
        {
            get { return (AuditLoginEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditLoginEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditLoginEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditLoginEntity Find(string entityKeyString)
        {
            foreach (AuditLoginEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
