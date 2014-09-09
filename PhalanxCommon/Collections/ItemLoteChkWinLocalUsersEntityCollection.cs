using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class ItemLoteChkWinLocalUsersEntityCollection : BaseEntityCollection
    {
        public int Add(ItemLoteChkWinLocalUsersEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<ItemLoteChkWinLocalUsersEntity> entityList)
        {
            foreach (ItemLoteChkWinLocalUsersEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, ItemLoteChkWinLocalUsersEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new ItemLoteChkWinLocalUsersEntity this[int index]
        {
            get { return (ItemLoteChkWinLocalUsersEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new ItemLoteChkWinLocalUsersEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                ItemLoteChkWinLocalUsersEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new ItemLoteChkWinLocalUsersEntity Find(string entityKeyString)
        {
            foreach (ItemLoteChkWinLocalUsersEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
