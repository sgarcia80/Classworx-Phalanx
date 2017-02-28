using NDCCommon.Collections;
using NDCDAL.Factories;
using NDCCommon.Entities;

namespace NDCBL
{
    public class QuestionBusiness
    {
        public QuestionEntityCollection GetAll()
        {
            QuestionFactory QFac = new QuestionFactory();

            return QFac.GetAll();
        }
        public QuestionEntity GetById(int id)
        {
            QuestionFactory factory = new QuestionFactory();

            return factory.GetById(id);
        }

    }
}
