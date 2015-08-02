ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [FK_Phx_Users_Phx_User_Superior] FOREIGN KEY ([sup_id]) REFERENCES [dbo].[Phx_User_Superior] ([sup_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

