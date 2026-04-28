using System;
using System.Collections.Generic;
using System.Text;
//using PhalanxNAL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxNAL;

namespace PhalanxBL
{
    public class WinDomainBusiness
    {
        private string _filNombre = "";
        private bool _filConfigured = false;
        private bool? _filactive;
        private WinDomainsFactory mWinDomFactory = null;

        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        public bool FilConfigured
        {
            set { _filConfigured = value; }
            //get { return _filNombre; }
        }
        public bool? FillActive
        {
            set { _filactive = value; }
            //get { return _filNombre; }
        }

        public WinDomainBusiness()
        {
            mWinDomFactory = new WinDomainsFactory();
        }

        public WinDomainEntityCollection GetAll()
        {
            mWinDomFactory.FilConfigured = _filConfigured;
            mWinDomFactory.FilNombre = _filNombre;
            mWinDomFactory.FilActive = _filactive;
            return mWinDomFactory.GetAll();
        }

        public WinDomainEntityCollection GetById(int id)
        {
            return mWinDomFactory.GetById(id);
        }

        public WinDomainEntityCollection FillFilter()
        {
            WinDomainEntityCollection WinDomEC = this.GetAll();
            WinDomainEntity Todos = new WinDomainEntity();
            Todos.NtName = "Todos";
            Todos.Id = 0;
            WinDomEC.Insert(0, Todos);
            return WinDomEC;
        }

        public bool Exists(string DomainName)
        {
            return (mWinDomFactory.GetWinDomain(DomainName) != null);
        }

        public WinDomainEntity FillData(WinDomainEntity domain)
        {
            return (mWinDomFactory.GetWinDomain(domain.NtName));
        }

        public bool Delete(WinDomainEntity Domain)
        {
            return mWinDomFactory.DeleteWinDomain(Domain);
        }

        public void Save(WinDomainEntity Domain)
        {
            mWinDomFactory.SaveDomain(Domain);
        }

        public WinDomainEntityCollection FindNetDomains(string filter)
        {
            return new NDomain().FindDomains(filter);
        }

        public WinDomainEntity GetByNtName(string ntName)
        {
            return new WinDomainsFactory().GetWinDomain(ntName);
        }
    }
}
