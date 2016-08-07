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
    public class PalabraBlanqueoEntityCollection : BaseEntityCollection
    {
        public PalabraBlanqueoEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(PalabraBlanqueoEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<PalabraBlanqueoEntity> entityList)
        {
            foreach (PalabraBlanqueoEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, PalabraBlanqueoEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new PalabraBlanqueoEntity this[int index]
        {
            get { return (PalabraBlanqueoEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new PalabraBlanqueoEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                PalabraBlanqueoEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new PalabraBlanqueoEntity Find(string entityKeyString)
        {
            foreach (PalabraBlanqueoEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}