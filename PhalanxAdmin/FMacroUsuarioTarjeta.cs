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
using System.IO;

namespace PhalanxAdmin
{
    public partial class FMacroUsuarioTarjeta : PhalanxAdmin.FConfiguracionTC
    {
        protected MacroUsuarioTarjetaEntityCollection _entities;
        protected string _filUsuarioRed = string.Empty;
        protected string _filUsuarioTC = string.Empty;
        protected string _filAplicacionCodigo = string.Empty;

        public override string Id
        {
            get
            {
                return "FMacroUsuarioTarjeta";
            }
        }

        public FMacroUsuarioTarjeta()
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
            _filAplicacionCodigo = txtAplicacion.Text.Trim();
            _filUsuarioRed = txtUsuarioRed.Text.Trim();
            _filUsuarioTC = txtUsuarioTC.Text.Trim();
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
            MacroUsuarioTarjetaBusiness business = new MacroUsuarioTarjetaBusiness();

            _entities = business.GetAll(_filUsuarioRed, _filUsuarioTC, _filAplicacionCodigo);
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
            foreach (MacroUsuarioTarjetaEntity entity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                lviArr[i].Text = entity.Dominio;
                lviArr[i].SubItems.Add(entity.UsuarioRed);
                lviArr[i].SubItems.Add(entity.AplicacionCodigo);
                lviArr[i].SubItems.Add(entity.UsuarioTC);
                lviArr[i].SubItems.Add(entity.Obseravaciones);
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
            txtUsuarioRed.Text = string.Empty;
            txtUsuarioTC.Text = string.Empty;
            txtAplicacion.Text = string.Empty;
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

        private void FMacroUsuarios_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();
            bool edit = UsrBL.AccParamConfigMacroUsuarioRW(System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;

            //ExecEntitiesRefresh();
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            openFileDialog1.Title = "Archivo CSV";

            DialogResult dr = openFileDialog1.ShowDialog();

            txtArchivo.Text = string.Empty;

            if (dr == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                txtArchivo.Text = filename;
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string filename = txtArchivo.Text;

            if (string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Debe seleccionar un archivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!openFileDialog1.CheckFileExists)
            {
                MessageBox.Show("El archivo no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool ok = ProcesarArchivo(filename);

                if (ok)
                {
                    MessageBox.Show("El archivo fue procesado correctamente", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ExecEntitiesRefresh();
                }
                else
                {
                    MessageBox.Show("El archivo presentó errores que se muestran en la lista", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al procesar el archivo", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ProcesarArchivo(string filename)
        {
            bool ok = true;
            List<MacroUsuarioTarjetaEntity> list = new List<MacroUsuarioTarjetaEntity>();
            List<string> mensajes = new List<string>();

            string[] filelines = File.ReadAllLines(filename);
            string dominio = string.Empty;
            string usuariored = string.Empty;
            string usuariotc = string.Empty;
            string aplicacion = string.Empty;

            int lineNro = 0;
            MacroUsuarioTarjetaEntity entity = null;

            foreach (string line in filelines)
            {
                entity = new MacroUsuarioTarjetaEntity();
                lineNro++;

                string[] datos = line.Split(';');

                if (datos.Length != 3)
                {
                    entity.Obseravaciones = string.Format("Línea {0}: Tiene un formato inválido", lineNro);
                }
                else
                {
                    if (!datos[0].Contains("\\"))
                    {
                        entity.Obseravaciones = string.Format("Línea {0}: No se encontró el Dominio", lineNro);
                    }
                    else
                    {
                        string[] user = datos[0].Split(new char[] { '\\' });
                        dominio = user[0];
                        usuariored = user[1];
                        aplicacion = datos[1];
                        usuariotc = datos[2];

                        List<string> errores = new List<string>();
                        if (string.IsNullOrEmpty(usuariored))
                        {
                            errores.Add("No informó el Usuario Red");
                        }
                        if (string.IsNullOrEmpty(aplicacion))
                        {
                            errores.Add("No informó el Código de Aplicación");
                        }
                        if (string.IsNullOrEmpty(usuariotc))
                        {
                            errores.Add("No informó el Usuario de Tarjeta");
                        }

                        if (errores.Count > 0)
                        {
                            entity.Obseravaciones = string.Format("Línea {0}: {1}", lineNro, string.Join(", ", errores.ToArray()));
                        }
                    }
                }

                if (string.IsNullOrEmpty(entity.Obseravaciones))
                {
                    entity.UsuarioRed = usuariored;
                    entity.UsuarioTC = usuariotc;
                    entity.Dominio = dominio;
                    entity.AplicacionCodigo = aplicacion;
                }
                else
                {
                    ok = false;
                }

                list.Add(entity);
            }

            if (ok)
            {
                MacroUsuarioTarjetaBusiness business = new MacroUsuarioTarjetaBusiness();
                business.Save(list);
            }
            else
            {
                _entities = new MacroUsuarioTarjetaEntityCollection();
                _entities.Add(list);

                RefreshEntitiesLV();
            }

            return ok;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLista.Items.Count == 0)
                {
                    return;
                }

                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = string.Format("usuarios_tc_{0:yyyyMMdd}", DateTime.Today);
                saveFileDialog1.Title = "Exportar a CSV";

                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

                MacroUsuarioTarjetaEntity entity = null;

                foreach (ListViewItem lvi in lvLista.Items)
                {
                    entity = lvi.Tag as MacroUsuarioTarjetaEntity;

                    if (entity != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }
                        sb.AppendFormat("{0}\\{1};{2};{3}", entity.Dominio, entity.UsuarioRed, entity.AplicacionCodigo, entity.UsuarioRed);
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a CSV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

