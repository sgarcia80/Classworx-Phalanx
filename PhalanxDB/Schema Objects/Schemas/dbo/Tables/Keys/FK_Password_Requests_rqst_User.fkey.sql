ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [FK_Password_Requests_rqst_User] FOREIGN KEY ([rqst_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

