ALTER TABLE [dbo].[ATMs_Users]
    ADD CONSTRAINT [FK_ATMs_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

