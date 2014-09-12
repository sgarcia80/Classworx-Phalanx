using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FRptABMUsuariosDetail : PhalanxAdmin.FModalBase
    {
        AuditUsuariosEntity _auditUsr;

        public FRptABMUsuariosDetail(AuditUsuariosEntity AuditUsr)
        {
            InitializeComponent();
            _auditUsr = AuditUsr;
        }

        private void FRptABMUsuariosDetail_Load(object sender, EventArgs e)
        {
            this.Title = "Estado Inicial y Final de la acción realizada";
            if (_auditUsr.AuditPhxUserOld != null)
            {
                txtIdUsrIni.Text = _auditUsr.AuditPhxUserOld.PhxUserId.ToString();
                txtUsernameIni.Text = _auditUsr.AuditPhxUserOld.Username;
                txtFullnameIni.Text = _auditUsr.AuditPhxUserOld.Fullname;
                txtDomainIni.Text = _auditUsr.AuditPhxUserOld.Domain;
                txtEmailIni.Text = _auditUsr.AuditPhxUserOld.Email;
                txtFileNoIni.Text = _auditUsr.AuditPhxUserOld.FileNumber;
                txtRelTypeIni.Text = _auditUsr.AuditPhxUserOld.RelationType;
                txtBranchIni.Text = _auditUsr.AuditPhxUserOld.Branch;
                txtFunctionIni.Text = _auditUsr.AuditPhxUserOld.Function;
                txtBuilAdressIni.Text = _auditUsr.AuditPhxUserOld.BuildingAdress;
                txtBuildFloorIni.Text = _auditUsr.AuditPhxUserOld.BuildingFloor;
                txtExtNoIni.Text = _auditUsr.AuditPhxUserOld.ExtensionNumber;
                txtActiveIni.Text = (_auditUsr.AuditPhxUserOld.Active ? "Activo" : "Inactivo");
                if (_auditUsr.AuditPhxUserOld.SupId > 0)
                {
                    txtSuperiorIni.Text = _auditUsr.AuditPhxUserOld.SupId.ToString()
                        + " - " + _auditUsr.AuditPhxUserOld.SupName
                        + " ( " + _auditUsr.AuditPhxUserOld.SupMail + ")";
                }
            }
            if (_auditUsr.AuditPhxUserNew != null)
            {
                txtIdUsrFin.Text = _auditUsr.AuditPhxUserNew.PhxUserId.ToString();
                txtUsernameFin.Text = _auditUsr.AuditPhxUserNew.Username;
                txtFullnameFin.Text = _auditUsr.AuditPhxUserNew.Fullname;
                txtDomainFin.Text = _auditUsr.AuditPhxUserNew.Domain;
                txtEmailFin.Text = _auditUsr.AuditPhxUserNew.Email;
                txtFileNoFin.Text = _auditUsr.AuditPhxUserNew.FileNumber;
                txtRelTypeFin.Text = _auditUsr.AuditPhxUserNew.RelationType;
                txtBranchFin.Text = _auditUsr.AuditPhxUserNew.Branch;
                txtFunctionFin.Text = _auditUsr.AuditPhxUserNew.Function;
                txtBuilAdressFin.Text = _auditUsr.AuditPhxUserNew.BuildingAdress;
                txtBuildFloorFin.Text = _auditUsr.AuditPhxUserNew.BuildingFloor;
                txtExtNoFin.Text = _auditUsr.AuditPhxUserNew.ExtensionNumber;
                txtActiveFin.Text = (_auditUsr.AuditPhxUserNew.Active ? "Activo" : "Inactivo");
                if (_auditUsr.AuditPhxUserNew.SupId > 0)
                {
                    txtSuperiorFin.Text = _auditUsr.AuditPhxUserNew.SupId.ToString()
                        + " - " + _auditUsr.AuditPhxUserNew.SupName
                        + " ( " + _auditUsr.AuditPhxUserNew.SupMail + ")";
                }
            }
        }
    }
}

