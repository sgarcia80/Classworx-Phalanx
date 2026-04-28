using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class UserTypeEntityCollection : BaseEntityCollection
    {
        public int Add(UserTypeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<UserTypeEntity> entityList)
        {
            foreach (UserTypeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, UserTypeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new UserTypeEntity this[int index]
        {
            get { return (UserTypeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new UserTypeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                UserTypeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new UserTypeEntity Find(string entityKeyString)
        {
            foreach (UserTypeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
