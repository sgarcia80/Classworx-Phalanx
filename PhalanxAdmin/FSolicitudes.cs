using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxBL;
using PhalanxCommon.Entities;
using System.Globalization;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FSolicitudes : PhalanxAdmin.FBaseReportes
    {
        private RequestGroupEntityCollection _reqGroups;
        private ArrayList _filEstados;
        private ArrayList _filGrupos;
        protected PasswordRequestEntityCollection _entities;
        protected string _filNombre = "";
        public override string Id
        {
            get
            {
                return "FSolicitudes";
            }
        }
        public FSolicitudes()
        {
            InitializeComponent();
            lvSolicitudes.ListViewItemSorter = new cwxSorter();

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
            if (lvSolicitudes.Columns.Count == 0)
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
            _filEstados = null;
            if (cboEstados.Items.Count > 0 && cboEstados.SelectedIndex > 0)
            {
                _filEstados = new ArrayList();
                _filEstados.Add(cboEstados.SelectedItem);
            }
            _filGrupos= null;
            if (cboGrupos.Items.Count > 0 && cboGrupos.SelectedIndex > 0)
            {
                _filGrupos= new ArrayList();
                _filGrupos.Add(cboGrupos.SelectedItem);
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
            PasswordRequestBusiness reqpwdBL = new PasswordRequestBusiness();
            // seteo filtros
            _entities = reqpwdBL.GetPassRqstByState(_filEstados, txtFilNroSolic.Text, _filGrupos, true);
        }

        //protected void gvCloseRequests_RowDataBound(object sender)
        //{
        //    if (sender != null)
        //    {
        //        string imageUrl = string.Empty;
        //        Image TempImage;
        //        string tempString = string.Empty;
        //        string strToolTip = string.Empty;
        //        //TempImage = (Image)e.Row.FindControl("imgTemp");

        //        PasswordRequestEntity reqpwd = (PasswordRequestEntity)sender;
        //        if (reqpwd != null)
        //        {
        //            if (reqpwd.RqstUser != null)
        //            {
        //                //e.Row.Cells[2].Text = reqpwd.ReturnUser.Username;
        //                tempString = reqpwd.RqstUser.Fullname;
        //                tempString = reqpwd.RequestDate.ToString("dd/MM/yyyy HH:mm:ss");

        //            }

        //            if (reqpwd.ReturnDate != null)
        //                tempString = ((DateTime)reqpwd.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss");

        //            tempString = reqpwd.State;

        //            if (reqpwd.User is WinLocalUserEntity)
        //            {
        //                tempString = "Dominio: " + ((WinLocalUserEntity)reqpwd.User).Domain + " - Server: " + ((WinLocalUserEntity)reqpwd.User).WinPc.Name + " - Usuario: " + reqpwd.User.Username;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de Windows";
        //            }

        //            if (reqpwd.User is ApplicationUserEntity)
        //            {
        //                tempString = "Aplicación: " + ((ApplicationUserEntity)reqpwd.User).ApplicationName + " - Usuario: " + reqpwd.User.Username;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de Aplicativo";
        //            }

        //            if (reqpwd.User is DatabaseUserEntity)
        //            {
        //                tempString = "Base de datos: " + ((DatabaseUserEntity)reqpwd.User).DBName + " - Tipo: " + ((DatabaseUserEntity)reqpwd.User).Db.Type.Name;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de Base de Datos";
        //            }

        //            if (reqpwd.User is UnixUserEntity)
        //            {
        //                tempString = "Servidor: " + ((UnixUserEntity)reqpwd.User).Server_Name;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de Unix-Linux";
        //            }
        //            if (reqpwd.User is AS400UserEntity)
        //            {
        //                tempString = "Servidor: " + ((AS400UserEntity)reqpwd.User).Server_Name;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de AS400";
        //            }

        //            if (reqpwd.User is CommunicationDeviceUserEntity)
        //            {
        //                //tempString = "Base de datos: " + ((CommunicationDeviceUserEntity)reqpwd.User).DBName + " - Tipo: " + ((DatabaseUserEntity)reqpwd.User).Db.Type.Name;
        //                imageUrl = "~/image/pwd_free.gif";
        //                strToolTip = "Contraseña de Equipos de Comunicación";
        //            }
        //        }
        //        //TempImage.ImageUrl = imageUrl;
        //        //TempImage.ToolTip = strToolTip;
        //    }
        //}
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
            if (this.lvSolicitudes.InvokeRequired)
            {
                SetItemsAddRangeCallback d = new SetItemsAddRangeCallback(SetLVItems);
                this.Invoke(d, new object[] { lviArr });
            }
            else
            {
                this.lvSolicitudes.Items.Clear();
                if (lviArr != null && lviArr.Length > 0)
                {
                    this.lvSolicitudes.Items.AddRange(lviArr);
                }
            }
        }

        /// <summary>
        /// Genera los list view items para llenar el list view
        /// </summary>
        /// <returns>Devuelve el arrary de list view items para llenar el listview</returns>
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = null;
            if (_entities != null)
            {
                lviArr = new ListViewItem[this._entities.Count];
                int i = 0, imgIndex = 0;

                string tmpString = string.Empty;

                foreach (PasswordRequestEntity reqpwd in this._entities)
                {
                    lviArr[i] = new ListViewItem();
                    /// hay que armar los items de lo que se traiga de la DB
                    if (reqpwd.User is WinLocalUserEntity)
                    {
                        tmpString = "Dominio: " + ((WinLocalUserEntity)reqpwd.User).Domain + " - Server: " + ((WinLocalUserEntity)reqpwd.User).WinPc.Name; // +" - Usuario: " + reqpwd.User.Username;
                        imgIndex = 3;
                    }

                    if (reqpwd.User is ApplicationUserEntity)
                    {
                        tmpString = "Aplicación: " + ((ApplicationUserEntity)reqpwd.User).ApplicationName; // +" - Usuario: " + reqpwd.User.Username;
                        imgIndex = 0;
                    }

                    if (reqpwd.User is DatabaseUserEntity)
                    {
                        tmpString = "Base de datos: " + ((DatabaseUserEntity)reqpwd.User).DBName + " - Tipo: " + ((DatabaseUserEntity)reqpwd.User).Db.Type.Name;
                        imgIndex = 1;
                    }

                    if (reqpwd.User is UnixUserEntity)
                    {
                        tmpString = "Servidor: " + ((UnixUserEntity)reqpwd.User).Unix.ServerName;
                        imgIndex = 2;
                    }
                    if (reqpwd.User is AS400UserEntity)
                    {
                        tmpString = "Servidor: " + ((AS400UserEntity)reqpwd.User).AS400.ServerName;
                        imgIndex = 4;
                    }

                    if (reqpwd.User is CommunicationDeviceUserEntity)
                    {
                        tmpString = "Eq. de Comunicación: " + ((CommunicationDeviceUserEntity)reqpwd.User).CommunicationDeviceName + " - Tipo: " + ((CommunicationDeviceUserEntity)reqpwd.User).CommunicationDeviceType;
                        imgIndex = 5;
                    }
                    if (reqpwd.User is ATMUserEntity)
                    {
                        tmpString = "ATM: " + ((ATMUserEntity)reqpwd.User).ATMName;
                        imgIndex = 6;
                    }
                    tmpString += " - Usuario: " + reqpwd.User.Username;
                    lviArr[i].ImageIndex = imgIndex;
                    lviArr[i].Text = tmpString;
                    lviArr[i].SubItems.Add(reqpwd.Key);
                    lviArr[i].SubItems.Add(reqpwd.RqstUsrFullName);
                    lviArr[i].SubItems.Add(reqpwd.RequestDate.ToString("dd/MM/yyyy HH:mm:ss"));
                    tmpString = "";
                    // Determino la fecha según el estado
                    switch (reqpwd.RqstState.Id)
                    {
                        // Autorizada
                        case 2:
                        // Rechazada
                        case 3:
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                        // Visualizada
                        case 4:
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                        // Asignaciones
                        case 5:
                        case 6:
                        case 7:
                            tmpString = ((DateTime)reqpwd.Auth1Date).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                        // Devuelta por el usuario
                        case 8:
                        // Devuelta por el administrador
                        case 9:
                            tmpString = ((DateTime)reqpwd.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                        // Expirada
                        case 10:
                            tmpString = ((DateTime)reqpwd.ExpirationDate).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                        // Cerrada
                        case 11:
                            tmpString = ((DateTime)reqpwd.CloseDate).ToString("dd/MM/yyyy HH:mm:ss");
                            break;
                    }
                    lviArr[i].SubItems.Add(tmpString);
                    lviArr[i].SubItems.Add(reqpwd.State);
                    string FechaCambio = "";
                    string UsrCambio = "";
                    if (reqpwd.CambioLoaded && reqpwd.ChangePostReturn != null)
                    {
                        FechaCambio = reqpwd.ChangePostReturn.DChange.ToString("dd/MM/yyyy HH:mm:ss");
                        UsrCambio = reqpwd.ChangePostReturn.PhxUser.Fullname;
                    }


                    lviArr[i].SubItems.Add(FechaCambio);
                    lviArr[i].SubItems.Add(UsrCambio);

                    lviArr[i].Tag = reqpwd;
                    i++;
                }
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
                if (this.lvSolicitudes.Items.Count > 0)
                {
                    this.lvSolicitudes.Items[0].Selected = true;
                    this.lvSolicitudes.Focus();
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
            txtFilNroSolic.Text = "";
            cboEstados.SelectedIndex = 0;
            cboGrupos.SelectedIndex = 0;
        }

        private void lnkCancelar_Click(object sender, EventArgs e)
        {
            this.bwRefreshEntities.CancelAsync();
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            this.lblStatus.Text = "Cancelado";
            this.lvSolicitudes.Items.Clear();
            this.pnlFilters.Enabled = true;
            this.pnlList.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void FSolicitudes_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            FillRequestState();
            FillRequestGroup();
            //ExecEntitiesRefresh();
        }

        private void FillRequestState()
        {
            cboEstados.Items.Clear();
            RequestStateEntityCollection reqStates = new RequestStateBusiness().FillFilter();
            cboEstados.DataSource = reqStates;
            cboEstados.SelectedIndex = 0;
        }

        private void FillRequestGroup()
        {
            cboGrupos.Items.Clear();
            _reqGroups = new RequestGroupBusiness().FillFilter();
            cboGrupos.DisplayMember = "RqstGrpName";
            cboGrupos.ValueMember = "Id";
            cboGrupos.DataSource = _reqGroups;
            cboGrupos.SelectedIndex = 0;
        }


        private void cboEstados_DrawItem(object sender, DrawItemEventArgs e)
        {
            for (int i=0;i< cboEstados.Items.Count; i++ )
            {
                e.Graphics.DrawString(cboEstados.Items[i].ToString(), cboEstados.Font, Brushes.Black, new Rectangle( 16, i * cboEstados.ItemHeight, cboEstados.Width, cboEstados.ItemHeight) );
                if (((int)Math.Pow(((RequestStateEntity)cboEstados.Items[i]).Id, 2) & (int.Parse ( cboEstados.Tag.ToString()))) > 0)
                {
                    e.Graphics.DrawImage(imageList.Images[1], 0, i * cboEstados.ItemHeight);
                }
                else
                {
                    e.Graphics.DrawImage(imageList.Images[0], 0, i * cboEstados.ItemHeight);
                }
            }
        }


        private void cboEstados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape )
            {
                cboEstados.SelectedIndex = -1;
            }
        }

        private void lvSolicitudes_DoubleClick(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }
        private void MostrarReporteSolicitudes()
        {
            if (lvSolicitudes.SelectedItems.Count > 0)
            {
                ReporteDeUsoEntityCollection RptUsoLst = new ReporteDeUsoEntityCollection();
                for (int i = 0; i < lvSolicitudes.SelectedItems.Count; i++)
                {
                    RptUsoLst.Add((PasswordRequestEntity)lvSolicitudes.SelectedItems[i].Tag);
                }

                FRptUso Rpt = new FRptUso(RptUsoLst);
                Rpt.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarReporteSolicitudes();
        }

        private void txtFilNroSolic_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            /*
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }*/
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            /*else if (this.allowSpace && e.KeyChar == ' ')
            {

            }*/
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }

        }

        private void lvSolicitudes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Items.Count == 0)
            {
                return;
            }
            cwxSorter s = (cwxSorter)((ListView)sender).ListViewItemSorter;
            if (s.Column == e.Column)
            {
                if (s.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    s.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    s.Order = System.Windows.Forms.SortOrder.Ascending;
                }
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
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = "ControlUtilizacion";
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                foreach (ColumnHeader ch in lvSolicitudes.Columns)
                {
                    sb.Append(ch.Text + Separator);
                }
                foreach (ListViewItem lvi in lvSolicitudes.Items)
                {
                    sb.AppendLine();
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        if (lvs.Text.Trim() == string.Empty)
                            sb.Append(" " + Separator);
                        else
                            sb.Append(lvs.Text + Separator);
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

        private void cboGrupos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                cboGrupos.SelectedIndex = -1;
            }

        }

        private void cboGrupos_DrawItem(object sender, DrawItemEventArgs e)
        {
            //imageListStatusStatus
            // Let's highlight the currently selected item like any well 
            // behaved combo box should
            Font myFont = new System.Drawing.Font("Microsoft Sans Serif", (float)8.25);

            /// setea el fondo del item con el color por defecto del sistema para items seleccionados,
            /// luego cuando no es un item seleccionado lo pinta con fondo blanco
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            // si está activo no dibuja el icono de inactivo
            if (_reqGroups[e.Index].Active)
            {
                e.Graphics.DrawString(_reqGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                  new Point(imageListStatus.Images[0].Width, e.Bounds.Y));
                //e.Graphics.DrawImage(imageListStatus.Images[0], new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                // el grupo está inactivo, hay que agregar el icono
                e.Graphics.DrawString(_reqGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                  new Point(imageListStatus.Images[1].Width + 2, e.Bounds.Y));
                e.Graphics.DrawImage(imageListStatus.Images[1], new Point(e.Bounds.X, e.Bounds.Y));
            }
            //is the mouse hovering over a combobox item??            
            if ((e.State & DrawItemState.Focus) == 0)
            {
                // al no ser un item seleccionado le pinta el fondo de blanco
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                //this code keeps the last item drawn from having a Bisque background. 
                if (_reqGroups[e.Index].Active)
                {
                    e.Graphics.DrawString(_reqGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                      new Point(imageListStatus.Images[0].Width, e.Bounds.Y));
                    //e.Graphics.DrawImage(imageListStatus.Images[0], new Point(e.Bounds.X, e.Bounds.Y));
                }
                else
                {
                    // el grupo está inactivo, hay que agregar el icono
                    e.Graphics.DrawString(_reqGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                      new Point(imageListStatus.Images[1].Width + 2, e.Bounds.Y));
                    e.Graphics.DrawImage(imageListStatus.Images[1], new Point(e.Bounds.X, e.Bounds.Y));
                }
            }


        }


    }
}

