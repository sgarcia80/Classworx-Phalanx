using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;
using phxLog;

namespace PhalanxAdmin
{
    public partial class FAltaDominio : PhalanxAdmin.FModalBase
    {
        public enum FormType
        {
            New,
            Update,
            View
        }
        private FormType m_FormType;
        private WinDomainBusiness mWinDomBus = null;
        private WinDomainEntity m_CurrentDomain = null;

        public FAltaDominio(): base()
        {
            InitializeComponent();
            mWinDomBus = new WinDomainBusiness();
            m_FormType = FormType.New;
        }
        
        public FAltaDominio(WinDomainEntity currDomain):this()
        {
            m_CurrentDomain = currDomain;
            txtDomName.Text = m_CurrentDomain.NtName;
            txtComment.Text = m_CurrentDomain.Comments;
			txtLDAPPath.Text = currDomain.LDAPPath;
            pNetFind.Visible = false;
            m_FormType = FormType.Update;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (txtDomName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar un Nombre de Dominio");
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                if (m_FormType == FormType.New)
                    NewDomain();
                else
                    UpdateDomain();
            }
            catch
            { 
                MessageBox.Show("Error al intentar crear un Dominio");
            }

        }

        private void NewDomain()
        {
            try
            {
                if (!mWinDomBus.Exists(txtDomName.Text))
                {
                    PhalanxCommon.Entities.WinDomainEntity dom = new PhalanxCommon.Entities.WinDomainEntity();
                    dom.NtName = txtDomName.Text;
                    dom.Comments = txtComment.Text;
					dom.LDAPPath = txtLDAPPath.Text;
                    mWinDomBus.Save(dom);
                    MessageBox.Show("Se ha creado el Dominio satisfactoriamente");
                }
                else
                {
                    if (MessageBox.Show("El Dominio ya existe en el sistema. " + Environment.NewLine +
                                        "Desea Actualizar el Dominio con los datos actuales?", "Actualizar Dominio", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                    {
                        m_CurrentDomain = mWinDomBus.FillData(m_CurrentDomain);
                        m_CurrentDomain.NtName = txtDomName.Text;
                        m_CurrentDomain.Comments = txtComment.Text;
						m_CurrentDomain.LDAPPath = txtLDAPPath.Text;
                        mWinDomBus.Save(m_CurrentDomain);
                        MessageBox.Show("Se ha actualizado el Dominio satisfactoriamente");
                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Ha ocurrido un error al crear el Dominio: " + Environment.NewLine + exc.Message);
            }
        }

        private void UpdateDomain()
        {
            try
            {
                m_CurrentDomain.NtName = txtDomName.Text;
                m_CurrentDomain.Comments = txtComment.Text;
				m_CurrentDomain.LDAPPath = txtLDAPPath.Text;
                mWinDomBus.Save(m_CurrentDomain);
                MessageBox.Show("Se ha modificado el Dominio satisfactoriamente");
            }
            catch (Exception exc)
            {

                MessageBox.Show("Ha ocurrido un error al modificar el Dominio: " + Environment.NewLine + exc.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void pNetFind_Click(object sender, EventArgs e)
        {
            FSelectWinDomains selWinDom = new FSelectWinDomains();
            selWinDom.Title = "Busqueda de Dominios";
            if (selWinDom.ShowDialog() == DialogResult.OK)
            {
                WinDomainEntity selectedDomain = (WinDomainEntity)selWinDom.GetSelectedEntity();
                if (selectedDomain != null)
                {
                    m_CurrentDomain = selectedDomain;
                    txtDomName.Text = selectedDomain.NtName;
                    txtComment.Text = selectedDomain.Comments;
					txtLDAPPath.Text = selectedDomain.LDAPPath;
                }
            }
        }

		private void FAltaDominio_Load(object sender, EventArgs e)
		{

		}


    }
}

