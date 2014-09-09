using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class WinLocalUserEntityCollection : BaseEntityCollection
    {
        public int Add(WinLocalUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<WinLocalUserEntity> entityList)
        {
            foreach (WinLocalUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (WinLocalUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, WinLocalUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new WinLocalUserEntity this[int index]
        {
            get { return (WinLocalUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new WinLocalUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                WinLocalUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new WinLocalUserEntity Find(string entityKeyString)
        {
            foreach (WinLocalUserEntity entity in InnerList)
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
            foreach (WinLocalUserEntity entity in InnerList)
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
