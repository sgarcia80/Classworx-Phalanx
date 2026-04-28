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
    public partial class PrueFormSel : Form
    {
        public PrueFormSel()
        {
            InitializeComponent();
        }
        private void CargaComboDominios()
        {
            WinDomainBusiness WinDomBL = new WinDomainBusiness();
            //ProvinciaEntityCollection ProvEC

            cbDominio.DataSource = WinDomBL.FillFilter();
        }

        private void PrueFormSel_Load(object sender, EventArgs e)
        {
            CargaComboDominios();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            WinDomainEntity FilDom = new WinDomainEntity();
            if (cbDominio.SelectedIndex == 0)
            {
                FilDom = null;
            }
            else
            {
                FilDom = (WinDomainEntity)cbDominio.SelectedItem;
            }
            FSelectWinPC SelWinPC = new FSelectWinPC(FilDom);
            SelWinPC.ShowDialog();
            /*
            if (SelWinPC.SelectedPC == null)
            {
                txtPC.Text = "";
            }
            else
            {
                txtPC.Text = SelWinPC.SelectedPC.Name;
            }*/
        }

    }
}