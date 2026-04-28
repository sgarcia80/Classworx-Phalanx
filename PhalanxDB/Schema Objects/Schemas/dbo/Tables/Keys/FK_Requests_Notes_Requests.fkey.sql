ALTER TABLE [dbo].[Requests_Notes]
    ADD CONSTRAINT [FK_Requests_Notes_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

