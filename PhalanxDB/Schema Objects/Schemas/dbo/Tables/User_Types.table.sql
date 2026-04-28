CREATE TABLE [dbo].[User_Types] (
    [user_type_id]   INT          NOT NULL,
    [user_type_desc] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipos de usuarios de quienes se administran las passwords', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User_Types';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de usuario (usuario local windows, usuario de dominio windows, usuario de SQL Server, usuario Unix, etc)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User_Types', @level2type = N'COLUMN', @level2name = N'user_type_desc';

