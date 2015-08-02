ALTER TABLE [dbo].[Delegation_Requests]
    ADD CONSTRAINT [FK_Delegation_Requests_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

