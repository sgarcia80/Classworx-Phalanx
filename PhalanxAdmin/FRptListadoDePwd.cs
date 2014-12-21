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
using Microsoft.Reporting.WinForms;

namespace PhalanxAdmin
{
    public partial class FRptListadoDePwd : PhalanxAdmin.FBaseReportes
    {
        public override string Id
        {
            get
            {
				return "FRptListadoDePwd";
            }
        }
		protected IList<FRptListadoDePwdEntity> _entities;

		public FRptListadoDePwd()
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
			/*
			List<DatabaseUserEntity> databaseUsers = new List<DatabaseUserEntity>();
			List<ApplicationUserEntity> applicationUsers = new List<ApplicationUserEntity>();
			List<UnixUserEntity> unixUsers = new List<UnixUserEntity>();
			List<AS400UserEntity> AS400Users = new List<AS400UserEntity>();
			List<ATMUserEntity> ATMUsers = new List<ATMUserEntity>();
			List<WinLocalUserEntity> WinLocalUsers = new List<WinLocalUserEntity>();
			List<CommunicationDeviceUserEntity> CommunicationDeviceUsers = new List<CommunicationDeviceUserEntity>();
			 */

			_entities = new List<FRptListadoDePwdEntity>();
				
			DatabaseUserBusiness dbb = new DatabaseUserBusiness();
			
			if (rbOrderFolio.Checked)
				dbb.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				dbb.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				dbb.SetOrderByName();

			DatabaseUserEntityCollection dbList = dbb.GetAll();

			foreach (DatabaseUserEntity user in dbList)
			{
				string p = dbb.GetPassword(user);
				user.User_RealPassword = p;
				//databaseUsers.Add(user);			
				_entities.Add(new FRptListadoDePwdEntity(user));
			}
			
			ApplicationUserBusiness appb = new ApplicationUserBusiness();
			
			if (rbOrderFolio.Checked)
				appb.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				appb.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				appb.SetOrderByName();

			ApplicationUserEntityCollection appList = appb.GetAll();

			foreach (ApplicationUserEntity user in appList)
			{
				string p = appb.GetPassword(user);
				user.User_RealPassword = p;
				//applicationUsers.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
			}
					
			UnixUserBusiness unixb = new UnixUserBusiness();
				
			if (rbOrderFolio.Checked)
				unixb.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				unixb.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				unixb.SetOrderByName();
			
			UnixUserEntityCollection unixList = unixb.GetAll();

			foreach (UnixUserEntity user in unixList)
			{
				string p = unixb.GetPassword(user);
				user.User_RealPassword = p;
				user.Server_Name = user.Unix.ServerName;
				//unixUsers.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
			}

			AS400UserBusiness AS400b = new AS400UserBusiness();

			if (rbOrderFolio.Checked)
				AS400b.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				AS400b.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				AS400b.SetOrderByName();
	
			AS400UserEntityCollection AS400List = AS400b.GetAll();

			foreach (AS400UserEntity user in AS400List)
			{
				string p = AS400b.GetPassword(user);
				user.User_RealPassword = p;
				user.Server_Name = user.AS400.ServerName;
				//AS400Users.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
			}
			
			ATMUserBusiness ATMb = new ATMUserBusiness();

			if (rbOrderFolio.Checked)
				ATMb.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				ATMb.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				ATMb.SetOrderByName();
			
			ATMUserEntityCollection ATMList = ATMb.GetAll();

			foreach (ATMUserEntity user in ATMList)
			{
				string p = ATMb.GetPassword(user);
				user.User_RealPassword = p;
				//ATMUsers.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
			}
			
			WinLocalUserBusiness wlub = new WinLocalUserBusiness();
			
			if (rbOrderFolio.Checked)
				wlub.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				wlub.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				wlub.SetOrderByName();
			
			WinLocalUserEntityCollection list = wlub.GetAll();

			foreach (WinLocalUserEntity user in list)
			{
				string p = wlub.GetPassword(user);
				user.User_RealPassword = p;
				//WinLocalUsers.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
			}
				
			CommunicationDeviceUserBusiness cdb = new CommunicationDeviceUserBusiness();

			if (rbOrderFolio.Checked)
				cdb.SetOrderByFolio();
			else if (rbOrderUsrName.Checked)
				cdb.SetOrderByUserName();
			else if (rbOrderUsrPath.Checked)
				cdb.SetOrderByName();

			CommunicationDeviceUserEntityCollection cdList = cdb.GetAll();

			foreach (CommunicationDeviceUserEntity user in cdList)
			{
				string p = cdb.GetPassword(user);
				user.User_RealPassword = p;
				//CommunicationDeviceUsers.Add(user);
				_entities.Add(new FRptListadoDePwdEntity(user));
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

			foreach (FRptListadoDePwdEntity userEntity in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                lviArr[i].Text = userEntity.Folio;
                lviArr[i].SubItems.Add(userEntity.Ambiente);
				lviArr[i].SubItems.Add(userEntity.Username);
                lviArr[i].SubItems.Add(userEntity.User_RealPassword);
                lviArr[i].SubItems.Add(userEntity.State);
				lviArr[i].SubItems.Add(userEntity.LastChangeDate); // HistChgPwdEnt.User.Username;
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
                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FileName = "Phalanx ABM Perfiles";
                saveFileDialog1.Title = "Exportar a CSV";
                StringBuilder sb = new StringBuilder();
                string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                foreach (ColumnHeader ch in lvLista.Columns)
                {
                    sb.Append(ch.Text + Separator);
                }
                foreach (ListViewItem lvi in lvLista.Items)
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

        private void FRptABMPerfiles_Load(object sender, EventArgs e)
        {
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";

        }

		private void btnBuscar_Click_1(object sender, EventArgs e)
		{
			try
			{
				ExecEntitiesRefresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al buscar");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (_entities == null)
					LoadEntities();

				LocalReport report = new LocalReport();
				report.ReportEmbeddedResource = "PhalanxAdmin.FRptListadoDePwd.rdlc";
				//report.ReportPath = "FRptListadoDePwd.rdlc";
				ReportDataSource rds = new ReportDataSource();
				rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
				rds.Value = _entities;
				report.DataSources.Add(rds);

				String v_mimetype;
                String v_encoding;
                String v_filename_extension;
                String[] v_streamids;
				Microsoft.Reporting.WinForms.Warning[] warnings;
				string _sSuggestedName = "Phalanx Listado de Contraseñas";

				Byte[] mybytes = report.Render("PDF", null, out v_mimetype, out v_encoding, out v_filename_extension, out v_streamids, out warnings);
				
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();

				saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf";
				saveFileDialog1.FilterIndex = 2;
				saveFileDialog1.RestoreDirectory = true;
				saveFileDialog1.FileName = _sSuggestedName;
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
					newFile.Write(mybytes, 0, mybytes.Length);
					newFile.Close();
					MessageBox.Show("La exportación ha sido completada", "Exportación a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a PDF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
    }

	public class FRptListadoDePwdEntity
	{
		public FRptListadoDePwdEntity(UserEntity user)
		{
			Folio = user.Id.ToString();
			Ambiente = user.UserType.Desc;
			Username = ObtenerUsuario(user);
			User_RealPassword = user.User_RealPassword;
			State = user.State;
			LastChangeDate = user.LastChangeDate;
		}

		public string Username { set; get; }
		public string Folio { set; get; }
		public string Ambiente { set; get; }
		public string User_RealPassword { set; get; }
		public string State { set; get; }
		public string LastChangeDate { set; get; }

		private string ObtenerUsuario(UserEntity usuario)
		{
			if (usuario is WinLocalUserEntity)
			{
				WinLocalUserEntity entidad = usuario as WinLocalUserEntity;

				return entidad.Domain + "\\" + entidad.PCName + "\\" + entidad.Username;
			}
			else if (usuario is UnixUserEntity)
			{
				UnixUserEntity entidad = usuario as UnixUserEntity;

				return entidad.Server_Name + "\\" + entidad.Username;
			}
			else if (usuario is AS400UserEntity)
			{
				AS400UserEntity entidad = usuario as AS400UserEntity;

				return entidad.Server_Name + "\\" + entidad.Username;
			}
			else if (usuario is DatabaseUserEntity)
			{
				DatabaseUserEntity entidad = usuario as DatabaseUserEntity;

				return entidad.DBType + "\\" + entidad.DBName + "\\" + entidad.Username;
			}
			else if (usuario is ATMUserEntity)
			{
				ATMUserEntity entidad = usuario as ATMUserEntity;

				return entidad.ATMName + "\\" + entidad.Username;
			}
			else if (usuario is CommunicationDeviceUserEntity)
			{
				CommunicationDeviceUserEntity entidad = usuario as CommunicationDeviceUserEntity;

				return entidad.CommunicationDeviceType + "\\" + entidad.CommunicationDeviceName + "\\" + entidad.Username;
			}
            else if (usuario is ApplicationUserEntity)
            {
                ApplicationUserEntity entidad = usuario as ApplicationUserEntity;

                return entidad.ApplicationName + "\\" + entidad.Username;
            }

			return usuario.Username;
		}
	}
}

