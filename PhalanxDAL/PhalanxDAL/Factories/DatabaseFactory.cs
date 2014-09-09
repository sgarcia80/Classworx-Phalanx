using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using PhalanxCommon.Collections;

namespace PhalanxDAL.Factories
{
    public class DatabaseFactory
    {
        private bool _orderByDBName = false;
        public void SetOrderByDBName()
        {
            _orderByDBName = true;
        }
        private DatabaseTypeEntity _filTipoDB;
        public DatabaseTypeEntity FilTipoDB
        {
            set { _filTipoDB = value; }
        }
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private bool? _filUsuariosActivos;
        public bool? FilUsuariosActivos
        {
            set { _filUsuariosActivos = value; }
        }

        public DataBaseEntityCollection GetAll()
        {
            DataBaseEntityCollection WinDomLst = new DataBaseEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(DataBaseEntity));
                    if (_filNombre != null && _filNombre != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("Name", _filNombre, MatchMode.Anywhere));
                    }
                    if (_filTipoDB != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Type", _filTipoDB));
                    }
                    if (_filUsuariosActivos != null)
                    {
                        DataSearch.Add(Expression.Eq("ActiveUser", _filUsuariosActivos));
                    }
                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    WinDomLst.Add(DataSearch.List<DataBaseEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "DataBaseFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "DataBaseFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "DataBaseFactory GetAll()"));
            }
            return WinDomLst;

        }

        public int Save(DataBaseEntity Database)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Database);
                    tx.Commit();
                    return Database.Id;
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
