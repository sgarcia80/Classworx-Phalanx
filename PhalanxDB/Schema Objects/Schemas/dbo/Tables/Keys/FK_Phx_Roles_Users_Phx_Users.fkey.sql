ALTER TABLE [dbo].[Phx_Roles_Users]
    ADD CONSTRAINT [FK_Phx_Roles_Users_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

