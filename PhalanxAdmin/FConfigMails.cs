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
    public partial class FConfigMails : FBaseConfiguracion
    {
        public override string Titulo
        {
            get
            {
                return GetTitlePath(base.Titulo, "Mails");
            }
        }

        private List<MailTypeEntity> _ConfigList = new List<MailTypeEntity>();
        private MailTypeEntity _EditParam = new MailTypeEntity();

        public FConfigMails()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "ConfigMails";
            }
        }

        private void FConfigMailsExpPwd_Load(object sender, EventArgs e)
        {
            //CargarComboParams();
            //PhxUserBusiness UsrBL = new PhxUserBusiness();

            //btnModif.Enabled = UsrBL.AccParamConfigMailsRW(this.Usuario);
            //btnTestMail.Enabled = UsrBL.AccParamConfigMailsRW(this.Usuario);
            //btnSave.Enabled = false;
            //btnCancel.Enabled = false;
            //grpTags.Visible = false;

            SetEditMode(false);

            InicializaForm();
        }

        private void InicializaForm()
        {
            MailTypeBusiness business = new MailTypeBusiness();

            this._ConfigList = business.GetAllMails();

            tlvPlantillas.CanExpandGetter = delegate (object x)
            {
                return (x is MailGroupEntity);
            };
            tlvPlantillas.ChildrenGetter = delegate (object x)
            {
                List<MailTypeEntity> grupo = new List<MailTypeEntity>();

                if (x is MailGroupEntity)
                {
                    foreach (MailTypeEntity item in this._ConfigList)
                    {
                        if (item.Group.Key == (x as MailGroupEntity).Key)
                        {
                            grupo.Add(item);
                        }
                    }
                }
                return grupo;
            };

            tlvcolName.ImageGetter = delegate (object row)
            {
                if (row is MailTypeEntity)
                {
                    return "PlantillaMail";
                }
                return "";
            };

            //CwxUserBusiness UsrBL = new CwxUserBusiness();
            //pnlBotones.Visible = UsrBL.AccAdmMailsRW(base.UserName);
            pnlBotones.Visible = true;

            RefreshPlantillas();
            TreeListViewToScreen();
            SetEditMode(false);

            txtAsuntoMail.ContextMenuStrip = mnuTagsAsunto;
            txtCuerpoMail.ContextMenuStrip = mnuTagsCuerpo;
        }

        private void RefreshPlantillas()
        {

            tlvPlantillas.ClearObjects();
            if (_ConfigList.Count == 0)
                return;

            List<MailGroupEntity> grupos = new List<MailGroupEntity>();
            foreach (MailTypeEntity item in this._ConfigList)
            {
                if (grupos.FindAll(o => o.Id == item.Group.Id).Count == 0)
                {
                    grupos.Add(item.Group);
                }
            }
            tlvPlantillas.Roots = grupos;
            tlvPlantillas.ExpandAll();

        }
        private void SetEditMode(bool EditMode)
        {
            txtDescrip.ReadOnly = true;
            txtPlantilla.ReadOnly = true;

            pnlTest.Visible = !EditMode;
            pnlModificar.Visible = !EditMode;
            pnlSaveCancel.Visible = EditMode;
            txtAsuntoMail.ReadOnly = !EditMode;
            txtCuerpoMail.ReadOnly = !EditMode;

            //this._FormEditMode = EditMode;

            tlvPlantillas.Enabled = !EditMode;

            if (EditMode)
            {
                MailTypeEntity conf = tlvPlantillas.SelectedObjects[0] as MailTypeEntity;
                GenerarTagsMenu(conf.Subject, mnuTagsAsunto, txtAsuntoMail);

                if(mnuTagsAsunto.Items.Count > 0)
                { 
                txtAsuntoMail.ContextMenuStrip = mnuTagsAsunto;
                }

                if (mnuTagsCuerpo.Items.Count > 0)
                {
                    txtCuerpoMail.ContextMenuStrip = mnuTagsCuerpo;
                }
            }
            else
            {
                txtAsuntoMail.ContextMenuStrip = null;
                txtCuerpoMail.ContextMenuStrip = null;
            }
        }
        private void TreeListViewToScreen()
        {
            txtPlantilla.Text = _EditParam.Name;
            txtDescrip.Text = _EditParam.Description;
            txtAsuntoMail.Text = _EditParam.Subject != null ? _EditParam.Subject.ShortTxtValue : string.Empty;
            txtCuerpoMail.Text = _EditParam.Body != null ? _EditParam.Body.LongTxtValue : string.Empty;
            bool SinDatos = string.IsNullOrEmpty(_EditParam.Key);
            pnlContentDatos.Enabled = !SinDatos;
            //if (pnlBotones.Visible) { 
            pnlBotones.Enabled = !SinDatos;
            //}
        }

        private void tlvPlantillas_SelectionChanged(object sender, EventArgs e)
        {
            if (tlvPlantillas.SelectedObjects.Count == 1 && tlvPlantillas.SelectedObjects[0] is MailTypeEntity)
            {
                if (string.IsNullOrEmpty(_EditParam.Key)
                    || (!string.IsNullOrEmpty(_EditParam.Key) && (tlvPlantillas.SelectedObjects[0] as MailTypeEntity).Key != _EditParam.Key))
                {
                    _EditParam = tlvPlantillas.SelectedObjects[0] as MailTypeEntity;
                    TreeListViewToScreen();

                    SetEditMode(false);
                }
            }
            else
            {
                _EditParam = new MailTypeEntity();
                TreeListViewToScreen();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_EditParam == null || (_EditParam != null && _EditParam.Id == 0))
            {
                MessageBox.Show("Debe seleccionar un Plantilla para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetEditMode(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /// validaciones
            /// asignar al objeto
            ScreenToEntities();
            /// grabar el estado del objeto
            new MailTypeBusiness().Save(_EditParam);
            /// Salir del modo edición
            SetEditMode(false);
        }

        private void ScreenToEntities()
        {
            _EditParam.Subject.ShortTxtValue = txtAsuntoMail.Text;
            _EditParam.Body.LongTxtValue = txtCuerpoMail.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            /// preguntar si quiere continuar
            if (MessageBox.Show("Desea continuar sin grabar los cambios?", "Edición de plantillas de mails", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            { return; }
            /// Salir del modo edición
            SetEditMode(false);
            /// actualizar pantalla con datos de la DB
            TreeListViewToScreen();
        }
        private bool _toostriptitle = false;
        private void mnuTags_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuTags_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = _toostriptitle;
            _toostriptitle = false;
        }
        private void GenerarTagsMenu(PhxConfigEntity config, ContextMenuStrip mnuTags, TextBox control)
        {
            PhxConfigBusiness conf = new PhxConfigBusiness();

            //bool AsignaMenuAsunto = false;
            //bool AsignaMenuCuerpo = false;

            PhxConfigEntity ConfEnt = config;

            List<MailTagEntity> tags = new List<MailTagEntity>();

            var btnTagNomSolic = new MailTagEntity("NombreSolic", "[NombreSolic]", true, true, "Nombre Solicitante");
            var btnTagFechaSolic = new MailTagEntity("FechaSolic", "[FechaSolic]", true, true, "Fecha Solicitado");
            var btnTagFechaExp = new MailTagEntity("FechaExp", "[FechaExp]", true, true, "Fecha Expiración");
            var btnTagPwdSolic = new MailTagEntity("UsuarioSolic", "[UsuarioSolic]", true, true, "Usuario Solicitante");
            var btnTagDescUso = new MailTagEntity("DescripUso", "[DescripUso]", true, true, "Descripción Uso");
            var btnTagTiempoUso = new MailTagEntity("TiempoUso", "[TiempoUso]", true, true, "Tiempo de Uso");
            var btnTagNroTicket = new MailTagEntity("NroTicket", "[NroTicket]", true, true, "Nro. Ticket");
            var btnTagEstadoSolic = new MailTagEntity("EstadoSolicitud", "[EstadoSolicitud]", true, true, "Estado Solicitud");
            var btnTagNombreUsuario = new MailTagEntity("NombreUsuario", "[NombreUsuario]", true, true, "Nombre Usuario");
            var btnTagFechaAlta = new MailTagEntity("FechaAlta", "[FechaAlta]", true, true, "FechaAlta");
            var btnTagAplicativo = new MailTagEntity("Aplicativo", "[Aplicativo]", true, true, "Aplicativo");
            var btnTagFechaDev = new MailTagEntity("FechaDev", "[FechaDev]", true, true, "Fecha Devolución");
            var btnTagToken = new MailTagEntity("Token", "[Token]", true, true, "Token");
            var btnTagDestino = new MailTagEntity("Destino", "[Destino]", true, true, "Destino");
            var btnTagNombreSolicitante = new MailTagEntity("NombreSolicitante", "[NombreSolicitante]", true, true, "Nombre Solicitante");
            var btnDiasRestantes = new MailTagEntity("DiasRestantes", "[DiasRestantes]", true, true, "Dias Restantes");
            var btnFolio = new MailTagEntity("Folio", "[Folio]", true, true, "Folio");

            if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyExpMails))
            {
                tags.Add(btnTagFechaExp);
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagPwdSolic);
                tags.Add(btnTagNroTicket);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodySolicPwdMails))
            {
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagPwdSolic);
                tags.Add(btnTagDescUso);
                tags.Add(btnTagTiempoUso);
                tags.Add(btnTagNroTicket);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails))
            {
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagPwdSolic);
                tags.Add(btnTagDescUso);
                tags.Add(btnTagTiempoUso);
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagEstadoSolic);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectExpMails)
                    || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdRqstMails)
                      || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectRespPwdRqstMails))
            {
                tags.Add(btnTagNroTicket);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioRedMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail))
            {
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagNombreUsuario);
                tags.Add(btnTagFechaAlta);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail))
            {
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagFechaAlta);
                tags.Add(btnTagAplicativo);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail))
            {
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagFechaAlta);
                tags.Add(btnTagAplicativo);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMails)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMails))
            {
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagPwdSolic);
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagFechaDev);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMailsNoCritic)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic))
            {
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagPwdSolic);
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagFechaDev);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail))
            {
                tags.Add(btnTagAplicativo);
                tags.Add(btnTagNombreSolicitante);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoRedMail) ||
                     ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail))
            {
                tags.Add(btnTagNombreSolicitante);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectReclamoNotificacionBlanqueoMail)
                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail))
            {
                tags.Add(btnTagFechaSolic);
                tags.Add(btnTagNombreUsuario);
                tags.Add(btnTagAplicativo);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail))
            {
                tags.Add(btnTagNomSolic);
                tags.Add(btnTagNroTicket);
                tags.Add(btnTagFechaAlta);
                tags.Add(btnTagToken);
                tags.Add(btnTagDestino);
            }
            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectVencPwdAppMails)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdAppMailsExp)
                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp))
            {
                tags.Add(btnTagNombreUsuario);
                tags.Add(btnTagAplicativo);
                tags.Add(btnFolio);
                tags.Add(btnDiasRestantes);
            }

            mnuTags.Items.Clear();

            System.Windows.Forms.ToolStripMenuItem mnuItm1;

            foreach (MailTagEntity tag in tags)
            {
                mnuItm1 = new System.Windows.Forms.ToolStripMenuItem();

                mnuItm1.Text = tag.Description;
                mnuItm1.Name = "mnuItmAs" + tag.Code;
                mnuItm1.Tag = tag.Tag;

                if (mnuTags == mnuTagsAsunto)
                {
                    mnuItm1.Click += new System.EventHandler(this.TagsAsuntoMenuItem_Click);
                }
                if (mnuTags == mnuTagsCuerpo)
                {
                    mnuItm1.Click += new System.EventHandler(this.TagsCuerpoMenuItem_Click);
                }

                mnuTags.Items.Add(mnuItm1);
            }

            //txtAsuntoMail.ContextMenuStrip = (AsignaMenuAsunto ? mnuTagsAsunto : null);
            //txtCuerpoMail.ContextMenuStrip = (AsignaMenuCuerpo ? mnuTagsCuerpo : null);

        }

        private void TagsCuerpoMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem submenu = sender as ToolStripMenuItem;
            if (submenu == null)
            {
                return;
            }

            string strTag = submenu.Tag.ToString();
            if (txtCuerpoMail.SelectionStart >= 0)
            {
                int SelStart = txtCuerpoMail.SelectionStart;
                string strValor = txtCuerpoMail.Text.Substring(0, txtCuerpoMail.SelectionStart) + strTag
                    + txtCuerpoMail.Text.Substring(txtCuerpoMail.SelectionStart);
                txtCuerpoMail.Text = strValor;
                txtCuerpoMail.SelectionStart = SelStart + strTag.Length;
                txtCuerpoMail.SelectionLength = 0;
                txtCuerpoMail.Focus();
            }
        }
        private void TagsAsuntoMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem submenu = sender as ToolStripMenuItem;
            if (submenu == null)
            {
                return;
            }
            
            string strTag = submenu.Tag.ToString();

            if (txtAsuntoMail.SelectionStart >= 0)
            {
                int SelStart = txtAsuntoMail.SelectionStart;
                string strValor = txtAsuntoMail.Text.Substring(0, txtAsuntoMail.SelectionStart) + strTag
                    + txtAsuntoMail.Text.Substring(txtAsuntoMail.SelectionStart);
                txtAsuntoMail.Text = strValor;
                txtAsuntoMail.SelectionStart = SelStart + strTag.Length;
                txtAsuntoMail.SelectionLength = 0;
                txtAsuntoMail.Focus();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_EditParam == null || (_EditParam != null && _EditParam.Id == 0))
            {
                MessageBox.Show("Debe seleccionar un Plantilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtToMailTest.Text))
            {
                MessageBox.Show("Debe introducir un mail para realizar la prueba", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //CwxMailTicketBusiness ticketbusiness = new CwxMailTicketBusiness();

            //var file = Properties.Resources.alert_email_macro;

            //bool ok;

            //if (!string.IsNullOrEmpty(file))
            //{
            //    ok = ticketbusiness.TestMail(_EditParam, txtToMailTest.Text.Trim(), file);
            //}
            //else
            //{
            //    ok = ticketbusiness.TestMail(_EditParam, txtToMailTest.Text.Trim());
            //}


            //if (ok)
            //{
            //    MessageBox.Show("El mail se ha enviado correctamente", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //}
        }

        private void mnuTagsAsunto_Opening(object sender, CancelEventArgs e)
        {
            MailTypeEntity conf = tlvPlantillas.SelectedObjects[0] as MailTypeEntity;

            GenerarTagsMenu(conf.Subject, mnuTagsAsunto, txtAsuntoMail);
        }

        private void mnuTagsCuerpo_Opening(object sender, CancelEventArgs e)
        {
            MailTypeEntity conf = tlvPlantillas.SelectedObjects[0] as MailTypeEntity;

            GenerarTagsMenu(conf.Body, mnuTagsCuerpo, txtCuerpoMail);
        }




        //        private void CargarComboParams()
        //        {
        //            cbParams.Items.Clear();
        //            PhxConfigBusiness ConfigBL = new PhxConfigBusiness();
        //            PhxConfigEntityCollection ConfEC = ConfigBL.GetMailsParams();
        //            cbParams.DataSource = ConfEC;

        //        }

        //        private void cbParams_SelectedValueChanged(object sender, EventArgs e)
        //        {
        //            MostrarInfoConfig();
        //        }

        //        private void MostrarInfoConfig()
        //        {
        //            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
        //            txtDescrip.Text = ConfEnt.Description;
        //            PhxConfigBusiness conf = new PhxConfigBusiness();
        //            if (
        //                ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyExpMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodySolicPwdMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp)
        //                )
        //            {
        //                txtValor.Multiline = true;
        //                txtValor.Text = ConfEnt.LongTxtValue;

        //            }
        //            else
        //            {
        //                txtValor.Multiline = false;
        //                txtValor.Text = ConfEnt.ShortTxtValue;
        //            }
        //        }

        //        private void btnModif_Click(object sender, EventArgs e)
        //        {
        //            txtValor.ReadOnly = false;
        //            txtValor.Focus();
        //            btnModif.Enabled = false;
        //            btnSave.Enabled = true;
        //            btnCancel.Enabled = true;
        //            cbParams.Enabled = false;
        //            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
        //            PhxConfigBusiness conf = new PhxConfigBusiness();

        //            btnDiasRestantes.Enabled = false;
        //            btnFolio.Enabled = false;
        //            btnTagAplicativo.Enabled = false;
        //            btnTagDescUso.Enabled = false;
        //            btnTagDestino.Enabled = false;
        //            btnTagEstadoSolic.Enabled = false;
        //            btnTagFechaAlta.Enabled = false;
        //            btnTagFechaDev.Enabled = false;
        //            btnTagFechaExp.Enabled = false;
        //            btnTagFechaSolic.Enabled = false;
        //            btnTagNombreSolicitante.Enabled = false;
        //            btnTagNombreUsuario.Enabled = false;
        //            btnTagNomSolic.Enabled = false;
        //            btnTagNroTicket.Enabled = false;
        //            btnTagPwdSolic.Enabled = false;
        //            btnTagTiempoUso.Enabled = false;
        //            btnTagToken.Enabled = false;

        //            if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyExpMails))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = true;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = true;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodySolicPwdMails))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = true;
        //                btnTagDescUso.Enabled = true;
        //                btnTagTiempoUso.Enabled = true;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = true;
        //                btnTagDescUso.Enabled = true;
        //                btnTagTiempoUso.Enabled = true;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = true;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectExpMails)
        //                    || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdRqstMails)
        //                      || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectRespPwdRqstMails)
        //)
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioRedMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = true;
        //                btnTagFechaAlta.Enabled = true;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = true;
        //                btnTagAplicativo.Enabled = true;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = true;
        //                btnTagAplicativo.Enabled = true;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMails)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMails))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = true;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = true;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectDevMailsNoCritic)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = true;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = true;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagAplicativo.Enabled = true;
        //                btnTagNombreSolicitante.Enabled = true;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectNotificacionBlanqueoRedMail) ||
        //                     ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagNombreSolicitante.Enabled = true;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectReclamoNotificacionBlanqueoMail)
        //                || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = true;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagNroTicket.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = true;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = true;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //                btnTagNombreSolicitante.Enabled = false;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = true;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagNroTicket.Enabled = true;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = false;
        //                btnTagFechaAlta.Enabled = true;
        //                btnTagAplicativo.Enabled = false;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = true;
        //                btnTagDestino.Enabled = true;
        //            }
        //            else if (ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectVencPwdAppMails)
        //                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
        //                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.SubjectPwdAppMailsExp)
        //                  || ConfEnt.Code == conf.ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp))
        //            {
        //                grpTags.Visible = true;
        //                btnTagFechaExp.Enabled = false;
        //                btnTagFechaSolic.Enabled = false;
        //                btnTagNomSolic.Enabled = false;
        //                btnTagPwdSolic.Enabled = false;
        //                btnTagNroTicket.Enabled = false;
        //                btnTagDescUso.Enabled = false;
        //                btnTagTiempoUso.Enabled = false;
        //                btnTagEstadoSolic.Enabled = false;
        //                btnTagNombreUsuario.Enabled = true;
        //                btnTagFechaAlta.Enabled = false;
        //                btnTagAplicativo.Enabled = true;
        //                btnTagFechaDev.Enabled = false;
        //                btnTagToken.Enabled = false;
        //                btnTagDestino.Enabled = false;
        //                btnFolio.Enabled = true;
        //                btnDiasRestantes.Enabled = true;
        //            }
        //        }

        //        private void btnCancel_Click(object sender, EventArgs e)
        //        {
        //            MostrarInfoConfig();
        //            txtValor.ReadOnly = true;
        //            grpTags.Visible = false;
        //            btnModif.Enabled = true;
        //            btnSave.Enabled = false;
        //            btnCancel.Enabled = false;
        //            cbParams.Enabled = true;

        //        }

        //        private void btnSave_Click(object sender, EventArgs e)
        //        {
        //            // actualizar el selected item del combo con el nuevo valor y grabarlo

        //            PhxConfigEntity ConfEnt = ((PhxConfigEntity)cbParams.SelectedItem);
        //            if (ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyExpMails)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodySolicPwdMails)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyRespSolicPwdMails)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyDevMails)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyAltaUsuarioRedExternoMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyNotificacionBlanqueoRedMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyReclamoNotificacionBlanqueoMail)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyDevMailsNoCritic)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyVencPwdAppMails)
        //                || ConfEnt.Code == new PhxConfigBusiness().ParamCodeToString(ConfigCodes.BodyPwdAppMailsExp)
        //                )
        //            {
        //                ((PhxConfigEntity)cbParams.SelectedItem).LongTxtValue = txtValor.Text;

        //            }
        //            else
        //            {
        //                ((PhxConfigEntity)cbParams.SelectedItem).ShortTxtValue = txtValor.Text;
        //            }
        //            PhxConfigBusiness ConfBL = new PhxConfigBusiness();
        //            ConfBL.Save((PhxConfigEntity)cbParams.SelectedItem);
        //            txtValor.ReadOnly = true;
        //            grpTags.Visible = false;
        //            btnModif.Enabled = true;
        //            btnSave.Enabled = false;
        //            btnCancel.Enabled = false;
        //            cbParams.Enabled = true;

        //        }

        //        private void btnTagNomSolic_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[NombreSolic]";
        //            AgregarTag(strTag);
        //        }

        //        private void AgregarTag(string strTag)
        //        {
        //            if (txtValor.SelectionStart >= 0)
        //            {
        //                int SelStart = txtValor.SelectionStart;
        //                string strValor = txtValor.Text.Substring(0, txtValor.SelectionStart) + strTag
        //                    + txtValor.Text.Substring(txtValor.SelectionStart);
        //                txtValor.Text = strValor;
        //                txtValor.SelectionStart = SelStart + strTag.Length;
        //                txtValor.SelectionLength = 0;
        //                txtValor.Focus();
        //            }
        //        }

        //        private void btnTagFechaSolic_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[FechaSolic]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagFechaExp_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[FechaExp]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagPwdSolic_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[UsuarioSolic]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTestMail_Click(object sender, EventArgs e)
        //        {
        //            FTestMail formTestMail = new FTestMail();
        //            formTestMail.ShowDialog();
        //        }

        //        private void btnTagDescUso_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[DescripUso]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagTiempoUso_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[TiempoUso]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagNroTicket_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[NroTicket]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagEstadoSolic_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[EstadoSolicitud]";
        //            AgregarTag(strTag);

        //        }

        //        private void btnTagNombreUsuario_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[NombreUsuario]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagFechaAlta_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[FechaAlta]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagAplicativo_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[Aplicativo]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagFechaDev_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[FechaDev]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagToken_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[Token]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagDestino_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[Destino]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnTagNombreSolicitante_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[NombreSolicitante]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnDiasRestantes_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[DiasRestantes]";
        //            AgregarTag(strTag);
        //        }

        //        private void btnFolio_Click(object sender, EventArgs e)
        //        {
        //            string strTag = "[Folio]";
        //            AgregarTag(strTag);
        //        }
    }
}