using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using PhalanxCommon.Entities;
using PhalanxBL;
using PhalanxMAL;

namespace PhalanxAdmin
{
    public partial class FTestMail : PhalanxAdmin.FModalBase
    {
        public FTestMail()
        {
            InitializeComponent();
        }

        private void FTestMail_Load(object sender, EventArgs e)
        {
            this.Title = "Test de envío de mails";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbParams.SelectedIndex >= 0 && txtMailDestin.Text != "")
            {

                string FromName = "";
                string FromMail = "";
                string Subject = "";
                string Body = "";

                PhxConfigBusiness conf = new PhxConfigBusiness();
                string SMTPServer = "";
                string SMTPUser = "";
                string SMTPPwd = "";
                string SMTPPort = "25";

                try
                {
                    FromName = "Phalanx Security Manager";
                    FromMail = conf.GetConfigParam(ConfigCodes.FromExpMails, false, false).ShortTxtValue;

                    SMTPServer = conf.GetConfigParam(ConfigCodes.SMTPDir, false, false).ShortTxtValue;
                    try
                    {
                        SMTPPort = (conf.GetConfigParam(ConfigCodes.SMTPPort, false).ShortTxtValue == "" ? "25" : conf.GetConfigParam(ConfigCodes.SMTPPort).ShortTxtValue);
                    }
                    catch (Exception exx)
                    {
                        SMTPPort = "25";
                    }
                    try
                    {
                        SMTPUser = conf.GetConfigParam(ConfigCodes.SMTPUsr, false, false).ShortTxtValue;
                        SMTPPwd = conf.GetConfigParam(ConfigCodes.SMTPPwd, false, false).ShortTxtValue;
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    // falta alguno de los parametros
                    MessageBox.Show("Hay parámetros de mailing faltantes. No se puede hacer el envío.", "Error en test de mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SendMail sMail;
                if (SMTPUser == "")
                {
                    sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort));
                }
                else
                {
                    sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort), SMTPUser, SMTPPwd);
                }




                if (cbParams.SelectedIndex == 0) // mail de solicitud
                {
                    Body = conf.GetConfigParam(ConfigCodes.BodySolicPwdMails).LongTxtValue;
                    Subject = "Solicitud de Contraseña"; //conf.GetConfigParam(ConfigCodes.).ShortTxtValue;
                }
                else if (cbParams.SelectedIndex == 1)
                {
                    Body = conf.GetConfigParam(ConfigCodes.BodyExpMails).LongTxtValue;
                    Subject = "Expiración de uso de Contraseña"; //conf.GetConfigParam(ConfigCodes.).ShortTxtValue;
                }

                bool IsSent = sMail.Send(FromName, FromMail, Subject, Body, "", txtMailDestin.Text, "", "", "", "");

                if (IsSent)
                {
                    MessageBox.Show("Se realizó el envío del mail de prueba");
                }
                else
                {
                    MessageBox.Show(sMail.Message, "Error al enviar mail de test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}

