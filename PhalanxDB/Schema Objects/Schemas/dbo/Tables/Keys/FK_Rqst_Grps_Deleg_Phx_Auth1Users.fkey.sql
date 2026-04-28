ALTER TABLE [dbo].[Rqst_Grps_Deleg]
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth1Users] FOREIGN KEY ([auth1_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

