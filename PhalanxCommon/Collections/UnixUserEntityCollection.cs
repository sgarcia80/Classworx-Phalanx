using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class UnixUserEntityCollection : BaseEntityCollection
    {
        public int Add(UnixUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<UnixUserEntity> entityList)
        {
            foreach (UnixUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (UnixUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, UnixUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new UnixUserEntity this[int index]
        {
            get { return (UnixUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new UnixUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                UnixUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new UnixUserEntity Find(string entityKeyString)
        {
            foreach (UnixUserEntity entity in InnerList)
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
            foreach (UnixUserEntity entity in InnerList)
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
