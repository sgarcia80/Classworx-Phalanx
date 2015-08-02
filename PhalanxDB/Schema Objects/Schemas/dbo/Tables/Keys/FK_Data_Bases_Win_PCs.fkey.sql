ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [FK_Data_Bases_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

