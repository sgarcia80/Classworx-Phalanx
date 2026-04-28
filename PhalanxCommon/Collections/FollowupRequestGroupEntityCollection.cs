using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class FollowupRequestGroupEntityCollection : BaseEntityCollection
    {
        public int Add(FollowupRequestGroupEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<FollowupRequestGroupEntity> entityList)
        {
            foreach (FollowupRequestGroupEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, FollowupRequestGroupEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new FollowupRequestGroupEntity this[int index]
        {
            get { return (FollowupRequestGroupEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new FollowupRequestGroupEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                FollowupRequestGroupEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new FollowupRequestGroupEntity Find(string entityKeyString)
        {
            foreach (FollowupRequestGroupEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
