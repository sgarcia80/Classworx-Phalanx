using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class BuildingEntityCollection : BaseEntityCollection
    {
        public int Add(BuildingEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<BuildingEntity> entityList)
        {
            foreach (BuildingEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (BuildingEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, BuildingEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new BuildingEntity this[int index]
        {
            get { return (BuildingEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new BuildingEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                BuildingEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new BuildingEntity Find(string entityKeyString)
        {
            foreach (BuildingEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
