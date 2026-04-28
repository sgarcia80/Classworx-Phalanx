using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxCommon;
using PhalanxBL;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FABMEquipo : PhalanxAdmin.FModalBase
    {
        private WinPCEntity m_CurrentWinPC = null;
        private UnixEntity m_CurrentUnixPC = null;
        private AS400Entity m_CurrentAS400 = null;
        private WinDomainBusiness m_WinDomBusiness = null;
        private WinPCBusiness m_WinPCBusiness = null;
        private UnixPCBusiness m_UnixPCBusiness = null;
        private AS400Business m_AS400Business = null;
        private bool _estadoOriginal = true;

        private bool m_readonly = false;
        private PCType m_PCType;

        private enum PCType
        {
            Windows,
            Unix,
            AS400
        }

        #region Constructors
        public FABMEquipo()
        {
            InitializeComponent();
        }
        public FABMEquipo(object Equipo, bool Readonly) : this()
        {
            m_readonly = Readonly;

            if (Equipo is WinPCEntity)
            {
                m_CurrentWinPC = (WinPCEntity)Equipo;
                m_PCType = PCType.Windows;
                m_WinPCBusiness = new WinPCBusiness();
                m_WinDomBusiness = new WinDomainBusiness();
            }
            else if (Equipo is UnixEntity)
            {
                m_CurrentUnixPC = (UnixEntity)Equipo;
                m_PCType = PCType.Unix;
                m_UnixPCBusiness = new UnixPCBusiness();
                _estadoOriginal = m_CurrentUnixPC.Active;
                cBoxActivo.Checked = m_CurrentUnixPC.Active;

            }
            else if (Equipo is AS400Entity)
            {
                m_CurrentAS400 = (AS400Entity)Equipo;
                m_PCType = PCType.AS400;
                m_AS400Business = new AS400Business();
                _estadoOriginal = m_CurrentAS400.Active;
                cBoxActivo.Checked = m_CurrentAS400.Active;
                if (m_CurrentAS400.Id == 0)
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
                }
                else
                {
                    DBRefreshEntites();
                }
            }
            else // no es de ningún tipo especificado
            {
                this.Close();
                throw (new CwxException("Tipo de Equipo desconocido"));
            }
            lvLista.ListViewItemSorter = new cwxSorter(); 

        }
        #endregion

        #region Properties
        private string PCDomainText
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

        private WinDomainEntity PCDomain
        {
            get { return (WinDomainEntity)cbDominio.SelectedValue; }
            set
            {
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
        private string PcIP
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
        private string PCName
        {
            get { return txtPCName.Text; }
            set { txtPCName.Text = value; }
        }
        private string PCDescription
        {
            get { return tBPCDescript.Text; }
            set { tBPCDescript.Text = value; }
        }
        private bool IsNew
        {
            get
            {
                switch (m_PCType)
                {
                    case PCType.Windows:
                        return (m_CurrentWinPC.Id == 0 ? true : false);                        
                        break;
                    case PCType.Unix:
                        return (m_CurrentUnixPC.Id == 0 ? true : false);                        
                        break;
                    case PCType.AS400:
                        return (m_CurrentAS400.Id == 0 ? true : false);                        
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }
        #endregion

        #region Events
        private void FABMEquipo_Load(object sender, EventArgs e)
        {
            ConfigureScreen();

            switch (m_PCType)
            {
                case PCType.Windows:
                    cbDominio.Focus();
                    //this.Title = "Equipo Windows";
                    if (m_readonly)
                    {
                        PCDomainText = m_CurrentWinPC.WinDomain.NtName;
                    }
                    else
                    {
                        PCDomain = m_CurrentWinPC.WinDomain;
                    }
                    PcIP = m_CurrentWinPC.PcIP;
                    PCName = m_CurrentWinPC.Name;
                    PCDescription = m_CurrentWinPC.Desc;
                    _estadoOriginal = m_CurrentWinPC.Active;
                    cBoxActivo.Checked = m_CurrentWinPC.Active;
                    break;
                case PCType.Unix:
                    txtPCName.Focus();
                    //this.Title = "Equipo Unix";
                    PcIP = m_CurrentUnixPC.Ip;
                    PCName = m_CurrentUnixPC.ServerName;
                    PCDescription = m_CurrentUnixPC.Desc;
                    break;
                case PCType.AS400:
                    txtPCName.Focus();
                    //this.Title = "Equipo AS400";
                    PcIP = m_CurrentAS400.Ip;
                    PCName = m_CurrentAS400.ServerName;
                    PCDescription = m_CurrentAS400.Desc;
                    _estadoOriginal = m_CurrentAS400.Active;
                    cBoxActivo.Checked = m_CurrentAS400.Active;
                    break;
                default:
                    break;
            }

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
            // si es visualizacion sale
            if (m_readonly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.OK;

            if (m_PCType == PCType.Windows && cbDominio.SelectedIndex == -1)
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

            try
            {
                bool GrabaEquipo = true;
                switch (m_PCType)
                {
                    case PCType.Windows:
                        // chequea si ya existe el equipo
                        if (!m_WinPCBusiness.Exists(PCDomain.NtName, PCName, m_CurrentWinPC.Id))
                        {
                            m_CurrentWinPC.Name = PCName;
                            m_CurrentWinPC.PcIP = PcIP;
                            m_CurrentWinPC.WinDomain = PCDomain;
                            m_CurrentWinPC.Desc = PCDescription;
                            if (m_CurrentWinPC.Id == 0)
                            {
                                m_WinPCBusiness.Create(m_CurrentWinPC);
                                MessageBox.Show("Se dió de alta el equipo");
                                return;
                            }
                            else // es update
                            {
                                m_WinPCBusiness.Update(m_CurrentWinPC);
                                MessageBox.Show("El equipo fue modificado");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El equipo ya existe en el sistema.");
                            this.DialogResult = DialogResult.None;
                            return;
                        }

                        break;
                    case PCType.Unix:
                        // chequea si ya existe el equipo en el sistema
                        if (!m_UnixPCBusiness.Exists(PCName, m_CurrentUnixPC.Id))
                        {
                            m_CurrentUnixPC.ServerName = PCName;
                            m_CurrentUnixPC.Ip = PcIP;
                            m_CurrentUnixPC.Desc = tBPCDescript.Text.Trim();
                            m_CurrentUnixPC.Active = cBoxActivo.Checked;
                            if (m_CurrentWinPC.Id == 0)
                            {
                                m_UnixPCBusiness.Create(m_CurrentUnixPC);
                                MessageBox.Show("Se dió de alta el equipo");
                                return;
                            }
                            else // es update
                            {
                                // ver si tiene contraseña y segun checked hab o deshab
                                if (m_CurrentWinPC.Id > 0 && m_CurrentUnixPC.Active != _estadoOriginal)
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
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("El equipo ya existe en el sistema. " + Environment.NewLine +
                                                "Desea Actualizar el equipo con los datos actuales?", "Actualizar Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                            == DialogResult.Yes)
                            {
                                m_CurrentUnixPC = m_UnixPCBusiness.FillData(m_CurrentUnixPC);
                                m_CurrentUnixPC.ServerName = PCName;
                                m_CurrentUnixPC.Ip = PcIP;
                                m_CurrentUnixPC.Active = cBoxActivo.Checked;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        if (GrabaEquipo)
                        {
                            m_UnixPCBusiness.Update(m_CurrentUnixPC);
                        }
                        MessageBox.Show("El equipo fue modificado");
                        break;
                    case PCType.AS400:
                        if (!m_AS400Business.Exists(PCName, m_CurrentAS400.Id))
                        {
                            m_CurrentAS400.ServerName = PCName;
                            m_CurrentAS400.Ip = PcIP;
                            m_CurrentAS400.Desc = tBPCDescript.Text.Trim();
                            m_CurrentAS400.Active = cBoxActivo.Checked;
                            if (m_CurrentAS400.Id == 0)
                            {
                                m_AS400Business.Create(m_CurrentAS400);
                                MessageBox.Show("Se dió de alta el equipo");
                                return;
                            }
                            else // es update
                            {
                                
                                // ver si tiene contraseña y segun checked hab o deshab
                                if (m_CurrentAS400.Id > 0 && m_CurrentAS400.Active != _estadoOriginal)
                                {
                                    // ver si tiene contraseña y segun checked hab o deshab
                                    AS400UserBusiness AS400UsrsB = new AS400UserBusiness();
                                    AS400UserEntityCollection AS400Usrs = AS400UsrsB.GetPCUsers(m_CurrentAS400);
                                    if (AS400Usrs.CountEstado(!cBoxActivo.Checked) > 0)
                                    {
                                        GrabaEquipo = false;
                                        FEqPwd formActDesPwd = new FEqPwd(m_CurrentAS400, cBoxActivo.Checked);
                                        if (formActDesPwd.ShowDialog() == DialogResult.OK)
                                        {
                                            GrabaEquipo = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El equipo ya existe en el sistema.");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                        if (GrabaEquipo)
                        {
                            m_AS400Business.Update(m_CurrentAS400);
                            MessageBox.Show("El equipo fue modificado");
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error al grabar: " + Environment.NewLine + exp.Message);
                this.DialogResult = DialogResult.None;
                return;

            }

            /*
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
                                m_UnixPCBusiness.Update(m_CurrentUnixPC);
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
                        m_WinPCBusiness.Update(m_CurrentPC);
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
                        m_UnixPCBusiness.Update(m_CurrentUnixPC);
                        MessageBox.Show("El equipo fue modificado");
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error al modificar el equipo: " + Environment.NewLine + exp.Message);
                    }

                }
            }*/
        }
        

        #endregion
        #region Methods
        private void ConfigureScreen()
        {
            if (m_PCType != PCType.Windows)
                panelDominio.Height = 0;

            if (m_readonly) // si es visualizacion
            {
                btnCancelar.Enabled = false;
                tBPCDescript.ReadOnly = true;
                tBIP1.ReadOnly = true;
                tBIP2.ReadOnly = true;
                tBIP3.ReadOnly = true;
                tBIP4.ReadOnly = true;
                txtPCName.ReadOnly = true;
                cBoxActivo.Enabled = false;
            }
            else // es editable (alta o modif)
            {
                if (IsNew)
                {
                    switch (m_PCType)
                    {
                        case PCType.Windows:
                            pNetFind.Visible = true;
                            cbDominio.DataSource = m_WinDomBusiness.GetAll();
                            break;
                        case PCType.Unix:
                            pNetFind.Visible = true;
                            break;
                        case PCType.AS400:
                            pNetFind.Visible = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;

        }

        AS400UserEntityCollection _entities;

        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            AS400UserBusiness UsrBL = new AS400UserBusiness();
            UsrBL.SetOrderByFolio();
            UsrBL.GetGruposAsignados = true;
            UsrBL.FilUsuariosActivos = true;
            UsrBL.FilEquipoAS400 = m_CurrentAS400;
            _entities = UsrBL.GetAll();
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
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (AS400UserEntity UsrEnt in this._entities)
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

