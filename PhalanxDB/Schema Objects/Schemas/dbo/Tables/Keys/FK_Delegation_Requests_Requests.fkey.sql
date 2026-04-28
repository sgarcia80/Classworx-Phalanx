ALTER TABLE [dbo].[Delegation_Requests]
    ADD CONSTRAINT [FK_Delegation_Requests_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

