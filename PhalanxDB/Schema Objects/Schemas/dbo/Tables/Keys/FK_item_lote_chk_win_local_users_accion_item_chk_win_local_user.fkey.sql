ALTER TABLE [dbo].[item_lote_chk_win_local_users]
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_accion_item_chk_win_local_user] FOREIGN KEY ([accion]) REFERENCES [dbo].[accion_item_chk_win_local_user] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

