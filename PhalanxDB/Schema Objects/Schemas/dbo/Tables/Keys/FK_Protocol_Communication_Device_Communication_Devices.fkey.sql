ALTER TABLE [dbo].[Protocol_Communication_Device]
    ADD CONSTRAINT [FK_Protocol_Communication_Device_Communication_Devices] FOREIGN KEY ([cm_dv_id]) REFERENCES [dbo].[Communication_Devices] ([cm_dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

