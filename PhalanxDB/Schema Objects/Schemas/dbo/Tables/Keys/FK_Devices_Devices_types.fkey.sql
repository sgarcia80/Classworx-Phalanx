ALTER TABLE [dbo].[Devices]
    ADD CONSTRAINT [FK_Devices_Devices_types] FOREIGN KEY ([dv_type_id]) REFERENCES [dbo].[Devices_types] ([dv_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

