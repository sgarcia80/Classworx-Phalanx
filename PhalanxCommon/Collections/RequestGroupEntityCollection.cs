using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class RequestGroupEntityCollection : BaseEntityCollection
    {
        public int Add(RequestGroupEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<RequestGroupEntity> entityList)
        {
            foreach (RequestGroupEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, RequestGroupEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new RequestGroupEntity this[int index]
        {
            get { return (RequestGroupEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new RequestGroupEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                RequestGroupEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new RequestGroupEntity Find(string entityKeyString)
        {
            foreach (RequestGroupEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
