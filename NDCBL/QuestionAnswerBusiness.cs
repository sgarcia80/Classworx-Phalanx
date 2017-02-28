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

            phxCryptMgr.CCryptMgr encriptacion = new phxCryptMgr.CCryptMgr(); 
            QuestionAnswerEntityCollection collection = factory.GetAll();

            //Se desencriptan todas las respuestas.
            foreach (QuestionAnswerEntity question in collection)
            {
                question.Respuesta = encriptacion.decrypt(question.Respuesta);
                question.Respuesta = question.Respuesta.Replace("\0", string.Empty).Trim();
            }

            return collection;
        }

        public void Save(QuestionAnswerEntityCollection collection)
        {
            QuestionAnswerFactory factory = new QuestionAnswerFactory();
            
            phxCryptMgr.CCryptMgr encriptacion = new phxCryptMgr.CCryptMgr();

            //Se encriptan todas las respuestas.
            foreach(QuestionAnswerEntity question in collection)
            {
                question.Respuesta = encriptacion.encrypt(question.Respuesta);
            }

            factory.Save(collection);
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