using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class ApplicationUserEntityCollection : BaseEntityCollection
    {
        public int Add(ApplicationUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<ApplicationUserEntity> entityList)
        {
            foreach (ApplicationUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<ApplicationUserEntity> entityList)
        {
            foreach (ApplicationUserEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (ApplicationUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, ApplicationUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new ApplicationUserEntity this[int index]
        {
            get { return (ApplicationUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new ApplicationUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                ApplicationUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new ApplicationUserEntity Find(string entityKeyString)
        {
            foreach (ApplicationUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public int CountEstado(bool Activos)
        {
            int Cant = 0;
            foreach (ApplicationUserEntity entity in InnerList)
            {
                if (entity.ActiveUser == Activos)
                {
                    Cant++;
                }
            }
            return Cant;
        }
    }
}

