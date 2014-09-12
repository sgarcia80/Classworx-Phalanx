using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FSelectPhxUser : PhalanxAdmin.FBaseSelect
    {
        public FSelectPhxUser()
        {
            InitializeComponent();
            m_PhxUserBus = new PhxUserBusiness();
        }
        private PhxUserBusiness m_PhxUserBus = null;
        private PhxUserEntity m_CurrentPhxUsr = null;

        protected override void LoadEntities()
        {
            this._entities = m_PhxUserBus.Search(txtFilNombre.Text.Trim());
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (PhxUserEntity PhxUserEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = PhxUserEnt.Fullname;
                lviArr[i].SubItems.Add(PhxUserEnt.Username);
                lviArr[i].Tag = PhxUserEnt;
                i++;
            }
            return lviArr;
        }
        protected override void CleanFilters()
        {
            base.CleanFilters();
            m_CurrentPhxUsr = null;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedItems.Count == 1)
            {
                m_CurrentPhxUsr = (PhxUserEntity)lvLista.SelectedItems[0].Tag;
                this.DialogResult = DialogResult.OK;
                return;
            }
        }
    }
}

