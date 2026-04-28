CREATE TABLE [dbo].[Win_Domains] (
    [win_domain_id] INT           IDENTITY (1, 1) NOT NULL,
    [nt_name]       VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [ad_name]       VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [Comments]      VARCHAR (255) COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del dominio según formato NT', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domains', @level2type = N'COLUMN', @level2name = N'nt_name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del dominio según formato active directory', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domains', @level2type = N'COLUMN', @level2name = N'ad_name';

