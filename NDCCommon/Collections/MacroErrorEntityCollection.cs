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
    public class MacroErrorEntityCollection : BaseEntityCollection
    {
        public MacroErrorEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(MacroErrorEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<MacroErrorEntity> entityList)
        {
            foreach (MacroErrorEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, MacroErrorEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new MacroErrorEntity this[int index]
        {
            get { return (MacroErrorEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new MacroErrorEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MacroErrorEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new MacroErrorEntity Find(string entityKeyString)
        {
            foreach (MacroErrorEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<MacroErrorEntity> ToList()
        {
            List<MacroErrorEntity> list = new List<MacroErrorEntity>();

            foreach (MacroErrorEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
