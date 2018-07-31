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
    public partial class FConfigMailsExpPwd : FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Mails");
            }
        }

        public FConfigMailsExpPwd()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigMailsExpPwd";
            }
        }

        private void FConfigMailsExpPwd_Load(object sender, EventArgs e)
        {
            CargarComboParams();
            PhxUserBusiness UsrBL = new PhxUserBusiness();

            btnModif.Enabled = UsrBL.AccParamConfigMailsRW(this.Usuario);
            btnTestMail.Enabled = UsrBL.AccParamConfigMailsRW(this.Usuario);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            grpTags.Visible = false;


        }
        private void CargarComboParams()
        {
            cbParams.Items.Clear();
            PhxConfigBusiness ConfigBL = new PhxConfigBusiness();
            PhxConfigEntityCollection ConfEC = ConfigBL.GetMailsParams();
            cbParams.DataSource = ConfEC;

        }

        private void cbParams_SelectedValueChanged(object sender, EventArgs e)
        {
            MostrarInfoConfig();
        }

        private void MostrarInfoConfig()
        {
            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
            txtDescrip.Text = ConfEnt.Description;
            PhxConfigBusiness conf = new PhxConfigBusiness();
            if (
                ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyExpMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodySolicPwdMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp)
                )
            {
                txtValor.Multiline = true;
                txtValor.Text = ConfEnt.LongTxtValue;

            }
            else
            {
                txtValor.Multiline = false;
                txtValor.Text = ConfEnt.ShortTxtValue;
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            txtValor.ReadOnly = false;
            txtValor.Focus();
            btnModif.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            cbParams.Enabled = false;
            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
            PhxConfigBusiness conf = new PhxConfigBusiness();

            btnDiasRestantes.Enabled = false;
            btnFolio.Enabled = false;
            btnTagAplicativo.Enabled = false;
            btnTagDescUso.Enabled = false;
            btnTagDestino.Enabled = false;
            btnTagEstadoSolic.Enabled = false;
            btnTagFechaAlta.Enabled = false;
            btnTagFechaDev.Enabled = false;
            btnTagFechaExp.Enabled = false;
            btnTagFechaSolic.Enabled = false;
            btnTagNombreSolicitante.Enabled = false;
            btnTagNombreUsuario.Enabled = false;
            btnTagNomSolic.Enabled = false;
            btnTagNroTicket.Enabled = false;
            btnTagPwdSolic.Enabled = false;
            btnTagTiempoUso.Enabled = false;
            btnTagToken.Enabled = false;

            if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyExpMails))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = true;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = true;
                btnTagNroTicket.Enabled = true;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodySolicPwdMails))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = true;
                btnTagDescUso.Enabled = true;
                btnTagTiempoUso.Enabled = true;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = true;
                btnTagDescUso.Enabled = true;
                btnTagTiempoUso.Enabled = true;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = true;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectExpMails)
                    || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdRqstMails)
                      || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectRespPwdRqstMails)
)
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioRedMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = true;
                btnTagFechaAlta.Enabled = true;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = true;
                btnTagAplicativo.Enabled = true;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagNroTicket.Enabled = true;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = true;
                btnTagAplicativo.Enabled = true;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMails))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = true;
                btnTagNroTicket.Enabled = true;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = true;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMailsNoCritic)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = true;
                btnTagNroTicket.Enabled = true;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = true;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail))
            {
                grpTags.Visible = true;
                btnTagAplicativo.Enabled = true;
                btnTagNombreSolicitante.Enabled = true;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoRedMail) ||
                     ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail))
            {
                grpTags.Visible = true;
                btnTagNombreSolicitante.Enabled = true;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectReclamoNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = true;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagNroTicket.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = true;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = true;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
                btnTagNombreSolicitante.Enabled = false;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = true;
                btnTagPwdSolic.Enabled = false;
                btnTagNroTicket.Enabled = true;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = false;
                btnTagFechaAlta.Enabled = true;
                btnTagAplicativo.Enabled = false;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = true;
                btnTagDestino.Enabled = true;
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectVencPwdAppMails)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdAppMailsExp)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp))
            {
                grpTags.Visible = true;
                btnTagFechaExp.Enabled = false;
                btnTagFechaSolic.Enabled = false;
                btnTagNomSolic.Enabled = false;
                btnTagPwdSolic.Enabled = false;
                btnTagNroTicket.Enabled = false;
                btnTagDescUso.Enabled = false;
                btnTagTiempoUso.Enabled = false;
                btnTagEstadoSolic.Enabled = false;
                btnTagNombreUsuario.Enabled = true;
                btnTagFechaAlta.Enabled = false;
                btnTagAplicativo.Enabled = true;
                btnTagFechaDev.Enabled = false;
                btnTagToken.Enabled = false;
                btnTagDestino.Enabled = false;
                btnFolio.Enabled = true;
                btnDiasRestantes.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MostrarInfoConfig();
            txtValor.ReadOnly = true;
            grpTags.Visible = false;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // actualizar el selected item del combo con el nuevo valor y grabarlo

            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
            if (ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyExpMails)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodySolicPwdMails)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyDevMails)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp)
                )
            {
                ((PhxConfigEntity)cbParams.SelectedItem).LongTxtValue = txtValor.Text;

            }
            else
            {
                ((PhxConfigEntity)cbParams.SelectedItem).ShortTxtValue = txtValor.Text;
            }
            PhxConfigBusiness ConfBL = new PhxConfigBusiness();
            ConfBL.Save((PhxConfigEntity)cbParams.SelectedItem);
            txtValor.ReadOnly = true;
            grpTags.Visible = false;
            btnModif.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            cbParams.Enabled = true;

        }

        private void btnTagNomSolic_Click(object sender, EventArgs e)
        {
            string strTag = "[NombreSolic]";
            AgregarTag(strTag);
        }

        private void AgregarTag(string strTag)
        {
            if (txtValor.SelectionStart >= 0)
            {
                int SelStart = txtValor.SelectionStart;
                string strValor = txtValor.Text.Substring(0, txtValor.SelectionStart) + strTag
                    + txtValor.Text.Substring(txtValor.SelectionStart);
                txtValor.Text = strValor;
                txtValor.SelectionStart = SelStart + strTag.Length;
                txtValor.SelectionLength = 0;
                txtValor.Focus();
            }
        }

        private void btnTagFechaSolic_Click(object sender, EventArgs e)
        {
            string strTag = "[FechaSolic]";
            AgregarTag(strTag);

        }

        private void btnTagFechaExp_Click(object sender, EventArgs e)
        {
            string strTag = "[FechaExp]";
            AgregarTag(strTag);

        }

        private void btnTagPwdSolic_Click(object sender, EventArgs e)
        {
            string strTag = "[UsuarioSolic]";
            AgregarTag(strTag);

        }

        private void btnTestMail_Click(object sender, EventArgs e)
        {
            FTestMail formTestMail = new FTestMail();
            formTestMail.ShowDialog();
        }

        private void btnTagDescUso_Click(object sender, EventArgs e)
        {
            string strTag = "[DescripUso]";
            AgregarTag(strTag);

        }

        private void btnTagTiempoUso_Click(object sender, EventArgs e)
        {
            string strTag = "[TiempoUso]";
            AgregarTag(strTag);

        }

        private void btnTagNroTicket_Click(object sender, EventArgs e)
        {
            string strTag = "[NroTicket]";
            AgregarTag(strTag);

        }

        private void btnTagEstadoSolic_Click(object sender, EventArgs e)
        {
            string strTag = "[EstadoSolicitud]";
            AgregarTag(strTag);

        }

        private void btnTagNombreUsuario_Click(object sender, EventArgs e)
        {
            string strTag = "[NombreUsuario]";
            AgregarTag(strTag);
        }

        private void btnTagFechaAlta_Click(object sender, EventArgs e)
        {
            string strTag = "[FechaAlta]";
            AgregarTag(strTag);
        }

        private void btnTagAplicativo_Click(object sender, EventArgs e)
        {
            string strTag = "[Aplicativo]";
            AgregarTag(strTag);
        }

        private void btnTagFechaDev_Click(object sender, EventArgs e)
        {
            string strTag = "[FechaDev]";
            AgregarTag(strTag);
        }

        private void btnTagToken_Click(object sender, EventArgs e)
        {
            string strTag = "[Token]";
            AgregarTag(strTag);
        }

        private void btnTagDestino_Click(object sender, EventArgs e)
        {
            string strTag = "[Destino]";
            AgregarTag(strTag);
        }

        private void btnTagNombreSolicitante_Click(object sender, EventArgs e)
        {
            string strTag = "[NombreSolicitante]";
            AgregarTag(strTag);
        }

        private void btnDiasRestantes_Click(object sender, EventArgs e)
        {
            string strTag = "[DiasRestantes]";
            AgregarTag(strTag);
        }

        private void btnFolio_Click(object sender, EventArgs e)
        {
            string strTag = "[Folio]";
            AgregarTag(strTag);
        }
    }
}