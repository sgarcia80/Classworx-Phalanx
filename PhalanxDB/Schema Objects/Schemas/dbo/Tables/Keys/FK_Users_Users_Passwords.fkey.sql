ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK_Users_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

