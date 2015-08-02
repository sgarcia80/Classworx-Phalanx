CREATE TABLE [dbo].[Win_Domain_Users] (
    [user_id]        INT NOT NULL,
    [win_domain_id]  INT NULL,
    [user_domain_id] INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'id asignado para el usuario en el dominio por el domain controller', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Users', @level2type = N'COLUMN', @level2name = N'user_domain_id';

