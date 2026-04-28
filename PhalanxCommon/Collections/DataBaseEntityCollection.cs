using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class DataBaseEntityCollection : BaseEntityCollection
    {
        public int Add(DataBaseEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<DataBaseEntity> entityList)
        {
            foreach (DataBaseEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (DataBaseEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, DataBaseEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new DataBaseEntity this[int index]
        {
            get { return (DataBaseEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new DataBaseEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                DataBaseEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new DataBaseEntity Find(string entityKeyString)
        {
            foreach (DataBaseEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
