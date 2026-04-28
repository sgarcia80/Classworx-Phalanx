using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class PhxVersionFactory
    {
        public PhxVersionEntityCollection GetAll()
        {
            PhxVersionEntityCollection WinDomLst = new PhxVersionEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxVersionEntity));
                    DataSearch.AddOrder(Order.Desc("FechaImplementacion"));
                    WinDomLst.Add(DataSearch.List<PhxVersionEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PhxVersionFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PhxVersionFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PhxVersionFactory GetAll()"));
            }
            return WinDomLst;

        }

    }
}
