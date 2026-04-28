ALTER TABLE [dbo].[Rqst_Grps_Deleg]
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

