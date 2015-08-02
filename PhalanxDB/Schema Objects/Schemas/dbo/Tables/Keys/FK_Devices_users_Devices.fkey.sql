ALTER TABLE [dbo].[Devices_users]
    ADD CONSTRAINT [FK_Devices_users_Devices] FOREIGN KEY ([dv_id]) REFERENCES [dbo].[Devices] ([dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

