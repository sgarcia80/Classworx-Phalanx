using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class DatabaseUserEntityCollection : BaseEntityCollection
    {
        public int Add(DatabaseUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<DatabaseUserEntity> entityList)
        {
            foreach (DatabaseUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (DatabaseUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, DatabaseUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new DatabaseUserEntity this[int index]
        {
            get { return (DatabaseUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new DatabaseUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                DatabaseUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new DatabaseUserEntity Find(string entityKeyString)
        {
            foreach (DatabaseUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public int CountEstado(bool Activos)
        {
            int Cant = 0;
            foreach (DatabaseUserEntity entity in InnerList)
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
