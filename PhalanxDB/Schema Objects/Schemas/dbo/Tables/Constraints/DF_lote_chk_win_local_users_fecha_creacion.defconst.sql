ALTER TABLE [dbo].[lote_chk_win_local_users]
    ADD CONSTRAINT [DF_lote_chk_win_local_users_fecha_creacion] DEFAULT (getdate()) FOR [fecha_creacion];

