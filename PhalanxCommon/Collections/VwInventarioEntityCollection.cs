using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class VwInventarioEntityCollection : BaseEntityCollection
    {
        public int Add(VwInventarioEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<VwInventarioEntity> entityList)
        {
            foreach (VwInventarioEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<VwInventarioEntity> entityList)
        {
            foreach (VwInventarioEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (VwInventarioEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, VwInventarioEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new VwInventarioEntity this[int index]
        {
            get { return (VwInventarioEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new VwInventarioEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                VwInventarioEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new VwInventarioEntity Find(string entityKeyString)
        {
            foreach (VwInventarioEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
