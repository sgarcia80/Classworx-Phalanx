using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class LoteChkWinLocalUsersEntityCollection : BaseEntityCollection
    {
        public int Add(LoteChkWinLocalUsersEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<LoteChkWinLocalUsersEntity> entityList)
        {
            foreach (LoteChkWinLocalUsersEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, LoteChkWinLocalUsersEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new LoteChkWinLocalUsersEntity this[int index]
        {
            get { return (LoteChkWinLocalUsersEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new LoteChkWinLocalUsersEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                LoteChkWinLocalUsersEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new LoteChkWinLocalUsersEntity Find(string entityKeyString)
        {
            foreach (LoteChkWinLocalUsersEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
