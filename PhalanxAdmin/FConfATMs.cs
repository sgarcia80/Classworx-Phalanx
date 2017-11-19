using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;

namespace PhalanxAdmin
{
    public partial class FConfATMs : PhalanxAdmin.FBaseConfiguracion
    {
        FollowupRequestGroupEntity _GrupoSeguimDefecto;

        public FConfATMs()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigATMs";
            }
        }


        private void FConfATMs_Load(object sender, EventArgs e)
        {
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            btnModif.Enabled = UsrBL.AccParamGrpSeguimATMRW(this.Usuario);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            InicializarComboFRwstGrp();

        }

        private void InicializarComboFRwstGrp()
        {
            /// chequear si está asignado el grupo de seguimiento por defecto. Si no lo está, poner leyenda.
            /// Si lo está, mostrar el item en el combo y deshabilitar el combo
            _GrupoSeguimDefecto = new FollowupRequestGroupDefaultBusiness().GetDefaultFollowupRqstGrpATMs();
            cboGrpSeguim.Enabled = false;
            cboGrpSeguim.DropDownStyle = ComboBoxStyle.DropDown;
            if (_GrupoSeguimDefecto == null)
            {
                cboGrpSeguim.Text = "No hay un grupo establecido";
            }
            else
            {
                cboGrpSeguim.Text = _GrupoSeguimDefecto.Name;
            }
        }

        private void CargarComboGrupos()
        {
            cboGrpSeguim.DataSource = null;
            cboGrpSeguim.Items.Clear();
            cboGrpSeguim.DropDownStyle = ComboBoxStyle.DropDownList;
            FollowupRequestGroupBusiness FRqstGrpsB = new FollowupRequestGroupBusiness();
            FollowupRequestGroupEntityCollection FRqstGrpsEC = FRqstGrpsB.GetAll();
            cboGrpSeguim.DataSource = FRqstGrpsEC;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            CargarComboGrupos();
            if (_GrupoSeguimDefecto != null)
            {
                cboGrpSeguim.SelectedValue = _GrupoSeguimDefecto.Id;
            }
            cboGrpSeguim.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnModif.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboGrpSeguim.DataSource = null;
            cboGrpSeguim.Items.Clear();
            InicializarComboFRwstGrp();
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnModif.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                FollowupRequestGroupDefaultBusiness FRqstGrpB = new FollowupRequestGroupDefaultBusiness();
                FollowupRequestGroupDefaultEntity FRqstGrpDefE = FRqstGrpB.SetFollowupRqstGrpATMs((int)cboGrpSeguim.SelectedValue); //Convert.ToInt32(cboGrpSeguim.SelectedValue.ToString()));
                if (FRqstGrpDefE == null)
                {
                    MessageBox.Show("Se ha producido un error al grabar el Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", "Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Set cursor as default arrow
                    Cursor.Current = Cursors.Default;
                    return;
                }

                _GrupoSeguimDefecto = FRqstGrpDefE.FollowupRqstGrp;
                MessageBox.Show("Se ha grabado el Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", "Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Se ha producido un error al grabar el Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", "Grupo de Seguimiento de Solicitudes por defecto para los usuarios de ATMs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnModif.Enabled = true;
            InicializarComboFRwstGrp();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

    }
}

