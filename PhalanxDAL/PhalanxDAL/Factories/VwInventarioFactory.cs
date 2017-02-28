using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace PhalanxDAL.Factories
{
    public class VwInventarioFactory
    {
        public bool FilActivos = true;
        public bool FilNoActivos = true;
        public bool FilCriticos = true;
        public bool FilNoCriticos = true;
        public bool OrderByFolio = true; // si no es folio es por usuario
        public bool FilAmbWin = true;
        public bool FilAmbUnix = true;
        public bool FilAmbAS400 = true;
        public bool FilAmbDB = true;
        public bool FilAmbApp = true;
        public bool FilAmbEC = true;
        public bool FilAmbATM = true;
        public string FilUsername = "";

        public VwInventarioEntityCollection GetAll()
        {
            IList<VwInventarioEntity> lstWLUs;
            VwInventarioEntityCollection DBUsrEC = new VwInventarioEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(VwInventarioEntity));
                if (FilUsername != "")
                {
                    DataSearch = DataSearch.Add(Expression.Like("Usuario", FilUsername, MatchMode.Anywhere));
                }
                if (!FilActivos || !FilNoActivos)
                {
                    if (!FilActivos)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Activo", false));
                    }

                    if (!FilNoActivos)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Activo", true));
                    }
                }
                if (!FilCriticos || !FilNoCriticos)
                {
                    if (!FilCriticos)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Critico", false));
                    }

                    if (!FilNoCriticos)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Critico", true));
                    }
                }

                if (!FilAmbWin || !FilAmbUnix || !FilAmbAS400 || !FilAmbDB || !FilAmbApp || !FilAmbEC || !FilAmbATM)
                {
                    if (!FilAmbWin)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "Windows"))));
                    }
                    if (!FilAmbUnix)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "Unix"))));
                    }
                    if (!FilAmbAS400)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "AS400"))));
                    }
                    if (!FilAmbATM)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "ATM"))));
                    }
                    if (!FilAmbDB)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "Bases De Datos"))));
                    }
                    if (!FilAmbApp)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "Aplicativos"))));
                    }
                    if (!FilAmbEC)
                    {
                        DataSearch = DataSearch.Add(Expression.Not((Expression.Eq("Ambiente", "Equipos de Comunicación"))));
                    }

                }
                if (OrderByFolio)
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("Folio"));
                }
                else
                {
                    DataSearch = DataSearch.AddOrder(Order.Asc("Usuario"));
                }



                lstWLUs = DataSearch.List<VwInventarioEntity>();
                DBUsrEC.Add(lstWLUs);

            }

            return DBUsrEC;

        }

    }
}
