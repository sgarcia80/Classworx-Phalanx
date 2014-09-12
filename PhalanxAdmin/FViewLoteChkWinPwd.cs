using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FViewLoteChkWinPwd : PhalanxAdmin.FModalBase
    {
        LoteChkWinLocalUsersEntity _lote;
        ItemLoteChkWinLocalUsersEntityCollection _itemsLote;
        bool _actualizaDatosLote = false;
        public FViewLoteChkWinPwd(LoteChkWinLocalUsersEntity Lote)
        {
            _lote = Lote;
            InitializeComponent();
            CargaDatosLote();
            RefreshLista();
            lblStatus.Visible = false;
            pbDB.Visible = false;
            //btnAccion.Enabled = (!(_lote.FechaFinProceso == null));
        }
        protected void CargaDatosLote()
        {
            new LoteChkWinLocalUsersBusiness().Refresh(_lote);
            lblNroLote.Text = _lote.Key;
            lblFFin.Text = (_lote.FechaFinProceso == null ? "" : _lote.FechaFinProceso.Value.ToString("dd/MM/yyyy HH:m:ss"));
            lblFGeneracion.Text = _lote.FechaCreacion.ToString("dd/MM/yyyy HH:m:ss");
            lblFInicio.Text = (_lote.FechaInicioProceso == null ? "" : _lote.FechaInicioProceso.Value.ToString("dd/MM/yyyy HH:m:ss"));
            lblFProgramada.Text = _lote.FechaProgramada.ToString("dd/MM/yyyy HH:m:ss");
            btnAccion.Enabled = (!(_lote.FechaFinProceso == null));

        }
        protected void RefreshLista()
        {
            ItemLoteChkWinLocalUsersBusiness WinPwdBL = new ItemLoteChkWinLocalUsersBusiness();
            // filtros
            bool? ChkPwdOK = null;
            bool? AccesoNombre = null;
            bool? AccesoIP = null;
            if (cbChkPwd.SelectedItem != null)
            {
                switch (cbChkPwd.SelectedItem.ToString())
                {
                    case "Todos":
                        break;
                    case "Correcto":
                        ChkPwdOK = true;
                        break;
                    case "Incorrecto":
                        ChkPwdOK = false;
                        break;
                }
            }
            if (cbAccesoNombre.SelectedItem != null)
            {
            switch (cbAccesoNombre.SelectedItem.ToString())
            {
                case "Todos":
                    break;
                case "Correcto":
                    AccesoNombre = true;
                    break;
                case "Incorrecto":
                    AccesoNombre = false;
                    break;
            }
            }
            if (cbAccesoIP.SelectedItem != null)
            {
                switch (cbAccesoIP.SelectedItem.ToString())
                {
                    case "Todos":
                        break;
                    case "Correcto":
                        AccesoIP = true;
                        break;
                    case "Incorrecto":
                        AccesoIP = false;
                        break;
                }
            }
            _itemsLote = WinPwdBL.BuscaItemsDeLote(_lote, ChkPwdOK, AccesoNombre, AccesoIP);
            lvItmsLote.Items.Clear();

            foreach (ItemLoteChkWinLocalUsersEntity ItmLote in _itemsLote)
            {

                ListViewItem lviAux = new ListViewItem();
                //lviAux.SubItems.Add(ItmLote.WinLocalUser.NetPath);
                lviAux.SubItems.Add(ItmLote.WinLocalUser.Domain);
                lviAux.SubItems.Add(ItmLote.WinLocalUser.PCName);
                lviAux.SubItems.Add(ItmLote.WinLocalUser.Username);
                string strFechaChk = "";
                if (ItmLote.FechaChk != null)
                {
                    strFechaChk = ItmLote.FechaChk.Value.ToString("dd/MM/yyyy HH:m:ss");
                }
                lviAux.SubItems.Add(strFechaChk);
                string strChkPwd = "";
                if (ItmLote.ChkPwd != null)
                {
                    strChkPwd = (ItmLote.ChkPwd.Value ? "OK" : "Falló");
                }
                lviAux.SubItems.Add(strChkPwd);
                string strChkNomEq = "";
                if (ItmLote.ChkPingNombreEquipo != null)
                {
                    strChkNomEq = (ItmLote.ChkPingNombreEquipo.Value ? "OK" : "Falló");
                }
                lviAux.SubItems.Add(strChkNomEq);

                string strChkIPEq = "";
                if (ItmLote.ChkPingIPEquipo != null)
                {
                    strChkIPEq = (ItmLote.ChkPingIPEquipo.Value ? "OK" : "Falló");
                }
                lviAux.SubItems.Add(strChkIPEq);

                string strChkUserName = "";
                if (ItmLote.ChkUsername != null)
                {
                    strChkUserName = (ItmLote.ChkUsername.Value ? "OK" : "Falló");
                }
                lviAux.SubItems.Add(strChkUserName);

                string strNombreEq = "";
                if (ItmLote.NombreEquipoPingIP != null)
                {
                    strNombreEq = ItmLote.NombreEquipoPingIP;
                }
                lviAux.SubItems.Add(strNombreEq);
                string Accion = "";
                if (ItmLote.Accion != null)
                {
                    Accion = ItmLote.Accion.Nombre;
                }
                lviAux.SubItems.Add(Accion);
                lviAux.Text = ItmLote.WinLocalUser.Key;
                lviAux.Tag = ItmLote;

                lvItmsLote.Items.Add(lviAux);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.pbDB.Visible = true;
            lblStatus.Visible = true;
            if (bwRefreshEntities.IsBusy)
            {
                bwRefreshEntities.CancelAsync();
            }
            else
            {
                groupBox1.Enabled = false;
                this.bwRefreshEntities.RunWorkerAsync();
            }

            //this.pbDB.Visible = false;
            //lblStatus.Visible = false;
            //Cursor.Current = Cursors.Default;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshLista();
        }

        private void FViewLoteChkWinPwd_Load(object sender, EventArgs e)
        {
            this.Title = "Lote de chequeo de contraseñas de usuarios Windows";
            cbAccesoIP.SelectedIndex = 0;
            cbAccesoNombre.SelectedIndex = 0;
            cbChkPwd.SelectedIndex = 0;

            if (_lote.FechaInicioProceso == null)
            {
                btnBorrarLote.Enabled = true;
            }
            else
            {
                btnBorrarLote.Enabled = false;
            }
            if (_lote.FechaFinProceso == null)
            {
                btnProcesar.Enabled = true;
                grpFiltros.Enabled = false;
            }
            else
            {
                btnProcesar.Enabled = false;
                grpFiltros.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_actualizaDatosLote)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnBorrarLote_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se va a dar de baja el lote. Desea continuar?", "Baja de lote de chequeo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoteChkWinLocalUsersBusiness LoteBL = new LoteChkWinLocalUsersBusiness();
                if (LoteBL.Baja(_lote))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Hubo problemas para dar de baja el lote");
                }
            }

        }
        //lvWinPwdDB.Items.AddRange(GenerarLVItmsWinPwd(WinPwdAAsignarALvDB));
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
                this.Cursor = Cursors.Default;
            }
        }
        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            // procesa lote
            LoteChkWinLocalUsersBusiness LoteBL = new LoteChkWinLocalUsersBusiness();
            LoteBL.ProcesarLote(_lote);
            bwRefreshEntities.ReportProgress(-100, "TEST");


        }

        private void bwRefreshEntities_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -100)
             // -100 indicates a new item should be added
            {
                CargaDatosLote();
                RefreshLista();
                _actualizaDatosLote = true;

                if (_lote.FechaFinProceso == null)
                {
                    btnProcesar.Enabled = true;
                    grpFiltros.Enabled = false;
                }
                else
                {
                    btnProcesar.Enabled = false;
                    grpFiltros.Enabled = true;
                }

                //this.lblStatus.Text = "Lote Procesado"; // e.Result.ToString();
                lblStatus.Visible = false;
                this.pbDB.Visible = false;
                groupBox1.Enabled = true;

            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (lvItmsLote.SelectedItems.Count == 1)
            {
                ItemLoteChkWinLocalUsersEntity ItemLote = (ItemLoteChkWinLocalUsersEntity)lvItmsLote.SelectedItems[0].Tag;
                if (ItemLote.Accion == null)
                {
                    FAccionItemLoteChkWinPwd frmAccion = new FAccionItemLoteChkWinPwd(ItemLote);
                    if (frmAccion.ShowDialog() == DialogResult.OK)
                    {
                        CargaDatosLote();
                    }
                }
                else
                {
                    MessageBox.Show("Ya se ha realizado una acción con este item");
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FileName = "ReportePhalanx";
            saveFileDialog1.Title = "Exportar a CSV";
            StringBuilder sb = new StringBuilder(); 
            foreach (ColumnHeader ch in lvItmsLote.Columns) 
            { 
                sb.Append(ch.Text + ","); 
            } 
            sb.AppendLine();
            foreach (ListViewItem lvi in lvItmsLote.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    if (lvs.Text.Trim() == string.Empty)
                        sb.Append(" ,");
                    else
                        sb.Append(lvs.Text + ",");
                }
                sb.AppendLine();
            }
            DialogResult dr = saveFileDialog1.ShowDialog(); 
            if (dr == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_actualizaDatosLote)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

    }
}

