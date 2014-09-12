using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxBL;
using System.IO;

namespace PhalanxAdmin
{
    public partial class FDepuracionLogs : PhalanxAdmin.FBaseAuditoria
    {
        public override string Id
        {
            get
            {
                return "FDepuracionLogs";
            }
        }
        protected AuditLoginEntityCollection _entities;

        public FDepuracionLogs()
        {
            InitializeComponent();
        }


        private void FRptLogueos_Load(object sender, EventArgs e)
        {
            cbLog.SelectedIndex = 0;

            this.lnkCancelar.Visible = false;
            this.pbDB.Visible = false;
            lblStatus.Text = "Listo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strErrorMsg = "Verifique el formato de la fecha (dd/mm/aaaa)";
            
            try
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                DateTime dTest;
                if (txtFDesde.Text.Trim() == "/  /")
                {
                    MessageBox.Show("Ingrese la fecha de depuración", "Error");

                    return;
                }
                
                dTest = Convert.ToDateTime(txtFDesde.Text, dtfi);

                strErrorMsg = "Error al depurar";
                
                switch (cbLog.SelectedIndex)
                {
                    case 0:
                    case 1:
                        //Depuración Log de modificación de contraseñas 
                        new HistPasswordChangeBusiness().Depurar(dTest);
                        break;
                    case 2:
                        new AuditLoginBusiness().Depurar(dTest);
                        break;
                    
                }

                MessageBox.Show("Depuración realizada con éxito", "Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(strErrorMsg, "Error");
            }
        }
    }
}

