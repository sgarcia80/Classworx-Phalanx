CREATE TABLE [dbo].[Users] (
    [user_id]          INT           IDENTITY (1, 1) NOT NULL,
    [username]         VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [active_user]      BIT           NULL,
    [user_type_id]     INT           NULL,
    [user_password_id] INT           NULL,
    [user_desc]        VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [user_critical]    BIT           NULL,
    [modifying_date]   DATETIME      NULL,
    [modifying_user]   INT           NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Esta tabla contiene a los usuarios de los que se les administrará su password', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica si esta cuenta está activa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'active_user';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Indica el tipo de usuario (de dominio, de sql server, local de una workstation)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_type_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del uso del usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_desc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'este campo indica si es usuario crítico - 1 = critico - 0= no', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_critical';

