ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [FK_mail_alert_Mail_type] FOREIGN KEY ([mail_type_id]) REFERENCES [dbo].[Mail_type] ([mail_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

