using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class FollowupRequestGroupDefaultEntityCollection : BaseEntityCollection
    {
        public int Add(FollowupRequestGroupDefaultEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<FollowupRequestGroupDefaultEntity> entityList)
        {
            foreach (FollowupRequestGroupDefaultEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, FollowupRequestGroupDefaultEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new FollowupRequestGroupDefaultEntity this[int index]
        {
            get { return (FollowupRequestGroupDefaultEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new FollowupRequestGroupDefaultEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                FollowupRequestGroupDefaultEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new FollowupRequestGroupDefaultEntity Find(string entityKeyString)
        {
            foreach (FollowupRequestGroupDefaultEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
