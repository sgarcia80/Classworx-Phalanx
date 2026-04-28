using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;

namespace PhalanxCommon.Collections
{
    public class CommunicationDeviceTypeEntityCollection : BaseEntityCollection
    {
        public int Add(CommunicationDeviceTypeEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<CommunicationDeviceTypeEntity> entityList)
        {
            foreach (CommunicationDeviceTypeEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, CommunicationDeviceTypeEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
    }
}
