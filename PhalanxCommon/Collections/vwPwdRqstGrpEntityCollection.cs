using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class vwPwdRqstGrpEntityCollection : BaseEntityCollection
    {
        public int Add(vwPwdRqstGrpEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<vwPwdRqstGrpEntity> entityList)
        {
            foreach (vwPwdRqstGrpEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }
        /// <summary>
        /// Agrega siempre y cuando ya no exista previamente. Esto se verifica a través del key de la entidad
        /// </summary>
        /// <param name="entityList"></param>
        public void AddUnique(IList<vwPwdRqstGrpEntity> entityList)
        {
            foreach (vwPwdRqstGrpEntity Entity in entityList)
            {
                if (base.Find(Entity.Key) == null)
                {
                    this.Add(Entity);
                }
            }
        }
        public void Add(IList entityList)
        {
            foreach (vwPwdRqstGrpEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, vwPwdRqstGrpEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new vwPwdRqstGrpEntity this[int index]
        {
            get { return (vwPwdRqstGrpEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new vwPwdRqstGrpEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                vwPwdRqstGrpEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new vwPwdRqstGrpEntity Find(string entityKeyString)
        {
            foreach (vwPwdRqstGrpEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
