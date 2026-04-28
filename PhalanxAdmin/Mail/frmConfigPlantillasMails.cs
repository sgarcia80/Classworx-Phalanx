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

namespace PhalanxAdmin
{
    public partial class frmConfigPlantillasMails : PhalanxAdmin.frmBaseMaxMdiChilds
    {
        public frmConfigPlantillasMails()
          : base()
        {
            InitializeComponent();
            #region Parte copy paste entre forms y cambia contenido
            //SetFormTitle = "Plantillas de mails";
            #endregion
            InicializaForm();
        }

        private List<MailTypeEntity> _ConfigList = new List<MailTypeEntity>();
        private MailTypeEntity _EditParam = new MailTypeEntity();
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
        }
        private void RefreshPlantillas()
        {

            tlvPlantillas.ClearObjects();
            if (_ConfigList.Count == 0)
                return;

            List<MailGroupEntity> grupos = new List<MailGroupEntity>();
            foreach (MailTypeEntity item in this._ConfigList)
            {
                if (grupos.FindAll( o=> o.Id == item.Group.Id).Count == 0)
                {
                    grupos.Add(item.Group);
                }
            }
            tlvPlantillas.Roots = grupos;
            tlvPlantillas.ExpandAll();

        }
        private void SetEditMode(bool EditMode)
        {
            pnlTest.Visible = !EditMode;
            pnlModificar.Visible = !EditMode;
            pnlSaveCancel.Visible = EditMode;
            txtAsuntoMail.ReadOnly = !EditMode;
            txtCuerpoMail.ReadOnly = !EditMode;

            //this._FormEditMode = EditMode;

            tlvPlantillas.Enabled = !EditMode;

            if (EditMode)
            {
                GenerarTagsMenu();
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
            txtAsuntoMail.Text = _EditParam.Subject != null ? _EditParam.Subject.ShortTxtValue: string.Empty;
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
            _toostriptitle = (e.ClickedItem.Name == "mnuitmTitleAsunto" || e.ClickedItem.Name == "mnuitmTitleCuerpo");
        }

        private void mnuTags_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = _toostriptitle;
            _toostriptitle = false;
        }
        private void GenerarTagsMenu()
        {
            bool AsignaMenuAsunto = false;
            bool AsignaMenuCuerpo = false;
            //List<CwxMailTagEntity> tags = new CwxMailTagBusiness().GetTicketTags(_EditParam.Id);

            //foreach (CwxMailTagEntity tag in tags)
            //{
            //    if (tag.IsSubjectValue)
            //    {
            //        System.Windows.Forms.ToolStripMenuItem mnuItm1;

            //        mnuItm1 = new System.Windows.Forms.ToolStripMenuItem();
            //        mnuItm1.Text = tag.Description;
            //        //mnuItm1.Size = new System.Drawing.Size(214, 22);
            //        mnuItm1.Name = "mnuItmAs" + tag.Code;
            //        mnuItm1.Tag = tag.Tag;
            //        mnuItm1.Click += new System.EventHandler(this.TagsAsuntoMenuItem_Click);
            //        mnuTagsAsunto.Items.Add(mnuItm1);
            //        AsignaMenuAsunto = true;
            //    }
            //    if (tag.IsBodyValue)
            //    {
            //        System.Windows.Forms.ToolStripMenuItem mnuItm1;

            //        mnuItm1 = new System.Windows.Forms.ToolStripMenuItem();
            //        mnuItm1.Text = tag.Description;
            //        //mnuItm1.Size = new System.Drawing.Size(214, 22);
            //        mnuItm1.Name = "mnuItmCp" + tag.Code;
            //        mnuItm1.Tag = tag.Tag;
            //        mnuItm1.Click += new System.EventHandler(this.TagsCuerpoMenuItem_Click);
            //        mnuTagsCuerpo.Items.Add(mnuItm1);
            //        AsignaMenuCuerpo = true;
            //    }
            //}

            txtAsuntoMail.ContextMenuStrip = (AsignaMenuAsunto ? mnuTagsAsunto : null);
            txtCuerpoMail.ContextMenuStrip = (AsignaMenuCuerpo ? mnuTagsCuerpo : null);

        }

        private void TagsCuerpoMenuItem_Click(object sender, EventArgs e)
        {
            string strTag = (sender as ToolStripMenuItem).Tag.ToString();
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
            string strTag = (sender as ToolStripMenuItem).Tag.ToString();
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
    }
}
