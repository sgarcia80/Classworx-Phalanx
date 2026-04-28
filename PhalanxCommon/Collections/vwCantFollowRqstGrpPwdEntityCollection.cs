using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class vwCantFollowRqstGrpPwdEntityCollection : BaseEntityCollection
    {
        public int Add(vwCantFollowRqstGrpPwdEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<vwCantFollowRqstGrpPwdEntity> entityList)
        {
            foreach (vwCantFollowRqstGrpPwdEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (vwCantFollowRqstGrpPwdEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, vwCantFollowRqstGrpPwdEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new vwCantFollowRqstGrpPwdEntity this[int index]
        {
            get { return (vwCantFollowRqstGrpPwdEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new vwCantFollowRqstGrpPwdEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                vwCantFollowRqstGrpPwdEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new vwCantFollowRqstGrpPwdEntity Find(string entityKeyString)
        {
            foreach (vwCantFollowRqstGrpPwdEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
