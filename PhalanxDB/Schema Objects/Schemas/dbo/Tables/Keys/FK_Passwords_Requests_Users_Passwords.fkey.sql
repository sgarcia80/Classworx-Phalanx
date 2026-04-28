ALTER TABLE [dbo].[Passwords_Requests]
    ADD CONSTRAINT [FK_Passwords_Requests_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

