using System;
//using System.Reflection;
using System.Collections;
using System.Collections.Generic;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon;
using PhalanxCommon.Collections;
//using NHibernate.Cfg;

namespace PhalanxDAL.Factories
{
    /// <summary>
    /// Summary description for WinDomainsFactory.
    /// </summary>
    public class WinDomainsFactory
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private bool _filConfigured = false;
        public bool FilConfigured
        {
            set { _filConfigured = value; }
            //get { return _filConfigured; }
        }

        public WinDomainsFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public WinDomainEntityCollection GetAll()
        {
            WinDomainEntityCollection WinDomLst = new WinDomainEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(WinDomainEntity));

                    if (_filNombre.Trim() != "")
                    {
                        DataSearch = DataSearch.Add(Expression.Like("NtName", _filNombre));
                    }
                    if (_filConfigured)
                    {
                        DataSearch = DataSearch.Add(
                                            Expression.And(
                                                    Expression.Sql("isnull({alias}.LDAPUser, '') <> ''"),
                                                    Expression.Sql("isnull({alias}.LDAPUserPassword, '') <> ''")
                                                            )
                                                   );
                    }

                    DataSearch = DataSearch.AddOrder(Order.Asc("NtName"));
                    WinDomLst.Add(DataSearch.List<WinDomainEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "WinDomainFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "WinDomainFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "WinDomainFactory GetAll()"));
            }
            return WinDomLst;
        }

        public WinDomainEntityCollection GetById(int id)
        {
            WinDomainEntityCollection WinDomLst = new WinDomainEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(WinDomainEntity));

                    DataSearch = DataSearch.Add(Expression.Like("Id", id));

                    DataSearch = DataSearch.AddOrder(Order.Asc("NtName"));
                    WinDomLst.Add(DataSearch.List<WinDomainEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "WinDomainFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "WinDomainFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "WinDomainFactory GetAll()"));
            }
            return WinDomLst;
        }
        public WinDomainEntityCollection GetWinDomains()
        {
            IList<WinDomainEntity> lstWDom = null;
            //ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                lstWDom = session.CreateCriteria(typeof(WinDomainEntity)).List<WinDomainEntity>();
            }
            WinDomainEntityCollection WinDomEC = new WinDomainEntityCollection();
            WinDomEC.Add(lstWDom);
            return WinDomEC;

        }
        public WinDomainEntityCollection GetWinDomainsWithDCs()
        {
            IList<WinDomainEntity> lstWDom = null;
            //ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                lstWDom = session.CreateCriteria(typeof(WinDomainEntity)).List<WinDomainEntity>();
                foreach (WinDomainEntity objWD in lstWDom)
                {
                    int i = objWD.WinDomainControllersList.Count;
                }
            }
            WinDomainEntityCollection WinDomEC = new WinDomainEntityCollection();
            WinDomEC.Add(lstWDom);
            return WinDomEC;

        }

        public WinPCEntityCollection GetWinDomainPCs(WinDomainEntity objWD)
        {

            ISession session = DBMgr.factory.OpenSession();
            session.Lock(objWD, NHibernate.LockMode.None);
            NHibernateUtil.Initialize(objWD);
            IList<WinPCEntity> lstWDPCs; // = new ArrayList();
            /*
            IList lstWDPCs;

            using(ISession session = DBMgr.factory.OpenSession())
            {
                lstWDPCs = session.CreateCriteria(typeof(WinPCEntity))
                    .Add("")
                    .List();
            }
            */

            int i = objWD.WinPCsList.Count;
            lstWDPCs = objWD.WinPCsList;
            /*
            foreach(WinPCEntity objWP in objWD.WinPCsList)
            {
                lstWDPCs.Add(objWP);
            }*/
            session.Close();

            //}

            WinPCEntityCollection WinPCEC = new WinPCEntityCollection();
            WinPCEC.Add(lstWDPCs);
            return WinPCEC;

            //return lstWDPCs;
        }
        public WinLocalUserEntityCollection GetWinDomainPCUsers(WinPCEntity objWP)
        {
            try
            {
                ISession session = DBMgr.factory.OpenSession();
                session.Lock(objWP, NHibernate.LockMode.None);
                NHibernateUtil.Initialize(objWP);
                IList<WinLocalUserEntity> lstWDUsrs;
                /*
                IList lstWDPCs;

                using(ISession session = DBMgr.factory.OpenSession())
                {
                    lstWDPCs = session.CreateCriteria(typeof(WinPCEntity))
                        .Add("")
                        .List();
                }
                */

                int i = objWP.WinLocalUsersList.Count;
                lstWDUsrs = objWP.WinLocalUsersList;
                /*
                foreach(WinPCEntity objWP in objWD.WinPCsList)
                {
                    lstWDPCs.Add(objWP);
                }*/
                session.Close();

                //}
                WinLocalUserEntityCollection WLUsrEC = new WinLocalUserEntityCollection();
                WLUsrEC.Add(lstWDUsrs);
                return WLUsrEC;
                //return lstWDUsrs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Busca el dominio a raíz del nombre pasado por parámetro como el nt_name
        /// </summary>
        /// <param name="DomainName">nombre del dominio con formato NT</param>
        /// <returns>Duevuelve el objeto correspondiente al dominio. Si no existe en la base,
        /// devuelve null</returns>
        public WinDomainEntity GetWinDomain(string DomainName)
        {
            try
            {
                WinDomainEntity objWD = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    IList WDlst = session.CreateCriteria(typeof(WinDomainEntity))
                        .Add(Expression.Sql("lower({alias}.nt_name) = lower('" + DomainName + "')"))
                        .List();

                    if (WDlst.Count == 1)
                    {
                        objWD = (WinDomainEntity)WDlst[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                return objWD;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void SaveDomain(WinDomainEntity Domain)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Domain);
                    // ver si hay DCs
                    // si hay primero grabar las PCs y después los DCs
                    if (Domain.WinDomainControllersList != null)
                    {
                        foreach (WinDomainControllerEntity WDCE in Domain.WinDomainControllersList)
                        {
                            WDCE.WinDomain = Domain;
                            WDCE.WinPc.WinDomain = Domain;
                            session.SaveOrUpdate(WDCE.WinPc);
                            session.SaveOrUpdate(WDCE);
                        }
                    }
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                if (tx != null)
                    tx.Rollback();
                throw new SystemException(ex.Message);
            }
        }

        public bool CreateWinDomain(string DomainName, string PDCName, IList BDCsNameLst)
        {
            // verificar que no exista en la base
            //WinDomainsFactory WDF = new WinDomainsFactory();
            WinDomainEntity objWD = this.GetWinDomain(DomainName);
            if (objWD != null)
            {
                // ya existe el dominio en la BD
                return false;
            }
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    // crear el dominio en la base
                    objWD = new WinDomainEntity();
                    objWD.NtName = DomainName;
                    tx = session.BeginTransaction();
                    session.Save(objWD);
                    // crear la PC de PDC y el PDC
                    if (PDCName != null && PDCName != string.Empty)
                    {
                        WinPCEntity objPDCPc = new WinPCEntity();
                        objPDCPc.Name = PDCName;
                        objPDCPc.WinDomain = objWD;
                        session.Save(objPDCPc);
                        //tx.Commit();
                        WinDomainControllerEntity WDC = new WinDomainControllerEntity();
                        WDC.Type = "P";
                        WDC.WinDomain = objWD;
                        WDC.WinPc = objPDCPc;
                        session.Save(WDC);
                        int i = 0;
                    }

                    // crear las PCs de BDCs y los BDCs
                    foreach (string BDCName in BDCsNameLst)
                    {
                        WinPCEntity objBDCPc = new WinPCEntity();
                        objBDCPc.Name = BDCName;
                        objBDCPc.WinDomain = objWD;
                        session.Save(objBDCPc);
                        WinDomainControllerEntity WDC = new WinDomainControllerEntity();
                        WDC.Type = "B";
                        WDC.WinDomain = objWD;
                        WDC.WinPc = objBDCPc;
                        session.Save(WDC);
                    }
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }

        public bool DeleteWinDomain(WinDomainEntity Domain)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(Domain);

                    if (Domain.WinDomainControllersList != null)
                    {
                        foreach (WinDomainControllerEntity WDCE in Domain.WinDomainControllersList)
                        {
                            WDCE.WinDomain = Domain;
                            WDCE.WinPc.WinDomain = Domain;
                            session.Delete(WDCE.WinPc);
                            session.Delete(WDCE);
                        }
                    }
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                }
            }
        }

    }
}
