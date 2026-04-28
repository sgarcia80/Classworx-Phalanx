using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class WinDomainControllerEntityCollection : BaseEntityCollection
    {
        public int Add(WinDomainControllerEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<WinDomainControllerEntity> entityList)
        {
            foreach (WinDomainControllerEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (WinDomainControllerEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, WinDomainControllerEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new WinDomainControllerEntity this[int index]
        {
            get { return (WinDomainControllerEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new WinDomainControllerEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                WinDomainControllerEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new WinDomainControllerEntity Find(string entityKeyString)
        {
            foreach (WinDomainControllerEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
