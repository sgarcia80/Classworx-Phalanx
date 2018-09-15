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
    public partial class FDominios : PhalanxAdmin.FBaseSistema
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Dominios");
            }
        }

        protected WinDomainEntityCollection _entities;
        protected WinDomainEntity m_DomainEntity;
        protected WinDomainBusiness m_WinDomBus;
        protected string _filNombre = "";

        public FDominios()
        {
            InitializeComponent();
            m_DomainEntity = new PhalanxCommon.Entities.WinDomainEntity();
            m_WinDomBus = new WinDomainBusiness();
        }

        private void FDominios_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkAdd.Enabled = UsrBL.AccAdmDominiosWinRW(this.Usuario);
            lnkModify.Enabled = UsrBL.AccAdmDominiosWinRW(this.Usuario);
            lnkDelete.Enabled = UsrBL.AccAdmDominiosWinRW(this.Usuario);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
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
        protected void ExecEntitiesRefresh()
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
            this.bwRefreshEntities.RunWorkerAsync();
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
        protected virtual void SetQueryFilters()
        {
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
        protected virtual void LoadEntities()
        {
            WinDomainBusiness WinDomBL = new WinDomainBusiness();
            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
            {
                WinDomBL.FilNombre = txtFilNombre.Text.Trim();
            }
            _entities = WinDomBL.GetAll();
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
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (WinDomainEntity WinDomEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /*
                if (WinDomEnt.Categoria == null)
                {
                    lviArr[i].SubItems.Add("");
                }
                else
                {
                    lviArr[i].SubItems.Add(WinDomEnt.Categoria.Categoria);
                }
                if (WinDomEnt.Empresa == null)
                {
                    lviArr[i].SubItems.Add("");
                }
                else
                {
                    lviArr[i].SubItems.Add(WinDomEnt.Empresa.Nombre);
                }*/
                lviArr[i].Text = WinDomEnt.NtName;
                lviArr[i].Tag = WinDomEnt;
                i++;
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

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FAltaDominio fAlta = new FAltaDominio();
            fAlta.Title = "Nuevo Dominio en el Sistema";
            fAlta.Usuario = this.Usuario;
            fAlta.ShowDialog();
            CleanFilters();
            DBRefreshEntites();
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FAltaDominio fAlta = new FAltaDominio((WinDomainEntity)lvLista.SelectedItems[0].Tag);
            fAlta.Title = "Modificación de Dominio";
            fAlta.Usuario = this.Usuario;
            fAlta.ShowDialog();
            CleanFilters();
            DBRefreshEntites();
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedItems.Count > 0)
            {

                string myItem = lvLista.SelectedItems[0].Text;
                if (MessageBox.Show("Desea Eliminar del Sistema el Dominio " + myItem + Environment.NewLine +
                                     "Debe tener en cuenta que se eliminarán todas sus Pcs del sistema.", "Eliminar dominio del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (m_WinDomBus.Exists(myItem))
                    {
                        if (m_WinDomBus.Delete((WinDomainEntity)lvLista.SelectedItems[0].Tag))
                        {
                            MessageBox.Show("Dominio Eliminado del sistema");
                            CleanFilters();
                            DBRefreshEntites();
                        }
                        else
                            MessageBox.Show("Se produjo un error al querer eliminar el Dominio del sistema");
                    }
                }
            }
        }



    }
}

