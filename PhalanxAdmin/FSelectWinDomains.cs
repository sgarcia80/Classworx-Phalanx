using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FSelectWinDomains : PhalanxAdmin.FBaseSelect
    {
        private WinDomainBusiness m_WinDomBus;
        public FSelectWinDomains()
        {
            InitializeComponent();
            m_WinDomBus = new WinDomainBusiness();
        }

        protected override void LoadEntities()
        {
            this._entities = m_WinDomBus.FindNetDomains(txtFilNombre.Text);
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (WinDomainEntity WinDomEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = WinDomEnt.NtName;
                if (WinDomEnt.Comments.Length > 15)
                    lviArr[i].SubItems.Add(WinDomEnt.Comments.Substring(1, 15) + " ...");
                else
                    lviArr[i].SubItems.Add(WinDomEnt.Comments);
                lviArr[i].ToolTipText = WinDomEnt.Comments;
                lviArr[i].Tag = WinDomEnt;
                i++;
            }
            return lviArr;
        }

    }
}

