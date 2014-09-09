using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class ReporteDeUsoEntityCollection : BaseEntityCollection
    {
        public int Add(ReporteDeUsoEntity entity)
        {
            return base.Add(entity);
        }
        public int Add(PasswordRequestEntity entity)
        {
            ReporteDeUsoEntity newentity = new ReporteDeUsoEntity(entity);
            return base.Add(newentity);
        }
        public void Add(IList<ReporteDeUsoEntity> entityList)
        {
            foreach (ReporteDeUsoEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<ReporteDeUsoEntity> entityList)
        {
            foreach (ReporteDeUsoEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (ReporteDeUsoEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, ReporteDeUsoEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new ReporteDeUsoEntity this[int index]
        {
            get { return (ReporteDeUsoEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new ReporteDeUsoEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                ReporteDeUsoEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new ReporteDeUsoEntity Find(string entityKeyString)
        {
            foreach (ReporteDeUsoEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
