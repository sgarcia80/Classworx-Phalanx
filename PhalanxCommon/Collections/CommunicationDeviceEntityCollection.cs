using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class CommunicationDeviceEntityCollection : BaseEntityCollection
    {
        public int Add(CommunicationDeviceEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<CommunicationDeviceEntity> entityList)
        {
            foreach (CommunicationDeviceEntity Entity in entityList)
                this.Add(Entity);
        }
        
        public void Add(IList entityList)
        {
            foreach (CommunicationDeviceEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, CommunicationDeviceEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new CommunicationDeviceEntity this[int index]
        {
            get { return (CommunicationDeviceEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new CommunicationDeviceEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                CommunicationDeviceEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new CommunicationDeviceEntity Find(string entityKeyString)
        {
            foreach (CommunicationDeviceEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            
            return null;
        }
    }
}
