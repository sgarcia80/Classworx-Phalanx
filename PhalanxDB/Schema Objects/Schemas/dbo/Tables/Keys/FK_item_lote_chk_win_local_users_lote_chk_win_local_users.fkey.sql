ALTER TABLE [dbo].[item_lote_chk_win_local_users]
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_lote_chk_win_local_users] FOREIGN KEY ([lote]) REFERENCES [dbo].[lote_chk_win_local_users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

