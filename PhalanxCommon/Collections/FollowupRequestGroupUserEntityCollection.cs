using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class FollowupRequestGroupUserEntityCollection : BaseEntityCollection
    {
        public int Add(FollowupRequestGroupUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<FollowupRequestGroupUserEntity> entityList)
        {
            foreach (FollowupRequestGroupUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, FollowupRequestGroupUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new FollowupRequestGroupUserEntity this[int index]
        {
            get { return (FollowupRequestGroupUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new FollowupRequestGroupUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                FollowupRequestGroupUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new FollowupRequestGroupUserEntity Find(string entityKeyString)
        {
            foreach (FollowupRequestGroupUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
