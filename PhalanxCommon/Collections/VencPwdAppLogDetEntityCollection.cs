using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class VencPwdAppLogDetEntityCollection : BaseEntityCollection
    {
        public int Add(VencPwdAppLogDetEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<VencPwdAppLogDetEntity> entityList)
        {
            foreach (VencPwdAppLogDetEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, VencPwdAppLogDetEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new VencPwdAppLogDetEntity this[int index]
        {
            get { return (VencPwdAppLogDetEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new VencPwdAppLogDetEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                VencPwdAppLogDetEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new VencPwdAppLogDetEntity Find(string entityKeyString)
        {
            foreach (VencPwdAppLogDetEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
