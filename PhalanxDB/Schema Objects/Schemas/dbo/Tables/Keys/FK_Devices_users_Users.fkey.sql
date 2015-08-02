ALTER TABLE [dbo].[Devices_users]
    ADD CONSTRAINT [FK_Devices_users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

