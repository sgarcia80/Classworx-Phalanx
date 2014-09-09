using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using NHibernate;
using PhalanxCommon.Entities;
using NHibernate.Expression;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    public class CommunicationDeviceFactory
    {
        private string _filNombre = "";
        private CommunicationDeviceTypeEntity _filTipoCD;
        private Nullable<bool> _filActivo;
        private Nullable<bool> _loadUsers;
        
        public string FilNombre
        {
            set { _filNombre = value; }
        }

        public CommunicationDeviceTypeEntity FilTipoCD
        {
            set { _filTipoCD = value; }
        }
        
        public Nullable<bool> FilActivo
        {
            set { _filActivo = value; }
        }

        public Nullable<bool> LoadUsers
        {
            set { _loadUsers = value; }
        }

        public CommunicationDeviceEntityCollection GetAll()
        {
            CommunicationDeviceEntityCollection ComDevLst = new CommunicationDeviceEntityCollection();
            
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(CommunicationDeviceEntity));

                    if (_filNombre.Trim() != "")
                        DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre, MatchMode.Anywhere));

                    if (_filTipoCD != null)
                        DataSearch = DataSearch.Add(Expression.Eq("Type", _filTipoCD));
                    
                    if (_filActivo != null)
                        DataSearch = DataSearch.Add(Expression.Eq("Active", _filActivo.Value));
                    
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));

                    ComDevLst.Add(DataSearch.List<CommunicationDeviceEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "CommunicationDeviceFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "CommunicationDeviceFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "CommunicationDeviceFactory GetAll()"));
            }

            return ComDevLst;
        }

        public CommunicationDeviceFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public int Save(CommunicationDeviceEntity CommunicationDevice)
        {
            return Save(CommunicationDevice, null);
        }

        public int Save(CommunicationDeviceEntity CommunicationDevice, IEnumerable<CommunicationDeviceProtocolEntity> protocolsToRemove)
        {
            ITransaction tx = null;
            
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();

                    session.SaveOrUpdate(CommunicationDevice);

                    if (protocolsToRemove != null)
                        foreach (CommunicationDeviceUserEntity user in CommunicationDevice.Users)
                            foreach (CommunicationDeviceProtocolEntity protocol in protocolsToRemove)
                            {
                                user.Protocols.Remove(protocol);

                                session.SaveOrUpdate(user);
                            }
                    
                    tx.Commit();

                    return CommunicationDevice.Id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }

        public CommunicationDeviceEntity GetByName(string name)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                return session.CreateCriteria(typeof(CommunicationDeviceEntity))
                    .Add(Expression.Eq("Name", name))
                    .UniqueResult<CommunicationDeviceEntity>();
                    
            }
        }
    }
}
