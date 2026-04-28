ALTER TABLE [dbo].[Phx_Users_Groups]
    ADD CONSTRAINT [FK_Phx_Users_Groups_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

