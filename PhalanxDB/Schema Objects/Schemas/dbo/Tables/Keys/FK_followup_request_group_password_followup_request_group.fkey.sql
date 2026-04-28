ALTER TABLE [dbo].[followup_request_group_password]
    ADD CONSTRAINT [FK_followup_request_group_password_followup_request_group] FOREIGN KEY ([frg_id]) REFERENCES [dbo].[followup_request_group] ([frg_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

