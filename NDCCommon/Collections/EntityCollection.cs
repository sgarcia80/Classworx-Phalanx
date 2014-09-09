using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Collections;

namespace NDCCommon.Collections
{
    public class EntityCollection<T> : BaseEntityCollection where T : BaseEntity
    {
        public int Add(T entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<T> entityList)
        {
            foreach (T Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (T Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, T myEntity)
        {
            base.Insert(index, myEntity);
        }
        
        public new T this[int index]
        {
            get { return (T)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new T this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                T entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new T Find(string entityKeyString)
        {
            foreach (T entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
