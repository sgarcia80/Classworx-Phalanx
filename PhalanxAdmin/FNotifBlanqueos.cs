using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCCommon.Collections;
using NDCCommon.Entities;
using NDCBL;

namespace PhalanxAdmin
{
    public partial class FNotifBlanqueos : PhalanxAdmin.FBaseNotifClaves
    {
        protected TicketNotificacionBlanqueoEntityCollection _entities;
        protected AplicacionNotificacionClaveEntityCollection _aplicaciones;
        private AplicacionNotificacionClaveEntity _filAplicacion;
        protected string _filNombre = "";
        protected string _filDominio = "";

        public FNotifBlanqueos()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "NotifBlanqueo";
            }
        }

        private void FEquiposWin_Load(object sender, EventArgs e)
        {
            //NDCBL.TicketNotificacionBlanqueoBusiness business = new TicketNotificacionBlanqueoBusiness();
            //lnkAdd.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnkModify.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            //lnkDelete.Enabled = UsrBL.AccAdmEqWinRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            CargaComboAplicaciones();
            ExecEntitiesRefresh();

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
            if (cbAplicacion.SelectedIndex > 0)
            {
                _filAplicacion = (AplicacionNotificacionClaveEntity)cbAplicacion.SelectedItem;
            }
            else
            {
                _filAplicacion = null;
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
            TicketNotificacionBlanqueoBusiness business = new TicketNotificacionBlanqueoBusiness();

            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;

            _entities = business.GetAll(fechaDesde, fechaHasta, _filAplicacion, txtFilDominio.Text, txtFilUsuario.Text);
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

        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = null;
            lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (TicketNotificacionBlanqueoEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Aplicacion.ToString();
                lviArr[i].SubItems.Add(entity.DominioUsuarioAplicacion);
                lviArr[i].SubItems.Add(entity.UsuarioAplicacion);
                lviArr[i].SubItems.Add(entity.Fecha.ToString("dd/MM/yyyy HH:mm"));
                //lviArr[i].ImageIndex = ;
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
            txtFilUsuario.Text = "";
            cbAplicacion.SelectedIndex = 0;
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

        private void CargaComboAplicaciones()
        {
            AplicacionNotificacionClaveBusiness business = new AplicacionNotificacionClaveBusiness();
            //ProvinciaEntityCollection ProvEC
            this._aplicaciones = business.GetAll();
            cbAplicacion.DataSource = this._aplicaciones;
        }

        private void lnkModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.Update, lvLista.SelectedItems[0].Tag);
            //fAltaPcs.Title = "Modificación de Equipo Windows";
            //if (fAltaPcs.ShowDialog() == DialogResult.OK)
            //{
            //    ExecEntitiesRefresh();
            //}
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.View, lvLista.SelectedItems[0].Tag);
            //fAltaPcs.Title = "Visualización de Equipo Windows";
            //fAltaPcs.ShowDialog();
        }
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FAltaPc fAltaPcs = new FAltaPc(FAltaPc.FormType.New, true); // el 2do param si es true es para win
            //fAltaPcs.Title = "Nuevo Equipo Windows";
            //if (fAltaPcs.ShowDialog() == DialogResult.OK)
            //{
            //    ExecEntitiesRefresh();
            //}

        }

    }

}

