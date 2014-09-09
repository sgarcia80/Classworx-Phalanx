using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using NHibernate;
using PhalanxCommon.Entities;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class CommunicationDeviceTypesFactory
    {
        public CommunicationDeviceTypeEntityCollection GetAll()
        {
            CommunicationDeviceTypeEntityCollection CommDevTypeLst = new CommunicationDeviceTypeEntityCollection();
            
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceTypeEntity));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    IList<CommunicationDeviceTypeEntity> lstCDTypes = DataSearch.List<CommunicationDeviceTypeEntity>();

                    CommDevTypeLst.Add(lstCDTypes);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "DatabaseTypeFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "DatabaseTypeFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "DatabaseTypeFactory GetAll()"));
            }

            return CommDevTypeLst;
        }
    }
}
