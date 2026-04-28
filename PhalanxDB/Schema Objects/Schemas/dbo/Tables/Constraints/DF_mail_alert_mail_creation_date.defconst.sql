ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [DF_mail_alert_mail_creation_date] DEFAULT (getdate()) FOR [mail_creation_date];

