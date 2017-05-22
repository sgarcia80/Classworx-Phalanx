using System;
using NDCCommon.Collections;
using NHibernate;
using NDCCommon.Entities;
using Common;
using PhalanxDAL;
using NHibernate.Criterion;

namespace NDCDAL.Factories
{
    public class QuestionAnswerFactory
    {

        public string FilUser { set; get; }

        public QuestionAnswerEntityCollection GetAll()
        {
            QuestionAnswerEntityCollection Lst = new QuestionAnswerEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(QuestionAnswerEntity));

                    if (!string.IsNullOrEmpty(FilUser))
                        DataSearch = DataSearch.Add(Restrictions.Like("Username", FilUser, MatchMode.Anywhere));

                    DataSearch = DataSearch.AddOrder(Order.Asc("Username"));

                    var result = DataSearch.List<QuestionAnswerEntity>();

                    if (result != null)
                    {
                        Lst.Add(result);
                    }
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "QuestionAnswerFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "QuestionAnswerFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "QuestionAnswerFactory GetAll()"));
            }
            return Lst;
        }

        public QuestionAnswerEntity GetById(int id)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                QuestionAnswerEntity entity = session.Get<QuestionAnswerEntity>(id);

                return entity;
            }
        }

        public void Save(QuestionAnswerEntityCollection collection)
        {
            ITransaction tx = null;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();

                    foreach (QuestionAnswerEntity entity in collection)
                    {
                        session.SaveOrUpdate(entity);
                    }
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();

                    throw e;
                }
            }
        }

        public void Save(QuestionAnswerEntity entidad)
        {
            ITransaction tx = null;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Save(entidad);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    if (tx != null)
                        tx.Rollback();

                    throw e;
                }
            }
        }

        public bool Delete(QuestionAnswerEntity QuestionAnswer)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(QuestionAnswer);
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }
    }
}
