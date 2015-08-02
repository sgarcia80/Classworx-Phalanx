ALTER TABLE [dbo].[Rqst_Grps_Deleg]
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth2Users] FOREIGN KEY ([auth2_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

