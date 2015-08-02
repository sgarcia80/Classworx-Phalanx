ALTER TABLE [dbo].[Phx_Roles_Users]
    ADD CONSTRAINT [FK_Phx_Roles_Users_Phx_Roles] FOREIGN KEY ([phx_role_id]) REFERENCES [dbo].[Phx_Roles] ([phx_role_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

