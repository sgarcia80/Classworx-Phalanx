ALTER TABLE [dbo].[item_lote_chk_win_local_users]
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_Win_Local_Users] FOREIGN KEY ([win_local_user]) REFERENCES [dbo].[Win_Local_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

