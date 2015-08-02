ALTER TABLE [dbo].[Requests_Notes]
    ADD CONSTRAINT [FK_Requests_Notes_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

