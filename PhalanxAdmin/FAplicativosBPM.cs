using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxBL;
using PhalanxCommon.Entities;
using NDCBL;
using NDCCommon.Collections;
using NDCCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FAplicativosBPM : PhalanxAdmin.FBaseSistema
    {
        protected AplicacionNotificacionClaveEntityCollection _entities;
        protected string _filNombre = "";
        
        public override string Id
        {
            get
            {
                return "AplicativosBPM";
            }
        }

        public FAplicativosBPM()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();
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
            _filNombre = txtFilNombre.Text.Trim();

        }

        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DBRefreshEntites();
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
            AplicacionNotificacionClaveBusiness ancBusiness = new AplicacionNotificacionClaveBusiness();

            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
                ancBusiness.FilNombre = txtFilNombre.Text.Trim();

            _entities = ancBusiness.GetAll();
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
        /// <returns>Devuelve el arrary de list view items para llenar el listview</returns>
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (AplicacionNotificacionClaveEntity ancEntity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = ancEntity.Codigo;
                lviArr[i].SubItems.Add(ancEntity.Nombre);
                lviArr[i].SubItems.Add(ancEntity.Notificable ? "Sí" : "No");
                lviArr[i].SubItems.Add(ancEntity.EsAplicacionRed ? "Sí" : "No");
                lviArr[i].SubItems.Add(ancEntity.EsAplicacionCobis ? "Sí" : "No");
                lviArr[i].SubItems.Add(ancEntity.EsEmuladores ? "Sí" : "No");
                lviArr[i].SubItems.Add(ancEntity.Macro != null ? ancEntity.Macro.Name : string.Empty);
                lviArr[i].Tag = ancEntity;
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

        private void FAplicativosBPM_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            lnkModificar.Enabled = UsrBL.AccParamAplicativosBMPRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            ExecEntitiesRefresh();

        }

        private void lnkModificar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                FABMAplicativoBPM FABMAplicativoBPM = new FABMAplicativoBPM((AplicacionNotificacionClaveEntity)lvLista.SelectedItems[0].Tag);

                FABMAplicativoBPM.ShowDialog();

                if (FABMAplicativoBPM.DialogResult == DialogResult.OK)
                {
                    this.CleanFilters();
                    this.ExecEntitiesRefresh();
                }
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
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                else
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                s.Column = e.Column;
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            
            ((ListView)sender).Sort();
        }

        private void btnSetAppRed_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                AplicacionNotificacionClaveEntity app = (AplicacionNotificacionClaveEntity)lvLista.SelectedItems[0].Tag;

                AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();

                if (ancb.SetearAppRed(app))
                {
                    this.CleanFilters();
                    this.ExecEntitiesRefresh();
                }
                else
                    MessageBox.Show("No se puedo setear la aplicación de red", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetAppCobis_Click(object sender, EventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                AplicacionNotificacionClaveEntity app = (AplicacionNotificacionClaveEntity)lvLista.SelectedItems[0].Tag;

                AplicacionNotificacionClaveBusiness ancb = new AplicacionNotificacionClaveBusiness();

                if (ancb.SetearAppCobis(app))
                {
                    this.CleanFilters();
                    this.ExecEntitiesRefresh();
                }
                else
                    MessageBox.Show("No se puedo setear la aplicación cobis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

