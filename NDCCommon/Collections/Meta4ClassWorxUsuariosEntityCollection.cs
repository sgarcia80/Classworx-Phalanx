using System;
using System.Collections.Generic;
using System.Text;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    public class Meta4ClassWorxUsuariosEntityCollection : BaseEntityCollection
    {
        public Meta4ClassWorxUsuariosEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(Meta4ClassWorxUsuariosEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList<Meta4ClassWorxUsuariosEntity> entityList)
        {
            foreach (Meta4ClassWorxUsuariosEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        public void Insert(int index, Meta4ClassWorxUsuariosEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new Meta4ClassWorxUsuariosEntity this[int index]
        {
            get { return (Meta4ClassWorxUsuariosEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new Meta4ClassWorxUsuariosEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                Meta4ClassWorxUsuariosEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new Meta4ClassWorxUsuariosEntity Find(string entityKeyString)
        {
            foreach (Meta4ClassWorxUsuariosEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
