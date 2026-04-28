ALTER TABLE [dbo].[Win_Local_Users]
    ADD CONSTRAINT [FK_Win_Local_Users_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

