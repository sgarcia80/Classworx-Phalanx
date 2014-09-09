using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class DatabaseTypeEntityCollection : BaseEntityCollection
    {
        public int Add(DatabaseTypeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<DatabaseTypeEntity> entityList)
        {
            foreach (DatabaseTypeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, DatabaseTypeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new DatabaseTypeEntity this[int index]
        {
            get { return (DatabaseTypeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new DatabaseTypeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                DatabaseTypeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new DatabaseTypeEntity Find(string entityKeyString)
        {
            foreach (DatabaseTypeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
