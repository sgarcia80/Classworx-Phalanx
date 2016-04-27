using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class DominioLoginEntityCollection : BaseEntityCollection
    {
        public DominioLoginEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(DominioLoginEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<DominioLoginEntity> entityList)
        {
            foreach (DominioLoginEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, DominioLoginEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new DominioLoginEntity this[int index]
        {
            get { return (DominioLoginEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new DominioLoginEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                DominioLoginEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new DominioLoginEntity Find(string entityKeyString)
        {
            foreach (DominioLoginEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public new DominioLoginEntity FindByName(string nombre)
        {
            foreach (DominioLoginEntity entity in InnerList)
            {
                if (entity.Nombre.ToString().Trim().ToUpper() == nombre)
                    return entity;
            }
            return null;
        }
    }
}
