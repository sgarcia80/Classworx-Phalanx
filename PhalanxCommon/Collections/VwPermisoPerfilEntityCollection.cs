using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class VwPermisoPerfilEntityCollection : BaseEntityCollection
    {
        public int Add(VwPermisoPerfilEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<VwPermisoPerfilEntity> entityList)
        {
            foreach (VwPermisoPerfilEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<VwPermisoPerfilEntity> entityList)
        {
            foreach (VwPermisoPerfilEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (VwPermisoPerfilEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, VwPermisoPerfilEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new VwPermisoPerfilEntity this[int index]
        {
            get { return (VwPermisoPerfilEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new VwPermisoPerfilEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                VwPermisoPerfilEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new VwPermisoPerfilEntity Find(string entityKeyString)
        {
            foreach (VwPermisoPerfilEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
