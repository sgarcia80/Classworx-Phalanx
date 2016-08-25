using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    public class QuestionBusiness
    {
        public QuestionEntityCollection GetAll()
        {
            QuestionFactory QFac = new QuestionFactory();

            return QFac.GetAll();
        }
    }
}
