ALTER TABLE [dbo].[followup_request_group_password]
    ADD CONSTRAINT [FK_followup_request_group_password_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

