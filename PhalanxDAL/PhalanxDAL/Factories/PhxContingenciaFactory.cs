using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxCommon;
using NHibernate;
using System.Configuration;

namespace PhalanxDAL.Factories
{
    public class PhxContingenciaFactory
    {
        public PhxContingenciaEntity EsquemaActualHabilitado()
        {
            PhxContingenciaEntityCollection ConEC = new PhxContingenciaEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxContingenciaEntity));
                    DataSearch.AddOrder(NHibernate.Expression.Order.Desc("Id"));

                    IList<PhxContingenciaEntity> lstCont = DataSearch.List<PhxContingenciaEntity>();
                    if (lstCont.Count == 0)
                    {
                        PhxContingenciaEntity ContE = new PhxContingenciaEntity();
                        ContE.EsquemaActivo = "@PROD@";
                        return ContE;
                    }
                    else
                    {
                        return lstCont[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PhxContingenciaFactory EsquemaActual()"));
            }

        }
        public bool CheckDataBaseAlternateConnection()
        {
            ITransaction tx = null;
            bool active = false;
            DBMgr.ChangeToAlternateConnection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    active = tx.IsActive;
                }
                catch (NHibernate.ADOException exADO)
                {
                    //exADO.
                    //DBMgr.ChangeToAlternateConnection();
                    active = false;
                }
                catch
                {
                    active = false;
                }
            }
            return active;
        }
        public bool CheckDataBaseConnection()
        {
            ITransaction tx = null;
            bool active = false;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    active = tx.IsActive;
                }
                catch (NHibernate.ADOException exADO)
                {
                    //exADO.
                    //DBMgr.
                }
                catch
                {
                    active = false;
                }
            }
            return active;
        }
        public bool EsAmbienteActualProduccion()
        {
            return DBMgr.EsAmbienteActualProduccion;
        }

        public bool VerificaSiConexionUsadaEstaActiva()
        {
            return (this.EsAmbienteActualProduccion() == this.EsquemaActualHabilitado().EsProduccion);
        }
        public void Save(PhxContingenciaEntity PhxEsquemaActivo)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Save(PhxEsquemaActivo);
                    tx.Commit();
                    
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    //return 0;
                    throw (new CwxException(ex.Message, "PhxContingenciaFactory Save()")); 
                    // handle exception
                }
            }
        }
        public void SetearEsquemaActivo(bool Produccion)
        {

            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);
            config.AppSettings.Settings["UsaProduccion"].Value = (Produccion ? "1" : "0");


            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");


        }
    }
}
