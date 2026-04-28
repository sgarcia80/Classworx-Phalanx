using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PasswordRequestEntityCollection : BaseEntityCollection
    {
        public int Add(PasswordRequestEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PasswordRequestEntity> entityList)
        {
            foreach (PasswordRequestEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PasswordRequestEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PasswordRequestEntity this[int index]
        {
            get { return (PasswordRequestEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PasswordRequestEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PasswordRequestEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PasswordRequestEntity Find(string entityKeyString)
        {
            foreach (PasswordRequestEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
