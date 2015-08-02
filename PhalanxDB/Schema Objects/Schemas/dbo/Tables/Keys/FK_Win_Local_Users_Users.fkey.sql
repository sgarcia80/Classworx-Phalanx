ALTER TABLE [dbo].[Win_Local_Users]
    ADD CONSTRAINT [FK_Win_Local_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

