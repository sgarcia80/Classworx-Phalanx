using System;
using NHibernate;
using PhalanxCommon.Entities;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class AccionItemChkWinLocalUserFactory
    {
        public AccionItemChkWinLocalUserEntity Load(int Id)
        {
            AccionItemChkWinLocalUserEntity AccionItemChkWinLocalUser = new AccionItemChkWinLocalUserEntity();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    AccionItemChkWinLocalUser = session.Load<AccionItemChkWinLocalUserEntity>(Id);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "AccionItemChkWinLocalUserFactory Load()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "AccionItemChkWinLocalUserFactory Load()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "AccionItemChkWinLocalUserFactory Load()"));
            }
            return AccionItemChkWinLocalUser;

        }
    }
}
