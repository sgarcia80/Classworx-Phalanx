ALTER TABLE [dbo].[followup_request_group_default]
    ADD CONSTRAINT [FK_followup_request_group_default_User_Types] FOREIGN KEY ([user_type_id]) REFERENCES [dbo].[User_Types] ([user_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

