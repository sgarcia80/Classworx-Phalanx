using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class vwHistPwdVisEntityCollection : BaseEntityCollection
    {
        public int Add(vwHistPwdVisEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<vwHistPwdVisEntity> entityList)
        {
            foreach (vwHistPwdVisEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<vwHistPwdVisEntity> entityList)
        {
            foreach (vwHistPwdVisEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (vwHistPwdVisEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, vwHistPwdVisEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new vwHistPwdVisEntity this[int index]
        {
            get { return (vwHistPwdVisEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new vwHistPwdVisEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                vwHistPwdVisEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new vwHistPwdVisEntity Find(string entityKeyString)
        {
            foreach (vwHistPwdVisEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
