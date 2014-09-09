using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using PhalanxCommon.Collections;
using System.Collections;

namespace PhalanxDAL.Factories
{
    public class DatabaseTypesFactory
    {
        private bool _filCargaDatabases = false;
        public bool FilCargaDatabases
        {
            set { _filCargaDatabases = value; }
        }
        public DatabaseTypeEntityCollection GetAll()
        {
            DatabaseTypeEntityCollection WinDomLst = new DatabaseTypeEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(DatabaseTypeEntity));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    IList<DatabaseTypeEntity> lstDBTypes = DataSearch.List<DatabaseTypeEntity>();
                    if (_filCargaDatabases)
                    {
                        for(int i=0;i<lstDBTypes.Count;i++)
                        {
                            int x = lstDBTypes[i].DataBasesList.Count;
                        }
                    }
                    WinDomLst.Add(lstDBTypes);
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
            return WinDomLst;

        }
    }
}
