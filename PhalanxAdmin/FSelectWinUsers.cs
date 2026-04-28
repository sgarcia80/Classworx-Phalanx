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
    public partial class FSelectWinUsers : PhalanxAdmin.FBaseSelect
    {
        private WinLocalUserBusiness m_WinUserBus = null;
        private WinPCEntity m_CurrentPC = null;

        public FSelectWinUsers(WinPCEntity pcEntity)
        {
            InitializeComponent();
            m_WinUserBus = new WinLocalUserBusiness();
            m_CurrentPC = pcEntity;
        }

        protected override void LoadEntities()
        {
            this._entities = m_WinUserBus.FindNetWinUsers(m_CurrentPC, txtFilNombre.Text);
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (WinLocalUserEntity WinUserEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = WinUserEnt.Username;
                lviArr[i].SubItems.Add(WinUserEnt.Desc);
                lviArr[i].Tag = WinUserEnt;
                i++;
            }
            return lviArr;
        }

    }
}

