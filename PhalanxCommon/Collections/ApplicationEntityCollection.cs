using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class ApplicationEntityCollection : BaseEntityCollection
    {
        public int Add(ApplicationEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<ApplicationEntity> entityList)
        {
            foreach (ApplicationEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, ApplicationEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new ApplicationEntity this[int index]
        {
            get { return (ApplicationEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new ApplicationEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                ApplicationEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new ApplicationEntity Find(string entityKeyString)
        {
            foreach (ApplicationEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
