using System;
using System.Collections.Generic;
using System.Text;
using PhalanxNAL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class WinPCBusiness
    {
        private string _filNombre = "";
        private WinPCsFactory m_WinPcsFac = null;
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private WinDomainEntity _filDominio;
        private Nullable<bool> _filActivo;
        public Nullable<bool> FilActivo
        {
            set { _filActivo = value; }
        }

        public WinPCBusiness()
        {
            m_WinPcsFac = new WinPCsFactory();
        }

        public WinDomainEntity FilDominio
        {
            set { _filDominio = value; }
            //get { return _filNombre; }
        }
        
        public WinPCEntityCollection GetAll()
        {
            m_WinPcsFac.FilNombre = _filNombre;
            m_WinPcsFac.FilDominio = _filDominio;
            m_WinPcsFac.FilActivo = _filActivo;
            return m_WinPcsFac.GetAll();
        }

        public WinPCEntity Get(string domainName, string pcName)
        {
            return (m_WinPcsFac.GetWinPC(domainName, pcName));
        }

        public bool Exists(string domainName, string pcName)
        {
            return (m_WinPcsFac.GetWinPC(domainName, pcName) != null);
        }

        /// <summary>
        /// Devuelve true si existe un equipo bajo el dominio y con el 
        /// nombre pasado y con Id distinta
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="pcName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Exists(string domainName, string pcName, int Id)
        {
            return (m_WinPcsFac.GetWinPC(domainName, pcName, Id) != null);
        }

        public WinPCEntity FillData(WinPCEntity pcEntity)
        {
            return (m_WinPcsFac.GetWinPC(pcEntity.WinDomain.NtName, pcEntity.Name)); 
        }

        public void Delete(string domainName, string pcName)
        {
            if (Exists(domainName, pcName))
                m_WinPcsFac.DeleteWinPC(domainName, pcName);
            else
                throw new SystemException("El equipo no existe en el Sistema");
        }

        public void Create(WinPCEntity Pc)
        {
            m_WinPcsFac.SaveWinPC(Pc);
        }

        public void Update(WinPCEntity Pc)
        {
            m_WinPcsFac.SaveWinPC(Pc);
        }

        public WinPCEntityCollection FindNetPcs(WinDomainEntity domain, string filter)
        {
            return new NPc().FindWinComputers(domain, filter);
        }
        public string ResolveHostName(string IPAddress)
        {
            NPc myNPc = new NPc();
            return myNPc.ResolveHostName(IPAddress);
        }
        public string Ping(string Host)
        {
            NPc myNPc = new NPc();
            return myNPc.PcPing(Host);
        }
    }
}
