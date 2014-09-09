using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class vwHistPwdChgEntityCollection : BaseEntityCollection
    {
        public int Add(vwHistPwdChgEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<vwHistPwdChgEntity> entityList)
        {
            foreach (vwHistPwdChgEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<vwHistPwdChgEntity> entityList)
        {
            foreach (vwHistPwdChgEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (vwHistPwdChgEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, vwHistPwdChgEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new vwHistPwdChgEntity this[int index]
        {
            get { return (vwHistPwdChgEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new vwHistPwdChgEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                vwHistPwdChgEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new vwHistPwdChgEntity Find(string entityKeyString)
        {
            foreach (vwHistPwdChgEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
