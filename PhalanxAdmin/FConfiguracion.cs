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

namespace PhalanxAdmin
{
    public partial class FConfiguracion : PhalanxAdmin.FBaseConfiguracion
    {
        //public override string Titulo
        //{
        //    get
        //    {
        //        return GetTitlePath(base.Titulo, "Configuración");
        //    }
        //}

        public FConfiguracion()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "Configuracion";
            }
        }

        private void FConfiguracion_Load(object sender, EventArgs e)
        {
            CargarComboAuth1();
        }
        private bool CargarComboAuth1()
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntityCollection AuthEC = PhxUsrBL.GetAuthForFilter();
            if (AuthEC.Count == 0)
            {
                return false;
            }
            cbAuth1.DataSource = AuthEC;
            PhxUserEntity SelAuth = new DemoConfBusiness().GetPwdRqstAuth();
            if (SelAuth == null)
            {
                cbAuth1.SelectedIndex = 0;
            }
            else
            {
                cbAuth1.SelectedItem = SelAuth;
            }
            return true;
            //PhxUserEntityCollection 
        }

        private void btnSaveAuth1_Click(object sender, EventArgs e)
        {
            if (cbAuth1.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un autorizador", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbAuth1.Focus();
                return;
            }
            DemoConfBusiness paraBL = new DemoConfBusiness();
            if (paraBL.SetPwdRqstAuthUserParam(((PhxUserEntity)cbAuth1.SelectedItem).Id))
            {
                MessageBox.Show("Se actualizó el usuario Autorizador con éxito");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el usuario Autorizador");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void xppnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bGuardarConexion_Click(object sender, EventArgs e)
        {
            if (tBServer.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre del servidor o su dirección IP");
                return;
            }
            if (tBBase.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre de la Base de Datos");
                return;
            }
            if (tBUser.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre de Usuario");
                return;
            }
            if (tBPassword.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el Password del Usuario");
                return;
            }
            
            string stringconnection = "server=" + tBServer.Text + ";";
            stringconnection += "database=" + tBBase.Text + ";";
            stringconnection += "uid=" + tBUser.Text + ";";
            stringconnection += "pwd=" + tBPassword.Text;

            try
            {
                PhalanxDAL.DBMgr.SetConnString(stringconnection);
                MessageBox.Show("Se han grabado los datos satisfactoriamente. " + Environment.NewLine +  "Debe reiniciar Phalanx.");
            }
            catch (SystemException se)
            {
                MessageBox.Show("Ha ocurrido un error al grabar los datos: " + se.Message);
            }

        }

    }
}

