ALTER TABLE [dbo].[hist_change_password_historico]
    ADD CONSTRAINT [FK_hist_change_password_historico_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

