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
    public class MacroEntityCollection : BaseEntityCollection
    {
        public MacroEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(MacroEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<MacroEntity> entityList)
        {
            foreach (MacroEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, MacroEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new MacroEntity this[int index]
        {
            get { return (MacroEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new MacroEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MacroEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new MacroEntity Find(string entityKeyString)
        {
            foreach (MacroEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<MacroEntity> ToList()
        {
            List<MacroEntity> list = new List<MacroEntity>();

            foreach (MacroEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
