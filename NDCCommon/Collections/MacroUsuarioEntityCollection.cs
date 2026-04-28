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
    public class MacroUsuarioEntityCollection : BaseEntityCollection
    {
        public MacroUsuarioEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(MacroUsuarioEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<MacroUsuarioEntity> entityList)
        {
            foreach (MacroUsuarioEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, MacroUsuarioEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new MacroUsuarioEntity this[int index]
        {
            get { return (MacroUsuarioEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new MacroUsuarioEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MacroUsuarioEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new MacroUsuarioEntity Find(string entityKeyString)
        {
            foreach (MacroUsuarioEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<MacroUsuarioEntity> ToList()
        {
            List<MacroUsuarioEntity> list = new List<MacroUsuarioEntity>();

            foreach (MacroUsuarioEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
