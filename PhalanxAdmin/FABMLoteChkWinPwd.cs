using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMLoteChkWinPwd : PhalanxAdmin.FModalBase
    {
        
        private bool _readonly = false;
        private LoteChkWinLocalUsersEntity _lote;
        public FABMLoteChkWinPwd()
        {
            InitializeComponent();
            PopulateDomains();
            _lote = new LoteChkWinLocalUsersEntity();
            base.Title = "Generación manual de lote de chequeo de usuarios de Windows";
            lvWinPwdDB.ListViewItemSorter = new cwxSorter();
            lvWinPwdGrupo.ListViewItemSorter = new cwxSorter();

        }
        public FABMLoteChkWinPwd(LoteChkWinLocalUsersEntity LoteADuplicar): this()
        {
            ItemLoteChkWinLocalUsersEntityCollection ItemsLote = new ItemLoteChkWinLocalUsersBusiness().GetAll(LoteADuplicar);
            foreach (ItemLoteChkWinLocalUsersEntity ItemLote in ItemsLote)
            {
                if (ItemLote.WinLocalUser.UserPassword.Checkeable && ItemLote.WinLocalUser.WinPc.Active
                     && ItemLote.WinLocalUser.WinPc.Checkable && ItemLote.WinLocalUser.ActiveUser)
                {
                    ListViewItem lviGrpWinPwd = new ListViewItem();
                    lviGrpWinPwd.Tag = ItemLote.WinLocalUser;
                    lviGrpWinPwd.Text = ItemLote.WinLocalUser.Key;
                    //lviGrpWinPwd.SubItems.Add(ItemLote.WinLocalUser.NetPath);
                    lviGrpWinPwd.SubItems.Add(ItemLote.WinLocalUser.Domain);
                    lviGrpWinPwd.SubItems.Add(ItemLote.WinLocalUser.PCName);
                    lviGrpWinPwd.SubItems.Add(ItemLote.WinLocalUser.Username);

                    lvWinPwdGrupo.Items.Add(lviGrpWinPwd);
                }

            }
        }
            

        private void PopulateDomains()
        {
            WinDomainBusiness winDomBus = new WinDomainBusiness();
            cbDominio.DataSource = winDomBus.GetAll();
        }
        private void PasarWinPwdDeDBaUsr()
        {
            if (lvWinPwdDB.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdDB.SelectedItems)
            {
                bool YaEstaEnDestino = false;
                foreach (ListViewItem lviSel in lvWinPwdGrupo.Items)
                {
                    if (((WinLocalUserEntity)lviDB.Tag).Id == ((WinLocalUserEntity)lviSel.Tag).Id)
                    {
                        YaEstaEnDestino = true;
                        break;
                    }
                }
                if (!YaEstaEnDestino)
                {
                    // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                    ListViewItem lviGrpWinPwd = new ListViewItem();
                    lviGrpWinPwd.Tag = lviDB.Tag;
                    lviGrpWinPwd.Text = lviDB.Text;
                    for (int i = 1; i < lviDB.SubItems.Count; i++)
                    {
                        lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                    }
                    /*
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                    lvWinPwdGrupo.Items.Add(lviGrpWinPwd);
                }
            }
            /*
            foreach (ListViewItem lviDB in lvWinPwdDB.SelectedItems)
            {
                lvWinPwdDB.Items.Remove(lviDB);
            }*/

        }
        private void PasarTodoWinPwdDeDBaUsr()
        {
            if (lvWinPwdDB.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem lviDB in lvWinPwdDB.Items)
            {
                bool YaEstaEnDestino = false;
                foreach (ListViewItem lviSel in lvWinPwdGrupo.Items)
                {
                    if (((WinLocalUserEntity)lviDB.Tag).Id == ((WinLocalUserEntity)lviSel.Tag).Id)
                    {
                        YaEstaEnDestino = true;
                        break;
                    }
                }
                if (!YaEstaEnDestino)
                {
                    // crear el phxuserrole y mandarlo al otro listview y sacarlos del lvBD
                    ListViewItem lviGrpWinPwd = new ListViewItem();
                    lviGrpWinPwd.Tag = lviDB.Tag;
                    lviGrpWinPwd.Text = lviDB.Text;
                    for (int i = 1; i < lviDB.SubItems.Count; i++)
                    {
                        lviGrpWinPwd.SubItems.Add(lviDB.SubItems[i]);
                    }
                    /*
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[0]);
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[1]);
                    lviGrpWinPwd.SubItems.Add(lviDB.SubItems[2]);*/
                    lvWinPwdGrupo.Items.Add(lviGrpWinPwd);
                }
            }
            /*
            foreach (ListViewItem lviDB in lvWinPwdDB.SelectedItems)
            {
                lvWinPwdDB.Items.Remove(lviDB);
            }*/

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // traigo todos los roles de la base
            WinLocalUserBusiness WinPwdBL = new WinLocalUserBusiness();
            WinLocalUserEntityCollection WinPwdEC = WinPwdBL.GetAllForLotesChk((WinDomainEntity)cbDominio.SelectedItem);
            IList<WinLocalUserEntity> WinPwdAAsignarALvDB = new List<WinLocalUserEntity>();
            // agrego solo aquellos que no tiene asignado el usuario
            lvWinPwdDB.Items.Clear();
            foreach (WinLocalUserEntity WinLocUsrEnt in WinPwdEC)
            {

                bool PermisoAsignado = false;
                /*foreach (ListViewItem lviPermisosUsr in lvWinPwdGrupo.Items)
                {
                    if (((WinLocalUserEntity)lviPermisosUsr.Tag).Id == WinLocUsrEnt.Id)
                    {
                        PermisoAsignado = true;
                        break;
                    }
                }*/
                if (!PermisoAsignado)
                {
                    //WinPwdAAsignarALvDB.Add(WinLocUsrEnt);
                    ListViewItem lviAux = new ListViewItem();
                    lviAux.SubItems.Add(WinLocUsrEnt.Domain);
                     lviAux.SubItems.Add(WinLocUsrEnt.PCName);
                    lviAux.SubItems.Add(WinLocUsrEnt.Username);
                   lviAux.Text = WinLocUsrEnt.Key;
                    lviAux.Tag = WinLocUsrEnt;

                    lvWinPwdDB.Items.Add(lviAux);
                }
            }
            //lvWinPwdDB.Items.AddRange(GenerarLVItmsWinPwd(WinPwdAAsignarALvDB));

        }

        private void lvWinPwdDB_DoubleClick(object sender, EventArgs e)
        {
            PasarWinPwdDeDBaUsr();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            PasarWinPwdDeDBaUsr();
        }

        private void btnAddAllRoles_Click(object sender, EventArgs e)
        {
            PasarTodoWinPwdDeDBaUsr();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_readonly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            if (lvWinPwdGrupo.Items.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una contraseña a chequear");
                return;
            }

            _lote.FechaProgramada = dtpFechaProgramada.Value;
            WinLocalUserEntityCollection UsrLote = new WinLocalUserEntityCollection();
            for (int i = 0; i < lvWinPwdGrupo.Items.Count; i++)
            {
                UsrLote.Add((WinLocalUserEntity)lvWinPwdGrupo.Items[i].Tag);
            }
            LoteChkWinLocalUsersBusiness LoteBL = new LoteChkWinLocalUsersBusiness();
            if (LoteBL.Save(_lote, UsrLote))
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }

        }

        private void btnDelItmsLote_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviDB in lvWinPwdGrupo.SelectedItems)
            {
                lvWinPwdGrupo.Items.Remove(lviDB);
            }
        }

        private void lvWinPwdDB_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
            {
                return;
            }
            /*if (e.Column >= ((ListView)sender).Columns.Count)
            {
                return;
            }*/
            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;
            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            ((ListView)sender).Sort();

        }

        private void lvWinPwdGrupo_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            /*if (e.Column >= ((ListView)sender).Columns.Count)
            {
                return;
            }*/
            if (((ListView)sender).Items.Count == 0)
            {
                return;
            }
            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;
            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            ((ListView)sender).Sort();

        }
    }
}

