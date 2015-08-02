CREATE TABLE [dbo].[hist_change_password_historico] (
    [hist_chg_pwd_id] INT           NOT NULL,
    [user_id]         INT           NOT NULL,
    [phx_user_id]     INT           NULL,
    [d_change]        DATETIME      NOT NULL,
    [password]        VARCHAR (550) NULL,
    [fecha_borrado]   DATETIME      NOT NULL
);

