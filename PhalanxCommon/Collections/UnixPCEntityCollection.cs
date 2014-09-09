using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class UnixPCEntityCollection : BaseEntityCollection
    {
        public int Add(UnixEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<UnixEntity> entityList)
        {
            foreach (UnixEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (UnixEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, UnixEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new UnixEntity this[int index]
        {
            get { return (UnixEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new UnixEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                UnixEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new UnixEntity Find(string entityKeyString)
        {
            foreach (UnixEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
