using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class MailAlertCCEntityCollection : BaseEntityCollection
    {
        public int Add(MailAlertCCEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<MailAlertCCEntity> entityList)
        {
            foreach (MailAlertCCEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, MailAlertCCEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new MailAlertCCEntity this[int index]
        {
            get { return (MailAlertCCEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new MailAlertCCEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MailAlertCCEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new MailAlertCCEntity Find(string entityKeyString)
        {
            foreach (MailAlertCCEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
