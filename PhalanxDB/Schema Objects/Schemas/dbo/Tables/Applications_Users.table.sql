CREATE TABLE [dbo].[Applications_Users] (
    [user_id]          INT          NOT NULL,
    [app_id]           INT          NOT NULL,
    [app_field1_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL,
    [app_field2_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL,
    [app_field3_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 1 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field1_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 2 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field2_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 3 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field3_value';

