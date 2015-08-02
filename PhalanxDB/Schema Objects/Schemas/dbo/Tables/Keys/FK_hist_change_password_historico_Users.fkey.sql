ALTER TABLE [dbo].[hist_change_password_historico]
    ADD CONSTRAINT [FK_hist_change_password_historico_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

