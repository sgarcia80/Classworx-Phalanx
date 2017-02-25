using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxConfig
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bGuardarConexion_Click(object sender, EventArgs e)
        {
            //server=localhost;database=phalanx;uid=sa;pwd=elfortin

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
            /*if (tBPassword.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el Password del Usuario");
                return;
            }*/

            string stringconnection = "server=" + tBServer.Text + ";";
            stringconnection += "database=" + tBBase.Text + ";";
            stringconnection += "uid=" + tBUser.Text + ";";
            stringconnection += "pwd=" + tBPassword.Text;

            bool found = false;
            string AppType = string.Empty;
            if (radioButtonAdmin.Checked)
                AppType = ".\\PhalanxAdmin.exe.config";
            else
                AppType = ".\\Web.Config";

            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(AppType);
                for (int k = 0; k < doc.ChildNodes.Count; k++)
                {
                    if (doc.ChildNodes.Item(k).Name.ToLower() == "configuration")
                    {
                        foreach (System.Xml.XmlNode node in doc.ChildNodes.Item(k))
                        {
                            if (node.LocalName.ToLower() == "connectionstrings")
                            {
                                for (int i = 0; i < node.ChildNodes.Count; i++)
                                {
                                    if (node.ChildNodes.Item(i).Attributes["name"].Value.ToLower() == "phalanx")
                                    {
                                        node.ChildNodes.Item(i).Attributes["connectionString"].Value = (new phxCryptMgr.CCryptMgr()).encryptConfigFile(stringconnection);
                                        found = true;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                if (found)
                {
                    doc.Save(AppType);
                    MessageBox.Show("Los datos se han guardado satisfactoriamente");
                }
                else 
                    MessageBox.Show("No se pudo hallar las entradas y/o los datos de configuración dentro del archivo " + AppType);
            }
            catch (SystemException se)
            {
                MessageBox.Show("Ha ocurrido un error al guardar la configuración: " + se.Message);
            }

        }

        private void bGenerarConexion_Click(object sender, EventArgs e)
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

            string stringconnection = "server=" + tBServer.Text + ";";
            stringconnection += "database=" + tBBase.Text + ";";
            stringconnection += "uid=" + tBUser.Text + ";";
            stringconnection += "pwd=" + tBPassword.Text;

            if (!string.IsNullOrEmpty(tBTimeout.Text))
            {
                stringconnection += ";Connection Timeout=" + tBTimeout.Text + ";";
            }

            string cs = (new phxCryptMgr.CCryptMgr()).encryptConfigFile(stringconnection);

            Clipboard.SetDataObject(cs, true);

            MessageBox.Show(cs);            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tBDominio.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el dominio");
                return;
            }
            if (tBUsuario.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre de usuario");
                return;
            }
            if (tbPass.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe ingresar el password");
                return;
            }

            string stringconnection = "dominio=" + tBDominio.Text + ";"
                        + "usuario=" + tBUsuario.Text + ";"
                        + "password=" + tbPass.Text;

            string cs = (new phxCryptMgr.CCryptMgr()).encrypt(stringconnection);

            Clipboard.SetDataObject(cs, true);

            MessageBox.Show(cs);
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            if (rbDesConfig.Checked)
            {
                txtDescencTxt.Text = (new phxCryptMgr.CCryptMgr()).decryptConfigFileAndClearBadChars(txtEncTxt.Text);
            }
            if (rbDesSimple.Checked)
            {
                txtDescencTxt.Text = (new phxCryptMgr.CCryptMgr()).decryptAndClearBadChars(txtEncTxt.Text);
            }
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            if (rbEncConfig.Checked)
            {
                txtConEncTxt.Text = (new phxCryptMgr.CCryptMgr()).encryptConfigFile(txtSinEncTxt.Text);
            }
            if (rbEncSimple.Checked)
            {
                txtConEncTxt.Text = (new phxCryptMgr.CCryptMgr()).encrypt(txtSinEncTxt.Text);
            }
        }
    }
}