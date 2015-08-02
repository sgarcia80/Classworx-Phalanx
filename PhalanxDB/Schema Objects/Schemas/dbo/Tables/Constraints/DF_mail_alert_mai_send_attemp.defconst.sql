ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [DF_mail_alert_mai_send_attemp] DEFAULT ((0)) FOR [mail_send_attemp];

