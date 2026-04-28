ALTER TABLE [dbo].[Global_Win_Groups]
    ADD CONSTRAINT [FK_Global_Win_Groups_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

