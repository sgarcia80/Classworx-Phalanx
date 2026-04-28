ALTER TABLE [dbo].[hist_change_password]
    ADD CONSTRAINT [FK_hist_change_password_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

