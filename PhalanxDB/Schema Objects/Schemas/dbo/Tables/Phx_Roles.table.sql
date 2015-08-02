CREATE TABLE [dbo].[Phx_Roles] (
    [phx_role_id] INT           IDENTITY (1, 1) NOT NULL,
    [role_name]   VARCHAR (200) COLLATE Latin1_General_CI_AS NOT NULL,
    [role_code]   VARCHAR (20)  COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código del Rol. Para no estar pendiente del ID ya que es identity', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Roles', @level2type = N'COLUMN', @level2name = N'role_code';

