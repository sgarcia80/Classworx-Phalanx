ALTER TABLE [dbo].[Passwords_Requests]
    ADD CONSTRAINT [FK_Passwords_Requests_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

