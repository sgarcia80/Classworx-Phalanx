using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxBL;


namespace PhalanxAdmin
{
    public partial class FAltaPc : PhalanxAdmin.FModalBase
    {
        public enum FormType
        {
            New,
            Update,
            View
        }

        private FormType m_FormType = FormType.View;
        private WinPCEntity m_CurrentPC = null;
        private UnixEntity m_CurrentUnixPC = null;
        private WinDomainBusiness m_WinDomBusiness = null;
        private WinPCBusiness m_WinPCBusiness = null;
        private UnixPCBusiness m_UnixPCBusiness = null;
        private bool _estadoOriginal = true;
        private bool m_IsWindows = true;

        public FAltaPc():base()
        {
            InitializeComponent();
        }

        public FAltaPc(FormType formType, object currentPC)
            : this()
        {
            m_WinPCBusiness = new WinPCBusiness();
            m_WinDomBusiness = new WinDomainBusiness();
            m_UnixPCBusiness = new UnixPCBusiness();
            m_FormType = formType;
            lvLista.ListViewItemSorter = new cwxSorter();

            ConfigureControls();

            if (currentPC is WinPCEntity)
            {
                m_IsWindows = true;
                m_CurrentPC = (WinPCEntity)currentPC;

                if (formType == FormType.View)
                    PCDomianText = m_CurrentPC.WinDomain.NtName;
                else
                    PCDomain = m_CurrentPC.WinDomain;
                PcIP = m_CurrentPC.PcIP;
                PCName = m_CurrentPC.Name;
                PCDescription = m_CurrentPC.Desc;
                _estadoOriginal = m_CurrentPC.Active;
                cBoxActivo.Checked = m_CurrentPC.Active;
                chkEquipoChequeable.Checked = m_CurrentPC.Checkable;
                if (formType == FormType.New)
                {
                    chkEquipoChequeable.Checked = true;
                }
            }
            else if (currentPC is UnixEntity)
            {
                m_IsWindows = false;
                m_CurrentUnixPC = (UnixEntity)currentPC;
                PcIP = m_CurrentUnixPC.Ip;
                PCName = m_CurrentUnixPC.ServerName;
                PCDescription = m_CurrentUnixPC.Desc;
                _estadoOriginal = m_CurrentUnixPC.Active;
                cBoxActivo.Checked = m_CurrentUnixPC.Active;
            }
            else if (currentPC is bool)
            {
                m_IsWindows = (bool)currentPC;
            }
            
            ConfigureScreen();
        }

        public FAltaPc(FormType formType, bool IsWindowsPC): this(formType, (object)IsWindowsPC)
        {

        }

        public void ConfigureControls()
        {
            switch (m_FormType)
            {
                case FormType.New:
                    {
                        if (IsWindowsPC)
                            cbDominio.DataSource = m_WinDomBusiness.GetAll();
                        break;
                    }
                case FormType.Update:
                    {
                        if (IsWindowsPC)
                            cbDominio.DataSource = m_WinDomBusiness.GetAll();
                        break;
                    }
            }
        }

        public void ConfigureScreen()
        {
            if (!IsWindowsPC)
            {
                panelDominio.Height = 0;
                chkEquipoChequeable.Visible = false;
            }

            switch (m_FormType)
            {
                case FormType.New:
                    {
                        pNetFind.Visible = true;
                        tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
                        break;
                    }
                case FormType.Update:
                    {
                        DBRefreshEntites();
                        break;
                    }
                case FormType.View:
                    {
                        if (IsWindowsPC)
                        {
                            cbDominio.Visible = false;
                            chkEquipoChequeable.Enabled = false;
                        }
                        btnCancelar.Enabled = false;
                        tBIP1.ReadOnly = true;
                        tBIP2.ReadOnly = true;
                        tBIP3.ReadOnly = true;
                        tBIP4.ReadOnly = true;
                        txtPCName.ReadOnly = true;
                        tBPCDescript.ReadOnly = true;
                        cBoxActivo.Enabled = false;
                        DBRefreshEntites();
                        
                        break;
                    }
            }
        }

        public string PCName
        {
            get { return txtPCName.Text; }
            set { txtPCName.Text = value; }
        }
        public string PCDescription
        {
            get { return tBPCDescript.Text; }
            set { tBPCDescript.Text = value; }
        }

        public string PCDomianText
        {
            set
            {
                cbDominio.Visible = false;
                TextBox tBDominio = new TextBox();
                tBDominio.Parent = cbDominio.Parent;
                tBDominio.Location = cbDominio.Location;
                tBDominio.Size = cbDominio.Size;
                tBDominio.Text = value;
                tBDominio.ReadOnly = true;
                panelDominio.Controls.Add(tBDominio);
            }
        }
        
        public WinDomainEntity PCDomain
        {
            get { return (WinDomainEntity)cbDominio.SelectedValue; }
            set {
                if (value != null)
                {
                    for (int i = 0; i < cbDominio.Items.Count; i++)
                    {
                        if (value.NtName.ToUpper() == cbDominio.Items[i].ToString().ToUpper())
                        {
                            cbDominio.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        public bool IsWindowsPC
        {
            get { return m_IsWindows; }
            set { m_IsWindows = value;}
        }

        public string PcIP
        {
            get 
            {
                if (tBIP1.Text == "" && tBIP2.Text == "" && tBIP3.Text == "" && tBIP4.Text == "")
                {
                    return "";
                }
                else
                {
                    return tBIP1.Text + "." + tBIP2.Text + "." + tBIP3.Text + "." + tBIP4.Text;
                }
            }
            set 
            {
                if (value != null && value != "")
                {
                    string[] segments = value.Split('.');
                    tBIP1.Text = segments[0];
                    tBIP2.Text = segments[1];
                    tBIP3.Text = segments[2];
                    tBIP4.Text = segments[3];
                }
            }
        }

  
        private void FAltaPc_Load(object sender, EventArgs e)
        {

        }

        private void tBIP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else 
            {
                if ((e.KeyChar == 46) || (tBIP1.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                     tBIP2.Focus();
                    tBIP2.SelectAll();
                }
            }
        }

        private void tBIP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 46) || (tBIP2.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                    tBIP3.Focus();
                    tBIP3.SelectAll();
                }
                else if ((e.KeyChar == 8) && (tBIP2.Text.Length == 0))
                {
                    tBIP1.Focus();
                    tBIP1.SelectAll();
                }

            }
        }

        private void tBIP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 46) || (tBIP3.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                    tBIP4.Focus();
                    tBIP4.SelectAll();
                }
                else if ((e.KeyChar == 8) && (tBIP3.Text.Length == 0))
                {
                    tBIP2.Focus();
                    tBIP2.SelectAll();
                }

            }

        }

        private void tBIP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 8) && (tBIP4.Text.Length == 0))
                {
                    tBIP3.Focus();
                    tBIP3.SelectAll();
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (m_FormType == FormType.View)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.OK;

            if (m_IsWindows && cbDominio.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un dominio");
                return;
            }

            if (txtPCName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre del equipo");
                this.DialogResult = DialogResult.None;
                return;
            }

/*            if (tBIP1.Text.Equals(string.Empty) || tBIP2.Text.Equals(string.Empty) ||
                tBIP3.Text.Equals(string.Empty) || tBIP4.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar una IP válida");
                this.DialogResult = DialogResult.None;
                return;
            }
            */
            if (m_FormType == FormType.New)
            {
                try
                {
                    if (IsWindowsPC)
                    {
                        if (!m_WinPCBusiness.Exists(PCDomain.NtName, PCName))
                        {
                            WinPCEntity winPC = new WinPCEntity();
                            winPC.Name = PCName;
                            winPC.PcIP = PcIP;
                            winPC.WinDomain = PCDomain;
                            winPC.Desc = PCDescription;
                            winPC.Active = cBoxActivo.Checked;
                            winPC.Checkable = chkEquipoChequeable.Checked;
                            m_WinPCBusiness.Create(winPC);
                            MessageBox.Show("Se dió de alta el equipo");
                        }
                        else
                        {
                            if (MessageBox.Show("El equipo ya existe en el sistema. " + Environment.NewLine +
                                                "Desea Actualizar el equipo con los datos actuales?", "Actualizar PC", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                            == DialogResult.Yes)
                            {
                                m_CurrentPC = m_WinPCBusiness.FillData(m_CurrentPC);
                                m_CurrentPC.Name = PCName;
                                m_CurrentPC.PcIP = PcIP;
                                m_CurrentPC.WinDomain = (WinDomainEntity)cbDominio.SelectedValue;
                                m_CurrentPC.Desc = PCDescription;
                                m_CurrentPC.Active = cBoxActivo.Checked;
                                m_CurrentPC.Checkable = chkEquipoChequeable.Checked;
                                // ver si tiene contraseñas y segun checked habilita o deshabilita
                                m_WinPCBusiness.Update(m_CurrentPC);
                                MessageBox.Show("Se actualizó el equipo");
                            }

                        }
                    }
                    else
                    {
                        if (!m_UnixPCBusiness.Exists(PCName))
                        {
                            UnixEntity UnixPC = new UnixEntity();
                            UnixPC.ServerName = PCName;
                            UnixPC.Ip = PcIP;
                            UnixPC.Desc = tBPCDescript.Text.Trim();
                            UnixPC.Active = cBoxActivo.Checked;
                            m_UnixPCBusiness.Create(UnixPC);
                            MessageBox.Show("Se dió de alta el equipo");
                        }
                        else
                        {
                            if (MessageBox.Show("El equipo ya existe en el sistema. " + Environment.NewLine +
                                                "Desea Actualizar el equipo con los datos actuales?", "Actualizar PC", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                            == DialogResult.Yes)
                            {
                                m_CurrentUnixPC = m_UnixPCBusiness.FillData(m_CurrentUnixPC);
                                m_CurrentUnixPC.ServerName = PCName;
                                m_CurrentUnixPC.Ip = PcIP;
                                m_CurrentUnixPC.Active = cBoxActivo.Checked;
                                // ver si tiene contraseña y segun checked hab o deshab
                                bool GrabaEquipo = true;
                                if (m_CurrentUnixPC.Id > 0 && m_CurrentUnixPC.Active != _estadoOriginal)
                                {
                                    // ver si tiene contraseña y segun checked hab o deshab
                                    UnixUserBusiness UnixUsrsB = new UnixUserBusiness();
                                    UnixUserEntityCollection UnixUsrs = UnixUsrsB.GetPCUsers(m_CurrentUnixPC);
                                    if (UnixUsrs.CountEstado(!cBoxActivo.Checked) > 0)
                                    {
                                        GrabaEquipo = false;
                                        FEqPwd formActDesPwd = new FEqPwd(m_CurrentUnixPC, cBoxActivo.Checked);
                                        if (formActDesPwd.ShowDialog() == DialogResult.OK)
                                        {
                                             GrabaEquipo = true;
                                        }
                                    }
                                }
                                if (GrabaEquipo)
                                {
                                    m_UnixPCBusiness.Update(m_CurrentUnixPC);
                                }
                                MessageBox.Show("El equipo fue actualizado");
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error al dar de alta el equipo: " + Environment.NewLine + exp.Message);
                }
            }
            else if (m_FormType == FormType.Update)
            {
                if (m_IsWindows)
                {
                    try
                    {
                        m_CurrentPC.Name = PCName;
                        m_CurrentPC.PcIP = PcIP;
                        m_CurrentPC.Desc = PCDescription;
                        m_CurrentPC.WinDomain = (WinDomainEntity)cbDominio.SelectedValue;
                        m_CurrentPC.Active = cBoxActivo.Checked;
                        m_CurrentPC.Checkable = chkEquipoChequeable.Checked;
                        
                        bool GrabaEquipo = true;
                        if (m_CurrentPC.Id > 0 && m_CurrentPC.Active != _estadoOriginal)
                        {
                            // ver si tiene contraseña y segun checked hab o deshab
                            WinLocalUserBusiness WinUsrsB = new WinLocalUserBusiness();
                            WinLocalUserEntityCollection WinUsrs = WinUsrsB.GetPCUsers(m_CurrentPC);
                            if (WinUsrs.CountEstado(!cBoxActivo.Checked) > 0)
                            {
                                GrabaEquipo = false;
                                FEqPwd formActDesPwd = new FEqPwd(m_CurrentPC, cBoxActivo.Checked);
                                if (formActDesPwd.ShowDialog() == DialogResult.OK)
                                {
                                    GrabaEquipo = true;
                                }
                            }
                        }
                        if (GrabaEquipo)
                        {
                            m_WinPCBusiness.Update(m_CurrentPC);
                        }
                        
                        MessageBox.Show("El equipo fue modificado");
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error al modificar el equipo: " + Environment.NewLine + exp.Message);
                    }
                }
                else
                {
                    try
                    {
                        m_CurrentUnixPC.ServerName = PCName;
                        m_CurrentUnixPC.Ip = PcIP;
                        m_CurrentUnixPC.Desc = PCDescription;
                        m_CurrentUnixPC.Active = cBoxActivo.Checked;
                        bool GrabaEquipo = true;
                        if (m_CurrentUnixPC.Id > 0 && m_CurrentUnixPC.Active != _estadoOriginal)
                        {
                            // ver si tiene contraseña y segun checked hab o deshab
                            UnixUserBusiness UnixUsrsB = new UnixUserBusiness();
                            UnixUserEntityCollection UnixUsrs = UnixUsrsB.GetPCUsers(m_CurrentUnixPC);
                            if (UnixUsrs.CountEstado(!cBoxActivo.Checked) > 0)
                            {
                                GrabaEquipo = false;
                                FEqPwd formActDesPwd = new FEqPwd(m_CurrentUnixPC, cBoxActivo.Checked);
                                if (formActDesPwd.ShowDialog() == DialogResult.OK)
                                {
                                    GrabaEquipo = true;
                                }
                            }
                        }
                        if (GrabaEquipo)
                        {
                            m_UnixPCBusiness.Update(m_CurrentUnixPC);
                            MessageBox.Show("El equipo fue modificado");
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error al modificar el equipo: " + Environment.NewLine + exp.Message);
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pNetFind_Click(object sender, EventArgs e)
        {
            if (m_IsWindows)
            {
                if (cbDominio.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un dominio de busqueda");
                    return;
                }

                FSelectWinPC selWinPC = new FSelectWinPC((WinDomainEntity)cbDominio.SelectedValue);
                selWinPC.Title = "Busqueda de equipos Windows en " + ((WinDomainEntity)cbDominio.SelectedValue).NtName;
                if (selWinPC.ShowDialog() == DialogResult.OK)
                {
                    WinPCEntity selWinPCEntity = (WinPCEntity)selWinPC.GetSelectedEntity();
                    if (selWinPCEntity != null)
                    {
                        m_CurrentPC = selWinPCEntity;
                        txtPCName.Text = selWinPCEntity.Name;
                        this.PcIP = selWinPCEntity.PcIP;
                    }
                }
            }
            else 
            {
                FSelectWinPC selUnixPC = new FSelectWinPC();
                selUnixPC.Title = "Busqueda de equipos Unix";
                if (selUnixPC.ShowDialog() == DialogResult.OK)
                {
                    UnixEntity selUnixPCEntity = (UnixEntity)selUnixPC.GetSelectedEntity();
                    if (selUnixPCEntity != null)
                    {
                        m_CurrentUnixPC = selUnixPCEntity;
                        txtPCName.Text = selUnixPCEntity.ServerName;
                        this.PcIP = selUnixPCEntity.Ip;
                    }
                }
            }
        }

        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;
        }

        UnixUserEntityCollection _entitiesUnix;
        WinLocalUserEntityCollection _entitiesWindows;

        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            if (m_CurrentUnixPC != null)
            {
                UnixUserBusiness UsrBL = new UnixUserBusiness();
                UsrBL.SetOrderByFolio();
                UsrBL.GetGruposAsignados = true;
                UsrBL.FilUsuariosActivos = true;
                UsrBL.FilEquipoUnix = m_CurrentUnixPC;
                _entitiesUnix = UsrBL.GetAll();
            }
            if (m_CurrentPC != null)
            {
                WinLocalUserBusiness UsrBL = new WinLocalUserBusiness();
                UsrBL.SetOrderByFolio();
                UsrBL.GetGruposAsignados = true;
                UsrBL.FilUsuariosActivos = true;
                UsrBL.FilWinPC = m_CurrentPC;
                _entitiesWindows = UsrBL.GetAll();
            }


        }
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }

        private void SetLVItems(ListViewItem[] lviArr)
        {
            this.lvLista.Items.Clear();
            if (lviArr.Length > 0)
            {

                this.lvLista.Items.AddRange(lviArr);
            }
        }

        private ListViewItem[] GenerateLVItems()
        {
            if (m_CurrentUnixPC != null)
            {
                ListViewItem[] lviArr = new ListViewItem[this._entitiesUnix.Count];
                int i = 0;
                foreach (UnixUserEntity UsrEnt in this._entitiesUnix)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(UsrEnt.Key);
                    lviArr[i].SubItems.Add(UsrEnt.Username);
                    lviArr[i].SubItems.Add(UsrEnt.Critical ? "Si" : "No");
                    lviArr[i].Text = "";
                    lviArr[i].ImageIndex = UsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = UsrEnt;
                    i++;
                }
                return lviArr;
            }
            else            
            {
                ListViewItem[] lviArr = new ListViewItem[this._entitiesWindows.Count];
                int i = 0;
                foreach (WinLocalUserEntity UsrEnt in this._entitiesWindows)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(UsrEnt.Key);
                    lviArr[i].SubItems.Add(UsrEnt.Username);
                    lviArr[i].SubItems.Add(UsrEnt.Critical ? "Si" : "No");
                    lviArr[i].Text = "";
                    lviArr[i].ImageIndex = UsrEnt.ActiveUser ? 0 : 1;
                    lviArr[i].Tag = UsrEnt;
                    i++;
                }
                return lviArr;
            }

        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
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

