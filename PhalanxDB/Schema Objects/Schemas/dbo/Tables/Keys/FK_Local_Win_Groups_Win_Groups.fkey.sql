ALTER TABLE [dbo].[Local_Win_Groups]
    ADD CONSTRAINT [FK_Local_Win_Groups_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

