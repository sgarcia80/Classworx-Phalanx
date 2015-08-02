CREATE TABLE [dbo].[Global_Win_Groups] (
    [win_group_id]  INT NOT NULL,
    [win_domain_id] INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que pertenece el grupo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Global_Win_Groups', @level2type = N'COLUMN', @level2name = N'win_domain_id';

