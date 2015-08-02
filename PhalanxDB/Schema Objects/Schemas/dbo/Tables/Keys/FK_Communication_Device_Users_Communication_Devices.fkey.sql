ALTER TABLE [dbo].[Communication_Device_Users]
    ADD CONSTRAINT [FK_Communication_Device_Users_Communication_Devices] FOREIGN KEY ([cm_dv_id]) REFERENCES [dbo].[Communication_Devices] ([cm_dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

