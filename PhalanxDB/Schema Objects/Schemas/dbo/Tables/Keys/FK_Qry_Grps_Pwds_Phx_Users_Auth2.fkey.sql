ALTER TABLE [dbo].[Rqst_Grps_Pwds]
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Phx_Users_Auth2] FOREIGN KEY ([auth2_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

