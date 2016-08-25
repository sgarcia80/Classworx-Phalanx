using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Common;
using NDCCommon.Entities;

namespace NDCCommon.Collections
{
    /// <summary>
    /// Summary description for BPMAplicacionEntityCollection
    /// </summary>
    public class QuestionAnswerEntityCollection : BaseEntityCollection
    {
        public QuestionAnswerEntityCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Add(QuestionAnswerEntity entity)
        {
            return base.Add(entity);
        }

        public void Add(IList<QuestionAnswerEntity> entityList)
        {
            foreach (QuestionAnswerEntity Entity in entityList)
                this.Add(Entity);
        }

        public void Insert(int index, QuestionAnswerEntity myEntity)
        {
            base.Insert(index, myEntity);
        }

        public new QuestionAnswerEntity this[int index]
        {
            get { return (QuestionAnswerEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public new QuestionAnswerEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                QuestionAnswerEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }

        public new QuestionAnswerEntity Find(string entityKeyString)
        {
            foreach (QuestionAnswerEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}