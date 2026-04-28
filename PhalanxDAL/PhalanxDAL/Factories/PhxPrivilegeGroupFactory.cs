using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using NHibernate;
using PhalanxCommon.Entities;
using PhalanxCommon;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class PhxPrivilegeGroupFactory
    {
        private bool _filCargaPrivilegios = false;
        public bool FilCargaPrivilegios
        {
            set { _filCargaPrivilegios = value; }
        }

        public PhxPrivilegeGroupEntityCollection GetAll()
        {
            PhxPrivilegeGroupEntityCollection WinDomLst = new PhxPrivilegeGroupEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxPrivilegeGroupEntity));

                    DataSearch = DataSearch.AddOrder(Order.Asc("Name"));
                    IList<PhxPrivilegeGroupEntity> lstDBTypes = DataSearch.List<PhxPrivilegeGroupEntity>();
                    if (_filCargaPrivilegios)
                    {
                        for (int i = 0; i < lstDBTypes.Count; i++)
                        {
                            int x = lstDBTypes[i].PhxPrivilegeList.Count;
                        }
                    }
                    WinDomLst.Add(lstDBTypes);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PhxPrivilegeGroupFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PhxPrivilegeGroupFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PhxPrivilegeGroupFactory GetAll()"));
            }
            return WinDomLst;

        }

    }
}
