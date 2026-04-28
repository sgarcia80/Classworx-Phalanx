ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [FK_Password_Requests_Request_States] FOREIGN KEY ([rqst_state_id]) REFERENCES [dbo].[Request_States] ([rqst_state_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

