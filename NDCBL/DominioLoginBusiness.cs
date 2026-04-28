using NDCCommon.Collections;
using NDCDAL.Factories;

namespace NDCBL
{
    public class DominioLoginBusiness
    {
        public DominioLoginEntityCollection GetAllParaCombo()
        {
            return new DominioLoginFactory().GetAllFromConfig();
        }

    }
}
