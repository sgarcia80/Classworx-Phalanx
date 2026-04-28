using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    /// <summary>
    /// Summary description for BPMAplicacionEntityCollection
    /// </summary>
    public class AplicacionNotificacionClaveEntityCollection : BaseEntityCollection
    {
        public AplicacionNotificacionClaveEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(AplicacionNotificacionClaveEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<AplicacionNotificacionClaveEntity> entityList)
        {
            foreach (AplicacionNotificacionClaveEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, AplicacionNotificacionClaveEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new AplicacionNotificacionClaveEntity this[int index]
        {
            get { return (AplicacionNotificacionClaveEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new AplicacionNotificacionClaveEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                AplicacionNotificacionClaveEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new AplicacionNotificacionClaveEntity Find(string entityKeyString)
        {
            foreach (AplicacionNotificacionClaveEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public new AplicacionNotificacionClaveEntity FindByCodigo(string codigo)
        {
            foreach (AplicacionNotificacionClaveEntity entity in InnerList)
            {
                if (entity.Codigo.ToString() == codigo)
                    return entity;
            }
            return null;
        }
    }
}