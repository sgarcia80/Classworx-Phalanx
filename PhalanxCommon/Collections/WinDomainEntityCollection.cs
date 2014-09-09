using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class WinDomainEntityCollection : BaseEntityCollection
    {
        public int Add(WinDomainEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<WinDomainEntity> entityList)
        {
            foreach (WinDomainEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, WinDomainEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new WinDomainEntity this[int index]
        {
            get { return (WinDomainEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new WinDomainEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                WinDomainEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new WinDomainEntity Find(string entityKeyString)
        {
            foreach (WinDomainEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
