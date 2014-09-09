using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxCommon;
using NHibernate;

namespace PhalanxDAL.Factories
{
    public class CommunicationDeviceProtocolFactory
    {
        public CommunicationDeviceProtocolEntityCollection GetAll()
        {
            CommunicationDeviceProtocolEntityCollection ProtLst = new CommunicationDeviceProtocolEntityCollection();
            
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceProtocolEntity));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    IList<CommunicationDeviceProtocolEntity> lstCDProtocols = DataSearch.List<CommunicationDeviceProtocolEntity>();

                    ProtLst.Add(lstCDProtocols);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "CommunicationDeviceProtocolFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "CommunicationDeviceProtocolFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "CommunicationDeviceProtocolFactory GetAll()"));
            }

            return ProtLst;
        }
    }
}
