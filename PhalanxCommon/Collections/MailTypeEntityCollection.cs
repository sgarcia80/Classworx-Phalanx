using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class MailTypeEntityCollection : BaseEntityCollection
    {
        public int Add(MailTypeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<MailTypeEntity> entityList)
        {
            foreach (MailTypeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, MailTypeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new MailTypeEntity this[int index]
        {
            get { return (MailTypeEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new MailTypeEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MailTypeEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new MailTypeEntity Find(string entityKeyString)
        {
            foreach (MailTypeEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
