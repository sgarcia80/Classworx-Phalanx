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
using System.Collections;

namespace PhalanxAdmin
{
    public partial class FUsuariosGrupos : PhalanxAdmin.FBaseReportesNormativos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Usuarios por Grupos de Solicitudes");
            }
        }

        protected IList _entities;

		string nombreGrupo;
		bool? grupoActivo;
		bool? usuarioActivo;
        
		public override string Id
        {
            get
            {
				return "FUsuariosGrupos";
            }
        }
		public FUsuariosGrupos()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

			cboEstadoGrupo.SelectedIndex = 0;
			cboEstadoUsuario.SelectedIndex = 0;
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
			nombreGrupo = txtFilNombre.Text.Trim();

			if (nombreGrupo == string.Empty)
				nombreGrupo = null;

			grupoActivo = null;
			usuarioActivo = null;

			if (cboEstadoGrupo.SelectedIndex < 2)
				grupoActivo = cboEstadoGrupo.SelectedIndex == 0;

			if (cboEstadoUsuario.SelectedIndex < 2)
				usuarioActivo = cboEstadoUsuario.SelectedIndex == 0;

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
			IList list = new PhxUserBusiness().GetAllByGrupoSolicitud(nombreGrupo, grupoActivo, usuarioActivo);
			
            _entities = list;
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
            foreach (object[] entidad in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                /*lviArr[i].SubItems.Add(HistChgPwdEnt.User.);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.Type.Name);
                lviArr[i].SubItems.Add(HistChgPwdEnt.Db.ServerName);
                lviArr[i].ImageIndex = HistChgPwdEnt.ActiveUser ? 0 : 1;*/
				
                lviArr[i].Text = entidad[0].ToString(); // HistChgPwdEnt.User.Username;
                lviArr[i].SubItems.Add(entidad[1].ToString());
                lviArr[i].SubItems.Add((bool) entidad[2] ? "Activo" : "Inactivo");
                lviArr[i].SubItems.Add(entidad[3].ToString());
				lviArr[i].SubItems.Add(entidad[4].ToString());
				lviArr[i].SubItems.Add(entidad[5].ToString());
				lviArr[i].SubItems.Add(entidad[6].ToString());
				lviArr[i].SubItems.Add((bool)entidad[7] ? "Activo" : "Inactivo");
                lviArr[i].Tag = entidad;
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
			cboEstadoGrupo.SelectedIndex = 0;
			cboEstadoUsuario.SelectedIndex = 0;
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
            return true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFilters())
                {
                    DBRefreshEntites();

                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    saveFileDialog1.FileName = "UsuariosPorGrupoSolicitudes";
                    saveFileDialog1.Title = "Exportar a CSV";

                    StringBuilder sb = new StringBuilder();
                    string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    sb.Append("Id Grupo" + Separator);
                    sb.Append("Nombre grupo" + Separator);
                    sb.Append("Estado grupo" + Separator);
                    sb.Append("Id usuario" + Separator);
					sb.Append("Dominio usuario" + Separator);
					sb.Append("Usuario red" + Separator);
					sb.Append("Nombre completo" + Separator);
					sb.Append("Estado usuario");

					foreach (object[] entidad in this._entities)
					{
                        sb.AppendLine();
                        sb.Append(entidad[0].ToString() + Separator);
						sb.Append(entidad[1].ToString() + Separator);
                        sb.Append((bool)entidad[2] ? "Activo" : "Inactivo" + Separator);
						sb.Append(entidad[3].ToString());
						sb.Append(entidad[4].ToString() + Separator);
						sb.Append(entidad[5].ToString() + Separator);
						sb.Append(entidad[6].ToString() + Separator);
						sb.Append((bool)entidad[7] ? "Activo" : "Inactivo" + Separator);
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

