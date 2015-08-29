using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class AuditTicketNotificacionEntityCollection : BaseEntityCollection
    {
        public AuditTicketNotificacionEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(AuditTicketNotificacionEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AuditTicketNotificacionEntity> entityList)
        {
            foreach (AuditTicketNotificacionEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AuditTicketNotificacionEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AuditTicketNotificacionEntity this[int index]
        {
            get { return (AuditTicketNotificacionEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AuditTicketNotificacionEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AuditTicketNotificacionEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AuditTicketNotificacionEntity Find(string entityKeyString)
        {
            foreach (AuditTicketNotificacionEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
