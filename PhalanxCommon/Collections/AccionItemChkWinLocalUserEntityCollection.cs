using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class AccionItemChkWinLocalUserEntityCollection : BaseEntityCollection
    {
        public int Add(AccionItemChkWinLocalUserEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AccionItemChkWinLocalUserEntity> entityList)
        {
            foreach (AccionItemChkWinLocalUserEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AccionItemChkWinLocalUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public AccionItemChkWinLocalUserEntity this[int index]
        {
            get { return (AccionItemChkWinLocalUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public AccionItemChkWinLocalUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AccionItemChkWinLocalUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AccionItemChkWinLocalUserEntity Find(string entityKeyString)
        {
            foreach (AccionItemChkWinLocalUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

    }
}
