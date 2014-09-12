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

namespace PhalanxAdmin
{
    public partial class FListadoContingencia : PhalanxAdmin.FBaseReportes
    {
        protected WinLocalUserEntityCollection _entities;
        protected string _filNombre = "";
        private int comboGroupSelected = 0;
        private int comboGroupSelectedValue = 0;
        //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        public override string Id
        {
            get
            {
                return "FListadoContingencia";
            }
        }

        public FListadoContingencia()
        {
            InitializeComponent();
            dateTimeDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            dateTimeHasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 999);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PasswordRequestBusiness prb = new PasswordRequestBusiness();

            PasswordRequestEntityCollection list = prb.GetRequestCriticalPwd(dateTimeDesde.Value, dateTimeHasta.Value, radioButtonFecha.Checked);

            List<PasswordRequestEntity> finalList = new List<PasswordRequestEntity>();
            foreach (PasswordRequestEntity pass in list)
            {
                bool found = false;

                if (pass.User.Critical)
                {
                    found = true;
                    if (pass.UserPassword.UsersList[0] is WinLocalUserEntity)
                    {
                        pass.ReportContrasenia = ((WinLocalUserEntity)pass.UserPassword.UsersList[0]).Domain +
                            "\\" + ((WinLocalUserEntity)pass.UserPassword.UsersList[0]).PCName +
                            "\\" + ((WinLocalUserEntity)pass.UserPassword.UsersList[0]).Username;
                        pass.ReportContraseniaType = "Windows";
                    }
                    else if (pass.UserPassword.UsersList[0] is UnixUserEntity)
                    {
                        pass.ReportContrasenia = ((UnixUserEntity)pass.UserPassword.UsersList[0]).Unix.ServerName +
                            "\\" + ((UnixUserEntity)pass.UserPassword.UsersList[0]).Username;
                        pass.ReportContraseniaType = "Unix-Linux";
                    }
                    else if (pass.UserPassword.UsersList[0] is AS400UserEntity)
                    {
                        pass.ReportContrasenia = ((AS400UserEntity)pass.UserPassword.UsersList[0]).AS400.ServerName +
                            "\\" + ((AS400UserEntity)pass.UserPassword.UsersList[0]).Username;
                        pass.ReportContraseniaType = "AS400";
                    }
                    else if (pass.UserPassword.UsersList[0] is ApplicationUserEntity)
                    {
                        pass.ReportContrasenia = ((ApplicationUserEntity)pass.UserPassword.UsersList[0]).ApplicationName +
                            "\\" + ((ApplicationUserEntity)pass.UserPassword.UsersList[0]).Username;
                        pass.ReportContraseniaType = "Aplicativo";
                    }
                    else if (pass.UserPassword.UsersList[0] is DatabaseUserEntity)
                    {
                        pass.ReportContrasenia = ((DatabaseUserEntity)pass.UserPassword.UsersList[0]).DBName +
                            "\\" + ((DatabaseUserEntity)pass.UserPassword.UsersList[0]).Username;
                        pass.ReportContraseniaType = "Base de Datos";
                    }
                    pass.ReportFolio = pass.User.Id.ToString();
                }
                
                if (found)
                {
                    finalList.Add(pass);
                }
            }

            PasswordRequestEntityBindingSource.DataSource = finalList;
            reportViewer.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FWinPwd_Load(object sender, EventArgs e)
        {
           
        }

        private void dateTimeDesde_ValueChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(dateTimeDesde.Value.ToString());
        }

        private void dateTimeHasta_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimeHasta.Value.ToString());
        }
    }
}

