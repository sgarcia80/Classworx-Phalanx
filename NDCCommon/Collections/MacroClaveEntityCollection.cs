using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Entities;
using Common;

namespace NDCCommon.Collections
{
    /// <summary>
    /// Summary description for BPMAplicacionEntityCollection
    /// </summary>
    public class MacroClaveEntityCollection : BaseEntityCollection
    {
        public MacroClaveEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(MacroClaveEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<MacroClaveEntity> entityList)
        {
            foreach (MacroClaveEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, MacroClaveEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new MacroClaveEntity this[int index]
        {
            get { return (MacroClaveEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new MacroClaveEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MacroClaveEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new MacroClaveEntity Find(string entityKeyString)
        {
            foreach (MacroClaveEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<MacroClaveEntity> ToList()
        {
            List<MacroClaveEntity> list = new List<MacroClaveEntity>();

            foreach (MacroClaveEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
