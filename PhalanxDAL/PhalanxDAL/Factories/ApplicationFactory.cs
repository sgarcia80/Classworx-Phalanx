using System;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class ApplicationFactory
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        public ApplicationEntityCollection GetApplication(string AppName, int AppIdDistinta)
        {
            ApplicationEntityCollection WinDomLst = new ApplicationEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationEntity));
                    DataSearch = DataSearch.Add(Expression.Eq("Name", AppName));
                    if (AppIdDistinta > 0)
                    {
                        DataSearch = DataSearch.Add(Expression.Not(Expression.Eq("Id", AppIdDistinta)));
                    }

                    WinDomLst.Add(DataSearch.List<ApplicationEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ApplicationFactory GetApplication()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ApplicationFactory GetApplication()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ApplicationFactory GetApplication()"));
            }
            return WinDomLst;

        }
        public ApplicationEntityCollection GetAll()
        {
            ApplicationEntityCollection WinDomLst = new ApplicationEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(ApplicationEntity));
                    if (_filNombre != null && _filNombre != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre, MatchMode.Anywhere));
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));
                    WinDomLst.Add(DataSearch.List<ApplicationEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "ApplicationFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "ApplicationFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "ApplicationFactory GetAll()"));
            }
            return WinDomLst;

        }

        public int Save(ApplicationEntity Application)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Application);
                    tx.Commit();
                    return Application.Id;
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
    }
}
