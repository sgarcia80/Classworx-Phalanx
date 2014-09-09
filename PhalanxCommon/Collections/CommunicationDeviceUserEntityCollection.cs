using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class CommunicationDeviceUserEntityCollection : BaseEntityCollection
    {
        public int Add(CommunicationDeviceUserEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<CommunicationDeviceUserEntity> entityList)
        {
            foreach (CommunicationDeviceUserEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Add(IList entityList)
        {
            foreach (CommunicationDeviceUserEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, CommunicationDeviceUserEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new CommunicationDeviceUserEntity this[int index]
        {
            get { return (CommunicationDeviceUserEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new CommunicationDeviceUserEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                CommunicationDeviceUserEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new CommunicationDeviceUserEntity Find(string entityKeyString)
        {
            foreach (CommunicationDeviceUserEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }

            return null;
        }

        public int CountEstado(bool Activos)
        {
            int Cant = 0;
            
            foreach (CommunicationDeviceUserEntity entity in InnerList)
            {
                if (entity.ActiveUser == Activos)
                    Cant++;
            }

            return Cant;
        }
    }
}
