ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [FK_audit_login_audit_application] FOREIGN KEY ([app_id]) REFERENCES [dbo].[audit_application] ([aa_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

