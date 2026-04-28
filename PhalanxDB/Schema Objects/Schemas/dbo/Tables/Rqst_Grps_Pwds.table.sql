CREATE TABLE [dbo].[Rqst_Grps_Pwds] (
    [pwdrqst_grp_pwd_id] INT IDENTITY (1, 1) NOT NULL,
    [rqst_grp_id]        INT NOT NULL,
    [user_password_id]   INT NOT NULL,
    [auth1_usr_id]       INT NULL,
    [auth2_usr_id]       INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Passwords a las que tiene acceso cada Grupo con sus restricciones', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';

