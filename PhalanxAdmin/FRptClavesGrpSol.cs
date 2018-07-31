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
    public partial class FRptClavesGrpSol : PhalanxAdmin.FBaseReportesNormativos
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Claves por Grupos de Solicitudes");
            }
        }

        public FRptClavesGrpSol()
        {
            InitializeComponent();
            #region comun en herencia FBaseReportes NO se modifica
            lvLista.ListViewItemSorter = new cwxSorter();
            #endregion

        }
        #region comun en herencia FBaseReportes y se modifica
        public override string Id
        {
            get
            {
                return "RptClavesGrpSol";
            }
        }
        protected vwPwdRqstGrpEntityCollection _entities;
        #endregion

        #region comun en herencia FBaseReportes NO se modifica
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
        private void bwRefreshEntities_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DBRefreshEntites();
        }
        private void DBRefreshEntites()
        {
            LoadEntities();
            RefreshEntitiesLV();
        }
        private void RefreshEntitiesLV()
        {
            ListViewItem[] lviArr = GenerateLVItems();
            SetLVItems(lviArr);
        }
        delegate void SetItemsAddRangeCallback(ListViewItem[] lvitems);
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
        #endregion
        #region comun en herencia FBaseReportes y se modifica
        private void SetQueryFilters()
        {
        }
        private void LoadEntities()
        {
            vwPwdRqstGrpBusiness DBUsrBL = new vwPwdRqstGrpBusiness();
            bool IncActivas = true;
            bool IncNoActivas = true;
            bool IncCriticas = true;
            bool IncNoCriticas = true;
            if (!rbFilActivasTodas.Checked)
            {
                IncActivas = rbFilActivasSi.Checked;
                IncNoActivas = rbFilActivasNo.Checked;
            }
            if (!rbFilCriticasTodas.Checked)
            {
                IncCriticas = rbFilCriticasSi.Checked;
                IncNoCriticas = rbFilCriticasNo.Checked;
            }
            bool? FilGrupoActivo = null;
            if (rbFilGrpActivosSi.Checked)
            { FilGrupoActivo = true; }
            else if (rbFilGrpActivosNo.Checked)
            { FilGrupoActivo = false; }
            _entities = DBUsrBL.GetAll(IncActivas, IncNoActivas, IncCriticas, IncNoCriticas
                , chkAmbWin.Checked, chkAmbUnix.Checked, chkAmbAS400.Checked, chkAmbApp.Checked, chkAmbDB.Checked, chkAmbEC.Checked, chkAmbATM.Checked, FilGrupoActivo);
        }
        private ListViewItem[] GenerateLVItems()
        {
            ListViewItem[] lviArr = new ListViewItem[this._entities.Count];
            int i = 0;
            foreach (vwPwdRqstGrpEntity AppUsrEnt in this._entities)
            {
                lviArr[i] = new ListViewItem();
                /// hay que armar los items de lo que se traiga de la DB
                lviArr[i].Text = AppUsrEnt.Folio.ToString();
                lviArr[i].SubItems.Add(AppUsrEnt.Ambiente);
                lviArr[i].SubItems.Add(AppUsrEnt.Usuario);
                lviArr[i].SubItems.Add(AppUsrEnt.Critico ? "Si" : "No");
                lviArr[i].SubItems.Add(AppUsrEnt.Activo ? "Activo" : "Inactivo");
                lviArr[i].SubItems.Add(AppUsrEnt.Grupo);
                lviArr[i].SubItems.Add(AppUsrEnt.GrupoActivo ? "Activo" : "Inactivo");

                lviArr[i].Tag = AppUsrEnt;
                i++;
            }
            return lviArr;

        }
        #endregion

        private void FRptClavesGrpSol_Load(object sender, EventArgs e)
        {
            #region comun en herencia FBaseReportes NO se modifica
            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";
            //ExecEntitiesRefresh();
        #endregion

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ValidateFilters())
                {
                    DBRefreshEntites();

                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    saveFileDialog1.FileName = "ClavesPorGrupoSolicitudes";
                    saveFileDialog1.Title = "Exportar a CSV";

                    StringBuilder sb = new StringBuilder();
                    string Separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    sb.Append("Folio" + Separator);
                    sb.Append("Ambiente" + Separator);
                    sb.Append("Usuario" + Separator);
                    sb.Append("Critico" + Separator);
                    sb.Append("Activo" + Separator);
                    sb.Append("Grupo" + Separator);
                    sb.Append("Grupo Activo");

                    foreach (vwPwdRqstGrpEntity AppUsrEnt in this._entities)
                    {
                        sb.AppendLine();
                        sb.Append(AppUsrEnt.Folio.ToString() + Separator);
                        sb.Append(AppUsrEnt.Ambiente + Separator);
                        sb.Append(AppUsrEnt.Usuario + Separator);
                        sb.Append((AppUsrEnt.Critico ? "Si" : "No") + Separator);
                        sb.Append((AppUsrEnt.Activo ? "Activo" : "Inactivo") + Separator);
                        sb.Append(AppUsrEnt.Grupo + Separator);
                        sb.Append(AppUsrEnt.GrupoActivo ? "Activo" : "Inactivo");
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
