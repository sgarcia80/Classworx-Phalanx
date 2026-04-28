CREATE TABLE [dbo].[Users_Passwords] (
    [user_password_id] INT           IDENTITY (1, 1) NOT NULL,
    [password]         VARCHAR (550) COLLATE Latin1_General_CI_AS NULL,
    [static_pwd]       BIT           NOT NULL,
    [d_next_change]    DATETIME      NULL,
    [d_last_change]    DATETIME      NULL,
    [change_freq]      NUMERIC (3)   NULL,
    [change_freq_unit] CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [d_next_chk]       DATETIME      NULL,
    [d_last_chk]       DATETIME      NULL,
    [chk_freq]         NUMERIC (3)   NULL,
    [chk_freq_unit]    CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [pwd_lock_type_id] INT           NULL,
    [chk_pwd]          BIT           NOT NULL,
    [d_lock_pwd]       DATETIME      NULL,
    [d_in_use_until]   DATETIME      NULL,
    [concurrent]       BIT           NOT NULL,
    [checkeable]       BIT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'campo de contraseña pensado para encriptación de 448 bits (56 bytes o 112 chars hexa)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica si la clave es estática (1: si - 0: no)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'static_pwd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica la fecha en que se debe hacer le próximo cambio de la pwd', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_next_change';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se cambió el pwd por última vez', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_last_change';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'frecuencia de cambio. esta es la cantidad. luego se ve en el campo que indica la unidad de medida', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'change_freq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'unidad de medida de la frecuencia del cambio (H: hrs - D: días - W:semanas - M: meses - Y: años)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'change_freq_unit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se debe realizar el próximo chequee de no alteración de pwd', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_next_chk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se chequeó por última vez la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_last_chk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'frecuencia de chequeo. esta es la cantidad. luego se ve en el campo que indica la unidad de medida', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_freq';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'unidad de medida de la frecuencia de chequeo (H: hrs - D: días - W:semanas - M: meses - Y: años)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_freq_unit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'id del tipo de lockeo que tiene la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'pwd_lock_type_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si la contraseña debe ser chequeada', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_pwd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se lockeó la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_lock_pwd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha hasta que la contraseña está en uso por visualización. Lock type debe tener lockeo por contraseña en uso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_in_use_until';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si la contraseña puede ser visualizada por mas de una persona a la vez', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'concurrent';

