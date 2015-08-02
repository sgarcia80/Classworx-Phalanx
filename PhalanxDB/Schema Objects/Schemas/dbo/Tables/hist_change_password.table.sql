CREATE TABLE [dbo].[hist_change_password] (
    [hist_chg_pwd_id] INT           IDENTITY (1, 1) NOT NULL,
    [user_id]         INT           NOT NULL,
    [phx_user_id]     INT           NULL,
    [d_change]        DATETIME      NOT NULL,
    [password]        VARCHAR (550) NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id del usuario que la cambió. Puede ser null por si el que la cambio fue un proceso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'hist_change_password', @level2type = N'COLUMN', @level2name = N'phx_user_id';

