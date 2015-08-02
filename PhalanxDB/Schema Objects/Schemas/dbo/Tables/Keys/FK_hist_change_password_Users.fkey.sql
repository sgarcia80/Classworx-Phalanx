ALTER TABLE [dbo].[hist_change_password]
    ADD CONSTRAINT [FK_hist_change_password_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

