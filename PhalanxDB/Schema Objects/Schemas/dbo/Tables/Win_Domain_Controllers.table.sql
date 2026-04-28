CREATE TABLE [dbo].[Win_Domain_Controllers] (
    [win_dc_id]           INT      IDENTITY (1, 1) NOT NULL,
    [win_domain_id]       INT      NOT NULL,
    [dc_type]             CHAR (1) COLLATE Latin1_General_CI_AS NOT NULL,
    [win_pc_id]           INT      NOT NULL,
    [impersonate_user_id] INT      NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que corresponde el domain controller', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'win_domain_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de DC, P: primary - B: backup', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'dc_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'usuario que se usa para hacer el impersonate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'impersonate_user_id';

