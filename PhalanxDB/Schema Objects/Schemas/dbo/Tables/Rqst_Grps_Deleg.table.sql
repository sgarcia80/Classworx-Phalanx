CREATE TABLE [dbo].[Rqst_Grps_Deleg] (
    [delrqst_grp_delg_id] INT IDENTITY (1, 1) NOT NULL,
    [rqst_grp_id]         INT NOT NULL,
    [win_group_id]        INT NOT NULL,
    [auth1_usr_id]        INT NULL,
    [auth2_usr_id]        INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Deleg', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Deleg', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';

