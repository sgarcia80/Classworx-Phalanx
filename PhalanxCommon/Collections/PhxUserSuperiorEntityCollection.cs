using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class PhxUserSuperiorEntityCollection : BaseEntityCollection
    {
        public int Add(PhxUserSuperiorEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<PhxUserSuperiorEntity> entityList)
        {
            foreach (PhxUserSuperiorEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, PhxUserSuperiorEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new PhxUserSuperiorEntity this[int index]
        {
            get { return (PhxUserSuperiorEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new PhxUserSuperiorEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PhxUserSuperiorEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new PhxUserSuperiorEntity Find(string entityKeyString)
        {
            foreach (PhxUserSuperiorEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
