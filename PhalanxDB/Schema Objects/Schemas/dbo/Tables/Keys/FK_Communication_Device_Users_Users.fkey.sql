ALTER TABLE [dbo].[Communication_Device_Users]
    ADD CONSTRAINT [FK_Communication_Device_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

