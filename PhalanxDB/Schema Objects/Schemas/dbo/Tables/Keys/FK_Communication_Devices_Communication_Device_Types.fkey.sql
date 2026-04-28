ALTER TABLE [dbo].[Communication_Devices]
    ADD CONSTRAINT [FK_Communication_Devices_Communication_Device_Types] FOREIGN KEY ([cm_dv_type_id]) REFERENCES [dbo].[Communication_Device_Types] ([cm_dv_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

