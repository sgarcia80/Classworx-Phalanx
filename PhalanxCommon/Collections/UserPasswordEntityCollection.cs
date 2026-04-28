using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class UserPasswordEntityCollection : BaseEntityCollection
    {
        public int Add(UserPasswordEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<UserPasswordEntity> entityList)
        {
            foreach (UserPasswordEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, UserPasswordEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new UserPasswordEntity this[int index]
        {
            get { return (UserPasswordEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new UserPasswordEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                UserPasswordEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new UserPasswordEntity Find(string entityKeyString)
        {
            foreach (UserPasswordEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
