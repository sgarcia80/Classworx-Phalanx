ALTER TABLE [dbo].[Rqst_Grps_Pwds]
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

