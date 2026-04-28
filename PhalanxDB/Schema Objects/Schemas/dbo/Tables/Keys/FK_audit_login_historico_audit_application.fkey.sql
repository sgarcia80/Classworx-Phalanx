ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [FK_audit_login_historico_audit_application] FOREIGN KEY ([app_id]) REFERENCES [dbo].[audit_application] ([aa_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

