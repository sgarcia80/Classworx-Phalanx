using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class vwHistPwdChgFactory
    {
        public Nullable<DateTime> FilFDesde = null;
        public Nullable<DateTime> FilFHasta = null;
        public PhxUserEntity FilPhxUser = null;
        public UserEntity FilUser = null;

        public int FilFolio = 0;

        public vwHistPwdChgEntityCollection GetAll()
        {
            IList<vwHistPwdChgEntity> lstWLUs;
            vwHistPwdChgEntityCollection DBUsrEC = new vwHistPwdChgEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(vwHistPwdChgEntity));
                if (FilFolio > 0)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("Folio", FilFolio));
                }
                if (FilPhxUser != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("PhxUser", FilPhxUser));
                }
                if (FilUser != null)
                {
                    if (FilUser is AS400UserEntity)
                    {
                            AS400UserEntity FilAs400User = (AS400UserEntity)FilUser;
                            DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.Server_Name + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is ApplicationUserEntity)
                    {
                        ApplicationUserEntity FilAs400User = (ApplicationUserEntity)FilUser;
                        DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.ApplicationName  + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is DatabaseUserEntity)
                    {
                        DatabaseUserEntity FilAs400User = (DatabaseUserEntity)FilUser;
                        DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.DBType + "\\" + FilAs400User.DBName 
                            + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is CommunicationDeviceUserEntity)
                    {
                        CommunicationDeviceUserEntity FilAs400User = (CommunicationDeviceUserEntity)FilUser;
                        DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.CommunicationDeviceType + "\\" + FilAs400User.CommunicationDeviceName + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is WinLocalUserEntity)
                    {
                        WinLocalUserEntity FilAs400User = (WinLocalUserEntity)FilUser;
                        DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.Domain + "\\" + FilAs400User.PCName + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is UnixUserEntity)
                    {
                        UnixUserEntity FilAs400User = (UnixUserEntity)FilUser;
                        DataSearch = DataSearch.Add(Expression.Eq("Usuario", FilAs400User.Unix + "\\" + FilAs400User.Username));
                    }
                    if (FilUser is ATMUserEntity)
                    {
                        ATMUserEntity FilATMUser = (ATMUserEntity)FilUser;
                        DataSearch.Add(Expression.Eq("Usuario", FilATMUser.ATMName + "\\" + FilATMUser.Username));
                    }
                
                }
                if (FilFDesde != null)
                {
                    DataSearch = DataSearch.Add(Expression.Ge("DChange", FilFDesde.Value.Date));
                }
                if (FilFHasta != null)
                {
                    DataSearch = DataSearch.Add(Expression.Lt("DChange", FilFHasta.Value.Date.AddDays(1)));
                }
                DataSearch = DataSearch.AddOrder(Order.Asc("Folio"));
                DataSearch = DataSearch.AddOrder(Order.Asc("DChange"));


                lstWLUs = DataSearch.List<vwHistPwdChgEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

    }
}
