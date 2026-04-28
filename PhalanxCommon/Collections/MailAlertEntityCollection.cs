using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class MailAlertEntityCollection : BaseEntityCollection
    {
        public int Add(MailAlertEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<MailAlertEntity> entityList)
        {
            foreach (MailAlertEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, MailAlertEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new MailAlertEntity this[int index]
        {
            get { return (MailAlertEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new MailAlertEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MailAlertEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new MailAlertEntity Find(string entityKeyString)
        {
            foreach (MailAlertEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
