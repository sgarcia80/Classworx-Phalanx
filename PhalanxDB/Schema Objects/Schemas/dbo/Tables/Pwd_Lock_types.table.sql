CREATE TABLE [dbo].[Pwd_Lock_types] (
    [pwd_lock_type_id]   INT           IDENTITY (1, 1) NOT NULL,
    [pwd_lock_type_code] VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [pwd_lock_type_desc] VARCHAR (150) COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código interno del tipo de lockeo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Pwd_Lock_types', @level2type = N'COLUMN', @level2name = N'pwd_lock_type_code';

