ALTER TABLE [dbo].[followup_request_group_user]
    ADD CONSTRAINT [FK_followup_rqst_grp_user_followup_request_group] FOREIGN KEY ([frg_id]) REFERENCES [dbo].[followup_request_group] ([frg_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

