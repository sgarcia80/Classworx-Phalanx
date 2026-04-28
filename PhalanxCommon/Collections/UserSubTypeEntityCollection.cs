using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class UserSubTypeEntityCollection : BaseEntityCollection
    {
        public int Add(UserSubTypeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<UserSubTypeEntity> entityList)
        {
            foreach (UserSubTypeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, UserSubTypeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new UserSubTypeEntity this[int index]
        {
            get { return (UserSubTypeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new UserSubTypeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                UserSubTypeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new UserSubTypeEntity Find(string entityKeyString)
        {
            foreach (UserSubTypeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
