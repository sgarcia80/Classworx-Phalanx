using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class ATMUserEntityCollection : BaseEntityCollection
    {
        public int Add(ATMUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<ATMUserEntity> entityList)
        {
            foreach (ATMUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<ATMUserEntity> entityList)
        {
            foreach (ATMUserEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (ATMUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, ATMUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new ATMUserEntity this[int index]
        {
            get { return (ATMUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new ATMUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                ATMUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new ATMUserEntity Find(string entityKeyString)
        {
            foreach (ATMUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public int CountEstado(bool Activos)
        {
            int Cant = 0;
            foreach (ATMUserEntity entity in InnerList)
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

