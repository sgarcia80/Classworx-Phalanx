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
    public class QuestionEntityCollection : BaseEntityCollection
    {
        public QuestionEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(QuestionEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<QuestionEntity> entityList)
        {
            foreach (QuestionEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, QuestionEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new QuestionEntity this[int index]
        {
            get { return (QuestionEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new QuestionEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                QuestionEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new QuestionEntity Find(string entityKeyString)
        {
            foreach (QuestionEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }

        public List<QuestionEntity> ToList()
        {
            List<QuestionEntity> list = new List<QuestionEntity>();

            foreach (QuestionEntity item in this)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
