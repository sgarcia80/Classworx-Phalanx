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
using System.IO;

namespace PhalanxAdmin
{
    public partial class FLogPwdChg : PhalanxAdmin.FBaseAuditoria
    {
        protected vwHistPwdChgEntityCollection _entities;
        private PhxUserEntity m_CurrentUser;
        private VwInventarioEntity m_InventUser;
        public override string Id
        {
            get
            {
                return "FLogPwdChg";
            }
        }
        public FLogPwdChg()
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
            vwHistPwdChgBusiness HistPwdChgBL = new vwHistPwdChgBusiness();
            // seteo filtros
            if (txtFilNombre.Text.Trim() != "")
            {
                //HistPwdChgBL.FilNombre = txtFilNombre.Text.Trim();
            }
            int Folio = 0;
            if (m_InventUser != null)
            {
                Folio = m_InventUser.Folio;
            }
            _entities = HistPwdChgBL.GetAll(this.m_CurrentUser, Folio, txtFDesde.Text, txtFHasta.Text, null);
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
            foreach (vwHistPwdChgEntity HistChgPwdEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /*lviArr[i].SubItems.Add(HistChgPwdEnt.User.);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.ServerName);
                lviArr[i].ImageIndex = HistChgPwdEnt.ActiveUser ? 0 : 1;*/
                lviArr[i].Text = HistChgPwdEnt.Usuario; // HistChgPwdEnt.User.Username;
                lviArr[i].SubItems.Add(HistChgPwdEnt.UserType.Desc);
                lviArr[i].SubItems.Add(HistChgPwdEnt.DChange.ToString("dd/MM/yyyy HH:m:ss"));
                lviArr[i].SubItems.Add(HistChgPwdEnt.PhxUser.Fullname);
                lviArr[i].Tag = HistChgPwdEnt;
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
            if (ValidateFilters())
            {
                try
                {
                    ExecEntitiesRefresh();
                }
                catch
                {
                    MessageBox.Show("Error al realizar la búsqueda", "Error");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtFilNombre.Text = "";
            this.m_CurrentUser = null;
            txtPwdUser.Text = "";
            this.m_InventUser = null;
            txtFDesde.Text = "";
            txtFHasta.Text = "";
            
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

        private void FHistPwdChg_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";
        }

        private void btnBuscarPhxUsr_Click(object sender, EventArgs e)
        {
            FSelectPhxUser selectPhxUsers = new FSelectPhxUser(); //(WinPCEntity)cBPC.SelectedValue);
            selectPhxUsers.Title = "Busqueda de Usuarios";

            if (selectPhxUsers.ShowDialog() == DialogResult.OK)
            {
                PhxUserEntity selectedUser = (PhxUserEntity)selectPhxUsers.GetSelectedEntity();
                if (selectedUser != null)
                {
                    m_CurrentUser = selectedUser;
                    txtFilNombre.Text = selectedUser.Fullname + "(" + selectedUser.Username + ")";
                }
            }

        }

        private void btnPwdUser_Click(object sender, EventArgs e)
        {
            FSelectUser selectUser = new FSelectUser();
            selectUser.Title = "Búsqueda de Contraseña en Custodia";
            if (selectUser.ShowDialog() == DialogResult.OK)
            {
                VwInventarioEntity selectedUser = (VwInventarioEntity)selectUser.GetSelectedEntity();
                if (selectedUser != null)
                {
                    m_InventUser = selectedUser;
                    txtPwdUser.Text = selectedUser.Usuario;
                }
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

        private bool ValidateFilters()
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

                return true;
            }
            catch 
            {
                MessageBox.Show(strErrorMsg, "Error en filtros de búsqueda");
            }

            return false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFilters())
                {
                    DBRefreshEntites();

                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    saveFileDialog1.FileName = "LogModificacionPwd";
                    saveFileDialog1.Title = "Exportar a CSV";

                    StringBuilder sb = new StringBuilder();
                    string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    sb.Append("Usuario" + Separator);
                    sb.Append("Ambiente" + Separator);
                    sb.Append("Fecha Modificación" + Separator);
                    sb.Append("Modificado por" + Separator);

                    foreach (vwHistPwdChgEntity HistChgPwdEnt in _entities)
                    {
                        sb.AppendLine();
                        sb.Append(HistChgPwdEnt.Usuario + Separator);
                        sb.Append(HistChgPwdEnt.UserType.Desc + Separator);
                        sb.Append(HistChgPwdEnt.DChange.ToString("dd/MM/yyyy HH:m:ss") + Separator);
                        sb.Append(HistChgPwdEnt.PhxUser.Fullname);
                    }

                    DialogResult dr = saveFileDialog1.ShowDialog();
                    
                    if (dr == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
                        sw.Write(sb.ToString());
                        sw.Close();
                        
                        MessageBox.Show("La exportación ha sido completada", "Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

