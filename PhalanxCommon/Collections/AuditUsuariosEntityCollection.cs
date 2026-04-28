using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AuditUsuariosEntityCollection : BaseEntityCollection
    {
        public int Add(AuditUsuariosEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditUsuariosEntity> entityList)
        {
            foreach (AuditUsuariosEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditUsuariosEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditUsuariosEntity this[int index]
        {
            get { return (AuditUsuariosEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditUsuariosEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditUsuariosEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditUsuariosEntity Find(string entityKeyString)
        {
            foreach (AuditUsuariosEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
