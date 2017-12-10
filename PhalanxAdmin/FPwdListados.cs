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
using Microsoft.Reporting.WinForms;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FPwdListados : PhalanxAdmin.FBaseReportes
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Listados");
            }
        }

        private RequestGroupEntityCollection _myGroups;
        protected WinLocalUserEntityCollection _entities;
        protected string _filNombre = "";
        private int comboGroupSelected = 0;
        private int comboGroupSelectedValue = 0;
        //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        public override string Id
        {
            get
            {
                return "WinPwdListados";
            }
        }

        public FPwdListados()
        {
            InitializeComponent();
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            PopulateGroups();
        }

        private void PopulateGroups()
        {
            RequestGroupBusiness RqstGrpBL = new RequestGroupBusiness();
            _myGroups = RqstGrpBL.GetAll(true);
            RequestGroupEntity eTodos = new RequestGroupEntity();
            eTodos.Id = -1;
            eTodos.RqstGrpName = "Todos";
            eTodos.Active = true;
            _myGroups.Insert(0, eTodos);
            CBGoups.DataSource = _myGroups;
            CBGoups.DisplayMember = "RqstGrpNameInactTxt";
            CBGoups.ValueMember = "Id";
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            if (e.ReportPath == "UsersPasswordList_db")
            {
                List<DatabaseUserEntity> finalList = new List<DatabaseUserEntity>();
                DatabaseUserBusiness dbb = new DatabaseUserBusiness();
                if (rbOrderFolio.Checked)
                {
                    dbb.SetOrderByFolio();
                }
                else
                    if (rbOrderUsrName.Checked)
                    {
                        dbb.SetOrderByUserName();
                    }
                    else
                        if (rbOrderUsrPath.Checked)
                        {
                            dbb.SetOrderByName();
                        }
                DatabaseUserEntityCollection dbList = dbb.GetAll();

                foreach (DatabaseUserEntity user in dbList)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        dbb.RefrechGroupsList(user);

                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = dbb.GetPassword(user);
                        user.User_RealPassword = p;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_DatabaseUserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_app")
            {
                List<ApplicationUserEntity> finalList = new List<ApplicationUserEntity>();
                ApplicationUserBusiness appb = new ApplicationUserBusiness();
                if (rbOrderFolio.Checked)
                {
                    appb.SetOrderByFolio();
                }
                else if (rbOrderUsrName.Checked)
                {
                    appb.SetOrderByUserName();
                }
                else if (rbOrderUsrPath.Checked)
                {
                    appb.SetOrderByName();
                }

                ApplicationUserEntityCollection appList = appb.GetAll();

                foreach (ApplicationUserEntity user in appList)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        appb.RefrechGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = appb.GetPassword(user);
                        user.User_RealPassword = p;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_ApplicationUserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_unix")
            {
                List<UnixUserEntity> finalList = new List<UnixUserEntity>();
                UnixUserBusiness unixb = new UnixUserBusiness();
                if (rbOrderFolio.Checked)
                {
                    unixb.SetOrderByFolio();
                }
                else if (rbOrderUsrName.Checked)
                {
                    unixb.SetOrderByUserName();
                }
                else if (rbOrderUsrPath.Checked)
                {
                    unixb.SetOrderByName();
                }
                UnixUserEntityCollection unixList = unixb.GetAll();

                foreach (UnixUserEntity user in unixList)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        unixb.RefrechGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = unixb.GetPassword(user);
                        user.User_RealPassword = p;
                        user.Server_Name = user.Unix.ServerName;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_UnixUserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_as400")
            {
                List<AS400UserEntity> finalList = new List<AS400UserEntity>();
                AS400UserBusiness AS400b = new AS400UserBusiness();
                if (rbOrderFolio.Checked)
                {
                    AS400b.SetOrderByFolio();
                }
                else if (rbOrderUsrName.Checked)
                {
                    AS400b.SetOrderByUserName();
                }
                else if (rbOrderUsrPath.Checked)
                {
                    AS400b.SetOrderByName();
                }
                AS400UserEntityCollection AS400List = AS400b.GetAll();

                foreach (AS400UserEntity user in AS400List)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        AS400b.RefrechGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = AS400b.GetPassword(user);
                        user.User_RealPassword = p;
                        user.Server_Name = user.AS400.ServerName;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_AS400UserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_ATM")
            {
                List<ATMUserEntity> finalList = new List<ATMUserEntity>();
                ATMUserBusiness ATMb = new ATMUserBusiness();
                if (rbOrderFolio.Checked)
                {
                    ATMb.SetOrderByFolio();
                }
                else if (rbOrderUsrName.Checked)
                {
                    ATMb.SetOrderByUserName();
                }
                else if (rbOrderUsrPath.Checked)
                {
                    ATMb.SetOrderByName();
                }
                ATMUserEntityCollection ATMList = ATMb.GetAll();

                foreach (ATMUserEntity user in ATMList)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        ATMb.RefrechGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = ATMb.GetPassword(user);
                        user.User_RealPassword = p;
                        //user.ATMName = user.ATM.ServerName;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_ATMUserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_win")
            {
                WinLocalUserBusiness wlub = new WinLocalUserBusiness();
                if (rbOrderFolio.Checked)
                {
                    wlub.SetOrderByFolio();
                }
                else if (rbOrderUsrName.Checked)
                {
                    wlub.SetOrderByUserName();
                }
                else if (rbOrderUsrPath.Checked)
                {
                    wlub.SetOrderByName();
                }
                WinLocalUserEntityCollection list = wlub.GetAll();

                List<WinLocalUserEntity> finalList = new List<WinLocalUserEntity>();
                foreach (WinLocalUserEntity user in list)
                {
                    bool found = false;
                    if (comboGroupSelected > 0)
                    {
                        wlub.RefrechGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = wlub.GetPassword(user);
                        user.User_RealPassword = p;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_WinLocalUserEntity", finalList));
            }
            else if (e.ReportPath == "UsersPasswordList_ec")
            {
                List<CommunicationDeviceUserEntity> finalList = new List<CommunicationDeviceUserEntity>();
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
                    bool found = false;

                    if (comboGroupSelected > 0)
                    {
                        cdb.RefreshGroupsList(user);
                        foreach (RqstGrpPwdEntity rGPL in user.UserPassword.RqstGrpsPwdsList)
                        {
                            if (rGPL.RqstGrp.Id == comboGroupSelectedValue)
                                found = true;
                        }
                    }
                    else
                        found = true;

                    if (found)
                    {
                        string p = cdb.GetPassword(user);
                        user.User_RealPassword = p;
                        finalList.Add(user);
                    }
                }
                e.DataSources.Add(new ReportDataSource("PhalanxCommon_Entities_CommunicationDeviceUserEntity", finalList));
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            comboGroupSelected = CBGoups.SelectedIndex;
            comboGroupSelectedValue = Convert.ToInt32(CBGoups.SelectedValue);
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FWinPwd_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.GetDefaultPageSettings().Margins.Bottom = 60;
            reportViewer1.LocalReport.GetDefaultPageSettings().Margins.Top = 40;
            reportViewer1.LocalReport.GetDefaultPageSettings().Margins.Left = 20;
            reportViewer1.LocalReport.GetDefaultPageSettings().Margins.Right = 20;
            reportViewer1.LocalReport.GetDefaultPageSettings().PaperSize.RawKind = 9; //A4


        }

        private void reportViewer1_MarginChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                comboGroupSelected = CBGoups.SelectedIndex;
                comboGroupSelectedValue = Convert.ToInt32(CBGoups.SelectedValue);
                reportViewer1.RefreshReport();

                string _sPathFilePDF = String.Empty;
                String v_mimetype;
                String v_encoding;
                String v_filename_extension;
                String[] v_streamids;
                Microsoft.Reporting.WinForms.Warning[] warnings;
                string _sSuggestedName = "Phalanx Listado de Contraseñas";

                //Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
                Microsoft.Reporting.WinForms.LocalReport objRDLC = new Microsoft.Reporting.WinForms.LocalReport();
                //reportViewer1.LocalReport.ReportEmbeddedResource = "reportViewer1.rdlc";
                //reportViewer1.LocalReport.DisplayName = _sSuggestedName;

                objRDLC.DataSources.Clear();
                byte[] byteViewer = reportViewer1.LocalReport.Render("PDF", null, out v_mimetype, out v_encoding, out v_filename_extension, out v_streamids, out warnings);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = _sSuggestedName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    newFile.Write(byteViewer, 0, byteViewer.Length);
                    newFile.Close();
                    MessageBox.Show("La exportación ha sido completada", "Exportación a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido completar la exportación. (" + ex.Message + ")", "Error en Exportación a PDF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CBGoups_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Let's highlight the currently selected item like any well 
            // behaved combo box should
            Font myFont = new System.Drawing.Font("Microsoft Sans Serif", (float)8.25);

            /// setea el fondo del item con el color por defecto del sistema para items seleccionados,
            /// luego cuando no es un item seleccionado lo pinta con fondo blanco
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            // si está activo no dibuja el icono de inactivo
            if (_myGroups[e.Index].Active)
            {
                e.Graphics.DrawString(_myGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                  new Point(imageList.Images[0].Width, e.Bounds.Y));
                //e.Graphics.DrawImage(imageList.Images[0], new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                // el grupo está inactivo, hay que agregar el icono
                e.Graphics.DrawString(_myGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                  new Point(imageList.Images[1].Width + 2, e.Bounds.Y));
                e.Graphics.DrawImage(imageList.Images[1], new Point(e.Bounds.X, e.Bounds.Y));
            }
            //is the mouse hovering over a combobox item??            
            if ((e.State & DrawItemState.Focus) == 0)
            {
                // al no ser un item seleccionado le pinta el fondo de blanco
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                //this code keeps the last item drawn from having a Bisque background. 
                if (_myGroups[e.Index].Active)
                {
                    e.Graphics.DrawString(_myGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                      new Point(imageList.Images[0].Width, e.Bounds.Y));
                    //e.Graphics.DrawImage(imageList.Images[0], new Point(e.Bounds.X, e.Bounds.Y));
                }
                else
                {
                    // el grupo está inactivo, hay que agregar el icono
                    e.Graphics.DrawString(_myGroups[e.Index].RqstGrpName, myFont, Brushes.Black,
                                      new Point(imageList.Images[1].Width + 2, e.Bounds.Y));
                    e.Graphics.DrawImage(imageList.Images[1], new Point(e.Bounds.X, e.Bounds.Y));
                }
            }

        }
    }
}

