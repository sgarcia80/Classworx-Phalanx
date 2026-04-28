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
using NDCCommon.Collections;
using NDCBL;
using NDCCommon.Entities;
using System.IO;
using Classworx.Common.Trace;

namespace PhalanxAdmin
{
    public partial class FRptListadoDePwdExport : PhalanxAdmin.FBaseReportesInternos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Listado de Contraseñas (Exportacion)");
            }
        }

        private PCType _filAmbiente = PCType.App;
        bool? _filEstado = null;

        private enum PCType
        {
            App,
            AS400,
            ATM,
            BBDD,
            Equipos,
            Unix,
            Windows
        }

        private int widthDescripcion;
        private int widthIP;
        private int widthProtocolos;
        private int widthAdicional1;
        private int widthAdicional2;
        private int widthAdicional3;
        private int widthFechaModif;
        private int widthUsuario;
        private int widthAmbienteNombre;
        private int widthContrasena;
        private int widthAmbiente;
        private int widthTipo;
        private int widthDominio;
        private int widthFolio;
        private int widthEstado;

        public override string Id
        {
            get
            {
                return "FTRptTicketsClavesExport";
            }
        }

        protected IList<FRptListadoDePwdEntity> _entities;

        public FRptListadoDePwdExport()
        {
            InitializeComponent();
            lvLista.ListViewItemSorter = new cwxSorter();

            PhxUserBusiness UsrBL = new PhxUserBusiness();
            //btnVer.Visible = UsrBL.AccTickets(this.Usuario);
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
            string tipo = ((KeyValuePair<string, string>)cbFilAmbiente.SelectedItem).Key;
            Enum.TryParse(tipo, out _filAmbiente);

            _filEstado = null;

            if (cbEstado.SelectedIndex > 0)
            {
                _filEstado = cbEstado.SelectedIndex == 1;
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
            _entities = new List<FRptListadoDePwdEntity>();
            try
            {
                switch (_filAmbiente)
                {
                    case PCType.App:
                        ApplicationUserBusiness appb = new ApplicationUserBusiness();
                        appb.FilUsuariosActivos = _filEstado;
                        ApplicationUserEntityCollection appList = appb.GetAll();

                        foreach (ApplicationUserEntity user in appList)
                        {
                            try
                            {
                                string p = appb.GetPassword(user);
                                user.User_RealPassword = p;
                                //applicationUsers.Add(user);
                                _entities.Add(new FRptListadoDePwdEntity(user));
                            }
                            catch (Exception)
                            {
                                TraceHelper.Information("Ultima usuario leido: Aplicativo - '{0}' - Usuario '{1}'", user.Desc, user.Username);
                                throw;
                            }
                        }
                        break;
                    case PCType.AS400:
                        AS400UserBusiness AS400b = new AS400UserBusiness();
                        AS400b.FilUsuariosActivos = _filEstado;
                        AS400UserEntityCollection AS400List = AS400b.GetAll();

                        foreach (AS400UserEntity user in AS400List)
                        {
                            string p = AS400b.GetPassword(user);
                            user.User_RealPassword = p;
                            user.Server_Name = user.AS400.ServerName;
                            //AS400Users.Add(user);
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    case PCType.ATM:
                        ATMUserBusiness ATMb = new ATMUserBusiness();
                        ATMb.FilUsuariosActivos = _filEstado;
                        ATMUserEntityCollection ATMList = ATMb.GetAll();

                        foreach (ATMUserEntity user in ATMList)
                        {
                            string p = ATMb.GetPassword(user);
                            user.User_RealPassword = p;
                            //ATMUsers.Add(user);
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    case PCType.BBDD:
                        DatabaseUserBusiness dbb = new DatabaseUserBusiness();
                        dbb.FilUsuariosActivos = _filEstado;
                        DatabaseUserEntityCollection dbList = dbb.GetAll();

                        foreach (DatabaseUserEntity user in dbList)
                        {
                            string p = dbb.GetPassword(user);
                            user.User_RealPassword = p;
                            //databaseUsers.Add(user);			
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    case PCType.Equipos:
                        CommunicationDeviceUserBusiness cdb = new CommunicationDeviceUserBusiness();
                        cdb.FilUsuariosActivos = _filEstado;
                        CommunicationDeviceUserEntityCollection cdList = cdb.GetAll();

                        foreach (CommunicationDeviceUserEntity user in cdList)
                        {
                            string p = cdb.GetPassword(user);
                            user.User_RealPassword = p;
                            //CommunicationDeviceUsers.Add(user);
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    case PCType.Unix:
                        UnixUserBusiness unixb = new UnixUserBusiness();
                        unixb.FilUsuariosActivos = _filEstado;
                        UnixUserEntityCollection unixList = unixb.GetAll();

                        foreach (UnixUserEntity user in unixList)
                        {
                            string p = unixb.GetPassword(user);
                            user.User_RealPassword = p;
                            user.Server_Name = user.Unix.ServerName;
                            //unixUsers.Add(user);
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    case PCType.Windows:
                        WinLocalUserBusiness wlub = new WinLocalUserBusiness();
                        wlub.FilUsuariosActivos = _filEstado;
                        WinLocalUserEntityCollection list = wlub.GetAll();

                        foreach (WinLocalUserEntity user in list)
                        {
                            string p = wlub.GetPassword(user);
                            user.User_RealPassword = p;
                            //WinLocalUsers.Add(user);
                            _entities.Add(new FRptListadoDePwdEntity(user));
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
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
                    EnableColumns();

                }
            }
        }

        private void EnableColumns()
        {
            colDescripcion.Width = widthDescripcion;
            colIP.Width = widthIP;
            colProtocolos.Width = widthProtocolos;
            colAdicional1.Width = widthAdicional1;
            colAdicional2.Width = widthAdicional2;
            colAdicional3.Width = widthAdicional3;
            colFechaModif.Width = widthFechaModif;
            colUsuario.Width = widthUsuario;
            colAmbienteNombre.Width = widthAmbienteNombre;
            colContrasena.Width = widthContrasena;
            colAmbiente.Width = widthAmbiente;
            colTipo.Width = widthTipo;
            colDominio.Width = widthDominio;
            colFolio.Width = widthFolio;
            colEstado.Width = widthEstado;


            if (!(_filAmbiente == PCType.BBDD || _filAmbiente == PCType.Equipos))
            {
                this.colTipo.Width = 0;
            }

            if (!(_filAmbiente == PCType.Windows || _filAmbiente == PCType.Unix || _filAmbiente == PCType.AS400))
            {
                this.colDominio.Width = 0;
            }

            if (_filAmbiente == PCType.BBDD || _filAmbiente == PCType.App)
            {
                this.colIP.Width = 0;
            }

            if (!(_filAmbiente == PCType.Equipos))
            {
                this.colProtocolos.Width = 0;
            }

            if (!(_filAmbiente == PCType.App))
            {
                this.colAdicional1.Width = 0;
                this.colAdicional2.Width = 0;
                this.colAdicional3.Width = 0;
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
            foreach (FRptListadoDePwdEntity userEntity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                //Folio
                lviArr[i].Text = userEntity.Folio;
                //Ambiente
                lviArr[i].SubItems.Add(userEntity.Ambiente);
                //Tipo 
                lviArr[i].SubItems.Add(userEntity.Tipo);
                //Ambiente Nombre
                lviArr[i].SubItems.Add(userEntity.AmbienteNombre);
                //Dominio
                lviArr[i].SubItems.Add(userEntity.Dominio);
                //Usuario
                lviArr[i].SubItems.Add(userEntity.User);
                //Contraseña 
                lviArr[i].SubItems.Add(userEntity.User_RealPassword);
                //Estado
                lviArr[i].SubItems.Add(userEntity.State);
                //Fecha Modif.
                lviArr[i].SubItems.Add(userEntity.LastChangeDate); // HistChgPwdEnt.User.Username;
                //Descripcion
                lviArr[i].SubItems.Add(userEntity.Descripcion);
                //IP 
                lviArr[i].SubItems.Add(userEntity.IP);
                //Protocolos
                lviArr[i].SubItems.Add(userEntity.Protocolos);
                //CampoAlt1
                lviArr[i].SubItems.Add(userEntity.CampoAlt1);
                //CampoAlt2
                lviArr[i].SubItems.Add(userEntity.CampoAlt2);
                //CampoAlt3
                lviArr[i].SubItems.Add(userEntity.CampoAlt3);

                lviArr[i].Tag = userEntity;
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

        private void FRptListadoDePwdExport_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";

            cbEstado.SelectedIndex = 0;

            widthDescripcion = colDescripcion.Width;
            widthIP = colIP.Width;
            widthProtocolos = colProtocolos.Width;
            widthAdicional1 = colAdicional1.Width;
            widthAdicional2 = colAdicional2.Width;
            widthAdicional3 = colAdicional3.Width;
            widthFechaModif = colFechaModif.Width;
            widthUsuario = colUsuario.Width;
            widthAmbienteNombre = colAmbienteNombre.Width;
            widthContrasena = colContrasena.Width;
            widthAmbiente = colAmbiente.Width;
            widthTipo = colTipo.Width;
            widthDominio = colDominio.Width;
            widthFolio = colFolio.Width;
            widthEstado = colEstado.Width;

            CargarTipos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha de inicio (dd/mm/aaaa)";
            try
            {
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

        private void CleanFilters()
        {
            cbFilAmbiente.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = ((KeyValuePair<string, string>)cbFilAmbiente.SelectedItem).Value;

                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = string.Format("ExportacionClaves_{0}_{1:yyyyMMddHHmm}", tipo, DateTime.Now);
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                foreach (ColumnHeader ch in lvLista.Columns)
                {
                    if (ch.Width > 0)
                    {
                        sb.Append(ch.Text + Separator);
                    }
                }

                int colindex = 0;
                string valor;
                string newline = " ";
                foreach (ListViewItem lvi in lvLista.Items)
                {
                    sb.AppendLine();

                    colindex = 0;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        if (lvLista.Columns[colindex].Width > 0)
                        {
                            valor = lvs.Text.Trim();

                            valor = valor.Replace(Separator, "");
                            if (colindex == colDescripcion.Index)
                            {
                                valor = valor.Replace(System.Environment.NewLine, newline);
                            }

                            if (string.IsNullOrWhiteSpace(valor))
                            {
                                sb.Append(" " + Separator);
                            }
                            else
                            {
                                sb.Append(valor + Separator);
                            }
                        }
                        colindex++;
                    }
                }

                //foreach (FRptListadoDePwdEntity pwd in _entities)
                //{
                //    pwd.Folio
                //}

                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
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

        private void CargarTipos()
        {
            KeyValuePair<string, string>[] tipos = new KeyValuePair<string, string>[7];

            tipos[0] = new KeyValuePair<string, string>(PCType.App.ToString(), "Aplicaciones");
            tipos[1] = new KeyValuePair<string, string>(PCType.AS400.ToString(), "AS400");
            tipos[2] = new KeyValuePair<string, string>(PCType.ATM.ToString(), "ATM");
            tipos[3] = new KeyValuePair<string, string>(PCType.BBDD.ToString(), "Base de Datos");
            tipos[4] = new KeyValuePair<string, string>(PCType.Equipos.ToString(), "Equipos de Com.");
            tipos[5] = new KeyValuePair<string, string>(PCType.Unix.ToString(), "Unix");
            tipos[6] = new KeyValuePair<string, string>(PCType.Windows.ToString(), "Windows");

            cbFilAmbiente.ValueMember = "Key";
            cbFilAmbiente.DisplayMember = "Value";
            cbFilAmbiente.DataSource = tipos;
            cbFilAmbiente.SelectedIndex = 0;
            _filAmbiente = PCType.App;
        }

        private void cbFilAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_entities != null)
            {
                _entities.Clear();
                lvLista.Items.Clear();
            }
            EnableColumns();
        }
    }
}

