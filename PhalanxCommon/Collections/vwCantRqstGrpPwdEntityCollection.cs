using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class vwCantRqstGrpPwdEntityCollection : BaseEntityCollection
    {
        public int Add(vwCantRqstGrpPwdEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<vwCantRqstGrpPwdEntity> entityList)
        {
            foreach (vwCantRqstGrpPwdEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        public void Add(IList entityList)
        {
            foreach (vwCantRqstGrpPwdEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, vwCantRqstGrpPwdEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new vwCantRqstGrpPwdEntity this[int index]
        {
            get { return (vwCantRqstGrpPwdEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new vwCantRqstGrpPwdEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                vwCantRqstGrpPwdEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new vwCantRqstGrpPwdEntity Find(string entityKeyString)
        {
            foreach (vwCantRqstGrpPwdEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
