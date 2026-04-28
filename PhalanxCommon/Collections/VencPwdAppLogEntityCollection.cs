using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class VencPwdAppLogEntityCollection : BaseEntityCollection
    {
        public int Add(VencPwdAppLogEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<VencPwdAppLogEntity> entityList)
        {
            foreach (VencPwdAppLogEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, VencPwdAppLogEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new VencPwdAppLogEntity this[int index]
        {
            get { return (VencPwdAppLogEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new VencPwdAppLogEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                VencPwdAppLogEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new VencPwdAppLogEntity Find(string entityKeyString)
        {
            foreach (VencPwdAppLogEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
