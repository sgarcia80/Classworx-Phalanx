using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Cfg;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class MailAlertFactory
    {
        private MailTypeEntity _filMailType;
        private Nullable<bool> _filSentMail; // indica si se filtra por mails enviados o no enviados
        public MailTypeEntity FilMailType
        {
            set { _filMailType = value; }
        }
        public Nullable<bool> FilSentMail
        {
            set
            {
                _filSentMail = value;
            }
        }

        public MailAlertFactory()
        {
        }
        public int Save(MailAlertEntity MailAlert)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    MailAlert.CreationDate = new GetDateFactory().GetDate().GetDate;
                    tx = session.BeginTransaction();
                    session.Save(MailAlert);
                    tx.Commit();
                    return MailAlert.Id;
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
        public void SentMail(MailAlertEntity SentMail, bool SetAsSent)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    if (SetAsSent)
                    {
                        // si fue enviado se setea la fecha
                        SentMail.SendDate = new GetDateFactory().GetDate().GetDate;
                    }
                    // incrementa el intento de envío
                    SentMail.SendAttemp++;
                    tx = session.BeginTransaction();
                    session.Update(SentMail);
                    tx.Commit();
                    //return SentMail.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    //return 0;
                    // handle exception
                }
            }
        }
        public MailAlertEntityCollection GetMailsToSend()
        {
            MailAlertEntityCollection MailAlertLst = new MailAlertEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MailAlertEntity));

                    DataSearch = DataSearch.Add(Expression.IsNull("SendDate"));
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("CreationDate"));

                    MailAlertLst.Add(DataSearch.List<MailAlertEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailAlertFactory GetMailsToSend()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailAlertFactory GetMailsToSend()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailAlertFactory GetMailsToSend()"));
            }
            return MailAlertLst;
        }
        public MailAlertEntity GetMailToSend(int Id)
        {
            MailAlertEntityCollection MailAlertLst = new MailAlertEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MailAlertEntity));

                    DataSearch = DataSearch.Add(Expression.Eq("Id", Id));

                    MailAlertLst.Add(DataSearch.List<MailAlertEntity>());
                    if (MailAlertLst.Count > 0)
                    {
                        return MailAlertLst[0];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailAlertFactory GetMailToSend()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailAlertFactory GetMailToSend()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailAlertFactory GetMailToSend()"));
            }
            return null;
        }
        public MailAlertEntityCollection GetAll()
        {
            MailAlertEntityCollection MailAlertLst = new MailAlertEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MailAlertEntity));
                    if (_filSentMail != null)
                    {
                        if (_filSentMail.Value == true)
                        {
                            DataSearch = DataSearch.Add(Expression.IsNotNull("SendDate"));
                        }
                        else
                        {
                            DataSearch = DataSearch.Add(Expression.IsNull("SendDate"));
                        }
                    }
                    if (_filMailType != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("MailType", _filMailType));
                    }
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("CreationDate"));

                    MailAlertLst.Add(DataSearch.List<MailAlertEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailAlertFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailAlertFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailAlertFactory GetAll()"));
            }
            return MailAlertLst;
        }
    }
}
