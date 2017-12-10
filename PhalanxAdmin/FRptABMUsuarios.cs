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

namespace PhalanxAdmin
{
    public partial class FRptABMUsuarios : PhalanxAdmin.FBaseReportes
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "ABM de Usuarios");
            }
        }

        public override string Id
        {
            get
            {
                return "FAuditABMUsr";
            }
        }
        protected AuditUsuariosEntityCollection _entities;
        public FRptABMUsuarios()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();
        }
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
        private void SetQueryFilters()
        {
            //_filNombre = txtFilNombre.Text.Trim();

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
            //HistPasswordChangeBusiness HistPwdChgBL = new HistPasswordChangeBusiness();
            AuditUsuariosBusiness AuditLoginBL = new AuditUsuariosBusiness();
            // seteo filtros
            _entities = AuditLoginBL.GetAll(txtFDesde.Text, txtFHasta.Text);
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
            foreach (AuditUsuariosEntity AuditUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /*lviArr[i].SubItems.Add(HistChgPwdEnt.User.);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.ServerName);
                lviArr[i].ImageIndex = HistChgPwdEnt.ActiveUser ? 0 : 1;*/
                lviArr[i].Text = AuditUsrEnt.Operacion;
                lviArr[i].SubItems.Add(AuditUsrEnt.Recurso);
                lviArr[i].SubItems.Add(AuditUsrEnt.IdUsuario + " - " + AuditUsrEnt.Username);
                lviArr[i].SubItems.Add(AuditUsrEnt.Fullname);
                lviArr[i].SubItems.Add(AuditUsrEnt.Fecha.ToString("dd/MM/yyyy HH:m:ss")); // HistChgPwdEnt.User.Username;
                lviArr[i].SubItems.Add(AuditUsrEnt.IdUsuarioABM + " - " + AuditUsrEnt.UsernameABM);
                lviArr[i].SubItems.Add(AuditUsrEnt.FullnameABM);
                lviArr[i].SubItems.Add(AuditUsrEnt.TerminalABM);
                lviArr[i].SubItems.Add("Satisfactoria");
                lviArr[i].Tag = AuditUsrEnt;
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

        private void FRptABMUsuarios_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha de inicio (dd/mm/aaaa)";
            try
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                DateTime dTest;
                if (txtFDesde.Text.Trim() != "/  /")
                {
                    dTest = Convert.ToDateTime(txtFDesde.Text, dtfi);
                }
                if (txtFHasta.Text.Trim() != "/  /")
                {
                    strErrorMsg = "Verifique el formato de la fecha de fin (dd/mm/aaaa)";
                    dTest = Convert.ToDateTime(txtFHasta.Text, dtfi);
                }

                //DateTime FDesde = Convert.ToDateTime(txtFDesde.Text,
                ExecEntitiesRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErrorMsg, "Error en filtros de búsqueda");
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtFDesde.Text = "";
            txtFHasta.Text = "";

        }

        private void lvLista_DoubleClick(object sender, EventArgs e)
        {
            if(lvLista.SelectedItems.Count > 0)
            {
             // 
                FRptABMUsuariosDetail FDetalle = new FRptABMUsuariosDetail((AuditUsuariosEntity)lvLista.SelectedItems[0].Tag);
                FDetalle.ShowDialog();
            }
        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
                return;

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


    }
}

