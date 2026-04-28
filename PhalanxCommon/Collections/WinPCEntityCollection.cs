using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class WinPCEntityCollection : BaseEntityCollection
    {
        public int Add(WinPCEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<WinPCEntity> entityList)
        {
            foreach (WinPCEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (WinPCEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, WinPCEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new WinPCEntity this[int index]
        {
            get { return (WinPCEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new WinPCEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                WinPCEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new WinPCEntity Find(string entityKeyString)
        {
            foreach (WinPCEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
