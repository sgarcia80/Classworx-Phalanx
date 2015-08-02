ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK_Users_User_Types] FOREIGN KEY ([user_type_id]) REFERENCES [dbo].[User_Types] ([user_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

