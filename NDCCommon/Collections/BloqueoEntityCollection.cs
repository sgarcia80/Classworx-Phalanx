using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using Common;

namespace NDCCommon.Collections
{
    /// <summary>
    /// Summary description for BPMAplicacionEntityCollection
    /// </summary>
    public class BloqueoEntityCollection : BaseEntityCollection
    {
        public BloqueoEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(BloqueoEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<BloqueoEntity> entityList)
        {
            foreach (BloqueoEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, BloqueoEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new BloqueoEntity this[int index]
        {
            get { return (BloqueoEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new BloqueoEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                BloqueoEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new BloqueoEntity Find(string entityKeyString)
        {
            foreach (BloqueoEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<BloqueoEntity> ToList()
        {
            List<BloqueoEntity> list = new List<BloqueoEntity>();

            foreach (BloqueoEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
