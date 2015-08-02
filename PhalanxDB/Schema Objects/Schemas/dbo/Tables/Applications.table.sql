CREATE TABLE [dbo].[Applications] (
    [app_id]               INT           IDENTITY (1, 1) NOT NULL,
    [app_name]             VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [app_desc]             VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [app_field1_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [app_field2_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [app_field3_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [active]               BIT           NOT NULL,
    [desactiva_pwd_cierre] BIT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de campo 1 de datos extra', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications', @level2type = N'COLUMN', @level2name = N'app_field1_desc';

