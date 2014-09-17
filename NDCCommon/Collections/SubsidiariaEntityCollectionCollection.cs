using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    /// <summary>
    /// Summary description for BPMAplicacionEntityCollection
    /// </summary>
    public class SubsidiariaEntityCollection : BaseEntityCollection
    {
        public SubsidiariaEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(SubsidiariaEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<SubsidiariaEntity> entityList)
        {
            foreach (SubsidiariaEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, SubsidiariaEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new SubsidiariaEntity this[int index]
        {
            get { return (SubsidiariaEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new SubsidiariaEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                SubsidiariaEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new SubsidiariaEntity Find(string entityKeyString)
        {
            foreach (SubsidiariaEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}