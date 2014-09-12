using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FSelectWinPC : PhalanxAdmin.FBaseSelect
    {
        private WinDomainEntity _dominio;
        private WinPCBusiness m_WinPcBus = null;
        private UnixPCBusiness m_UnixPcBus = null;
      
        public FSelectWinPC(WinDomainEntity Dominio)
        {
            InitializeComponent();
            _dominio = Dominio;
            m_WinPcBus = new WinPCBusiness();
        }

        public FSelectWinPC()
        {
            InitializeComponent();
            m_UnixPcBus = new UnixPCBusiness();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;

            if (m_WinPcBus != null)
            {
                foreach (WinPCEntity WinPCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(WinPCEnt.PcIP);
                    lviArr[i].Text = WinPCEnt.Name;
                    lviArr[i].Tag = WinPCEnt;
                    i++;
                }
            }
            else 
            {
                foreach (UnixEntity UnixPCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(UnixPCEnt.Ip);
                    lviArr[i].Text = UnixPCEnt.ServerName;
                    lviArr[i].Tag = UnixPCEnt;
                    i++;
                }
            }
            return lviArr;
        }

        protected override void SetQueryFilters()
        {
            base.SetQueryFilters();
        }

        protected override void LoadEntities()
        {
            if (m_WinPcBus != null)
                this._entities = m_WinPcBus.FindNetPcs(_dominio, txtFilNombre.Text);
            else
                this._entities = m_UnixPcBus.FindNetPcs(txtFilNombre.Text);
        }

        private void FSelectWinPC_Load(object sender, EventArgs e)
        {
           // ExecEntitiesRefresh();
        }
    }
}

