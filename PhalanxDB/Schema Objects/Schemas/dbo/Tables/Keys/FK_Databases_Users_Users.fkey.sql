ALTER TABLE [dbo].[Databases_Users]
    ADD CONSTRAINT [FK_Databases_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

