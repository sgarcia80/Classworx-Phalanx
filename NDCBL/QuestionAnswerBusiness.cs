using System;
using System.Data;
using System.Configuration;
using NDCCommon.Entities;
using NDCDAL.Factories;
using NDCCommon.Collections;

namespace NDCBL
{
    /// <summary>
    /// Summary description for ApplicationBusiness
    /// </summary>
    public class QuestionAnswerBusiness
    {
        public QuestionAnswerBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string FilUser { set; get; }

        public QuestionAnswerEntity GetById(int id)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            return factory.GetById(id);
        }

        public QuestionAnswerEntityCollection GetAll()
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            factory.FilUser = FilUser;

            return factory.GetAll();
        }

        public void Save(QuestionAnswerEntity entidad)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            factory.Save(entidad);
        }

        public void Create(QuestionAnswerEntity entidad)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            factory.Save(entidad);
        }

        public void Update(QuestionAnswerEntity entidad)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            factory.Save(entidad);
        }

        public bool Delete(QuestionAnswerEntity QuestionAnswer)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();

            return factory.Delete(QuestionAnswer);
        }
    }
}