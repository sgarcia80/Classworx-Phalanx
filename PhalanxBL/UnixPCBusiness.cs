using System;
using System.Collections.Generic;
using System.Text;
using PhalanxNAL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class UnixPCBusiness
    {
        private string _filNombre = "";
        private UnixPCsFactory m_UnixPcsFac = null;
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
        public UnixPCBusiness()
        {
            m_UnixPcsFac = new UnixPCsFactory();
        }

        public UnixPCEntityCollection GetAll()
        {
            m_UnixPcsFac.FilNombre = _filNombre;
            m_UnixPcsFac.FilActivo = _filActivo;
            return m_UnixPcsFac.GetAll();
        }

        public UnixEntity Get(string pcName)
        {
            return (m_UnixPcsFac.GetUnixPC(pcName));
        }

        public bool Exists(string pcName)
        {
            return (m_UnixPcsFac.GetUnixPC(pcName) != null);
        }

        public bool Exists(string pcName, int Id)
        {
            return (m_UnixPcsFac.GetUnixPC(pcName, Id) != null);
        }

        public UnixEntity FillData(UnixEntity pcEntity)
        {
            return (m_UnixPcsFac.GetUnixPC(pcEntity.ServerName)); 
        }

        public void Delete( string pcName)
        {
            if (Exists( pcName))
                m_UnixPcsFac.DeleteUnixPC(pcName);
            else
                throw new SystemException("La PC no existe en el Sistema");
        }

        public void Create(UnixEntity Pc)
        {
            m_UnixPcsFac.SaveUnixPC(Pc);
        }

        public void Update(UnixEntity Pc)
        {
            m_UnixPcsFac.SaveUnixPC(Pc);
        }

        public UnixPCEntityCollection FindNetPcs(string filter)
        {
            return new NPc().FindUnixComputers(filter);
        }
        
  }
}
