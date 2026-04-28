CREATE TABLE [dbo].[Win_Groups] (
    [win_group_id]  INT          IDENTITY (1, 1) NOT NULL,
    [ad_group_name] VARCHAR (64) COLLATE Latin1_General_CI_AS NULL,
    [nt_group_name] VARCHAR (40) COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nobre del grupo de 64 caracteres para active directory', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Groups', @level2type = N'COLUMN', @level2name = N'ad_group_name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del grupo compatible con dominios nt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Groups', @level2type = N'COLUMN', @level2name = N'nt_group_name';

