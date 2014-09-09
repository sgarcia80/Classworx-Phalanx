using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Net.Mail;

namespace PhalanxMAL
{
    public class PasswordRqstMail
    {
        public PasswordRqstMail()
        {
        }
        void Create()
        {
        }
        public void SendMail(PasswordRequestEntity PwdRqst)
        {
            string RqstUserName = "";
            string RqstUserMail = "";
            string SuperiorName = "";
            string SuperiorMail = "";
            string AuthGroupName = "";
            string AuthGroupMail = "";
            string FromName = "";
            string FromMail = "";
            string MailBody = "";
            string MailSubject = "";
            string SMTPServer = "";
            string SMTPPort = "";

            // ver los mails a enviar
            // buscar el texto en config
            // reemplazar los tags
            MailMessage mail = new MailMessage();
            // traer el mail del solicitante y ponerlo en el to
            MailAddress MailToDir = new MailAddress(SuperiorMail, SuperiorName);
            //MailAddress MailToDir = new MailAddress(PwdRqst.RqstUser.Email, PwdRqst.RqstUser.Fullname);
            mail.To.Add(MailToDir);
            //traer mail de admins y poner en el CC
            MailAddress MailAuthGroup = new MailAddress(AuthGroupMail);
            mail.CC.Add(MailAuthGroup);
            MailAddress MailRqstUser = new MailAddress(RqstUserMail, RqstUserName);
            mail.CC.Add(MailRqstUser);
            mail.From = new MailAddress(FromMail);
            //mail.Body = ReplaceExpirationRqstTokens(EmailBody, PwdRqst);
            mail.Body = MailBody;
            mail.Subject = MailSubject;
            try
            {
                SmtpClient sMail = new SmtpClient(SMTPServer, Convert.ToInt32(SMTPPort)); //exchange or smtp server goes here.
                //sMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                //sMail.Credentials = new NetworkCredential("username","password");this line most likely wont be needed if you are already an authenticated user.
                //sMail.UseDefaultCredentials = false; // esto es si se le pasan credenciales
                sMail.Send(mail); //fromEmail, ToEmail, subject, body);
            }
            catch (Exception ex)
            {
                //do something after error if there is one
                throw (ex);
            }


        }
        private string ReplaceExpirationRqstTokens(string MailBody, PasswordRequestEntity PwdRqst)
        {
            /*
            o	Nombre del solicitante: [NombreSolic]
            o	Fecha de solicitud: [FechaSolic]
            o	Fecha de expiración: [FechaExp]
            o	Datos de contraseña solicitada: [UsuarioSolic]
            Para esto se supondrá el formato [ambiente]\[nombre de usuario]
             * */

            MailBody.Replace("[NombreSolic]", PwdRqst.RqstUser.Fullname);
            MailBody.Replace("[FechaSolic]", PwdRqst.RequestDate.ToString("dd/MM/yyyy"));
            MailBody.Replace("[FechaExp]", PwdRqst.ExpirationDate.Value.ToString("dd/MM/yyyy"));
            string UsuarioSolicitado = "";
            //PwdRqst.
            return MailBody;
        }

    }
}
