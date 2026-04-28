using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class vwCantFollowRqstGrpPwdFactory
    {
        public bool CheckOneAssociation = false;
        int? m_fil_FollowRqstGrpId;
        public int FilFollowRqstGrpId
        {
            set { m_fil_FollowRqstGrpId = value; }
        }

        public vwCantFollowRqstGrpPwdEntityCollection GetAll()
        {
            vwCantFollowRqstGrpPwdEntityCollection WinDomLst = new vwCantFollowRqstGrpPwdEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(vwCantFollowRqstGrpPwdEntity));
                    if (m_fil_FollowRqstGrpId != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("FollowRqstGrpId", m_fil_FollowRqstGrpId.Value));
                    }
                    if (CheckOneAssociation)
                    {
                        DataSearch.Add(Expression.Eq("CantPwdAssoc", 1));
                    }
                    WinDomLst.Add(DataSearch.List<vwCantFollowRqstGrpPwdEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "vwCantFollowRqstGrpPwdFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "vwCantFollowRqstGrpPwdFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "vwCantFollowRqstGrpPwdFactory GetAll()"));
            }
            return WinDomLst;
        }
        public int Save(vwCantFollowRqstGrpPwdEntity vwCantFollowRqstGrpPwd)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(vwCantFollowRqstGrpPwd);
                    tx.Commit();
                    return vwCantFollowRqstGrpPwd.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }


        public bool Delete(vwCantFollowRqstGrpPwdEntity vwCantFollowRqstGrpPwd)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(vwCantFollowRqstGrpPwd);
                    tx.Commit();
                    return true;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }
    }
}
