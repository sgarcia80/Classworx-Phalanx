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
    public partial class FMailsAlert : PhalanxAdmin.FBaseAuditoria
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Mails y Notificaciones");
            }
        }

        protected MailAlertEntityCollection _entities;
        protected string _filNombre = "";
        public override string Id
        {
            get
            {
                return "MailAlert";
            }
        }


        MailTypeEntity _filMailType;
        Nullable<bool> _filSentMail;

        public FMailsAlert()
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
            // seteo filtros
            if (((MailTypeEntity)cbTipoMails.SelectedItem).Id == 0)
            {
                _filMailType = null;
            }
            else
            {

                _filMailType = ((MailTypeEntity)cbTipoMails.SelectedItem);
            }
            if (cbEstadoMail.SelectedItem.ToString() == "Todos")
            {
                _filSentMail = null;
            }
            else if (cbEstadoMail.SelectedItem.ToString() == "No enviados")
            {
                _filSentMail = false;
            }
            else if (cbEstadoMail.SelectedItem.ToString() == "Enviados")
            {
                _filSentMail = true;
            }


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
            MailAlertBusiness MailAlertBL = new MailAlertBusiness();
            // seteo filtros
            if (_filMailType != null)
            {
                MailAlertBL.FilMailType = _filMailType;
            }
            if (_filSentMail != null)
            {
                MailAlertBL.FilSentMail = _filSentMail;
            }

            _entities = MailAlertBL.GetAll();
        }
        private void CargaComboTiposMails()
        {
            MailTypeBusiness DBTypeBL = new MailTypeBusiness();
            //ProvinciaEntityCollection ProvEC
            this.cbTipoMails.DataSource = DBTypeBL.FillFilter();
        }

        private void FMailsAlert_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            CargaComboTiposMails();
            cbEstadoMail.SelectedIndex = 0;
            ExecEntitiesRefresh();
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
            foreach (MailAlertEntity MailEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = MailEnt.MailType.Name;
                string Destinatarios = "";
                if (MailEnt.ToName != null && MailEnt.ToName != "")
                {
                    Destinatarios += MailEnt.ToName;
                    if (MailEnt.ToAddress != null && MailEnt.ToAddress != "")
                    {
                        Destinatarios += "(" + MailEnt.ToAddress + ")";
                    }
                }
                else
                {
                    if (MailEnt.ToAddress != null && MailEnt.ToAddress != "")
                    {
                        Destinatarios += MailEnt.ToAddress;
                    }
                }

                if (MailEnt.Cc1Name != null && MailEnt.Cc1Name != "")
                {
                    if (Destinatarios.Length > 0) { Destinatarios += ", "; }

                    Destinatarios += MailEnt.Cc1Name;
                    if (MailEnt.Cc1Address != null && MailEnt.Cc1Address != "")
                    {
                        Destinatarios += "(" + MailEnt.Cc1Address + ")";
                    }
                }
                else
                {
                    if (Destinatarios.Length > 0) { Destinatarios += ", "; }
                    if (MailEnt.Cc1Address != null && MailEnt.Cc1Address != "")
                    {
                        Destinatarios += MailEnt.Cc1Address;
                    }
                }

                if (MailEnt.Cc2Name != null && MailEnt.Cc2Name != "") 
                { 
                    if (Destinatarios.Length > 0) { Destinatarios += ", "; }
                    Destinatarios += MailEnt.Cc2Name;
                    if (MailEnt.Cc2Address != null && MailEnt.Cc2Address != "")
                    {
                        Destinatarios += "(" + MailEnt.Cc2Address + ")";
                    }
                }
                else
                {
                    if (Destinatarios.Length > 0) { Destinatarios += ", "; }
                    if (MailEnt.Cc2Address != null && MailEnt.Cc2Address != "")
                    {
                        Destinatarios += MailEnt.Cc2Address;
                    }
                }

                lviArr[i].SubItems.Add(Destinatarios);
                lviArr[i].SubItems.Add(MailEnt.SendAttemp.ToString());
                if (MailEnt.CreationDate != null)
                {
                    lviArr[i].SubItems.Add(MailEnt.CreationDate.Value.ToString("dd/MM/yyyy HH:m:ss"));
                }
                if (MailEnt.SendDate != null)
                {
                    lviArr[i].ImageIndex = 0;
                    lviArr[i].SubItems.Add(MailEnt.SendDate.Value.ToString("dd/MM/yyyy HH:m:ss"));
                }
                else
                {
                    lviArr[i].ImageIndex = 1;
                }

                lviArr[i].Tag = MailEnt;
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
            //txtFilNombre.Text = "";
            _filMailType = null;
            _filSentMail = null;

            cbEstadoMail.SelectedIndex = 0;
            cbTipoMails.SelectedIndex = 0;
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

