using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class CommunicationDeviceProtocolEntityCollection : BaseEntityCollection
    {
        public int Add(CommunicationDeviceProtocolEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<CommunicationDeviceProtocolEntity> entityList)
        {
            foreach (CommunicationDeviceProtocolEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, CommunicationDeviceProtocolEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new CommunicationDeviceProtocolEntity this[int index]
        {
            get { return (CommunicationDeviceProtocolEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new CommunicationDeviceProtocolEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                CommunicationDeviceProtocolEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new CommunicationDeviceProtocolEntity Find(string entityKeyString)
        {
            foreach (CommunicationDeviceProtocolEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
