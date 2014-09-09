using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class vwCantRqstGrpPwdFactory
    {
        public bool CheckOneAssociation = false;
        int? m_fil_RqstGrpId;
        public int FilRqstGrpId
        {
            set { m_fil_RqstGrpId = value; }
        }

        public vwCantRqstGrpPwdEntityCollection GetAll()
        {
            vwCantRqstGrpPwdEntityCollection WinDomLst = new vwCantRqstGrpPwdEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(vwCantRqstGrpPwdEntity));
                    if (m_fil_RqstGrpId != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("RqstGrpId", m_fil_RqstGrpId.Value));
                    }
                    if (CheckOneAssociation)
                    {
                        DataSearch.Add(Expression.Eq("CantPwdAssoc", 1));
                    }
                    WinDomLst.Add(DataSearch.List<vwCantRqstGrpPwdEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "vwCantRqstGrpPwdFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "vwCantRqstGrpPwdFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "vwCantRqstGrpPwdFactory GetAll()"));
            }
            return WinDomLst;
        }
        public int Save(vwCantRqstGrpPwdEntity vwCantRqstGrpPwd)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(vwCantRqstGrpPwd);
                    tx.Commit();
                    return vwCantRqstGrpPwd.Id;
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


        public bool Delete(vwCantRqstGrpPwdEntity vwCantRqstGrpPwd)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(vwCantRqstGrpPwd);
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
