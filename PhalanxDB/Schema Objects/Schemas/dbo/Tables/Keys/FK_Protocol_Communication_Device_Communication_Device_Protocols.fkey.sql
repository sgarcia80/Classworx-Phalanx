ALTER TABLE [dbo].[Protocol_Communication_Device]
    ADD CONSTRAINT [FK_Protocol_Communication_Device_Communication_Device_Protocols] FOREIGN KEY ([cm_dv_protocol_id]) REFERENCES [dbo].[Communication_Device_Protocols] ([cm_dv_protocol_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

