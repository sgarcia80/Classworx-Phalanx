using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDCDAL.Factories;
using NDCBL;
using NDCCommon.Entities;
using PhalanxBL;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FReenvioMail : PhalanxAdmin.FModalBase
    {
        private MailAlertEntity email = null;

        public FReenvioMail(int idEmail)
        {
            InitializeComponent();
            this.Title = "Reenvio de email";

            MailAlertBusiness mab = new MailAlertBusiness();
            
            try
            {
                email = mab.GetMail(idEmail);
            }
            catch (Common.CwxException cwxEx)
            {
                MessageBox.Show(cwxEx.FullMessage);
                this.Close();
                return;
            }

            MostrarDestinatarios();
            
            txtAsunto.Text = email.Subject;
            txtCuerpo.Text = email.Body;
        }

        private void MostrarDestinatarios()
        {
            StringBuilder destinatarios = new StringBuilder();

            if (!string.IsNullOrEmpty(email.ToAddress))
                destinatarios.Append(email.ToAddress)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc1Address))
                destinatarios.Append(email.Cc1Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc2Address))
                destinatarios.Append(email.Cc2Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc3Address))
                destinatarios.Append(email.Cc3Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc4Address))
                destinatarios.Append(email.Cc4Address)
                    .Append(";");
            
            if (!string.IsNullOrEmpty(email.Cc5Address))
                destinatarios.Append(email.Cc5Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc6Address))
                destinatarios.Append(email.Cc6Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc7Address))
                destinatarios.Append(email.Cc7Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc8Address))
                destinatarios.Append(email.Cc8Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc9Address))
                destinatarios.Append(email.Cc9Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc10Address))
                destinatarios.Append(email.Cc10Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc11Address))
                destinatarios.Append(email.Cc11Address)
                    .Append(";");

            if (!string.IsNullOrEmpty(email.Cc12Address))
                destinatarios.Append(email.Cc12Address)
                    .Append(";");

            if (destinatarios.Length > 0)
                destinatarios.Remove(destinatarios.Length - 1, 1);

            txtDestinatarios.Text = destinatarios.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MailAlertBusiness mailAlertBusiness = new MailAlertBusiness();

                mailAlertBusiness.Reenviar(email.Id, txtDestinatarios.Text.Split(';'));

                MessageBox.Show("Email reenviado", "Reenvio de email");
            }
            catch
            {
                MessageBox.Show("Hubo problemas al reenviar el email", "Reenvio de email");
            }
        }
    }
}

