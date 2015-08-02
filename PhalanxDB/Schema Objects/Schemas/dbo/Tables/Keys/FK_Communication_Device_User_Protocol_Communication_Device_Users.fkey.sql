ALTER TABLE [dbo].[Communication_Device_User_Protocol]
    ADD CONSTRAINT [FK_Communication_Device_User_Protocol_Communication_Device_Users] FOREIGN KEY ([cm_dv_user_id]) REFERENCES [dbo].[Communication_Device_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

