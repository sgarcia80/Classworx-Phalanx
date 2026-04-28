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
    public partial class FSelEquipo : PhalanxAdmin.FBaseSelect
    {
        private UnixEntity _UnixPC;
        private AS400Entity _AS400PC;
        private WinPCEntity _WinPC;
        public bool OnlyWinPc = false;
        public bool OnlyUnixPc = false;
        public bool OnlyAS400Pc = false;
        public WinDomainEntity WinDomain = null;
        /// <summary>
        /// este constructor se usa para compatibilidad para cuando existia AS400
        /// </summary>
        public FSelEquipo()
        {
            InitializeComponent();
            rbAS400.Visible = false;
        }
        public UnixEntity UnixPCSelected
        {
            get { return _UnixPC; }
        }
        public AS400Entity AS400PCSelected
        {
            get { return _AS400PC; }
        }
        public WinPCEntity WinPCSelected
        {
            get { return _WinPC; }
        }

        protected override ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;

            if (rbWin.Checked)
            {
                foreach (WinPCEntity WinPCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    //lviArr[i].SubItems.Add(WinPCEnt.PcIP);
                    lviArr[i].Text = WinPCEnt.WinDomain.NtName + @"\" + WinPCEnt.Name;
                    lviArr[i].Tag = WinPCEnt;
                    i++;
                }
            }
            else if (rbUnix.Checked)
            {
                foreach (UnixEntity UnixPCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    //lviArr[i].SubItems.Add(UnixPCEnt.Ip);
                    lviArr[i].Text = UnixPCEnt.ServerName;
                    lviArr[i].Tag = UnixPCEnt;
                    i++;
                }
            }
            else if (rbAS400.Checked)
            {
                foreach (AS400Entity AS400PCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    //lviArr[i].SubItems.Add(AS400PCEnt.Ip);
                    lviArr[i].Text = AS400PCEnt.ServerName;
                    lviArr[i].Tag = AS400PCEnt;
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
            if (rbWin.Checked)
            {
                WinPCBusiness WinPCBL = new WinPCBusiness();
                if (WinDomain != null)
                {
                    WinPCBL.FilDominio = WinDomain;
                }
                WinPCBL.FilNombre = txtFilNombre.Text.Trim();
                WinPCBL.FilActivo = true;
                this._entities = WinPCBL.GetAll();
            }
            else if (rbUnix.Checked)
            {
                UnixPCBusiness UnixPCBL = new UnixPCBusiness();
                UnixPCBL.FilNombre = txtFilNombre.Text.Trim();
                UnixPCBL.FilActivo = true;
                this._entities = UnixPCBL.GetAll();
            }
            else if (rbAS400.Checked)
            {
                AS400Business AS400PCBL = new AS400Business();
                AS400PCBL.FilNombre = txtFilNombre.Text.Trim();
                AS400PCBL.FilActivo = true;
                this._entities = AS400PCBL.GetAll();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedItems.Count == 1)
            {
                if (lvLista.SelectedItems[0].Tag is WinPCEntity)
                {
                    _WinPC = (WinPCEntity)lvLista.SelectedItems[0].Tag;
                    _UnixPC = null;
                    _AS400PC = null;
                }
                else if (lvLista.SelectedItems[0].Tag is UnixEntity)
                {
                    _UnixPC = (UnixEntity)lvLista.SelectedItems[0].Tag;
                    _WinPC = null;
                    _AS400PC = null;
                }
                else if (lvLista.SelectedItems[0].Tag is AS400Entity)
                {
                    _AS400PC = (AS400Entity)lvLista.SelectedItems[0].Tag;
                    _WinPC = null;
                    _UnixPC = null;
                }

                this.DialogResult = DialogResult.OK;
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            _UnixPC = null;
            _WinPC = null;
            _AS400PC = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void FSelEquipo_Load(object sender, EventArgs e)
        {
            if (this.OnlyWinPc)
            {
                rbWin.Checked = true;
                rbWin.Visible = false;
                rbUnix.Visible = false;
                rbAS400.Visible = false;
            }
            else if (this.OnlyUnixPc)
            {
                rbUnix.Checked = true;
                rbWin.Visible = false;
                rbUnix.Visible = false;
                rbAS400.Visible = false;
            }
            else if (this.OnlyAS400Pc)
            {
                rbAS400.Checked = true;
                rbUnix.Visible = false;
                rbWin.Visible = false;
                rbAS400.Visible = false;
            }
        }
    }
}