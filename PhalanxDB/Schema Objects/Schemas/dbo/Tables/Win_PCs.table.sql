CREATE TABLE [dbo].[Win_PCs] (
    [win_pc_id]     INT           IDENTITY (1, 1) NOT NULL,
    [pc_name]       VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [win_domain_id] INT           NULL,
    [pc_ip]         VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [pc_desc]       VARCHAR (200) NULL,
    [active]        BIT           NOT NULL,
    [checkable]     BIT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que pertenece la PC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_PCs', @level2type = N'COLUMN', @level2name = N'win_domain_id';

