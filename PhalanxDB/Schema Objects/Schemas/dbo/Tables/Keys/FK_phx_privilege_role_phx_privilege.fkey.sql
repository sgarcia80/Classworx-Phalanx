ALTER TABLE [dbo].[phx_privilege_role]
    ADD CONSTRAINT [FK_phx_privilege_role_phx_privilege] FOREIGN KEY ([phx_privilege_id]) REFERENCES [dbo].[phx_privilege] ([phx_privilege_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

