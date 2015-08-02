ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [FK_Requests_Return_User] FOREIGN KEY ([return_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

