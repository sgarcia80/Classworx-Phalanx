CREATE TABLE [dbo].[lote_chk_win_local_users] (
    [id]                   INT      IDENTITY (1, 1) NOT NULL,
    [fecha_programada]     DATETIME NOT NULL,
    [fecha_creacion]       DATETIME NOT NULL,
    [fecha_inicio_proceso] DATETIME NULL,
    [fecha_fin_proceso]    DATETIME NULL
);

