using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class HistPasswordChangeEntityCollection : BaseEntityCollection
    {
        public int Add(HistPasswordChangeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<HistPasswordChangeEntity> entityList)
        {
            foreach (HistPasswordChangeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, HistPasswordChangeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new HistPasswordChangeEntity this[int index]
        {
            get { return (HistPasswordChangeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new HistPasswordChangeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                HistPasswordChangeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new HistPasswordChangeEntity Find(string entityKeyString)
        {
            foreach (HistPasswordChangeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
