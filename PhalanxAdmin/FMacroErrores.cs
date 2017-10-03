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
    public partial class FMacroErrores : PhalanxAdmin.FBaseSistema
    {
        protected MacroErrorEntityCollection _entities;
        protected string _filDescripcion = string.Empty;

        public override string Id
        {
            get
            {
                return "MacroErrores";
            }
        }

        public FMacroErrores()
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
            _filDescripcion = txtDescripcion.Text.Trim();

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
            MacroErrorBusiness business = new MacroErrorBusiness();

            _entities = business.GetAll(_filDescripcion);
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
            foreach (MacroErrorEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Descripcion;
                lviArr[i].Tag = entity;
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
            txtDescripcion.Text = string.Empty;
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

        private void FMacroErrores_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            bool edit = UsrBL.AccParamConfigMacroErroresRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            lnkEdit.Enabled = edit;
            lnkAdd.Enabled = edit;
            lnkDelete.Enabled = edit;
            
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            ExecEntitiesRefresh();

        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                MacroErrorEntity entity = (MacroErrorEntity)lvLista.SelectedItems[0].Tag;

                Edit(entity, true);
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

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FABMMacroError form = new FABMMacroError();

            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedItems.Count > 0)
            {
                MacroErrorEntity entity = (MacroErrorEntity)lvLista.SelectedItems[0].Tag;

                string mensaje = string.Format("Se eliminará el Error seleccionado. {0}¿Desea conitnuar?", Environment.NewLine);

                if (MessageBox.Show(mensaje, "Eliminar Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    MacroErrorBusiness business = new MacroErrorBusiness();

                    if (business.Delete(entity))
                    {
                        MessageBox.Show("La operación se ha realizado correctamente");
                        CleanFilters();
                        DBRefreshEntites();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al querer eliminar el Error");
                    }
                }
            }
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvLista.SelectedIndices.Count == 1)
            {
                MacroErrorEntity entity = (MacroErrorEntity)lvLista.SelectedItems[0].Tag;

                Edit(entity, false);
            }
        }

        private void Edit(MacroErrorEntity entity, bool readOnly)
        {
            FABMMacroError form = new FABMMacroError(entity, readOnly);

            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                this.CleanFilters();
                this.ExecEntitiesRefresh();
            }
        }
    }
}

