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
    public partial class FPCs : PhalanxAdmin.FBaseAdmin
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Equipos PC");
            }
        }

        protected WinPCEntityCollection _entities;
        protected UnixPCEntityCollection _entitiesUnix;
        protected WinDomainEntityCollection _dominios;
        private WinDomainEntity _filDominio;
        protected string _filNombre = "";

        public FPCs()
        {
            InitializeComponent();
        }

        public override string Id
        {
            get
            {
                return "PCs";
            }
        }

        private void FPCs_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            CargaComboDominios();
            //ExecEntitiesRefresh();
        }


        //protected virtual void InicializaFiltros
        /* Proceso de acceso a DB
         * 1 - ExecClientesRefresh
         * 2 - se ejecuta la función asociada al evento DoWork del background worker
         * 3 - DBRefreshEntites()
         * 4 - LoadEntities: acá regenera la lista de entidades
         * 5 - RefreshClientesLV: arma los listview items
         * 6 - SetLVItems: agrega los LVItems al LV mediante callbacks
         */
        /// <summary>
        /// Pone el form en estado de búsqueda, setea los filtros de búsqueda y arranda el BackgroundWorker
        /// </summary>
        private void ExecEntitiesRefresh()
        {
            if (lvLista.Columns.Count == 0)
            {
                //throw new Exception("Se deben definir las columnas del ListView");
            }

            this.Cursor = Cursors.WaitCursor;
            this.lnkCancelar.Visible = true;
            this.pbDB.Visible = true;
            this.lblStatus.Text = "Buscando...";
            SetQueryFilters();
            this.pnlFilters.Enabled = false;
            this.pnlList.Enabled = false;
            if (bwRefreshEntities.IsBusy)
            {
                bwRefreshEntities.CancelAsync();
            }
            else
            {
                this.bwRefreshEntities.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Setea las variables de filtros con los valores de los controles
        /// </summary>
        /// <example>
        /// private override void SetQueryFilters()
        /// {
        ///  _filNombre = txtFilFullname.Text;
        ///  _filEmpresa = txtFilEmpresa.Text;
        ///  _filEstado = ((EstadoClienteEntity)cbEstado.SelectedItem).Id;
        ///  _filCateg = ((CategoriaClienteEntity)cbCategoria.SelectedItem).Id;
        ///  _filLocalidad = ((LocalidadEntity)cbLocalidad.SelectedItem).Id;
        /// }
        /// </example>
        private void SetQueryFilters()
        {
            if (cbDominio.SelectedIndex > 0)
            {
                _filDominio = (WinDomainEntity)cbDominio.SelectedItem;
            }
            else
            {
                _filDominio = null;
            }

        }

        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            DBRefreshEntites();
        }
        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        /// <summary>
        /// Carga la lista de entidades a mostrar en el listview
        /// </summary>
        /// <example>
        /// protected override void LoadEntities()
        /// {
        ///     ClienteBusiness ClieBL = new ClienteBusiness();
        ///     this._entities = ClieBL.Load(_filNombre, _filEmpresa, _filEstado, _filCateg, _filLocalidad);
        /// }
        /// </example>
        private void LoadEntities()
        {
            if (rbWindows.Checked)
            {
                WinPCBusiness WinPCBL = new WinPCBusiness();
                // seteo filtros
                if (txtFilNombre.Text.Trim() != "")
                {
                    WinPCBL.FilNombre = txtFilNombre.Text.Trim();
                }
                WinPCBL.FilDominio = _filDominio;
                _entities = WinPCBL.GetAll();
            }
            else
            {
                UnixPCBusiness UnixPCBL = new UnixPCBusiness();
                // seteo filtros
                if (txtFilNombre.Text.Trim() != "")
                {
                    UnixPCBL.FilNombre = txtFilNombre.Text.Trim();
                }
                _entitiesUnix = UnixPCBL.GetAll();
            }
        }

        /// <summary>
        /// Llama a la función que genera el array de LV Items y si hay items llama a la que hace el llenado
        /// usando el delegado
        /// </summary>
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }
        delegate void SetItemsAddRangeCallback(ListViewItem[] lvitems);

        /// <summary>
        /// Llena el Listview con los items pasados en el array
        /// </summary>
        /// <param name="lviArr">Array de Listview Items para llenar el Listview</param>
        private void SetLVItems(ListViewItem[] lviArr)
        {
            if (this.lvLista.InvokeRequired)
            {
                SetItemsAddRangeCallback d = new SetItemsAddRangeCallback(SetLVItems);
                this.Invoke(d, new object[] { lviArr });
            }
            else
            {
                this.lvLista.Items.Clear();
                if (lviArr.Length > 0)
                {
                    this.lvLista.Items.AddRange(lviArr);
                }
            }
        }

        /// <summary>
        /// Genera los list view items para llenar el list view
        /// </summary>
        /// <example>
        /// private void RefreshClientesLV()
        /// {
        ///     ListViewItem[] lviArr = new ListViewItem[this._clientes.Count];
        ///     int i = 0;
        ///     foreach (ClienteEntity ClieEnt in this._clientes)
        ///     {
        ///         lviArr[i] = new ListViewItem();
        ///         if (ClieEnt.Categoria == null)
        ///         {
        ///             lviArr[i].SubItems.Add("");
        ///         }
        ///         else
        ///         {
        ///             lviArr[i].SubItems.Add(ClieEnt.Categoria.Categoria);
        ///         }
        ///         if (ClieEnt.Empresa == null)
        ///         {
        ///             lviArr[i].SubItems.Add("");
        ///         }
        ///         else
        ///         {
        ///             lviArr[i].SubItems.Add(ClieEnt.Empresa.Nombre);
        ///         }
        ///         lviArr[i].Text = ClieEnt.NombreCompleto;
        ///         lviArr[i].Tag = ClieEnt;
        ///         i++;
        ///     }
        ///     return lviArr;
        /// }
        /// </example>
        /// <returns>Devuelve el arrary de list view items para llenar el listview</returns>
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr= null;
            if (rbWindows.Checked)
            {
                lviArr = new ListViewItem[this._entities.Count];
                int i = 0;
                foreach (WinPCEntity WinPCEnt in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(WinPCEnt.WinDomain.NtName);
                    lviArr[i].SubItems.Add(WinPCEnt.PcIP);
                    lviArr[i].Text = WinPCEnt.Name;
                    lviArr[i].Tag = WinPCEnt;
                    i++;
                }
            }
            else 
            {
                lviArr = new ListViewItem[this._entitiesUnix.Count];
                int i = 0;
                foreach (UnixEntity UnixPCEnt in this._entitiesUnix)
                {
                    string desc = string.Empty;
                    if (UnixPCEnt.Desc.Length > 25)
                        desc = UnixPCEnt.Desc.Substring(0, 25) + "...";
                    else
                        desc = UnixPCEnt.Desc;
                    lviArr[i] = new ListViewItem();
                    lviArr[i].SubItems.Add(desc);
                    lviArr[i].SubItems.Add(UnixPCEnt.Ip);
                    lviArr[i].Text = UnixPCEnt.ServerName;
                    lviArr[i].Tag = UnixPCEnt;
                    i++;
                }
            }
            return lviArr;
        }

        private void bwRefreshEntities_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                this.lblStatus.Text = "Cancelado";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                this.lblStatus.Text = "Listo"; // e.Result.ToString();
                this.lnkCancelar.Visible = false;
                this.pbDB.Visible = false;
                this.pnlFilters.Enabled = true;
                this.pnlList.Enabled = true;
                if (this.lvLista.Items.Count > 0)
                {
                    this.lvLista.Items[0].Selected = true;
                    this.lvLista.Focus();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ExecEntitiesRefresh();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtFilNombre.Text = "";
            cbDominio.SelectedIndex = 0;
        }

        private void lnkCancelar_Click(object sender, EventArgs e)
        {
            this.bwRefreshEntities.CancelAsync();
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            this.lblStatus.Text = "Cancelado";
            this.lvLista.Items.Clear();
            this.pnlFilters.Enabled = true;
            this.pnlList.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void CargaComboDominios()
        {
            WinDomainBusiness WinDomBL = new WinDomainBusiness();
            //ProvinciaEntityCollection ProvEC
            this._dominios = WinDomBL.FillFilter();
            cbDominio.DataSource = this._dominios;
        }

        private void lnkAdd_Click(object sender, EventArgs e)
        {
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.Update, lvLista.SelectedItems[0].Tag);
            fAltaPcs.Title = "Modificación de Equipo";
            if (fAltaPcs.ShowDialog() == DialogResult.OK)
            {
                ExecEntitiesRefresh();
            }
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.View, lvLista.SelectedItems[0].Tag);
            fAltaPcs.Title = "Visualización de Equipo";
            fAltaPcs.ShowDialog();
        }

        private void lnkDelete_Click(object sender, EventArgs e)
        {
            /*
            if (lvLista.SelectedItems.Count > 0)
            {
                FQuestion deletePC = new FQuestion();
                deletePC.Title = "Eliminar dominio del Sistema";
                string myItem = lvLista.SelectedItems[0].Text;
                string myDom= lvLista.SelectedItems[0].SubItems[1].Text;
                deletePC.Question = "Desea Eliminar del Sistema la PC " + myItem + Environment.NewLine +
                                     "Debe tener en cuenta que se eliminarán todos los usuarios asociados a esta Pc.";
                if (deletePC.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        m_WinPcsBus.Delete(myDom, myItem);
                        MessageBox.Show("PC Eliminada del sistema");
                        ExecEntitiesRefresh
                    }
                    catch (SystemException se)
                    {
                        MessageBox.Show("Se produjo un error al querer eliminar la PC del sistema: " + Environment.NewLine + 
                            se.Message);
                    }
                }
            }
            */
        }

        private void rBUnix_CheckedChanged(object sender, EventArgs e)
        {
            cbDominio.Enabled = false;
            lvLista.Columns[1].Text = "Descripción";
            lvLista.Items.Clear();
            labelDom.Visible = false;
            cbDominio.Visible = false;
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            cbDominio.Enabled = true;
            lvLista.Columns[1].Text = "Dominio";
            lvLista.Items.Clear();
            labelDom.Visible = true;
            cbDominio.Visible = true;
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.New, rbWindows.Checked);
            fAltaPcs.Title = "Nuevo Equipo";
            if (fAltaPcs.ShowDialog() == DialogResult.OK)
            {
                ExecEntitiesRefresh();
            }

        }



    }
}

