CREATE TABLE [dbo].[Phx_Users] (
    [phx_user_id]               INT           IDENTITY (1, 1) NOT NULL,
    [username]                  VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [fullname]                  VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [user_domain]               VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [user_email]                VARCHAR (150) COLLATE Latin1_General_CI_AS NULL,
    [creation_date]             DATETIME      NULL,
    [delete_date]               DATETIME      NULL,
    [phx_user_file_number]      VARCHAR (10)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_relation_type]    CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [phx_user_branch]           VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [phx_user_function]         VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_adress]  VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_floor]   VARCHAR (5)   COLLATE Latin1_General_CI_AS NULL,
    [phx_user_extension_number] VARCHAR (4)   COLLATE Latin1_General_CI_AS NULL,
    [active]                    BIT           NOT NULL,
    [sup_id]                    INT           NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuarios de algún módulo del sistema. Con seguridad integrada con windows serían usuarios de Windows', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre de usuario. En un principio sería el usuario del dominio', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'username';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre completo del usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'fullname';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Dominio al cual pertenece el usuario. El nombre del dominio será en formato NT Domain', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'user_domain';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha de baja', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'delete_date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'legajo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_file_number';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'relacion laboral - I=interno - E=Externo - P=Proveedor', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_relation_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'funcion - perfil laboral', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_function';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Domicilio Edificio', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_building_adress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'piso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_building_floor';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'interno', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_extension_number';

