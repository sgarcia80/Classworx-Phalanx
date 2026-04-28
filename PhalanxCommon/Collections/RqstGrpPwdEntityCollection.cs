using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class RqstGrpPwdEntityCollection : BaseEntityCollection
    {
        public int Add(RqstGrpPwdEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<RqstGrpPwdEntity> entityList)
        {
            foreach (RqstGrpPwdEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, RqstGrpPwdEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new RqstGrpPwdEntity this[int index]
        {
            get { return (RqstGrpPwdEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new RqstGrpPwdEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                RqstGrpPwdEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new RqstGrpPwdEntity Find(string entityKeyString)
        {
            foreach (RqstGrpPwdEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
