using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AS400UserEntityCollection : BaseEntityCollection
    {
        public int Add(AS400UserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AS400UserEntity> entityList)
        {
            foreach (AS400UserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (AS400UserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AS400UserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AS400UserEntity this[int index]
        {
            get { return (AS400UserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AS400UserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AS400UserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AS400UserEntity Find(string entityKeyString)
        {
            foreach (AS400UserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        /// <summary>
        /// Devuelve la cantidad de Usuarios que tengan el estado indicado
        /// en el parámetro Activos
        /// </summary>
        /// <param name="Activos">Si es true devuelve la cantidad de usuarios
        /// Activos, si es false devuelve la cantidad de usuarios Inactivos</param>
        /// <returns>Cantidad de usuarios en el estado indicado</returns>
        public int CountEstado(bool Activos)
        {
            int Cant = 0;
            foreach (AS400UserEntity entity in InnerList)
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
