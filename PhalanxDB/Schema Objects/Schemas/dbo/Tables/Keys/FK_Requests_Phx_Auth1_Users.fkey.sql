ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [FK_Requests_Phx_Auth1_Users] FOREIGN KEY ([auth1_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

