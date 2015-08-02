CREATE TABLE [dbo].[item_lote_chk_win_local_users] (
    [id]                     INT           IDENTITY (1, 1) NOT NULL,
    [lote]                   INT           NOT NULL,
    [win_local_user]         INT           NOT NULL,
    [fecha_chk]              DATETIME      NULL,
    [chk_ping_nombre_equipo] BIT           NULL,
    [chk_ping_ip_equipo]     BIT           NULL,
    [chk_pwd]                BIT           NULL,
    [nombre_equipo_ping_ip]  VARCHAR (150) NULL,
    [chk_username]           BIT           NULL,
    [accion]                 INT           NULL
);

