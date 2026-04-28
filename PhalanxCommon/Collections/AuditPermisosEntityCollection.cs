using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AuditPermisosEntityCollection : BaseEntityCollection
    {
        public int Add(AuditPermisosEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditPermisosEntity> entityList)
        {
            foreach (AuditPermisosEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditPermisosEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditPermisosEntity this[int index]
        {
            get { return (AuditPermisosEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditPermisosEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditPermisosEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditPermisosEntity Find(string entityKeyString)
        {
            foreach (AuditPermisosEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
