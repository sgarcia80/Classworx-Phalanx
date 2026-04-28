using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class VwPerfilUsuarioEntityCollection : BaseEntityCollection
    {
        public int Add(VwPerfilUsuarioEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<VwPerfilUsuarioEntity> entityList)
        {
            foreach (VwPerfilUsuarioEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<VwPerfilUsuarioEntity> entityList)
        {
            foreach (VwPerfilUsuarioEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (VwPerfilUsuarioEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, VwPerfilUsuarioEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new VwPerfilUsuarioEntity this[int index]
        {
            get { return (VwPerfilUsuarioEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new VwPerfilUsuarioEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                VwPerfilUsuarioEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new VwPerfilUsuarioEntity Find(string entityKeyString)
        {
            foreach (VwPerfilUsuarioEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
