using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Common
{
    public abstract class BaseEntityCollection : CollectionBase //, IEnumerable
    {
        public BaseEntityCollection() { }

        #region Public Memebers
        /// <summary>
        /// Convierte el contenido de la coleccion en un array de objetos
        /// </summary>
        /// <returns>Array de objetos</returns>
        public object[] ToArray()
        {
            return InnerList.ToArray();
        }

        /// <summary>
        /// Permite llenar una coleccion en base a un array de objetos
        /// </summary>
        /// <param name="objList">Array de objetos que van a formar parte de la coleccion</param>
        public void FromArray(object[] objList)
        {
            foreach (object obj in objList)
            {
                InnerList.Add(obj); // no se dispara el evento OnInsert
                //				InnerList.Add(obj);
            }
        }
        public BaseEntity this[int index]
        {
            get { return (BaseEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        /// <summary>
        /// Indexer por entitykeyString.
        /// Lento. Evitar su uso.
        /// Hace: 
        /// para Get:
        ///		usa Find(entityKeyString)
        ///	para Set:
        ///		Buscar la entidad por entityKeyString.
        ///		Busca el index en base a la entidad.
        ///		Llama al indexer por index.
        public BaseEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                BaseEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        /// <summary>
        /// Realiza la busqueda comparando con el ToString del key de cada entidad
        /// <param name="entityKeyString"></param>
        /// <returns></returns>
        public BaseEntity Find(string entityKeyString)
        {
            foreach (BaseEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
        public virtual void Remove(BaseEntity entity)
        {
            InnerList.Remove(entity);
        }

        public virtual void Remove(string entityKeyString)
        {
            InnerList.Remove(Find(entityKeyString));
        }

        public virtual bool Contains(BaseEntity entity)
        {
            return InnerList.Contains(entity);
        }
        public virtual void Add(IList<BaseEntity> entityList)
        {
            foreach (BaseEntity Entity in entityList)
            {
                this.Add(Entity);
            }
        }

        #endregion
        #region Protected Members
        protected virtual int Add(BaseEntity entity)
        {
            return Insert(InnerList.Count, entity);
            //return List.Add(entity);
            //return InnerList.Add(entity);
        }
        protected virtual int AddAccepted(BaseEntity entity)
        {
            return Insert(InnerList.Count, entity);
        }
        protected virtual int Insert(int index, BaseEntity entity)
        {
            InnerList.Insert(index, entity);
            //List.Insert(index, entity);
            return index;
        }
        protected virtual void InsertAccepted(int index, BaseEntity entity)
        {
            Insert(index, entity);
        }

        #endregion



        /*
		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < InnerList.Count; i++)
			{
				yield return InnerList[i];
			}
		}

		#endregion*/
    }
}
