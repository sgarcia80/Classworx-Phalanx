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
    public class MacroUsuarioTarjetaEntityCollection : BaseEntityCollection
    {
        public MacroUsuarioTarjetaEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(MacroUsuarioTarjetaEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<MacroUsuarioTarjetaEntity> entityList)
        {
            foreach (MacroUsuarioTarjetaEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, MacroUsuarioTarjetaEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new MacroUsuarioTarjetaEntity this[int index]
        {
            get { return (MacroUsuarioTarjetaEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new MacroUsuarioTarjetaEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                MacroUsuarioTarjetaEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new MacroUsuarioTarjetaEntity Find(string entityKeyString)
        {
            foreach (MacroUsuarioTarjetaEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<MacroUsuarioTarjetaEntity> ToList()
        {
            List<MacroUsuarioTarjetaEntity> list = new List<MacroUsuarioTarjetaEntity>();

            foreach (MacroUsuarioTarjetaEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
