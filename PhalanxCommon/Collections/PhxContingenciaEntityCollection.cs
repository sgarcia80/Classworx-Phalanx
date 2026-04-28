using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class PhxContingenciaEntityCollection : BaseEntityCollection
    {
        public int Add(PhxContingenciaEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxContingenciaEntity> entityList)
        {
            foreach (PhxContingenciaEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (PhxContingenciaEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxContingenciaEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxContingenciaEntity this[int index]
        {
            get { return (PhxContingenciaEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxContingenciaEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxContingenciaEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxContingenciaEntity Find(string entityKeyString)
        {
            foreach (PhxContingenciaEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
