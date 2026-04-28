using System.Collections.Generic;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NHibernate;
using PhalanxDAL;

namespace NDCDAL.Factories
{
    public class QuestionFactory
    {
        public QuestionEntityCollection GetAll()
        {
            IList<QuestionEntity> questions;

            QuestionEntityCollection questionEC = new QuestionEntityCollection();

            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(QuestionEntity));

                try
                {
                    questions = DataSearch.List<QuestionEntity>();
                    questionEC.Add(questions);
                }
                catch
                {
                }

            }

            return questionEC;
        }

        public QuestionEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                QuestionEntity entity = session.Get<QuestionEntity>(id);

                return entity;
            }
        }
    
    }
}