ALTER TABLE [dbo].[audit_usuarios]
    ADD CONSTRAINT [FK_audit_usuarios_audit_phx_user_new] FOREIGN KEY ([audit_phx_user_id_old]) REFERENCES [dbo].[audit_phx_user] ([audit_phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

