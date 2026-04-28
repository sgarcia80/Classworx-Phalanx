ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [FK_audit_login_evento_login] FOREIGN KEY ([evento_login_id]) REFERENCES [dbo].[evento_login] ([evento_login_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

