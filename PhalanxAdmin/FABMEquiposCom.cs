using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxBL;

namespace PhalanxAdmin
{
    public partial class FABMEquiposCom : PhalanxAdmin.FModalBase
    {
        CommunicationDeviceEntity _entity = new CommunicationDeviceEntity();
        bool _readOnly = false;
        private bool _estadoOriginal = true;

        private TextBox txtCDType;

        private string CDName
        {
            get { return txtCDName.Text; }
            set { txtCDName.Text = value; }
        }

        private string Description
        {
            get { return txtDesc.Text; }
            set { txtDesc.Text = value; }
        }

        private string IP
        {
            get
            {
                if (txtIP1.Text == string.Empty || txtIP2.Text == string.Empty || txtIP3.Text == string.Empty || txtIP4.Text == string.Empty)
                    return string.Empty;
                else
                    return txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
            }
            set
            {
                if (value != null && value != string.Empty)
                {
                    string[] segments = value.Split('.');

                    if (segments.Length == 4)
                    {
                        txtIP1.Text = segments[0];
                        txtIP2.Text = segments[1];
                        txtIP3.Text = segments[2];
                        txtIP4.Text = segments[3];
                    }
                }
            }
        }

        private bool Activo
        {
            set { cBoxActivo.Checked = value; }
            get { return cBoxActivo.Checked; }
        }

        private CommunicationDeviceTypeEntity Type
        {
            get
            {
                if (!_readOnly)
                    return cbCDType.SelectedItem as CommunicationDeviceTypeEntity;

                return null;
            }
            set
            {
                if (!_readOnly)
                    cbCDType.SelectedItem = value;
                else
                    txtCDType.Text = value.Name;  
            }
        }

        public FABMEquiposCom()
        {
            InitializeComponent();
        }

        public FABMEquiposCom(CommunicationDeviceEntity CommunicationDevice, bool ReadOnly)
            : this()
        {
            _entity = CommunicationDevice;
            
            _estadoOriginal = _entity.Active;
            _readOnly = ReadOnly;
            lvLista.ListViewItemSorter = new cwxSorter();
        }

        private void FABMEquiposCom_Load(object sender, EventArgs e)
        {
            base.Title = "Equipo de Comunicación";

            CargarProtocolos();

            if (_readOnly)
                DeshabilitarControles();
            else
                CargarComboTipos();

            if (_entity.Id != 0)
            {
                CDName = _entity.Name;
                Type = _entity.Type;
                Description = _entity.Description;
                IP = _entity.IP;
                Activo = _entity.Active;
                DBRefreshEntites();
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            }
        }

        private void DeshabilitarControles()
        {
            txtCDType = new TextBox();
            txtCDType.Location = cbCDType.Location;
            txtCDType.ReadOnly = true;
            txtCDType.Width = cbCDType.Width;
            txtCDType.Height = cbCDType.Height;
            this.Controls.Add(txtCDType);
            cbCDType.Visible = false;

            txtCDName.ReadOnly = true;
            txtDesc.ReadOnly = true;
            txtIP1.ReadOnly = true;
            txtIP2.ReadOnly = true;
            txtIP3.ReadOnly = true;
            txtIP4.ReadOnly = true;

            clbCDProtocols.Enabled = false;

            // deshabilita boton cancelar
            btnCancelar.Enabled = false;
            // deshabilita cambio de estado
            cBoxActivo.Enabled = false;
        }

        private void CargarComboTipos()
        {
            CommunicationDeviceTypeBusiness CDTypeBL = new CommunicationDeviceTypeBusiness();
            cbCDType.DataSource = CDTypeBL.GetAll();
        }

        private void CargarProtocolos()
        {
            CommunicationDeviceProtocolBusiness CDProtocolBL = new CommunicationDeviceProtocolBusiness();
            
            foreach (CommunicationDeviceProtocolEntity protocol in CDProtocolBL.GetAll())
            {
                ListViewItem item = new ListViewItem();
                item.Text = protocol.Name;
                item.Tag = protocol;
                item.Checked = _entity.Protocols.Contains(protocol);
                
                clbCDProtocols.Items.Add(item);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            // si es visualización sale
            if (_readOnly)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            CommunicationDeviceBusiness CommunicationDeviceBL = new CommunicationDeviceBusiness();

            string errorMessage = null;

            string nombre = CDName.Trim();

            if (string.IsNullOrEmpty(nombre))
                errorMessage = "Debe ingresar un Nombre";
            else if (string.IsNullOrEmpty(IP))
                errorMessage = "Debe ingresar la dirección IP";
            else if (!ValidarIP())
                errorMessage = "La dirección IP es inválida";
            else if (Type == null)
                errorMessage = "Debe ingresar el tipo de equipo de comunicación";
            else if (CommunicationDeviceBL.Exists(nombre, _entity.Id))
                errorMessage = "Ya existe un equipo de comunicación con ese nombre";

            if (errorMessage != null)
            {
                MessageBox.Show(errorMessage);

                return;
            }

            // grabo DB
            _entity.Name = nombre;
            _entity.Description = Description;
            _entity.Type = Type;
            _entity.IP = IP;
            _entity.Active = Activo;
            
            bool GrabaDB = true;

            IDictionary<CommunicationDeviceProtocolEntity, CommunicationDeviceUserEntityCollection> usuarioProtRemover = new Dictionary<CommunicationDeviceProtocolEntity, CommunicationDeviceUserEntityCollection>();

            foreach (ListViewItem lvProtocol in clbCDProtocols.Items)
            {
                CommunicationDeviceProtocolEntity protocol = (CommunicationDeviceProtocolEntity)lvProtocol.Tag;

                bool existe = _entity.Protocols.Contains(protocol);

                if (lvProtocol.Checked && !existe)
                     _entity.Protocols.Add(protocol);

                 if (!lvProtocol.Checked && existe)
                 {
                     CommunicationDeviceUserBusiness CDUBL = new CommunicationDeviceUserBusiness();

                     CDUBL.FilEC = _entity;
                     CDUBL.FilProtocol = protocol;

                     CommunicationDeviceUserEntityCollection usuarios = CDUBL.GetAll();

                     if (usuarios.Count > 0)
                         usuarioProtRemover.Add(protocol, usuarios);

                     //Verificar si hay usuarios para este par de equipo/protocolo
                     _entity.Protocols.Remove(protocol);
                 }
            }

            
            if (usuarioProtRemover.Count > 0)
            {
                FUsProtocolo formDesUsProtocolos = new FUsProtocolo(usuarioProtRemover);

                if (formDesUsProtocolos.ShowDialog() != DialogResult.OK)
                    GrabaDB = false;
            }
              
            if (GrabaDB && _entity.Id > 0 && _entity.Active != _estadoOriginal)
            {
                CommunicationDeviceUserBusiness CDUBL = new CommunicationDeviceUserBusiness();
                
                CommunicationDeviceUserEntityCollection CDUEC = CDUBL.GetCDUsers(_entity);
                
                if (CDUEC.CountEstado(!cBoxActivo.Checked) > 0)
                {
                    GrabaDB = false;
                    // abre form
                    FEqPwd formActDesPwd = new FEqPwd(_entity, cBoxActivo.Checked);
                    
                    if (formActDesPwd.ShowDialog() == DialogResult.OK)
                        GrabaDB = true;
                }
            }
            
            if (GrabaDB)
            {
                int Id = CommunicationDeviceBL.Save(_entity, usuarioProtRemover.Keys);
                
                if (Id > 0)
                {
                    _entity.Id = Id;
                    MessageBox.Show("Se grabó la información del Equipo de Comunicación");

                }
                else
                {
                    MessageBox.Show("Hubo un error al grabar el Equipo de Comunicación", "Equipo de Comunicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cancelar la operación?", "Equipo de Comunicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    == DialogResult.No)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        
        private void cBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            picDesactivo.Visible = !cBoxActivo.Checked;
            picActivo.Visible = cBoxActivo.Checked;
        }

        private void txtIP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 46) || (txtIP1.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                    
                    txtIP2.Focus();
                    txtIP2.SelectAll();
                }
            }
        }

        private void txtIP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 46) || (txtIP2.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                    txtIP3.Focus();
                    txtIP3.SelectAll();
                }
                else if ((e.KeyChar == 8) && (txtIP2.Text.Length == 0))
                {
                    txtIP1.Focus();
                    txtIP1.SelectAll();
                }
            }
        }

        private void txtIP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 46 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 46) || (txtIP3.Text.Length > 1) && (e.KeyChar != 8))
                {
                    if (e.KeyChar == 46)
                        e.Handled = true;
                    txtIP4.Focus();
                    txtIP4.SelectAll();
                }
                else if ((e.KeyChar == 8) && (txtIP3.Text.Length == 0))
                {
                    txtIP2.Focus();
                    txtIP2.SelectAll();
                }
            }
        }

        private void txtIP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == 8) && (txtIP4.Text.Length == 0))
                {
                    txtIP3.Focus();
                    txtIP3.SelectAll();
                }
            }
        }

        private bool ValidarIP()
        {
            string[] octetos = { txtIP1.Text, txtIP2.Text, txtIP3.Text, txtIP4.Text };

            int valorOcteto;

            foreach (string octeto in octetos)
                if (!(int.TryParse(octeto, out valorOcteto) && valorOcteto >= 0 && valorOcteto < 256))
                    return false;

            return true;
        }

        CommunicationDeviceUserEntityCollection _entities;

        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void LoadEntities()
        {
            CommunicationDeviceUserBusiness UsrBL = new CommunicationDeviceUserBusiness();
            UsrBL.SetOrderByFolio();
            UsrBL.GetGruposAsignados = true;
            UsrBL.FilUsuariosActivos = true;
            UsrBL.FilEC = _entity;
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
            foreach (CommunicationDeviceUserEntity UsrEnt in this._entities)
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

