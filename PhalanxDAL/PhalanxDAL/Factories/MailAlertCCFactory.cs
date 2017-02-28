using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class MailAlertCCCCFactory
    {
        public MailAlertCCEntityCollection GetAll()
        {
            MailAlertCCEntityCollection MailAlertCCLst = new MailAlertCCEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MailAlertCCEntity));
                    DataSearch = DataSearch.AddOrder(Order.Asc("Id"));
                    MailAlertCCLst.Add(DataSearch.List<MailAlertCCEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailAlertCCFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailAlertCCFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailAlertCCFactory GetAll()"));
            }
            return MailAlertCCLst;
        }
    }
}
