using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class AS400Business
    {
        private string _filNombre = "";
        private AS400Factory m_AS400Fac = null;
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private Nullable<bool> _filActivo;
        public Nullable<bool> FilActivo
        {
            set { _filActivo = value; }
        }
        public AS400Business()
        {
            m_AS400Fac = new AS400Factory();
        }

        public AS400EntityCollection GetAll()
        {
            m_AS400Fac.FilNombre = _filNombre;
            m_AS400Fac.FilActivo = _filActivo;
            return m_AS400Fac.GetAll();
        }

        public AS400Entity Get(string pcName)
        {
            return (m_AS400Fac.GetAS400(pcName));
        }

        public bool Exists(string pcName)
        {
            return (m_AS400Fac.GetAS400(pcName) != null);
        }

        public AS400Entity FillData(AS400Entity pcEntity)
        {
            return (m_AS400Fac.GetAS400(pcEntity.ServerName)); 
        }

        /*public void Delete( string pcName)
        {
            if (Exists( pcName))
                m_AS400Fac.DeleteAS400(pcName);
            else
                throw new SystemException("La PC no existe en el Sistema");
        }*/

        public void Create(AS400Entity Pc)
        {
            m_AS400Fac.SaveAS400(Pc);
        }

        public void Update(AS400Entity Pc)
        {
            m_AS400Fac.SaveAS400(Pc);
        }



        public bool Exists(string PCName, int Id)
        {
            return (m_AS400Fac.GetAS400(PCName, Id) != null);
        }
    }
}
