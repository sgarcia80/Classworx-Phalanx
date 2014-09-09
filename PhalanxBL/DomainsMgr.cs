using System;
using System.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
//using PhalanxNAL;
//using phxUsersMgr;

namespace PhalanxBL
{
	/// <summary>
	/// Summary description for MgrDominios.
	/// </summary>
	public class DomainsMgr
	{
		#region Private Members
		private Hashtable m_lstDominiosDB = null;
        private WinDomainEntityCollection _DominiosDB = new WinDomainEntityCollection();
        private WinDomainEntityCollection _DominiosNet = new WinDomainEntityCollection();
        private Hashtable m_lstDominiosNet = null;
		private bool m_DBDomainsLoaded = false;
		#endregion

		#region Constructors
		public DomainsMgr()
		{
			m_lstDominiosDB = new Hashtable(); // ArrayList();
			m_lstDominiosNet = new Hashtable();
		}
		#endregion

		#region Public Properties
        public WinDomainEntityCollection DominiosDB
		{
            get { return _DominiosDB; }
		}
		public Hashtable DominiosNet
		{
			get {return m_lstDominiosNet;}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Busca los dominios dados de alta en la BD con sus PDCs y BDCs respectivos
		/// </summary>
		public void ReloadDBDomains()
		{
			m_lstDominiosDB.Clear();
			WinDomainsFactory WDF = new WinDomainsFactory();
            _DominiosDB = WDF.GetWinDomainsWithDCs();
			//foreach (WinDomains objWD in WDF.GetWinDomains())
            /*
			foreach (WinDomainEntity objWD in WDF.GetWinDomainsWithDCs())
			{
				Domain objDomAux = new Domain(objWD.NtName.ToLower());
				foreach(WinDomainControllerEntity objWDC in objWD.WinDomainControllersList)
				{
					PC auxDCPC = new PC(objWDC.WinPcId.PcName.ToLower());
					if (objWDC.IsBDC)
					{
						objDomAux.lstBDCs.Add(auxDCPC.PCName.ToLower(), auxDCPC);
					}
					else if (objWDC.IsPDC)
					{
						objDomAux.PDC = auxDCPC;
					}

				}
				m_lstDominiosDB.Add(objDomAux.NtName.ToLower(),objDomAux);
			}*/

				m_DBDomainsLoaded = true;
		}
		/// <summary>
		/// Busca los dominios en la red con sus PDCs y BDCs respectivos
		/// </summary>
		public void ReloadNetDomains()
		{
			this.ReloadNetDomains(true);
		}
		public void ReloadNetDomains(bool SearchDCs)
		{
            /*
			m_lstDominiosNet.Clear();
			CDomainList mydomlist = new CDomainList();
            _DominiosNet = mydomlist.getDomainList();
            // si tengo que buscar los domain controllers
            if (SearchDCs)
            {
                // por cada dominio busco DCs
                for (int i = 0; i < _DominiosNet.Count; i++)
                {
                    _DominiosNet[i].WinDomainControllersList = new CDomain().getDCs(_DominiosNet[i]);
                }
            }*/
		}
		public bool IsDomainInDB(string DomainName)
		{
			if (!m_DBDomainsLoaded || m_lstDominiosDB[DomainName] != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        /*
        public int CreateDomainInDB(WinDomainEntity Domain)
        {
            WinDomainsFactory WinDomF = new WinDomainsFactory();
            return WinDomF.CreateWinDomain(Domain);
        }*/

        public bool DeleteDomainInDB(WinDomainEntity Domain)
        {
            WinDomainsFactory winDomFac = new WinDomainsFactory();
            return true; // winDomFac.DeleteWinDomain(Domain);
        }

		public bool SaveDomainToDB(string DomainName)
		{
            return false;
            /*
			// verificar que existe el Dominio en la lista de Net
			Domain NetDomain = (Domain)this.m_lstDominiosNet[DomainName];
			if (NetDomain == null)
			{
				// no existe el dominio en la lista de dominios encontrados en la red
				return false;
			}
			if (NetDomain.PDC == null)
			{
				// busca los DCs
				CDomainList mydomlist = new CDomainList();
				CDomain currDom = mydomlist.getDomain(DomainName);
				//Domain objDomAux = new Domain(currDom.ntName.ToLower());
				//m_lstDominiosNet.Add(NetDomain.NtName.ToLower(),NetDomain);
				foreach (CPc currPC in currDom.getDCs())
				{
					PC auxDCPC = new PC(currPC.pc_name.ToLower());
					if (currPC.isBDC)
					{
						NetDomain.lstBDCs.Add(currPC.pc_name.ToLower(), auxDCPC);
					}
					else if (currPC.isPDC)
					{
						NetDomain.PDC = auxDCPC;
					}
				}
			}
			// Crear el dominio en la base
			WinDomainsFactory WDF = new WinDomainsFactory();
			IList BDCsLst = new ArrayList();
			foreach (PC BDC in NetDomain.lstBDCs.Values)
			{
				BDCsLst.Add(BDC.PCName);
			}
			if (WDF.CreateWinDomain(NetDomain.NtName, (NetDomain.PDC == null?string.Empty:NetDomain.PDC.PCName) , BDCsLst ))
			{
				return true;
			}
			else
			{
				return false;
			}*/
		}
		#endregion

	}
}
