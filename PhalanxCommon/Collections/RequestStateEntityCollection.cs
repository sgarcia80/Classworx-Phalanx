using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class RequestStateEntityCollection : BaseEntityCollection
    {
        public int Add(RequestStateEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<RequestStateEntity> entityList)
        {
            foreach (RequestStateEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, RequestStateEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new RequestStateEntity this[int index]
        {
            get { return (RequestStateEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new RequestStateEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                RequestStateEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new RequestStateEntity Find(string entityKeyString)
        {
            foreach (RequestStateEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
