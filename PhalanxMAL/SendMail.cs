using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace PhalanxMAL
{
    public class SendMail
    {
        private string _smtp_server;
        private int _smtp_port = 25;
        private bool _smtp_needs_auth = false;
        private string _smtp_user;
        private string _smtp_pwd;
        private SmtpClient sMail;
        private string _error_message;

        #region Constructors
        public SendMail(string SMTPServer)
            :this(SMTPServer, 25)
        {

        }
        public SendMail(string SMTPServer, int SMTPPort)
            : this(SMTPServer, SMTPPort, "", "")
        {
        }
        public SendMail(string SMTPServer, int SMTPPort, string SMTPUser, string SMTPPassword)
        {
            _smtp_port = SMTPPort;
            _smtp_server = SMTPServer;
            sMail = new SmtpClient(_smtp_server, _smtp_port);//exchange or smtp server goes here.
            _smtp_user = SMTPUser;
            _smtp_pwd = SMTPPassword;
            if (SMTPUser != "")
            {
                _smtp_needs_auth = true;
                sMail.UseDefaultCredentials = false;
                sMail.Credentials = new NetworkCredential(_smtp_user, _smtp_pwd); //this line most likely wont be needed if you are already an authenticated user.
            }

        }
        #endregion

        public string Message
        {
            get { return _error_message; }
        }

        public bool Send(string FromName, string FromMail, string Subject, string Body
            , MailAddressCollection CCMailAddresses)
        {
            try
            {
                MailMessage MailToSend = new MailMessage();
                MailToSend.Body = Body;
                MailToSend.Subject = Subject;

                // setea el from
                MailAddress fromEmail;
                if (FromName != "")
                {
                    fromEmail = new MailAddress(FromMail, FromName);
                }
                else
                {
                    fromEmail = new MailAddress(FromMail);
                }
                MailToSend.From = fromEmail;
                for (int i = 0; i < CCMailAddresses.Count; i++)
                {
                    if (i == 0)
                    {
                        MailToSend.To.Add(CCMailAddresses[i]);
                    }
                    else
                    {
                        MailToSend.CC.Add(CCMailAddresses[i]);
                    }
                } 
                sMail.Send(MailToSend); //(fromEmail, ToEmail, subject, body);
                _error_message = "";
                return true;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += " - " + ex.InnerException.Message;
                }
                _error_message = Mensaje;
                return false;
            }
        }

        public bool Send(string FromName, string FromMail, string Subject, string Body
            , string ToName, string ToMail, string Cc1Name, string Cc1Mail, string Cc2Name, string Cc2Mail)
        {
            try
            {
                MailMessage MailToSend = new MailMessage();
                MailToSend.Body = Body;
                MailToSend.Subject = Subject;

                // setea el from
                MailAddress fromEmail;
                if (FromName != "")
                {
                    fromEmail = new MailAddress(FromMail, FromName);
                }
                else
                {
                    fromEmail = new MailAddress(FromMail);
                }
                MailToSend.From = fromEmail;
                
                // setea el To
                MailAddress ToEmail;
                if (ToName != "")
                {
                    ToEmail = new MailAddress(ToMail, ToName);
                }
                else
                {
                    ToEmail = new MailAddress(ToMail);
                }
                MailToSend.To.Add(ToEmail);

                // setea el Cc1
                if (Cc1Mail != "")
                {
                    MailAddress Cc1Email;
                    if (Cc1Name != "")
                    {
                        Cc1Email = new MailAddress(Cc1Mail, Cc1Name);
                    }
                    else
                    {
                        Cc1Email = new MailAddress(Cc1Mail);
                    }
                    MailToSend.CC.Add(Cc1Email);
                }

                // setea el Cc2
                if (Cc2Mail != "")
                {
                    MailAddress Cc2Email;
                    if (Cc2Name != "")
                    {
                        Cc2Email = new MailAddress(Cc2Mail, Cc2Name);
                    }
                    else
                    {
                        Cc2Email = new MailAddress(Cc2Mail);
                    }
                    MailToSend.CC.Add(Cc2Email);
                }

                sMail.Send(MailToSend); //(fromEmail, ToEmail, subject, body);
                _error_message = "";
                return true;
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                if (ex.InnerException != null)
                {
                    Mensaje += " - " + ex.InnerException.Message;
                }
                _error_message = Mensaje;
                return false;
            }

        }
    }
}
