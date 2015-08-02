ALTER TABLE [dbo].[Local_Win_Groups]
    ADD CONSTRAINT [FK_Local_Win_Groups_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

