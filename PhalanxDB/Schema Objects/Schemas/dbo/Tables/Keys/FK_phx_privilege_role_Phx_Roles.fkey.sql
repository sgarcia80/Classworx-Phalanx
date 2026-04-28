ALTER TABLE [dbo].[phx_privilege_role]
    ADD CONSTRAINT [FK_phx_privilege_role_Phx_Roles] FOREIGN KEY ([phx_role_id]) REFERENCES [dbo].[Phx_Roles] ([phx_role_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

