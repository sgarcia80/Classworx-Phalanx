using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class FollowupRequestGroupPasswordEntityCollection : BaseEntityCollection
    {
        public int Add(FollowupRequestGroupPasswordEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<FollowupRequestGroupPasswordEntity> entityList)
        {
            foreach (FollowupRequestGroupPasswordEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, FollowupRequestGroupPasswordEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new FollowupRequestGroupPasswordEntity this[int index]
        {
            get { return (FollowupRequestGroupPasswordEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new FollowupRequestGroupPasswordEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                FollowupRequestGroupPasswordEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new FollowupRequestGroupPasswordEntity Find(string entityKeyString)
        {
            foreach (FollowupRequestGroupPasswordEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
