ALTER TABLE [dbo].[followup_request_group_user]
    ADD CONSTRAINT [FK_followup_rqst_grp_user_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

